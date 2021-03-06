// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> Creates or updates a workload group. </summary>
    public partial class WorkloadGroupsCreateOrUpdateOperation : Operation<WorkloadGroup>, IOperationSource<WorkloadGroup>
    {
        private readonly ArmOperationHelpers<WorkloadGroup> _operation;

        /// <summary> Initializes a new instance of WorkloadGroupsCreateOrUpdateOperation for mocking. </summary>
        protected WorkloadGroupsCreateOrUpdateOperation()
        {
        }

        internal WorkloadGroupsCreateOrUpdateOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<WorkloadGroup>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "WorkloadGroupsCreateOrUpdateOperation");
        }
        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override WorkloadGroup Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<WorkloadGroup>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<WorkloadGroup>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        WorkloadGroup IOperationSource<WorkloadGroup>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return WorkloadGroup.DeserializeWorkloadGroup(document.RootElement);
        }

        async ValueTask<WorkloadGroup> IOperationSource<WorkloadGroup>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return WorkloadGroup.DeserializeWorkloadGroup(document.RootElement);
        }
    }
}
