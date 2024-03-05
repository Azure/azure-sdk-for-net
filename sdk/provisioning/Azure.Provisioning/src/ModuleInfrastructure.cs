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
        private ModuleConstruct? _rootConstruct;

        public ModuleInfrastructure(Infrastructure infrastructure)
        {
            _infrastructure = infrastructure;
            Dictionary<Resource, List<Resource>> resourceTree = BuildResourceTree();

            BuildModuleConstructs(_infrastructure.Root, resourceTree, null);

            AddOutputsToModules();
        }

        public void Write(string? outputPath = null)
        {
            outputPath ??= $".\\{GetType().Name}";
            outputPath = Path.GetFullPath(outputPath);

            WriteBicepFile(_rootConstruct!, outputPath);

            var queue = new Queue<ModuleConstruct>();
            queue.Enqueue(_rootConstruct!);
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
                    output.Resource.ModuleScope!.AddOutput(output);
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

        private void BuildModuleConstructs(Resource resource, Dictionary<Resource, List<Resource>> resourceTree, ModuleConstruct? parentScope)
        {
            ModuleConstruct? construct = null;
            var moduleResource = new ModuleResource(resource, parentScope);

            if (NeedsModuleConstruct(resource, resourceTree))
            {
                construct = new ModuleConstruct(moduleResource);

                if (parentScope == null)
                {
                    construct.IsRoot = true;
                    _rootConstruct = construct;
                }
            }

            if (parentScope != null)
            {
                parentScope.AddResource(resource);
                resource.ModuleScope = parentScope;
            }

            parentScope ??= construct;

            if (parentScope != null)
            {
                foreach (var parameter in resource.Scope.GetParameters(false))
                {
                    parentScope.AddParameter(parameter);
                }

                foreach (var typeDictPair in resource.PropertyOverrides)
                {
                    // ToList to avoid modifying the collection while iterating
                    foreach (var propertyParameterPair in typeDictPair.Value.ToList())
                    {
                        var parameterToCopy = propertyParameterPair.Value.Parameter;
                        if (parameterToCopy == null)
                        {
                            continue;
                        }
                        resource.PropertyOverrides[typeDictPair.Key][propertyParameterPair.Key] = new PropertyOverride(parameter: new Parameter(
                            parameterToCopy.Value.Name,
                            parameterToCopy.Value.Description,
                            parameterToCopy.Value.DefaultValue,
                            parameterToCopy.Value.IsSecure,
                            parentScope,
                            parameterToCopy.Value.Value,
                            parameterToCopy.Value.Output));
                    }
                }
            }

            foreach (var child in resourceTree[resource])
            {
                BuildModuleConstructs(child, resourceTree, construct ?? parentScope);
            }
        }

        private bool NeedsModuleConstruct(Resource resource, Dictionary<Resource, List<Resource>> resourceTree)
        {
            if (resource is not (Tenant or Subscription or ResourceGroup))
            {
                return false;
            }
            if (resource is Tenant)
            {
                // TODO add management group check
                return resourceTree[resource].Count > 1;
            }

            if (resource is Subscription)
            {
                foreach (var child in resourceTree[resource])
                {
                    if (child is not ResourceGroup || (child is ResourceGroup && child.Id.Name != ResourceGroup.ResourceGroupFunction))
                    {
                        return true;
                    }
                }
            }

            if (resource is ResourceGroup && !resource.IsExisting)
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
            stream.Write(construct.SerializeModule());
#else
            BinaryData data = construct.SerializeModule();
            var buffer = data.ToArray();
            stream.Write(buffer, 0, buffer.Length);
#endif
        }
    }
}
