// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class PatternAnalyzer
    {
        [CodeGenMember("Flags")]
        private string FlagsInternal
        {
            get => string.Join("|", Flags);
            set
            {
                Flags.Clear();

                if (!string.IsNullOrEmpty(value))
                {
                    string[] values = value.Split('|');
                    for (int i = 0; i < values.Length; ++i)
                    {
                        Flags.Add(new RegexFlag(values[i]));
                    }
                }
            }
        }

        /// <summary>
        /// Gets regular expression flags for <see cref="Pattern"/>.
        /// </summary>
        public IList<RegexFlag> Flags { get; } = new List<RegexFlag>();

        /// <summary>
        /// Gets a list of stopwords.
        /// </summary>
        public IList<string> Stopwords { get; }
    }
}
