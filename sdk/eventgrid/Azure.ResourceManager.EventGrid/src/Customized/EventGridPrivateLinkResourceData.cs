// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> Information of the private link resource. </summary>
    public partial class EventGridPrivateLinkResourceData : ResourceData, IJsonModel<EventGridPrivateLinkResourceData>, IPersistableModel<EventGridPrivateLinkResourceData>
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal EventGridPrivateLinkResourceData()
        {
        }

        internal EventGridPrivateLinkResourceData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            string groupId,
            string displayName,
            IReadOnlyList<string> requiredMembers,
            IReadOnlyList<string> requiredZoneNames,
            IDictionary<string, BinaryData> additionalBinaryDataProperties = null) : base(id, name, resourceType, systemData)
        {
            GroupId = groupId;
            DisplayName = displayName;
            RequiredMembers = requiredMembers;
            RequiredZoneNames = requiredZoneNames;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Gets the GroupId. </summary>
        [WirePath("properties.groupId")]
        public string GroupId { get; }

        /// <summary> Gets the DisplayName. </summary>
        [WirePath("properties.displayName")]
        public string DisplayName { get; }

        /// <summary> Gets the RequiredMembers. </summary>
        [WirePath("properties.requiredMembers")]
        public IReadOnlyList<string> RequiredMembers { get; }

        /// <summary> Gets the RequiredZoneNames. </summary>
        [WirePath("properties.requiredZoneNames")]
        public IReadOnlyList<string> RequiredZoneNames { get; }
    }
}
