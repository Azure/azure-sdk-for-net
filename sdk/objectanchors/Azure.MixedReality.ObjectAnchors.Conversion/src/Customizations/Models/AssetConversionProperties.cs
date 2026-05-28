// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.MixedReality.ObjectAnchors.Conversion.Models;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// Represents the properties of an AOA asset conversion job.
    /// </summary>
    [CodeGenModel("IngestionProperties")]
    public partial class AssetConversionProperties
    {
        /// <summary>
        /// Represents the properties of an AOA asset conversion job.
        /// </summary>
        internal AssetConversionProperties()
        {
        }

        /// <summary>
        /// The URI for downloading the generated AOA Model.
        /// </summary>
        public Uri OutputModelUri
        {
            get
            {
                return OutputModelUriString == null ? null : new Uri(OutputModelUriString);
            }
        }
        /// <summary>
        /// The Uri to the Asset to be ingested by the AOA Asset Conversion Service. This asset needs to have been uploaded to the service using an endpoint provided from a call to the GetUploadUri API.
        /// </summary>
        public Uri InputAssetUri
        {
            get
            {
                return InputAssetUriString == null ? null : new Uri(InputAssetUriString);
            }
            internal set
            {
                InputAssetUriString = value.AbsoluteUri;
            }
        }

        /// <summary>
        /// The status of the AOA asset conversion job.
        /// </summary>
        [CodeGenMember("JobStatus")]
        public AssetConversionStatus? ConversionStatus { get; internal set; }

        /// <summary>
        /// The configuration of the AOA asset conversion job.
        /// </summary>
        [CodeGenMember("IngestionConfiguration")]
        public AssetConversionConfiguration ConversionConfiguration { get; internal set; }

        /// <summary>
        /// The error code of the AOA asset conversion job.
        /// </summary>
        public ConversionErrorCode ErrorCode { get; }

        /// <summary>
        /// The file type of the original 3D asset. Examples include: &quot;ply&quot;, &quot;obj&quot;, &quot;fbx&quot;, &quot;glb&quot;, &quot;gltf&quot;, etc.
        /// </summary>
        public AssetFileType InputAssetFileType { get; internal set; }

        /// <summary>
        /// Identifier for the AOA Ingestion Job. </summary>
        public Guid JobId { get => JobIdInternal.GetValueOrDefault(); set => JobIdInternal = value; }

        /// <summary> Identifier for the Account owning the AOA Ingestion Job.
        /// </summary>
        public Guid AccountId { get => AccountIdInternal.GetValueOrDefault(); set => AccountIdInternal = value; }

        /// <summary>
        /// The scaled dimensions of the asset.
        /// </summary>
        public System.Numerics.Vector3? ScaledAssetDimensions { get => ScaledAssetDimensionsWrapper == null ? null : (System.Numerics.Vector3)ScaledAssetDimensionsWrapper; }

        [CodeGenMember("OutputModelUri")]
        internal string OutputModelUriString { get; }

        [CodeGenMember("InputAssetUri")]
        internal string InputAssetUriString { get; set; }

        [CodeGenMember("AssetFileType")]
        internal string AssetFileTypeString { get => this.InputAssetFileType.ToString(); set => this.InputAssetFileType = new AssetFileType(value); }

        [CodeGenMember("JobId")]
        internal Guid? JobIdInternal { get; set; }

        [CodeGenMember("AccountId")]
        internal Guid? AccountIdInternal { get; set; }

        [CodeGenMember("ScaledAssetDimensions")]
        internal Vector3 ScaledAssetDimensionsWrapper { get; set; }
    }
}
