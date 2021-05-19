// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Configurations that allow callers to specify details about how to execute
    /// an Analyze Sentiment action in a set of documents.
    /// For example, execute opinion mining, set model version, and more.
    /// </summary>
    public class AnalyzeSentimentAction : AnalyzeSentimentOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeSentimentAction"/>
        /// class which allows callers to specify details about how to execute
        /// an Analyze Sentiment action in a set of documents.
        /// For example, execute opinion mining, set model version, and more.
        /// </summary>
        public AnalyzeSentimentAction()
        {
        }
    }
}
