// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenType("MongoDBChatDataSource")]
[CodeGenSuppress(nameof(MongoDBChatDataSource), typeof(InternalMongoDBChatDataSourceParameters))]
[Experimental("AOAI001")]
#if AZURE_OPENAI_GA
[EditorBrowsable(EditorBrowsableState.Never)]
#endif
public partial class MongoDBChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalMongoDBChatDataSourceParameters InternalParameters { get; }

#if !AZURE_OPENAI_GA
    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.Authentication"/>
    public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        set => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.Endpoint"/>
    public string EndpointName
    {
        get => InternalParameters.Endpoint;
        set => InternalParameters.Endpoint = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.CollectionName"/>
    public string CollectionName
    {
        get => InternalParameters.CollectionName;
        set => InternalParameters.CollectionName = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.AppName"/>
    public string AppName
    {
        get => InternalParameters.AppName;
        set => InternalParameters.AppName = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.IndexName"/>
    public string IndexName
    {
        get => InternalParameters.IndexName;
        set => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        set => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        set => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        set => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        set => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResults
    {
        get => InternalParameters.AllowPartialResult;
        set => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.OutputContexts"/>
    public DataSourceOutputContexts? OutputContexts
    {
        get => InternalParameters.OutputContexts;
        set => InternalParameters.OutputContexts = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.VectorizationSource"/>
    public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.EmbeddingDependency;
        set => InternalParameters.EmbeddingDependency = value;
    }

    /// <summary>
    /// Creates a new instance of <see cref="MongoDBChatDataSource"/>.
    /// </summary>
    public MongoDBChatDataSource() : base(InternalAzureChatDataSourceKind.MongoDb, null)
    {
        InternalParameters = new();
    }
#else
    public MongoDBChatDataSource()
    {
        throw new InvalidOperationException($"MongoDB data sources are not supported in this GA version. Please use a preview library and service version for this integration.");
    }
#endif

    /// <summary> Initializes a new instance of <see cref="MongoDBChatDataSource"/>. </summary>
    /// <param name="kind"></param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal MongoDBChatDataSource(InternalAzureChatDataSourceKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, InternalMongoDBChatDataSourceParameters internalParameters)
        : base(kind, additionalBinaryDataProperties)
    {
        InternalParameters = internalParameters ?? new();
    }
}
