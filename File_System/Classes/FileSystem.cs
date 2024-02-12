namespace File_System.Classes;

public class FileSystem
{
	public Directory rootDirectory { get; init; }
	public Directory currentDirectory { get; set; }
	public FileSystem(string path)
	{
		rootDirectory = new Directory(path, "root", null!);
		currentDirectory = rootDirectory;
	}
}
