// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning
{
    /// <summary>
    /// Basic building block of a set of resources in Azure.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Construct : IConstruct
#pragma warning restore AZC0012 // Avoid single word type names
    {
        private List<Parameter> _parameters;
        private List<Resource> _resources;
        private List<IConstruct> _constructs;
        private List<Output> _outputs;
        private List<Resource> _existingResources;
        private string? _environmentName;

        /// <inheritdoc/>
        public string Name { get; }
        /// <inheritdoc/>
        public string EnvironmentName => GetEnvironmentName();
        /// <inheritdoc/>
        public IConstruct? Scope { get; }
        /// <inheritdoc/>
        public ResourceGroup? ResourceGroup { get; protected set; }
        /// <inheritdoc/>
        public Subscription? Subscription { get; }
        /// <inheritdoc/>
        public Tenant Root { get; }
        /// <inheritdoc/>
        public ConstructScope ConstructScope { get; }
        /// <inheritdoc/>
        public Configuration? Configuration
        {
            get
            {
                return Scope == null ? _configuration : Scope.Configuration;
            }
            internal set
            {
                _configuration = value;
            }
        }
        private Configuration? _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Construct"/> class.
        /// </summary>
        /// <param name="scope">The scope the construct belongs to.</param>
        /// <param name="name">The name of the construct.</param>
        /// <param name="constructScope">The <see cref="ConstructScope"/> the construct is.</param>
        /// <param name="tenantId">The tenant id to use.  If not passed in will try to load from AZURE_TENANT_ID environment variable.</param>
        /// <param name="subscriptionId">The subscription id to use.  If not passed, the subscription will be loaded from the deployment context.</param>
        /// <param name="envName">The environment name to use.  If not passed in will try to load from AZURE_ENV_NAME environment variable.</param>
        /// <param name="resourceGroup"></param>
        /// <exception cref="ArgumentException"><paramref name="constructScope"/> is <see cref="ConstructScope.ResourceGroup"/> and <paramref name="scope"/> is null.</exception>
        protected Construct(IConstruct? scope, string name, ConstructScope constructScope = ConstructScope.ResourceGroup, Guid? tenantId = null, Guid? subscriptionId = null, string? envName = null, ResourceGroup? resourceGroup = null)
            : this(scope, name, constructScope, tenantId, subscriptionId, envName, null, null, resourceGroup)
        {
        }

        internal Construct(
            IConstruct? scope,
            string name,
            ConstructScope constructScope,
            Guid? tenantId = default,
            Guid? subscriptionId = default,
            string? envName = default,
            Tenant? tenant = default,
            Subscription? subscription = default,
            ResourceGroup? resourceGroup = default)
        {
            Scope = scope;
            Scope?.AddConstruct(this);
            _resources = new List<Resource>();
            _outputs = new List<Output>();
            _parameters = new List<Parameter>();
            _constructs = new List<IConstruct>();
            _existingResources = new List<Resource>();
            Name = name;
            Root = tenant ?? scope?.Root ?? new Tenant(this, tenantId);
            ConstructScope = constructScope;
            if (constructScope == ConstructScope.ResourceGroup)
            {
                ResourceGroup = resourceGroup ?? scope?.ResourceGroup ?? scope?.GetOrAddResourceGroup();
            }
            if (constructScope == ConstructScope.Subscription)
            {
                Subscription = subscription ?? (scope is null ? this.GetOrCreateSubscription(subscriptionId) : scope.Subscription ?? scope.GetOrCreateSubscription(subscriptionId));
            }

            _environmentName = envName;
        }

        private string GetEnvironmentName()
        {
            return _environmentName is null ? Scope!.EnvironmentName : _environmentName;
        }

        /// <summary>
        /// Registers an existing resource with this construct that will be used by other resources in the construct.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Resource"/> to use.</typeparam>
        /// <param name="resource">Resource instance to use.</param>
        /// <param name="create">Lambda to create the resource if it was not found.</param>
        /// <returns>The <see cref="Resource"/> instance that will be used.</returns>
        protected T UseExistingResource<T>(T? resource, Func<T> create) where T : Resource
        {
            var result = resource ?? this.GetSingleResource<T>() ?? create();
            _existingResources.Add(result);
            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<Resource> GetResources(bool recursive = true)
        {
            IEnumerable<Resource> result = _resources;
            if (recursive)
            {
                result = result.Concat(GetConstructs(false).SelectMany(c => c.GetResources(true)));
            }
            return result;
        }

        internal IEnumerable<Resource> GetExistingResources(bool recursive = true)
        {
            IEnumerable<Resource> result = _existingResources;
            if (recursive)
            {
                result = result.Concat(GetConstructs(false).SelectMany(c => ((Construct)c).GetExistingResources(true)));
            }
            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<IConstruct> GetConstructs(bool recursive = true)
        {
            IEnumerable<IConstruct> result = _constructs;
            if (recursive)
            {
                result = result.Concat(GetConstructs(false).SelectMany(c => c.GetConstructs(true)));
            }
            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<Parameter> GetParameters(bool recursive = true)
        {
            IEnumerable<Parameter> result = _parameters;
            if (recursive)
            {
                result = result.Concat(GetConstructs(false).SelectMany(c => c.GetParameters(true)));
            }
            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<Output> GetOutputs(bool recursive = true)
        {
            IEnumerable<Output> result = _outputs;
            if (recursive)
            {
                result = result.Concat(GetConstructs(false).SelectMany(c => c.GetOutputs(true)));
            }
            return result;
        }

        /// <inheritdoc/>
        public void AddResource(Resource resource)
        {
            _resources.Add(resource);
        }

        /// <inheritdoc/>
        public void AddConstruct(IConstruct construct)
        {
            _constructs.Add(construct);
        }

        /// <inheritdoc/>
        public void AddParameter(Parameter parameter)
        {
            _parameters.Add(parameter);
        }

        /// <inheritdoc/>
        public void AddOutput(Output output)
        {
            _outputs.Add(output);
        }
    }
}
