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
    /// <summary>
    /// Constants for versioning support.
    /// </summary>
    internal static class HDInsightConstants
    {
        /// <summary>
        /// Gets an error message template for use when the cluster version is too low for this version of the SDK. 
        /// </summary>
        public const string ClusterVersionTooHighForClusterOperations = "The cluster version {0} is not supported by this version of the tools. Please upgrade your tools to the newer version. The compatibility range for these tools is {1} - {2}.";

        /// <summary>
        /// Gets an error message template for use when the cluster version is too high for this version of the SDK. 
        /// </summary>
        public const string ClusterVersionTooLowForClusterOperations = "The cluster version {0} is outside the compatibility range for this version of the tools. Please upgrade your cluster to the newer version. The compatibility range for these tools is {1} - {2}.";

        /// <summary>
        /// Gets an error message template for use when the cluster version is too low for this version of the SDK. 
        /// </summary>
        public const string ClusterVersionTooHighForJobSubmissionOperations = "The cluster version {0} is not supported by this version of the tools. Please upgrade your tools to the newer version. The compatibility range for these tools is {1} - {2}.";

        /// <summary>
        /// Gets an error message template for use when the cluster version is too high for this version of the SDK. 
        /// </summary>
        public const string ClusterVersionTooLowForJobSubmissionOperations = "The cluster version {0} is outside the compatibility range for this version of the tools. Please upgrade your cluster to the newer version. The compatibility range for these tools is {1} - {2}.";
    }
}
