using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Messaging
{
    public enum ReceiveMode
    {
        /// <summary>Specifies the PeekLock receive mode. This is the default value for <see cref="Microsoft.ServiceBus.Messaging.ReceiveMode" />.</summary>
        PeekLock,
        /// <summary>Specifies the ReceiveAndDelete receive mode.</summary>
        ReceiveAndDelete
    }
}
