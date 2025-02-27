// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using Azure.Generator.Providers;
using Azure.Generator.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        //TODO: Move these to InputLibrary instead
        private Dictionary<RequestPath, OperationSet> _pathToOperationSetMap;
        private Dictionary<string, HashSet<OperationSet>> _specNameToOperationSetsMap;
        private Dictionary<string, InputModelType> _inputTypeMap;

        /// <inheritdoc/>
        public AzureOutputLibrary()
        {
            _pathToOperationSetMap = CategorizeClients();
            _specNameToOperationSetsMap = EnsureOperationsetMap();
            _inputTypeMap = AzureClientPlugin.Instance.InputLibrary.InputNamespace.Models.OfType<InputModelType>().ToDictionary(model => model.Name);
        }

        private LongRunningOperationProvider? _armOperation;
        internal LongRunningOperationProvider ArmOperation => _armOperation ??= new LongRunningOperationProvider(false);

        private LongRunningOperationProvider? _genericArmOperation;
        internal LongRunningOperationProvider GenericArmOperation => _genericArmOperation ??= new LongRunningOperationProvider(true);

        private IReadOnlyList<TypeProvider> BuildResources()
        {
            var result = new List<TypeProvider>();
            foreach ((var schemaName, var operationSets) in _specNameToOperationSetsMap)
            {
                var model = _inputTypeMap[schemaName];
                var resourceData = AzureClientPlugin.Instance.TypeFactory.CreateModel(model)!;
                foreach (var operationSet in operationSets)
                {
                    var requestPath = operationSet.RequestPath;
                    var resourceType = ResourceDetection.GetResourceTypeFromPath(requestPath);
                    TypeProvider resource = CreateResourceCore(operationSet, operationSet.InputClient, operationSet.RequestPath, schemaName, resourceData, resourceType);
                    AzureClientPlugin.Instance.AddTypeToKeep(resource.Name);
                    result.Add(resource);
                }
            }
            return result;
        }

        /// <summary>
        /// Create a resource client provider
        /// </summary>
        /// <param name="operationSet"></param>
        /// <param name="inputClient"></param>
        /// <param name="requestPath"></param>
        /// <param name="schemaName"></param>
        /// <param name="resourceData"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        public virtual TypeProvider CreateResourceCore(IReadOnlyCollection<InputOperation> operationSet, InputClient inputClient, string requestPath, string schemaName, ModelProvider resourceData, string resourceType)
        {
            return new ResourceClientProvider(operationSet, inputClient, requestPath, schemaName, resourceData, resourceType);
        }

        private Dictionary<string, HashSet<OperationSet>> EnsureOperationsetMap()
        {
            var result = new Dictionary<string, HashSet<OperationSet>>();
            foreach (var operationSet in _pathToOperationSetMap.Values)
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

        /// <inheritdoc/>
        // TODO: generate collections
        protected override TypeProvider[] BuildTypeProviders()
        {
            var baseProviders = base.BuildTypeProviders();
            if (AzureClientPlugin.Instance.IsAzureArm.Value == true)
            {
                var resources = BuildResources();
                return [.. baseProviders, new RequestContextExtensionsDefinition(), ArmOperation, GenericArmOperation, .. resources, .. resources.Select(r => ((ResourceClientProvider)r).Source)];
            }
            return [.. baseProviders, new RequestContextExtensionsDefinition()];
        }

        internal bool IsResource(string name) => _specNameToOperationSetsMap.ContainsKey(name);

        internal Lazy<IEnumerable<OperationSet>> ResourceOperationSets => new(() => _specNameToOperationSetsMap.Values.SelectMany(x => x));
    }
}
