// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Keep the GA environment model shape writable: the generated discriminator hierarchy does not expose the previous public constructor and flattened settable properties needed for source compatibility.
    public partial class AwsEnvironment : IPersistableModel<AwsEnvironment>
    {
        /// <summary> Initializes a new instance of <see cref="AwsEnvironment"/>. </summary>
        public AwsEnvironment() : base(EnvironmentType.AwsAccount, new ChangeTrackingDictionary<string, BinaryData>())
        {
            Regions = new ChangeTrackingList<string>();
        }

        /// <summary> Gets the AWS account name. </summary>
        public string AccountName { get; }

        /// <summary> Gets or sets the AWS account's organizational data. </summary>
        public AwsOrganizationalInfo OrganizationalData { get; set; }

        /// <summary> Gets the list of regions to scan. </summary>
        public IList<string> Regions { get; }

        /// <summary> Gets or sets the scan interval in hours. </summary>
        public long? ScanInterval { get; set; }

        void IJsonModel<AwsEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        AwsEnvironment IJsonModel<AwsEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (AwsEnvironment)JsonModelCreateCore(ref reader, options);
        BinaryData IPersistableModel<AwsEnvironment>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        AwsEnvironment IPersistableModel<AwsEnvironment>.Create(BinaryData data, ModelReaderWriterOptions options) => (AwsEnvironment)PersistableModelCreateCore(data, options);
        string IPersistableModel<AwsEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
