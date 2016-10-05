using System;
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{
    public interface IRequestInterceptor
    {
        Task<HttpResponseMessage> SendAsync(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> nextSendAsync,
            HttpRequestMessage request,
            CancellationToken cancellationToken);
    }
}
