//
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

using System;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A copy activity SQL data warehouse sink.
    /// </summary>
    public class SqlDWSink : CopySink
    {
        /// <summary>
        /// Optional. Name of the SQL column which is used to save slice
        /// identifier information, to support idempotent copy.
        /// </summary>
        public string SliceIdentifierColumnName { get; set; }

        /// <summary>
        /// Optional. SQL writer cleanup script.
        /// </summary>
        public string SqlWriterCleanupScript { get; set; }

        /// <summary>
        /// Optional. If true, use PolyBase to copy data into SQL Data Warehouse when all below criteria are met:
        /// 1. Source linked service must be <see cref="AzureStorageLinkedService"/>.
        /// 2. Source dataset must be <see cref="AzureBlobDataset"/>.
        /// 3. Format of source dataset must be <see cref="TextFormat"/>.
        /// 5. EncodingName of source dataset format must be "utf-8".
        /// 6. RowDelimiter of source dataset format must be "\n".
        /// 7. NullValue of source dataset format must be <see cref="string.Empty"/>.
        /// 8. Compression of source dataset only supports <see cref="GZipCompression"/> and <see cref="DeflateCompression"/>.
        /// 9. Source must be <see cref="BlobSource"/>.
        /// Default value is false.
        /// </summary>
        public bool? AllowPolyBase { get; set; }

        /// <summary>
        /// Optional. Specifies PolyBase-related settings when AllowPolyBase is true.
        /// </summary>
        public PolyBaseSettings PolyBaseSettings { get; set; }

        /// <summary>
        /// Initializes a new instance of the SqlDWSink class.
        /// </summary>
        public SqlDWSink()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SqlDWSink class with required arguments.
        /// </summary>
        public SqlDWSink(int writeBatchSize, TimeSpan writeBatchTimeout)
            : base(writeBatchSize, writeBatchTimeout)
        {
        }
    }
}
