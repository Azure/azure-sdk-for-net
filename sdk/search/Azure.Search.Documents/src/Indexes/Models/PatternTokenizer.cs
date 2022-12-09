// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class PatternTokenizer
    {
        [CodeGenMember("Flags")]
        internal string FlagsInternal
        {
            get => Flags.Count > 0 ? string.Join("|", Flags) : null;
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
        /// Regular expression flags for <see cref="Pattern"/>.
        /// </summary>
        public IList<RegexFlag> Flags { get; } = new List<RegexFlag>();
    }
}
