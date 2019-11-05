// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Azure.AI.TextAnalytics
{
    // TODO: can we merge this with ResultBatch<T>?
    /// <summary>
    /// </summary>
    public class TextAnalyticsResultPage<T> : Page<DocumentResult<T>>
    {
        private Response _response;

        /// <summary>
        /// </summary>
        /// <param name="response"></param>
        public TextAnalyticsResultPage(Response response)
        {
            _response = response;
        }

        /// <summary>
        /// </summary>
        public List<DocumentResult<T>> DocumentResults { get; } = new List<DocumentResult<T>>();

        /// <summary>
        /// Errors and Warnings by document.
        /// </summary>
        public List<DocumentError> Errors { get; } = new List<DocumentError>();

        /// <summary>
        /// Gets (Optional) if showStats=true was specified in the request this
        /// field will contain information about the request payload.
        /// </summary>
        public RequestStatistics Statistics { get; internal set; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; internal set; }

        /// <summary>
        /// </summary>
        public override IReadOnlyList<DocumentResult<T>> Values => DocumentResults.AsReadOnly();

        /// <summary>
        /// </summary>
        // Paging is not currently supported
        public override string ContinuationToken => null;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override Response GetRawResponse() => _response;

        /// <summary>
        /// </summary>
        /// <param name="page"></param>
        public static explicit operator TextAnalyticsResultPage<T>(Page<T> page)
        {
            return page as TextAnalyticsResultPage<T>;
        }
    }
}
