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
namespace Microsoft.Hadoop.Client.HadoopStorageClientLayer
{
    using System;
    using System.Threading;

    /// <summary>
    /// Represents the base interface of a Hadoop Storage Client.
    /// </summary>
    public interface IHadoopStorageClientBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not SSL errors should be ignored.
        /// </summary>
        bool IgnoreSslErrors { get; set; }

        /// <summary>
        /// Gets or sets a maximum time span for storage commands.
        /// </summary>
        TimeSpan Timeout { get; set; }
    }
}
