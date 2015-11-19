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
    using System.Runtime.Serialization;

    /// <summary>
    /// Content summary of a directory entry.
    /// </summary>
    [DataContract(Name = "ContentSummary")]
    public class ContentSummary
    {
        /// <summary>
        /// Gets or sets the directory count.
        /// </summary>
        [DataMember(Name = "directoryCount")]
        public int DirectoryCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the file count.
        /// </summary>
        [DataMember(Name = "fileCount")]
        public int FileCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the length of a file.
        /// </summary>
        [DataMember(Name = "length")]
        public int Length
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the quota.
        /// </summary>
        [DataMember(Name = "quota")]
        public double Quota
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets total space consumed.
        /// </summary>
        [DataMember(Name = "spaceConsumed")]
        public int SpaceConsumed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the space quota.
        /// </summary>
        [DataMember(Name = "spaceQuota")]
        public double SpaceQuota
        {
            get;
            set;
        }
    }
}
