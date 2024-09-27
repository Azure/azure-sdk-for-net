// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Inference.Telemetry
{
#nullable enable
    internal abstract class AbstractRecordedResponse
    {
        public string? Model { get; protected set; } = null;
        public string? Id { get; protected set; } = null;
        public virtual string[]? FinishReasons { get; protected set; } = null;
        public long? CompletionTokens { get; protected set; } = null;
        public long? PromptTokens { get; protected set; } = null;

        /// <summary>
        /// Return the JSON serialized completion for event logging.
        /// </summary>
        /// <returns>The iterator over completions</returns>
        public abstract string[] GetSerializedCompletions();
    }
}
