using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;

using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests
{
    /// <summary>
    /// Tests for the service bus management.
    /// </summary>
    public class ServiceBusManagementTests
    {
        class InternalQueueInfoComparer : IEqualityComparer<QueueInfo>
        {
            bool IEqualityComparer<QueueInfo>.Equals(QueueInfo x, QueueInfo y)
            {
                return x.DefaultMessageTimeToLive == y.DefaultMessageTimeToLive
                    && x.DuplicateDetectionHistoryTimeWindow == y.DuplicateDetectionHistoryTimeWindow
                    && x.EnableBatchedOperations == y.EnableBatchedOperations
                    && x.EnableDeadLetteringOnMessageExpiration == y.EnableDeadLetteringOnMessageExpiration
                    && x.LockDuration == y.LockDuration
                    && x.MaxDeliveryCount == y.MaxDeliveryCount
                    && x.MaxSizeInMegabytes == y.MaxSizeInMegabytes
                    && x.MessageCount == y.MessageCount
                    && string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase)
                    && x.RequiresDuplicateDetection == y.RequiresDuplicateDetection
                    && x.RequiresSession == y.RequiresSession
                    && x.SizeInBytes == y.SizeInBytes
                    && string.Equals(x.Uri.ToString(), y.Uri.ToString(), StringComparison.OrdinalIgnoreCase);
            }

            int IEqualityComparer<QueueInfo>.GetHashCode(QueueInfo obj)
            {
                return obj.GetHashCode();
            }
        }

        IServiceBusService Service { get; set; }
        IEqualityComparer<QueueInfo> QueueInfoComparer { get; set; }

        public ServiceBusManagementTests()
        {
            Service = ServiceBusService.Create(Configuration.ServiceNamespace, Configuration.UserName, Configuration.Password);
            QueueInfoComparer = new InternalQueueInfoComparer();
        }


        string GetUniqueEntityName()
        {
            return string.Format("UnitTests.{0}", Guid.NewGuid().ToString());
        }

        Dictionary<string, QueueInfo> GetQueues()
        {
            Dictionary<string, QueueInfo> queues = new Dictionary<string, QueueInfo>(StringComparer.OrdinalIgnoreCase);
            foreach (QueueInfo queue in Service.ListQueuesAsync().AsTask<IEnumerable<QueueInfo>>().Result)
            {
                queues.Add(queue.Name, queue);
            }
            return queues;
        }

        [Fact]
        public void NullArgsInQueues()
        {
            Assert.Throws<ArgumentNullException>(() => Service.CreateQueueAsync(null));
            Assert.Throws<ArgumentNullException>(() => Service.CreateQueueAsync(null, new QueueSettings()));
            Assert.Throws<ArgumentNullException>(() => Service.CreateQueueAsync("foo", null));
            Assert.Throws<ArgumentNullException>(() => Service.GetQueueAsync(null));
            Assert.Throws<ArgumentNullException>(() => Service.DeleteQueueAsync(null));
        }

        /// <summary>
        /// Tests full lifecycle of a queue.
        /// </summary>
        [Fact]
        public void QueueLifecycle()
        {
            // Create a queue.
            string queueName = GetUniqueEntityName();
            QueueInfo newQueue = Service.CreateQueueAsync(queueName).AsTask<QueueInfo>().Result;

            // Confirm that the queue can be obtained from the server
            QueueInfo storedQueue = Service.GetQueueAsync(queueName).AsTask<QueueInfo>().Result;
            Assert.Equal<QueueInfo>(storedQueue, newQueue, QueueInfoComparer);

            // Confirm that the queue can be obtained in the list
            Dictionary<string, QueueInfo> queues = GetQueues();

            Assert.True(queues.ContainsKey(queueName));
            Assert.Equal<QueueInfo>(newQueue, queues[queueName], QueueInfoComparer);

            // Delete the queue
            Service.DeleteQueueAsync(queueName).AsTask().Wait();
            queues = GetQueues();
            Assert.False(queues.ContainsKey(queueName));
        }

        /// <summary>
        /// Verifies that using an existing name for a new queue result in an exception.
        /// </summary>
        [Fact]
        public void CreateQueueDuplicateName()
        {
            // Create a queue
            string queueName = GetUniqueEntityName();
            QueueInfo newQueue = Service.CreateQueueAsync(queueName).AsTask<QueueInfo>().Result;

            Task t = Service.CreateQueueAsync(queueName).AsTask();
            Assert.Throws<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Verifies creation of the queue with all non-default parameters
        /// </summary>
        [Fact]
        public void CreateQueueWithNonDefaultParams()
        {
            string queueName = GetUniqueEntityName();
            QueueSettings settings = new QueueSettings();

            settings.DefaultMessageTimeToLive = TimeSpan.FromHours(24);
            settings.DuplicateDetectionHistoryTimeWindow = TimeSpan.FromDays(2);
            settings.EnableBatchedOperations = false;
            settings.EnableDeadLetteringOnMessageExpiration = true;
            settings.LockDuration = TimeSpan.FromMinutes(3);
            settings.MaxDeliveryCount = 5;
            settings.MaxSizeInMegabytes = 2048;
            settings.RequiresDuplicateDetection = true;
            settings.RequiresSession = true;

            QueueInfo queueInfo = Service.CreateQueueAsync(queueName, settings).AsTask<QueueInfo>().Result;
            Assert.Equal(queueInfo.DefaultMessageTimeToLive, settings.DefaultMessageTimeToLive.Value);
            Assert.Equal(queueInfo.DuplicateDetectionHistoryTimeWindow, settings.DuplicateDetectionHistoryTimeWindow.Value);
            Assert.Equal(queueInfo.EnableBatchedOperations, settings.EnableBatchedOperations.Value);
            Assert.Equal(queueInfo.EnableDeadLetteringOnMessageExpiration, settings.EnableDeadLetteringOnMessageExpiration.Value);
            Assert.Equal(queueInfo.LockDuration, settings.LockDuration.Value);
            Assert.Equal(queueInfo.MaxDeliveryCount, settings.MaxDeliveryCount.Value);
            Assert.Equal(queueInfo.MaxSizeInMegabytes, settings.MaxSizeInMegabytes.Value);
            Assert.Equal(queueInfo.RequiresDuplicateDetection, settings.RequiresDuplicateDetection.Value);
            Assert.Equal(queueInfo.RequiresSession, settings.RequiresSession.Value);
        }
    }
}
