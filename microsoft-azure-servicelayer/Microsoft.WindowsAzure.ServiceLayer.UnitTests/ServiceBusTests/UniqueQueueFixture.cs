using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// A fixture for generating unique queue for a group of tests.
    /// </summary>
    public class UniqueQueueFixture: IDisposable
    {
        public string QueueName { get; private set; }

        /// <summary>
        /// Initializes the fixture by creating a queue with the unique name.
        /// </summary>
        public UniqueQueueFixture()
        {
            QueueName = Configuration.GetUniqueQueueName();
            Configuration.ServiceBus.CreateQueueAsync(QueueName).AsTask().Wait();
        }

        /// <summary>
        /// Disposes the fixture by removing the queue.
        /// </summary>
        void IDisposable.Dispose()
        {
            Configuration.ServiceBus.DeleteQueueAsync(QueueName).AsTask().Wait();
        }
    }
}
