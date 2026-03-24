// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.

namespace Azure.AI.Agents.Persistent
{
    // Backward-compatible forwarding overloads for methods whose metadata parameter
    // was changed from IReadOnlyDictionary<string,string> to IDictionary<string,string>.

    public partial class PersistentAgentsAdministrationClient
    {
        /// <inheritdoc cref="CreateAgent(string, string, string, string, IEnumerable{ToolDefinition}, ToolResources, float?, float?, System.BinaryData, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgent> CreateAgent(string model, string name, string description, string instructions, IEnumerable<ToolDefinition> tools, ToolResources toolResources, float? temperature, float? topP, System.BinaryData responseFormat, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => CreateAgent(model, name, description, instructions, tools, toolResources, temperature, topP, responseFormat, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="CreateAgentAsync(string, string, string, string, IEnumerable{ToolDefinition}, ToolResources, float?, float?, System.BinaryData, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PersistentAgent>> CreateAgentAsync(string model, string name, string description, string instructions, IEnumerable<ToolDefinition> tools, ToolResources toolResources, float? temperature, float? topP, System.BinaryData responseFormat, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => CreateAgentAsync(model, name, description, instructions, tools, toolResources, temperature, topP, responseFormat, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="UpdateAgent(string, string, string, string, string, IEnumerable{ToolDefinition}, ToolResources, float?, float?, System.BinaryData, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgent> UpdateAgent(string assistantId, string model, string name, string description, string instructions, IEnumerable<ToolDefinition> tools, ToolResources toolResources, float? temperature, float? topP, System.BinaryData responseFormat, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => UpdateAgent(assistantId, model, name, description, instructions, tools, toolResources, temperature, topP, responseFormat, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="UpdateAgentAsync(string, string, string, string, string, IEnumerable{ToolDefinition}, ToolResources, float?, float?, System.BinaryData, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PersistentAgent>> UpdateAgentAsync(string assistantId, string model, string name, string description, string instructions, IEnumerable<ToolDefinition> tools, ToolResources toolResources, float? temperature, float? topP, System.BinaryData responseFormat, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => UpdateAgentAsync(assistantId, model, name, description, instructions, tools, toolResources, temperature, topP, responseFormat, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);
    }

    public partial class ThreadMessages
    {
        /// <inheritdoc cref="CreateMessage(string, MessageRole, System.BinaryData, IEnumerable{MessageAttachment}, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentThreadMessage> CreateMessage(string threadId, MessageRole role, System.BinaryData content, IEnumerable<MessageAttachment> attachments, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => CreateMessage(threadId, role, content, attachments, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="CreateMessageAsync(string, MessageRole, System.BinaryData, IEnumerable{MessageAttachment}, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PersistentThreadMessage>> CreateMessageAsync(string threadId, MessageRole role, System.BinaryData content, IEnumerable<MessageAttachment> attachments, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => CreateMessageAsync(threadId, role, content, attachments, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="UpdateMessage(string, string, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentThreadMessage> UpdateMessage(string threadId, string messageId, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => UpdateMessage(threadId, messageId, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="UpdateMessageAsync(string, string, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PersistentThreadMessage>> UpdateMessageAsync(string threadId, string messageId, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => UpdateMessageAsync(threadId, messageId, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);
    }

    public partial class ThreadRuns
    {
        /// <inheritdoc cref="UpdateRun(string, string, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ThreadRun> UpdateRun(string threadId, string runId, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => UpdateRun(threadId, runId, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="UpdateRunAsync(string, string, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ThreadRun>> UpdateRunAsync(string threadId, string runId, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => UpdateRunAsync(threadId, runId, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);
    }

    public partial class Threads
    {
        /// <inheritdoc cref="CreateThread(IEnumerable{ThreadMessageOptions}, ToolResources, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgentThread> CreateThread(IEnumerable<ThreadMessageOptions> messages, ToolResources toolResources, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => CreateThread(messages, toolResources, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="CreateThreadAsync(IEnumerable{ThreadMessageOptions}, ToolResources, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PersistentAgentThread>> CreateThreadAsync(IEnumerable<ThreadMessageOptions> messages, ToolResources toolResources, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => CreateThreadAsync(messages, toolResources, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="UpdateThread(string, ToolResources, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgentThread> UpdateThread(string threadId, ToolResources toolResources, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => UpdateThread(threadId, toolResources, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="UpdateThreadAsync(string, ToolResources, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PersistentAgentThread>> UpdateThreadAsync(string threadId, ToolResources toolResources, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => UpdateThreadAsync(threadId, toolResources, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);
    }

    public partial class VectorStores
    {
        /// <inheritdoc cref="CreateVectorStore(IEnumerable{string}, string, VectorStoreConfiguration, VectorStoreExpirationPolicy, VectorStoreChunkingStrategy, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgentsVectorStore> CreateVectorStore(IEnumerable<string> fileIds, string name, VectorStoreConfiguration storeConfiguration, VectorStoreExpirationPolicy expiresAfter, VectorStoreChunkingStrategy chunkingStrategy, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => CreateVectorStore(fileIds, name, storeConfiguration, expiresAfter, chunkingStrategy, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="CreateVectorStoreAsync(IEnumerable{string}, string, VectorStoreConfiguration, VectorStoreExpirationPolicy, VectorStoreChunkingStrategy, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PersistentAgentsVectorStore>> CreateVectorStoreAsync(IEnumerable<string> fileIds, string name, VectorStoreConfiguration storeConfiguration, VectorStoreExpirationPolicy expiresAfter, VectorStoreChunkingStrategy chunkingStrategy, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => CreateVectorStoreAsync(fileIds, name, storeConfiguration, expiresAfter, chunkingStrategy, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="ModifyVectorStore(string, string, VectorStoreExpirationPolicy, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgentsVectorStore> ModifyVectorStore(string vectorStoreId, string name, VectorStoreExpirationPolicy expiresAfter, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => ModifyVectorStore(vectorStoreId, name, expiresAfter, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);

        /// <inheritdoc cref="ModifyVectorStoreAsync(string, string, VectorStoreExpirationPolicy, IDictionary{string, string}, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PersistentAgentsVectorStore>> ModifyVectorStoreAsync(string vectorStoreId, string name, VectorStoreExpirationPolicy expiresAfter, IReadOnlyDictionary<string, string> metadata, CancellationToken cancellationToken = default)
            => ModifyVectorStoreAsync(vectorStoreId, name, expiresAfter, (IDictionary<string, string>)metadata?.ToDictionary(kv => kv.Key, kv => kv.Value), cancellationToken);
    }
}

#pragma warning restore AZC0002
