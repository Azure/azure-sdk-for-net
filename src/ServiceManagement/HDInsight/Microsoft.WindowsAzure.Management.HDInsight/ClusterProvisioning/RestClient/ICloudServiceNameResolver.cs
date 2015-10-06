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
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;

    /// <summary>
    /// Provides a service that can resolve cloud service names.
    /// </summary>
    public interface ICloudServiceNameResolver
    {
        /// <summary>
        /// Gets the Cloud Service Name.
        /// </summary>
        /// <param name="subscriptionId">
        /// The subscription Id.
        /// </param>
        /// <param name="extensionPrefix">
        /// The extension Prefix.
        /// </param>
        /// <param name="region">
        /// The region.
        /// </param>
        /// <returns>
        /// The Cloud Servie name.
        /// </returns>
        string GetCloudServiceName(Guid subscriptionId, string extensionPrefix, string region);
    }
}
