// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ContainerRegistry
{
    public partial class ConnectedRegistry
    {
        // ConnectedRegistry has both an ARM resource parent and a flattened model property named Parent.
        // Defining the resource parent here lets the customization below target the model property unambiguously.
        private ResourceReference<ContainerRegistryService> _parent;

        /// <summary> Gets or sets the Parent. </summary>
        public ContainerRegistryService Parent
        {
            get
            {
                Initialize();
                return _parent.Value;
            }
            set
            {
                Initialize();
                _parent.Value = value;
            }
        }

        // Preserve the existing public API name while avoiding a collision with the resource Parent property.
        /// <summary> Gets or sets the ConnectedRegistryParent. </summary>
        [CodeGenMember("Parent")]
        public ConnectedRegistryParent ConnectedRegistryParent
        {
            get
            {
                return Properties is null ? default : Properties.Parent;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new ConnectedRegistryProperties();
                }
                Properties.Parent = value;
            }
        }

        /// <summary></summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2025-04-01". </summary>
            public static readonly string V2025_04_01 = "2025-04-01";
        }
    }
}
