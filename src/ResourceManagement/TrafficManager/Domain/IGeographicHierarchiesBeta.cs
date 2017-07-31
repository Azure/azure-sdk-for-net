// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.TrafficManager.Fluent.Models;

    /// <summary>
    /// Entry point to Azure traffic manager geographic hierarchy management API in Azure.
    /// </summary>
    public interface IGeographicHierarchiesBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicHierarchiesOperations>
    {
        /// <return>The root of the Geographic Hierarchy used by the Geographic traffic routing method.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation GetRoot();
    }
}