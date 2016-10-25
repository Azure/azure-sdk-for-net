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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A single Amazon Simple Storage Service (S3) object or a set of S3 objects.
    /// </summary>
    [AdfTypeName("AmazonS3")]
    public class AmazonS3Dataset : DatasetTypeProperties
    {
        /// <summary>
        /// The name of the Amazon S3 bucket.
        /// </summary>
        [AdfRequired]
        public string BucketName { get; set; }

        /// <summary>
        /// The key of the Amazon S3 object.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The prefix filter for the S3 object(s) name.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// The version for the S3 object.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The format of the Amazon S3 object(s).
        /// </summary>
        public StorageFormat Format { get; set; }

        /// <summary> 
        /// The data compression method used for the Amazon S3 object(s). 
        /// </summary>
        public Compression Compression { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonS3Dataset" /> class.
        /// </summary>
        public AmazonS3Dataset()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonS3Dataset" />
        /// class with required arguments.
        /// </summary>
        public AmazonS3Dataset(string bucketName)
        {
            Ensure.IsNotNullOrEmpty(bucketName, "bucketName");
            this.BucketName = bucketName;
        }
    }
}

