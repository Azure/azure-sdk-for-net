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
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// Simple filter parser class to implement very basic $filter
    /// Supported syntax: (optional names clause) and (timeGrain clause) and (startTime clause) and (endTime clause)
    /// Clauses can be in any order
    /// Names clause must be surrounded by parentheses if it contains multiple names
    /// No parentheses are allowed outside the names clause
    /// NOTE: The regex parser does not currently support dimensions (dimensionname.value, dimensionvalue.value)
    /// </summary>
    internal static class MetricFilterRegexParser
    {
        private static Regex splitOnAndRegex = new Regex("\\sand\\s", RegexOptions.Compiled);
        private static Regex splitOnORegex = new Regex("\\sor\\s", RegexOptions.Compiled);
        private static Regex nameGroupRegex = new Regex("^\\s*\\((?<clauses>[^)]*?)\\)\\s*$", RegexOptions.Compiled);
        private static Regex nameClauseRegex = new Regex("^\\s*name\\.value\\s+eq\\s+'(?<value>[^']*?)'\\s*$", RegexOptions.Compiled);
        private static Regex clauseRegex = new Regex(
                "^\\s*(?<name>(timeGrain|startTime|endTime|name\\.value))\\s+eq\\s+(?<value>('[^']*?')|\\S+|(duration'[^']*?'))\\s*$",
                RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        /// <summary>
        /// Creates a new Filter object from the ($filter) query string
        /// </summary>
        /// <param name="query">The query string</param>
        /// <returns>A filter object representing the query</returns>
        public static MetricFilter Parse(string query)
        {
            MetricFilter filter = new MetricFilter();

            string[] clauses = splitOnAndRegex.Split(query);

            // Grab all the top-level items (separated by ANDs), which can be either simple clauses or a parenthesized group of 'name' clauses
            foreach (string clause in clauses)
            {
                Match nameGroup = nameGroupRegex.Match(clause);

                // If it's in parentheses, it must be a group of 'name' clauses, only 1 is allowed
                if (nameGroup.Success && filter.DimensionFilters == null)
                {
                    // The capturing group strips off the parentheses, leaving the clauses separated by ORs (nested parentheses are not allowed)
                    string[] namesClauses = splitOnORegex.Split(nameGroup.Groups["clauses"].Captures[0].Value);
                    List<string> names = new List<string>();

                    // Parse each 'name' clause and collect the values
                    foreach (string nameClause in namesClauses)
                    {
                        Match match = nameClauseRegex.Match(nameClause);

                        if (!match.Success)
                        {
                            throw new FormatException(
                                "Only conditions of the form 'name.value eq <value>' are allowed inside parentheses");
                        }

                        names.Add(match.Groups["value"].Captures[0].Value);
                    }

                    // an empty group will cause this assignment to throw InvalidOperationException
                    filter.DimensionFilters = names.Select(n => new MetricDimension()
                    {
                        Name = n
                    });
                }
                else if (clause.Trim().StartsWith("("))
                {
                    throw new FormatException("Parentheses Error: only one set of parentheses is allowed; " +
                                              "If present, only (and all) constraints on 'name.value' must appear inside. " +
                                              "No 'and' (and all 'or') operators may appear within parentheses.");
                }
                else
                {
                    // It's not in a group, so it must be a simple clause
                    Match match = clauseRegex.Match(clause);

                    if (!match.Success || match.Groups["name"].Captures.Count <= 0 ||
                        match.Groups["value"].Captures.Count <= 0)
                    {
                        throw new FormatException(
                            "only conditions of the form '<name> eq <value>' are allowed, where <name> = 'timeGrain', 'startTime', 'endTime', or 'name.value'");
                    }

                    // Collect name and value
                    string name = match.Groups["name"].Captures[0].Value;
                    string value = match.Groups["value"].Captures[0].Value;

                    // Case sensitivity is handled in the regex
                    switch (name)
                    {
                        case "timeGrain":
                            // verify the OData duration value indicator
                            string prefix = "duration'";
                            if (value.StartsWith("duration'") && value.EndsWith("'") && value.Length > prefix.Length)
                            {
                                // Strip off prefix and end quote
                                filter.TimeGrain =
                                    XmlConvert.ToTimeSpan(value.Substring(9, value.Length - prefix.Length - 1));
                            }
                            else throw new FormatException("Invalid duration value for timeGrain");
                            break;
                        case "startTime":
                            filter.StartTime = DateTime.Parse(value);
                            break;
                        case "endTime":
                            filter.EndTime = DateTime.Parse(value);
                            break;
                        case "name.value": // single name (without) parentheses is allowed, but only one
                            if (filter.DimensionFilters == null)
                            {
                                // verify quotes
                                if (value.StartsWith("'") && value.EndsWith("'") && value.Length >= 2)
                                {
                                    // strip off quotes and store
                                    filter.DimensionFilters = new List<MetricDimension>()
                                    {
                                        new MetricDimension()
                                        {
                                            Name = value.Substring(1, value.Length - 2)
                                        }
                                    };
                                }
                                else
                                {
                                    throw new FormatException("Invalid string value for name.value");
                                }
                            }
                            else throw new FormatException("Multiple 'name' conditions must be within parentheses");
                            break;
                        default:
                            throw new FormatException(
                                "Condition name must be one of: 'timeGrain', 'startTime', 'endTime', or 'name.value'");
                    }
                }
            }

            // Verify no missing values?
            return filter;
        }
    }
}
