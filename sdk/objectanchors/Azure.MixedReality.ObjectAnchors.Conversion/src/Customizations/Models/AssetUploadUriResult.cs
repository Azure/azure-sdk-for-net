// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// The result of obtaining the upload location for an asset.
    /// </summary>
    [CodeGenModel("UploadLocation")]
    public partial class AssetUploadUriResult
    {
        /// <summary>
        /// Initializes a new instance of GetAssetUploadUriResult.
        /// </summary>
        /// <param name="inputAssetUriString"> The blob upload URI in storage where a model should be uploaded to the service for conversion. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputAssetUriString"/> is null. </exception>
        internal AssetUploadUriResult(string inputAssetUriString)
        {
            if (inputAssetUriString == null)
            {
                throw new ArgumentNullException(nameof(inputAssetUriString));
            }

            UploadUri = new Uri(inputAssetUriString);
        }

        /// <summary>
        /// The blob upload URI in storage where a model should be uploaded to the service for conversion.
        /// </summary>
        public Uri UploadUri { get; }

        [CodeGenMember("InputAssetUri")]
        internal string UploadUriString { get => UploadUri.AbsoluteUri; }
    }
}
