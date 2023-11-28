// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Configuration for how semantic search returns answers to the search.
    /// </summary>
    public partial class QueryAnswer
    {
        private const string QueryAnswerCountRaw = "count-";
        private const string QueryAnswerThresholdRaw = "threshold-";

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryAnswer"/> class.
        /// </summary>
        /// <param name="answerType">A value that specifies whether <see cref="SemanticSearchResults.Answers"/> should be returned as part of the search response.</param>
        public QueryAnswer(QueryAnswerType answerType)
        {
            Argument.AssertNotNull(answerType, nameof(answerType));

            AnswerType = answerType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryAnswer"/> class.
        /// </summary>
        internal QueryAnswer() { }

        /// <summary> A value that specifies whether <see cref="SemanticSearchResults.Answers"/> should be returned as part of the search response. </summary>
        public QueryAnswerType AnswerType { get; internal set; }

        /// <summary> A value that specifies the number of <see cref="SemanticSearchResults.Answers"/> that should be returned as part of the search response and will default to 1. </summary>
        public int? Count { get; set; }

        /// <summary> A value that specifies the threshold of <see cref="SemanticSearchResults.Answers"/> that should be returned as part of the search response. The threshold is optional and will default to 0.7.
        /// </summary>
        public double? Threshold { get; set; }

        /// <summary> Constructed from <see cref="AnswerType"/>, <see cref="Count"/> and <see cref="Threshold"/>. For example: "extractive|count-1,threshold-0.7"</summary>
        internal string QueryAnswerRaw
        {
            get
            {
                    StringBuilder queryAnswerStringValue = new(AnswerType.ToString());

                    if (Count.HasValue && Threshold.HasValue)
                    {
                        return queryAnswerStringValue.Append($"|{QueryAnswerCountRaw}{Count.Value},{QueryAnswerThresholdRaw}{Threshold.Value}").ToString();
                    }
                    else if (Count.HasValue)
                    {
                        return queryAnswerStringValue.Append($"|{QueryAnswerCountRaw}{Count.Value}").ToString();
                    }
                    else if (Threshold.HasValue)
                    {
                        return queryAnswerStringValue.Append($"|{QueryAnswerThresholdRaw}{Threshold.Value}").ToString();
                    }
                    else
                    {
                        return queryAnswerStringValue.ToString();
                    }
                }
            set
            {
                if (!string.IsNullOrEmpty(value)) // If the value is - "extractive" or "extractive|count-1" or "extractive|threshold-0.7" or "extractive|count-5,threshold-0.9" or "extractive|threshold-0.8,count-4"
                {
                    string[] queryAnswerValues = value.Split('|');
                    if (!string.IsNullOrEmpty(queryAnswerValues[0]))
                    {
                        AnswerType = new QueryAnswerType(queryAnswerValues[0]);
                    }

                    if (queryAnswerValues.Length == 2)
                    {
                        var queryAnswerParams = queryAnswerValues[1].Split(',');
                        if (queryAnswerParams.Length <= 2)
                        {
                            foreach (var param in queryAnswerParams)
                            {
                                if (param.Contains(QueryAnswerCountRaw))
                                {
                                    var countPart = param.Substring(param.IndexOf(QueryAnswerCountRaw, StringComparison.OrdinalIgnoreCase) + QueryAnswerCountRaw.Length);
                                    if (int.TryParse(countPart, out int countValue))
                                    {
                                        Count = countValue;
                                    }
                                }
                                else if (param.Contains(QueryAnswerThresholdRaw))
                                {
                                    var thresholdPart = param.Substring(param.IndexOf(QueryAnswerThresholdRaw, StringComparison.OrdinalIgnoreCase) + QueryAnswerThresholdRaw.Length);
                                    if (double.TryParse(thresholdPart, out double thresholdValue))
                                    {
                                        Threshold = thresholdValue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
