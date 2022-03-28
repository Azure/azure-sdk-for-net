using System.Threading;
using Azure.Messaging.EventHubs;

namespace ProcessorEmptyReadTest
{
    internal static class EventHubsExceptionExtensions
    {
        public static void TrackMetrics(this EventHubsException instance,
                                        Metrics metrics)
        {
            switch (instance.Reason)
            {
                case EventHubsException.FailureReason.ServiceTimeout:
                    Interlocked.Increment(ref metrics.TimeoutExceptions);
                    break;

                case EventHubsException.FailureReason.ServiceCommunicationProblem:
                    Interlocked.Increment(ref metrics.CommunicationExceptions);
                    break;

                case EventHubsException.FailureReason.ServiceBusy:
                    Interlocked.Increment(ref metrics.ServiceBusyExceptions);
                    break;

                default:
                    Interlocked.Increment(ref metrics.GeneralExceptions);
                    break;
            }
        }
    }
}