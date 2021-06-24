// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Azure.Core;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// An Exception thrown during an attempt to provide an unsupported asset file type in an asset conversion operation
    /// </summary>
    public class AssetFileTypeNotSupportedException : Exception, ISerializable
    {
        /// <summary>
        /// Creates an instance of the <see cref="AssetFileTypeNotSupportedException"/>
        /// </summary>
        public AssetFileTypeNotSupportedException()
            : base($"The provided asset file type is unsupported by Azure Object Anchors for conversion.")
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="AssetFileTypeNotSupportedException"/>
        /// </summary>
        /// <param name="message">The message corresponding to the exception</param>
        public AssetFileTypeNotSupportedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates an Exception thrown during an attempt to provide an unsupported asset file type in an asset conversion operation
        /// </summary>
        /// <param name="message">The message corresponding to the exception</param>
        /// <param name="inner">The inner exception</param>
        public AssetFileTypeNotSupportedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(AttemptedFileType), AttemptedFileType);
            info.AddValue(nameof(SupportedAssetFileTypes), SupportedAssetFileTypes);

            base.GetObjectData(info, context);
        }

        internal AssetFileTypeNotSupportedException(AssetFileType assetFileType, IReadOnlyList<AssetFileType> supportedAssetFileTypes)
            : base($"The provided asset file type of \"{assetFileType}\" is unsupported by Azure Object Anchors for conversion. Supported file types: {string.Join(", ", supportedAssetFileTypes)}")
        {
            AttemptedFileType = assetFileType;
            SupportedAssetFileTypes = supportedAssetFileTypes;
        }

        /// <summary>
        /// An Exception thrown during an attempt to provide an unsupported asset file type in an asset conversion operation
        /// </summary>
        /// <param name="info">The SerializationInfo</param>
        /// <param name="context">The StreamingContext</param>
        protected AssetFileTypeNotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            AttemptedFileType = (AssetFileType) info.GetValue(nameof(AttemptedFileType), typeof(AssetFileType));
            SupportedAssetFileTypes = (IReadOnlyList<AssetFileType>) info.GetValue(nameof(SupportedAssetFileTypes), typeof(IReadOnlyList<AssetFileType>));
        }

        /// <summary>
        /// The unsupported filetype provided for asset conversion
        /// </summary>
        public AssetFileType AttemptedFileType { get; }

        /// <summary>
        /// The list of file types supported by Azure Object Anchors Conversion
        /// </summary>
        public IReadOnlyList<AssetFileType> SupportedAssetFileTypes { get; }
    }
}
