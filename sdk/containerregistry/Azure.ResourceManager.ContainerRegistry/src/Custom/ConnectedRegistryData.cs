// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ContainerRegistry.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Backward compatibility: the old API exposed Mode as ConnectedRegistryMode? (nullable).
    // The new TypeSpec spec defines mode as required, generating a non-nullable property.
    // Suppress the generated property and re-expose as nullable.
    [CodeGenSuppress("Mode")]
    public partial class ConnectedRegistryData
    {
        /// <summary> The mode of the connected registry resource that indicates the permissions of the registry. </summary>
        [WirePath("properties.mode")]
        public ConnectedRegistryMode? Mode
        {
            get => Properties is null ? default : Properties.Mode;
            set
            {
                if (Properties is null)
                {
                    Properties = new ConnectedRegistryProperties();
                }
                if (value.HasValue)
                {
                    Properties.Mode = value.Value;
                }
            }
        }
    }
}
