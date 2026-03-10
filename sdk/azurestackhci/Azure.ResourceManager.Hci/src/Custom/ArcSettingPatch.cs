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
            get
            {
                if (Properties is null || Properties.ConnectivityProperties is null)
                    return null;
#pragma warning disable IL2026, IL3050 // Deprecated backward-compat property
                return BinaryData.FromObjectAsJson(Properties.ConnectivityProperties);
#pragma warning restore IL2026, IL3050
            }
            set
            {
                if (Properties is null)
                    Properties = new ArcSettingsPatchProperties();
#pragma warning disable IL2026, IL3050 // Deprecated backward-compat property
                Properties.ConnectivityProperties = value?.ToObjectFromJson<ArcConnectivityProperties>();
#pragma warning restore IL2026, IL3050
            }
        }
    }
}
