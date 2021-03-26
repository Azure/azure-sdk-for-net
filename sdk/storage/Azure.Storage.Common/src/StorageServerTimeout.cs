// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// TODO.
    /// </summary>
    public static class StorageServerTimeout
    {
        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static IDisposable CreateScope(TimeSpan timeout)
        {
            return HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object> { { Constants.ServerTimeout.HttpMessagePropertyKey, timeout } });
        }
    }
}
