//-----------------------------------------------------------------------
// <copyright file="CloudBlobClient.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Globalization;

    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Blob Service. This client is used to configure and execute requests against the Blob Service.
    /// </summary>
    /// <remarks>The service client encapsulates the base URI for the Blob service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.</remarks>
    public sealed partial class CloudBlobClient
    {
        /// <summary>
        /// Constant for the max value of ParallelOperationThreadCount.
        /// </summary>
        private const int MaxParallelOperationThreadCount = 64;

        /// <summary>
        /// Stores the default delimiter.
        /// </summary>
        private string defaultDelimiter;

        /// <summary>
        /// Stores the parallelism factor.
        /// </summary>
        private int parallelismFactor = 1;

        /// <summary>
        /// Default is 32 MB.
        /// </summary>
        private long singleBlobUploadThresholdInBytes = Constants.MaxSingleUploadBlobSize / 2;

        /// <summary>
        /// The default server and client timeout interval.
        /// </summary>
        private TimeSpan? timeout;

        /// <summary>
        /// Max execution time accross all potential retries.
        /// </summary>
        private TimeSpan? maximumExecutionTime;

        private AuthenticationScheme authenticationScheme;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobClient"/> class using the specified Blob service endpoint
        /// and anonymous credentials.
        /// </summary>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param>
        public CloudBlobClient(Uri baseUri)
            : this(baseUri, null /* credentials */)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobClient"/> class using the specified Blob service endpoint
        /// and account credentials.
        /// </summary>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudBlobClient(Uri baseUri, StorageCredentials credentials)
            : this(null /* usePathStyleUris */, baseUri, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobClient"/> class.
        /// </summary>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        internal CloudBlobClient(bool? usePathStyleUris, Uri baseUri, StorageCredentials credentials)
        {
            CommonUtils.AssertNotNull("baseUri", baseUri);

            if (credentials == null)
            {
                credentials = new StorageCredentials();
            }

            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }

            if (!baseUri.IsAbsoluteUri)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.RelativeAddressNotPermitted, baseUri.ToString());
                throw new ArgumentException(errorMessage, "baseUri");
            }

            this.BaseUri = baseUri;
            this.Credentials = credentials;
            this.RetryPolicy = new ExponentialRetry();
            this.ServerTimeout = Constants.DefaultServerSideTimeout;
            this.DefaultDelimiter = NavigationHelper.Slash;
            this.AuthenticationScheme = AuthenticationScheme.SharedKey;

            if (usePathStyleUris.HasValue)
            {
                this.UsePathStyleUris = usePathStyleUris.Value;
            }
            else
            {
                // Automatically decide whether to use host style uri or path style uri
                this.UsePathStyleUris = CommonUtils.UsePathStyleAddressing(this.BaseUri);
            }
        }

        /// <summary>
        /// Gets the account credentials used to create the Blob service client.
        /// </summary>
        /// <value>The account credentials.</value>
        public StorageCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets the base URI for the Blob service client.
        /// </summary>
        /// <value>The base URI used to construct the Blob service client.</value>
        public Uri BaseUri { get; private set; }

        /// <summary>
        /// Gets or sets the default retry policy for requests made via the Blob service client.
        /// </summary>
        /// <value>The retry policy.</value>
        public IRetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the default server and client timeout for requests.
        /// </summary>
        /// <value>The server and client timeout interval.</value>
        public TimeSpan? ServerTimeout
        {
            get
            {
                return this.timeout;
            }

            set
            {
                if (value.HasValue)
                {
                    CommonUtils.CheckTimeoutBounds(value.Value);
                }

                this.timeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum execution time accross all potential retries.
        /// </summary>
        /// <value>The maximum execution time accross all potential retries.</value>
        public TimeSpan? MaximumExecutionTime
        {
            get
            {
                return this.maximumExecutionTime;
            }

            set
            {
                if (value.HasValue)
                {
                    CommonUtils.CheckTimeoutBounds(value.Value);
                }

                this.maximumExecutionTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the default delimiter that may be used to create a virtual directory structure of blobs.
        /// </summary>
        /// <value>The default delimiter.</value>
        public string DefaultDelimiter
        {
            get
            {
                return this.defaultDelimiter;
            }

            set
            {
                CommonUtils.AssertNotNullOrEmpty("DefaultDelimiter", value);
                this.defaultDelimiter = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum size of a blob in bytes that may be uploaded as a single blob. 
        /// </summary>
        /// <value>The maximum size of a blob, in bytes, that may be uploaded as a single blob,
        /// ranging from between 1 and 64 MB inclusive.</value>
        public long SingleBlobUploadThresholdInBytes
        {
            get
            {
                return this.singleBlobUploadThresholdInBytes;
            }

            set
            {
                CommonUtils.AssertInBounds("SingleBlobUploadThresholdInBytes", value, 1 * Constants.MB, Constants.MaxSingleUploadBlobSize);
                this.singleBlobUploadThresholdInBytes = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of blocks that may be simultaneously uploaded when uploading a blob that is greater than 
        /// the value specified by the <see cref="SingleBlobUploadThresholdInBytes"/> property in size.
        /// </summary>
        /// <value>The number of parallel operations that may proceed.</value>
        public int ParallelOperationThreadCount
        {
            get
            {
                return this.parallelismFactor;
            }

            set
            {
                CommonUtils.AssertInBounds("UploadParallelActiveTasks", value, 1, MaxParallelOperationThreadCount);
                this.parallelismFactor = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the service client is used with Path style or Host style.
        /// </summary>
        /// <value>Is <c>true</c> if use path style uris; otherwise, <c>false</c>.</value>
        internal bool UsePathStyleUris { get; private set; }

        /// <summary>
        /// Returns a reference to a <see cref="CloudBlobContainer"/> object.
        /// </summary>
        /// <returns>A reference to the root container.</returns>
        public CloudBlobContainer GetRootContainerReference()
        {
            return new CloudBlobContainer(NavigationHelper.RootContainerName, this);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudBlobContainer"/> object with the specified name.
        /// </summary>
        /// <param name="containerName">The name of the container, or an absolute URI to the container.</param>
        /// <returns>A reference to a container.</returns>
        public CloudBlobContainer GetContainerReference(string containerName)
        {
            CommonUtils.AssertNotNullOrEmpty("containerName", containerName);
            return new CloudBlobContainer(containerName, this);
        }

        private ICanonicalizer GetCanonicalizer()
        {
            if (this.AuthenticationScheme == AuthenticationScheme.SharedKeyLite)
            {
                return SharedKeyLiteCanonicalizer.Instance;
            }

            return SharedKeyCanonicalizer.Instance;
        }

        /// <summary>
        /// Parses the user prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="listingPrefix">The listing prefix.</param>
        private static void ParseUserPrefix(string prefix, out string containerName, out string listingPrefix)
        {
            containerName = null;
            listingPrefix = null;

#if !COMMON
            string[] prefixParts = prefix.Split(NavigationHelper.SlashAsSplitOptions, 2, StringSplitOptions.None);
            if (prefixParts.Length == 1)
            {
                // No slash in prefix
                // Case abc => container = $root, prefix=abc; Listing with prefix at root
                listingPrefix = prefixParts[0];
            }
            else
            {
                // Case "/abc" => container=$root, prefix=abc; Listing with prefix at root
                // Case "abc/" => container=abc, no prefix; Listing all under a container
                // Case "abc/def" => container = abc, prefix = def; Listing with prefix under a container
                // Case "/" => container=$root, no prefix; Listing all under root
                containerName = prefixParts[0];
                listingPrefix = prefixParts[1];
            }

            if (string.IsNullOrEmpty(containerName))
            {
                containerName = NavigationHelper.RootContainerName;
            }

            if (string.IsNullOrEmpty(listingPrefix))
            {
                listingPrefix = null;
            }
#endif
        }
    }
}
