// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Configuration for how semantic search returns query rewrite to the search.
    /// </summary>
    public partial class QueryRewrites
    {
        private const string QueryRewriteCountRaw = "count-";

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRewrites"/> class.
        /// </summary>
        /// <param name="rewritesType">A value that specifies whether <see cref="SemanticSearchResults.SemanticQueryRewritesResultType"/> should be returned as part of the search response.</param>
        public QueryRewrites(QueryRewritesType rewritesType)
        {
            Argument.AssertNotNull(rewritesType, nameof(rewritesType));

            RewritesType = rewritesType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRewrites"/> class.
        /// </summary>
        internal QueryRewrites() { }

        /// <summary> A value that specifies whether <see cref="SemanticSearchResults.SemanticQueryRewritesResultType"/> should be returned as part of the search response. </summary>
        public QueryRewritesType RewritesType { get; internal set; }

        /// <summary> A value that specifies the number of <see cref="SemanticSearchResults.SemanticQueryRewritesResultType"/> that should be returned as part of the search response and will default to 10. </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Constructed from <see cref="RewritesType"/> and <see cref="Count"/>.
        /// Examples of the values:
        /// - "none"
        /// - `generative|count-3`
        /// </summary>
        internal string QueryRewritesRaw
        {
            get
            {
                StringBuilder queryRewriteStringValue = new(RewritesType.ToString());

                if (Count.HasValue)
                {
                    queryRewriteStringValue.Append('|');
                    queryRewriteStringValue.Append($"{QueryRewriteCountRaw}{Count.Value}");
                }

                return queryRewriteStringValue.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    string[] queryRewriteValues = value.Split('|');
                    if (!string.IsNullOrEmpty(queryRewriteValues[0]))
                    {
                        RewritesType = new QueryRewritesType(queryRewriteValues[0]);
                    }

                    if (queryRewriteValues.Length == 2 && queryRewriteValues[1].Contains(QueryRewriteCountRaw))
                    {
                        var countPart = queryRewriteValues[1].Substring(
                            queryRewriteValues[1].IndexOf(QueryRewriteCountRaw, StringComparison.OrdinalIgnoreCase) + QueryRewriteCountRaw.Length);

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
