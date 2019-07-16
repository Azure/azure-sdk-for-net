using System.Linq;
using System.Text;
using Azure.Messaging.EventHubs.Diagnostics;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Dummy.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    class DiagnosticsTests
    {
        [Test]
        public void ExtractsActivityWithIdAndNoContext()
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));

            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";

            var activity = eventData.ExtractActivity();

            Assert.That(activity.ParentId, Is.EqualTo("diagnostic-id"));
            Assert.That(activity.RootId, Is.EqualTo("diagnostic-id"));
            Assert.That(activity.Id, Is.Null);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.That(baggage, Is.Empty);
        }

        [Test]
        public void ExtractsActivityWithIdAndSingleContext()
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));

            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";
            eventData.Properties["Correlation-Context"] = "k1=v1";

            var activity = eventData.ExtractActivity();

            Assert.That(activity.ParentId, Is.EqualTo("diagnostic-id"));
            Assert.That(activity.RootId, Is.EqualTo("diagnostic-id"));
            Assert.That(activity.Id, Is.Null);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Assert.That(baggage.Count, Is.EqualTo(1));
            Assert.That(baggage.Keys.Contains("k1"), Is.True);
            Assert.That(baggage["k1"], Is.EqualTo("v1"));
        }

        [Test]
        public void ExtractsActivityWithIdAndMultiContext()
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));

            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";
            eventData.Properties["Correlation-Context"] = "k1=v1,k2=v2,k3=v3";

            var activity = eventData.ExtractActivity();

            Assert.That(activity.ParentId, Is.EqualTo("diagnostic-id"));
            Assert.That(activity.RootId, Is.EqualTo("diagnostic-id"));
            Assert.That(activity.Id, Is.Null);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Assert.That(baggage.Count, Is.EqualTo(3));
            Assert.That(baggage.Keys.Contains("k1"), Is.True);
            Assert.That(baggage.Keys.Contains("k2"), Is.True);
            Assert.That(baggage.Keys.Contains("k3"), Is.True);
            Assert.That(baggage["k1"], Is.EqualTo("v1"));
            Assert.That(baggage["k2"], Is.EqualTo("v2"));
            Assert.That(baggage["k3"], Is.EqualTo("v3"));
        }

        [Test]
        public void ExtractActivityWithAlternateName()
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));

            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";

            var activity = eventData.ExtractActivity("My activity");
            Assert.That(activity.OperationName, Is.EqualTo("My activity"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("not valid context")]
        [TestCase("not,valid,context")]
        public void ExtractsActivityWithIdAndInvalidContext(string context)
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));

            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";
            eventData.Properties["Correlation-Context"] = context;

            var activity = eventData.ExtractActivity();

            Assert.That(activity.ParentId, Is.EqualTo("diagnostic-id"));
            Assert.That(activity.RootId, Is.EqualTo("diagnostic-id"));
            Assert.That(activity.Id, Is.Null);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.That(baggage, Is.Empty);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ExtractsActivityWithoutIdAsRoot(string id)
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));

            eventData.Properties["Diagnostic-Id"] = id;
            eventData.Properties["Correlation-Context"] = "k1=v1,k2=v2";

            var activity = eventData.ExtractActivity();

            Assert.That(activity.ParentId, Is.Null);
            Assert.That(activity.RootId, Is.Null);
            Assert.That(activity.Id, Is.Null);

            // Baggage is ignored in absence of Id.

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.That(baggage, Is.Empty);
        }
    }
}
