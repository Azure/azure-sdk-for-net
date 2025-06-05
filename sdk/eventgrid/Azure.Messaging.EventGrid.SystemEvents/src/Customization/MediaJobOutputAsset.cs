// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> The event data for a Job output asset. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaJobOutputAsset : MediaJobOutput
    {
        /// <summary> Initializes a new instance of <see cref="MediaJobOutputAsset"/>. </summary>
        /// <param name="progress"> Gets the Job output progress. </param>
        /// <param name="state"> Gets the Job output state. </param>
        internal MediaJobOutputAsset(long progress, MediaJobState state) : base(progress, state)
        {
            OdataType = "#Microsoft.Media.JobOutputAsset";
        }

        /// <summary> Initializes a new instance of <see cref="MediaJobOutputAsset"/>. </summary>
        /// <param name="odataType"> The discriminator for derived types. </param>
        /// <param name="error"> Gets the Job output error. </param>
        /// <param name="label"> Gets the Job output label. </param>
        /// <param name="progress"> Gets the Job output progress. </param>
        /// <param name="state"> Gets the Job output state. </param>
        /// <param name="assetName"> Gets the Job output asset name. </param>
        internal MediaJobOutputAsset(string odataType, MediaJobError error, string label, long progress, MediaJobState state, string assetName) : base(odataType, error, label, progress, state)
        {
            AssetName = assetName;
            OdataType = odataType ?? "#Microsoft.Media.JobOutputAsset";
        }

        /// <summary> Gets the Job output asset name. </summary>
        public string AssetName { get; }
    }
}
