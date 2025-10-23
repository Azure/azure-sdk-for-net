// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class AcsChatThreadPropertiesUpdatedEventData
    {
        /// <summary>
        /// Gets the properties of the chat thread updated event.
        /// </summary>
        public IReadOnlyDictionary<string, object> Properties { get; }
    }
}
