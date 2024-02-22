// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("AzureCosmosDBChatExtensionConfiguration", typeof(AzureCosmosDBChatExtensionParameters))]
public partial class AzureCosmosDBChatExtensionConfiguration : AzureChatExtensionConfiguration
{
    // CUSTOM CODE NOTE:
    //    These changes facilitate the direct use of the extension "configuration" classes for access to their
    //    constituent "parameter" values. These serialize into a subordinate payload within the wire format
    //    REST structure but don't convey additional semantic meaning, so internalizing parameter types and then
    //    plumbing the configuration through substantially simplifies the experience.

    /// <summary> Initializes a new instance of <see cref="AzureCosmosDBChatExtensionConfiguration"/>. </summary>
    public AzureCosmosDBChatExtensionConfiguration()
    {
        Type = AzureChatExtensionType.AzureCosmosDB;
        Parameters = new AzureCosmosDBChatExtensionParameters();
    }

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
    public OnYourDataVectorizationSource VectorizationSource
    {
        get => Parameters.EmbeddingDependency;
        set => Parameters.EmbeddingDependency = value;
    }
}
