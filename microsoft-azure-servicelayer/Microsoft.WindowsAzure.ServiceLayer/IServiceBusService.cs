using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.Foundation;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Service bus service
    /// </summary>
    public interface IServiceBusService
    {
        IAsyncOperation<IEnumerable<QueueInfo>> ListQueuesAsync();
    }
}
