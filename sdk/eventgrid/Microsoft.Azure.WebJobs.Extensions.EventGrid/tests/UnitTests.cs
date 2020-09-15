// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests.Common;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using static Microsoft.Azure.WebJobs.Extensions.EventGrid.EventGridTriggerAttributeBindingProvider;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests
{
    public class UnitTests
    {
        private void DummyMethod(JObject e)
        {
        }

        [Test]
        public async Task BindAsyncTest()
        {
            MethodBase methodbase = this.GetType().GetMethod("DummyMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            ParameterInfo[] arrayParam = methodbase.GetParameters();

            ITriggerBinding binding = new EventGridTriggerBinding(arrayParam[0], null, singleDispatch: true);
            JObject eve = JObject.Parse(FakeData.eventGridEvent);
            JObject data = (JObject)eve["data"];

            // Data for batch binding
            ITriggerBinding bindingBatch = new EventGridTriggerBinding(arrayParam[0], null, singleDispatch: false);
            JArray events = JArray.Parse(FakeData.multipleEventGridEvents);
            IEnumerable<JToken> dataEvents = events.Select(ev => ev["data"]);

            // JObject as input
            ITriggerData triggerDataWithEvent = await binding.BindAsync(eve, null);
            Assert.AreEqual(data, triggerDataWithEvent.BindingData["data"]);

            // JArray as input
            ITriggerData triggerDataWithEvents = await bindingBatch.BindAsync(events, null);
            Assert.AreEqual(dataEvents, triggerDataWithEvents.BindingData["data"]);

            // string as input
            ITriggerData triggerDataWithString = await binding.BindAsync(FakeData.eventGridEvent, null);
            Assert.AreEqual(data, triggerDataWithString.BindingData["data"]);

            // test invalid, batch of events
            FormatException formatException = Assert.Throws<FormatException>(() => binding.BindAsync(FakeData.eventGridEvents, null));
            Assert.AreEqual($"Unable to parse {FakeData.eventGridEvents} to {typeof(JObject)}", formatException.Message);

            // test invalid, random object
            var testObject = new TestClass();
            InvalidOperationException invalidException = Assert.Throws<InvalidOperationException>(() => binding.BindAsync(testObject, null));
            Assert.AreEqual($"Unable to bind {testObject} to type {arrayParam[0].ParameterType}", invalidException.Message);
        }

        private class TestClass
        {
            public override string ToString()
            {
                return "test object";
            }
        }
    }
}
