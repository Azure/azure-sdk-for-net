// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.SipRouting
{
    [CodeGenClient("AzureCommunicationSIPRoutingServiceRestClient")]
    internal partial class SipRoutingRestClient
    {
        internal HttpMessage CreatePatchSipConfigurationRequest(SipConfiguration body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/sip", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (body != null)
            {
                request.Headers.Add("Content-Type", "application/merge-patch+json");
                var content = new Utf8JsonRequestContent();
                body.Write(content.JsonWriter);
                request.Content = content;
            }
            return message;
        }
    }
}
