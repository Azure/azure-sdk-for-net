// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class LastAccessTimeTrackingPolicy
    {
        /// <summary> Backward-compatible alias for Enable. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("enable")]
        public bool IsEnabled
        {
            get => Enable;
            set => Enable = value;
        }
    }
}
