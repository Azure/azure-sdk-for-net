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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data
{
    /// <summary>
    /// Enum that describe the flavor of the cluster.
    /// </summary>
    public enum ClusterType
    {
        /// <summary>
        /// Hadoop only cluster type.
        /// </summary>
        Hadoop,

        /// <summary>
        /// Hadoop with HBase cluster type.
        /// </summary>
        HBase,

        /// <summary>
        /// Hadoop with Storm cluster type.
        /// </summary>
        Storm,

        /// <summary>
        /// Hadoop with Spark cluster type.
        /// </summary>
        Spark,

        /// <summary>
        /// Unknown cluster flavor.
        /// </summary>
        Unknown
    }
}