// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// search-preview:2026-05-01-preview (entire class)

using System;
using System.Text;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Configuration for how semantic search generates query rewrites.
    /// </summary>
    public partial class QueryRewrites
    {
        private const string QueryRewritesCountRaw = "count-";

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRewrites"/> class.
        /// </summary>
        /// <param name="rewritesType">A value that specifies whether query rewrites should be generated to augment the search query.</param>
        public QueryRewrites(QueryRewritesType rewritesType)
        {
            Argument.AssertNotNull(rewritesType, nameof(rewritesType));

            RewritesType = rewritesType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRewrites"/> class.
        /// </summary>
        internal QueryRewrites() { }

        /// <summary> A value that specifies whether query rewrites should be generated to augment the search query. </summary>
        public QueryRewritesType RewritesType { get; internal set; }

        /// <summary>
        /// A value that specifies the number of query rewrites that should be generated. Optional and defaults to null,
        /// which lets the service apply its own default (10 for <see cref="QueryRewritesType.Generative"/>).
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Constructed from <see cref="RewritesType"/> and <see cref="Count"/>.
        /// Examples of the values:
        /// - "generative"
        /// - "generative|count-3"
        /// </summary>
        internal string QueryRewritesRaw
        {
            get
            {
                StringBuilder builder = new(RewritesType.ToString());

                if (Count.HasValue)
                {
                    builder.Append('|');
                    builder.Append($"{QueryRewritesCountRaw}{Count.Value}");
                }

                return builder.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    string[] parts = value.Split('|');
                    if (!string.IsNullOrEmpty(parts[0]))
                    {
                        RewritesType = new QueryRewritesType(parts[0]);
                    }

                    if (parts.Length == 2)
                    {
                        foreach (var param in parts[1].Split(','))
                        {
                            if (param.StartsWith(QueryRewritesCountRaw, StringComparison.OrdinalIgnoreCase))
                            {
                                var countPart = param.Substring(QueryRewritesCountRaw.Length);
                                if (int.TryParse(countPart, out int countValue))
                                {
                                    Count = countValue;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
