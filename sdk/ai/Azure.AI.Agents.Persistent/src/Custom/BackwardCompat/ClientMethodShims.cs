// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat shims: The new generator changed metadata parameters from
// IReadOnlyDictionary<string,string> to IDictionary<string,string>. These overloads
// accept the old IReadOnlyDictionary signature and delegate to the new IDictionary methods.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable AZC0002 // DO ensure that service method parameters are optional

namespace Azure.AI.Agents.Persistent
{
    // Helper to convert IReadOnlyDictionary → IDictionary without copying when possible.
    internal static class BackwardCompatHelper
    {
        // IReadOnlyDictionary doesn't implement IDictionary, so Dictionary(IDictionary)
        // constructor can't be used. ToDictionary is the simplest correct conversion.
        internal static IDictionary<string, string> ToDict(IReadOnlyDictionary<string, string> source)
            => source is IDictionary<string, string> dict ? dict : source?.ToDictionary(e => e.Key, e => e.Value);
    }

    // ── PersistentAgentsAdministrationClient ──────────────────────────────────

    public partial class PersistentAgentsAdministrationClient
    {
        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgent> CreateAgent(
            string model,
            string name,
            string description,
            string instructions,
            IEnumerable<ToolDefinition> tools,
            ToolResources toolResources,
            float? temperature,
            float? topP,
            BinaryData responseFormat,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => CreateAgent(model, name, description, instructions, tools, toolResources,
                temperature, topP, responseFormat, BackwardCompatHelper.ToDict(metadata), cancellationToken);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PersistentAgent>> CreateAgentAsync(
            string model,
            string name,
            string description,
            string instructions,
            IEnumerable<ToolDefinition> tools,
            ToolResources toolResources,
            float? temperature,
            float? topP,
            BinaryData responseFormat,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => await CreateAgentAsync(model, name, description, instructions, tools, toolResources,
                temperature, topP, responseFormat, BackwardCompatHelper.ToDict(metadata), cancellationToken).ConfigureAwait(false);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgent> UpdateAgent(
            string assistantId,
            string model,
            string name,
            string description,
            string instructions,
            IEnumerable<ToolDefinition> tools,
            ToolResources toolResources,
            float? temperature,
            float? topP,
            BinaryData responseFormat,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => UpdateAgent(assistantId, model, name, description, instructions, tools, toolResources,
                temperature, topP, responseFormat, BackwardCompatHelper.ToDict(metadata), cancellationToken);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PersistentAgent>> UpdateAgentAsync(
            string assistantId,
            string model,
            string name,
            string description,
            string instructions,
            IEnumerable<ToolDefinition> tools,
            ToolResources toolResources,
            float? temperature,
            float? topP,
            BinaryData responseFormat,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => await UpdateAgentAsync(assistantId, model, name, description, instructions, tools, toolResources,
                temperature, topP, responseFormat, BackwardCompatHelper.ToDict(metadata), cancellationToken).ConfigureAwait(false);
    }

    // ── ThreadMessages ────────────────────────────────────────────────────────

    public partial class ThreadMessages
    {
        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentThreadMessage> CreateMessage(
            string threadId,
            MessageRole role,
            BinaryData content,
            IEnumerable<MessageAttachment> attachments,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => CreateMessage(threadId, role, content, attachments, BackwardCompatHelper.ToDict(metadata), cancellationToken);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PersistentThreadMessage>> CreateMessageAsync(
            string threadId,
            MessageRole role,
            BinaryData content,
            IEnumerable<MessageAttachment> attachments,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => await CreateMessageAsync(threadId, role, content, attachments, BackwardCompatHelper.ToDict(metadata), cancellationToken).ConfigureAwait(false);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentThreadMessage> UpdateMessage(
            string threadId,
            string messageId,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => UpdateMessage(threadId, messageId, BackwardCompatHelper.ToDict(metadata), cancellationToken);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PersistentThreadMessage>> UpdateMessageAsync(
            string threadId,
            string messageId,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => await UpdateMessageAsync(threadId, messageId, BackwardCompatHelper.ToDict(metadata), cancellationToken).ConfigureAwait(false);
    }

    // ── ThreadRuns ────────────────────────────────────────────────────────────

    public partial class ThreadRuns
    {
        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ThreadRun> UpdateRun(
            string threadId,
            string runId,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => UpdateRun(threadId, runId, BackwardCompatHelper.ToDict(metadata), cancellationToken);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ThreadRun>> UpdateRunAsync(
            string threadId,
            string runId,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => await UpdateRunAsync(threadId, runId, BackwardCompatHelper.ToDict(metadata), cancellationToken).ConfigureAwait(false);
    }

    // ── Threads ───────────────────────────────────────────────────────────────

    public partial class Threads
    {
        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgentThread> CreateThread(
            IEnumerable<ThreadMessageOptions> messages,
            ToolResources toolResources,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => CreateThread(messages, toolResources, BackwardCompatHelper.ToDict(metadata), cancellationToken);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PersistentAgentThread>> CreateThreadAsync(
            IEnumerable<ThreadMessageOptions> messages,
            ToolResources toolResources,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => await CreateThreadAsync(messages, toolResources, BackwardCompatHelper.ToDict(metadata), cancellationToken).ConfigureAwait(false);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgentThread> UpdateThread(
            string threadId,
            ToolResources toolResources,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => UpdateThread(threadId, toolResources, BackwardCompatHelper.ToDict(metadata), cancellationToken);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PersistentAgentThread>> UpdateThreadAsync(
            string threadId,
            ToolResources toolResources,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => await UpdateThreadAsync(threadId, toolResources, BackwardCompatHelper.ToDict(metadata), cancellationToken).ConfigureAwait(false);
    }

    // ── VectorStores ──────────────────────────────────────────────────────────

    public partial class VectorStores
    {
        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgentsVectorStore> CreateVectorStore(
            IEnumerable<string> fileIds,
            string name,
            VectorStoreConfiguration storeConfiguration,
            VectorStoreExpirationPolicy expiresAfter,
            VectorStoreChunkingStrategy chunkingStrategy,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => CreateVectorStore(fileIds, name, storeConfiguration, expiresAfter, chunkingStrategy, BackwardCompatHelper.ToDict(metadata), cancellationToken);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PersistentAgentsVectorStore>> CreateVectorStoreAsync(
            IEnumerable<string> fileIds,
            string name,
            VectorStoreConfiguration storeConfiguration,
            VectorStoreExpirationPolicy expiresAfter,
            VectorStoreChunkingStrategy chunkingStrategy,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => await CreateVectorStoreAsync(fileIds, name, storeConfiguration, expiresAfter, chunkingStrategy, BackwardCompatHelper.ToDict(metadata), cancellationToken).ConfigureAwait(false);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PersistentAgentsVectorStore> ModifyVectorStore(
            string vectorStoreId,
            string name,
            VectorStoreExpirationPolicy expiresAfter,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => ModifyVectorStore(vectorStoreId, name, expiresAfter, BackwardCompatHelper.ToDict(metadata), cancellationToken);

        /// <summary> Backward-compat: accepts IReadOnlyDictionary metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PersistentAgentsVectorStore>> ModifyVectorStoreAsync(
            string vectorStoreId,
            string name,
            VectorStoreExpirationPolicy expiresAfter,
            IReadOnlyDictionary<string, string> metadata,
            CancellationToken cancellationToken)
            => await ModifyVectorStoreAsync(vectorStoreId, name, expiresAfter, BackwardCompatHelper.ToDict(metadata), cancellationToken).ConfigureAwait(false);
    }
}
