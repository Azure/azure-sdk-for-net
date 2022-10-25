// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The call transfer accepted event.
    /// </summary>
    [CodeGenModel("CallTransferAccepted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CallTransferAccepted : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="CallTransferAccepted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallTransferAccepted"/> object.</returns>
        public static CallTransferAccepted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallTransferAccepted(element);
        }
    }
}
