// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("ElasticsearchChatExtensionConfiguration", typeof(ElasticsearchChatExtensionParameters))]
public partial class ElasticsearchChatExtensionConfiguration : AzureChatExtensionConfiguration
{
    // CUSTOM CODE NOTE:
    //    These changes facilitate the direct use of the extension "configuration" classes for access to their
    //    constituent "parameter" values. These serialize into a subordinate payload within the wire format
    //    REST structure but don't convey additional semantic meaning, so internalizing parameter types and then
    //    plumbing the configuration through substantially simplifies the experience.

    /// <summary> Initializes a new instance of <see cref="ElasticsearchChatExtensionConfiguration"/>. </summary>
    public ElasticsearchChatExtensionConfiguration()
    {
        Type = AzureChatExtensionType.Elasticsearch;
        Parameters = new ElasticsearchChatExtensionParameters();
    }

    internal ElasticsearchChatExtensionParameters Parameters { get; }

    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.Authentication"/>
    public OnYourDataAuthenticationOptions Authentication
    {
        get => Parameters.Authentication;
        set => Parameters.Authentication = value;
    }
    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.DocumentCount"/>
    public int? DocumentCount
    {
        get => Parameters.DocumentCount;
        set => Parameters.DocumentCount = value;
    }
    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.ShouldRestrictResultScope"/>
    public bool? ShouldRestrictResultScope
    {
        get => Parameters.ShouldRestrictResultScope;
        set => Parameters.ShouldRestrictResultScope = value;
    }
    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.Strictness"/>
    public int? Strictness
    {
        get => Parameters.Strictness;
        set => Parameters.Strictness = value;
    }
    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => Parameters.RoleInformation;
        set => Parameters.RoleInformation = value;
    }
    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.Endpoint"/>
    public Uri Endpoint
    {
        get => Parameters.Endpoint;
        set => Parameters.Endpoint = value;
    }
    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.IndexName"/>
    public string IndexName
    {
        get => Parameters.IndexName;
        set => Parameters.IndexName = value;
    }
    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.FieldMappingOptions"/>
    public ElasticsearchIndexFieldMappingOptions FieldMappingOptions
    {
        get => Parameters.FieldMappingOptions;
        set => Parameters.FieldMappingOptions = value;
    }
    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.QueryType"/>
    public ElasticsearchQueryType? QueryType
    {
        get => Parameters.QueryType;
        set => Parameters.QueryType = value;
    }
    /// <inheritdoc cref="ElasticsearchChatExtensionParameters.EmbeddingDependency"/>
    public OnYourDataVectorizationSource VectorizationSource
    {
        get => Parameters.EmbeddingDependency;
        set => Parameters.EmbeddingDependency = value;
    }
}
