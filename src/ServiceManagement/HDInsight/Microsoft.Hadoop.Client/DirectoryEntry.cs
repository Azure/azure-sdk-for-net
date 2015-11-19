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
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Status of file/directory in HDFS.
    /// </summary>
    [DataContract]
    public class DirectoryEntry
    {
        /// <summary>
        /// Gets or sets the access time.
        /// </summary>
        [DataMember(Name = "accessTime")]
        public long AccessTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets block size.
        /// </summary>
        [DataMember(Name = "blockSize")]
        public int BlockSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        [DataMember(Name = "group")]
        public string Group
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        [DataMember(Name = "length")]
        public int Length
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets modification time.
        /// </summary>
        [DataMember(Name = "modificationTime")]
        public long ModificationTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        [DataMember(Name = "owner")]
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the path suffix.
        /// </summary>
        [DataMember(Name = "pathSuffix")]
        public string PathSuffix
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the permission.
        /// </summary>
        [DataMember(Name = "permission")]
        public string Permission
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the replication factor.
        /// </summary>
        [DataMember(Name = "replication")]
        public short Replication
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of directory entry.
        /// </summary>
        [DataMember(Name = "type")]
        public DirectoryEntryType EntryType
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Type of directory entry.
    /// </summary>
    public enum DirectoryEntryType
    {
        /// <summary>
        /// The file.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "FILE", Justification = "Necessary for correct serialization/deserialization.")]
        FILE,

        /// <summary>
        /// The directory.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DIRECTORY", Justification = "Necessary for correct serialization/deserialization.")]
        DIRECTORY
    }
}
