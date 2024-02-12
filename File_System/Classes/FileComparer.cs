using System;
namespace File_System.Classes
{
	public class FileComparer : Comparer<File>
	{
		public FileComparer()
		{
		}

        public override int Compare(File? x, File? y)
        {
            return Comparer<string>.Default.Compare(x!._name, y!._name);
        }
    }
}

