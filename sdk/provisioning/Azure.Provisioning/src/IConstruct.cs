// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning
{
    /// <summary>
    /// Interface for a construct.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public interface IConstruct
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Gets the name of the construct.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the environment name of the construct.
        /// </summary>
        public string EnvironmentName { get; }

        /// <summary>
        /// Gets the <see cref="Provisioning.ConstructScope"/> scope.
        /// </summary>
        public ConstructScope ConstructScope { get; }
        /// <summary>
        /// Gets the <see cref="Tenant"/> for the construct."/>.
        /// </summary>
        public Tenant Root { get; }
        /// <summary>
        /// Gets the <see cref="ResourceManager.ResourceGroup"/> for the construct.
        /// </summary>
        public ResourceGroup? ResourceGroup { get; }
        /// <summary>
        /// Gets the <see cref="ResourceManager.Subscription"/> for the construct.
        /// </summary>
        public Subscription? Subscription { get; }

        /// <summary>
        /// Gets the configuration for the construct.
        /// </summary>
        public Configuration? Configuration { get; }

        /// <summary>
        /// Gets the parent of the construct.
        /// </summary>
        public IConstruct? Scope { get; }

        /// <summary>
        /// Gets all outputs in the construct.
        /// </summary>
        /// <param name="recursive">Include all child constructs.</param>
        public IEnumerable<Output> GetOutputs(bool recursive = true);
        /// <summary>
        /// Gets all parameters in the construct.
        /// </summary>
        /// <param name="recursive">Include all child constructs.</param>
        public IEnumerable<Parameter> GetParameters(bool recursive = true);
        /// <summary>
        /// Gets all resources in the construct.
        /// </summary>
        /// <param name="recursive">Include all child constructs.</param>
        public IEnumerable<Resource> GetResources(bool recursive = true);
        /// <summary>
        /// Gets all child constructs in the construct.
        /// </summary>
        /// <param name="recursive">Include all child constructs.</param>
        public IEnumerable<IConstruct> GetConstructs(bool recursive = true);
        /// <summary>
        /// Adds a resource to the construct.
        /// </summary>
        /// <param name="resource">The <see cref="Resource"/> to add.</param>
        public void AddResource(Resource resource);
        /// <summary>
        /// Adds a child construct to the construct.
        /// </summary>
        /// <param name="construct">The <see cref="IConstruct"/> to add.</param>
        public void AddConstruct(IConstruct construct);
        /// <summary>
        /// Adds a parameter to the construct.
        /// </summary>
        /// <param name="parameter">The <see cref="Parameter"/> to add.</param>
        public void AddParameter(Parameter parameter);
        /// <summary>
        /// Adds an output to the construct.
        /// </summary>
        /// <param name="output">The <see cref="Output"/> to add.</param>
        public void AddOutput(Output output);
    }
}
