// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatDataSource")] public abstract partial class AzureChatDataSource { }
[CodeGenModel("AzureChatMessageContextCitation")] public partial class AzureChatCitation { }
[CodeGenModel("AzureChatMessageContextAllRetrievedDocuments")] public partial class AzureChatRetrievedDocument { }
[CodeGenModel("AzureChatMessageContextAllRetrievedDocumentsFilterReason")] public readonly partial struct AzureChatRetrievedDocumentFilterReason { }
[CodeGenModel("AzureChatMessageContext")] public partial class AzureChatMessageContext { }
[CodeGenModel("AzureSearchChatDataSourceParametersQueryType")] public readonly partial struct DataSourceQueryType { }
