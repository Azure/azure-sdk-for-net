// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Hci.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    [CodeGenSuppress("ConnectivityProperties")]
    public partial class ArcSettingData
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
