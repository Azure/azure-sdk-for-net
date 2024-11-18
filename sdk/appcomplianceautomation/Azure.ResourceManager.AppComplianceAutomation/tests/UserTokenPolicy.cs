// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Newtonsoft.Json.Linq;

namespace Azure.ResourceManager.AppComplianceAutomation.Tests
{
    public class UserTokenPolicy : HttpPipelineSynchronousPolicy
    {
        public const string UserTokenHeader = "x-ms-aad-user-token";
        private const string AuthorizationHeaderKey = "Authorization";
        private readonly TokenCredential _credential;
        private readonly string _scope;
        public UserTokenPolicy(TokenCredential credential, string scope)
        {
            _credential = credential;
            _scope = scope;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.Request.Headers.TryGetValue(AuthorizationHeaderKey, out string authorization))
            {
                message.Request.Headers.SetValue(UserTokenHeader, authorization);
            }
            else
            {
                string token = "Bearer " + (_credential.GetToken(new TokenRequestContext(new[] { _scope }), default)).Token;
                message.Request.Headers.SetValue(UserTokenHeader, token);
            }
        }
    }
}
