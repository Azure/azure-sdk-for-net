// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkToNetworkInterconnectPatch
    {
        /// <summary> Common properties for Layer2Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use Layer2Settings instead.")]
        public Layer2Configuration Layer2Configuration
        {
            get => ToLayer2Configuration(Layer2Settings);
            set => Layer2Settings = ToLayer2ConfigurationPatch(value);
        }

        private static Layer2Configuration ToLayer2Configuration(Layer2ConfigurationPatch value)
            => value is null ? null : new Layer2Configuration(value.Mtu, value.Interfaces.ToList(), additionalBinaryDataProperties: null);

        private static Layer2ConfigurationPatch ToLayer2ConfigurationPatch(Layer2Configuration value)
            => value is null ? null : new Layer2ConfigurationPatch(value.Mtu, value.Interfaces.ToList(), additionalBinaryDataProperties: null);
    }
}
