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
    /// <summary>
    /// Enumeration of version status.
    /// </summary>
    public enum VersionStatus
    {
        /// <summary>
        /// The version of the HDInsight cluster is lower than the minimum version supported by the SDK.
        /// </summary>
        Obsolete,

        /// <summary>
        /// The version of the HDInsight cluster is supported by the SDK.
        /// </summary>
        Compatible,

        /// <summary>
        /// The version of the HDInsight cluster is higher than the maximum version supported by the SDK.
        /// </summary>
        ToolsUpgradeRequired
    }
}