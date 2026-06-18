// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class QueuePurgesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>
    {
        public QueuePurgesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
