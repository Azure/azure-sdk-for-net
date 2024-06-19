// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("PineconeChatDataSource")]
public partial class PineconeChatDataSource : AzureChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalPineconeChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.Environment"/>
    required public string Environment
    {
        get => InternalParameters.Environment;
        init => InternalParameters.Environment = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.IndexName"/>
    required public string IndexName
    {
        get => InternalParameters.IndexName;
        init => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.Authentication"/>
    required public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        init => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.VectorizationSource"/>
    required public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.VectorizationSource;
        init => InternalParameters.VectorizationSource = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.FieldMappings"/>
    required public DataSourceFieldMappings FieldMappings
    {
        get => InternalParameters.FieldMappings;
        init => InternalParameters.FieldMappings = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        init => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        init => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        init => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => InternalParameters.RoleInformation;
        init => InternalParameters.RoleInformation = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        init => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResult
    {
        get => InternalParameters.AllowPartialResult;
        init => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.OutputContextFlags"/>
    public DataSourceOutputContextFlags? OutputContextFlags
    {
        get => InternalParameters.OutputContextFlags;
        init => InternalParameters.OutputContextFlags = value;
    }

    public PineconeChatDataSource()
    {
        Type = "pinecone";
        InternalParameters = new();
        _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
    }

    /// <summary> Initializes a new instance of <see cref="PineconeChatDataSource"/>. </summary>
    /// <param name="type"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal PineconeChatDataSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalPineconeChatDataSourceParameters internalParameters) : base(type, serializedAdditionalRawData)
    {
        InternalParameters = internalParameters;
    }
}
