// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using Azure.Generator.Providers;
using Azure.Generator.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        // TODO: categorize clients into operationSets, which contains operations sharing the same Path
        private Dictionary<string, OperationSet> _pathToOperationSetMap;
        private Dictionary<string, HashSet<OperationSet>> _resourceDataBySpecNameMap;

        /// <inheritdoc/>
        public AzureOutputLibrary()
        {
            _pathToOperationSetMap = CategorizeClients();
            _resourceDataBySpecNameMap = EnsureResourceDataMap();
        }

        private Dictionary<string, HashSet<OperationSet>> EnsureResourceDataMap()
        {
            var result = new Dictionary<string, HashSet<OperationSet>>();
            foreach (var operationSet in _pathToOperationSetMap.Values)
            {
                if (AzureClientPlugin.Instance.ResourceDetection.TryGetResourceDataSchema(operationSet, out var resourceSpecName, out var resourceSchema))
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

        private Dictionary<string, OperationSet> CategorizeClients()
        {
            var result = new Dictionary<string, OperationSet>();
            foreach (var inputClient in AzureClientPlugin.Instance.InputLibrary.InputNamespace.Clients)
            {
                var requestPathList = new HashSet<string>();
                foreach (var operation in inputClient.Operations)
                {
                    var path = operation.GetHttpPath();
                    requestPathList.Add(path);
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

        /// <inheritdoc/>
        // TODO: generate resources and collections
        protected override TypeProvider[] BuildTypeProviders()
        {
            if (AzureClientPlugin.Instance.IsAzureArm.Value == true)
            {
                var armOperation = new MgmtLongRunningOperationProvider(false);
                var genericArmOperation = new MgmtLongRunningOperationProvider(true);

                // TODO: remove them once they are referenced in Resource operation implementation
                AzureClientPlugin.Instance.AddTypeToKeep(armOperation.Name);
                AzureClientPlugin.Instance.AddTypeToKeep(genericArmOperation.Name);
                return [.. base.BuildTypeProviders(), new RequestContextExtensionsDefinition(), armOperation, genericArmOperation];
            }
            return [.. base.BuildTypeProviders(), new RequestContextExtensionsDefinition()];
        }

        internal bool IsResource(string name) => _resourceDataBySpecNameMap.ContainsKey(name);
    }
}
