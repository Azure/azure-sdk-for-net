// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.MySql.FlexibleServers.Models;
using Azure.ResourceManager.MySql.MySqlFlexibleServers;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    internal partial class BackupAndExportRestOperations
    {
        internal HttpMessage CreateCreateRequest(string subscriptionId, string resourceGroupName, string serverName, MySqlFlexibleServerBackupAndExportContent content)
        {
            var context = new RequestContext();
            // Add policy to replace the Azure-AsyncOperation header
            context.AddPolicy(new LroReplaceAzureAsyncOperationPolicy(), HttpPipelinePosition.PerRetry);
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DBforMySQL/flexibleServers/", false);
            uri.AppendPath(serverName, true);
            uri.AppendPath("/backupAndExport", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content0 = new Utf8JsonRequestContent();
            content0.JsonWriter.WriteObjectValue(content, ModelSerializationExtensions.WireOptions);
            request.Content = content0;
            _userAgent.Apply(message);
            return message;
        }
    }
}
