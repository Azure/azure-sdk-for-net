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
    /// An access key-based Amazon Web Services (AWS) linked service.
    /// The AWS Identity and Access Management (IAM) access key is used for all AWS web APIs.
    /// </summary>
    [AdfTypeName("AwsAccessKey")]
    public class AwsAccessKeyLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. The IAM access key ID.
        /// </summary>
        [AdfRequired]
        public string AccessKeyId { get; set; }

        /// <summary>
        /// Required. The IAM secret access key.
        /// </summary>
        [AdfRequired]
        public string SecretAccessKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AwsAccessKeyLinkedService" /> class.
        /// </summary>
        public AwsAccessKeyLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AwsAccessKeyLinkedService" />
        /// class with required arguments.
        /// </summary>
        public AwsAccessKeyLinkedService(string accessKeyId, string secretAccessKey)
        {
            Ensure.IsNotNullOrEmpty(accessKeyId, "accessKeyId");
            Ensure.IsNotNullOrEmpty(secretAccessKey, "secretAccessKey");
            this.AccessKeyId = accessKeyId;
            this.SecretAccessKey = secretAccessKey;
        }
    }
}
