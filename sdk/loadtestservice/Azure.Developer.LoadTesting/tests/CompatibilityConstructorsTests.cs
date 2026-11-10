// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests
{
    [TestFixture]
    public class CompatibilityConstructorsTests
    {
        [Test]
        public void PreviouslyRequiredModelConstructorsInitializeValues()
        {
            var daily = new DailyRecurrence(2);
            var hourly = new HourlyRecurrence(3);
            var monthly = new MonthlyRecurrenceByWeekDays(2, 4);
            var cron = new RecurrenceWithCron("0 0 * * *");
            var trigger = new ScheduleTestsTrigger("display name", new[] { "test-id" });

            var components = new Dictionary<string, LoadTestingAppComponent>();
            var testComponents = new TestAppComponents(components);
            var runComponents = new TestRunAppComponents(components);

            var metrics = new Dictionary<string, ResourceMetric>();
            var metricsConfiguration = new TestServerMetricsConfiguration(metrics);

            var eventFilters = new Dictionary<string, TestsNotificationEventFilter>();
            var notificationRule = new TestsNotificationRule("display name", new[] { "action-group-id" }, eventFilters);

            Assert.That(daily.Interval, Is.EqualTo(2));
            Assert.That(hourly.Interval, Is.EqualTo(3));
            Assert.That(monthly.Index, Is.EqualTo(2));
            Assert.That(monthly.Interval, Is.EqualTo(4));
            Assert.That(cron.CronExpression, Is.EqualTo("0 0 * * *"));
            Assert.That(trigger.DisplayName, Is.EqualTo("display name"));
            Assert.That(trigger.TestIds, Is.EqualTo(new[] { "test-id" }));
            Assert.That(testComponents.Components, Is.SameAs(components));
            Assert.That(runComponents.Components, Is.SameAs(components));
            Assert.That(metricsConfiguration.Metrics, Is.SameAs(metrics));
            Assert.That(notificationRule.DisplayName, Is.EqualTo("display name"));
            Assert.That(notificationRule.ActionGroupIds, Is.EqualTo(new[] { "action-group-id" }));
            Assert.That(notificationRule.EventFilters, Is.SameAs(eventFilters));
        }
    }
}
