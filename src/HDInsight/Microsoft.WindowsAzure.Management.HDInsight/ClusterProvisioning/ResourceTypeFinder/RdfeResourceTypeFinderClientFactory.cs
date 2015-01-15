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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ResourceTypeFinder
{
    internal class RdfeResourceTypeFinderClientFactory : IRdfeResourceTypeFinderFactory
    {
        /// <summary>
        /// Creates an instance IRdfeResourceTypeFinderClient using the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="context">The context that can be used to cancel the task.</param>
        /// <param name="ignoreSslErrors">If set to <c>true</c> ignore SSL errors.</param>
        /// <param name="schemaVersion">The schema version.</param>
        /// <returns>
        /// An instance of IRdfeResourceTypeFinderClient.
        /// </returns>
        public IRdfeResourceTypeFinderClient Create(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors, string schemaVersion)
        {
            return new RdfeResourceTypeFinderClient(credentials, context, ignoreSslErrors, schemaVersion);
        }
    }
}
