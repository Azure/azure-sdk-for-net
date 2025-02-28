// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using Azure.Generator.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator
{
    internal class ResourceBuilder
    {
        private Dictionary<string, HashSet<OperationSet>> _specNameToResourceOperationSetMap;

        public bool IsResource(string name) => _specNameToResourceOperationSetMap.ContainsKey(name);

        private IEnumerable<OperationSet>? _resourceOperationSets;
        public IEnumerable<OperationSet> ResourceOperationSets => _resourceOperationSets ??= _specNameToResourceOperationSetMap.Values.SelectMany(x => x);

        public ResourceBuilder()
        {
            _specNameToResourceOperationSetMap = EnsureOperationsetMap();
        }

        public IReadOnlyList<(InputClient ResourceClient, string RequestPath, bool IsSingleton, string RequestType, string SpecName)> BuildResourceClients()
        {
            var result = new List<(InputClient ResourceClient, string RequestPath, bool IsSingleton, string RequestType, string SpecName)>();
            var singletonDetection = new SingletonDetection();
            foreach ((var schemaName, var operationSets) in _specNameToResourceOperationSetMap)
            {
                foreach (var operationSet in operationSets)
                {
                    var requestPath = operationSet.RequestPath;
                    var resourceType = ResourceDetection.GetResourceTypeFromPath(requestPath);
                    var isSingleton = singletonDetection.IsSingletonResource(operationSet.InputClient, requestPath);
                    var requestType = ResourceDetection.GetResourceTypeFromPath(requestPath); ;
                    result.Add((operationSet.InputClient, operationSet.RequestPath, isSingleton, requestType, schemaName));
                }
            }
            return result;
        }

        private Dictionary<string, HashSet<OperationSet>> EnsureOperationsetMap()
        {
            var pathToOperationSetMap = CategorizeClients();
            var result = new Dictionary<string, HashSet<OperationSet>>();
            foreach (var operationSet in pathToOperationSetMap.Values)
            {
                if (AzureClientPlugin.Instance.ResourceDetection.TryGetResourceDataSchema(operationSet, operationSet.RequestPath, out var resourceSpecName, out var resourceSchema))
                {
                    // if this operation set corresponds to a SDK resource, we add it to the map
                    if (!result.TryGetValue(resourceSpecName!, out HashSet<OperationSet>? value))
                    {
                        value = new HashSet<OperationSet>();
                        result.Add(resourceSpecName!, value);
                    }
                    value.Add(operationSet);
                }
            }

            return result;
        }

        private Dictionary<RequestPath, OperationSet> CategorizeClients()
        {
            var result = new Dictionary<RequestPath, OperationSet>();
            foreach (var inputClient in AzureClientPlugin.Instance.InputLibrary.InputNamespace.Clients)
            {
                foreach (var operation in inputClient.Operations)
                {
                    var path = operation.GetHttpPath();
                    if (result.TryGetValue(path, out var operationSet))
                    {
                        operationSet.Add(operation);
                    }
                    else
                    {
                        operationSet = new OperationSet(path, inputClient)
                        {
                            operation
                        };
                        result.Add(path, operationSet);
                    }
                }
            }

            // TODO: add operation set for the partial resources here

            return result;
        }
    }
}
