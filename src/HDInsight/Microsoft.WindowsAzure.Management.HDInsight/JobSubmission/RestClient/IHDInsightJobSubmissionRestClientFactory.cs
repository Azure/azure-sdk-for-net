// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.RestClient
{
    using Microsoft.WindowsAzure.Management.HDInsight;

    /// <summary>
    /// The IHDInsightJobSubmissionRestClient factory interface used to create new
    /// HDInsightJobSubmissionRestClient objects.
    /// </summary>
    internal interface IHDInsightJobSubmissionRestClientFactory
    {
        /// <summary>
        /// Creates a new instance of an IHDInsightJobSubmissionRestClient class.
        /// </summary>
        /// <param name="credentials">
        ///     The connection credentials to use when creating the object.
        /// </param>
        /// <param name="context">A context containing cancellation token and logger.</param>
        /// <param name="ignoreSslErrors">
        /// Specifies that server side SSL errors should be ignored.
        /// </param>
        /// <returns>
        /// A new IHDInsightJobSubmissionRestClient class.
        /// </returns>
        IHDInsightJobSubmissionRestClient Create(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors);
    }
}
