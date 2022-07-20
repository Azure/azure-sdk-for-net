// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call transfer failed event.
    /// </summary>
    public partial class CallTransferFailedEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="CallTransferFailedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallTransferFailedEvent"/> object.</returns>
        public static CallTransferFailedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallTransferFailedEvent(element);
        }
    }
}
