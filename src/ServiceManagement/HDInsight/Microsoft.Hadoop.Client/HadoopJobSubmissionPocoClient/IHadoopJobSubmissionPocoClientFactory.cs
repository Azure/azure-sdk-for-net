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
namespace Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient
{
    using Microsoft.WindowsAzure.Management.HDInsight;

    /// <summary>
    /// A factory used to create HadoopJobSubmissionPoco clients.
    /// </summary>
    internal interface IHadoopJobSubmissionPocoClientFactory
    {
        /// <summary>
        /// Creates a new instance of a HadoopJobSubmissionPoco client.
        /// </summary>
        /// <param name="credentials">
        /// The connection credentials to use when connecting to the instance.
        /// </param>
        /// <param name="context">
        /// The context which contains a cancelation token for the request.
        /// </param>
        /// <param name="ignoreSslErrors">
        /// Specifies that server side SSL errors should be be ignored.
        /// </param>
        /// <param name="userAgentString">User agent string to pass.</param>
        /// <returns>
        /// A new instance of an HadoopJobSubmissionPoco client capable of talking to the 
        /// specified cluster.
        /// </returns>
        IHadoopJobSubmissionPocoClient Create(IJobSubmissionClientCredential credentials, IAbstractionContext context, bool ignoreSslErrors, string userAgentString);
    }
}
