// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    // These obsolete properties should be suppressed during generation, otherwise build will fail
    [CodeGenSuppress("StartTimeUtc")]
    [CodeGenSuppress("EndTimeUtc")]
    [CodeGenSuppress("LastUpdatedTimeUtc")]
    public partial class HciClusterUpdateRunData
    {
        internal HciClusterUpdateRunData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, UpdateRunProperties properties, string updateRunName, AzureLocation? location, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(id, name, resourceType, systemData)
        {
            Properties = properties;
            Location = location;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        // Retain the legacy property as an alias for the resource name.
        /// <summary> Gets the name of the update run. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UpdateRunName => Name;

        // We suppressed the base Name property, so we need to re-declare it here to point to Progress.Name for backward compatibility with older versions of autorest that flattened Step.name to Progress.Name. This allows existing code that uses the old property name to continue working without modification.
        /// <summary> Name of the progress step. </summary>
        [WirePath("properties.progress.name")]
        [CodeGenMember("Name")]
        public string NamePropertiesProgressName
        {
            get
            {
                return Properties.Progress is null ? default : Properties.Progress.Name;
            }
            set
            {
                if (Properties.Progress is null)
                {
                    Properties.Progress = new HciUpdateStep();
                }
                Properties.Progress.Name = value;
            }
        }
    }
}
