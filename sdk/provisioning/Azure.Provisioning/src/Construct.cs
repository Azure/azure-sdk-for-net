// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Provisioning.ResourceManager;
using Microsoft.Extensions.Azure;

namespace Azure.Provisioning
{
    /// <summary>
    /// Basic building block of a set of resources in Azure.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Construct : IConstruct, IPersistableModel<Construct>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Construct"/> class.
        /// </summary>
        /// <param name="scope">The scope the construct belongs to.</param>
        /// <param name="name">The name of the construct.</param>
        /// <param name="constructScope">The <see cref="ConstructScope"/> the construct is.</param>
        /// <param name="tenantId">The tenant id to use.  If not passed in will try to load from AZURE_TENANT_ID environment variable.</param>
        /// <param name="subscriptionId">The subscription id to use.  If not passed in will try to load from AZURE_SUBSCRIPTION_ID environment variable.</param>
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
            if (scope is null && constructScope == ConstructScope.ResourceGroup)
            {
                throw new ArgumentException($"Scope cannot be null if construct scope is is {nameof(ConstructScope.ResourceGroup)}");
            }

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
                ResourceGroup = resourceGroup ?? scope!.ResourceGroup ?? scope.GetOrAddResourceGroup();
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

        private string GetScopeName()
        {
            return ResourceGroup?.Name ?? (Subscription != null ? $"subscription('{Subscription.Name}')" : "tenant()");
        }

        private BinaryData SerializeModuleReference(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            stream.WriteLine($"module {Name} './resources/{Name}/{Name}.bicep' = {{");
            stream.WriteLine($"  name: '{Name}'");
            stream.WriteLine($"  scope: {GetScopeName()}");

            var parametersToWrite = new HashSet<Parameter>();
            var outputs = new HashSet<Output>(GetOutputs());
            foreach (var p in GetParameters(false))
            {
                if (!ShouldExposeParameter(p, outputs))
                {
                    continue;
                }
                parametersToWrite.Add(p);
            }
            if (parametersToWrite.Count > 0)
            {
                stream.WriteLine($"  params: {{");
                foreach (var parameter in parametersToWrite)
                {
                    stream.WriteLine($"    {parameter.Name}: {parameter.GetParameterString(Scope!)}");
                }
                stream.WriteLine($"  }}");
            }
            stream.WriteLine($"}}");

            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        private BinaryData SerializeModule(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();

            WriteScopeLine(stream);

            WriteParameters(stream);

            WriteExistingResources(stream);

            foreach (var resource in GetResources(false))
            {
                if (resource is Tenant)
                {
                    continue;
                }
                stream.WriteLine();
                WriteLines(0, ModelReaderWriter.Write(resource, options), stream, resource);
            }

            foreach (var construct in GetConstructs(false))
            {
                stream.WriteLine();
                stream.Write(ModelReaderWriter.Write(construct, new ModelReaderWriterOptions("bicep-module")).ToArray());
            }

            WriteOutputs(stream);

            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        private void WriteExistingResources(MemoryStream stream)
        {
            foreach (var resource in _existingResources)
            {
                stream.WriteLine();
                stream.WriteLine($"resource {resource.Name} '{resource.Id.ResourceType}@{resource.Version}' existing = {{");
                stream.WriteLine($"  name: '{resource.Name}'");
                stream.WriteLine($"}}");
            }
        }

        private void WriteScopeLine(MemoryStream stream)
        {
            if (ConstructScope != ConstructScope.ResourceGroup)
            {
                stream.WriteLine($"targetScope = '{ConstructScope.ToString().ToCamelCase()}'{Environment.NewLine}");
            }
        }

        internal void WriteOutputs(MemoryStream stream)
        {
            if (GetOutputs().Any())
            {
                stream.WriteLine();
            }

            var outputsToWrite = new HashSet<Output>();
            GetAllOutputsRecursive(this, outputsToWrite, false);
            foreach (var output in outputsToWrite)
            {
                string value;
                if (output.IsLiteral || ReferenceEquals(this, output.Resource.ModuleScope))
                {
                    value = output.IsLiteral ? $"'{output.Value}'" : output.Value;
                }
                else
                {
                    value = $"{output.Resource.ModuleScope!.Name}.outputs.{output.Name}";
                }
                string name = output.Name;
                stream.WriteLine($"output {name} string = {value}");
            }
        }

        private void GetAllOutputsRecursive(IConstruct construct, HashSet<Output> visited, bool isChild)
        {
            if (!isChild)
            {
                foreach (var output in construct.GetOutputs())
                {
                    if (!visited.Contains(output))
                    {
                        visited.Add(output);
                    }
                }
            }
        }

        private void WriteParameters(MemoryStream stream)
        {
            var parametersToWrite = new HashSet<Parameter>();
            GetAllParametersRecursive(this, parametersToWrite, false);
            var outputs = new HashSet<Output>(GetOutputs());
            foreach (var parameter in parametersToWrite)
            {
                if (!ShouldExposeParameter(parameter, outputs))
                {
                    continue;
                }
                string defaultValue = parameter.DefaultValue is null ? string.Empty : $" = '{parameter.DefaultValue}'";

                if (parameter.IsSecure)
                    stream.WriteLine($"@secure()");

                stream.WriteLine($"@description('{parameter.Description}')");
                stream.WriteLine($"param {parameter.Name} string{defaultValue}{Environment.NewLine}");
            }
        }

        private bool ShouldExposeParameter(Parameter parameter, HashSet<Output> outputs)
        {
            // Don't expose the parameter if the output that was used to create the parameter is already in scope.
            return parameter.Output == null || !outputs.Contains(parameter.Output);
        }

        private void GetAllParametersRecursive(IConstruct construct, HashSet<Parameter> visited, bool isChild)
        {
            if (!isChild)
            {
                foreach (var parameter in construct.GetParameters())
                {
                    if (!visited.Contains(parameter))
                    {
                        visited.Add(parameter);
                    }
                }
                foreach (var child in construct.GetConstructs(false))
                {
                    GetAllParametersRecursive(child, visited, isChild);
                }
            }
        }

        private static void WriteLines(int depth, BinaryData data, MemoryStream stream, Resource resource)
        {
            string indent = new string(' ', depth * 2);
            string[] lines = data.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                string lineToWrite = lines[i];

                ReadOnlySpan<char> line = lines[i].AsSpan();
                int start = 0;
                while (line.Length > start && line[start] == ' ')
                {
                    start++;
                }
                line = line.Slice(start);
                int end = line.IndexOf(':');
                if (end > 0)
                {
                    // foo: 1
                    // foo: 'something.url'
                    string name = line.Slice(0, end).ToString();
                    if (resource.ParameterOverrides.TryGetValue(name, out var value))
                    {
                        lineToWrite = $"{new string(' ', start)}{name}: {value}";
                    }
                }
                stream.WriteLine($"{indent}{lineToWrite}");
            }
        }

        BinaryData IPersistableModel<Construct>.Write(ModelReaderWriterOptions options) => (options.Format) switch
        {
            "bicep" => SerializeModule(options),
            "bicep-module" => SerializeModuleReference(options),
            _ => throw new FormatException($"Unsupported format {options.Format}")
        };

        Construct IPersistableModel<Construct>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<Construct>.GetFormatFromOptions(ModelReaderWriterOptions options) => "bicep";
    }
}
