// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;

namespace Microsoft.Azure.Test.HttpRecorder
{
    /// <summary>
    /// Interface that used by the mock server for mapping a request with it's corresponding response.
    /// </summary>
    public interface IRecordMatcher
    {
        /// <summary>
        /// Gets the key used for mapping a given RecordEntry request's with its response.
        /// </summary>
        /// <param name="recordEntry">The record entry containing the request info</param>
        /// <returns>The key used for the mapping</returns>
        string GetMatchingKey(RecordEntry recordEntry);

        /// <summary>
        /// Gets the key mapping for the given request.
        /// </summary>
        /// <param name="request">The request to be mapped</param>
        /// <returns>The key corresponding to this request</returns>
        string GetMatchingKey(HttpRequestMessage request);
    }
}
