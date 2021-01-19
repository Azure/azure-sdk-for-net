// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs;

namespace Microsoft.Azure.WebJobs
{
#pragma warning disable CA1200 // Avoid using cref tags with a prefix
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Blob. The attribute supports binding
    /// to single blobs, blob containers, or collections of blobs.
    /// </summary>
    /// <remarks>
    /// The method parameter type can be one of the following:
    /// <list type="bullet">
    /// <item><description><see cref="BlobBaseClient"/></description></item>
    /// <item><description><see cref="AppendBlobClient"/></description></item>
    /// <item><description><see cref="BlockBlobClient"/></description></item>
    /// <item><description><see cref="PageBlobClient"/></description></item>
    /// <item><description><see cref="Stream"/></description></item>
    /// <item><description><see cref="TextReader"/></description></item>
    /// <item><description><see cref="TextWriter"/></description></item>
    /// <item><description>
    /// <see cref="string"/> (normally for reading, or as an out parameter for writing)
    /// </description>
    /// </item>
    /// <item><description>
    /// <see cref="T:byte[]"/> (normally for reading, or as an out parameter for writing)
    /// </description>
    /// </item>
    /// </list>
    /// In addition to single blob bindings,  parameters can be bound to multiple blobs.
    /// The parameter type can be CloudBlobContainer, CloudBlobDirectory or <see cref="IEnumerable{T}"/>
    /// of one of the following element types:
    /// <list type = "bullet" >
    /// <item><description><see cref="BlobClient"/></description></item>
    /// <item><description><see cref="BlobBaseClient"/></description></item>
    /// <item><description><see cref="AppendBlobClient"/></description></item>
    /// <item><description><see cref="BlockBlobClient"/></description></item>
    /// <item><description><see cref="PageBlobClient"/></description></item>
    /// <item><description><see cref="Stream"/></description></item>
    /// <item><description><see cref="string"/></description></item>
    /// <item><description><see cref="TextReader"/></description></item>
    /// </list>
    /// </remarks>
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "There is an accessor for FileAccess")]
#pragma warning restore CA1200 // Avoid using cref tags with a prefix
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [DebuggerDisplay("{BlobPath,nq}")]
    [ConnectionProvider(typeof(StorageAccountAttribute))]
    [Binding]
    public sealed class BlobAttribute : Attribute, IConnectionProvider
    {
        private readonly string _blobPath;
        private FileAccess? _access;

        /// <summary>Initializes a new instance of the <see cref="BlobAttribute"/> class.</summary>
        /// <param name="blobPath">The path of the blob to which to bind.</param>
        public BlobAttribute(string blobPath)
        {
            _blobPath = blobPath;
        }

        /// <summary>Initializes a new instance of the <see cref="BlobAttribute"/> class.</summary>
        /// <param name="blobPath">The path of the blob to which to bind.</param>
        /// <param name="access">The kind of operations that can be performed on the blob.</param>
        public BlobAttribute(string blobPath, FileAccess access)
        {
            _blobPath = blobPath;
            _access = access;
        }

        /// <summary>Gets the path of the blob to which to bind.</summary>
        [AutoResolve]
        [BlobNameValidation]
        public string BlobPath
        {
            get { return _blobPath; }
        }

        /// <summary>
        /// Gets the kind of operations that can be performed on the blob.
        /// </summary>
        public FileAccess? Access
        {
            get { return _access; }
            set { _access = value; }
        }

        /// <summary>
        /// Gets or sets the app setting name that contains the Azure Storage connection string.
        /// </summary>
        public string Connection { get; set; }
    }
}
