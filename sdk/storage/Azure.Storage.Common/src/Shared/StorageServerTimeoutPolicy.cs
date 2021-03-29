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
            if (message.TryGetProperty(Constants.ServerTimeout.HttpMessagePropertyKey, out var value))
            {
                if (value is int timeout)
                {
                    string query = message.Request.Uri.Query;
                    if (string.IsNullOrEmpty(query))
                    {
                        message.Request.Uri.Query += $"?{Constants.ServerTimeout.QueryParameterKey}={timeout}";
                    }
                    else if (!query.Contains($"{Constants.ServerTimeout.QueryParameterKey}="))
                    {
                        message.Request.Uri.Query += $"&{Constants.ServerTimeout.QueryParameterKey}={timeout}";
                    }
                }
                else
                {
                    throw new ArgumentException(
                        $"{Constants.ServerTimeout.HttpMessagePropertyKey} http message property must be an int but was {value?.GetType()}");
                }
            }
        }
    }
}
