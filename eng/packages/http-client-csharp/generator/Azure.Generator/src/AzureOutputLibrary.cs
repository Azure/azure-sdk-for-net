// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        private Dictionary<string, InputModelType> _inputTypeMap;

        /// <inheritdoc/>
        public AzureOutputLibrary()
        {
            _inputTypeMap = AzureClientPlugin.Instance.InputLibrary.InputNamespace.Models.OfType<InputModelType>().ToDictionary(model => model.Name);
        }

        private LongRunningOperationProvider? _armOperation;
        internal LongRunningOperationProvider ArmOperation => _armOperation ??= new LongRunningOperationProvider(false);

        private LongRunningOperationProvider? _genericArmOperation;
        internal LongRunningOperationProvider GenericArmOperation => _genericArmOperation ??= new LongRunningOperationProvider(true);

        private IReadOnlyList<TypeProvider> BuildResources()
        {
            var result = new List<TypeProvider>();
            foreach ((InputClient client, string requestPath, bool isSingleton, string requestType, string specName) in AzureClientPlugin.Instance.ResourceBuilder.BuildResourceClients())
            {
                var resourceData = AzureClientPlugin.Instance.TypeFactory.CreateModel(_inputTypeMap[specName])!;
                var resource = CreateResourceCore(client, requestPath, specName, resourceData, requestType, isSingleton);
                AzureClientPlugin.Instance.AddTypeToKeep(resource.Name);
                result.Add(resource);
            }
            return result;
        }

        /// <summary>
        /// Create a resource client provider
        /// </summary>
        /// <param name="inputClient"></param>
        /// <param name="requestPath"></param>
        /// <param name="schemaName"></param>
        /// <param name="resourceData"></param>
        /// <param name="resourceType"></param>
        /// <param name="isSingleton"></param>
        /// <returns></returns>
        public virtual TypeProvider CreateResourceCore(InputClient inputClient, string requestPath, string schemaName, ModelProvider resourceData, string resourceType, bool isSingleton)
            => new ResourceClientProvider(inputClient, requestPath, schemaName, resourceData, resourceType, isSingleton);

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
    }
}
