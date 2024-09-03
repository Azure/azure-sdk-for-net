// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureMachineLearningIndexChatDataSource")]
public partial class AzureMachineLearningIndexChatDataSource : AzureChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalAzureMachineLearningIndexChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.Name"/>
    required public string IndexName
    {
        get => InternalParameters.Name;
        init => InternalParameters.Name = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.ProjectResourceId"/>
    required public string ProjectResourceId
    {
        get => InternalParameters.ProjectResourceId;
        init => InternalParameters.ProjectResourceId = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.Authentication"/>
    required public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        init => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.Version"/>
    required public string Version
    {
        get => InternalParameters.Version;
        init => InternalParameters.Version = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        init => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        init => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        init => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => InternalParameters.RoleInformation;
        init => InternalParameters.RoleInformation = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        init => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResult
    {
        get => InternalParameters.AllowPartialResult;
        init => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.OutputContextFlags"/>
    public DataSourceOutputContextFlags? OutputContextFlags
    {
        get => InternalParameters.OutputContextFlags;
        init => InternalParameters.OutputContextFlags = value;
    }

    /// <inheritdoc cref="InternalAzureMachineLearningIndexChatDataSourceParameters.Filter"/>
    public string Filter
    {
        get => InternalParameters.Filter;
        init => InternalParameters.Filter = value;
    }

    /// <summary>
    /// Creates a new instance of <see cref="AzureMachineLearningIndexChatDataSource"/>.
    /// </summary>
    public AzureMachineLearningIndexChatDataSource() : base(type: "azure_ml_index", serializedAdditionalRawData: null)
    {
        InternalParameters = new();
    }

    // CUSTOM: Made internal.
    /// <summary> Initializes a new instance of <see cref="AzureMachineLearningIndexChatDataSource"/>. </summary>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Machine Learning Index data source. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalParameters"/> is null. </exception>
    internal AzureMachineLearningIndexChatDataSource(InternalAzureMachineLearningIndexChatDataSourceParameters internalParameters)
    {
        Argument.AssertNotNull(internalParameters, nameof(internalParameters));
        InternalParameters = internalParameters;
    }

    /// <summary> Initializes a new instance of <see cref="AzureMachineLearningIndexChatDataSource"/>. </summary>
    /// <param name="type"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal AzureMachineLearningIndexChatDataSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalAzureMachineLearningIndexChatDataSourceParameters internalParameters)
        : base(type, serializedAdditionalRawData)
    {
        InternalParameters = internalParameters;
    }
}
