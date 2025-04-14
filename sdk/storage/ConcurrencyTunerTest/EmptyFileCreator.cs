using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyTunerTest
{
    internal class EmptyFileCreator
    {
        int _numOfFiles;
        string _path;
        Range _fileSizeRange;

        internal EmptyFileCreator Location(string location)
        {
            _path = Path.GetFullPath(location);

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            return this;
        }

        internal void Build()
        {
            foreach (int i in Enumerable.Range(0, _numOfFiles))
            {
                string filePath = Path.Combine(_path, $"file{i}");
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    Random rand = new Random();
                    int fileSize = rand.Next(_fileSizeRange.Start.Value, _fileSizeRange.End.Value);
                    byte[] data = new byte[fileSize];
                    rand.NextBytes(data);
                    fs.Write(data, 0, fileSize);
                }
            }
        }

        internal EmptyFileCreator NumberOfFiles(int numOfFiles)
        {
            _numOfFiles = numOfFiles;
            return this;
        }

        internal EmptyFileCreator RangeOfFileSizeInMB(int lower = 0, int upper = 1)
        {
            lower = ConvertToMB(lower);
            upper = ConvertToMB(upper);
            _fileSizeRange = new Range(lower, upper);
            return this;
        }

        private int ConvertToMB(int num)
        {
            return num * 1024 * 1024;
        }
    }
}
