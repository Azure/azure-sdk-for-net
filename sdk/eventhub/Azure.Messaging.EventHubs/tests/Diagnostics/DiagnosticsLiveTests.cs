using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Dummy.
    /// </summary>
    ///
    [TestFixture]
    [NonParallelizable]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    class DiagnosticsLiveTests
    {
        [Test]
        [Ignore("Injection step not working")]
        public async Task SendFiresEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var eventQueue = DiagnosticsCommon.CreateEventQueue();

                    using (var listener = DiagnosticsCommon.CreateEventListener(null, eventQueue))
                    using (var subscription = DiagnosticsCommon.SubscribeToEvents(listener))
                    {
                        var parentActivity = new Activity("RandomName").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                        var eventData = new EventData(Encoding.UTF8.GetBytes("I hope it works!"));
                        var partitionKey = "AmIaGoodPartitionKey";

                        // Enable Send .Start & .Stop events.

                        listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Exception"));

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.False);
                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.False);

                        parentActivity.Start();

                        await producer.SendAsync(eventData, new SendOptions { PartitionKey = partitionKey });

                        parentActivity.Stop();

                        // Check Diagnostic-Id injection.

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.True);

                        // Check Correlation-Context injection.

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.True);
                        Assert.That(TrackOne.EventHubsDiagnosticSource.SerializeCorrelationContext(parentActivity.Baggage.ToList()), Is.EqualTo(eventData.Properties[TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName]));

                        Assert.That(eventQueue.TryDequeue(out var sendStart), Is.True);
                        // SendStart

                        Assert.That(eventQueue.TryDequeue(out var sendStop), Is.True);
                        // SendStop

                        // There should be no more events to dequeue.

                        Assert.That(eventQueue.TryDequeue(out var evnt), Is.False);
                    }
                }
            }
        }
    }
}
