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
        private readonly TempArmOperationHelper<ResourceGroup> _operationHelper;

        protected UpdateResourceGroupOperation()
        {
        }

        internal UpdateResourceGroupOperation(ResourceOperationsBase operations, ArmResponse<ResourceGroup> response)
        {
            _operationHelper = new TempArmOperationHelper<ResourceGroup>(
                response,
                operations,
                OperationFinalStateVia.Location,
                "UpdateResourceGroupOperation");
            _operations = operations;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateResourceGroupOperation"/> class.
        /// </summary>
        /// <param name="operations"> The arm operations object to copy from. </param>
        /// <param name="request"> The original request. </param>
        /// <param name="response"> The original response. </param>
        internal UpdateResourceGroupOperation(ResourceOperationsBase operations, Request request, Response response)
        {
            _operationHelper = new TempArmOperationHelper<ResourceGroup>(
                this,
                new ClientDiagnostics(operations.ClientOptions),
                ManagementPipelineBuilder.Build(operations.Credential, operations.BaseUri, operations.ClientOptions),
                request,
                response,
                OperationFinalStateVia.Location,
                "UpdateResourceGroupOperation");
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
            return new ResourceGroup(_operations, new ResourceGroupData(obj as ResourceManager.Resources.Models.ResourceGroup));
        }
    }
}
