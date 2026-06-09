// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("ExtensionTopicData")]

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> Event grid Extension Topic. This is used for getting Event Grid related metrics for Azure resources. </summary>
    public partial class ExtensionTopicData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;
        private string _description;
        private string _systemTopic;

        /// <summary> Initializes a new instance of <see cref="ExtensionTopicData"/>. </summary>
        public ExtensionTopicData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ExtensionTopicData"/>. </summary>
        internal ExtensionTopicData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ExtensionTopicProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id, name, resourceType, systemData)
        {
            _description = properties?.Description;
            _systemTopic = properties?.SystemTopic;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Description of the extension topic. </summary>
        [WirePath("properties.description")]
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        /// <summary> System topic resource id which is mapped to the source. </summary>
        [WirePath("properties.systemTopic")]
        public string SystemTopic
        {
            get => _systemTopic;
            set => _systemTopic = value;
        }
    }
}
