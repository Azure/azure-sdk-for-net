// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerInstanceContainer
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstanceContainer"/>. </summary>
        /// <param name="name"> The user-provided name of the container instance. </param>
        /// <param name="image"> The name of the image used to create the container instance. </param>
        /// <param name="resources"> The resource requirements of the container instance. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="image"/> or <paramref name="resources"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceContainer(string name, string image, ContainerResourceRequirements resources)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(image, nameof(image));
            Argument.AssertNotNull(resources, nameof(resources));

            Name = name;
            Image = image;
            Command = new ChangeTrackingList<string>();
            Ports = new ChangeTrackingList<ContainerPort>();
            EnvironmentVariables = new ChangeTrackingList<ContainerEnvironmentVariable>();
            Resources = resources;
            VolumeMounts = new ChangeTrackingList<ContainerVolumeMount>();
        }
    }
}
