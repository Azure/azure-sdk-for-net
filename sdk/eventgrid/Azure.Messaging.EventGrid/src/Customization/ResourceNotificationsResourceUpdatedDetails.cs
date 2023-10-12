// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Describes the schema of the properties under resource info which are common across all ARN system topic events. </summary>
    public partial class ResourceNotificationsResourceUpdatedDetails
    {
        /// <summary> the type of the resource for which the event is being emitted. </summary>
        [CodeGenMember("Type")]
        public string ResourceType { get; }
    }
}