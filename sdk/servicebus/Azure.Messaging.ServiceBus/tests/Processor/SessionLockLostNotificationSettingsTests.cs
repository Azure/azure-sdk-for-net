// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    [NonParallelizable]
    public class SessionLockLostNotificationSettingsTests
    {
        [Test]
        public void FixtureRestoresOriginalCompatibilitySettings()
        {
            bool switchWasPresent = AppContext.TryGetSwitch(SessionReceiverManager.DisableEagerSessionLockLostSwitch, out bool originalSwitch);
            string originalEnvironmentValue = Environment.GetEnvironmentVariable(SessionReceiverManager.DisableEagerSessionLockLostEnvironmentVariable);
            var fixture = new SessionLockLostNotificationTests();

            fixture.ResetCompatibilitySettings();
            fixture.RestoreCompatibilitySettings();

            Assert.That(
                AppContext.TryGetSwitch(SessionReceiverManager.DisableEagerSessionLockLostSwitch, out bool restoredSwitch),
                Is.EqualTo(switchWasPresent));
            Assert.That(restoredSwitch, Is.EqualTo(originalSwitch));
            Assert.That(
                Environment.GetEnvironmentVariable(SessionReceiverManager.DisableEagerSessionLockLostEnvironmentVariable),
                Is.EqualTo(originalEnvironmentValue));
        }
    }
}
