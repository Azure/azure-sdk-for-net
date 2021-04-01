// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    internal class UpdateResourceGroupOperation : ArmOperation<ResourceGroup>, IOperationSource<ResourceGroup>
    {
        private readonly ResourceOperationsBase _operations;

        protected UpdateResourceGroupOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateResourceGroupOperation"/> class.
        /// </summary>
        /// <param name="source"> The operation source to use. </param>
        /// <param name="operations"> The arm operations object to copy from. </param>
        /// <param name="request"> The original request. </param>
        /// <param name="response">The original response. </param>
        internal UpdateResourceGroupOperation(IOperationSource<ResourceGroup> source, ResourceOperationsBase operations, Request request, Response response)
            : base(source, operations.Diagnostics, ManagementPipelineBuilder.Build(operations.Credential, operations.BaseUri, operations.ClientOptions), request, response, "UpdateResourceGroupOperation")
        {
            _operations = operations;
        }

        ResourceGroup IOperationSource<ResourceGroup>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return GetResourceGrouop(document);
        }

        private ResourceGroup GetResourceGrouop(JsonDocument document)
        {
            var method = typeof(ResourceManager.Resources.Models.ResourceGroup).GetMethod("DeserializeResourceGroup", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var obj = method.Invoke(null, new object[] { document.RootElement });
            return new ResourceGroup(_operations, new ResourceGroupData(obj as ResourceManager.Resources.Models.ResourceGroup));
        }

        async ValueTask<ResourceGroup> IOperationSource<ResourceGroup>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return GetResourceGrouop(document);
        }
    }
}
