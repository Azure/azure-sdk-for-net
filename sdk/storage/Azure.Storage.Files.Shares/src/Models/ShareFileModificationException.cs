﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.Serialization;
using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// An exception thrown if <see cref="Stream"/> returned from <code>ShareFileClient.OpenRead</code> or <code>ShareFileClient.OpenReadAsync</code>
    /// observed that a file content has been modified during the read.
    /// </summary>
    [Serializable]
    public class ShareFileModificationException : Exception, ISerializable
    {
        /// <summary>
        /// Gets the URI of the resurce that has been modified.
        /// </summary>
        public Uri ResourceUri { get;  }

        /// <summary>
        /// Gets the ETag value that was expected during the read.
        /// </summary>
        public ETag ExpectedETag { get; }

        /// <summary>
        /// Gets the ETag value that was received from the service.
        /// </summary>
        public ETag ActualETag { get; }

        /// <summary>
        /// Gets the range that was requested for the service.
        /// </summary>
        public HttpRange Range { get; }

        /// <summary>
        /// Creates a new instance of <see cref="ShareFileModificationException"/>.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="resurceUri">The URI of the resurce that has been modified.</param>
        /// <param name="expectedETag">The ETag value that was expected during the read.</param>
        /// <param name="actualEtag">The ETag value that was received from the service.</param>
        /// <param name="range">The range that was requested for the service.</param>
        public ShareFileModificationException(
            string message,
            Uri resurceUri,
            ETag expectedETag,
            ETag actualEtag,
            HttpRange range) : base(message)
        {
            ResourceUri = resurceUri;
            ExpectedETag = expectedETag;
            ActualETag = actualEtag;
            Range = range;
        }

        /// <inheritdoc />
        protected ShareFileModificationException(SerializationInfo info, StreamingContext streamingContext)
        {
            ResourceUri = (Uri)info.GetValue(nameof(ResourceUri), typeof(Uri));
            ExpectedETag = (ETag)info.GetValue(nameof(ExpectedETag), typeof(ETag));
            ActualETag = (ETag)info.GetValue(nameof(ActualETag), typeof(ETag));
            Range = (HttpRange)info.GetValue(nameof(Range), typeof(HttpRange));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));
            info.AddValue(nameof(ResourceUri), ResourceUri);
            info.AddValue(nameof(ExpectedETag), ExpectedETag);
            info.AddValue(nameof(ActualETag), ActualETag);
            info.AddValue(nameof(Range), Range);
            base.GetObjectData(info, context);
        }
    }
}
