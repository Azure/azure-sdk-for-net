// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using Azure.Generator.Providers;
using Azure.Generator.Utilities;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        // TODO: categorize clients into operationSets, which contains operations sharing the same Path
        private Dictionary<string, OperationSet> _pathToOperationSetMap;
        private Dictionary<string, HashSet<OperationSet>> _resourceDataMap;
        private HashSet<string> _resourceDataNames;

        /// <inheritdoc/>
        public AzureOutputLibrary()
        {
            _pathToOperationSetMap = CategorizeClients();
            _resourceDataMap = EnsureResourceDataMap();
            _resourceDataNames = _resourceDataMap.Keys.ToHashSet();
        }

        private Dictionary<string, HashSet<OperationSet>> EnsureResourceDataMap()
        {
            var result = new Dictionary<string, HashSet<OperationSet>>();
            foreach (var operationSet in _pathToOperationSetMap.Values)
            {
                if (operationSet.TryGetResourceDataSchema(out var resourceSchemaName, out var resourceSchema, AzureClientPlugin.Instance.InputLibrary.InputNamespace))
                {
                    //// Skip the renaming for partial resource when resourceSchema is null but resourceSchemaName is not null
                    //if (resourceSchema is not null)
                    //{
                    //    // ensure the name of resource data is singular
                    //    // skip this step if the configuration is set to keep this plural
                    //    if (!Configuration.MgmtConfiguration.KeepPluralResourceData.Contains(resourceSchemaName))
                    //    {
                    //        resourceSchemaName = resourceSchemaName.LastWordToSingular(false);
                    //        resourceSchema.Name = resourceSchemaName;
                    //    }
                    //    else
                    //    {
                    //        MgmtReport.Instance.TransformSection.AddTransformLog(
                    //            new TransformItem(TransformTypeName.KeepPluralResourceData, resourceSchemaName),
                    //            resourceSchema.GetFullSerializedName(), $"Keep ObjectName as Plural: {resourceSchemaName}");
                    //    }
                    //}

                    // if this operation set corresponds to a SDK resource, we add it to the map
                    if (!result.TryGetValue(resourceSchemaName!, out HashSet<OperationSet>? value))
                    {
                        value = new HashSet<OperationSet>();
                        result.Add(resourceSchemaName!, value);
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
        protected override TypeProvider[] BuildTypeProviders()
        {
            var providers = base.BuildTypeProviders();
            var models = providers.Where(p => !_resourceDataMap.ContainsKey(p.Name));
            return [.. models, new RequestContextExtensionsDefinition(), .. BuildResourceDatas(), .. BuildResources()];
        }

        private IReadOnlyList<TypeProvider> BuildResources()
        {
            // TODO: Implement resource providers
            return Array.Empty<ResourceProvdier>();
        }

        private IReadOnlyList<ResourceDataProvider> BuildResourceDatas()
        {
            var result = new List<ResourceDataProvider>();
            var resourceDatas = AzureClientPlugin.Instance.InputLibrary.InputNamespace.Models.Where(m => _resourceDataNames.Contains(m.Name));
            foreach (var resourceData in resourceDatas)
            {
                result.Add(AzureClientPlugin.Instance.TypeFactory.CreateResourceData(resourceData));
            }
            return result;
        }
    }
}
