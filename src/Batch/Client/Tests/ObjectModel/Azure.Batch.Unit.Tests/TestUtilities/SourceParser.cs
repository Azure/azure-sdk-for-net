// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Uses regular expressions to parse source code
    /// </summary>
    public class SourceParser
    {
        public IReadOnlyList<string> SourceFolders { get; private set; }

        public string FileNamePattern { get; private set; }

        public string FileNameExcludePattern { get; private set; }

        public string SearchPattern { get; private set; }

        public SourceParser(string sourceRoot, string fileNamePattern, string fileNameExcludePattern, string searchPattern) :
            this(new List<string>() { sourceRoot }, fileNamePattern, fileNameExcludePattern, searchPattern)
        {
        }

        public SourceParser(IReadOnlyList<string> sourceFolders, string fileNamePattern, string fileNameExcludePattern, string searchPattern)
        {
            this.SourceFolders = sourceFolders;
            this.FileNamePattern = fileNamePattern;
            this.FileNameExcludePattern = fileNameExcludePattern;
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
            Regex fileNameRegex = new Regex(this.FileNamePattern);
            Regex fileNameExcludeRegex = string.IsNullOrEmpty(this.FileNameExcludePattern) ? null : new Regex(this.FileNameExcludePattern);

            foreach (string sourceFolder in this.SourceFolders)
            {
                IEnumerable<string> files = Directory.EnumerateFiles(sourceFolder, "*.*", SearchOption.AllDirectories)
                    .Where(fileName => fileNameRegex.Match(fileName).Success)
                    .Where(fileName => fileNameExcludeRegex == null || !fileNameExcludeRegex.Match(fileName).Success);

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
