// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class GcpProjectEnvironment : IPersistableModel<GcpProjectEnvironment>
    {
        /// <summary> Initializes a new instance of <see cref="GcpProjectEnvironment"/>. </summary>
        public GcpProjectEnvironment() : base(EnvironmentType.GcpProject, new ChangeTrackingDictionary<string, BinaryData>())
        {
        }

        /// <summary> Gets or sets the GCP project's organizational data. </summary>
        public GcpOrganizationalInfo OrganizationalData { get; set; }

        /// <summary> Gets or sets the GCP project's details. </summary>
        public GcpProjectDetails ProjectDetails { get; set; }

        /// <summary> Gets or sets the scan interval in hours. </summary>
        public long? ScanInterval { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            base.JsonModelWriteCore(writer, options);
            WriteModel(writer, "organizationalData", OrganizationalData, options);
            WriteModel(writer, "projectDetails", ProjectDetails, options);
            if (Optional.IsDefined(ScanInterval))
            {
                writer.WritePropertyName("scanInterval"u8);
                writer.WriteNumberValue(ScanInterval.Value);
            }
        }

        void IJsonModel<GcpProjectEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        GcpProjectEnvironment IJsonModel<GcpProjectEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (GcpProjectEnvironment)JsonModelCreateCore(ref reader, options);
        BinaryData IPersistableModel<GcpProjectEnvironment>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        GcpProjectEnvironment IPersistableModel<GcpProjectEnvironment>.Create(BinaryData data, ModelReaderWriterOptions options) => (GcpProjectEnvironment)PersistableModelCreateCore(data, options);
        string IPersistableModel<GcpProjectEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

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
