using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Messaging
{
    internal enum SubqueueType
    {
        /// <summary> The Active Subqueue. </summary>
        Active = 0,

        /// <summary> The DeadLettered Subqueue.  </summary>
        DeadLettered = 3,

        /// <summary> The Scheduled Subqueue.  </summary>
        Scheduled = 4,
    }
}
