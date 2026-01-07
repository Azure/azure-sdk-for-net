// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Connect Failed event.
    /// </summary>
    [CodeGenModel("ConnectFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class ConnectFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="ConnectFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ConnectFailed"/> object.</returns>
        public static ConnectFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeConnectFailed(element);
        }
    }
}
