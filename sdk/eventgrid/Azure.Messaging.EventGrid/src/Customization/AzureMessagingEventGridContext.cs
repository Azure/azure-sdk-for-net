// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// This class is used to provide a default ModelReaderWriterContext for Azure Messaging Event Grid.
    /// </summary>
    public partial class AzureMessagingEventGridContext
    {
        /// <summary>
        /// The default <see cref="AzureMessagingEventGridContext"/> instance.
        /// </summary>
        public static AzureMessagingEventGridContext Default { get; } = new AzureMessagingEventGridContext();

        internal AzureMessagingEventGridContext()
        {
        }
    }
}
