// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Reservations.Models;
using Microsoft.TypeSpec.Generator.Customizations;
using TypeSpecCodeGenSuppress = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    // Justification: GA modelled MergeReservation/SplitReservation as
    // ArmOperation<IList<ReservationDetailData>> and Return as a synchronous
    // Response<ReservationRefundResult>. The new generator emits Pageable shapes for Merge/Split
    // and an LRO for Return. It also omits the GA CreateResourceIdentifier and direct
    // GetReservationDetail forwarding methods. These shims preserve the GA-shape methods.
    [TypeSpecCodeGenSuppress("MergeReservation", typeof(WaitUntil), typeof(MergeContent), typeof(CancellationToken))]
    [TypeSpecCodeGenSuppress("MergeReservationAsync", typeof(WaitUntil), typeof(MergeContent), typeof(CancellationToken))]
    [TypeSpecCodeGenSuppress("SplitReservation", typeof(WaitUntil), typeof(SplitContent), typeof(CancellationToken))]
    [TypeSpecCodeGenSuppress("SplitReservationAsync", typeof(WaitUntil), typeof(SplitContent), typeof(CancellationToken))]
    public partial class ReservationOrderResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(Guid reservationOrderId)
            => new ResourceIdentifier($"/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}");

        [ForwardsClientCalls]
        public virtual Task<Response<ReservationDetailResource>> GetReservationDetailAsync(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationDetails().GetAsync(reservationId, expand, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<ReservationDetailResource> GetReservationDetail(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationDetails().Get(reservationId, expand, cancellationToken);

        public virtual async Task<ArmOperation<IList<ReservationDetailData>>> MergeReservationAsync(WaitUntil waitUntil, MergeContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _reservationClientDiagnostics.CreateScope("ReservationOrderResource.MergeReservation");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationRestClient.CreateMergeReservationRequest(Guid.Parse(Id.Name), MergeContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ReservationsArmOperation<IList<ReservationDetailData>> operation = new ReservationsArmOperation<IList<ReservationDetailData>>(
                    new ReservationDetailDataListOperationSource(),
                    _reservationClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmOperation<IList<ReservationDetailData>> MergeReservation(WaitUntil waitUntil, MergeContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _reservationClientDiagnostics.CreateScope("ReservationOrderResource.MergeReservation");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationRestClient.CreateMergeReservationRequest(Guid.Parse(Id.Name), MergeContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ReservationsArmOperation<IList<ReservationDetailData>> operation = new ReservationsArmOperation<IList<ReservationDetailData>>(
                    new ReservationDetailDataListOperationSource(),
                    _reservationClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<ArmOperation<IList<ReservationDetailData>>> SplitReservationAsync(WaitUntil waitUntil, SplitContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _reservationClientDiagnostics.CreateScope("ReservationOrderResource.SplitReservation");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationRestClient.CreateSplitReservationRequest(Guid.Parse(Id.Name), SplitContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ReservationsArmOperation<IList<ReservationDetailData>> operation = new ReservationsArmOperation<IList<ReservationDetailData>>(
                    new ReservationDetailDataListOperationSource(),
                    _reservationClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmOperation<IList<ReservationDetailData>> SplitReservation(WaitUntil waitUntil, SplitContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _reservationClientDiagnostics.CreateScope("ReservationOrderResource.SplitReservation");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationRestClient.CreateSplitReservationRequest(Guid.Parse(Id.Name), SplitContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ReservationsArmOperation<IList<ReservationDetailData>> operation = new ReservationsArmOperation<IList<ReservationDetailData>>(
                    new ReservationDetailDataListOperationSource(),
                    _reservationClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [ForwardsClientCalls]
        public virtual async Task<Response<ReservationRefundResult>> ReturnAsync(ReservationRefundContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _returnClientDiagnostics.CreateScope("ReservationOrderResource.Return");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _returnRestClient.CreateReturnRequest(Guid.Parse(Id.Name), ReservationRefundContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ReservationRefundResult value = response.Status >= 200 && response.Status < 300 && response.Content?.ToMemory().Length > 0
                    ? ReservationRefundResult.DeserializeReservationRefundResult(response.Content)
                    : new ReservationRefundResult();
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [ForwardsClientCalls]
        public virtual Response<ReservationRefundResult> Return(ReservationRefundContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _returnClientDiagnostics.CreateScope("ReservationOrderResource.Return");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _returnRestClient.CreateReturnRequest(Guid.Parse(Id.Name), ReservationRefundContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ReservationRefundResult value = response.Status >= 200 && response.Status < 300 && response.Content?.ToMemory().Length > 0
                    ? ReservationRefundResult.DeserializeReservationRefundResult(response.Content)
                    : new ReservationRefundResult();
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private sealed class ReservationDetailDataListOperationSource : IOperationSource<IList<ReservationDetailData>>
        {
            IList<ReservationDetailData> IOperationSource<IList<ReservationDetailData>>.CreateResult(Response response, CancellationToken cancellationToken)
            {
                using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                return ParseReservationDetailDataList(document.RootElement);
            }

            async ValueTask<IList<ReservationDetailData>> IOperationSource<IList<ReservationDetailData>>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            {
                using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                return ParseReservationDetailDataList(document.RootElement);
            }
        }

        private static IList<ReservationDetailData> ParseReservationDetailDataList(JsonElement root)
        {
            List<ReservationDetailData> result = new List<ReservationDetailData>();
            if (root.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement element in root.EnumerateArray())
                {
                    result.Add(ReservationDetailData.DeserializeReservationDetailData(element, ModelSerializationExtensions.WireOptions));
                }
            }
            return result;
        }
    }
}
