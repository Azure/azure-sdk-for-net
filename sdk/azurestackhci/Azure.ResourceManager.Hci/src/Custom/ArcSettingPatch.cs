// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    [CodeGenSuppress("ConnectivityProperties")]
    public partial class ArcSettingPatch
    {
        /// <summary> Contains connectivity related configuration for ARC resources. </summary>
        [Obsolete("This property is obsolete. Use Properties.ConnectivityProperties with type ArcConnectivityProperties instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.connectivityProperties")]
        public BinaryData ConnectivityProperties
        {
            get => throw new NotSupportedException("This property is obsolete. Use Properties.ConnectivityProperties instead.");
            set => throw new NotSupportedException("This property is obsolete. Use Properties.ConnectivityProperties instead.");
        }
    }
}
