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
    /// Version spec for HDInsight clusters.
    /// </summary>
    public sealed class HDInsightVersion
    {
        /// <summary>
        /// Gets or sets the Semantic version for the HDInsight cluster.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the version status for the HDInsight cluster.
        /// </summary>
        public VersionStatus VersionStatus { get; set; }

        /// <summary>
        /// Converts this object into its string representation.
        /// </summary>
        /// <returns>The string representation of this object.</returns>
        public override string ToString()
        {
            return this.Version;
        }
    }
}
