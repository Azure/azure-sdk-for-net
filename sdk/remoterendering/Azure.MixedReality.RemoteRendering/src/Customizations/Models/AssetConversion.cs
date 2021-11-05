// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// Information concerning the state of a conversion.
    /// </summary>
    [CodeGenModel("Conversion")]
    public partial class AssetConversion
    {
        /// <summary> The id of the conversion supplied when the conversion was created. </summary>
        [CodeGenMember("Id")]
        public string ConversionId { get; }

        /// <summary> Settings for where to retrieve input files from and where to write output files. Supplied when creating the conversion. </summary>
        [CodeGenMember("Settings")]
        public AssetConversionOptions Options { get; }

        /// <summary> The time when the conversion was created. Date and time in ISO 8601 format. </summary>
        [CodeGenMember("CreationTime")]
        public DateTimeOffset CreatedOn { get; }
    }
}
