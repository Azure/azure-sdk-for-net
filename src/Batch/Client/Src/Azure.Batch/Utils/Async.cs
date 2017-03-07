using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Utils
{
    internal static class Async
    {
        internal static readonly Task CompletedTask = Task.Delay(0);
    }
}
