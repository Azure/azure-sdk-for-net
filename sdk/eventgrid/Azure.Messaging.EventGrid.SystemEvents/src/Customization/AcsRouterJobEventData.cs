// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class AcsRouterJobEventData
    {
        /// <summary> Router Job events Labels. </summary>
        public IReadOnlyDictionary<string, string> Labels { get; }

        /// <summary> Router Jobs events Tags. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
