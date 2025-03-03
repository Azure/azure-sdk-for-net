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
        private Dictionary<string, (RequestPath, InputClient)> _specNameToResourceClientMap;

        public bool IsResource(string name) => _specNameToResourceClientMap.ContainsKey(name);

        private IEnumerable<RequestPath>? _resourcePaths;
        public IEnumerable<RequestPath> ResourcePaths => _resourcePaths ??= _specNameToResourceClientMap.Values.Select(x => x.Item1);

        public ResourceBuilder()
        {
            _specNameToResourceClientMap = EnsureOperationsetMap();
        }

        public IReadOnlyList<(InputClient ResourceClient, string RequestPath, bool IsSingleton, string RequestType, string SpecName)> BuildResourceClients()
        {
            var result = new List<(InputClient ResourceClient, string RequestPath, bool IsSingleton, string RequestType, string SpecName)>();
            var singletonDetection = new SingletonDetection();
            foreach ((string schemaName, (RequestPath requestPath, InputClient client)) in _specNameToResourceClientMap)
            {
                var resourceType = ResourceDetection.GetResourceTypeFromPath(requestPath);
                var isSingleton = singletonDetection.IsSingletonResource(client, requestPath);
                result.Add((client, requestPath, isSingleton, resourceType, schemaName));
            }
            return result;
        }

        private Dictionary<string, (RequestPath ResourcePath, InputClient Client)> EnsureOperationsetMap()
        {
            var pathToOperationSetMap = CategorizeClients();
            var result = new Dictionary<string, (RequestPath, InputClient)>();
            foreach (var (requestPath, client) in pathToOperationSetMap)
            {
                if (AzureClientPlugin.Instance.ResourceDetection.TryGetResourceDataSchema(client.Operations, requestPath, out var resourceSpecName, out var resourceSchema))
                {
                    // if this operation set corresponds to a SDK resource, we add it to the map
                    if (!result.ContainsKey(resourceSpecName))
                    {
                        result.Add(resourceSpecName, (requestPath, client));
                    }
                }
            }

            return result;
        }

        private Dictionary<RequestPath, InputClient> CategorizeClients()
        {
            var result = new Dictionary<RequestPath, InputClient>();
            foreach (var inputClient in AzureClientPlugin.Instance.InputLibrary.InputNamespace.Clients)
            {
                foreach (var operation in inputClient.Operations)
                {
                    var path = operation.GetHttpPath();
                    if (!result.ContainsKey(path))
                    {
                        result.Add(path, inputClient);
                    }
                }
            }

            // TODO: add operation set for the partial resources here

            return result;
        }
    }
}
