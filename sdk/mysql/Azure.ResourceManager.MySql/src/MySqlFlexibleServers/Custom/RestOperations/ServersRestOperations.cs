// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.MySql.MySqlFlexibleServers;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    internal partial class ServersRestOperations
    {
        internal HttpMessage CreateCreateRequest(string subscriptionId, string resourceGroupName, string serverName, MySqlFlexibleServerData data)
        {
            var context = new RequestContext();
            // TODO: To apply the HTTP message policy for the Azure-AsyncOperation header, we made this workaround temporarily.
            // Issue https://github.com/Azure/azure-sdk-for-net/issues/44251 was openned for Azure.Core to propose the introduction of a method within the IOperation interface that would facilitate the application of policies to particular operations.
            //context.AddPolicy(new LroReplaceAzureAsyncOperationPolicy(), HttpPipelinePosition.PerRetry);
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DBforMySQL/flexibleServers/", false);
            uri.AppendPath(serverName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data, ModelSerializationExtensions.WireOptions);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }
    }
}
