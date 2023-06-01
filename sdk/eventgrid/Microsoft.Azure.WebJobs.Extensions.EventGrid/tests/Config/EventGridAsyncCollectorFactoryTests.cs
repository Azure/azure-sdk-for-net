// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Microsoft.Azure.WebJobs.Extensions.EventGrid.Config;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests.Config
{
    internal class EventGridAsyncCollectorFactoryTests
    {
        [Test]
        [TestCase(null, null, null, "The 'Connection.topicEndpointUri' property or 'TopicEndpointUri' property must be set")]
        [TestCase("", null, null, "The 'Connection.topicEndpointUri' property or 'TopicEndpointUri' property must be set")]
        [TestCase(null, null, "", "The 'Connection.topicEndpointUri' property or 'TopicEndpointUri' property must be set")]
        [TestCase(null, null, "EmptyUri", "The 'Connection.topicEndpointUri' property or 'TopicEndpointUri' property must be set")]
        [TestCase("bar.com", "baz", null, "The 'TopicEndpointUri' property must be a valid absolute Uri")]
        [TestCase(null, "baz", "ValidUri", "Conflicting topic credentials have been set in 'ValidUri' and 'TopicKeySetting'")]
        [TestCase("https://foo.com", "baz", "ValidUri", "Conflicting topic credentials have been set in 'ValidUri' and 'TopicKeySetting'")]
        [TestCase("https://foo.com", null, "MissingUri", "The topic endpoint uri in 'MissingUri' does not exist. Make sure that it is a defined App Setting.")]
        [TestCase("https://foo.com", null, "InvalidUri", "The topic endpoint uri in 'InvalidUri' must be a valid absolute Uri")]
        [TestCase("https://foo.com", null, "AnotherUri", "Conflicting topic endpoint uris have been set in 'AnotherUri' and 'TopicEndpointUri'")]
        public void ValidateOutputBindingAttributeTests(string topicEndpointUri, string topicKeySetting, string connection, string message)
        {
            var host = TestHelpers.NewHost<Empty>(configuration: new Dictionary<string, string>
            {
                { "EmptyUri:topicEndpointUri", "" },
                { "InvalidUri:topicEndpointUri", "bar.com" },
                { "ValidUri:topicEndpointUri", "https://foo.com" },
                { "AnotherUri:topicEndpointUri", "https://bar.com" },
            });

            var factory = host.Services.GetRequiredService<EventGridAsyncCollectorFactory>();
            var exception = Assert.Throws<InvalidOperationException>(() => factory.Validate(new EventGridAttribute
            {
                TopicEndpointUri = topicEndpointUri,
                TopicKeySetting = topicKeySetting,
                Connection = connection
            }));

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [Test]
        public void TestTopicKeySetting()
        {
            var host = TestHelpers.NewHost<Empty>();
            var factory = host.Services.GetRequiredService<EventGridAsyncCollectorFactory>();

            var connectionInformation = factory.ResolveConnectionInformation(new EventGridAttribute
            {
                TopicEndpointUri = "https://foo.com",
                TopicKeySetting = "Bar",
                Connection = null
            });

            Assert.That(connectionInformation.AzureKeyCredential, Is.Not.Null);
        }

        [Test]
        [TestCase("https://foo.com", null, null)]
        [TestCase(null, null, "ValidUri")]
        [TestCase("https://foo.com", null, "EmptyUri")]
        public void TestSystemAssignedIdentity(string topicEndpointUri, string topicKeySetting, string connection)
        {
            var host = TestHelpers.NewHost<Empty>(configuration: new Dictionary<string, string>
            {
                { "EmptyUri:topicEndpointUri", "" },
                { "ValidUri:topicEndpointUri", "https://foo.com" },
            });
            var factory = host.Services.GetRequiredService<EventGridAsyncCollectorFactory>();

            var connectionInformation = factory.ResolveConnectionInformation(new EventGridAttribute
            {
                TopicEndpointUri = topicEndpointUri,
                TopicKeySetting = topicKeySetting,
                Connection = connection
            });

            Assert.That(connectionInformation.TokenCredential, Is.Not.Null.And.TypeOf<DefaultAzureCredential>());
        }

        public class Empty
        {
        }
    }
}
