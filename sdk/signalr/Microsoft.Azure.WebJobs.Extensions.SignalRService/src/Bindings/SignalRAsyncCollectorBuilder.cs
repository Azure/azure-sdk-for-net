// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRAsyncCollectorBuilder<T> : IAsyncConverter<SignalRAttribute, IAsyncCollector<T>>
    {
        private readonly IServiceManagerStore _managerStore;

        public SignalRAsyncCollectorBuilder(IServiceManagerStore managerStore)
        {
            _managerStore = managerStore;
        }

        public async Task<IAsyncCollector<T>> ConvertAsync(SignalRAttribute input, CancellationToken cancellationToken)
        {
            var client = await Utils.GetAzureSignalRClientAsync(input.ConnectionStringSetting, input.HubName, _managerStore).ConfigureAwait(false);
            return new SignalRAsyncCollector<T>(client);
        }
    }
}