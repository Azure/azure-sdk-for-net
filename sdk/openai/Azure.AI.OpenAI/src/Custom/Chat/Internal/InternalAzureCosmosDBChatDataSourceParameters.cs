// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureCosmosDBChatDataSourceParameters")]
internal partial class InternalAzureCosmosDBChatDataSourceParameters
{
    [CodeGenMember("IncludeContexts")]
    private IList<string> _internalIncludeContexts = new ChangeTrackingList<string>();
    private DataSourceOutputContextFlags? _outputContextFlags;

    /// <inheritdoc cref="DataSourceOutputContextFlags"/>
    public DataSourceOutputContextFlags? OutputContextFlags
    {
        get => DataSourceOutputContextFlagsExtensions.FromStringList(_internalIncludeContexts);
        internal set
        {
            _outputContextFlags = value;
            _internalIncludeContexts = _outputContextFlags?.ToStringList();
        }
    }

    /// <summary>
    /// The authentication options to use with the Azure CosmosDB data source.
    /// </summary>
    /// <remarks>
    /// Azure CosmosDB data sources support any of the following options:
    /// <list type="bullet">
    /// <item><see cref="DataSourceAuthentication.FromConnectionString(string)"/></item>
    /// </list>
    /// </remarks>
    [CodeGenMember("Authentication")]
    public DataSourceAuthentication Authentication { get; set; }

    /// <summary> Gets the index field mappings. </summary>
    /// <remarks>
    /// Supported field mappings for Elasticsearch data sources include:
    /// <list type="bullet">
    /// <item><see cref="DataSourceFieldMappings.VectorFieldNames"/> -- Required</item>
    /// <item><see cref="DataSourceFieldMappings.ContentFieldNames"/> -- Required</item>
    /// <item><see cref="DataSourceFieldMappings.ContentFieldSeparator"/></item>
    /// <item><see cref="DataSourceFieldMappings.TitleFieldName"/></item>
    /// <item><see cref="DataSourceFieldMappings.UrlFieldName"/></item>
    /// <item><see cref="DataSourceFieldMappings.FilepathFieldName"/></item>
    /// </list>
    /// </remarks>
    [CodeGenMember("FieldsMapping")]
    public DataSourceFieldMappings FieldMappings { get; set; }

    /// <summary>
    /// The vectorization dependency used for embeddings.
    /// </summary>
    /// <remarks>
    /// Supported vectorization dependencies for Azure CosmosDB data sources include:
    /// <list type="bullet">
    /// <item><see cref="DataSourceVectorizer.FromEndpoint(Uri, DataSourceAuthentication)"/></item>
    /// <item><see cref="DataSourceVectorizer.FromDeploymentName(string)"/></item>
    /// </list>
    /// </remarks>
    [CodeGenMember("EmbeddingDependency")]
    public DataSourceVectorizer VectorizationSource { get; set; }
}
