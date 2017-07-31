// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Type representing Geographic Hierarchy region (location).
    /// </summary>
    public interface IGeographicLocation  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.TrafficManager.Fluent.Models.RegionInner>
    {
        /// <summary>
        /// Gets the location code.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Gets list of all descendant locations grouped under this location in the Geographic Hierarchy.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation> DescendantLocations { get; }

        /// <summary>
        /// Gets list of immediate child locations grouped under this location in the Geographic Hierarchy.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation> ChildLocations { get; }
    }
}