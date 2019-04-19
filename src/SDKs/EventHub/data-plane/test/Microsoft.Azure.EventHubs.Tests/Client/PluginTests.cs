// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Threading.Tasks;
    using System.Text;
    using Microsoft.Azure.EventHubs.Core;
    using Xunit;

    public class PluginTests
    {
        protected EventHubClient EventHubClient;

        [Fact]
        [DisplayTestMethodName]
        Task Registering_plugin_multiple_times_should_throw()
        {
            this.EventHubClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
            var firstPlugin = new SamplePlugin();
            var secondPlugin = new SamplePlugin();

            this.EventHubClient.RegisterPlugin(firstPlugin);
            Assert.Throws<ArgumentException>(() => EventHubClient.RegisterPlugin(secondPlugin));
            return EventHubClient.CloseAsync();
        }

        [Fact]
        [DisplayTestMethodName]
        Task Unregistering_plugin_should_complete_with_plugin_set()
        {
            this.EventHubClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
            var firstPlugin = new SamplePlugin();

            this.EventHubClient.RegisterPlugin(firstPlugin);
            this.EventHubClient.UnregisterPlugin(firstPlugin.Name);
            return this.EventHubClient.CloseAsync();
        }

        [Fact]
        [DisplayTestMethodName]
        Task Unregistering_plugin_should_complete_without_plugin_set()
        {
            this.EventHubClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
            this.EventHubClient.UnregisterPlugin("Non-existant plugin");
            return this.EventHubClient.CloseAsync();
        }

        [Fact]
        [DisplayTestMethodName]
        async Task Plugin_without_ShouldContinueOnException_should_throw()
        {
            this.EventHubClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
            try
            {
                var plugin = new ExceptionPlugin();

                this.EventHubClient.RegisterPlugin(plugin);
                var testEvent = new EventData(Encoding.UTF8.GetBytes("Test message"));
                await Assert.ThrowsAsync<NotImplementedException>(() => this.EventHubClient.SendAsync(testEvent));
            }
            finally
            {
                await this.EventHubClient.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task Plugin_with_ShouldContinueOnException_should_continue()
        {
            this.EventHubClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
            try
            {
                var plugin = new ShouldCompleteAnywayExceptionPlugin();

                this.EventHubClient.RegisterPlugin(plugin);

                var testEvent = new EventData(Encoding.UTF8.GetBytes("Test message"));
                await this.EventHubClient.SendAsync(testEvent);
            }
            finally
            {
                await this.EventHubClient.CloseAsync();
            }
        }
    }

    internal class SamplePlugin : EventHubsPlugin
    {
        public override string Name => nameof(SamplePlugin);

        public override Task<EventData> BeforeEventSend(EventData eventData)
        {
            eventData.Properties.Add("FirstSendPlugin", true);
            return Task.FromResult(eventData);
        }
    }

    internal class ExceptionPlugin : EventHubsPlugin
    {
        public override string Name => nameof(ExceptionPlugin);

        public override Task<EventData> BeforeEventSend(EventData eventData)
        {
            throw new NotImplementedException();
        }
    }

    internal class ShouldCompleteAnywayExceptionPlugin : EventHubsPlugin
    {
        public override bool ShouldContinueOnException => true;

        public override string Name => nameof(ShouldCompleteAnywayExceptionPlugin);

        public override Task<EventData> BeforeEventSend(EventData eventData)
        {
            throw new NotImplementedException();
        }
    }
}