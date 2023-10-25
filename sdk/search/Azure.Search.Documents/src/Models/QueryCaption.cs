// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Configuration for how semantic search captions search results.
    /// </summary>
    public partial class QueryCaption
    {
        private const string QueryCaptionRawSplitter = "|highlight-";

        /// <summary>
        /// A value that specifies whether <see cref="SemanticSearchResult.Captions"/> should be returned as part of the search response.
        /// <para>The default value is <see cref="QueryCaptionType.None"/>.</para>
        /// </summary>
        public QueryCaptionType? CaptionType { get; set; }

        /// <summary>
        /// If <see cref="CaptionType"/> is set to <see cref="QueryCaptionType.Extractive"/>, setting this to <c>true</c> enables highlighting of the returned captions.
        /// It populates <see cref="CaptionResult.Highlights"/>.
        /// <para>The default value is <c>true</c>.</para>
        /// </summary>
        public bool? HighlightEnabled { get; set; }

        /// <summary> Constructed from <see cref="CaptionType"/> and <see cref="HighlightEnabled"/>.</summary>
        [CodeGenMember("Captions")]
        internal string QueryCaptionRaw
        {
            get
            {
                string queryCaptionStringValue = null;

                if (CaptionType.HasValue)
                {
                    if (CaptionType.Value == QueryCaptionType.Extractive)
                    {
                        queryCaptionStringValue = $"{CaptionType.Value}{QueryCaptionRawSplitter}{HighlightEnabled.GetValueOrDefault(true)}";
                    }
                    else
                    {
                        queryCaptionStringValue = CaptionType.ToString();
                    }
                }

                return queryCaptionStringValue;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    CaptionType = null;
                    HighlightEnabled = null;
                }
                else
                {
                    int splitIndex = value.IndexOf(QueryCaptionRawSplitter, StringComparison.OrdinalIgnoreCase);
                    if (splitIndex >= 0)
                    {
                        var queryCaptionPart = value.Substring(0, splitIndex);
                        var highlightPart = value.Substring(splitIndex + QueryCaptionRawSplitter.Length);

                        CaptionType = string.IsNullOrEmpty(queryCaptionPart) ? null : new QueryCaptionType(queryCaptionPart);
                        HighlightEnabled = bool.TryParse(highlightPart, out bool highlightValue) ? highlightValue : null;
                    }
                    else
                    {
                        CaptionType = new QueryCaptionType(value);
                        HighlightEnabled = null;
                    }
                }
            }
        }
    }
}
