// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests
{
    public interface IChatClient
    {
        Task ReceiveMessage(string message);
    }
}
