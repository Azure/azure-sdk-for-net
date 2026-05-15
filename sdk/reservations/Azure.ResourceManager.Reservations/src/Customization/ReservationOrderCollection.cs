// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Reservations.Models;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public partial class ReservationOrderCollection
    {
        public virtual async Task<ArmOperation<ReservationOrderResource>> CreateOrUpdateAsync(WaitUntil waitUntil, Guid reservationOrderId, ReservationPurchaseContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _reservationOrderClientDiagnostics.CreateScope("ReservationOrderCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationOrderRestClient.CreateCreateOrUpdateRequest(reservationOrderId, ReservationPurchaseContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ReservationsArmOperation<ReservationOrderResource> operation = new ReservationsArmOperation<ReservationOrderResource>(
                    new ReservationOrderOperationSource(Client),
                    _reservationOrderClientDiagnostics,
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

        public virtual ArmOperation<ReservationOrderResource> CreateOrUpdate(WaitUntil waitUntil, Guid reservationOrderId, ReservationPurchaseContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _reservationOrderClientDiagnostics.CreateScope("ReservationOrderCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationOrderRestClient.CreateCreateOrUpdateRequest(reservationOrderId, ReservationPurchaseContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ReservationsArmOperation<ReservationOrderResource> operation = new ReservationsArmOperation<ReservationOrderResource>(
                    new ReservationOrderOperationSource(Client),
                    _reservationOrderClientDiagnostics,
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

        public virtual async Task<Response<ReservationOrderResource>> GetAsync(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _reservationOrderClientDiagnostics.CreateScope("ReservationOrderCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationOrderRestClient.CreateGetRequest(reservationOrderId, expand, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ReservationOrderData> response = Response.FromValue(ReservationOrderData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ReservationOrderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<ReservationOrderResource> Get(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _reservationOrderClientDiagnostics.CreateScope("ReservationOrderCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationOrderRestClient.CreateGetRequest(reservationOrderId, expand, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ReservationOrderData> response = Response.FromValue(ReservationOrderData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ReservationOrderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<bool>> ExistsAsync(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
        {
            NullableResponse<ReservationOrderResource> response = await GetIfExistsAsync(reservationOrderId, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        public virtual Response<bool> Exists(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
        {
            NullableResponse<ReservationOrderResource> response = GetIfExists(reservationOrderId, expand, cancellationToken);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        public virtual async Task<NullableResponse<ReservationOrderResource>> GetIfExistsAsync(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _reservationOrderClientDiagnostics.CreateScope("ReservationOrderCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationOrderRestClient.CreateGetRequest(reservationOrderId, expand, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<ReservationOrderData> response = result.Status switch
                {
                    200 => Response.FromValue(ReservationOrderData.FromResponse(result), result),
                    404 => Response.FromValue((ReservationOrderData)null, result),
                    _ => throw new RequestFailedException(result)
                };
                if (response.Value == null)
                {
                    return new NoValueResponse<ReservationOrderResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ReservationOrderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual NullableResponse<ReservationOrderResource> GetIfExists(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _reservationOrderClientDiagnostics.CreateScope("ReservationOrderCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationOrderRestClient.CreateGetRequest(reservationOrderId, expand, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<ReservationOrderData> response = result.Status switch
                {
                    200 => Response.FromValue(ReservationOrderData.FromResponse(result), result),
                    404 => Response.FromValue((ReservationOrderData)null, result),
                    _ => throw new RequestFailedException(result)
                };
                if (response.Value == null)
                {
                    return new NoValueResponse<ReservationOrderResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ReservationOrderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
