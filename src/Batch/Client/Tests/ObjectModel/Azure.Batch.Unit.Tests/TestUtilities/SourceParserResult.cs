﻿namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class SourceParserResult
    {
        public Match Match { get; private set; }

        public string File { get; private set; }

        public int LineNumber { get; private set; }

        public SourceParserResult(string file, Match match, int lineNumber)
        {
            this.File = file;
            this.Match = match;
            this.LineNumber = lineNumber;
        }
    }
}
