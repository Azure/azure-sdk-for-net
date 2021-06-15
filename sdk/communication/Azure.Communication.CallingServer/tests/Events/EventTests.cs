// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests.Events
{
    public class EventTests : CallingServerTestBase
    {
        [Test]
        public async Task CallRecordingStateChangeEventTest()
        {
            CallRecordingStateChangeEvent e = new CallRecordingStateChangeEvent("id", CallRecordingState.Active, new DateTimeOffset(DateTime.Now), "callServerId");
            var c = CallRecordingStateChangeEvent.Deserialize(await Serialize(e));

            Assert.IsTrue(this.DeepCompare(e, c));

            e.RecordingId = "id2";
            var d = CallRecordingStateChangeEvent.Deserialize(await Serialize(e));

            Assert.IsFalse(this.DeepCompare(c, d));
        }

        [Test]
        public async Task CallConnectionStateChangedEventTest()
        {
            CallConnectionStateChangedEvent e = new CallConnectionStateChangedEvent("serverCallId", "callConnectionId", CallConnectionState.Disconnected);
            var c = CallConnectionStateChangedEvent.Deserialize(await Serialize(e));

            Assert.IsTrue(this.DeepCompare(e, c));

            e.CallConnectionState = CallConnectionState.Connected;
            var d = CallConnectionStateChangedEvent.Deserialize(await Serialize(e));

            Assert.IsFalse(this.DeepCompare(c, d));
        }

        [Test]
        public async Task AddParticipantResultEventTest()
        {
            AddParticipantResultEvent e = new AddParticipantResultEvent(null, "operatingContext", OperationStatus.Failed);
            var c = AddParticipantResultEvent.Deserialize(await Serialize(e));

            Assert.IsTrue(this.DeepCompare(e, c));

            e.OperationContext = "context";
            var d = AddParticipantResultEvent.Deserialize(await Serialize(e));

            Assert.IsFalse(this.DeepCompare(c, d));
        }

        [Test]
        public async Task PlayAudioResultEventTest()
        {
            PlayAudioResultEvent e = new PlayAudioResultEvent(null, "operatingContext", OperationStatus.Failed);
            var c = PlayAudioResultEvent.Deserialize(await Serialize(e));

            Assert.IsTrue(this.DeepCompare(e, c));

            e.OperationContext = "context";
            var d = PlayAudioResultEvent.Deserialize(await Serialize(e));

            Assert.IsFalse(this.DeepCompare(c, d));
        }

        [Test]
        public async Task ToneReceivedEventTest()
        {
            ToneInfo r = new ToneInfo(1, ToneValue.A);
            ToneReceivedEvent e = new ToneReceivedEvent();
            var c = ToneReceivedEvent.Deserialize(await Serialize(e));

            Assert.IsTrue(this.DeepCompare(e, c));

            e.ToneInfo = new ToneInfo(1, ToneValue.A);
            var d = ToneReceivedEvent.Deserialize(await Serialize(e));

            Assert.IsFalse(this.DeepCompare(c, d));
        }

        private bool DeepCompare(object a, object b)
        {
            _ = a ?? throw new ArgumentNullException(nameof(a));
            _ = b ?? throw new ArgumentNullException(nameof(b));

            if (a.GetType() != b.GetType())
            {
                return false;
            }

            var aType = a.GetType();
            var aProperties = aType.GetProperties().ToList();

            var bType = b.GetType();
            var bProperties = bType.GetProperties().ToList();

            foreach (var aProperty in aProperties)
            {
                var bProperty = bProperties.FirstOrDefault(p => p.Name == aProperty.Name);

                var result = CompareProperty(
                    aProperty,
                    bProperty ?? throw new NullReferenceException($"Missing Property: {aProperty.Name}"));

                if (!result)
                {
                    return false;
                }

                bProperties.Remove(bProperty);
            }

            foreach (var bProperty in bProperties)
            {
                var aProperty = bProperties.FirstOrDefault(p => p.Name == bProperty.Name);
                var result = CompareProperty(
                    aProperty ?? throw new NullReferenceException($"Missing Property: {bProperty.Name}"),
                    bProperty);

                if (!result)
                {
                    return false;
                }
            }

            return true;

            bool CompareProperty(PropertyInfo aPropertyInfo, PropertyInfo bPropertyInfo)
            {
                if (aPropertyInfo is null || bPropertyInfo is null)
                {
                    return false;
                }

                if (aPropertyInfo.GetType().IsByRef != bPropertyInfo.GetType().IsByRef)
                {
                    return false;
                }

                var aValue = aPropertyInfo.GetValue(a);
                var bValue = bPropertyInfo.GetValue(b);

                if (aValue is null && bValue is null)
                {
                    return true;
                }
                else if (aValue is null || bValue is null)
                {
                    return false;
                }

                if (aPropertyInfo.GetType().IsByRef)
                {
                    return DeepCompare(aValue, bValue);
                }
                else
                {
                    return aValue.Equals(bValue);
                }
            }
        }

        private async Task<string> Serialize<T>(T e) where T : IUtf8JsonSerializable
        {
            var m = new MemoryStream();
            var w = new Utf8JsonWriter(m);
            e.Write(w);
            await w.FlushAsync();
            m.Position = 0;
            return await new StreamReader(m).ReadToEndAsync();
        }
    }
}
