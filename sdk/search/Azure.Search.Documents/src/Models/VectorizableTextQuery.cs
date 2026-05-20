// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Customizes the generated <see cref="VectorizableTextQuery"/> so that <c>queryRewrites</c> is exposed as a
    /// <see cref="QueryRewrites"/> wrapper supporting both the rewrite type and the optional count parameter
    /// (for example 'generative|count-3').
    /// </summary>
    public partial class VectorizableTextQuery
    {
        /// <summary> Can be configured to let a generative model rewrite the query before sending it to be vectorized. </summary>
        public QueryRewrites QueryRewrites { get; set; }

        /// <summary>
        /// Constructed from <see cref="QueryRewrites.RewritesType"/> and <see cref="QueryRewrites.Count"/>.
        /// </summary>
        [CodeGenMember("QueryRewrites")]
        private string QueryRewritesRaw
        {
            get => QueryRewrites?.QueryRewritesRaw;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    QueryRewrites ??= new QueryRewrites();
                    QueryRewrites.QueryRewritesRaw = value;
                }
            }
        }
    }
}

#endif
