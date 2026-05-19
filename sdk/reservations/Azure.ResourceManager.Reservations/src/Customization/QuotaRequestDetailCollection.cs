// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    // Justification: GA exposed item-level Get/Exists/GetIfExists methods on
    // QuotaRequestDetailCollection. The TypeSpec generator only emits list operations for this
    // collection, so these shims preserve the GA lookup surface and 404-to-no-value behavior.
    public partial class QuotaRequestDetailCollection
    {
        public virtual async Task<Response<QuotaRequestDetailResource>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _quotaRequestStatusClientDiagnostics.CreateScope("QuotaRequestDetailCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _quotaRequestStatusRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), _providerId, _location, id, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<QuotaRequestDetailData> response = Response.FromValue(QuotaRequestDetailData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new QuotaRequestDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<QuotaRequestDetailResource> Get(Guid id, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _quotaRequestStatusClientDiagnostics.CreateScope("QuotaRequestDetailCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _quotaRequestStatusRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), _providerId, _location, id, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<QuotaRequestDetailData> response = Response.FromValue(QuotaRequestDetailData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new QuotaRequestDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            NullableResponse<QuotaRequestDetailResource> response = await GetIfExistsAsync(id, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        public virtual Response<bool> Exists(Guid id, CancellationToken cancellationToken = default)
        {
            NullableResponse<QuotaRequestDetailResource> response = GetIfExists(id, cancellationToken);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        public virtual async Task<NullableResponse<QuotaRequestDetailResource>> GetIfExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _quotaRequestStatusClientDiagnostics.CreateScope("QuotaRequestDetailCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _quotaRequestStatusRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), _providerId, _location, id, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<QuotaRequestDetailData> response = result.Status switch
                {
                    200 => Response.FromValue(QuotaRequestDetailData.FromResponse(result), result),
                    404 => Response.FromValue((QuotaRequestDetailData)null, result),
                    _ => throw new RequestFailedException(result)
                };
                if (response.Value == null)
                {
                    return new NoValueResponse<QuotaRequestDetailResource>(response.GetRawResponse());
                }
                return Response.FromValue(new QuotaRequestDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual NullableResponse<QuotaRequestDetailResource> GetIfExists(Guid id, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _quotaRequestStatusClientDiagnostics.CreateScope("QuotaRequestDetailCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _quotaRequestStatusRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), _providerId, _location, id, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<QuotaRequestDetailData> response = result.Status switch
                {
                    200 => Response.FromValue(QuotaRequestDetailData.FromResponse(result), result),
                    404 => Response.FromValue((QuotaRequestDetailData)null, result),
                    _ => throw new RequestFailedException(result)
                };
                if (response.Value == null)
                {
                    return new NoValueResponse<QuotaRequestDetailResource>(response.GetRawResponse());
                }
                return Response.FromValue(new QuotaRequestDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
