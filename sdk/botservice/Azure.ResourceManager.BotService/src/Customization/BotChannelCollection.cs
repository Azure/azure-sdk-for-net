// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.BotService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.BotService
{
    // Backward compatibility: The generated methods accept `string channelName` but the old API
    // used `BotChannelName` (a strongly-typed enum). These hand-written overloads preserve the
    // `BotChannelName` parameter type for backward compatibility. @@alternateType cannot be used
    // here because the parameter is a path segment and alternateType does not support enum-to-string
    // conversion for path parameters.
    [CodeGenSuppress("GetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Exists", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(string), typeof(CancellationToken))]
    public partial class BotChannelCollection
    {
        /// <summary>
        /// Returns a BotService Channel registration specified by the parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BotChannels_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-09-15-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="channelName"> The name of the Bot resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BotChannelResource>> GetAsync(BotChannelName channelName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _botChannelsClientDiagnostics.CreateScope("BotChannelCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _botChannelsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, channelName.ToString(), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<BotChannelData> response = Response.FromValue(BotChannelData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new BotChannelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a BotService Channel registration specified by the parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BotChannels_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-09-15-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="channelName"> The name of the Bot resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BotChannelResource> Get(BotChannelName channelName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _botChannelsClientDiagnostics.CreateScope("BotChannelCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _botChannelsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, channelName.ToString(), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<BotChannelData> response = Response.FromValue(BotChannelData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new BotChannelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BotChannels_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-09-15-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="channelName"> The name of the Bot resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(BotChannelName channelName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _botChannelsClientDiagnostics.CreateScope("BotChannelCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _botChannelsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, channelName.ToString(), context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<BotChannelData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(BotChannelData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((BotChannelData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BotChannels_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-09-15-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="channelName"> The name of the Bot resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(BotChannelName channelName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _botChannelsClientDiagnostics.CreateScope("BotChannelCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _botChannelsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, channelName.ToString(), context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<BotChannelData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(BotChannelData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((BotChannelData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BotChannels_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-09-15-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="channelName"> The name of the Bot resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<BotChannelResource>> GetIfExistsAsync(BotChannelName channelName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _botChannelsClientDiagnostics.CreateScope("BotChannelCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _botChannelsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, channelName.ToString(), context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<BotChannelData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(BotChannelData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((BotChannelData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<BotChannelResource>(response.GetRawResponse());
                }
                return Response.FromValue(new BotChannelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BotChannels_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-09-15-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="channelName"> The name of the Bot resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<BotChannelResource> GetIfExists(BotChannelName channelName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _botChannelsClientDiagnostics.CreateScope("BotChannelCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _botChannelsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, channelName.ToString(), context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<BotChannelData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(BotChannelData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((BotChannelData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<BotChannelResource>(response.GetRawResponse());
                }
                return Response.FromValue(new BotChannelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
