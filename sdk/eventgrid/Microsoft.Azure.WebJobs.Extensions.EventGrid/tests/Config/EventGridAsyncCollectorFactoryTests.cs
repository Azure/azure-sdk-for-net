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
        [TestCase(null, null, null, EventGridAsyncCollectorFactory.MissingSettingsErrorMessage)]
        [TestCase("", null, null, EventGridAsyncCollectorFactory.MissingSettingsErrorMessage)]
        [TestCase(null, null, "", EventGridAsyncCollectorFactory.MissingSettingsErrorMessage)]
        [TestCase(null, null, "EmptyUri", "The 'topicEndpointUri' was not specified in 'EmptyUri'.")]
        [TestCase("bar.com", "baz", null, EventGridAsyncCollectorFactory.MustBeValidAbsoluteUriErrorMessage)]
        [TestCase(null, "baz", "ValidUri", EventGridAsyncCollectorFactory.ConflictingSettingsErrorMessage)]
        [TestCase("https://foo.com", "baz", "ValidUri", EventGridAsyncCollectorFactory.ConflictingSettingsErrorMessage)]
        [TestCase("https://foo.com", null, "ValidUri", EventGridAsyncCollectorFactory.ConflictingSettingsErrorMessage)]
        [TestCase("https://foo.com", null, null, EventGridAsyncCollectorFactory.MissingTopicKeySettingErrorMessage)]
        [TestCase(null, null, "MissingUri", "The 'MissingUri' setting does not exist. Make sure that it is a defined App Setting.")]
        [TestCase(null, null, "InvalidUri", "The 'topicEndpointUri' in 'InvalidUri' must be a valid absolute Uri.")]
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
            Assert.That(exception, Is.InstanceOf<InvalidOperationException>());
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
        public void TestMissingKeySetting()
        {
            var host = TestHelpers.NewHost<Empty>();
            var factory = host.Services.GetRequiredService<EventGridAsyncCollectorFactory>();

            var exception = Assert.Throws<InvalidOperationException>(() => factory.Validate(new EventGridAttribute
            {
                TopicEndpointUri = "https://foo.com"
            }));

            Assert.That(exception.Message, Is.EqualTo("The 'TopicKeySetting' property must be the name of an application setting containing the Topic Key."));
            Assert.That(exception, Is.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void TestMissingUriSetting()
        {
            var host = TestHelpers.NewHost<Empty>();
            var factory = host.Services.GetRequiredService<EventGridAsyncCollectorFactory>();

            var exception = Assert.Throws<InvalidOperationException>(() => factory.Validate(new EventGridAttribute
            {
                TopicKeySetting = "Bar"
            }));

            Assert.That(exception.Message, Is.EqualTo(EventGridAsyncCollectorFactory.MissingSettingsErrorMessage));
            Assert.That(exception, Is.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void TestMissingUriSetting_Connection()
        {
            var host = TestHelpers.NewHost<Empty>(configuration: new Dictionary<string, string>
            {
                { "MissingUri:clientId", "clientId" },
            });
            var factory = host.Services.GetRequiredService<EventGridAsyncCollectorFactory>();

            var exception = Assert.Throws<InvalidOperationException>(() => factory.Validate(new EventGridAttribute
            {
                Connection = "MissingUri"
            }));

            Assert.That(exception.Message, Is.EqualTo("The 'topicEndpointUri' was not specified in 'MissingUri'."));
            Assert.That(exception, Is.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void TestInvalidUriSetting()
        {
            var host = TestHelpers.NewHost<Empty>(configuration: new Dictionary<string, string>
            {
                { "InvalidUri:topicEndpointUri", "bar.com" },
            });
            var factory = host.Services.GetRequiredService<EventGridAsyncCollectorFactory>();

            var exception = Assert.Throws<InvalidOperationException>(() => factory.Validate(new EventGridAttribute
            {
                Connection = "InvalidUri"
            }));

            Assert.That(exception.Message, Is.EqualTo("The 'topicEndpointUri' in 'InvalidUri' must be a valid absolute Uri."));
            Assert.That(exception, Is.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void TestSystemAssignedIdentity()
        {
            var host = TestHelpers.NewHost<Empty>(configuration: new Dictionary<string, string>
            {
                { "ValidUri:topicEndpointUri", "https://foo.com" },
            });
            var factory = host.Services.GetRequiredService<EventGridAsyncCollectorFactory>();

            var connectionInformation = factory.ResolveConnectionInformation(new EventGridAttribute
            {
                Connection = "ValidUri"
            });

            Assert.That(connectionInformation.TokenCredential, Is.Not.Null.And.TypeOf<DefaultAzureCredential>());
        }

        public class Empty
        {
        }
    }
}
