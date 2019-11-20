// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TextBatchResponse<T> : Response<Collection<T>> where T : TextAnalysisResult
    {
        private readonly Response _response;

        /// <summary>
        /// </summary>
        /// <param name="response"></param>
        /// <param name="value"></param>
        /// <param name="statistics"></param>
        /// <param name="modelVersion"></param>
        public TextBatchResponse(Response response, Collection<T> value, TextBatchStatistics statistics, string modelVersion)
        {
            _response = response;
            Value = value;
            Statistics = statistics;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// </summary>
        public TextBatchStatistics Statistics { get; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; }

        /// <summary>
        /// </summary>
        public override Collection<T> Value { get; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override Response GetRawResponse() => _response;
    }
}
