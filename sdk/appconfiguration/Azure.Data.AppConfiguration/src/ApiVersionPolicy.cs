// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    internal class ApiVersionPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _versionString;

        public ApiVersionPolicy(string versionString)
        {
            _versionString = versionString;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Uri.AppendQuery("api-version", _versionString);
        }
    }
}
