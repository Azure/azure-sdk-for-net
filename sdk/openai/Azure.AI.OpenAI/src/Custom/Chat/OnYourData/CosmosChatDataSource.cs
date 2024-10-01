// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureCosmosDBChatDataSource")]
[Experimental("AOAI001")]
public partial class CosmosChatDataSource : ChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalAzureCosmosDBChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.ContainerName"/>
    required public string ContainerName
    {
        get => InternalParameters.ContainerName;
        set => InternalParameters.ContainerName = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.DatabaseName"/>
    required public string DatabaseName
    {
        get => InternalParameters.DatabaseName;
        set => InternalParameters.DatabaseName = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.IndexName"/>
    required public string IndexName
    {
        get => InternalParameters.IndexName;
        set => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.Authentication"/>
    required public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        set => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.VectorizationSource"/>
    required public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.VectorizationSource;
        set => InternalParameters.VectorizationSource = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.FieldMappings"/>
    required public DataSourceFieldMappings FieldMappings
    {
        get => InternalParameters.FieldMappings;
        set => InternalParameters.FieldMappings = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        set => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        set => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        set => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        set => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResults
    {
        get => InternalParameters.AllowPartialResult;
        set => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.OutputContexts"/>
    public DataSourceOutputContexts? OutputContexts
    {
        get => InternalParameters.OutputContexts;
        set => InternalParameters.OutputContexts = value;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="CosmosChatDataSource"/>.
    /// </summary>
    public CosmosChatDataSource() : base(type: "azure_cosmos_db", serializedAdditionalRawData: null)
    {
        InternalParameters = new();
    }

    // CUSTOM: Made internal.
    /// <summary> Initializes a new instance of <see cref="CosmosChatDataSource"/>. </summary>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure CosmosDB data source. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalParameters"/> is null. </exception>
    internal CosmosChatDataSource(InternalAzureCosmosDBChatDataSourceParameters internalParameters) : this()
    {
        Argument.AssertNotNull(internalParameters, nameof(internalParameters));
        InternalParameters = internalParameters;
    }

    /// <summary> Initializes a new instance of <see cref="CosmosChatDataSource"/>. </summary>
    /// <param name="type"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal CosmosChatDataSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalAzureCosmosDBChatDataSourceParameters internalParameters)
        : base(type, serializedAdditionalRawData)
    {
        InternalParameters = internalParameters;
    }
}
