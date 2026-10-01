// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable AAIP001
#pragma warning disable AAIP002

namespace Azure.AI.Extensions.OpenAI;

public partial class OAuthConsentRequestResponseItem : AgentResponseItem
{
    /// <inheritdoc/>
    protected override AgentResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeOAuthConsentRequestResponseItem(document.RootElement, options);
    }

    /// <inheritdoc/>
    protected override AgentResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeOAuthConsentRequestResponseItem(document.RootElement, options);
    }

    internal OAuthConsentRequestResponseItem(AgentResponseItemKind @type, string id, AgentReference agentReference, string responseId, IDictionary<string, BinaryData> additionalBinaryDataProperties, string internalConsentLink, string serverLabel) : base(@type, id, agentReference, responseId, additionalBinaryDataProperties)
    {
        ConsentLink = internalConsentLink == null ? null : new Uri(internalConsentLink);
        ServerLabel = serverLabel;
    }

    internal static OAuthConsentRequestResponseItem DeserializeOAuthConsentRequestResponseItem(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        AgentResponseItemKind @type = default;
        string id = default;
        AgentReference agentReference = default;
        string responseId = default;
        IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        string internalConsentLink = default;
        string serverLabel = default;
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("type"u8))
            {
                @type = new AgentResponseItemKind(prop.Value.GetString());
                continue;
            }
            if (prop.NameEquals("id"u8))
            {
                id = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("agent_reference"u8))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                agentReference = AgentReference.DeserializeAgentReference(prop.Value, options);
                continue;
            }
            if (prop.NameEquals("response_id"u8))
            {
                responseId = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("consent_link"u8))
            {
                internalConsentLink = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("server_label"u8))
            {
                serverLabel = prop.Value.GetString();
                continue;
            }
            if (options.Format != "W")
            {
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
        }
        return new OAuthConsentRequestResponseItem(
            @type,
            id,
            agentReference,
            responseId,
            additionalBinaryDataProperties,
            internalConsentLink,
            serverLabel);
    }

    internal OAuthConsentRequestResponseItem(Uri consentLink, string serverLabel, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(ResponseItemKind.OAuthConsentRequest)
    {
        ConsentLink = consentLink;
        ServerLabel = serverLabel;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}
