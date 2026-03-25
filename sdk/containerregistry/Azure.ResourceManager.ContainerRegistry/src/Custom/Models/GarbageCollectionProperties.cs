// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> Backward-compat shim: restores GarbageCollectionProperties.Enabled
    /// which was renamed to IsEnabled to follow the Azure SDK boolean naming convention. </summary>
    public partial class GarbageCollectionProperties
    {
        /// <summary> Indicates whether garbage collection is enabled for the connected registry. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("enabled")]
        public bool? Enabled
        {
            get => IsEnabled;
            set => IsEnabled = value;
        }
    }
}
