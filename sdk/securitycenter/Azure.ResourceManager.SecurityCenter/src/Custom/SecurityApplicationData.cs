// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code now emits separate application data types for subscription and security-connector scopes; the previous GA shared SecurityApplicationData type is no longer in the TypeSpec model graph. Keep a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the SecurityApplicationData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityApplicationData : SecurityConnectorApplicationData, IJsonModel<SecurityApplicationData>, IPersistableModel<SecurityApplicationData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityApplicationData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityApplicationData() { }

        internal SecurityApplicationData(SecurityConnectorApplicationData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, new ChangeTrackingDictionary<string, System.BinaryData>())
        {
            Description = data.Description;
            DisplayName = data.DisplayName;
            SourceResourceType = data.SourceResourceType;
            foreach (System.BinaryData conditionSet in data.ConditionSets)
            {
                ConditionSets.Add(conditionSet);
            }
        }
        /// <summary>
        /// Gets the ConditionSets value preserved from the previous public API surface.
        /// </summary>
        public new IList<System.BinaryData> ConditionSets { get; } = new List<System.BinaryData>();
        /// <summary>
        /// Gets or sets the Description value preserved from the previous public API surface.
        /// </summary>
        public new string Description { get; set; }
        /// <summary>
        /// Gets or sets the DisplayName value preserved from the previous public API surface.
        /// </summary>
        public new string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the SourceResourceType value preserved from the previous public API surface.
        /// </summary>
        public new ApplicationSourceResourceType? SourceResourceType { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityApplicationData IJsonModel<SecurityApplicationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityApplicationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityApplicationData IPersistableModel<SecurityApplicationData>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityApplicationData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<SecurityApplicationData>.Write(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
