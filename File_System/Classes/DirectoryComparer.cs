using System;

namespace File_System.Classes
{
	public class DirectoryComparer : Comparer<Directory>
	{
		public DirectoryComparer()
		{
		}

        public override int Compare(Directory? x, Directory? y)
        {
            return Comparer<string>.Default.Compare(x!._name, y!._name);
        }
    }
}

