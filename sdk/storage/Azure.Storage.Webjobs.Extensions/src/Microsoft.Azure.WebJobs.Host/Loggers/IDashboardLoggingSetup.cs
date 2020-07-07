// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using Microsoft.Azure.WebJobs.Host.Dispatch;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using static Microsoft.Azure.WebJobs.Host.Executors.JobHostContextFactory;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    // $$$
    // For hoisting the V1 logging work out to Host.Storage.
    internal interface IDashboardLoggingSetup
    {
        bool Setup(
            IFunctionIndex functions,
            IListenerFactory functionsListenerFactory,
            out IFunctionExecutor hostCallExecutor,
            out IListener listener,
            out HostOutputMessage hostOutputMessage,
            string hostId,
            CancellationToken shutdownToken);
    }

    // $$$ An "empty" implementation that disables everything.
    // V1 WebJobs logging can replace this with a storage-backed impl.
    internal class NullDashboardLoggingSetup : IDashboardLoggingSetup
    {
        private readonly IFunctionExecutor _functionExecutor;
        private readonly SharedQueueHandler _sharedQueueHandler;

        public NullDashboardLoggingSetup(IFunctionExecutor functionExecutor, SharedQueueHandler sharedQueueHandler)
        {
            _functionExecutor = functionExecutor;
            _sharedQueueHandler = sharedQueueHandler;
        }

        public bool Setup(IFunctionIndex functions, IListenerFactory functionsListenerFactory, out IFunctionExecutor hostCallExecutor, out IListener listener, out HostOutputMessage hostOutputMessage, string hostId, CancellationToken shutdownToken)
        {
            hostCallExecutor = new ShutdownFunctionExecutor(shutdownToken, _functionExecutor);
            hostOutputMessage = new DataOnlyHostOutputMessage();

            IListener factoryListener = new ListenerFactoryListener(functionsListenerFactory, _sharedQueueHandler);
            listener = new ShutdownListener(shutdownToken, factoryListener);
            
            return false;
        }
    }
}
