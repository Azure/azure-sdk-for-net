// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.DeviceProvisioningServices
{
    public partial class DeviceProvisioningServicesPrivateLinkResource : IJsonModel<DeviceProvisioningServicesPrivateLinkResourceData>
    {
        void IJsonModel<DeviceProvisioningServicesPrivateLinkResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DeviceProvisioningServicesPrivateLinkResourceData>)Data).Write(writer, options);

        DeviceProvisioningServicesPrivateLinkResourceData IJsonModel<DeviceProvisioningServicesPrivateLinkResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<DeviceProvisioningServicesPrivateLinkResourceData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<DeviceProvisioningServicesPrivateLinkResourceData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<DeviceProvisioningServicesPrivateLinkResourceData>(Data, options, AzureResourceManagerDeviceProvisioningServicesContext.Default);

        DeviceProvisioningServicesPrivateLinkResourceData IPersistableModel<DeviceProvisioningServicesPrivateLinkResourceData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DeviceProvisioningServicesPrivateLinkResourceData>(data, options, AzureResourceManagerDeviceProvisioningServicesContext.Default);

        string IPersistableModel<DeviceProvisioningServicesPrivateLinkResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<DeviceProvisioningServicesPrivateLinkResourceData>)Data).GetFormatFromOptions(options);
    }
}
