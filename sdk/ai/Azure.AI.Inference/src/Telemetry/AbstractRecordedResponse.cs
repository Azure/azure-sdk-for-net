using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.Inference.Telemetry
{
    internal abstract class AbstractRecordedResponse
    {
        public string Model { get; protected set; } = "";
        public string Id { get; protected set; } = "";
        public string FinishReason { get; protected set; } = "";
        public int CompletionTokens { get; protected set; } = 0;
        public int PromptTokens { get; protected set; } = 0;

        /// <summary>
        /// Return the JSON serialized completion for event logging.
        /// </summary>
        /// <returns>The iterator over completions</returns>
        public abstract string[] getSerializedCompletions();
    }
}
