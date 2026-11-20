// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.IotFirmwareDefense
{
    // Preserve request builders for the hidden legacy download URL APIs. The migrated generated
    // Firmwares client no longer emits methods for these compatibility-only operations.
    internal partial class Firmwares
    {
        internal HttpMessage CreateGenerateDownloadUriRequest(Guid subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId.ToString(), true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.IoTFirmwareDefense/workspaces/", false);
            uri.AppendPath(workspaceName, true);
            uri.AppendPath("/firmwares/", false);
            uri.AppendPath(firmwareId, true);
            uri.AppendPath("/generateDownloadUrl", false);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            _userAgent.Apply(message);
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGenerateFilesystemDownloadUriRequest(Guid subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId.ToString(), true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.IoTFirmwareDefense/workspaces/", false);
            uri.AppendPath(workspaceName, true);
            uri.AppendPath("/firmwares/", false);
            uri.AppendPath(firmwareId, true);
            uri.AppendPath("/generateFilesystemDownloadUrl", false);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            _userAgent.Apply(message);
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }
    }
}
