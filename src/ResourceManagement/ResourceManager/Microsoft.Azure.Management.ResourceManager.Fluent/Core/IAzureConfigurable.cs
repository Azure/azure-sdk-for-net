// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.TransientFaultHandling;
using System.Net.Http;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    public interface IAzureConfigurable<T> where T : IAzureConfigurable<T>
    {
        T WithUserAgent(string product, string version);
        T WithRetryPolicy(RetryPolicy retryPolicy);
        T WithDelegatingHandler(DelegatingHandler delegatingHandler);
        T WithLogLevel(HttpLoggingDelegatingHandler.Level level);
    }
}
