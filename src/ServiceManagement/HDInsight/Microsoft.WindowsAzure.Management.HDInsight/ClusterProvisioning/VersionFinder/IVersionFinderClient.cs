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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface to allow a user to retrieve tha available Versions for a subscription id.
    /// </summary>
    internal interface IVersionFinderClient
    {
        /// <summary>
        /// Lists the available Versions for a subscription id.
        /// </summary>
        /// <returns>Available Versions for a subscription id.</returns>
        Task<Collection<HDInsightVersion>> ListAvailableVersions();

        /// <summary>
        /// Parses the available Versions for a subscription id.
        /// </summary>
        /// <param name="capabilities">Key value pair containing Version capabilities for a subscription id.</param>
        /// <returns>Available Versions for a subscription id.</returns>
        Collection<HDInsightVersion> ListAvailableVersions(IEnumerable<KeyValuePair<string, string>> capabilities);

        /// <summary>
        /// Gets the status of this version as supported by the HDInsight SDK.
        /// </summary>
        /// <param name="hdinsightClusterVersion">HDInsight cluster version.</param>
        /// <returns>The status of this version as supported by the HDInsight SDK.</returns>
        VersionStatus GetVersionStatus(Version hdinsightClusterVersion);
    }
}