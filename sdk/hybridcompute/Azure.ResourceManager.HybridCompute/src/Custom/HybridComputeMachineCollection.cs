// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.HybridCompute.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute
{
    [CodeGenSuppress("GetAsync", typeof(string), typeof(InstanceViewTypes?), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(InstanceViewTypes?), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(string), typeof(InstanceViewTypes?), typeof(CancellationToken))]
    [CodeGenSuppress("Exists", typeof(string), typeof(InstanceViewTypes?), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(string), typeof(InstanceViewTypes?), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(string), typeof(InstanceViewTypes?), typeof(CancellationToken))]
    public partial class HybridComputeMachineCollection
    {
        /// <summary> Gets a hybrid machine. </summary>
        public virtual Task<Response<HybridComputeMachineResource>> GetAsync(string machineName, InstanceViewTypes? expand, CancellationToken cancellationToken = default)
            => GetAsync(machineName, expand?.ToString(), cancellationToken);

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Get(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HybridComputeMachineResource>> GetAsync(string machineName, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using DiagnosticScope scope = _machinesClientDiagnostics.CreateScope("HybridComputeMachineCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _machinesRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, machineName, expand, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<HybridComputeMachineData> response = Response.FromValue(HybridComputeMachineData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new HybridComputeMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a hybrid machine. </summary>
        public virtual Response<HybridComputeMachineResource> Get(string machineName, InstanceViewTypes? expand, CancellationToken cancellationToken = default)
            => Get(machineName, expand?.ToString(), cancellationToken);

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Get(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridComputeMachineResource> Get(string machineName, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using DiagnosticScope scope = _machinesClientDiagnostics.CreateScope("HybridComputeMachineCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _machinesRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, machineName, expand, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<HybridComputeMachineData> response = Response.FromValue(HybridComputeMachineData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new HybridComputeMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks if a hybrid machine exists. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string machineName, InstanceViewTypes? expand, CancellationToken cancellationToken = default)
            => ExistsAsync(machineName, expand?.ToString(), cancellationToken);

        /// <summary>
        /// Checks if a hybrid machine exists.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="ExistsAsync(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string machineName, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using DiagnosticScope scope = _machinesClientDiagnostics.CreateScope("HybridComputeMachineCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _machinesRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, machineName, expand, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<HybridComputeMachineData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(HybridComputeMachineData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((HybridComputeMachineData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks if a hybrid machine exists. </summary>
        public virtual Response<bool> Exists(string machineName, InstanceViewTypes? expand, CancellationToken cancellationToken = default)
            => Exists(machineName, expand?.ToString(), cancellationToken);

        /// <summary>
        /// Checks if a hybrid machine exists.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Exists(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string machineName, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using DiagnosticScope scope = _machinesClientDiagnostics.CreateScope("HybridComputeMachineCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _machinesRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, machineName, expand, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<HybridComputeMachineData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(HybridComputeMachineData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((HybridComputeMachineData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a hybrid machine if it exists. </summary>
        public virtual Task<NullableResponse<HybridComputeMachineResource>> GetIfExistsAsync(string machineName, InstanceViewTypes? expand, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(machineName, expand?.ToString(), cancellationToken);

        /// <summary>
        /// Gets a hybrid machine if it exists.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="GetIfExistsAsync(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<HybridComputeMachineResource>> GetIfExistsAsync(string machineName, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using DiagnosticScope scope = _machinesClientDiagnostics.CreateScope("HybridComputeMachineCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _machinesRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, machineName, expand, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<HybridComputeMachineData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(HybridComputeMachineData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((HybridComputeMachineData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<HybridComputeMachineResource>(response.GetRawResponse());
                }
                return Response.FromValue(new HybridComputeMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a hybrid machine if it exists. </summary>
        public virtual NullableResponse<HybridComputeMachineResource> GetIfExists(string machineName, InstanceViewTypes? expand, CancellationToken cancellationToken = default)
            => GetIfExists(machineName, expand?.ToString(), cancellationToken);

        /// <summary>
        /// Gets a hybrid machine if it exists.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="GetIfExists(string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<HybridComputeMachineResource> GetIfExists(string machineName, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using DiagnosticScope scope = _machinesClientDiagnostics.CreateScope("HybridComputeMachineCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _machinesRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, machineName, expand, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<HybridComputeMachineData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(HybridComputeMachineData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((HybridComputeMachineData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<HybridComputeMachineResource>(response.GetRawResponse());
                }
                return Response.FromValue(new HybridComputeMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
