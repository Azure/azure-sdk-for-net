// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    internal class StorageServerTimeoutPolicy : HttpPipelineSynchronousPolicy
    {
        private StorageServerTimeoutPolicy()
        {
        }

        public static StorageServerTimeoutPolicy Shared { get; } = new StorageServerTimeoutPolicy();

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.TryGetProperty(Constants.ServerTimeout.HttpMessagePropertyKey, out var value) && value is TimeSpan timeout)
            {
                message.Request.Uri.Query += $"{Constants.ServerTimeout.QueryParameterKey}={Convert.ToInt32(timeout.TotalSeconds)}";
            }
        }
    }
}
