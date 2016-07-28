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
