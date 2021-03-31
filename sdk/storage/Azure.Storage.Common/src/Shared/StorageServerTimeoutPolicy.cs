// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    internal class StorageServerTimeoutPolicy : HttpPipelineSynchronousPolicy
    {
        private const string QueryParameterKeyWithEqualSign = Constants.ServerTimeout.QueryParameterKey + "=";

        private StorageServerTimeoutPolicy()
        {
        }

        public static StorageServerTimeoutPolicy Shared { get; } = new StorageServerTimeoutPolicy();

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.TryGetProperty(Constants.ServerTimeout.HttpMessagePropertyKey, out var value))
            {
                if (value is TimeSpan timeout)
                {
                    string query = message.Request.Uri.Query;
                    int totalSeconds = Convert.ToInt32(timeout.TotalSeconds);
                    if (string.IsNullOrEmpty(query))
                    {
                        message.Request.Uri.Query += string.Format(CultureInfo.InvariantCulture, "?{0}{1}", QueryParameterKeyWithEqualSign, totalSeconds);
                    }
                    else if (!query.Contains(QueryParameterKeyWithEqualSign))
                    {
                        message.Request.Uri.Query += string.Format(CultureInfo.InvariantCulture, "&{0}{1}", QueryParameterKeyWithEqualSign, totalSeconds);
                    }
                }
                else
                {
                    throw new ArgumentException(
                        $"{Constants.ServerTimeout.HttpMessagePropertyKey} http message property must be a TimeSpan but was {value?.GetType()}");
                }
            }
        }
    }
}
