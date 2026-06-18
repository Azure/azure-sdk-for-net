// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec no longer emits this IoT custom-alert-rule discriminator subtype, so the generator only produces the common rule hierarchy; keep the previous GA subtype as a hidden shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the UnauthorizedOperationsNotInAllowedRange class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UnauthorizedOperationsNotInAllowedRange : TimeWindowCustomAlertRule, IJsonModel<UnauthorizedOperationsNotInAllowedRange>, IPersistableModel<UnauthorizedOperationsNotInAllowedRange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedOperationsNotInAllowedRange"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="isEnabled">The value preserved for API compatibility.</param>
        /// <param name="minThreshold">The value preserved for API compatibility.</param>
        /// <param name="maxThreshold">The value preserved for API compatibility.</param>
        /// <param name="timeWindowSize">The value preserved for API compatibility.</param>
        public UnauthorizedOperationsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        UnauthorizedOperationsNotInAllowedRange IJsonModel<UnauthorizedOperationsNotInAllowedRange>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<UnauthorizedOperationsNotInAllowedRange>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        UnauthorizedOperationsNotInAllowedRange IPersistableModel<UnauthorizedOperationsNotInAllowedRange>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<UnauthorizedOperationsNotInAllowedRange>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<UnauthorizedOperationsNotInAllowedRange>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
