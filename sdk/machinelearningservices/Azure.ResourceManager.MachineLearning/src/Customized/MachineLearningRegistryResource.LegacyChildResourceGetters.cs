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
    // Customized: preserve legacy MachineLearning-prefixed child resource getters and related legacy resource helpers.
    public partial class MachineLearningRegistryResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningRegistryCodeContainerCollection GetMachineLearningRegistryCodeContainers() => GetRegistryCodeContainers();
        /// <summary> Gets a registry code container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryCodeContainerResource>> GetMachineLearningRegistryCodeContainerAsync(string codeName, CancellationToken cancellationToken = default) => GetRegistryCodeContainerAsync(codeName, cancellationToken);
        /// <summary> Gets a registry code container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryCodeContainerResource> GetMachineLearningRegistryCodeContainer(string codeName, CancellationToken cancellationToken = default) => GetRegistryCodeContainer(codeName, cancellationToken);
        /// <summary> Gets registry component containers. </summary>
        public virtual MachineLearninRegistryComponentContainerCollection GetMachineLearninRegistryComponentContainers() => GetRegistryComponentContainers();
        /// <summary> Gets a registry component container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearninRegistryComponentContainerResource>> GetMachineLearninRegistryComponentContainerAsync(string componentName, CancellationToken cancellationToken = default) => GetRegistryComponentContainerAsync(componentName, cancellationToken);
        /// <summary> Gets a registry component container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearninRegistryComponentContainerResource> GetMachineLearninRegistryComponentContainer(string componentName, CancellationToken cancellationToken = default) => GetRegistryComponentContainer(componentName, cancellationToken);
        /// <summary> Gets registry data containers. </summary>
        public virtual MachineLearningRegistryDataContainerCollection GetMachineLearningRegistryDataContainers() => GetRegistryDataContainers();
        /// <summary> Gets a registry data container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryDataContainerResource>> GetMachineLearningRegistryDataContainerAsync(string name, CancellationToken cancellationToken = default) => GetRegistryDataContainerAsync(name, cancellationToken);
        /// <summary> Gets a registry data container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryDataContainerResource> GetMachineLearningRegistryDataContainer(string name, CancellationToken cancellationToken = default) => GetRegistryDataContainer(name, cancellationToken);
        /// <summary> Gets registry environment containers. </summary>
        public virtual MachineLearningRegistryEnvironmentContainerCollection GetMachineLearningRegistryEnvironmentContainers() => GetRegistryEnvironmentContainers();
        /// <summary> Gets a registry environment container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryEnvironmentContainerResource>> GetMachineLearningRegistryEnvironmentContainerAsync(string environmentName, CancellationToken cancellationToken = default) => GetRegistryEnvironmentContainerAsync(environmentName, cancellationToken);
        /// <summary> Gets a registry environment container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryEnvironmentContainerResource> GetMachineLearningRegistryEnvironmentContainer(string environmentName, CancellationToken cancellationToken = default) => GetRegistryEnvironmentContainer(environmentName, cancellationToken);
        /// <summary> Gets registry model containers. </summary>
        public virtual MachineLearningRegistryModelContainerCollection GetMachineLearningRegistryModelContainers() => GetRegistryModelContainers();
        /// <summary> Gets a registry model container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryModelContainerResource>> GetMachineLearningRegistryModelContainerAsync(string modelName, CancellationToken cancellationToken = default) => GetRegistryModelContainerAsync(modelName, cancellationToken);
        /// <summary> Gets a registry model container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryModelContainerResource> GetMachineLearningRegistryModelContainer(string modelName, CancellationToken cancellationToken = default) => GetRegistryModelContainer(modelName, cancellationToken);
    }
}
