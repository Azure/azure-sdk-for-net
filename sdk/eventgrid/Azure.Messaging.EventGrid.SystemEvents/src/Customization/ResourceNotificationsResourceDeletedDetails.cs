// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Describes the schema of the properties under resource info which are common across all ARN system topic delete events. </summary>
    public partial class ResourceNotificationsResourceDeletedDetails
    {
        /// <summary> Resource for which the event is being emitted. </summary>
        [CodeGenMember("Id")]
        public ResourceIdentifier Resource { get; }

        internal string Name { get; }

        internal string Type { get; }
    }
}