// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MachineLearning.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve GA MachineLearning-prefixed child resource accessors over shorter generated
    // registry child-resource accessors, which are not standalone REST operations that client.tsp can rename.
    public partial class MachineLearningRegistryResource
    {
        // Customized: keep the historical MachineLearning*/MachineLearnin* method names for source compatibility.
        /// <summary> Gets a collection of MachineLearningRegistryCodeContainerResources in the <see cref="MachineLearningRegistryResource"/>. </summary>
        public virtual MachineLearningRegistryCodeContainerCollection GetMachineLearningRegistryCodeContainers() => new MachineLearningRegistryCodeContainerCollection(Client, Id);
        /// <summary> Gets a registry code container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryCodeContainerResource>> GetMachineLearningRegistryCodeContainerAsync(string codeName, CancellationToken cancellationToken = default) => GetMachineLearningRegistryCodeContainers().GetAsync(codeName, cancellationToken);
        /// <summary> Gets a registry code container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryCodeContainerResource> GetMachineLearningRegistryCodeContainer(string codeName, CancellationToken cancellationToken = default) => GetMachineLearningRegistryCodeContainers().Get(codeName, cancellationToken);
        /// <summary> Gets registry component containers. </summary>
        public virtual MachineLearninRegistryComponentContainerCollection GetMachineLearninRegistryComponentContainers() => new MachineLearninRegistryComponentContainerCollection(Client, Id);
        /// <summary> Gets a registry component container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearninRegistryComponentContainerResource>> GetMachineLearninRegistryComponentContainerAsync(string componentName, CancellationToken cancellationToken = default) => GetMachineLearninRegistryComponentContainers().GetAsync(componentName, cancellationToken);
        /// <summary> Gets a registry component container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearninRegistryComponentContainerResource> GetMachineLearninRegistryComponentContainer(string componentName, CancellationToken cancellationToken = default) => GetMachineLearninRegistryComponentContainers().Get(componentName, cancellationToken);
        /// <summary> Gets registry data containers. </summary>
        public virtual MachineLearningRegistryDataContainerCollection GetMachineLearningRegistryDataContainers() => new MachineLearningRegistryDataContainerCollection(Client, Id);
        /// <summary> Gets a registry data container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryDataContainerResource>> GetMachineLearningRegistryDataContainerAsync(string name, CancellationToken cancellationToken = default) => GetMachineLearningRegistryDataContainers().GetAsync(name, cancellationToken);
        /// <summary> Gets a registry data container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryDataContainerResource> GetMachineLearningRegistryDataContainer(string name, CancellationToken cancellationToken = default) => GetMachineLearningRegistryDataContainers().Get(name, cancellationToken);
        /// <summary> Gets registry environment containers. </summary>
        public virtual MachineLearningRegistryEnvironmentContainerCollection GetMachineLearningRegistryEnvironmentContainers() => new MachineLearningRegistryEnvironmentContainerCollection(Client, Id);
        /// <summary> Gets a registry environment container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryEnvironmentContainerResource>> GetMachineLearningRegistryEnvironmentContainerAsync(string environmentName, CancellationToken cancellationToken = default) => GetMachineLearningRegistryEnvironmentContainers().GetAsync(environmentName, cancellationToken);
        /// <summary> Gets a registry environment container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryEnvironmentContainerResource> GetMachineLearningRegistryEnvironmentContainer(string environmentName, CancellationToken cancellationToken = default) => GetMachineLearningRegistryEnvironmentContainers().Get(environmentName, cancellationToken);
        /// <summary> Gets registry model containers. </summary>
        public virtual MachineLearningRegistryModelContainerCollection GetMachineLearningRegistryModelContainers() => new MachineLearningRegistryModelContainerCollection(Client, Id);
        /// <summary> Gets a registry model container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryModelContainerResource>> GetMachineLearningRegistryModelContainerAsync(string modelName, CancellationToken cancellationToken = default) => GetMachineLearningRegistryModelContainers().GetAsync(modelName, cancellationToken);
        /// <summary> Gets a registry model container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryModelContainerResource> GetMachineLearningRegistryModelContainer(string modelName, CancellationToken cancellationToken = default) => GetMachineLearningRegistryModelContainers().Get(modelName, cancellationToken);
    }
}
