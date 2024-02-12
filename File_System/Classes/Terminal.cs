using File_System.Enums;

namespace File_System.Classes;

public class Terminal
{
    public FileSystem fileSystem = new FileSystem("/");

    public Terminal()
	{ }

	public void Start()
	{
        while (true)
        {
            List<TerminalCommand> listOfCommands = new List<TerminalCommand>();
            TerminalCommand? currentCommand = null;

            while (currentCommand is null)
            {
                currentCommand = GetCommand();
            }

            Action DirectoryMethod = CommandToMethod((TerminalCommand)currentCommand);
            DirectoryMethod.Invoke();

            listOfCommands.Add((TerminalCommand)currentCommand);
            currentCommand = null;
        }
    }

    public TerminalCommand? GetCommand()
    {
        string input;

        input = Console.ReadLine()?.Normalize() ?? "";
        if (Enum.TryParse<TerminalCommand>(input, true, out TerminalCommand terminalCommand))
        {
            return terminalCommand;
        }

        return null;
    }

    public Action CommandToMethod(TerminalCommand command) => command switch
    {
        TerminalCommand.CD => MoveDirectory,
        TerminalCommand.LS => List,
        TerminalCommand.TOUCH => CreateFile,
        TerminalCommand.MKDIR => CreateDirectory,
        TerminalCommand.CAT => GetContent,
        _ => () => throw new NotImplementedException()
    };

    public void MoveDirectory()
    {
        Console.WriteLine("MoveDirectory");
    }

    public void List()
    {
        Console.WriteLine("List");
    }

    public void CreateFile()
    {
        Console.WriteLine("CreateFile");
    }

    public void CreateDirectory()
    {
        Console.WriteLine("CreateDirectory");
    }

    public void GetContent()
    {
        Console.WriteLine("GetContent");
    }
}
