// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("ElasticsearchChatDataSource")]
[Experimental("AOAI001")]
#if AZURE_OPENAI_GA
[EditorBrowsable(EditorBrowsableState.Never)]
#endif
public partial class ElasticsearchChatDataSource : ChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalElasticsearchChatDataSourceParameters InternalParameters { get; }

#if !AZURE_OPENAI_GA

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.Endpoint"/>
    required public Uri Endpoint
    {
        get => InternalParameters.Endpoint;
        set => InternalParameters.Endpoint = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.IndexName"/>
    required public string IndexName
    {
        get => InternalParameters.IndexName;
        set => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.Authentication"/>
    required public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        set => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        set => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        set => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        set => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        set => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResults
    {
        get => InternalParameters.AllowPartialResult;
        set => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.OutputContexts"/>
    public DataSourceOutputContexts? OutputContexts
    {
        get => InternalParameters.OutputContexts;
        set => InternalParameters.OutputContexts = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.FieldMappings"/>
    public DataSourceFieldMappings FieldMappings
    {
        get => InternalParameters.FieldMappings;
        set => InternalParameters.FieldMappings = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.QueryType"/>
    public DataSourceQueryType? QueryType
    {
        get => InternalParameters.QueryType;
        set => InternalParameters.QueryType = value;
    }

    /// <inheritdoc cref="InternalElasticsearchChatDataSourceParameters.VectorizationSource"/>
    public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.VectorizationSource;
        set => InternalParameters.VectorizationSource = value;
    }

    public ElasticsearchChatDataSource() : base(type: "elasticsearch", serializedAdditionalRawData: null)
    {
        InternalParameters = new();
    }

#else
    public ElasticsearchChatDataSource()
    {
        throw new InvalidOperationException($"Elasticsearch data sources are not supported in this GA version. Please use a preview library and service version for this integration.");
    }
#endif

    // CUSTOM: Made internal.
    /// <summary> Initializes a new instance of <see cref="ElasticsearchChatDataSource"/>. </summary>
    /// <param name="internalParameters"> The parameter information to control the use of the Elasticsearch data source. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalParameters"/> is null. </exception>
    internal ElasticsearchChatDataSource(InternalElasticsearchChatDataSourceParameters internalParameters)
        : this()
    {
        Argument.AssertNotNull(internalParameters, nameof(internalParameters));
        InternalParameters = internalParameters;
    }

    /// <summary> Initializes a new instance of <see cref="ElasticsearchChatDataSource"/>. </summary>
    /// <param name="type"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal ElasticsearchChatDataSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalElasticsearchChatDataSourceParameters internalParameters)
        : base(type, serializedAdditionalRawData)
    {
        InternalParameters = internalParameters;
    }
}