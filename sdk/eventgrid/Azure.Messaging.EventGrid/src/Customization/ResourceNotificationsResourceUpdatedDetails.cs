// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Describes the schema of the properties under resource info which are common across all ARN system topic events. </summary>
    public partial class ResourceNotificationsResourceUpdatedDetails
    {
        /// <summary> the type of the resource for which the event is being emitted. </summary>
        [CodeGenMember("Type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceType { get; }

        /// <summary> Resource for which the event is being emitted. </summary>
        public ResourceIdentifier Resource
        {
            get
            {
                if (_resource == null)
                {
                    _resource = new ResourceIdentifier(Id);
                }

                return _resource;
            }
        }

        private ResourceIdentifier _resource;

        /// <summary> id of the resource for which the event is being emitted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id { get; }

        /// <summary> name of the resource for which the event is being emitted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; }

        /// <summary> the location of the resource for which the event is being emitted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Location { get; }

        /// <summary> the tags on the resource for which the event is being emitted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property will always be null. Use ResourceTags instead.")]
        public string Tags { get; internal set; }

        /// <summary> the tags on the resource for which the event is being emitted. </summary>
        [CodeGenMember("Tags")]
        public IReadOnlyDictionary<string, string> ResourceTags { get; }
    }
}