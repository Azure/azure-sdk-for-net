// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat shims: The generated model factory was renamed from
// PersistentAgentsModelFactory to AgentsPersistentModelFactory.
// These methods restore the old API surface on PersistentAgentsModelFactory
// by delegating to the new generated factory class.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.AI.Agents.Persistent
{
    public static partial class PersistentAgentsModelFactory
    {
        // ── Methods with IDENTICAL parameter types ────────────────────────────
        // These simply forward to AgentsPersistentModelFactory.

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AISearchIndexResource AISearchIndexResource(string indexConnectionId = default, string indexName = default, AzureAISearchQueryType? queryType = default, int? topK = default, string filter = default, string indexAssetId = default)
            => AgentsPersistentModelFactory.AISearchIndexResource(indexConnectionId, indexName, queryType, topK, filter, indexAssetId);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IncompleteRunDetails IncompleteRunDetails(IncompleteDetailsReason reason = default)
            => AgentsPersistentModelFactory.IncompleteRunDetails(reason);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDelta MessageDelta(MessageRole role = default, IEnumerable<MessageDeltaContent> content = default)
            => AgentsPersistentModelFactory.MessageDelta(role, content);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaContent MessageDeltaContent(int index = default, string type = default)
            => AgentsPersistentModelFactory.MessageDeltaContent(index, type);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaImageFileContent MessageDeltaImageFileContent(int index = default, MessageDeltaImageFileContentObject imageFile = default)
            => AgentsPersistentModelFactory.MessageDeltaImageFileContent(index, imageFile);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaImageFileContentObject MessageDeltaImageFileContentObject(string fileId = default)
            => AgentsPersistentModelFactory.MessageDeltaImageFileContentObject(fileId);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaTextAnnotation MessageDeltaTextAnnotation(int index = default, string type = default)
            => AgentsPersistentModelFactory.MessageDeltaTextAnnotation(index, type);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaTextContent MessageDeltaTextContent(int index = default, MessageDeltaTextContentObject text = default)
            => AgentsPersistentModelFactory.MessageDeltaTextContent(index, text);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaTextContentObject MessageDeltaTextContentObject(string value = default, IEnumerable<MessageDeltaTextAnnotation> annotations = default)
            => AgentsPersistentModelFactory.MessageDeltaTextContentObject(value, annotations);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaTextFileCitationAnnotation MessageDeltaTextFileCitationAnnotation(int index = default, MessageDeltaTextFileCitationAnnotationObject fileCitation = default, string text = default, int? startIndex = default, int? endIndex = default)
            => AgentsPersistentModelFactory.MessageDeltaTextFileCitationAnnotation(index, fileCitation, text, startIndex, endIndex);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaTextFileCitationAnnotationObject MessageDeltaTextFileCitationAnnotationObject(string fileId = default, string quote = default)
            => AgentsPersistentModelFactory.MessageDeltaTextFileCitationAnnotationObject(fileId, quote);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaTextFilePathAnnotation MessageDeltaTextFilePathAnnotation(int index = default, MessageDeltaTextFilePathAnnotationObject filePath = default, int? startIndex = default, int? endIndex = default, string text = default)
            => AgentsPersistentModelFactory.MessageDeltaTextFilePathAnnotation(index, filePath, startIndex, endIndex, text);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaTextFilePathAnnotationObject MessageDeltaTextFilePathAnnotationObject(string fileId = default)
            => AgentsPersistentModelFactory.MessageDeltaTextFilePathAnnotationObject(fileId);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaTextUriCitationAnnotation MessageDeltaTextUriCitationAnnotation(int index = default, MessageDeltaTextUriCitationDetails uriCitation = default, int? startIndex = default, int? endIndex = default)
            => AgentsPersistentModelFactory.MessageDeltaTextUriCitationAnnotation(index, uriCitation, startIndex, endIndex);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaTextUriCitationDetails MessageDeltaTextUriCitationDetails(string uri = default, string title = default)
            => AgentsPersistentModelFactory.MessageDeltaTextUriCitationDetails(uri, title);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageImageFileParam MessageImageFileParam(string fileId = default, ImageDetailLevel? detail = default)
            => AgentsPersistentModelFactory.MessageImageFileParam(fileId, detail);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageImageUriParam MessageImageUriParam(string uri = default, ImageDetailLevel? detail = default)
            => AgentsPersistentModelFactory.MessageImageUriParam(uri, detail);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageIncompleteDetails MessageIncompleteDetails(MessageIncompleteDetailsReason reason = default)
            => AgentsPersistentModelFactory.MessageIncompleteDetails(reason);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageInputImageFileBlock MessageInputImageFileBlock(MessageImageFileParam imageFile = default)
            => AgentsPersistentModelFactory.MessageInputImageFileBlock(imageFile);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageInputImageUriBlock MessageInputImageUriBlock(MessageImageUriParam imageUrl = default)
            => AgentsPersistentModelFactory.MessageInputImageUriBlock(imageUrl);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageInputTextBlock MessageInputTextBlock(string text = default)
            => AgentsPersistentModelFactory.MessageInputTextBlock(text);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTextAnnotation MessageTextAnnotation(string type = default, string text = default)
            => AgentsPersistentModelFactory.MessageTextAnnotation(type, text);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTextUriCitationAnnotation MessageTextUriCitationAnnotation(string text = default, MessageTextUriCitationDetails uriCitation = default, int? startIndex = default, int? endIndex = default)
            => AgentsPersistentModelFactory.MessageTextUriCitationAnnotation(text, uriCitation, startIndex, endIndex);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTextUriCitationDetails MessageTextUriCitationDetails(string uri = default, string title = default)
            => AgentsPersistentModelFactory.MessageTextUriCitationDetails(uri, title);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RequiredToolCall RequiredToolCall(string type = default, string id = default)
            => AgentsPersistentModelFactory.RequiredToolCall(type, id);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunCompletionUsage RunCompletionUsage(long completionTokens = default, long promptTokens = default, long totalTokens = default)
            => AgentsPersistentModelFactory.RunCompletionUsage(completionTokens, promptTokens, totalTokens);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunError RunError(string code = default, string message = default)
            => AgentsPersistentModelFactory.RunError(code, message);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepAzureAISearchToolCall RunStepAzureAISearchToolCall(string id = default, IReadOnlyDictionary<string, string> azureAISearch = default)
            => AgentsPersistentModelFactory.RunStepAzureAISearchToolCall(id, azureAISearch);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepBingGroundingToolCall RunStepBingGroundingToolCall(string id = default, IReadOnlyDictionary<string, string> bingGrounding = default)
            => AgentsPersistentModelFactory.RunStepBingGroundingToolCall(id, bingGrounding);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepCodeInterpreterImageOutput RunStepCodeInterpreterImageOutput(RunStepCodeInterpreterImageReference image = default)
            => AgentsPersistentModelFactory.RunStepCodeInterpreterImageOutput(image);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepCodeInterpreterImageReference RunStepCodeInterpreterImageReference(string fileId = default)
            => AgentsPersistentModelFactory.RunStepCodeInterpreterImageReference(fileId);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepCodeInterpreterLogOutput RunStepCodeInterpreterLogOutput(string logs = default)
            => AgentsPersistentModelFactory.RunStepCodeInterpreterLogOutput(logs);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepCompletionUsage RunStepCompletionUsage(long completionTokens = default, long promptTokens = default, long totalTokens = default)
            => AgentsPersistentModelFactory.RunStepCompletionUsage(completionTokens, promptTokens, totalTokens);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDelta RunStepDelta(RunStepDeltaDetail stepDetails = default)
            => AgentsPersistentModelFactory.RunStepDelta(stepDetails);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaCodeInterpreterDetailItemObject RunStepDeltaCodeInterpreterDetailItemObject(string input = default, IEnumerable<RunStepDeltaCodeInterpreterOutput> outputs = default)
            => AgentsPersistentModelFactory.RunStepDeltaCodeInterpreterDetailItemObject(input, outputs);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaCodeInterpreterImageOutput RunStepDeltaCodeInterpreterImageOutput(int index = default, RunStepDeltaCodeInterpreterImageOutputObject image = default)
            => AgentsPersistentModelFactory.RunStepDeltaCodeInterpreterImageOutput(index, image);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaCodeInterpreterImageOutputObject RunStepDeltaCodeInterpreterImageOutputObject(string fileId = default)
            => AgentsPersistentModelFactory.RunStepDeltaCodeInterpreterImageOutputObject(fileId);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaCodeInterpreterLogOutput RunStepDeltaCodeInterpreterLogOutput(int index = default, string logs = default)
            => AgentsPersistentModelFactory.RunStepDeltaCodeInterpreterLogOutput(index, logs);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaCodeInterpreterOutput RunStepDeltaCodeInterpreterOutput(int index = default, string type = default)
            => AgentsPersistentModelFactory.RunStepDeltaCodeInterpreterOutput(index, type);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaCodeInterpreterToolCall RunStepDeltaCodeInterpreterToolCall(int index = default, string id = default, RunStepDeltaCodeInterpreterDetailItemObject codeInterpreter = default)
            => AgentsPersistentModelFactory.RunStepDeltaCodeInterpreterToolCall(index, id, codeInterpreter);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaFileSearchToolCall RunStepDeltaFileSearchToolCall(int index = default, string id = default, RunStepFileSearchToolCallResults fileSearch = default)
            => AgentsPersistentModelFactory.RunStepDeltaFileSearchToolCall(index, id, fileSearch);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaFunction RunStepDeltaFunction(string name = default, string arguments = default, string output = default)
            => AgentsPersistentModelFactory.RunStepDeltaFunction(name, arguments, output);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaFunctionToolCall RunStepDeltaFunctionToolCall(int index = default, string id = default, RunStepDeltaFunction function = default)
            => AgentsPersistentModelFactory.RunStepDeltaFunctionToolCall(index, id, function);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaMessageCreation RunStepDeltaMessageCreation(RunStepDeltaMessageCreationObject messageCreation = default)
            => AgentsPersistentModelFactory.RunStepDeltaMessageCreation(messageCreation);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaMessageCreationObject RunStepDeltaMessageCreationObject(string messageId = default)
            => AgentsPersistentModelFactory.RunStepDeltaMessageCreationObject(messageId);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaToolCall RunStepDeltaToolCall(int index = default, string id = default, string type = default)
            => AgentsPersistentModelFactory.RunStepDeltaToolCall(index, id, type);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaToolCallObject RunStepDeltaToolCallObject(IEnumerable<RunStepDeltaToolCall> toolCalls = default)
            => AgentsPersistentModelFactory.RunStepDeltaToolCallObject(toolCalls);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepError RunStepError(RunStepErrorCode code = default, string message = default)
            => AgentsPersistentModelFactory.RunStepError(code, message);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepFileSearchToolCall RunStepFileSearchToolCall(string id = default, RunStepFileSearchToolCallResults fileSearch = default)
            => AgentsPersistentModelFactory.RunStepFileSearchToolCall(id, fileSearch);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepFileSearchToolCallResult RunStepFileSearchToolCallResult(string fileId = default, string fileName = default, float score = default, IEnumerable<FileSearchToolCallContent> content = default)
            => AgentsPersistentModelFactory.RunStepFileSearchToolCallResult(fileId, fileName, score, content);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepFileSearchToolCallResults RunStepFileSearchToolCallResults(FileSearchRankingOptions rankingOptions = default, IEnumerable<RunStepFileSearchToolCallResult> results = default)
            => AgentsPersistentModelFactory.RunStepFileSearchToolCallResults(rankingOptions, results);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepMessageCreationDetails RunStepMessageCreationDetails(RunStepMessageCreationReference messageCreation = default)
            => AgentsPersistentModelFactory.RunStepMessageCreationDetails(messageCreation);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepMessageCreationReference RunStepMessageCreationReference(string messageId = default)
            => AgentsPersistentModelFactory.RunStepMessageCreationReference(messageId);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepOpenAPIToolCall RunStepOpenAPIToolCall(string id = default, IReadOnlyDictionary<string, string> openAPI = default)
            => AgentsPersistentModelFactory.RunStepOpenAPIToolCall(id, openAPI);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepToolCall RunStepToolCall(string type = default, string id = default)
            => AgentsPersistentModelFactory.RunStepToolCall(type, id);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepToolCallDetails RunStepToolCallDetails(IEnumerable<RunStepToolCall> toolCalls = default)
            => AgentsPersistentModelFactory.RunStepToolCallDetails(toolCalls);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ThreadMessageOptions ThreadMessageOptions(MessageRole role = default, BinaryData content = default, IEnumerable<MessageAttachment> attachments = default, IDictionary<string, string> metadata = default)
            => AgentsPersistentModelFactory.ThreadMessageOptions(role, content, attachments, metadata);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorStoreFileCount VectorStoreFileCount(int inProgress = default, int completed = default, int failed = default, int cancelled = default, int total = default)
            => AgentsPersistentModelFactory.VectorStoreFileCount(inProgress, completed, failed, cancelled, total);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorStoreFileError VectorStoreFileError(VectorStoreFileErrorCode code = default, string message = default)
            => AgentsPersistentModelFactory.VectorStoreFileError(code, message);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorStoreStaticChunkingStrategyRequest VectorStoreStaticChunkingStrategyRequest(VectorStoreStaticChunkingStrategyOptions @static = default)
            => AgentsPersistentModelFactory.VectorStoreStaticChunkingStrategyRequest(@static);

        /// <summary> Backward-compat: delegates to AgentsPersistentModelFactory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorStoreStaticChunkingStrategyResponse VectorStoreStaticChunkingStrategyResponse(VectorStoreStaticChunkingStrategyOptions @static = default)
            => AgentsPersistentModelFactory.VectorStoreStaticChunkingStrategyResponse(@static);

        // ── Methods with DIFFERENT parameter types ────────────────────────────
        // Old signatures had extensible enum struct params that were removed.
        // The old param is accepted but ignored; we delegate to the new method.

        /// <summary> Backward-compat: old signature had AzureFunctionBindingType param. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AzureFunctionBinding AzureFunctionBinding(AzureFunctionBindingType type = default, AzureFunctionStorageQueue storageQueue = default)
            => AgentsPersistentModelFactory.AzureFunctionBinding(storageQueue);

        /// <summary> Backward-compat: old signature had FileSearchToolCallContentType param. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileSearchToolCallContent FileSearchToolCallContent(FileSearchToolCallContentType type = default, string text = default)
            => AgentsPersistentModelFactory.FileSearchToolCallContent(text);

        /// <summary> Backward-compat: old signature had MessageDeltaChunkObject param. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaChunk MessageDeltaChunk(string id = default, MessageDeltaChunkObject @object = default, MessageDelta delta = default)
            => AgentsPersistentModelFactory.MessageDeltaChunk(id, delta);

        /// <summary> Backward-compat: old signature had PersistentAgentsVectorStoreObject param. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PersistentAgentsVectorStore PersistentAgentsVectorStore(string id = default, PersistentAgentsVectorStoreObject @object = default, DateTimeOffset createdAt = default, string name = default, int usageBytes = default, VectorStoreFileCount fileCounts = default, VectorStoreStatus status = default, VectorStoreExpirationPolicy expiresAfter = default, DateTimeOffset? expiresAt = default, DateTimeOffset? lastActiveAt = default, IReadOnlyDictionary<string, string> metadata = default)
            => AgentsPersistentModelFactory.PersistentAgentsVectorStore(id, createdAt, name, usageBytes, fileCounts, status, expiresAfter, expiresAt, lastActiveAt, metadata);

        /// <summary> Backward-compat: old signature had ResponseFormatJsonSchemaTypeType param. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResponseFormatJsonSchemaType ResponseFormatJsonSchemaType(ResponseFormatJsonSchemaTypeType type = default, ResponseFormatJsonSchema jsonSchema = default)
            => AgentsPersistentModelFactory.ResponseFormatJsonSchemaType(jsonSchema);

        /// <summary> Backward-compat: old signature had RunStepDeltaChunkObject param. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RunStepDeltaChunk RunStepDeltaChunk(string id = default, RunStepDeltaChunkObject @object = default, RunStepDelta delta = default)
            => AgentsPersistentModelFactory.RunStepDeltaChunk(id, delta);

        /// <summary> Backward-compat: old signature had VectorStoreFileObject param. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorStoreFile VectorStoreFile(string id = default, VectorStoreFileObject @object = default, int usageBytes = default, DateTimeOffset createdAt = default, string vectorStoreId = default, VectorStoreFileStatus status = default, VectorStoreFileError lastError = default, VectorStoreChunkingStrategyResponse chunkingStrategy = default)
            => AgentsPersistentModelFactory.VectorStoreFile(id, usageBytes, createdAt, vectorStoreId, status, lastError, chunkingStrategy);

        /// <summary> Backward-compat: old signature had VectorStoreFileBatchObject param. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorStoreFileBatch VectorStoreFileBatch(string id = default, VectorStoreFileBatchObject @object = default, DateTimeOffset createdAt = default, string vectorStoreId = default, VectorStoreFileBatchStatus status = default, VectorStoreFileCount fileCounts = default)
            => AgentsPersistentModelFactory.VectorStoreFileBatch(id, createdAt, vectorStoreId, status, fileCounts);
    }
}
