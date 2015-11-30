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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;

    /// <summary>
    /// Interface to allow a user to retrieve tha available locations for a subscription id.
    /// </summary>
    internal interface ILocationFinderClient
    {
        /// <summary>
        /// Lists the available locations for a subscription id.
        /// </summary>
        /// <returns>
        /// Available locations for a subscription id.
        /// </returns>
        Task<Collection<string>> ListAvailableLocations();

        /// <summary>
        /// Lists the available locations that allow IaaS deployments for a subscription id.
        /// </summary>
        /// <returns>
        /// Available locations for a subscription id.
        /// </returns>
        Task<Collection<string>> ListAvailableIaasLocations();

        /// <summary>
        /// Parses the available locations for a subscription id.
        /// </summary>
        /// <param name="capabilities">Key value pair containing location capabilities for a subscription id.</param>
        /// <returns>Available locations for a subscription id.</returns>
        Collection<string> ListAvailableLocations(IEnumerable<KeyValuePair<string, string>> capabilities);

        /// <summary>
        /// Parses the available IaaS locations for a subscription id.
        /// </summary>
        /// <param name="capabilities">Key value pair containing location capabilities for a subscription id.</param>
        /// <returns>Available locations for a subscription id.</returns>
        Collection<string> ListAvailableIaasLocations(IEnumerable<KeyValuePair<string, string>> capabilities);
    }
}