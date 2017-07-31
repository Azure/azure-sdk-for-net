// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to traffic manager profile management API in Azure.
    /// </summary>
    public interface ITrafficManagerProfilesBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <return>The default Geographic Hierarchy used by the Geographic traffic routing method.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation GetGeographicHierarchyRoot();
    }
}