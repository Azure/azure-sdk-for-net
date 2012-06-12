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
// <summary>
//    Contains code for the BlobRequestOptions.cs class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Represents a set of options that may be specified on a request.
    /// </summary>
    public class BlobRequestOptions
    {
        /// <summary>
        /// The server and client timeout interval for the request.
        /// </summary>
        private TimeSpan? timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobRequestOptions"/> class.
        /// </summary>
        public BlobRequestOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobRequestOptions"/> class based on an 
        /// existing instance.
        /// </summary>
        /// <param name="other">The set of request options to clone.</param>
        public BlobRequestOptions(BlobRequestOptions other)
        {
            this.Timeout = other.Timeout;
            this.RetryPolicy = other.RetryPolicy;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobRequestOptions"/> class.
        /// </summary>
        /// <param name="service">An object of type <see cref="CloudBlobClient"/>.</param>
        internal BlobRequestOptions(CloudBlobClient service)
            : this()
        {
            this.ApplyDefaults(service);
        }

        /// <summary>
        /// Gets or sets the retry policy for the request.
        /// </summary>
        /// <value>The retry policy delegate.</value>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the server and client timeout for the request. 
        /// </summary>
        /// <value>The server and client timeout interval for the request.</value>
        public TimeSpan? Timeout
        {
            get
            {
                return this.timeout;
            }

            set
            {
                if (value.HasValue)
                {
                    Utilities.CheckTimeoutBounds(value.Value);
                }

                this.timeout = value;
            }
        }

        /// <summary>
        /// Creates the full modifier.
        /// </summary>
        /// <typeparam name="T">The type of the options.</typeparam>
        /// <param name="service">The service.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A full modifier of the requested type.</returns>
        internal static T CreateFullModifier<T>(CloudBlobClient service, T options)
            where T : BlobRequestOptions, new()
        {
            T fullModifier = null;

            if (options != null)
            {
                fullModifier = options.Clone() as T;
            }
            else
            {
                fullModifier = new T();
            }

            fullModifier.ApplyDefaults(service);
            return fullModifier;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A clone of the instance.</returns>
        internal virtual BlobRequestOptions Clone()
        {
            return new BlobRequestOptions(this);
        }

        /// <summary>
        /// Applies the defaults.
        /// </summary>
        /// <param name="service">The service.</param>
        internal virtual void ApplyDefaults(CloudBlobClient service)
        {
            this.Timeout = this.Timeout ?? service.Timeout;
            this.RetryPolicy = this.RetryPolicy ?? service.RetryPolicy;
        }
    }
}
