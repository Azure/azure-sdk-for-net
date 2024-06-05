// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureSearchChatDataSourceParametersFieldsMapping")]
public partial class DataSourceFieldMappings
{
    /// <summary>
    /// The name of the index field to use as a title.
    /// </summary>
    [CodeGenMember("TitleField")]
    public string TitleFieldName { get; init;}

    /// <summary>
    /// The name of the index field to use as a URL.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="AzureCosmosDBChatDataSource"/>, <see cref="ElasticsearchChatDataSource"/>, and
    /// <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// <para>
    /// It is not applicable to types including: <see cref="AzureMachineLearningIndexChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("UrlField")]
    public string UrlFieldName { get; init;}

    /// <summary> The name of the index field to use as a filepath. </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="AzureCosmosDBChatDataSource"/>, <see cref="ElasticsearchChatDataSource"/>, and
    /// <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// <para>
    /// It is not applicable to types including: <see cref="AzureMachineLearningIndexChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("FilepathField")]
    public string FilepathFieldName { get; init; }

    /// <summary> The names of index fields that should be treated as content. </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="AzureCosmosDBChatDataSource"/>, <see cref="ElasticsearchChatDataSource"/>, and
    /// <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// <para>
    /// It is not applicable to types including: <see cref="AzureMachineLearningIndexChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("ContentFields")]
    public IList<string> ContentFieldNames { get; } = new ChangeTrackingList<string>();

    /// <summary> The separator pattern that content fields should use. </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="AzureCosmosDBChatDataSource"/>, <see cref="ElasticsearchChatDataSource"/>, and
    /// <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// <para>
    /// It is not applicable to types including: <see cref="AzureMachineLearningIndexChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("ContentFieldsSeparator")]
    public string ContentFieldSeparator { get; init;}

    /// <summary> The names of fields that represent vector data. </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="AzureCosmosDBChatDataSource"/>, and <see cref="ElasticsearchChatDataSource"/>.
    /// </para>
    /// <para>
    /// It is not applicable to types including: <see cref="AzureMachineLearningIndexChatDataSource"/> and
    /// <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("VectorFields")]
    public IList<string> VectorFieldNames { get; } = new ChangeTrackingList<string>();

    /// <summary> The names of fields that represent image vector data. </summary>
    /// <remarks>
    /// This configuration is only applicable to <see cref="AzureSearchChatDataSource"/>.
    /// </remarks>
    [CodeGenMember("ImageVectorFields")]
    public IList<string> ImageVectorFieldNames { get; } = new ChangeTrackingList<string>();

    /// <summary>
    /// Initializes a new instance of <see cref="DataSourceFieldMappings"/>.
    /// </summary>
    public DataSourceFieldMappings()
    {}
}
