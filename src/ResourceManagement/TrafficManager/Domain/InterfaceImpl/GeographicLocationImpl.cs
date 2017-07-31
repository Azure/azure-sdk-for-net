// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class GeographicLocationImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the location code.
        /// </summary>
        string Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation.Code
        {
            get
            {
                return this.Code();
            }
        }

        /// <summary>
        /// Gets list of immediate child locations grouped under this location in the Geographic Hierarchy.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation> Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation.ChildLocations
        {
            get
            {
                return this.ChildLocations() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation>;
            }
        }

        /// <summary>
        /// Gets list of all descendant locations grouped under this location in the Geographic Hierarchy.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation> Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation.DescendantLocations
        {
            get
            {
                return this.DescendantLocations() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation>;
            }
        }
    }
}