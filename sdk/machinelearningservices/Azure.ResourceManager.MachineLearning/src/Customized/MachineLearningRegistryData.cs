// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.MachineLearning.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: restore GA settable collection properties. The TypeSpec model keeps these
    // collections inside read-only RegistryProperties, so SDK custom code is required to expose setters.
    public partial class MachineLearningRegistryData
    {
        /// <summary> Private endpoint connections info used for pending connections in private link portal. </summary>
        [CodeGenMember("RegistryPrivateEndpointConnections")]
        [WirePath("properties.registryPrivateEndpointConnections")]
        public IList<RegistryPrivateEndpointConnection> RegistryPrivateEndpointConnections
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RegistryProperties();
                }
                return Properties.RegistryPrivateEndpointConnections;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new RegistryProperties();
                }
                Properties.RegistryPrivateEndpointConnections.Clear();
                foreach (RegistryPrivateEndpointConnection item in value)
                {
                    Properties.RegistryPrivateEndpointConnections.Add(item);
                }
            }
        }

        /// <summary> Details of each region the registry is in. </summary>
        [CodeGenMember("RegionDetails")]
        [WirePath("properties.regionDetails")]
        public IList<RegistryRegionArmDetails> RegionDetails
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RegistryProperties();
                }
                return Properties.RegionDetails;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new RegistryProperties();
                }
                Properties.RegionDetails.Clear();
                foreach (RegistryRegionArmDetails item in value)
                {
                    Properties.RegionDetails.Add(item);
                }
            }
        }
    }
}
