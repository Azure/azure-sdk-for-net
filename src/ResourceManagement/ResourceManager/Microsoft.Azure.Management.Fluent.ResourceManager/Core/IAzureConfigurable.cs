// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.TransientFaultHandling;
using System.Net.Http;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{
    public interface IAzureConfigurable<T> where T : IAzureConfigurable<T>
    {
        T withUserAgent(string product, string version);
        T withRetryPolicy(RetryPolicy retryPolicy);
        T withDelegatingHandler(DelegatingHandler delegatingHandler);
        T withLogLevel(HttpLoggingDelegatingHandler.Level level);
    }
}
