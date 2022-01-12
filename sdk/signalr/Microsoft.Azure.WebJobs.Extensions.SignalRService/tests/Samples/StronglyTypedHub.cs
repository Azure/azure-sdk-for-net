// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Samples
{
    #region Snippet:StronglyTypedHub
    public class StronglyTypedHub : ServerlessHub<IChatClient>
    {
        [FunctionName(nameof(Broadcast))]
        public async Task Broadcast([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest _, string message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
    #endregion

    #region Snippet:StronglyTypedHub_ClientMethodInterface
    public interface IChatClient
    {
        Task ReceiveMessage(string message);
    }
    #endregion
}