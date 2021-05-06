// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    internal class UpdateResourceGroupOperation : ArmOperation<ResourceGroup>, IOperationSource<ResourceGroup>
    {
        private readonly ResourceOperationsBase _operations;
        private readonly OperationOrResponseInternals<ResourceGroup> _operationHelper;

        protected UpdateResourceGroupOperation()
        {
        }

        internal UpdateResourceGroupOperation(ResourceOperationsBase operations, ArmResponse<ResourceGroup> response)
        {
            _operationHelper = new OperationOrResponseInternals<ResourceGroup>(response);
            _operations = operations;
        }

        public override ResourceGroup Value => _operationHelper.Value;

        public override bool HasValue => _operationHelper.HasValue;

        public override string Id => throw new System.NotImplementedException();

        public override bool HasCompleted => _operationHelper.HasCompleted;

        public override Response GetRawResponse() => _operationHelper.GetRawResponse();

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operationHelper.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operationHelper.UpdateStatusAsync(cancellationToken);

        public override ValueTask<Response<ResourceGroup>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operationHelper.WaitForCompletionAsync(cancellationToken);

        public override ValueTask<Response<ResourceGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, CancellationToken cancellationToken) => _operationHelper.WaitForCompletionAsync(pollingInterval, cancellationToken);

        ResourceGroup IOperationSource<ResourceGroup>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return GetResourceGrouop(document);
        }

        async ValueTask<ResourceGroup> IOperationSource<ResourceGroup>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return GetResourceGrouop(document);
        }

        private ResourceGroup GetResourceGrouop(JsonDocument document)
        {
            var method = typeof(ResourceManager.Resources.Models.ResourceGroup).GetMethod("DeserializeResourceGroup", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var obj = method.Invoke(null, new object[] { document.RootElement });
            return new ResourceGroup(_operations, obj as ResourceGroupData);
        }
    }
}
