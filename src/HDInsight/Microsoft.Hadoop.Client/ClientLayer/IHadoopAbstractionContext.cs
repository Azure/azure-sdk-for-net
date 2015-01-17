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
    using Microsoft.WindowsAzure.Management.HDInsight;

    /// <summary>
    /// Represents an abstraction context for HadoopConnectionCredentials.
    /// </summary>
    /// <typeparam name="TCredentials">
    /// The type of credentials to use.
    /// </typeparam>
    public interface IHadoopAbstractionContext<TCredentials> : IAbstractionContext where TCredentials : IJobSubmissionClientCredential
    {
        /// <summary>
        /// Gets the connection credentials.
        /// </summary>
        TCredentials Credentials { get; }
    }
}
