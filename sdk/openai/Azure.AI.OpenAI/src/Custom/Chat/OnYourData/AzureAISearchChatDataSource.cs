// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenType("AzureSearchChatDataSource")]
[Experimental("AOAI001")]
public partial class AzureSearchChatDataSource : ChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalAzureSearchChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Endpoint"/>
    required public Uri Endpoint
    {
        get => InternalParameters.Endpoint;
        set => InternalParameters.Endpoint = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.IndexName"/>
    required public string IndexName
    {
        get => InternalParameters.IndexName;
        set => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Authentication"/>
    required public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        set => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        set => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        set => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        set => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        set => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResults
    {
        get => InternalParameters.AllowPartialResult;
        set => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.OutputContexts"/>
    public DataSourceOutputContexts? OutputContexts
    {
        get => InternalParameters.OutputContexts;
        set => InternalParameters.OutputContexts = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.FieldMappings"/>
    public DataSourceFieldMappings FieldMappings
    {
        get => InternalParameters.FieldMappings;
        set => InternalParameters.FieldMappings = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.QueryType"/>
    public DataSourceQueryType? QueryType
    {
        get => InternalParameters.QueryType;
        set => InternalParameters.QueryType = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.SemanticConfiguration"/>
    public string SemanticConfiguration
    {
        get => InternalParameters.SemanticConfiguration;
        set => InternalParameters.SemanticConfiguration = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Filter"/>
    public string Filter
    {
        get => InternalParameters.Filter;
        set => InternalParameters.Filter = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.VectorizationSource"/>
    public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.VectorizationSource;
        set => InternalParameters.VectorizationSource = value;
    }

    /// <summary>
    /// Creates a new instance of <see cref="AzureSearchChatDataSource"/>.
    /// </summary>
    public AzureSearchChatDataSource() : base(type: "azure_search", additionalBinaryDataProperties: null)
    {
        InternalParameters = new();
    }

    // CUSTOM: Made internal.
    /// <summary> Initializes a new instance of <see cref="AzureSearchChatDataSource"/>. </summary>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalParameters"/> is null. </exception>
    internal AzureSearchChatDataSource(InternalAzureSearchChatDataSourceParameters internalParameters) : this()
    {
        Argument.AssertNotNull(internalParameters, nameof(internalParameters));
        InternalParameters = internalParameters;
    }

    /// <summary> Initializes a new instance of <see cref="AzureSearchChatDataSource"/>. </summary>
    /// <param name="type"></param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal AzureSearchChatDataSource(string type, IDictionary<string, BinaryData> additionalBinaryDataProperties, InternalAzureSearchChatDataSourceParameters internalParameters)
        : base(type, additionalBinaryDataProperties)
    {
        InternalParameters = internalParameters;
    }
}
