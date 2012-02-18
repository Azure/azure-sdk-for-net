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
        /// <summary>
        /// Lists all available queues in the namespace.
        /// </summary>
        /// <returns>Collection of queues</returns>
        IAsyncOperation<IEnumerable<QueueInfo>> ListQueuesAsync();

        /// <summary>
        /// Gets a queue with the given name.
        /// </summary>
        /// <param name="queueName">Name of the queue</param>
        /// <returns>Queue data</returns>
        IAsyncOperation<QueueInfo> GetQueueAsync(string queueName);

        /// <summary>
        /// Deletes a queue with the given name.
        /// </summary>
        /// <param name="queueName">Queue name</param>
        /// <returns>Asynchronous operation</returns>
        IAsyncAction DeleteQueueAsync(string queueName);

        /// <summary>
        /// Creates a queue with the given name and default settings.
        /// </summary>
        /// <param name="queueName">Queue name</param>
        /// <returns>Created queue</returns>
        IAsyncOperation<QueueInfo> CreateQueueAsync(string queueName);

        /// <summary>
        /// Creates a queue with the given parameters.
        /// </summary>
        /// <param name="queueName">Queue name</param>
        /// <param name="queueSettings">Queue parameters</param>
        /// <returns>Created queue</returns>
        IAsyncOperation<QueueInfo> CreateQueueAsync(string queueName, QueueSettings queueSettings);
    }
}
