// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Communication.Chat
{
    public partial class AzureCommunicationChatContext
    {
        private static AzureCommunicationChatContext _azureCommunicationChatContext;

        /// <summary> Gets the default instance </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureCommunicationChatContext Default => _azureCommunicationChatContext ??= new();
    }
}
