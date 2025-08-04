// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenType("PineconeChatDataSource")]
[CodeGenSuppress(nameof(CosmosChatDataSource), typeof(InternalPineconeChatDataSourceParameters))]
[Experimental("AOAI001")]
#if AZURE_OPENAI_GA
[EditorBrowsable(EditorBrowsableState.Never)]
#endif
public partial class PineconeChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalPineconeChatDataSourceParameters InternalParameters { get; }

#if !AZURE_OPENAI_GA

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.Environment"/>
    public string Environment
    {
        get => InternalParameters.Environment;
        set => InternalParameters.Environment = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.IndexName"/>
    public string IndexName
    {
        get => InternalParameters.IndexName;
        set => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.Authentication"/>
    public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        set => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.VectorizationSource"/>
    public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.VectorizationSource;
        set => InternalParameters.VectorizationSource = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.FieldMappings"/>
    public DataSourceFieldMappings FieldMappings
    {
        get => InternalParameters.FieldMappings;
        set => InternalParameters.FieldMappings = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        set => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        set => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        set => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        set => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResults
    {
        get => InternalParameters.AllowPartialResult;
        set => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.OutputContexts"/>
    public DataSourceOutputContexts? OutputContexts
    {
        get => InternalParameters.OutputContexts;
        set => InternalParameters.OutputContexts = value;
    }

    /// <summary>
    /// Creates a new instance of <see cref="PineconeChatDataSource"/>.
    /// </summary>
    public PineconeChatDataSource() : base(InternalAzureChatDataSourceKind.Pinecone, null)
    {
        InternalParameters = new();
    }
#else
    public PineconeChatDataSource()
    {
        throw new InvalidOperationException($"Pinecone data sources are not supported in this GA version. Please use a preview library and service version for this integration.");
    }
#endif

    /// <summary> Initializes a new instance of <see cref="PineconeChatDataSource"/>. </summary>
    /// <param name="kind"></param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal PineconeChatDataSource(InternalAzureChatDataSourceKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, InternalPineconeChatDataSourceParameters internalParameters)
        : base(kind, additionalBinaryDataProperties)
    {
        InternalParameters = internalParameters ?? new();
    }
}