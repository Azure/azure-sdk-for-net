﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Messaging.ServiceBus;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ServiceBusConnectionStringProperties" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ServiceBusConnectionStringPropertiesTests
    {
        /// <summary>
        ///   Provides the reordered token test cases for the <see cref="ServiceBusConnectionStringProperties.Parse" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ParseDoesNotforceTokenOrderingCases()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var sas = "fullsas";

            yield return new object[] { $"Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };EntityPath={ eventHub }", endpoint, eventHub, sasKeyName, sasKey, null };
            yield return new object[] { $"Endpoint=sb://{ endpoint };SharedAccessKey={ sasKey };EntityPath={ eventHub };SharedAccessKeyName={ sasKeyName }", endpoint, eventHub, sasKeyName, sasKey, null };
            yield return new object[] { $"Endpoint=sb://{ endpoint };EntityPath={ eventHub };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey }", endpoint, eventHub, sasKeyName, sasKey, null };
            yield return new object[] { $"SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };Endpoint=sb://{ endpoint };EntityPath={ eventHub }", endpoint, eventHub, sasKeyName, sasKey, null };
            yield return new object[] { $"EntityPath={ eventHub };SharedAccessKey={ sasKey };SharedAccessKeyName={ sasKeyName };Endpoint=sb://{ endpoint }", endpoint, eventHub, sasKeyName, sasKey, null };
            yield return new object[] { $"EntityPath={ eventHub };SharedAccessSignature={ sas };Endpoint=sb://{ endpoint }", endpoint, eventHub, null, null, sas };
            yield return new object[] { $"SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };Endpoint=sb://{ endpoint };EntityPath={ eventHub };SharedAccessSignature={ sas }", endpoint, eventHub, sasKeyName, sasKey, sas };
        }

        /// <summary>
        ///   Provides the reordered token test cases for the <see cref="ServiceBusConnectionStringProperties.Parse" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ParseCorrectlyParsesPartialConnectionStringCases()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var sas = "fullsas";

            yield return new object[] { $"Endpoint=sb://{ endpoint }", endpoint, null, null, null, null };
            yield return new object[] { $"SharedAccessKey={ sasKey }", null, null, sasKeyName, null, null };
            yield return new object[] { $"EntityPath={ eventHub };SharedAccessKeyName={ sasKeyName }", null, eventHub, sasKeyName, null, null };
            yield return new object[] { $"SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey }", null, null, sasKeyName, sasKey, null };
            yield return new object[] { $"EntityPath={ eventHub };SharedAccessKey={ sasKey };SharedAccessKeyName={ sasKeyName }", null, eventHub, sasKeyName, sasKey, null };
            yield return new object[] { $"SharedAccessKeyName={ sasKeyName };SharedAccessSignature={ sas }", null, null, null, null, sas };
            yield return new object[] { $"EntityPath={ eventHub };SharedAccessSignature={ sas }", null, eventHub, null, null, sas };
            yield return new object[] { $"EntityPath={ eventHub };SharedAccessKey={ sasKey };SharedAccessKeyName={ sasKeyName };SharedAccessSignature={ sas }", null, eventHub, sasKeyName, sasKey, sas };
        }

        /// <summary>
        ///   Provides the invalid properties argument cases for the <see cref="ServiceBusConnectionStringProperties.Create" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ToConnectionStringValidatesPropertiesCases()
        {
            yield return new object[] { new ServiceBusConnectionStringProperties
            {
                Endpoint = null,
                EntityPath = "fake",
                SharedAccessSignature = "fake"
            },
            "missing endpoint" };

            yield return new object[] { new ServiceBusConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetServiceBusEndpointScheme(), "someplace.hosname.ext")),
                EntityPath = "fake"
            },
            "missing authorization" };

            yield return new object[] { new ServiceBusConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetServiceBusEndpointScheme(), "someplace.hosname.ext")),
                EntityPath = "fake",
                SharedAccessSignature = "fake",
                SharedAccessKey = "fake"
            },
            "SAS and key specified" };

            yield return new object[] { new ServiceBusConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetServiceBusEndpointScheme(), "someplace.hosname.ext")),
                EntityPath = "fake",
                SharedAccessSignature = "fake",
                SharedAccessKeyName = "fake"
            },
            "SAS and shared key name specified" };

            yield return new object[] { new ServiceBusConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetServiceBusEndpointScheme(), "someplace.hosname.ext")),
                EntityPath = "fake",
                SharedAccessKeyName = "fake"
            },
            "only shared key name specified" };

            yield return new object[] { new ServiceBusConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetServiceBusEndpointScheme(), "someplace.hosname.ext")),
                EntityPath = "fake",
                SharedAccessKey = "fake"
            },
            "only shared key specified" };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ParseToConnectionStringsArguments(string connectionString)
        {
            ExactTypeConstraint typeConstraint = connectionString is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            Assert.That(() => ServiceBusConnectionStringProperties.Parse(connectionString), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseCorrectlyParsesANamespaceConnectionString()
        {
            var endpoint = "test.endpoint.com";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var sharedAccessSignature = "fakeSAS";
            var connectionString = $"Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };SharedAccessSignature={ sharedAccessSignature }";
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.SharedAccessSignature, Is.EqualTo(sharedAccessSignature), "The precomputed SAS should match.");
            Assert.That(parsed.EntityPath, Is.Null, "The Service Bus path was not included in the connection string");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseCorrectlyParsesAnEntityConnectionString()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var sharedAccessSignature = "fakeSAS";
            var connectionString = $"Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };EntityPath={ eventHub };SharedAccessSignature={ sharedAccessSignature }";
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.SharedAccessSignature, Is.EqualTo(sharedAccessSignature), "The precomputed SAS should match.");
            Assert.That(parsed.EntityPath, Is.EqualTo(eventHub), "The Service Bus path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ParseDoesNotforceTokenOrderingCases))]
        public void ParseCorrectlyParsesPartialConnectionStrings(string connectionString,
                                                                 string endpoint,
                                                                 string eventHub,
                                                                 string sasKeyName,
                                                                 string sasKey,
                                                                 string sharedAccessSignature)
        {
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.SharedAccessSignature, Is.EqualTo(sharedAccessSignature), "The precomputed SAS should match.");
            Assert.That(parsed.EntityPath, Is.EqualTo(eventHub), "The Service Bus path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseToleratesLeadingDelimiters()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var connectionString = $";Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };EntityPath={ eventHub }";
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EntityPath, Is.EqualTo(eventHub), "The Service Bus path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseToleratesTrailingDelimiters()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var connectionString = $"Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };EntityPath={ eventHub };";
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EntityPath, Is.EqualTo(eventHub), "The Service Bus path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseToleratesSpacesBetweenPairs()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var connectionString = $"Endpoint=sb://{ endpoint }; SharedAccessKeyName={ sasKeyName }; SharedAccessKey={ sasKey }; EntityPath={ eventHub }";
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EntityPath, Is.EqualTo(eventHub), "The Service Bus path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseToleratesSpacesBetweenValues()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var connectionString = $"Endpoint = sb://{ endpoint };SharedAccessKeyName ={ sasKeyName };SharedAccessKey= { sasKey }; EntityPath  =  { eventHub }";
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EntityPath, Is.EqualTo(eventHub), "The Service Bus path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ParseDoesNotforceTokenOrderingCases))]
        public void ParseDoesNotForceTokenOrdering(string connectionString,
                                                   string endpoint,
                                                   string eventHub,
                                                   string sasKeyName,
                                                   string sasKey,
                                                   string shardAccessSignature)
        {
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.SharedAccessSignature, Is.EqualTo(shardAccessSignature), "The precomputed SAS should match.");
            Assert.That(parsed.EntityPath, Is.EqualTo(eventHub), "The Service Bus path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseIgnoresUnknownTokens()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var connectionString = $"Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };Unknown=INVALID;SharedAccessKey={ sasKey };EntityPath={ eventHub };Trailing=WHOAREYOU";
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EntityPath, Is.EqualTo(eventHub), "The Service Bus path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("test.endpoint.com")]
        [TestCase("sb://test.endpoint.com")]
        [TestCase("sb://test.endpoint.com:80")]
        [TestCase("amqp://test.endpoint.com")]
        [TestCase("http://test.endpoint.com")]
        [TestCase("https://test.endpoint.com:8443")]
        public void ParseDoesAcceptsHostNamesAndUrisForTheEndpoint(string endpointValue)
        {
            var connectionString = $"Endpoint={ endpointValue };EntityPath=dummy";
            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);

            if (!Uri.TryCreate(endpointValue, UriKind.Absolute, out var valueUri))
            {
                valueUri = new Uri($"fake://{ endpointValue }");
            }

            Assert.That(parsed.Endpoint.Port, Is.EqualTo(-1), "The default port should be used.");
            Assert.That(parsed.Endpoint.Host, Does.Not.Contain(" "), "The host name should not contain any spaces.");
            Assert.That(parsed.Endpoint.Host, Does.Not.Contain(":"), "The host name should not contain any port separators (:).");
            Assert.That(parsed.Endpoint.Host, Does.Not.Contain(valueUri.Port), "The host name should not contain the port.");
            Assert.That(parsed.Endpoint.Host, Is.EqualTo(valueUri.Host), "The host name should have been normalized.");
            Assert.That(parsed.Endpoint.ToString(), Does.StartWith(GetServiceBusEndpointScheme()), "The parser's endpoint scheme should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("test.endpoint.com:443")]
        [TestCase("notvalid=[broke]")]
        public void ParseDoesNotAllowAnInvalidEndpointFormat(string endpointValue)
        {
            var connectionString = $"Endpoint={endpointValue }";
            Assert.That(() => ServiceBusConnectionStringProperties.Parse(connectionString), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("Endpoint;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=;SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey;EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath")]
        [TestCase("Endpoint;SharedAccessKeyName=;SharedAccessKey;EntityPath=")]
        [TestCase("Endpoint=;SharedAccessKeyName;SharedAccessKey;EntityPath=")]
        public void ParseConsidersMissingValuesAsMalformed(string connectionString)
        {
            Assert.That(() => ServiceBusConnectionStringProperties.Parse(connectionString), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Create" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ToConnectionStringValidatesPropertiesCases))]
        public void ToConnectionStringValidatesProperties(ServiceBusConnectionStringProperties properties, string testDescription)
        {
            Assert.That(() => properties.ToConnectionString(), Throws.InstanceOf<ArgumentException>(), $"The case for `{ testDescription }` failed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Create" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToConnectionStringProducesTheConnectionStringForSharedAccessSignatures()
        {
            var properties = new ServiceBusConnectionStringProperties
            {
                Endpoint = new Uri("sb://place.endpoint.ext"),
                EntityPath = "HubName",
                SharedAccessSignature = "FaKe#$1324@@"
            };

            var connectionString = properties.ToConnectionString();
            Assert.That(connectionString, Is.Not.Null, "The connection string should not be null.");
            Assert.That(connectionString.Length, Is.GreaterThan(0), "The connection string should have content.");

            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);
            Assert.That(parsed, Is.Not.Null, "The connection string should be parsable.");
            Assert.That(PropertiesAreEquivalent(properties, parsed), Is.True, "The connection string should parse into the source properties.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Create" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToConnectionStringProducesTheConnectionStringForSharedKeys()
        {
            var properties = new ServiceBusConnectionStringProperties
            {
                Endpoint = new Uri("sb://place.endpoint.ext"),
                EntityPath = "HubName",
                SharedAccessKey = "FaKe#$1324@@",
                SharedAccessKeyName = "RootSharedAccessManagementKey"
            };

            var connectionString = properties.ToConnectionString();
            Assert.That(connectionString, Is.Not.Null, "The connection string should not be null.");
            Assert.That(connectionString.Length, Is.GreaterThan(0), "The connection string should have content.");

            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);
            Assert.That(parsed, Is.Not.Null, "The connection string should be parsable.");
            Assert.That(PropertiesAreEquivalent(properties, parsed), Is.True, "The connection string should parse into the source properties.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.Create" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("sb://")]
        [TestCase("amqps://")]
        [TestCase("amqp://")]
        [TestCase("http://")]
        [TestCase("https://")]
        [TestCase("fake://")]
        public void ToConnectionStringNormalizesTheEndpointScheme(string scheme)
        {
            var properties = new ServiceBusConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(scheme, "myhub.servicebus.windows.net")),
                EntityPath = "HubName",
                SharedAccessKey = "FaKe#$1324@@",
                SharedAccessKeyName = "RootSharedAccessManagementKey"
            };

            var connectionString = properties.ToConnectionString();
            Assert.That(connectionString, Is.Not.Null, "The connection string should not be null.");
            Assert.That(connectionString.Length, Is.GreaterThan(0), "The connection string should have content.");

            var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);
            Assert.That(parsed, Is.Not.Null, "The connection string should be parsable.");
            Assert.That(parsed.Endpoint.Host, Is.EqualTo(properties.Endpoint.Host), "The host name of the endpoints should match.");

            var expectedScheme = new Uri(string.Concat(GetServiceBusEndpointScheme(), "fake.fake.com")).Scheme;
            Assert.That(parsed.Endpoint.Scheme, Is.EqualTo(expectedScheme), "The endpoint scheme should have been overridden.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.ToConnectionString" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void ToConnectionStringAllowsSharedAccessKeyAuthorization()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]";
            var properties = ServiceBusConnectionStringProperties.Parse(fakeConnection);

            Assert.That(() => properties.ToConnectionString(), Throws.Nothing, "Validation should accept the shared access key authorization.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnectionStringProperties.ToConnectionString" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void ToConnectionStringAllowsSharedAccessSignatureAuthorization()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessSignature=[not_real]";
            var properties = ServiceBusConnectionStringProperties.Parse(fakeConnection);

            Assert.That(() => properties.ToConnectionString(), Throws.Nothing, "Validation should accept the shared access signature authorization.");
        }

        /// <summary>
        ///   Compares two <see cref="ServiceBusConnectionStringProperties" /> instances for
        ///   structural equality.
        /// </summary>
        ///
        /// <param name="first">The first instance to consider.</param>
        /// <param name="second">The second instance to consider.</param>
        ///
        /// <returns><c>true</c> if the instances are equivalent; otherwise, <c>false</c>.</returns>
        ///
        private static bool PropertiesAreEquivalent(ServiceBusConnectionStringProperties first,
                                                    ServiceBusConnectionStringProperties second)
        {
            if (object.ReferenceEquals(first, second))
            {
                return true;
            }

            if ((first == null) || (second == null))
            {
                return false;
            }

            return string.Equals(first.Endpoint.AbsoluteUri, second.Endpoint.AbsoluteUri, StringComparison.OrdinalIgnoreCase)
                && string.Equals(first.EntityPath, second.EntityPath, StringComparison.OrdinalIgnoreCase)
                && string.Equals(first.SharedAccessSignature, second.SharedAccessSignature, StringComparison.OrdinalIgnoreCase)
                && string.Equals(first.SharedAccessKeyName, second.SharedAccessKeyName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(first.SharedAccessKey, second.SharedAccessKey, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///   Gets the Service Bus endpoint scheme used by the <see cref="ServiceBusConnectionStringProperties" />
        ///   using its private field.
        /// </summary>
        ///
        /// <returns>The endpoint scheme used by the parser.</returns>
        ///
        private static string GetServiceBusEndpointScheme() =>
            (string)
                typeof(ServiceBusConnectionStringProperties)
                    .GetField("ServiceBusEndpointScheme", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);
    }
}
