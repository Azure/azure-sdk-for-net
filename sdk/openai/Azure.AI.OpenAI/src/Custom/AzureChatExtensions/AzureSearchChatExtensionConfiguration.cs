// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("AzureSearchChatExtensionConfiguration", typeof(AzureSearchChatExtensionParameters))]
public partial class AzureSearchChatExtensionConfiguration : AzureChatExtensionConfiguration
{
    // CUSTOM CODE NOTE:
    //    These changes facilitate the direct use of the extension "configuration" classes for access to their
    //    constituent "parameter" values. These serialize into a subordinate payload within the wire format
    //    REST structure but don't convey additional semantic meaning, so internalizing parameter types and then
    //    plumbing the configuration through substantially simplifies the experience.

    /// <summary> Initializes a new instance of <see cref="AzureSearchChatExtensionConfiguration"/>. </summary>
    public AzureSearchChatExtensionConfiguration()
    {
        Type = AzureChatExtensionType.AzureSearch;
        Parameters = new AzureSearchChatExtensionParameters();
    }

    internal AzureSearchChatExtensionParameters Parameters { get; }

    /// <inheritdoc cref="AzureSearchChatExtensionParameters.Authentication"/>
    public OnYourDataAuthenticationOptions Authentication
    {
        get => Parameters.Authentication;
        set => Parameters.Authentication = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.DocumentCount"/>
    public int? DocumentCount
    {
        get => Parameters.DocumentCount;
        set => Parameters.DocumentCount = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.ShouldRestrictResultScope"/>
    public bool? ShouldRestrictResultScope
    {
        get => Parameters.ShouldRestrictResultScope;
        set => Parameters.ShouldRestrictResultScope = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.Strictness"/>
    public int? Strictness
    {
        get => Parameters.Strictness;
        set => Parameters.Strictness = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => Parameters.RoleInformation;
        set => Parameters.RoleInformation = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.SearchEndpoint"/>
    public Uri SearchEndpoint
    {
        get => Parameters.SearchEndpoint;
        set => Parameters.SearchEndpoint = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.IndexName"/>
    public string IndexName
    {
        get => Parameters.IndexName;
        set => Parameters.IndexName = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.FieldMappingOptions"/>
    public AzureSearchIndexFieldMappingOptions FieldMappingOptions
    {
        get => Parameters.FieldMappingOptions;
        set => Parameters.FieldMappingOptions = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.QueryType"/>
    public AzureSearchQueryType? QueryType
    {
        get => Parameters.QueryType;
        set => Parameters.QueryType = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.SemanticConfiguration"/>
    public string SemanticConfiguration
    {
        get => Parameters.SemanticConfiguration;
        set => Parameters.SemanticConfiguration = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.Filter"/>
    public string Filter
    {
        get => Parameters.Filter;
        set => Parameters.Filter = value;
    }
    /// <inheritdoc cref="AzureSearchChatExtensionParameters.EmbeddingDependency"/>
    public OnYourDataVectorizationSource VectorizationSource
    {
        get => Parameters.EmbeddingDependency;
        set => Parameters.EmbeddingDependency = value;
    }
}
