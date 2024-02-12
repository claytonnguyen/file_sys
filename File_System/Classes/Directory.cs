using System.Linq;
using File_Sytem.Interfaces;

namespace File_System.Classes;

public class Directory : IDirectoryObjects
{
	public string _name { get; private set; }
	public string _path { get; init; }
	private Directory _parent { get; init; }
	private SortedSet<Directory> _childrenDirectories { get; set; }
	private SortedSet<File> _childrenFiles { get; set; }

	public Directory(string path, string name, Directory parentDirectory)
	{
		_path = path;
		_name = name;
		_parent = parentDirectory;
        _childrenDirectories = new SortedSet<Directory>(new DirectoryComparer());
        _childrenFiles = new SortedSet<File>(new FileComparer());
    }

	public void Search(string searchWord)
	{
		foreach(var file in _childrenFiles)
		{
			Console.WriteLine(string.Format("{0}", file._path));
		}
		foreach(var directory in _childrenDirectories)
		{
			Console.WriteLine(string.Format("{0}", directory._path));
		}
	}

	public void CreateDirectory(string directoryName)
	{
		// check if directory with this name already exists
		if (NameAlreadyExists<Directory>(directoryName, _childrenDirectories))
		{
			throw new Exception(string.Format("Directory: {0} already exists", directoryName));
		}

		Directory newDir = new Directory(_path, directoryName, this);
		_childrenDirectories.Add(newDir);
	}

	public void CreateFile(string fileName, string? content = default)
	{
		// check if file with this name already exists
		if (NameAlreadyExists(fileName, _childrenFiles))
		{
			throw new Exception(string.Format("File: {0} already exists", fileName));
		}

		File newFile = new File(_path, fileName, content ?? "");
		_childrenFiles.Add(newFile);
	}

	public void DeleteDirectory(string directoryName)
	{
		Directory? dir = _childrenDirectories?.First(x => x._name == directoryName);
		if(dir is not null)
		{
			_childrenDirectories?.Remove(dir);
		}
	}

	public void DeleteFile(string fileName)
	{
        File? file = _childrenFiles?.First(x => x._name == fileName);
        if (file is not null)
        {
            _childrenFiles?.Remove(file);
        }
    }

	public void ListDirectories()
	{
        if (_childrenDirectories is not null)
        {
            foreach (var directory in _childrenDirectories)
            {
                Console.WriteLine(directory._name);
            }
        }
    }

	public void ListFiles()
	{
		if (_childrenFiles is not null)
		{
            foreach (var file in _childrenFiles)
			{
                Console.WriteLine(file._name);
			}
        }
	}

	public void ListDirectoriesAndFiles()
	{
		ListDirectories();
		ListFiles();
	}

	private bool NameAlreadyExists<T>(string name, SortedSet<T> searchList) where T : IDirectoryObjects
	{
		return !(searchList.FirstOrDefault(x => x._name == name) == null);
	}
}