// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Tests for input text streaming client event types.
    /// Note: ClientEventInputTextDelta and ClientEventInputTextDone are internal in C# and cannot be
    /// directly instantiated from the test project. Event type string registration is verified here;
    /// wire-level behavior is covered by integration tests.
    /// </summary>
    [TestFixture]
    public class InputTextStreamingEventsTests
    {
        [Test]
        public void InputTextEventTypeStrings_AreRegistered()
        {
            Assert.That(ClientEventType.InputTextDelta.ToString(), Is.EqualTo("input_text.delta"));
            Assert.That(ClientEventType.InputTextDone.ToString(), Is.EqualTo("input_text.done"));
        }
    }
}
