// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter;

namespace Azure.ResourceManager.SecurityCenter.Models
{
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

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            base.JsonModelWriteCore(writer, options);
            WriteModel(writer, "organizationalData", OrganizationalData, options);
            writer.WritePropertyName("regions"u8);
            writer.WriteStartArray();
            foreach (string region in Regions)
            {
                writer.WriteStringValue(region);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(AccountName))
            {
                writer.WritePropertyName("accountName"u8);
                writer.WriteStringValue(AccountName);
            }
            if (Optional.IsDefined(ScanInterval))
            {
                writer.WritePropertyName("scanInterval"u8);
                writer.WriteNumberValue(ScanInterval.Value);
            }
        }

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

        private static void WriteModel<T>(Utf8JsonWriter writer, string propertyName, T value, ModelReaderWriterOptions options)
        {
            if (value is null)
            {
                return;
            }

            writer.WritePropertyName(propertyName);
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(value, options, AzureResourceManagerSecurityCenterContext.Default), ModelSerializationExtensions.JsonDocumentOptions);
            document.RootElement.WriteTo(writer);
        }
    }
}
