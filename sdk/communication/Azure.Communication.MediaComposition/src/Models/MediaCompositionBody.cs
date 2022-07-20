// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.MediaComposition.Models
{
    /// <summary>Media Composition Body.</summary>
    [CodeGenModel("MediaCompositionBody")]
    public partial class MediaCompositionBody
    {
        /// <summary> Layout configuration of the composition. </summary>
        public MediaCompositionLayout Layout { get; set; }
        /// <summary> Inputs used in the composition. </summary>
        public IDictionary<string, MediaInput> Inputs { get; }
        /// <summary> Outputs used in the composition. </summary>
        public IDictionary<string, MediaOutput> Outputs { get; }
    }
}
