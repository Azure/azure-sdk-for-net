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
    /// Represents a Hadoop client that can be used to submit jobs to an Hadoop cluster.
    /// </summary>
    public static class JobSubmissionClientFactory
    {
        /// <summary>
        /// Creates a new instance of the Hadoop Client that can be used to 
        /// submit jobs to a Hadoop instance.
        /// </summary>
        /// <param name="credentials">
        /// The connection credentials for the Hadoop instance.
        /// </param>
        /// <returns>
        /// An Hadoop client implementation.
        /// </returns>
        public static IJobSubmissionClient Connect(IJobSubmissionClientCredential credentials)
        {
            return Connect(credentials, string.Empty);
        }

        /// <summary>
        /// Creates a new instance of the Hadoop Client that can be used to 
        /// submit jobs to a Hadoop instance.
        /// </summary>
        /// <param name="credentials">
        /// The connection credentials for the Hadoop instance.
        /// </param>
        /// <param name="customUserAgent">
        /// Custom user agent string if needed.
        /// </param>
        /// <returns>
        /// An Hadoop client implementation.
        /// </returns>
        public static IJobSubmissionClient Connect(IJobSubmissionClientCredential credentials, string customUserAgent)
        {
            return ServiceLocator.Instance.Locate<IHadoopClientFactoryManager>().Create(credentials, customUserAgent);
        }
    }
}
