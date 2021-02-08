// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// Information concerning the state of a conversion.
    /// </summary>
    [CodeGenModel("ConversionSettings")]
    public partial class AssetConversionOptions
    {
        /// <summary> Options for the conversion input. </summary>
        [CodeGenMember("InputLocation")]
        public AssetConversionInputOptions InputOptions { get; }

        /// <summary> Options for the conversion output. </summary>
        [CodeGenMember("OutputLocation")]
        public AssetConversionOutputOptions OutputOptions { get; }
    }
}
