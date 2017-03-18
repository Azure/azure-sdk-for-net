﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// An on-premises file system.
    /// </summary>
    [AdfTypeName("FileShare")]
    public class FileShareDataset : DatasetTypeProperties
    {
        /// <summary>
        /// The name of the file folder.
        /// </summary>
        public string FolderPath { get; set; }

        /// <summary>
        /// The name of the file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The partitions to be used by the path.
        /// </summary>
        public IList<Partition> PartitionedBy { get; set; }

        /// <summary>
        /// The format of the file.
        /// </summary>
        public StorageFormat Format { get; set; }

        /// <summary>
        /// Files sets filter by wildcard.
        /// </summary>
        public string FileFilter { get; set; }

        /// <summary>
        /// The data compression method used on files.
        /// </summary>
        public Compression Compression { get; set; }

        /// <summary>
        /// Optional. Can only be used when accociated Linked Service is <see cref="FtpServerLinkedService"/>.
        /// If true, data representation during transmission from FTP server is in Binary mode.
        /// If false, data representation during transmission from FTP server is in ASCII mode.
        /// Default value is true.
        /// </summary>
        public bool? UseBinaryTransfer { get; set; }
    }
}
