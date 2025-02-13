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

        private MgmtLongRunningOperationProvider? _armOperation;
        internal MgmtLongRunningOperationProvider ArmOperation => _armOperation ??= new MgmtLongRunningOperationProvider(false);

        private MgmtLongRunningOperationProvider? _genericArmOperation;
        internal MgmtLongRunningOperationProvider GenericArmOperation => _genericArmOperation ??= new MgmtLongRunningOperationProvider(true);

        private IReadOnlyList<ResourceProvider> BuildResources()
        {
            var result = new List<ResourceProvider>();
            foreach ((var schemaName, var operationSets) in _specNameToOperationSetsMap)
            {
                var model = _inputTypeMap[schemaName];
                var resourceData = (ResourceDataProvider)AzureClientPlugin.Instance.TypeFactory.CreateModel(model)!;
                foreach (var operationSet in operationSets)
                {
                    var requestPath = operationSet.RequestPath;
                    var resourceType = ResourceDetection.GetResourceTypeFromPath(requestPath);
                    var resource = new ResourceProvider(operationSet, schemaName, resourceData, resourceType);
                    AzureClientPlugin.Instance.AddTypeToKeep(resource.Name);
                    result.Add(resource);
                }
            }
            return result;
        }

        private Dictionary<string, HashSet<OperationSet>> EnsureOperationsetMap()
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
            if (AzureClientPlugin.Instance.IsAzureArm.Value == true)
            {
                BuildLROProviders();
                return [.. base.BuildTypeProviders(), new RequestContextExtensionsDefinition(), ArmOperation, GenericArmOperation, .. BuildResources()];
            }
            return [.. base.BuildTypeProviders(), new RequestContextExtensionsDefinition()];
        }

        private void BuildLROProviders()
        {
            // TODO: remove them once they are referenced in Resource operation implementation
            AzureClientPlugin.Instance.AddTypeToKeep(ArmOperation.Name);
            AzureClientPlugin.Instance.AddTypeToKeep(GenericArmOperation.Name);
        }

        internal bool IsResource(string name) => _specNameToOperationSetsMap.ContainsKey(name);

        internal Lazy<IEnumerable<OperationSet>> ResourceOperationSets => new(() => _specNameToOperationSetsMap.Values.SelectMany(x => x));
    }
}
