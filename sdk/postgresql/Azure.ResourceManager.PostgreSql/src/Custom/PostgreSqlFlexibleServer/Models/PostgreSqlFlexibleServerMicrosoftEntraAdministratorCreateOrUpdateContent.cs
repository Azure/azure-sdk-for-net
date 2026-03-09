// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.PostgreSql.FlexibleServers;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Represents a Microsoft Entra administrator create or update content. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent : IJsonModel<PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent>, IPersistableModel<PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent>
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent"/>. </summary>
        public PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent()
        {
        }

        /// <summary> The principal type used to represent the type of Active Directory Administrator. </summary>
        [WirePath("properties.principalType")]
        public PostgreSqlFlexibleServerPrincipalType? PrincipalType { get; set; }
        /// <summary> Active Directory administrator principal name. </summary>
        [WirePath("properties.principalName")]
        public string PrincipalName { get; set; }
        /// <summary> The tenantId of the Active Directory administrator. </summary>
        [WirePath("properties.tenantId")]
        public Guid? TenantId { get; set; }

        /// <summary> Writes the model to the provided <see cref="Utf8JsonWriter"/>. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (PrincipalType.HasValue)
            {
                writer.WritePropertyName("principalType"u8);
                writer.WriteStringValue(PrincipalType.Value.ToString());
            }
            if (PrincipalName != null)
            {
                writer.WritePropertyName("principalName"u8);
                writer.WriteStringValue(PrincipalName);
            }
            if (TenantId.HasValue)
            {
                writer.WritePropertyName("tenantId"u8);
                writer.WriteStringValue(TenantId.Value.ToString());
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        void IJsonModel<PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent IJsonModel<PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return new PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent();
        }

        BinaryData IPersistableModel<PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent)} does not support writing '{format}' format.");
            }
            return ModelReaderWriter.Write(this, options, AzureResourceManagerPostgreSqlContext.Default);
        }

        PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent IPersistableModel<PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            return new PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent();
        }

        string IPersistableModel<PostgreSqlFlexibleServerMicrosoftEntraAdministratorCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Converts to AdministratorMicrosoftEntraAdd. </summary>
        internal AdministratorMicrosoftEntraAdd ToAdministratorMicrosoftEntraAdd()
        {
            return new AdministratorMicrosoftEntraAdd
            {
                PrincipalType = PrincipalType,
                PrincipalName = PrincipalName,
                TenantId = TenantId?.ToString()
            };
        }
    }
}
