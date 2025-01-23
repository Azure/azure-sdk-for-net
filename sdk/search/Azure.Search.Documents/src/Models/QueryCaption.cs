// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Configuration for how semantic search captions search results.
    /// </summary>
    public partial class QueryCaption
    {
        private const string QueryCaptionHighlightRaw = "highlight-";
        private const string QueryCaptionMaxCharLengthRaw = "maxcharlength-";

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryCaption"/> class.
        /// </summary>
        /// <param name="captionType">A value that specifies whether <see cref="SemanticSearchResult.Captions"/> should be returned as part of the search response.</param>
        public QueryCaption(QueryCaptionType captionType)
        {
            Argument.AssertNotNull(captionType, nameof(captionType));

            CaptionType = captionType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryCaption"/> class.
        /// </summary>
        internal QueryCaption() { }

        /// <summary>
        /// A value that specifies whether <see cref="SemanticSearchResult.Captions"/> should be returned as part of the search response.
        /// <para>The default value is <see cref="QueryCaptionType.None"/>.</para>
        /// </summary>
        public QueryCaptionType CaptionType { get; internal set; }

        /// <summary>
        /// If <see cref="CaptionType"/> is set to <see cref="QueryCaptionType.Extractive"/>, setting this to <c>true</c> enables highlighting of the returned captions.
        /// It populates <see cref="QueryCaptionResult.Highlights"/>.
        /// <para>The default value is <c>true</c>.</para>
        /// </summary>
        public bool HighlightEnabled { get; set; } = true;

        /// <summary>
        /// A value that specifies the maximum character length for captions returned as part of the search response.
        /// Optional and defaults to null.
        /// </summary>
        public int? MaxCharLength { get; set; }

        /// <summary>
        /// Constructed from <see cref="CaptionType"/>, <see cref="HighlightEnabled"/>, and <see cref="MaxCharLength"/>.
        /// </summary>
        internal string QueryCaptionRaw
        {
            get
            {
                StringBuilder queryCaptionStringValue = new(CaptionType.ToString());

                if (CaptionType == QueryCaptionType.Extractive)
                {
                    queryCaptionStringValue.Append('|');
                    queryCaptionStringValue.Append($"{QueryCaptionHighlightRaw}{HighlightEnabled}");

                    // Add maxcharlength if specified.
                    if (MaxCharLength.HasValue)
                    {
                        queryCaptionStringValue.Append($",{QueryCaptionMaxCharLengthRaw}{MaxCharLength.Value}");
                    }
                }

                return queryCaptionStringValue.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    CaptionType = null;
                    HighlightEnabled = true;
                    MaxCharLength = null;
                }
                else
                {
                    string[] parts = value.Split('|');
                    CaptionType = new QueryCaptionType(parts[0]);

                    HighlightEnabled = true;
                    MaxCharLength = null;

                    if (CaptionType == QueryCaptionType.Extractive && parts.Length > 1)
                    {
                        string[] parameters = parts[1].Split(',');

                        foreach (var param in parameters)
                        {
                            if (param.StartsWith(QueryCaptionHighlightRaw, StringComparison.OrdinalIgnoreCase))
                            {
                                var highlightPart = param.Substring(QueryCaptionHighlightRaw.Length);
                                HighlightEnabled = bool.TryParse(highlightPart, out bool highlightValue) ? highlightValue : true;
                            }
                            else if (param.StartsWith(QueryCaptionMaxCharLengthRaw, StringComparison.OrdinalIgnoreCase))
                            {
                                var maxCharLengthPart = param.Substring(QueryCaptionMaxCharLengthRaw.Length);
                                if (int.TryParse(maxCharLengthPart, out int maxCharLengthValue))
                                {
                                    MaxCharLength = maxCharLengthValue;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
