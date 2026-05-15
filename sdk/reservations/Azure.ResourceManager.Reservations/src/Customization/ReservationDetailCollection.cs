// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GetRevisions(Guid) was a collection-level entry point in GA but in the new SDK
// lives on ReservationDetailResource; we synthesize a resource here to invoke it without a network
// round-trip.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public partial class ReservationDetailCollection
    {
        public virtual async Task<Response<ReservationDetailResource>> GetAsync(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _reservationClientDiagnostics.CreateScope("ReservationDetailCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationRestClient.CreateGetRequest(Guid.Parse(Id.Name), reservationId, expand, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ReservationDetailData> response = Response.FromValue(ReservationDetailData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ReservationDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<ReservationDetailResource> Get(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _reservationClientDiagnostics.CreateScope("ReservationDetailCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationRestClient.CreateGetRequest(Guid.Parse(Id.Name), reservationId, expand, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ReservationDetailData> response = Response.FromValue(ReservationDetailData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ReservationDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<bool>> ExistsAsync(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
        {
            NullableResponse<ReservationDetailResource> response = await GetIfExistsAsync(reservationId, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        public virtual Response<bool> Exists(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
        {
            NullableResponse<ReservationDetailResource> response = GetIfExists(reservationId, expand, cancellationToken);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        public virtual async Task<NullableResponse<ReservationDetailResource>> GetIfExistsAsync(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _reservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationRestClient.CreateGetRequest(Guid.Parse(Id.Name), reservationId, expand, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<ReservationDetailData> response = result.Status switch
                {
                    200 => Response.FromValue(ReservationDetailData.FromResponse(result), result),
                    404 => Response.FromValue((ReservationDetailData)null, result),
                    _ => throw new RequestFailedException(result)
                };
                if (response.Value == null)
                {
                    return new NoValueResponse<ReservationDetailResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ReservationDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual NullableResponse<ReservationDetailResource> GetIfExists(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _reservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _reservationRestClient.CreateGetRequest(Guid.Parse(Id.Name), reservationId, expand, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<ReservationDetailData> response = result.Status switch
                {
                    200 => Response.FromValue(ReservationDetailData.FromResponse(result), result),
                    404 => Response.FromValue((ReservationDetailData)null, result),
                    _ => throw new RequestFailedException(result)
                };
                if (response.Value == null)
                {
                    return new NoValueResponse<ReservationDetailResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ReservationDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List revisions of a reservation. </summary>
        public virtual AsyncPageable<ReservationDetailResource> GetRevisionsAsync(Guid reservationId, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier detailId = new ResourceIdentifier($"{Id}/reservations/{reservationId}");
            ReservationDetailResource detail = Client.GetReservationDetailResource(detailId);
            return detail.GetRevisionsAsync(cancellationToken);
        }

        /// <summary> List revisions of a reservation. </summary>
        public virtual Pageable<ReservationDetailResource> GetRevisions(Guid reservationId, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier detailId = new ResourceIdentifier($"{Id}/reservations/{reservationId}");
            ReservationDetailResource detail = Client.GetReservationDetailResource(detailId);
            return detail.GetRevisions(cancellationToken);
        }
    }
}
