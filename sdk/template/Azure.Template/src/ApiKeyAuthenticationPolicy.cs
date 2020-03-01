// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer
{
    internal class ApiKeyAuthenticationPolicy : HttpPipelineSynchronousPolicy
    {
        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";
        private FormRecognizerApiKeyCredential _credential;

        public ApiKeyAuthenticationPolicy(FormRecognizerApiKeyCredential credential)
        {
            _credential = credential;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            message.Request.Headers.SetValue(AuthorizationHeader, _credential.ApiKey);
        }
    }
}
