// -----------------------------------------------------------------------------------------
// <copyright file="CloudTableClient.Common.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
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
    /// Provides a client-side logical representation of the Windows Azure Table service. This client is used to configure and execute requests against the Table service.
    /// </summary>
    /// <remarks>The CloudTableClient object encapsulates the base URI for the Table service. If the service client will be used for authenticated access, 
    /// it also encapsulates the credentials for accessing the storage account.</remarks>    
    public sealed partial class CloudTableClient
    {
        /// <summary>
        /// The default server and client timeout interval.
        /// </summary>
        private TimeSpan? timeout;

        /// <summary>
        /// Max execution time across all potential retries.
        /// </summary>
        private TimeSpan? maximumExecutionTime;

        private AuthenticationScheme authenticationScheme;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTableClient"/> class using the specified Table service endpoint
        /// and anonymous credentials.
        /// </summary>
        /// <param name="baseUri">The Table service endpoint to use to create the client.</param>
        public CloudTableClient(Uri baseUri)
            : this(baseUri, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTableClient"/> class using the specified Table service endpoint
        /// and storage account credentials.
        /// </summary>
        /// <param name="baseUri">The Table service endpoint to use to create the client.</param>
        /// <param name="credentials">The storage account credentials.</param>
        public CloudTableClient(Uri baseUri, StorageCredentials credentials)
            : this(null, baseUri, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTableClient"/> class.
        /// </summary>
        /// <param name="usePathStyleUris">True to use path-style URIs.</param>
        /// <param name="baseUri">The Table service endpoint to use to create the client.</param>
        /// <param name="credentials">The storage account credentials.</param>
        internal CloudTableClient(bool? usePathStyleUris, Uri baseUri, StorageCredentials credentials)
        {
            CommonUtility.AssertNotNull("baseUri", baseUri);

            if (credentials == null)
            {
                credentials = new StorageCredentials();
            }

            if (!baseUri.IsAbsoluteUri)
            {
                string errorMessage = string.Format(
                                                CultureInfo.CurrentCulture,
                                                SR.RelativeAddressNotPermitted,
                                                baseUri.ToString());

                throw new ArgumentException(errorMessage, "baseUri");
            }

            this.BaseUri = baseUri;
            this.Credentials = credentials;
            this.RetryPolicy = new ExponentialRetry();
            this.ServerTimeout = Constants.DefaultServerSideTimeout;
            this.AuthenticationScheme = AuthenticationScheme.SharedKey;

            if (usePathStyleUris.HasValue)
            {
                this.UsePathStyleUris = usePathStyleUris.Value;
            }
            else
            {
                // Automatically decide whether to use host style uri or path style uri
                this.UsePathStyleUris = CommonUtility.UsePathStyleAddressing(this.BaseUri);
            }
        }

        /// <summary>
        /// Gets or sets a buffer manager that implements the <see cref="IBufferManager"/> interface, 
        /// specifying a buffer pool for use with operations against the Table service client.
        /// </summary>
        public IBufferManager BufferManager { get; set; }

        /// <summary>
        /// Gets the storage account credentials used to create the Table service client.
        /// </summary>
        /// <value>The storage account credentials.</value>
        public StorageCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets the base URI for the Table service client.
        /// </summary>
        /// <value>The base URI used to construct the Table service client.</value>
        public Uri BaseUri { get; private set; }

        /// <summary>
        /// Gets or sets the default retry policy for requests made via the Table service client.
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
                    CommonUtility.CheckTimeoutBounds(value.Value);
                }

                this.timeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum execution time across all potential retries.
        /// </summary>
        /// <value>The maximum execution time across all potential retries.</value>
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
                    CommonUtility.CheckTimeoutBounds(value.Value);
                }

                this.maximumExecutionTime = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the service client is used with Path style or Host style.
        /// </summary>
        /// <value>Is <c>true</c> if use path style URIs; otherwise, <c>false</c>.</value>
        internal bool UsePathStyleUris { get; private set; }

        /// <summary>
        /// Gets a reference to the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <returns>A <see cref="CloudTable"/> object.</returns>
        public CloudTable GetTableReference(string tableName)
        {
            CommonUtility.AssertNotNullOrEmpty("tableName", tableName);
            return new CloudTable(tableName, this);
        }

        private ICanonicalizer GetCanonicalizer()
        {
            if (this.AuthenticationScheme == AuthenticationScheme.SharedKeyLite)
            {
                return SharedKeyLiteTableCanonicalizer.Instance;
            }

            return SharedKeyTableCanonicalizer.Instance;
        }
    }
}
