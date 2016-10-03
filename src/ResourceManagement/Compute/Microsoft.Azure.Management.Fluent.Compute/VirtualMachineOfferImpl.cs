// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Fluent.Resource.Core;

namespace Microsoft.Azure.Management.Fluent.Compute
{
    internal partial class VirtualMachineOfferImpl : IVirtualMachineOffer
    {
        private IVirtualMachinePublisher publisher;
        private IVirtualMachineSkus skus;

        internal VirtualMachineOfferImpl(IVirtualMachinePublisher publisher, string offer, IVirtualMachineImagesOperations client)
        {
            this.publisher = publisher;
            Name = offer;
            skus = new VirtualMachineSkusImpl(this, client);
        }

        public string Name
        {
            get; private set;
        }

        public Region Region
        {
            get
            {
                return publisher.Region;
            }
        }

        public IVirtualMachinePublisher Publisher
        {
            get
            {
                return publisher;
            }
        }

        public IVirtualMachineSkus Skus
        {
            get
            {
                return skus;
            }
        }
    }
}
