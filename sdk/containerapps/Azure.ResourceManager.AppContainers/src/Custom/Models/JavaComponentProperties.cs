// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AppContainers.Models
{
    public abstract partial class JavaComponentProperties
    {
        // Preserve the shipped protected parameterless constructor for derived customizations.
        /// <summary> Initializes a new instance of <see cref="JavaComponentProperties"/>. </summary>
        protected JavaComponentProperties()
        {
            Configurations = new ChangeTrackingList<JavaComponentConfigurationProperty>();
            ServiceBinds = new ChangeTrackingList<JavaComponentServiceBind>();
        }
    }
}
