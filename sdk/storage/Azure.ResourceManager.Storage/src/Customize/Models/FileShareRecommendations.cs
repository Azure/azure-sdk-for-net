// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class FileShareRecommendations
    {
        /// <summary> Backward-compatible alias for BaseIOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("baseIOPS")]
        public int? BaseIops => BaseIOPS;
    }
}
