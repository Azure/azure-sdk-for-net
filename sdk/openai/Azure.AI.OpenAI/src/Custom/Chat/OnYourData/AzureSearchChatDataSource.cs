// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureSearchChatDataSource")]
public partial class AzureSearchChatDataSource : AzureChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalAzureSearchChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Endpoint"/>
    required public Uri Endpoint
    {
        get => InternalParameters.Endpoint;
        init => InternalParameters.Endpoint = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.IndexName"/>
    required public string IndexName
    {
        get => InternalParameters.IndexName;
        init => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Authentication"/>
    required public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        init => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        init => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        init => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        init => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => InternalParameters.RoleInformation;
        init => InternalParameters.RoleInformation = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        init => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResult
    {
        get => InternalParameters.AllowPartialResult;
        init => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.OutputContextFlags"/>
    public DataSourceOutputContextFlags? OutputContextFlags
    {
        get => InternalParameters.OutputContextFlags;
        init => InternalParameters.OutputContextFlags = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.FieldMappings"/>
    public DataSourceFieldMappings FieldMappings
    {
        get => InternalParameters.FieldMappings;
        init => InternalParameters.FieldMappings = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.QueryType"/>
    public DataSourceQueryType? QueryType
    {
        get => InternalParameters.QueryType;
        init => InternalParameters.QueryType = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.SemanticConfiguration"/>
    public string SemanticConfiguration
    {
        get => InternalParameters.SemanticConfiguration;
        init => InternalParameters.SemanticConfiguration = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Filter"/>
    public string Filter
    {
        get => InternalParameters.Filter;
        init => InternalParameters.Filter = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.VectorizationSource"/>
    public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.VectorizationSource;
        init => InternalParameters.VectorizationSource = value;
    }

    /// <summary>
    /// Creates a new instance of <see cref="AzureSearchChatDataSource"/>.
    /// </summary>
    public AzureSearchChatDataSource() : base(type: "azure_search", serializedAdditionalRawData: null)
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
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal AzureSearchChatDataSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalAzureSearchChatDataSourceParameters internalParameters)
        : base(type, serializedAdditionalRawData)
    {
        InternalParameters = internalParameters;
    }
}
