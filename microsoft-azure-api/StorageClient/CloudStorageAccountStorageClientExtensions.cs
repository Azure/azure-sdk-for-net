//-----------------------------------------------------------------------
// <copyright file="CloudStorageAccountStorageClientExtensions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the CloudStorageAccountStorageClientExtensions class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Provides a set of extensions to the <see cref="CloudStorageAccount"/> class that may be used to generate client objects for 
    /// the Windows Azure storage services.
    /// </summary>
    public static class CloudStorageAccountStorageClientExtensions
    {
        /// <summary>
        /// Creates a new Blob service client.
        /// </summary>
        /// <param name="account">The storage account.</param>
        /// <returns>A client object that specifies the Blob service endpoint.</returns>
        public static CloudBlobClient CreateCloudBlobClient(this CloudStorageAccount account)
        {
            if (account.BlobEndpoint == null)
            {
                throw new InvalidOperationException("No blob endpoint configured.");
            }

            if (account.Credentials == null)
            {
                throw new InvalidOperationException("No credentials provided configured.");
            }

            return new CloudBlobClient(account.BlobEndpoint, account.Credentials);
        }

        /// <summary>
        /// Creates a new Queue service client.
        /// </summary>
        /// <param name="account">The storage account.</param>
        /// <returns>A client object that specifies the Queue service endpoint.</returns>
        public static CloudQueueClient CreateCloudQueueClient(this CloudStorageAccount account)
        {
            if (account.QueueEndpoint == null)
            {
                throw new InvalidOperationException("No queue endpoint configured.");
            }

            if (account.Credentials == null)
            {
                throw new InvalidOperationException("No credentials provided.");
            }

            return new CloudQueueClient(account.QueueEndpoint, account.Credentials);
        }

        /// <summary>
        /// Creates the Table service client.
        /// </summary>
        /// <param name="account">The storage account.</param>
        /// <returns>A client object that specifies the Table service endpoint.</returns>
        public static CloudTableClient CreateCloudTableClient(this CloudStorageAccount account)
        {
            if (account.TableEndpoint == null)
            {
                throw new InvalidOperationException("No table endpoint configured.");
            }

            if (account.Credentials == null)
            {
                throw new InvalidOperationException("No credentials provided.");
            }

            return new CloudTableClient(account.TableEndpoint, account.Credentials);
        }
    }
}
