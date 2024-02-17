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
    internal class ModuleInfrastructure
    {
        private readonly Infrastructure _infrastructure;
        private readonly ModuleConstruct _rootConstruct;

        public ModuleInfrastructure(Infrastructure infrastructure)
        {
            _infrastructure = infrastructure;
            Dictionary<Resource, List<Resource>> resourceTree = BuildResourceTree();

            ModuleConstruct? root = null;
            BuildModuleConstructs(_infrastructure.Root, resourceTree, null, ref root);
            _rootConstruct = root!;

            AddOutputsToModules();
        }

        public void Write(string? outputPath = null)
        {
            outputPath ??= $".\\{GetType().Name}";
            outputPath = Path.GetFullPath(outputPath);

            WriteBicepFile(_rootConstruct, outputPath);

            var queue = new Queue<ModuleConstruct>();
            queue.Enqueue(_rootConstruct);
            WriteConstructsByLevel(queue, outputPath);
        }

        private void AddOutputsToModules()
        {
            // Get all of the user-defined constructs in addition to the Infrastructure construct
            foreach (var construct in _infrastructure.GetConstructs(true).Concat(new[] { _infrastructure }))
            {
                // ToList to avoid modifying the collection while iterating
                foreach (var output in construct.GetOutputs(false).ToList())
                {
                    var moduleOutput = new Output(
                        output.Name,
                        output.Value,
                        output.Resource.ModuleScope!,
                        output.Resource,
                        output.IsLiteral,
                        output.IsSecure);

                    output.Resource.ModuleScope!.AddOutput(moduleOutput);
                }
            }
        }

        private Dictionary<Resource, List<Resource>> BuildResourceTree()
        {
            var resources = _infrastructure.GetResources(true);
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
            var moduleResource = new ModuleResource(resource, parentScope);

            if (NeedsModuleConstruct(resource, resourceTree))
            {
                construct = new ModuleConstruct(moduleResource);

                if (parentScope == null)
                {
                    root = construct;
                    construct.IsRoot = true;
                    parentScope = construct;
                }
            }

            if (parentScope != null)
            {
                parentScope.AddResource(resource);
                resource.ModuleScope = parentScope;
            }

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
    }
}
