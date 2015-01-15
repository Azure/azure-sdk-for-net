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
namespace Microsoft.Hadoop.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Hadoop.Client.ClientLayer;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    /// <summary>
    /// Represents a Hadoop client that can provide information about completed applications.
    /// </summary>
    internal static class HadoopApplicationHistoryClientFactory
    {
        /// <summary>
        /// Creates a new instance of the Hadoop Client that can be used to obtain information on completed applications.
        /// </summary>
        /// <param name="credentials">
        /// The connection credentials for the Hadoop instance.
        /// </param>
        /// <returns>
        /// An Hadoop client implementation.
        /// </returns>
        internal static IHadoopApplicationHistoryClient Connect(IJobSubmissionClientCredential credentials)
        {
            return ServiceLocator.Instance.Locate<IHadoopClientFactoryManager>().CreateHadoopApplicationHistoryClient(credentials);
        }
    }
}
