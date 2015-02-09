//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// Simple Filter parser for $filter expressions on MetricDefinition and Usage calls
    /// Supported Syntax: Name clauses (Name eq 'value') separated by " or "s (no parentheses)
    /// </summary>
    internal static class MetricDefinitionFilterParser
    {
        private static Regex splitRegex = new Regex("\\sor\\s", RegexOptions.Compiled);
        private static Regex clauseRegex = new Regex("^\\s*name\\.value\\s+eq\\s+'(?<value>[^']+)'\\s*$", RegexOptions.Compiled);

        /// <summary>
        /// Parses the filter string
        /// </summary>
        /// <param name="filterString">The $filter string</param>
        /// <returns>The list of names requested</returns>
        public static IEnumerable<string> Parse(string filterString)
        {
            HashSet<string> names = new HashSet<string>();
            string[] clauses = splitRegex.Split(filterString);

            foreach (string clause in clauses)
            {
                Match match = clauseRegex.Match(clause);

                if (!match.Success)
                {
                    throw new FormatException("Only conditions of the form 'name.value eq <value>' are allowed");
                }

                names.Add(match.Groups["value"].Captures[0].Value);
            }

            return names;
        }
    }
}
