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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.LocationFinder
{
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight;

    /// <summary>
    /// Factory interface to create  a Location finder client.
    /// </summary>
    internal interface ILocationFinderClientFactory
    {
        /// <summary>
        /// Creates a Location finder client instance.
        /// </summary>
        /// <param name="credentials">Credentials containing user subscription id.</param>
        /// <param name="context">
        /// A context instance that can be used to cancel the task.
        /// </param>
        /// <param name="ignoreSslErrors">
        /// Specifies that server side SSL errors should be ignored.
        /// </param>
        /// <returns>A Location finder client instance.</returns>
        ILocationFinderClient Create(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors);
    }
}
