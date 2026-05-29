// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    /// <summary>
    /// A class representing a collection of <see cref="ContainerRegistryRunResource"/> and their operations.
    /// Each <see cref="ContainerRegistryRunResource"/> in the collection will belong to the same instance of resource group.
    /// To get a <see cref="ContainerRegistryRunCollection"/> instance call the GetRuns method from an instance of resource group.
    /// </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunCollection : ArmCollection, IEnumerable<ContainerRegistryRunResource>, IAsyncEnumerable<ContainerRegistryRunResource>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryRunCollection"/> for mocking. </summary>
        protected ContainerRegistryRunCollection() : base() { }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="runId"> The run ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="runId"> The run ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<Response<bool>> ExistsAsync(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets the detailed information for a given run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="runId"> The run ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ContainerRegistryRunResource> Get(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets the detailed information for a given run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="runId"> The run ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<Response<ContainerRegistryRunResource>> GetAsync(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets all the runs for a registry.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The runs filter to apply on the operation. Arithmetic operators are not supported. The allowed string function is 'contains'. All logical operators except 'Not', 'Has', 'All' are allowed. </param>
        /// <param name="top"> $top is supported for get list of runs, which limits the maximum number of runs to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerRegistryRunResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ContainerRegistryRunResource> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets all the runs for a registry.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The runs filter to apply on the operation. Arithmetic operators are not supported. The allowed string function is 'contains'. All logical operators except 'Not', 'Has', 'All' are allowed. </param>
        /// <param name="top"> $top is supported for get list of runs, which limits the maximum number of runs to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerRegistryRunResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ContainerRegistryRunResource> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="runId"> The run ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<ContainerRegistryRunResource> GetIfExists(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="runId"> The run ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<NullableResponse<ContainerRegistryRunResource>> GetIfExistsAsync(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }

        IEnumerator<ContainerRegistryRunResource> IEnumerable<ContainerRegistryRunResource>.GetEnumerator() { return GetAll().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetAll().GetEnumerator(); }
        IAsyncEnumerator<ContainerRegistryRunResource> IAsyncEnumerable<ContainerRegistryRunResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
    }
}
