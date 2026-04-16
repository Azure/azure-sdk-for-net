// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerInstance
{
    [CodeGenSuppress("OSType")]
    public partial class ContainerGroupProfileData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupProfileData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers, ContainerInstanceOperatingSystemType osType) : this(location)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            foreach (var container in containers)
            {
                Containers.Add(container);
            }
            OSType = osType;
        }

        /// <summary> The operating system type required by the containers in the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceOperatingSystemType? OSType
        {
            get => Properties is null ? default : Properties.OSType;
            set
            {
                if (Properties is null)
                {
                    Properties = new ContainerGroupProfileProperties();
                }
                Properties.OSType = value ?? default;
            }
        }
    }
}
