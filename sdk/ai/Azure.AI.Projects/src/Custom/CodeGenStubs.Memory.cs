// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Memory;

[CodeGenType("ChatSummaryMemoryItem")] public partial class ChatSummaryMemoryItem { }
[CodeGenType("DeleteMemoryStoreResponse")] public partial class DeleteMemoryStoreResponse { }
[CodeGenType("DeleteScopeRequest")] internal partial class DeleteScopeRequest { }
[CodeGenType("MemoryItem")] public abstract partial class MemoryItem { }
[CodeGenType("MemoryItemKind")] public readonly partial struct MemoryItemKind { }
[CodeGenType("MemoryOperation")] public partial class MemoryOperation { }
[CodeGenType("MemoryOperationKind")] public readonly partial struct MemoryOperationKind { }
[CodeGenType("MemorySearchItem")] public partial class MemorySearchItem { }
[CodeGenType("MemorySearchResultOptions")] public partial class MemorySearchResultOptions { }
[CodeGenType("MemoryStoreDefaultDefinition")] public partial class MemoryStoreDefaultDefinition { }
[CodeGenType("MemoryStoreDefaultOptions")] public partial class MemoryStoreDefaultOptions { }
[CodeGenType("MemoryStoreDefinition")] public abstract partial class MemoryStoreDefinition { }
[CodeGenType("MemoryStoreDeleteScopeResponse")] public partial class MemoryStoreDeleteScopeResponse { }
[CodeGenType("MemoryDeletionResult")] public partial class MemoryDeletionResult { }
[CodeGenType("MemoryStoreKind")] internal readonly partial struct MemoryStoreKind { }
[CodeGenType("MemoryStoreObjectType")] public readonly partial struct MemoryStoreObjectType { }
[CodeGenType("MemoryStoreOperationUsage")] public partial class MemoryStoreOperationUsage { }
/// <summary> Token usage details for the input portion of a memory-store operation. </summary>
[CodeGenType("MemoryStoreOperationUsageInputTokensDetails")] public partial class MemoryStoreOperationUsageInputTokensDetails { }
/// <summary> Token usage details for the output portion of a memory-store operation. </summary>
[CodeGenType("MemoryStoreOperationUsageOutputTokensDetails")] public partial class MemoryStoreOperationUsageOutputTokensDetails { }
[CodeGenType("MemoryStoreSearchResponse")] public partial class MemoryStoreSearchResponse { }
[CodeGenType("MemoryUpdateResultDetails")] public partial class MemoryUpdateResultDetails { }
[CodeGenType("UnknownMemoryItem")] internal partial class UnknownMemoryItem { }
[CodeGenType("UnknownMemoryStoreDefinition")] internal partial class UnknownMemoryStoreDefinition { }
[CodeGenType("UpdateMemoryStoreRequest")] internal partial class UpdateMemoryStoreRequest { }
[CodeGenType("UserProfileMemoryItem")] public partial class UserProfileMemoryItem { }
// Internal experimental classes
[CodeGenType("AIProjectMemoryStoresGetMemoriesAsyncCollectionResult")][Experimental("AAIP001")] internal partial class AIProjectMemoryStoresGetMemoriesAsyncCollectionResult { }
[CodeGenType("AIProjectMemoryStoresGetMemoriesCollectionResult")][Experimental("AAIP001")] internal partial class AIProjectMemoryStoresGetMemoriesCollectionResult { }
