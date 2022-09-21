// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Communication.CallAutomation.Models.Events
{
    /// <summary>
    /// The play completed event.
    /// </summary>
    [CodeGenModel("RecognizeFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class RecognizeFailedInternal : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="RecognizeFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeFailed"/> object.</returns>
        public static RecognizeFailedInternal Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeRecognizeFailedInternal(element);
        }
    }
}
