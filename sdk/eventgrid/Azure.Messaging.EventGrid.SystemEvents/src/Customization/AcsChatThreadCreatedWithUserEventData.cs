// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class AcsChatThreadCreatedWithUserEventData
    {
        /// <summary>
        /// Gets the properties of the chat thread created with user event.
        /// </summary>
        public IReadOnlyDictionary<string, object> Properties { get; }
    }
}
