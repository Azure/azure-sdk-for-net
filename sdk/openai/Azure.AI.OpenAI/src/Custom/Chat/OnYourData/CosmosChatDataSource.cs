// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenType("AzureCosmosDBChatDataSource")]
[CodeGenSuppress(nameof(CosmosChatDataSource), typeof(InternalAzureCosmosDBChatDataSourceParameters))]
[Experimental("AOAI001")]
public partial class CosmosChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalAzureCosmosDBChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.ContainerName"/>
    public string ContainerName
    {
        get => InternalParameters.ContainerName;
        set => InternalParameters.ContainerName = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.DatabaseName"/>
    public string DatabaseName
    {
        get => InternalParameters.DatabaseName;
        set => InternalParameters.DatabaseName = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.IndexName"/>
    public string IndexName
    {
        get => InternalParameters.IndexName;
        set => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.Authentication"/>
    public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        set => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.VectorizationSource"/>
    public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.VectorizationSource;
        set => InternalParameters.VectorizationSource = value;
    }

    /// <inheritdoc cref="InternalAzureCosmosDBChatDataSourceParameters.FieldMappings"/>
    public DataSourceFieldMappings FieldMappings
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
    public CosmosChatDataSource() : base(InternalAzureChatDataSourceKind.AzureCosmosDb, null)
    {
        InternalParameters = new();
    }

    /// <summary> Initializes a new instance of <see cref="CosmosChatDataSource"/>. </summary>
    /// <param name="kind"></param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal CosmosChatDataSource(InternalAzureChatDataSourceKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, InternalAzureCosmosDBChatDataSourceParameters internalParameters)
        : base(kind, additionalBinaryDataProperties)
    {
        InternalParameters = internalParameters ?? new();
    }
}
