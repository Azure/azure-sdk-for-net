// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

// Backward-compat constructor and property shims for TypeSpec migration.
// Properties delegate to the internal ContainerProperties nested type.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerInstanceContainer
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstanceContainer"/>. </summary>
        /// <param name="name"> The name of the container. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceContainer(string name)
            : this(name, (ContainerProperties)default, (IDictionary<string, System.BinaryData>)default)
        {
        }

        /// <summary> Initializes a new instance of <see cref="ContainerInstanceContainer"/>. </summary>
        /// <param name="name"> The name of the container. </param>
        /// <param name="image"> The container image. </param>
        /// <param name="resources"> The resource requirements. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceContainer(string name, string image, ContainerResourceRequirements resources)
            : this(name, (ContainerProperties)default, (IDictionary<string, System.BinaryData>)default)
        {
        }

        // Delegation properties for ContainerProperties members (moved to nested type in TypeSpec generation).

        /// <summary> The environment variables to set in the container instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ContainerEnvironmentVariable> EnvironmentVariables
        {
            get
            {
                if (Properties is null)
                    Properties = new ContainerProperties();
                return Properties.EnvironmentVariables;
            }
        }

        /// <summary> The instance view of the container instance. Only valid in response. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceView InstanceView => Properties?.InstanceView;

        /// <summary> The resource requirements of the container instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerResourceRequirements Resources
        {
            get => Properties?.Resources;
            set
            {
                if (Properties is null)
                    Properties = new ContainerProperties();
                Properties.Resources = value;
            }
        }

        /// <summary> The container security properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerSecurityContextDefinition SecurityContext
        {
            get => Properties?.SecurityContext;
            set
            {
                if (Properties is null)
                    Properties = new ContainerProperties();
                Properties.SecurityContext = value;
            }
        }

        /// <summary> The volume mounts available to the container instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ContainerVolumeMount> VolumeMounts
        {
            get
            {
                if (Properties is null)
                    Properties = new ContainerProperties();
                return Properties.VolumeMounts;
            }
        }
    }
}
