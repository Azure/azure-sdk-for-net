// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{
#pragma warning disable CA1200 // Avoid using cref tags with a prefix
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Blob, causing the method to run when a blob is
    /// uploaded.
    /// </summary>
    /// <remarks>
    /// The method parameter type can be one of the following:
    /// <list type="bullet">
    /// <item><description><see cref="BlobClient"/></description></item>
    /// <item><description><see cref="BlobBaseClient"/></description></item>
    /// <item><description><see cref="AppendBlobClient"/></description></item>
    /// <item><description><see cref="BlockBlobClient"/></description></item>
    /// <item><description><see cref="PageBlobClient"/></description></item>
    /// <item><description><see cref="Stream"/></description></item>
    /// <item><description><see cref="TextReader"/></description></item>
    /// <item><description><see cref="string"/></description></item>
    /// <item><description><see cref="T:byte[]"/></description></item>
    /// </list>
    /// </remarks>
#pragma warning restore CA1200 // Avoid using cref tags with a prefix
    [AttributeUsage(AttributeTargets.Parameter)]
    [DebuggerDisplay("{BlobPath,nq}")]
    [ConnectionProvider(typeof(StorageAccountAttribute))]
    [Binding]
    public sealed class BlobTriggerAttribute : Attribute, IConnectionProvider
    {
        private readonly string _blobPath;

        // LogsAndContainerScan is default kind as it does not require additional actions to set up a blob trigger
        private BlobTriggerSource _blobTriggerSource = BlobTriggerSource.LogsAndContainerScan;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobTriggerAttribute"/> class.
        /// </summary>
        /// <param name="blobPath">The path of the blob to which to bind.</param>
        /// <remarks>
        /// The blob portion of the path can contain tokens in curly braces to indicate a pattern to match. The matched
        /// name can be used in other binding attributes to define the output name of a Job function.
        /// </remarks>
        public BlobTriggerAttribute(string blobPath)
        {
            _blobPath = blobPath;
        }

        /// <summary>
        /// Gets or sets the app setting name that contains the Azure Storage connection string.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>Gets the path of the blob to which to bind.</summary>
        /// <remarks>
        /// The blob portion of the path can contain tokens in curly braces to indicate a pattern to match. The matched
        /// name can be used in other binding attributes to define the output name of a Job function.
        /// </remarks>
        public string BlobPath
        {
            get { return _blobPath; }
        }

        /// <summary>
        /// Returns a bool value that indicates whether EventGrid is used.
        /// </summary>
        public BlobTriggerSource Source
        {
            get { return _blobTriggerSource; }
            set { _blobTriggerSource = value; }
        }
    }
}
