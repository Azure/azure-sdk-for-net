// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// Base class for Service Version Policies
    /// </summary>
    internal class ServiceVersionPolicy : HttpPipelineSynchronousPolicy
    {
        internal static void ThrowIfContainsHeader(HttpMessage message, string header, string operationName, string serviceVersion)
        {
            if (message.Request.Headers.Contains(header))
            {
                throw new ArgumentException($"{header} is not supported for {operationName} in service version {serviceVersion}");
            }
        }
    }
}
