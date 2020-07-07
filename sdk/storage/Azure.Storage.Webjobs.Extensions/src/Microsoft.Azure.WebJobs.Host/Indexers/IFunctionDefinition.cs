// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Indexers
{
    public interface IFunctionDefinition
    {
        FunctionDescriptor Descriptor { get; }

        IFunctionInstanceFactory InstanceFactory { get; }

        IListenerFactory ListenerFactory { get; }
    }
}
