// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Indexers
{
    internal class FunctionDefinition : IFunctionDefinition
    {
        private readonly FunctionDescriptor _descriptor;
        private readonly IFunctionInstanceFactory _instanceFactory;
        private readonly IListenerFactory _listenerFactory;

        public FunctionDefinition(FunctionDescriptor descriptor, IFunctionInstanceFactory instanceFactory, IListenerFactory listenerFactory)
        {
            _descriptor = descriptor;
            _instanceFactory = instanceFactory;
            _listenerFactory = listenerFactory;
        }

        public FunctionDescriptor Descriptor
        {
            get
            {
                return _descriptor;
            }
        }

        public IFunctionInstanceFactory InstanceFactory
        {
            get { return _instanceFactory; }
        }

        public IListenerFactory ListenerFactory
        {
            get { return _listenerFactory; }
        }
    }
}
