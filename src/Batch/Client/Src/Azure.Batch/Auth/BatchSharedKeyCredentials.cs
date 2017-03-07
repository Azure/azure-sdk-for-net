// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

// 

namespace Microsoft.Azure.Batch.Auth
{
    using System;

    /// <summary>
    /// Shared key credentials for an Azure Batch account.
    /// </summary>
    public class BatchSharedKeyCredentials : BatchCredentials
    {
        /// <summary>
        /// Gets the Batch account name.
        /// </summary>
        public string AccountName { get; private set; }

        /// <summary>
        /// Gets the Base64 encoded account access key.
        /// </summary>
        internal string KeyValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchSharedKeyCredentials"/> class with the specified Batch service endpoint, account name, and access key.
        /// </summary>
        /// <param name="baseUrl">The Batch service endpoint.</param>
        /// <param name="accountName">The name of the Batch account.</param>
        /// <param name="keyValue">The Base64 encoded account access key.</param>
        public BatchSharedKeyCredentials(string baseUrl, string accountName, string keyValue)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("baseUrl");
            }
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException("accountName");
            }
            if (string.IsNullOrEmpty(keyValue))
            {
                throw new ArgumentNullException("keyValue");
            }

            this.BaseUrl = baseUrl;
            this.AccountName = accountName;
            this.KeyValue = keyValue;
        }
    }
}
