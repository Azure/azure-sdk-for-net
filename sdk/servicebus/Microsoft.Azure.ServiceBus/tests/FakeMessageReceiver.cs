using Microsoft.Azure.ServiceBus.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    public sealed class FakeMessageReceiver : MessageReceiver
    {
        private readonly Func<int, TimeSpan, Task<IList<Message>>> onReceiveCallback;
        private readonly Func<IEnumerable<string>, Task> onCompleteCallback;
        private readonly Func<string, IDictionary<string, object>, Task> onAbandonCallback;

        public FakeMessageReceiver(
            Func<int, TimeSpan, Task<IList<Message>>> onReceiveCallback,
            Func<IEnumerable<string>, Task> onCompleteCallback = default,
            Func<string, IDictionary<string, object>, Task> onAbandonCallback = default,
            ReceiveMode receiveMode = ReceiveMode.PeekLock)
            : base(
                  new ServiceBusConnectionStringBuilder("blah.com", "path", "key-name", "key-value"),
                  receiveMode)
        {
            this.onReceiveCallback = onReceiveCallback;
            this.onCompleteCallback = onCompleteCallback;
            this.onAbandonCallback = onAbandonCallback;
        }

        protected override Task<IList<Message>> OnReceiveAsync(int maxMessageCount, TimeSpan serverWaitTime)
        {
            return this.onReceiveCallback(maxMessageCount, serverWaitTime);
        }

        protected override Task OnCompleteAsync(IEnumerable<string> lockTokens)
        {
            this.onCompleteCallback(lockTokens);
            return base.OnCompleteAsync(lockTokens);
        }

        protected override Task OnAbandonAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            this.onAbandonCallback(lockToken, propertiesToModify);
            return base.OnAbandonAsync(lockToken, propertiesToModify);
        }
    }
}
