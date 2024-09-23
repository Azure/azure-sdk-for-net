// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("MongoDBChatDataSource")]
public partial class MongoDBChatDataSource : AzureChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalMongoDBChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.Authentication"/>
    required public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        set => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.Endpoint"/>
    required public string EndpointName
    {
        get => InternalParameters.Endpoint;
        set => InternalParameters.Endpoint = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.CollectionName"/>
    required public string CollectionName
    {
        get => InternalParameters.CollectionName;
        set => InternalParameters.CollectionName = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.AppName"/>
    required public string AppName
    {
        get => InternalParameters.AppName;
        set => InternalParameters.AppName = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.IndexName"/>
    required public string IndexName
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
    public bool? AllowPartialResult
    {
        get => InternalParameters.AllowPartialResult;
        set => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalMongoDBChatDataSourceParameters.OutputContextFlags"/>
    public DataSourceOutputContexts? OutputContextFlags
    {
        get => InternalParameters.OutputContextFlags;
        set => InternalParameters.OutputContextFlags = value;
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
    public MongoDBChatDataSource() : base(type: "mongo_db", serializedAdditionalRawData: null)
    {
        InternalParameters = new();
    }

    // CUSTOM: Made internal.
    /// <summary> Initializes a new instance of <see cref="MongoDBChatDataSource"/>. </summary>
    /// <param name="internalParameters"> The parameter information to control the use of the MongoDB data source. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalParameters"/> is null. </exception>
    internal MongoDBChatDataSource(InternalMongoDBChatDataSourceParameters internalParameters)
    {
        Argument.AssertNotNull(internalParameters, nameof(internalParameters));
        InternalParameters = internalParameters;
    }

    /// <summary> Initializes a new instance of <see cref="MongoDBChatDataSource"/>. </summary>
    /// <param name="type"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal MongoDBChatDataSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalMongoDBChatDataSourceParameters internalParameters)
        : base(type, serializedAdditionalRawData)
    {
        InternalParameters = internalParameters;
    }
}
