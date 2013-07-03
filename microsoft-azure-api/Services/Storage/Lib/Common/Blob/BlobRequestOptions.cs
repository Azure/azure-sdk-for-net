//-----------------------------------------------------------------------
// <copyright file="BlobRequestOptions.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using System;

    /// <summary>
    /// Represents a set of timeout and retry policy options that may be specified for a blob operation request.
    /// </summary>
    public sealed class BlobRequestOptions : IRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobRequestOptions"/> class.
        /// </summary>
        public BlobRequestOptions()
        {
        }

        /// <summary>
        /// Clones an instance of BlobRequestOptions so that we can apply defaults.
        /// </summary>
        /// <param name="other">BlobRequestOptions instance to be cloned.</param>
        internal BlobRequestOptions(BlobRequestOptions other)
            : this()
        {
            if (other != null)
            {
                this.RetryPolicy = other.RetryPolicy;
                this.ServerTimeout = other.ServerTimeout;
                this.MaximumExecutionTime = other.MaximumExecutionTime;
                this.OperationExpiryTime = other.OperationExpiryTime;
                this.UseTransactionalMD5 = other.UseTransactionalMD5;
                this.StoreBlobContentMD5 = other.StoreBlobContentMD5;
                this.DisableContentMD5Validation = other.DisableContentMD5Validation;
            }
        }

        internal static BlobRequestOptions ApplyDefaults(BlobRequestOptions options, BlobType blobType, CloudBlobClient serviceClient, bool applyExpiry = true)
        {
            BlobRequestOptions modifiedOptions = new BlobRequestOptions(options);

            modifiedOptions.RetryPolicy = modifiedOptions.RetryPolicy ?? serviceClient.RetryPolicy;
            modifiedOptions.ServerTimeout = modifiedOptions.ServerTimeout ?? serviceClient.ServerTimeout;
            modifiedOptions.MaximumExecutionTime = modifiedOptions.MaximumExecutionTime ?? serviceClient.MaximumExecutionTime;

            if (applyExpiry && !modifiedOptions.OperationExpiryTime.HasValue && modifiedOptions.MaximumExecutionTime.HasValue)
            {
                modifiedOptions.OperationExpiryTime = DateTime.Now + modifiedOptions.MaximumExecutionTime.Value;
            }

            modifiedOptions.DisableContentMD5Validation = modifiedOptions.DisableContentMD5Validation ?? false;

            modifiedOptions.StoreBlobContentMD5 =
#if WINDOWS_PHONE
            false;
#else
            modifiedOptions.StoreBlobContentMD5 ?? (blobType == BlobType.BlockBlob);
#endif

            modifiedOptions.UseTransactionalMD5 = modifiedOptions.UseTransactionalMD5 ?? false;

            return modifiedOptions;
        }

        /// <summary>
        ///  Gets or sets the absolute Expiry time across all potential retries etc. 
        /// </summary>
        internal DateTime? OperationExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the retry policy.
        /// </summary>
        /// <value>The retry policy.</value>
        public IRetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the server timeout interval for the request.
        /// </summary>
        /// <value>The server timeout interval for the request.</value>
        public TimeSpan? ServerTimeout { get; set; }

        /// <summary>
        /// Gets or sets the maximum execution time across all potential retries etc. 
        /// </summary>
        /// <value>The maximum execution time.</value>
        public TimeSpan? MaximumExecutionTime { get; set; }

        /// <summary>
        /// Gets or sets a value to calculate and send/validate content MD5 for transactions.
        /// </summary>
        /// <value>Use <c>true</c> to calculate and send/validate content MD5 for transactions; otherwise, <c>false</c>.</value>       
#if WINDOWS_PHONE
        /// <remarks>This property is not supported for Windows Phone.</remarks>
#endif
        public bool? UseTransactionalMD5
        {
            get
            {
                return this.useTransactionalMD5;
            }

            set
            {
#if WINDOWS_PHONE
                if (value.HasValue && value.Value)
                {
                    throw new NotSupportedException(SR.WindowsPhoneDoesNotSupportMD5);
                }
#endif
                this.useTransactionalMD5 = value;
            }
        }

        private bool? useTransactionalMD5;

        /// <summary>
        /// Gets or sets a value to indicate that an MD5 hash will be calculated and stored when uploading a blob.
        /// </summary>
        /// <value>Use <c>true</c> to calculate and store an MD5 hash when uploading a blob; otherwise, <c>false</c>.</value>
#if WINDOWS_PHONE
        /// <remarks>This property is not supported for Windows Phone.</remarks>
#endif
        public bool? StoreBlobContentMD5
        {
            get
            {
                return this.storeBlobContentMD5;
            }

            set
            {
#if WINDOWS_PHONE
                if (value.HasValue && value.Value)
                {
                    throw new NotSupportedException(SR.WindowsPhoneDoesNotSupportMD5);
                }
#endif
                this.storeBlobContentMD5 = value;
            }
        }

        private bool? storeBlobContentMD5;

        /// <summary>
        /// Gets or sets a value to indicate that MD5 validation will be disabled when downloading blobs.
        /// </summary>
        /// <value>Use <c>true</c> to disable MD5 validation; <c>false</c> to enable MD5 validation.</value>
#if WINDOWS_PHONE
        /// <remarks>This property is not supported for Windows Phone.</remarks>
#endif
        public bool? DisableContentMD5Validation
        {
            get
            {
                return this.disableContentMD5Validation;
            }

            set
            {
#if WINDOWS_PHONE
                if (value.HasValue && value.Value)
                {
                    throw new NotSupportedException(SR.WindowsPhoneDoesNotSupportMD5);
                }
#endif
                this.disableContentMD5Validation = value;
            }
        }

        private bool? disableContentMD5Validation;
    }
}
