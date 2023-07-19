// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.IO;
using Azure.Core;

namespace Azure.ResourceManager.Automation
{
    [CodeGenSuppress("CreateReplaceContentRequest", typeof(string), typeof(string), typeof(string), typeof(string), typeof(Stream))]
    internal partial class RunbookDraftRestOperations
    {
        internal HttpMessage CreateReplaceContentRequest(string subscriptionId, string resourceGroupName, string automationAccountName, string runbookName, Stream runbookContent, bool isContentSkipped = false)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Automation/automationAccounts/", false);
            uri.AppendPath(automationAccountName, true);
            uri.AppendPath("/runbooks/", false);
            uri.AppendPath(runbookName, true);
            uri.AppendPath("/draft/content", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "text/powershell");
            if (!isContentSkipped)
            {
                request.Content = RequestContent.Create(runbookContent);
            }
            _userAgent.Apply(message);
            return message;
        }
    }
}
