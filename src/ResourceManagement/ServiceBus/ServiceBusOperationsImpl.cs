// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ServiceBus.Fluent;

namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
    using System;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The implementation of ServiceBusOperations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU2VydmljZUJ1c09wZXJhdGlvbnNJbXBs
    internal partial class ServiceBusOperationsImpl :
        ReadableWrappers<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusOperation,
            Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusOperationImpl,
            Models.Operation>,
        IServiceBusOperations
    {
        private IOperations client;
        private IServiceBusManager manager;

        ///GENMHASH:9B1D3873FF71223189782E38CD28D350:820D400924B14AAA0FDF99261AB8CEC4
        internal ServiceBusOperationsImpl(IServiceBusManager manager)
        {
            this.client = manager.Inner.Operations;
            this.manager = manager;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IServiceBusManager Manager()
        {
            return this.manager;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:BDD4784792410F2C6C5B16513D2369A0
        IOperations IHasInner<IOperations>.Inner
        {
            get
            {
                return this.client;
            }
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:1F240F2F28F726FE4D55C13D630B141C
        public IEnumerable<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusOperation> List()
        {
            return this.ListAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:937B09D91ECA02A359C00855DBB26BBE
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IServiceBusOperation>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            Func<string, CancellationToken, Task<IPage<Models.Operation>>> listNextNext = (string nextLink, CancellationToken token) =>
            {
                if (nextLink == "")
                {
                    return Task.FromResult<IPage<Models.Operation>>((new Page<Models.Operation>()));
                }
                return client.ListNextAsync(nextLink, token);
            };

            return await PagedCollection<IServiceBusOperation, Operation>.LoadPage(async (cancellation) => await client.ListAsync(cancellation),
                listNextNext, WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:816BE32CB291312AA34F4C0AE02796BA:A51CF20B6BF9CE09FFA405D51BE889ED
        protected override IServiceBusOperation WrapModel(Operation inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new ServiceBusOperationImpl(inner);
        }
    }
}