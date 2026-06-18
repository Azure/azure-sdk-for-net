// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec shape renamed this GA model to AwsEnvironmentInfo. Keep this hidden compatibility type and delegate wire operations to the generated replacement.
    /// <summary>
    /// Provides a compatibility shim for the AwsEnvironment class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AwsEnvironment : SecurityConnectorEnvironment, IJsonModel<AwsEnvironment>, IPersistableModel<AwsEnvironment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AwsEnvironment"/> type for compatibility with the previous public API surface.
        /// </summary>
        public AwsEnvironment() { }

        private AwsEnvironment(AwsEnvironmentInfo info) : this()
        {
            OrganizationalData = info.OrganizationalData;
            foreach (string region in info.Regions)
            {
                Regions.Add(region);
            }
            AccountName = info.AccountName;
            ScanInterval = info.ScanInterval;
        }

        private AwsEnvironmentInfo ToGenerated()
        {
            return new AwsEnvironmentInfo(EnvironmentType.AwsAccount, new Dictionary<string, BinaryData>(), OrganizationalData, new List<string>(Regions), AccountName, ScanInterval);
        }
        /// <summary>
        /// Gets the AccountName value preserved from the previous public API surface.
        /// </summary>
        public string AccountName { get; }
        /// <summary>
        /// Gets or sets the OrganizationalData value preserved from the previous public API surface.
        /// </summary>
        public AwsOrganizationalInfo OrganizationalData { get; set; }
        /// <summary>
        /// Gets the Regions value preserved from the previous public API surface.
        /// </summary>
        public IList<string> Regions { get; } = new List<string>();
        /// <summary>
        /// Gets or sets the ScanInterval value preserved from the previous public API surface.
        /// </summary>
        public long? ScanInterval { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(((IPersistableModel<AwsEnvironmentInfo>)ToGenerated()).Write(options), ModelSerializationExtensions.JsonDocumentOptions);
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }
        }
        AwsEnvironment IJsonModel<AwsEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new AwsEnvironment(((IJsonModel<AwsEnvironmentInfo>)new AwsEnvironmentInfo()).Create(ref reader, options));
        void IJsonModel<AwsEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<AwsEnvironmentInfo>)ToGenerated()).Write(writer, options);
        AwsEnvironment IPersistableModel<AwsEnvironment>.Create(System.BinaryData data, ModelReaderWriterOptions options) => new AwsEnvironment(((IPersistableModel<AwsEnvironmentInfo>)new AwsEnvironmentInfo()).Create(data, options));
        string IPersistableModel<AwsEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<AwsEnvironmentInfo>)new AwsEnvironmentInfo()).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<AwsEnvironment>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<AwsEnvironmentInfo>)ToGenerated()).Write(options);
    }
}
