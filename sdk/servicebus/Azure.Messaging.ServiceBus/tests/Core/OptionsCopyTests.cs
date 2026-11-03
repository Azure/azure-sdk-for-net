// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class OptionsCopyTests
    {
        [Test]
        public void ProcessorClonePreservesAllPublicSettableProperties()
        {
            var options = CreateNonDefaultOptions<ServiceBusProcessorOptions>();
            options.MaxReceiveWaitTime = TimeSpan.FromSeconds(19);

            ServiceBusProcessorOptions clone = options.Clone();

            AssertCopy(options, clone);
            Assert.That(clone.MaxReceiveWaitTime, Is.EqualTo(options.MaxReceiveWaitTime));
        }

        [Test]
        public void ClientClonePreservesAllPublicSettableProperties()
        {
            var options = CreateNonDefaultOptions<ServiceBusClientOptions>();

            AssertCopy(options, options.Clone());
        }

        [Test]
        public void RetryClonePreservesAllPublicSettableProperties()
        {
            var options = CreateNonDefaultOptions<ServiceBusRetryOptions>();

            AssertCopy(options, options.Clone());
        }

        [Test]
        public void BatchClonePreservesAllPublicSettableProperties()
        {
            var options = CreateNonDefaultOptions<CreateMessageBatchOptions>();

            AssertCopy(options, options.Clone());
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task SessionProcessorPreservesAllPublicSettableProperties(bool useSessionIds)
        {
            var options = CreateNonDefaultOptions<ServiceBusSessionProcessorOptions>();
            if (useSessionIds)
            {
                options.SessionIds.Add("first-session");
                options.SessionIds.Add("second-session");
            }

            await using var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "queue",
                options);

            foreach (PropertyInfo property in GetPublicSettableProperties(options.GetType()))
            {
                PropertyInfo target = typeof(ServiceBusSessionProcessor).GetProperty(property.Name);
                Assert.That(target, Is.Not.Null, $"Add a consumer assertion for {property.Name}.");
                Assert.That(target.GetValue(processor), Is.EqualTo(property.GetValue(options)), property.Name);
            }

            int sessionCount = useSessionIds
                ? Math.Min(options.SessionIds.Count, options.MaxConcurrentSessions)
                : options.MaxConcurrentSessions;
            Assert.That(
                processor.InnerProcessor.MaxConcurrentCalls,
                Is.EqualTo(sessionCount * options.MaxConcurrentCallsPerSession));

            // Session IDs are consumed separately from ToProcessorOptions and kept as a private snapshot.
            FieldInfo sessionIdsField = typeof(ServiceBusProcessor).GetField(
                "_sessionIds", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(sessionIdsField, Is.Not.Null);
            var sessionIds = (string[])sessionIdsField.GetValue(processor.InnerProcessor);
            Assert.That(sessionIds, Is.EqualTo(options.SessionIds), nameof(options.SessionIds));
            options.SessionIds.Add("added-after-construction");
            Assert.That(sessionIds, Does.Not.Contain("added-after-construction"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SessionReceiverConversionPreservesAllPublicSettableProperties(bool enableNonExclusiveSession)
        {
            var options = CreateNonDefaultOptions<ServiceBusSessionReceiverOptions>();
            options.EnableNonExclusiveSession = enableNonExclusiveSession;
            options.SessionLockToken = enableNonExclusiveSession ? options.SessionLockToken : null;

            ServiceBusReceiverOptions converted = options.ToReceiverOptions();

            foreach (PropertyInfo property in GetPublicSettableProperties(options.GetType()))
            {
                object expected = property.GetValue(options);
                string targetName = property.Name;
                if (property.Name == nameof(ServiceBusSessionReceiverOptions.EnableNonExclusiveSession))
                {
                    targetName = nameof(ServiceBusReceiverOptions.IsSessionExclusive);
                    expected = !enableNonExclusiveSession;
                }

                PropertyInfo target = typeof(ServiceBusReceiverOptions).GetProperty(
                    targetName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                Assert.That(target, Is.Not.Null, $"Add a conversion assertion for {property.Name}.");
                Assert.That(target.GetValue(converted), Is.EqualTo(expected), property.Name);
            }
        }

        private static PropertyInfo[] GetPublicSettableProperties(Type type) =>
            type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(property =>
                    property.GetMethod?.IsPublic == true &&
                    property.SetMethod?.IsPublic == true &&
                    property.GetIndexParameters().Length == 0)
                .OrderBy(property => property.Name)
                .ToArray();

        private static T CreateNonDefaultOptions<T>() where T : new()
        {
            var options = new T();
            PropertyInfo[] properties = GetPublicSettableProperties(typeof(T));
            Assert.That(properties, Is.Not.Empty);

            foreach (PropertyInfo property in properties)
            {
                object defaultValue = property.GetValue(options);
                object value = CreateNonDefaultValue(property.PropertyType, defaultValue, property.Name);
                property.SetValue(options, value);
                Assert.That(
                    property.GetValue(options),
                    Is.Not.EqualTo(defaultValue),
                    $"{typeof(T).Name}.{property.Name} must be tested with a non-default value.");
            }

            return options;
        }

        private static object CreateNonDefaultValue(Type propertyType, object defaultValue, string propertyName)
        {
            Type type = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
            if (type == typeof(bool))
            {
                return defaultValue == null || !(bool)defaultValue;
            }
            if (type == typeof(int))
            {
                return (defaultValue == null ? 0 : (int)defaultValue) + 1;
            }
            if (type == typeof(long))
            {
                return 65536L;
            }
            if (type == typeof(string))
            {
                return "non-default-option";
            }
            if (type == typeof(TimeSpan))
            {
                return TimeSpan.FromSeconds(37);
            }
            if (type == typeof(Guid))
            {
                return Guid.Parse("11111111-2222-3333-4444-555555555555");
            }
            if (type.IsEnum)
            {
                return Enum.GetValues(type).Cast<object>().First(value => !Equals(value, defaultValue));
            }
            if (type == typeof(Uri))
            {
                return new Uri("sb://custom.example.com");
            }
            if (type == typeof(IWebProxy))
            {
                return Mock.Of<IWebProxy>();
            }
            if (type == typeof(RemoteCertificateValidationCallback))
            {
                return new RemoteCertificateValidationCallback((sender, certificate, chain, errors) => false);
            }
            if (type == typeof(ServiceBusRetryPolicy))
            {
                return Mock.Of<ServiceBusRetryPolicy>();
            }
            if (type == typeof(ServiceBusRetryOptions))
            {
                return CreateNonDefaultOptions<ServiceBusRetryOptions>();
            }

            throw new AssertionException($"Add a non-default test value for {propertyName} ({propertyType}).");
        }

        private static void AssertCopy<T>(T original, T copy)
        {
            Assert.That(copy, Is.Not.SameAs(original));
            foreach (PropertyInfo property in GetPublicSettableProperties(typeof(T)))
            {
                object expected = property.GetValue(original);
                object actual = property.GetValue(copy);
                if (expected is ServiceBusRetryOptions retryOptions)
                {
                    Assert.That(actual, Is.InstanceOf<ServiceBusRetryOptions>(), property.Name);
                    AssertCopy(retryOptions, (ServiceBusRetryOptions)actual);
                }
                else
                {
                    Assert.That(actual, Is.EqualTo(expected), $"{typeof(T).Name}.{property.Name}");
                }
            }
        }
    }
}
