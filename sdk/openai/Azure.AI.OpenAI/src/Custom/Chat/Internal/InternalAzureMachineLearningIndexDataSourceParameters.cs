// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureMachineLearningIndexChatDataSourceParameters")]
internal partial class InternalAzureMachineLearningIndexChatDataSourceParameters
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
    /// The authentication options to use with the Azure Machine Learning Index data source.
    /// </summary>
    /// <remarks>
    /// Azure Machine Learning Index data sources support any of the following options:
    /// <list type="bullet">
    /// <item><see cref="DataSourceAuthentication.FromAccessToken(string)"/></item>
    /// <item><see cref="DataSourceAuthentication.FromSystemManagedIdentity()"/></item>
    /// <item><see cref="DataSourceAuthentication.FromUserManagedIdentity(string)"/></item>
    /// </list>
    /// </remarks>
    [CodeGenMember("Authentication")]
    public DataSourceAuthentication Authentication { get; set; }
}
