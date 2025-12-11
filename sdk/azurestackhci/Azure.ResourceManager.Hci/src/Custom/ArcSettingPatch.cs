// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.ClientModel.Primitives;

namespace Azure.ResourceManager.Hci.Models
{
    // Because of breaking changes in autogen, we need to add this property manually.
    public partial class ArcSettingPatch
    {
        /// <summary> contains connectivity related configuration for ARC resources. This property is deprecated. Please use ConnectivityConfigurations instead. </summary>
        [WirePath("properties.connectivityProperties")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData ConnectivityProperties
        {
            get
            {
                return ModelReaderWriter.Write(
                    ConnectivityConfigurations,
                    options: ModelReaderWriterOptions.Json,
                    context: AzureResourceManagerHciContext.Default);
            }
            set
            {
                ConnectivityConfigurations = ModelReaderWriter.Read<HciArcConnectivityProperties>(
                    value,
                    options: ModelReaderWriterOptions.Json,
                    context: AzureResourceManagerHciContext.Default);
            }
        }
    }
}
