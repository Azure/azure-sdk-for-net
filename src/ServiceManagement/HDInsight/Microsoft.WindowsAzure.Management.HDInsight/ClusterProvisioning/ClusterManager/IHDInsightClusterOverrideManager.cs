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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ClusterManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    using Microsoft.WindowsAzure.Management.HDInsight;

    /// <summary>
    /// Provides an interface to manage how various connection systems
    /// work within the HDInsight system.
    /// </summary>
    internal interface IHDInsightClusterOverrideManager
    {
        void AddOverride<T>(IVersionFinderClientFactory versionFinderFactory,
                            IHDInsightManagementRestUriBuilderFactory uriBuilderFactory,
                            IPayloadConverter payloadConverter) where T : IHDInsightSubscriptionCredentials;

        /// <summary>
        /// Gets the handlers.
        /// </summary>
        /// <typeparam name="T">The subscription credentials.</typeparam>
        /// <param name="credentials">The credentials.</param>
        /// <param name="context">The context.</param>
        /// <param name="ignoreSslErrors">If set to <c>true</c> ignore SSL errors.</param>
        /// <returns>An override handler.</returns>
        HDInsightOverrideHandlers GetHandlers<T>(T credentials, IAbstractionContext context, bool ignoreSslErrors) where T : IHDInsightSubscriptionCredentials;
    }
}
