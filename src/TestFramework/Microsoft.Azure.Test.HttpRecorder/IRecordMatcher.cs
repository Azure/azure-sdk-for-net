// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
