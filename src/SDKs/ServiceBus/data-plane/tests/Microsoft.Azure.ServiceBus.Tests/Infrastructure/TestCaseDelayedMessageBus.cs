using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    /// <summary>
    ///   Used to capture messages to potentially be forwarded later. Messages are forwarded by
    ///   disposing of the message bus.
    /// </summary
    /// 
    /// <remarks>
    ///   Based on the XUnit Sample:
    ///   https://github.com/xunit/samples.xunit/tree/master/RetryFactExample
    /// </remarks>
    /// 
    internal class TestCaseDelayedMessageBus : IMessageBus
    {
        private readonly IMessageBus innerBus;
        private readonly List<IMessageSinkMessage> messages = new List<IMessageSinkMessage>();
        
        public TestCaseDelayedMessageBus(IMessageBus innerBus)
        {
            this.innerBus = innerBus;
        }
        
        public bool QueueMessage(IMessageSinkMessage message)
        {
            lock (messages)
            {
                messages.Add(message);
            }
        
            // No way to ask the inner bus if they want to cancel without sending them the message, so
            // we just go ahead and continue always.
            return true;
        }
        
        public void Dispose()
        {
            foreach (var message in messages)
            {
                innerBus.QueueMessage(message);
            }
        }
    }
}
