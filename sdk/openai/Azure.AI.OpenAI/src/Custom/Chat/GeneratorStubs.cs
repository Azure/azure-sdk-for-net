// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatDataSource")] public abstract partial class AzureChatDataSource { }
[CodeGenModel("AzureChatMessageContextCitation")] public partial class AzureChatCitation { }
[CodeGenModel("AzureChatMessageContextAllRetrievedDocuments")] public partial class AzureChatRetrievedDocument { }
[CodeGenModel("AzureChatMessageContext")] public partial class AzureChatMessageContext { }
[CodeGenModel("InternalAzureSearchChatDataSourceParametersQueryType")] public readonly partial struct DataSourceQueryType { }
[CodeGenModel("AzureChatRetrievedDocumentFilterReason")] public readonly partial struct AzureChatRetrievedDocumentFilterReason { }
