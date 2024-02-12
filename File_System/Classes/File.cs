using File_Sytem.Interfaces;

namespace File_System.Classes;

public class File : IDirectoryObjects
{
	public string _path { get; private set; }
	public string _name { get; private set; }
	public string _content { get; private set; }
	public File(string path, string name, string content)
	{
		_path = name;
		_name = name;
		_content = content;
	}

	public string GetContents()
	{
		return _content;
	}
}

