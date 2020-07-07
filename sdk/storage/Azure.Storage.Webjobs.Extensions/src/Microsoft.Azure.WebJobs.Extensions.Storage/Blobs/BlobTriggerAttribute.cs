// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Blob, causing the method to run when a blob is
    /// uploaded.
    /// </summary>
    /// <remarks>
    /// The method parameter type can be one of the following:
    /// <list type="bullet">
    /// <item><description>ICloudBlob</description></item>
    /// <item><description>CloudBlockBlob</description></item>
    /// <item><description>CloudPageBlob</description></item>
    /// <item><description><see cref="Stream"/></description></item>
    /// <item><description><see cref="TextReader"/></description></item>
    /// <item><description><see cref="string"/></description></item>
    /// <item><description><see cref="T:byte[]"/></description></item>
    /// </list>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Parameter)]
    [DebuggerDisplay("{BlobPath,nq}")]
    [ConnectionProvider(typeof(StorageAccountAttribute))]
    [Binding]
    public sealed class BlobTriggerAttribute : Attribute, IConnectionProvider
    {
        private readonly string _blobPath;

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
    }
}
