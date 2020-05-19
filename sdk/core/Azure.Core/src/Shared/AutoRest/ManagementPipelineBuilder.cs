// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Xml;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class ManagementPipelineBuilder
    {
        public static HttpPipeline Build(TokenCredential credential, Uri endpoint, ClientOptions options)
        {
            return HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, $"{endpoint}/.default"));
        }
    }
}