// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Metadata;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubClientTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorExpandedArgumentInvalidCases()
        {
            var credential = Mock.Of<TokenCredential>();

            yield return new object[] { null, "fakePath", credential };
            yield return new object[] { "", "fakePath", credential };
            yield return new object[] { "FakeHost", null, credential };
            yield return new object[] { "FakeHost", "", credential };
            yield return new object[] { "FakeHost", "FakePath", null };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorCreatesDefaultOptionsCases()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            yield return new object[] { new EventHubClient(fakeConnection), "simple connection string" };
            yield return new object[] { new EventHubClient(fakeConnection), "connection string with null options" };
            yield return new object[] { new EventHubClient("host", "path", Mock.Of<TokenCredential>()), "expanded argument" };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorClonesOptionsCases()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            var options = new EventHubClientOptions
            {
                ConnectionType = ConnectionType.AmqpWebSockets,
                DefaultTimeout = TimeSpan.FromHours(2),
                Retry = new ExponentialRetry(TimeSpan.FromMinutes(10), TimeSpan.FromHours(1), 24),
                Proxy = Mock.Of<IWebProxy>()
            };

            yield return new object[] { new EventHubClient(fakeConnection, options), options, "connection string" };
            yield return new object[] { new EventHubClient("host", "path", Mock.Of<TokenCredential>(), options), options, "expanded argument" };
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresConnectionString(string connectionString)
        {
            Assert.That(() => new EventHubClient(connectionString), Throws.ArgumentException, "The constructor without options should perform validation.");
            Assert.That(() => new EventHubClient(connectionString, new EventHubClientOptions()), Throws.ArgumentException, "The constructor with options should perform validation.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDoesNotRequireOptionsWithConnectionString()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            Assert.That(() => new EventHubClient(fakeConnection, null), Throws.Nothing);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        public void ConstructorValidatesConnectionString(string connectionString)
        {
            Assert.That(() => new EventHubClient(connectionString), Throws.ArgumentException);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorExpandedArgumentInvalidCases))]
        public void ConstructorValidatesExpandedArguments(string host,
                                                          string eventHubPath,
                                                          TokenCredential credential)
        {
            Assert.That(() => new EventHubClient(host, eventHubPath, credential), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(EventHubClient client,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventHubClientOptions();

            var options = (EventHubClientOptions)typeof(EventHubClient)
                .GetProperty("ClientOptions", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(client);

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.ConnectionType, Is.EqualTo(defaultOptions.ConnectionType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.DefaultTimeout, Is.EqualTo(defaultOptions.DefaultTimeout), $"The { constructorDescription } constructor should have the correct default timeout.");
            Assert.That(options.Proxy, Is.EqualTo(defaultOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)options.Retry, (ExponentialRetry)defaultOptions.Retry), $"The { constructorDescription } constructor should have the correct retry.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorClonesOptionsCases))]
        public void ConstructorClonesOptions(EventHubClient client,
                                             EventHubClientOptions constructorOptions,
                                             string constructorDescription)
        {
            var options = (EventHubClientOptions)typeof(EventHubClient)
                .GetProperty("ClientOptions", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(client);

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set the options.");
            Assert.That(options, Is.Not.SameAs(constructorOptions), $"The { constructorDescription } constructor should have cloned the options.");
            Assert.That(options.ConnectionType, Is.EqualTo(constructorOptions.ConnectionType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.DefaultTimeout, Is.EqualTo(constructorOptions.DefaultTimeout), $"The { constructorDescription } constructor should have the correct default timeout.");
            Assert.That(options.Proxy, Is.EqualTo(constructorOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)options.Retry, (ExponentialRetry)constructorOptions.Retry), $"The { constructorDescription } constructor should have the correct retry.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringInitializesProperties()
        {
            var entityPath = "somePath";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ entityPath }";
            var client = new EventHubClient(fakeConnection);

            Assert.That(client.EventHubPath, Is.EqualTo(entityPath));
            Assert.That(client.Credential, Is.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithExpandedArgumentsInitializesProperties()
        {
            var host = "host.windows.servicebus.net";
            var entityPath = "somePath";
            var credential = Mock.Of<TokenCredential>();
            var client = new EventHubClient(host, entityPath, credential);

            Assert.That(client.EventHubPath, Is.EqualTo(entityPath));
            Assert.That(client.Credential, Is.EqualTo(credential));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringValidatesOptions()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            var invalidOptions = new EventHubClientOptions { ConnectionType = ConnectionType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };

            Assert.That(() => new EventHubClient(fakeConnection, invalidOptions), Throws.ArgumentException, "The connection string constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithExpandedArgumentsValidatesOptions()
        {
            var invalidOptions = new EventHubClientOptions { ConnectionType = ConnectionType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };
            Assert.That(() => new EventHubClient("host", "path", Mock.Of<TokenCredential>(), invalidOptions), Throws.ArgumentException, "The cexpanded argument onstructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateSender" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateEventSenderCreatesDefaultWhenNoOptionsArePassed()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var expected = new SenderOptions
            {
                Retry = clientOptions.Retry,
                Timeout = clientOptions.DefaultTimeout
            };

            var actual = default(SenderOptions);
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";

            var mockClient = new Mock<EventHubClient>(connectionString, clientOptions)
            {
                CallBase = true
            };

            mockClient
                .Protected()
                .Setup<EventSender>("BuildEventSender", ItExpr.IsAny<ConnectionType>(), ItExpr.IsAny<string>(), ItExpr.IsAny<SenderOptions>())
                .Returns(Mock.Of<EventSender>())
                .Callback<ConnectionType, string, SenderOptions>((type, path, options) => actual = options);

            mockClient.Object.CreateSender();

            Assert.That(actual, Is.Not.Null, "The sender options should have been set.");
            Assert.That(actual.PartitionId, Is.EqualTo(expected.PartitionId), "The partition identifiers should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)actual.Retry, (ExponentialRetry)expected.Retry), "The retries should match.");
            Assert.That(actual.TimeoutOrDefault, Is.EqualTo(expected.TimeoutOrDefault), "The timeouts should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateSender" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateEventSenderCreatesDefaultWhenOptionsAreNotSet()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var senderOptions = new SenderOptions
            {
                PartitionId = "123",
                Retry = null,
                Timeout = TimeSpan.Zero
            };

            var expected = new SenderOptions
            {
                PartitionId = senderOptions.PartitionId,
                Retry = clientOptions.Retry,
                Timeout = clientOptions.DefaultTimeout
            };

            var actual = default(SenderOptions);
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";

            var mockClient = new Mock<EventHubClient>(connectionString, clientOptions)
            {
                CallBase = true
            };

            mockClient
                .Protected()
                .Setup<EventSender>("BuildEventSender", ItExpr.IsAny<ConnectionType>(), ItExpr.IsAny<string>(), ItExpr.IsAny<SenderOptions>())
                .Returns(Mock.Of<EventSender>())
                .Callback<ConnectionType, string, SenderOptions>((type, path, options) => actual = options);

            mockClient.Object.CreateSender(senderOptions);

            Assert.That(actual, Is.Not.Null, "The sender options should have been set.");
            Assert.That(actual, Is.Not.SameAs(senderOptions), "The options should have been cloned.");
            Assert.That(actual.PartitionId, Is.EqualTo(expected.PartitionId), "The partition identifiers should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)actual.Retry, (ExponentialRetry)expected.Retry), "The retries should match.");
            Assert.That(actual.TimeoutOrDefault, Is.EqualTo(expected.TimeoutOrDefault), "The timeouts should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreatePartitionReceiver" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionReceiverCreatesDefaultWhenNoOptionsArePassed()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var expectedOptions = new ReceiverOptions
            {
                Retry = clientOptions.Retry,
                DefaultMaximumReceiveWaitTime = clientOptions.DefaultTimeout

            };

            var expectedPartition = "56767";
            var actualOptions = default(ReceiverOptions);
            var actualPartition = default(string);
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";

            var mockClient = new Mock<EventHubClient>(connectionString, clientOptions)
            {
                CallBase = true
            };

            mockClient
                .Protected()
                .Setup<PartitionReceiver>("BuildPartitionReceiver", ItExpr.IsAny<ConnectionType>(), ItExpr.IsAny<string>(), ItExpr.IsAny<string>(), ItExpr.IsAny<ReceiverOptions>())
                .Returns(Mock.Of<PartitionReceiver>())
                .Callback<ConnectionType, string, string, ReceiverOptions>((type, path, partition, options) => { actualOptions = options; actualPartition = partition; });

            mockClient.Object.CreatePartitionReceiver(expectedPartition);

            Assert.That(actualPartition, Is.EqualTo(expectedPartition), "The partition should match.");
            Assert.That(actualOptions, Is.Not.Null, "The receiver options should have been set.");
            Assert.That(actualOptions.BeginReceivingAt.Offset, Is.EqualTo(expectedOptions.BeginReceivingAt.Offset), "The beginning position to receive should match.");
            Assert.That(actualOptions.ConsumerGroup, Is.EqualTo(expectedOptions.ConsumerGroup), "The consumer groups should match.");
            Assert.That(actualOptions.ExclusiveReceiverPriority, Is.EqualTo(expectedOptions.ExclusiveReceiverPriority), "The exclusive priorities should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)actualOptions.Retry, (ExponentialRetry)expectedOptions.Retry), "The retries should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreatePartitionReceiver" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionReceiverCreatesDefaultWhenOptionsAreNotSet()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var expectedOptions = new ReceiverOptions
            {
                BeginReceivingAt = EventPosition.FromOffset(65),
                ConsumerGroup = "SomeGroup",
                ExclusiveReceiverPriority = 251,
                Identifier = "Bob",
                PrefetchCount = 600,
                Retry = clientOptions.Retry,
                DefaultMaximumReceiveWaitTime = clientOptions.DefaultTimeout

            };

            var expectedPartition = "56767";
            var actualOptions = default(ReceiverOptions);
            var actualPartition = default(string);
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";

            var mockClient = new Mock<EventHubClient>(connectionString, clientOptions)
            {
                CallBase = true
            };

            mockClient
                .Protected()
                .Setup<PartitionReceiver>("BuildPartitionReceiver", ItExpr.IsAny<ConnectionType>(), ItExpr.IsAny<string>(), ItExpr.IsAny<string>(), ItExpr.IsAny<ReceiverOptions>())
                .Returns(Mock.Of<PartitionReceiver>())
                .Callback<ConnectionType, string, string, ReceiverOptions>((type, path, partition, options) => { actualOptions = options; actualPartition = partition; });

            mockClient.Object.CreatePartitionReceiver(expectedPartition, expectedOptions);

            Assert.That(actualPartition, Is.EqualTo(expectedPartition), "The partition should match.");
            Assert.That(actualOptions, Is.Not.Null, "The receiver options should have been set.");
            Assert.That(actualOptions, Is.Not.SameAs(expectedOptions), "A clone of the options should have been made.");
            Assert.That(actualOptions.BeginReceivingAt.Offset, Is.EqualTo(expectedOptions.BeginReceivingAt.Offset), "The beginning position to receive should match.");
            Assert.That(actualOptions.ConsumerGroup, Is.EqualTo(expectedOptions.ConsumerGroup), "The consumer groups should match.");
            Assert.That(actualOptions.ExclusiveReceiverPriority, Is.EqualTo(expectedOptions.ExclusiveReceiverPriority), "The exclusive priorities should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)actualOptions.Retry, (ExponentialRetry)expectedOptions.Retry), "The retries should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.GetPartitionIdsAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionIdsAsyncDelegatesToGetProperties()
        {
            var date = DateTimeOffset.Parse("2015-10-27T12:00:00Z").DateTime;
            var partitionIds = new[] { "first", "second", "third" };
            var properties = new EventHubProperties("dummy", date, partitionIds, date);
            var mockClient = new Mock<EventHubClient> { CallBase = true };

            mockClient
                .Setup(client => client.GetPropertiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(properties))
                .Verifiable("GetPropertiesAcync should have been delegated to.");

            var actual = await mockClient.Object.GetPartitionIdsAsync(CancellationToken.None);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(partitionIds));

            mockClient.VerifyAll();
        }
    }
}
