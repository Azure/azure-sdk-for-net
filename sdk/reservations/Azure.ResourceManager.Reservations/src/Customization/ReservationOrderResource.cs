// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA modelled MergeReservation/SplitReservation as
// ArmOperation<IList<ReservationDetailData>> and Return as a synchronous
// Response<ReservationRefundResult>. The new generator emits Pageable shapes for Merge/Split
// and an LRO for Return. It also omits the GA CreateResourceIdentifier and direct
// GetReservationDetail forwarding methods. These shims preserve the GA-shape methods.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Reservations.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    [CodeGenSuppress("MergeReservation", typeof(WaitUntil), typeof(MergeContent), typeof(CancellationToken))]
    [CodeGenSuppress("MergeReservationAsync", typeof(WaitUntil), typeof(MergeContent), typeof(CancellationToken))]
    [CodeGenSuppress("SplitReservation", typeof(WaitUntil), typeof(SplitContent), typeof(CancellationToken))]
    [CodeGenSuppress("SplitReservationAsync", typeof(WaitUntil), typeof(SplitContent), typeof(CancellationToken))]
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
                IList<ReservationDetailData> value = ParseReservationDetailDataList(response);
                return new ReservationsArmOperation<IList<ReservationDetailData>>(Response.FromValue(value, response));
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
                IList<ReservationDetailData> value = ParseReservationDetailDataList(response);
                return new ReservationsArmOperation<IList<ReservationDetailData>>(Response.FromValue(value, response));
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
                IList<ReservationDetailData> value = ParseReservationDetailDataList(response);
                return new ReservationsArmOperation<IList<ReservationDetailData>>(Response.FromValue(value, response));
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
                IList<ReservationDetailData> value = ParseReservationDetailDataList(response);
                return new ReservationsArmOperation<IList<ReservationDetailData>>(Response.FromValue(value, response));
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

        private static IList<ReservationDetailData> ParseReservationDetailDataList(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content);
            JsonElement root = document.RootElement;
            List<ReservationDetailData> result = new List<ReservationDetailData>();
            if (root.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement element in root.EnumerateArray())
                {
                    result.Add(ModelReaderWriter.Read<ReservationDetailData>(BinaryData.FromString(element.GetRawText()), ModelReaderWriterOptions.Json, AzureResourceManagerReservationsContext.Default));
                }
            }
            return result;
        }
    }
}
