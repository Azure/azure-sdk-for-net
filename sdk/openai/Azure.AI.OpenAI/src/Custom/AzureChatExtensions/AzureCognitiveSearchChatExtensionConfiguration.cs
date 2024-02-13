// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("AzureCognitiveSearchChatExtensionConfiguration", typeof(AzureCognitiveSearchChatExtensionParameters))]
public partial class AzureCognitiveSearchChatExtensionConfiguration : AzureChatExtensionConfiguration
{
    // CUSTOM CODE NOTE:
    //    These changes facilitate the direct use of the extension "configuration" classes for access to their
    //    constituent "parameter" values. These serialize into a subordinate payload within the wire format
    //    REST structure but don't convey additional semantic meaning, so internalizing parameter types and then
    //    plumbing the configuration through substantially simplifies the experience.

    /// <summary> Initializes a new instance of <see cref="AzureCognitiveSearchChatExtensionConfiguration"/>. </summary>
    public AzureCognitiveSearchChatExtensionConfiguration()
    {
        Type = AzureChatExtensionType.AzureCognitiveSearch;
        Parameters = new AzureCognitiveSearchChatExtensionParameters();
    }

    internal AzureCognitiveSearchChatExtensionParameters Parameters { get; }

    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.Authentication"/>
    public OnYourDataAuthenticationOptions Authentication
    {
        get => Parameters.Authentication;
        set => Parameters.Authentication = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.DocumentCount"/>
    public int? DocumentCount
    {
        get => Parameters.DocumentCount;
        set => Parameters.DocumentCount = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.ShouldRestrictResultScope"/>
    public bool? ShouldRestrictResultScope
    {
        get => Parameters.ShouldRestrictResultScope;
        set => Parameters.ShouldRestrictResultScope = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.Strictness"/>
    public int? Strictness
    {
        get => Parameters.Strictness;
        set => Parameters.Strictness = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => Parameters.RoleInformation;
        set => Parameters.RoleInformation = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.SearchEndpoint"/>
    public Uri SearchEndpoint
    {
        get => Parameters.SearchEndpoint;
        set => Parameters.SearchEndpoint = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.IndexName"/>
    public string IndexName
    {
        get => Parameters.IndexName;
        set => Parameters.IndexName = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.Key"/>
    public string Key
    {
        get => Parameters.Key;
        set => Parameters.Key = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.FieldMappingOptions"/>
    public AzureCognitiveSearchIndexFieldMappingOptions FieldMappingOptions
    {
        get => Parameters.FieldMappingOptions;
        set => Parameters.FieldMappingOptions = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.QueryType"/>
    public AzureCognitiveSearchQueryType? QueryType
    {
        get => Parameters.QueryType;
        set => Parameters.QueryType = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.SemanticConfiguration"/>
    public string SemanticConfiguration
    {
        get => Parameters.SemanticConfiguration;
        set => Parameters.SemanticConfiguration = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.Filter"/>
    public string Filter
    {
        get => Parameters.Filter;
        set => Parameters.Filter = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.EmbeddingEndpoint"/>
    public Uri EmbeddingEndpoint
    {
        get => Parameters.EmbeddingEndpoint;
        set => Parameters.EmbeddingEndpoint = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.EmbeddingKey"/>
    public string EmbeddingKey
    {
        get => Parameters.EmbeddingKey;
        set => Parameters.EmbeddingKey = value;
    }
    /// <inheritdoc cref="AzureCognitiveSearchChatExtensionParameters.EmbeddingDependency"/>
    public OnYourDataVectorizationSource VectorizationSource
    {
        get => Parameters.EmbeddingDependency;
        set => Parameters.EmbeddingDependency = value;
    }
}
