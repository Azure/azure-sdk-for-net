// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenType("AzureSearchChatDataSourceParametersFieldsMapping")]
[Experimental("AOAI001")]
public partial class DataSourceFieldMappings
{
    /// <summary>
    /// The name of the index field to use as a title.
    /// </summary>
    [CodeGenMember("TitleField")]
    public string TitleFieldName { get; set;}

    /// <summary>
    /// The name of the index field to use as a URL.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="CosmosChatDataSource"/>, <see cref="ElasticsearchChatDataSource"/>, and
    /// <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("UrlField")]
    public string UrlFieldName { get; set;}

    /// <summary> The name of the index field to use as a filepath. </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="CosmosChatDataSource"/>, <see cref="ElasticsearchChatDataSource"/>, and
    /// <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("FilepathField")]
    public string FilePathFieldName { get; set; }

    /// <summary> The names of index fields that should be treated as content. </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="CosmosChatDataSource"/>, <see cref="ElasticsearchChatDataSource"/>, and
    /// <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("ContentFields")]
    public IList<string> ContentFieldNames { get; }

    /// <summary> The separator pattern that content fields should use. </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="CosmosChatDataSource"/>, <see cref="ElasticsearchChatDataSource"/>, and
    /// <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("ContentFieldsSeparator")]
    public string ContentFieldSeparator { get; set;}

    /// <summary> The names of fields that represent vector data. </summary>
    /// <remarks>
    /// <para>
    /// This field is applicable to data source types including: <see cref="AzureSearchChatDataSource"/>,
    /// <see cref="CosmosChatDataSource"/>, and <see cref="ElasticsearchChatDataSource"/>.
    /// </para>
    /// <para>
    /// It is not applicable to types including: <see cref="PineconeChatDataSource"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("VectorFields")]
    public IList<string> VectorFieldNames { get; }

    /// <summary> The names of fields that represent image vector data. </summary>
    /// <remarks>
    /// This configuration is only applicable to <see cref="AzureSearchChatDataSource"/>.
    /// </remarks>
    [CodeGenMember("ImageVectorFields")]
    public IList<string> ImageVectorFieldNames { get; }
}
