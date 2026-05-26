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
using System.ComponentModel;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    [TypeSpecCodeGenSuppress("MergeReservation", typeof(WaitUntil), typeof(MergeContent), typeof(CancellationToken))]
    [TypeSpecCodeGenSuppress("MergeReservationAsync", typeof(WaitUntil), typeof(MergeContent), typeof(CancellationToken))]
    [TypeSpecCodeGenSuppress("SplitReservation", typeof(WaitUntil), typeof(SplitContent), typeof(CancellationToken))]
    [TypeSpecCodeGenSuppress("SplitReservationAsync", typeof(WaitUntil), typeof(SplitContent), typeof(CancellationToken))]
    public partial class ReservationOrderResource
    {
        /// <summary>
        /// Return a reservation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/return</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Return_Post</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Information needed for returning reservation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// <summary>
        /// Return a reservation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/return</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Return_Post</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Information needed for returning reservation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        // The new generator no longer emits the GA CreateResourceIdentifier helper, so customization is required to preserve it.
        public static ResourceIdentifier CreateResourceIdentifier(Guid reservationOrderId)
            => new ResourceIdentifier($"/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}");

        //The new generator no longer generates direct-forwarding convenience APIs like `GA` on the parent resource by default,
        // so customization is required to preserve that behavior.
        [ForwardsClientCalls]
        public virtual Task<Response<ReservationDetailResource>> GetReservationDetailAsync(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationDetails().GetAsync(reservationId, expand, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<ReservationDetailResource> GetReservationDetail(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationDetails().Get(reservationId, expand, cancellationToken);

        //GA modelled `MergeReservation` as ArmOperation<IList<ReservationDetailData>> while the new generator emits Pageable shapes.
        // Customization is required to preserve the GA method signatures and behavior.
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

        //GA modelled `SplitReservation` as ArmOperation<IList<ReservationDetailData>> while the new generator emits Pageable shapes.
        // Customization is required to preserve the GA method signatures and behavior.
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
