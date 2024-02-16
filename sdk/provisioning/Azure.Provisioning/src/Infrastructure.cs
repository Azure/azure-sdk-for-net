// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning
{
    /// <summary>
    /// A class representing a set of <see cref="IConstruct"/> that make up the Azure infrastructure.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Infrastructure : Construct
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Infrastructure"/> class.
        /// </summary>
        /// <param name="constructScope">The <see cref="ConstructScope"/> to use for the root <see cref="IConstruct"/>.</param>
        /// <param name="tenantId">The tenant id to use.  If not passed in will try to load from AZURE_TENANT_ID environment variable.</param>
        /// <param name="subscriptionId">The subscription id to use.  If not passed in will try to load from AZURE_SUBSCRIPTION_ID environment variable.</param>
        /// <param name="envName">The environment name to use.  If not passed in will try to load from AZURE_ENV_NAME environment variable.</param>
        public Infrastructure(ConstructScope constructScope = ConstructScope.Subscription, Guid? tenantId = null, Guid? subscriptionId = null, string? envName = null)
            : base(null, "default", constructScope, tenantId, subscriptionId, envName ?? Environment.GetEnvironmentVariable("AZURE_ENV_NAME") ?? throw new Exception("No environment variable found named 'AZURE_ENV_NAME'"))
        {
        }

        /// <summary>
        /// Converts the infrastructure to Bicep files.
        /// </summary>
        /// <param name="outputPath">Path to put the files.</param>
        public void Build(string? outputPath = null)
        {
            outputPath ??= $".\\{GetType().Name}";
            outputPath = Path.GetFullPath(outputPath);

            Dictionary<Resource, List<Resource>> resourceTree = BuildResourceTree();

            ModuleConstruct? root = null;
            BuildModuleConstructs(Root, resourceTree, null, ref root);

            AddOutputsToModules();

            WriteBicepFile(root!, outputPath);

            var queue = new Queue<ModuleConstruct>();
            queue.Enqueue(root!);
            WriteConstructsByLevel(queue, outputPath);
        }

        private void AddOutputsToModules()
        {
            foreach (var construct in Root.Scope.GetConstructs(true))
            {
                foreach (var output in construct.GetOutputs(false).ToList())
                {
                    output.Resource.ModuleScope!.AddOutput(output);
                }
            }
        }

        private Dictionary<Resource, List<Resource>> BuildResourceTree()
        {
            var resources = GetResources(true);
            Dictionary<Resource, List<Resource>> resourceTree = new();
            HashSet<Resource> visited = new();
            foreach (var resource in resources)
            {
                VisitResource(resource, resourceTree, visited);
            }

            return resourceTree;
        }

        private void VisitResource(Resource resource, Dictionary<Resource, List<Resource>> resourceTree, HashSet<Resource> visited)
        {
            if (!visited.Add(resource))
            {
                return;
            }

            if (!resourceTree.ContainsKey(resource))
            {
                resourceTree[resource] = new List<Resource>();
            }

            if (resource.Parent != null)
            {
                if (!resourceTree.ContainsKey(resource.Parent))
                {
                    resourceTree[resource.Parent] = new List<Resource>();
                }
                resourceTree[resource.Parent].Add(resource);
                VisitResource(resource.Parent, resourceTree, visited);
            }
        }

        private void BuildModuleConstructs(Resource resource, Dictionary<Resource, List<Resource>> resourceTree, ModuleConstruct? parentScope, ref ModuleConstruct? root)
        {
            ModuleConstruct? construct = null;
            if (NeedsModuleConstruct(resource, resourceTree))
            {
                construct = new ModuleConstruct(resource);

                if (parentScope == null)
                {
                    root = construct;
                    construct.IsRoot = true;
                }
            }

            if (construct != null)
            {
                parentScope?.AddConstruct(construct);
            }

            if (parentScope != null)
            {
                parentScope.AddResource(resource);
                resource.ModuleScope = parentScope;
            }

            parentScope = parentScope ?? construct;
            if (parentScope != null)
            {
                foreach (var parameter in resource.Parameters)
                {
                    parentScope.AddParameter(parameter);
                }

                foreach (var parameterOverrideDictionary in resource.ParameterOverrides)
                {
                    foreach (var parameterOverride in parameterOverrideDictionary.Value)
                    {
                        parameterOverride.Value.Source = parentScope;
                        parameterOverride.Value.Value = GetParameterValue(parameterOverride.Value, parentScope);
                    }
                }

                // foreach (var output in resource.Scope.GetOutputs(false))
                // {
                //     var moduleOutput = new Output(output.Name, output.Value, parentScope, resource, output.IsLiteral, output.IsSecure);
                //     parentScope.AddOutput(moduleOutput);
                // }
            }

            foreach (var child in resourceTree[resource])
            {
                BuildModuleConstructs(child, resourceTree, construct ?? parentScope, ref root);
            }
        }

        private static string GetParameterValue(Parameter parameter, IConstruct scope)
        {
            // If the parameter is a parameter of the module scope, use the parameter name.
            if (scope.GetParameters(false).Contains(parameter))
            {
                return parameter.Name;
            }
            // Otherwise we assume it is an output from the current module.
            if ( parameter.Source is null || ReferenceEquals(parameter.Source, scope))
            {
                return parameter.Value!;
            }

            return $"{parameter.Source.Name}.outputs.{parameter.Name}";
        }

        private static ConstructScope ResourceToConstructScope(Resource resource)
        {
            return resource switch
            {
                Tenant => ConstructScope.Tenant,
                ResourceManager.Subscription => ConstructScope.Subscription,
                //TODO managementgroup support
                ResourceManager.ResourceGroup => ConstructScope.ResourceGroup,
                _ => throw new InvalidOperationException(),
            };
        }

        private bool NeedsModuleConstruct(Resource resource, Dictionary<Resource, List<Resource>> resourceTree)
        {
            if (!(resource is Tenant || resource is Subscription || resource is ResourceGroup))
            {
                return false;
            }
            if (resource is Tenant)
            {
                // TODO add management group check
                return resourceTree[resource].Count > 1;
            }
            if (resource is Subscription || resource is ResourceGroup)
            {
                // TODO add policy support
                return resourceTree[resource].Count > 0;
            }

            return false;
        }

        private void WriteConstructsByLevel(Queue<ModuleConstruct> constructs, string outputPath)
        {
            while (constructs.Count > 0)
            {
                var construct = constructs.Dequeue();
                foreach (var child in construct.GetConstructs(false))
                {
                    constructs.Enqueue((ModuleConstruct)child);
                }
                WriteBicepFile(construct, outputPath);
            }
        }

        private string GetFilePath(ModuleConstruct construct, string outputPath)
        {
            string fileName = construct.IsRoot ? Path.Combine(outputPath, "main.bicep") : Path.Combine(outputPath, "resources", construct.Name, $"{construct.Name}.bicep");
            Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
            return fileName;
        }

        private void WriteBicepFile(ModuleConstruct construct, string outputPath)
        {
            using var stream = new FileStream(GetFilePath(construct, outputPath), FileMode.Create);
#if NET6_0_OR_GREATER
            stream.Write(ModelReaderWriter.Write(construct, new ModelReaderWriterOptions("bicep")));
#else
            BinaryData data = ModelReaderWriter.Write(construct, new ModelReaderWriterOptions("bicep"));
            var buffer = data.ToArray();
            stream.Write(buffer, 0, buffer.Length);
#endif
        }

        private class ModuleConstruct : Construct
        {
            public ModuleConstruct(Resource resource)
                : base(
                    resource.Scope,
                    resource is Subscription ? resource.Name : resource.Id.Name.Replace('-', '_'),
                    ResourceToConstructScope(resource),
                    subscriptionId: resource is not Tenant ? Guid.Parse(resource.Id.SubscriptionId!) : null,
                    resourceGroup: resource as ResourceGroup)
            {
            }

            public bool IsRoot { get; set; }
        }
    }
}
