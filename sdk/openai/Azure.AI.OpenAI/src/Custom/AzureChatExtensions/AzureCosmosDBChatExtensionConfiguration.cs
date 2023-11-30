// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("AzureCosmosDBChatExtensionConfiguration", typeof(AzureCosmosDBChatExtensionParameters))]
public partial class AzureCosmosDBChatExtensionConfiguration : AzureChatExtensionConfiguration
{
    /// <summary> Initializes a new instance of <see cref="AzureCosmosDBChatExtensionConfiguration"/>. </summary>
    public AzureCosmosDBChatExtensionConfiguration()
        : this(AzureChatExtensionType.AzureCosmosDB, new AzureCosmosDBChatExtensionParameters())
    { }

    internal AzureCosmosDBChatExtensionParameters Parameters { get; }

    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.Authentication"/>
    public OnYourDataAuthenticationOptions Authentication
    {
        get => Parameters.Authentication;
        set => Parameters.Authentication = value;
    }
    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.DocumentCount"/>
    public int? DocumentCount
    {
        get => Parameters.DocumentCount;
        set => Parameters.DocumentCount = value;
    }
    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.ShouldRestrictResultScope"/>
    public bool? ShouldRestrictResultScope
    {
        get => Parameters.ShouldRestrictResultScope;
        set => Parameters.ShouldRestrictResultScope = value;
    }
    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.Strictness"/>
    public int? Strictness
    {
        get => Parameters.Strictness;
        set => Parameters.Strictness = value;
    }
    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => Parameters.RoleInformation;
        set => Parameters.RoleInformation = value;
    }
    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.DatabaseName"/>
    public string DatabaseName
    {
        get => Parameters.DatabaseName;
        set => Parameters.DatabaseName = value;
    }
    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.ContainerName"/>
    public string ContainerName
    {
        get => Parameters.ContainerName;
        set => Parameters.ContainerName = value;
    }
    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.IndexName"/>
    public string IndexName
    {
        get => Parameters.IndexName;
        set => Parameters.IndexName = value;
    }
    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.FieldMappingOptions"/>
    public AzureCosmosDBFieldMappingOptions FieldMappingOptions
    {
        get => Parameters.FieldMappingOptions;
        set => Parameters.FieldMappingOptions = value;
    }
    /// <inheritdoc cref="AzureCosmosDBChatExtensionParameters.EmbeddingDependency"/>
    public OnYourDataEmbeddingDependency EmbeddingDependency
    {
        get => Parameters.EmbeddingDependency;
        set => Parameters.EmbeddingDependency = value;
    }
}
