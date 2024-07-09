// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureCosmosDBChatDataSource")]
public partial class AzureCosmosDBChatDataSource : AzureChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalAzureCosmosDBChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.ContainerName"/>
    required public string ContainerName
    {
        get => InternalParameters.ContainerName;
        init => InternalParameters.ContainerName = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.DatabaseName"/>
    required public string DatabaseName
    {
        get => InternalParameters.DatabaseName;
        init => InternalParameters.DatabaseName = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.IndexName"/>
    required public string IndexName
    {
        get => InternalParameters.IndexName;
        init => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.Authentication"/>
    required public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        init => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.VectorizationSource"/>
    required public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.VectorizationSource;
        init => InternalParameters.VectorizationSource = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.FieldMappings"/>
    required public DataSourceFieldMappings FieldMappings
    {
        get => InternalParameters.FieldMappings;
        init => InternalParameters.FieldMappings = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        init => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        init => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        init => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => InternalParameters.RoleInformation;
        init => InternalParameters.RoleInformation = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        init => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResult
    {
        get => InternalParameters.AllowPartialResult;
        init => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.OutputContextFlags"/>
    public DataSourceOutputContextFlags? OutputContextFlags
    {
        get => InternalParameters.OutputContextFlags;
        init => InternalParameters.OutputContextFlags = value;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="AzureCosmosDBChatDataSource"/>.
    /// </summary>
    public AzureCosmosDBChatDataSource()
    {
        Type = "azure_cosmos_db";
        InternalParameters = new();
        _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
    }

    /// <summary> Initializes a new instance of <see cref="AzureCosmosDBChatDataSource"/>. </summary>
    /// <param name="type"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal AzureCosmosDBChatDataSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalAzureCosmosDBChatDataSourceParameters internalParameters) : base(type, serializedAdditionalRawData)
    {
        InternalParameters = internalParameters;
    }
}
