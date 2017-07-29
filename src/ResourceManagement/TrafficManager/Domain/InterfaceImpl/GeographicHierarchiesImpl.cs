// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.TrafficManager.Fluent.Models;

    internal partial class GeographicHierarchiesImpl 
    {
        /// <return>The root of the Geographic Hierarchy used by the Geographic traffic routing method.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicHierarchiesBeta.GetRoot()
        {
            return this.GetRoot() as Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation;
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManager>.Manager
        {
            get
            {
                return this.Manager() as Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManager;
            }
        }
    }
}