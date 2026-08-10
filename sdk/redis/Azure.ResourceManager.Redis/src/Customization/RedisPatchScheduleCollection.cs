// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Redis.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis
{
    // TODO: Remove these suppressions and custom methods when https://github.com/microsoft/typespec/issues/11609 is fixed.
    [CodeGenSuppress("CreateOrUpdateAsync", typeof(WaitUntil), typeof(RedisPatchScheduleDefaultName), typeof(RedisPatchScheduleData), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdate", typeof(WaitUntil), typeof(RedisPatchScheduleDefaultName), typeof(RedisPatchScheduleData), typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(RedisPatchScheduleDefaultName), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(RedisPatchScheduleDefaultName), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(RedisPatchScheduleDefaultName), typeof(CancellationToken))]
    [CodeGenSuppress("Exists", typeof(RedisPatchScheduleDefaultName), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(RedisPatchScheduleDefaultName), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(RedisPatchScheduleDefaultName), typeof(CancellationToken))]
    public partial class RedisPatchScheduleCollection
    {
        /// <summary> Create or replace the patching schedule for Redis cache. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="data"> Parameters to set the patching schedule for Redis cache. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<RedisPatchScheduleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, RedisPatchScheduleDefaultName defaultName, RedisPatchScheduleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _redisPatchSchedulesClientDiagnostics.CreateScope("RedisPatchScheduleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _redisPatchSchedulesRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, defaultName.ToString(), RedisPatchScheduleData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<RedisPatchScheduleData> response = Response.FromValue(RedisPatchScheduleData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                RedisArmOperation<RedisPatchScheduleResource> operation = new RedisArmOperation<RedisPatchScheduleResource>(Response.FromValue(new RedisPatchScheduleResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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

        /// <summary> Create or replace the patching schedule for Redis cache. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="data"> Parameters to set the patching schedule for Redis cache. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<RedisPatchScheduleResource> CreateOrUpdate(WaitUntil waitUntil, RedisPatchScheduleDefaultName defaultName, RedisPatchScheduleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _redisPatchSchedulesClientDiagnostics.CreateScope("RedisPatchScheduleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _redisPatchSchedulesRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, defaultName.ToString(), RedisPatchScheduleData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<RedisPatchScheduleData> response = Response.FromValue(RedisPatchScheduleData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                RedisArmOperation<RedisPatchScheduleResource> operation = new RedisArmOperation<RedisPatchScheduleResource>(Response.FromValue(new RedisPatchScheduleResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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

        /// <summary> Gets the patching schedule of a redis cache. </summary>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RedisPatchScheduleResource>> GetAsync(RedisPatchScheduleDefaultName defaultName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _redisPatchSchedulesClientDiagnostics.CreateScope("RedisPatchScheduleCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _redisPatchSchedulesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, defaultName.ToString(), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<RedisPatchScheduleData> response = Response.FromValue(RedisPatchScheduleData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new RedisPatchScheduleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the patching schedule of a redis cache. </summary>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RedisPatchScheduleResource> Get(RedisPatchScheduleDefaultName defaultName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _redisPatchSchedulesClientDiagnostics.CreateScope("RedisPatchScheduleCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _redisPatchSchedulesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, defaultName.ToString(), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<RedisPatchScheduleData> response = Response.FromValue(RedisPatchScheduleData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new RedisPatchScheduleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in Azure. </summary>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(RedisPatchScheduleDefaultName defaultName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _redisPatchSchedulesClientDiagnostics.CreateScope("RedisPatchScheduleCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _redisPatchSchedulesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, defaultName.ToString(), context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response<RedisPatchScheduleData> response = CreateNullableResponse(message.Response);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in Azure. </summary>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(RedisPatchScheduleDefaultName defaultName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _redisPatchSchedulesClientDiagnostics.CreateScope("RedisPatchScheduleCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _redisPatchSchedulesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, defaultName.ToString(), context);
                Pipeline.Send(message, context.CancellationToken);
                Response<RedisPatchScheduleData> response = CreateNullableResponse(message.Response);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<RedisPatchScheduleResource>> GetIfExistsAsync(RedisPatchScheduleDefaultName defaultName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _redisPatchSchedulesClientDiagnostics.CreateScope("RedisPatchScheduleCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _redisPatchSchedulesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, defaultName.ToString(), context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response<RedisPatchScheduleData> response = CreateNullableResponse(message.Response);
                if (response.Value == null)
                {
                    return new NoValueResponse<RedisPatchScheduleResource>(response.GetRawResponse());
                }
                return Response.FromValue(new RedisPatchScheduleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<RedisPatchScheduleResource> GetIfExists(RedisPatchScheduleDefaultName defaultName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _redisPatchSchedulesClientDiagnostics.CreateScope("RedisPatchScheduleCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _redisPatchSchedulesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, defaultName.ToString(), context);
                Pipeline.Send(message, context.CancellationToken);
                Response<RedisPatchScheduleData> response = CreateNullableResponse(message.Response);
                if (response.Value == null)
                {
                    return new NoValueResponse<RedisPatchScheduleResource>(response.GetRawResponse());
                }
                return Response.FromValue(new RedisPatchScheduleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static Response<RedisPatchScheduleData> CreateNullableResponse(Response result)
        {
            return result.Status switch
            {
                200 => Response.FromValue(RedisPatchScheduleData.FromResponse(result), result),
                404 => Response.FromValue((RedisPatchScheduleData)null, result),
                _ => throw new RequestFailedException(result)
            };
        }
    }
}
