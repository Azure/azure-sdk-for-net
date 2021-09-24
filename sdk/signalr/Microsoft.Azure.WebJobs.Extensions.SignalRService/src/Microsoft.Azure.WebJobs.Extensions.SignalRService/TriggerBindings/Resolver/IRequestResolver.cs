// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Serverless.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal interface IRequestResolver
    {
        bool ValidateContentType(HttpRequestMessage request);

        bool ValidateSignature(HttpRequestMessage request, AccessKey[] accessKeys);

        bool TryGetInvocationContext(HttpRequestMessage request, out InvocationContext context);

        Task<(T, IHubProtocol)> GetMessageAsync<T>(HttpRequestMessage request) where T : ServerlessMessage, new();
    }
}