namespace BatchClientUnitTests.TestUtilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Uses regular expressions to parse source code
    /// </summary>
    public class SourceParser
    {
        public IReadOnlyList<string> SourceFolders { get; private set; }

        public string FileNamePattern { get; private set; }

        public string SearchPattern { get; private set; }

        public SourceParser(string sourceRoot, string fileNamePattern, string searchPattern) : 
            this(new List<string>() { sourceRoot }, fileNamePattern, searchPattern)
        {
        }
        
        public SourceParser(IReadOnlyList<string> sourceFolders, string fileNamePattern, string searchPattern)
        {
            this.SourceFolders = sourceFolders;
            this.FileNamePattern = fileNamePattern;
            this.SearchPattern = searchPattern;
        }

        private static int CalculateLineNumber(string fileString, int stringIndex)
        {
            string fileSubstr = fileString.Substring(0, stringIndex);

            int lineNumber = Regex.Matches(fileSubstr, Environment.NewLine).Count + 1;
            return lineNumber;
        }
        
        public IEnumerable<SourceParserResult> Parse()
        {
            List<SourceParserResult> results = new List<SourceParserResult>();

            Regex regex = new Regex(this.SearchPattern);
            
            foreach (string sourceFolder in this.SourceFolders)
            {
                IEnumerable<string> files = Directory.EnumerateFiles(sourceFolder, this.FileNamePattern, SearchOption.AllDirectories);
                
                foreach (string filePath in files)
                {
                    //Read the entire content of the file into memory
                    string file = File.ReadAllText(filePath);

                    //Find each Regex Match
                    Match match = regex.Match(file);

                    while (match.Success)
                    {
                        int lineNumber = CalculateLineNumber(file, match.Index);
                        results.Add(new SourceParserResult(filePath, match, lineNumber));

                        match = match.NextMatch();
                    }
                }
            }

            return results;
        }
    }
}
