// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class AcsChatThreadPropertiesUpdatedPerUserEventData
    {
        /// <summary>
        /// The properties of the chat thread that were updated for the user.
        /// </summary>
        public IReadOnlyDictionary<string, object> Properties { get; }
    }
}
