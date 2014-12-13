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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;

    /// <summary>
    /// Specifies a contract for accessing rdfe properties of a subscription for a given resource type.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Rdfe", Justification = "Rdfe is an acronym for Red Dog Front End")]
    internal interface IRdfeServiceRestClient
    {
        /// <summary>
        /// Get the properties of a subscription for a given resource type.
        /// </summary>
        /// <returns>A key value pair enumerable containing the properties of this subscription.</returns>
        Task<IEnumerable<KeyValuePair<string, string>>> GetResourceProviderProperties();

        /// <summary>
        /// Parses the xml payload from a rdfe call response and returns a key value pair enumerable.
        /// </summary>
        /// <param name="payload">Xml payload from a rdfe call response.</param>
        /// <returns>A key value pair enumerable containing the properties of this subscription.</returns>
        IEnumerable<KeyValuePair<string, string>> ParseCapabilities(string payload);
    }
}
