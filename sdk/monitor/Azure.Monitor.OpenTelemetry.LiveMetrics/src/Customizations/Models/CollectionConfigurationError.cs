// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Models
{
    internal partial class CollectionConfigurationError
    {
        public static CollectionConfigurationError CreateError(
            CollectionConfigurationErrorType errorType,
            string message,
            System.Exception? exception,
            params Tuple<string, string>[] data)
        {
            return new CollectionConfigurationError(
                errorType,
                message,
                exception?.ToString() ?? string.Empty,
                Array.ConvertAll(data, tuple => new KeyValuePairString(tuple.Item1, tuple.Item2))
            );
        }
    }
}
