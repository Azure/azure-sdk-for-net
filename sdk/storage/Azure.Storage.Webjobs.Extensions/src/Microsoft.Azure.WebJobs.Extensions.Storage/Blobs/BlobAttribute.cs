// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{ 
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Blob. The attribute supports binding
    /// to single blobs, blob containers, or collections of blobs.
    /// </summary>
    /// <remarks>
    /// The method parameter type can be one of the following:
    /// <list type="bullet">
    /// <item><description>ICloudBlob</description></item>
    /// <item><description>CloudBlockBlob</description></item>
    /// <item><description>CloudPageBlob</description></item>
    /// <item><description><see cref="Stream"/> (read-only)</description></item>
    /// <item><description>CloudBlobStream (write-only)</description></item>
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
    /// <item><description>ICloudBlob</description></item>
    /// <item><description>CloudBlockBlob</description></item>
    /// <item><description>CloudPageBlob</description></item>
    /// <item><description>Stream</description></item>
    /// <item><description>string</description></item>
    /// <item><description>TextReader</description></item>
    /// </list>
    /// </remarks>
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "There is an accessor for FileAccess")]
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
