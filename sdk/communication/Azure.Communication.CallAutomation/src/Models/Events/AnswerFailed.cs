// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Create Call Failed event.
    /// </summary>
    [CodeGenModel("AnswerFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class AnswerFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="AnswerFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AnswerFailed"/> object.</returns>
        public static AnswerFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeAnswerFailed(element);
        }
    }
}
