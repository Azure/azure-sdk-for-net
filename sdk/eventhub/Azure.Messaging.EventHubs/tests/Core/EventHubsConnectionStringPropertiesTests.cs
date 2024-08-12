// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubsConnectionStringProperties" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubsConnectionStringPropertiesTests
    {
        /// <summary>
        ///   Provides the reordered token test cases for the <see cref="EventHubsConnectionStringProperties.Parse" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ParseDoesNotForceTokenOrderingCases()
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
        ///   Provides the reordered token test cases for the <see cref="EventHubsConnectionStringProperties.Parse" /> tests.
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
        ///   Provides the invalid properties argument cases for the <see cref="EventHubsConnectionStringProperties.Create" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ToConnectionStringValidatesArgumentCases()
        {
            yield return new object[] { new EventHubsConnectionStringProperties
            {
                Endpoint = null,
                EventHubName = "fake",
                SharedAccessSignature = "fake"
            },
            "missing endpoint" };

            yield return new object[] { new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetEventHubsEndpointScheme(), "someplace.hosname.ext")),
                EventHubName = null,
                SharedAccessSignature = "fake"
            },
            "missing Event Hub name" };

            yield return new object[] { new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetEventHubsEndpointScheme(), "someplace.hosname.ext")),
                EventHubName = "fake"
            },
            "missing authorization" };

            yield return new object[] { new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetEventHubsEndpointScheme(), "someplace.hosname.ext")),
                EventHubName = "fake",
                SharedAccessSignature = "fake",
                SharedAccessKey = "fake"
            },
            "SAS and key specified" };

            yield return new object[] { new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetEventHubsEndpointScheme(), "someplace.hosname.ext")),
                EventHubName = "fake",
                SharedAccessSignature = "fake",
                SharedAccessKeyName = "fake"
            },
            "SAS and shared key name specified" };

            yield return new object[] { new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetEventHubsEndpointScheme(), "someplace.hosname.ext")),
                EventHubName = "fake",
                SharedAccessKeyName = "fake"
            },
            "only shared key name specified" };

            yield return new object[] { new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(GetEventHubsEndpointScheme(), "someplace.hosname.ext")),
                EventHubName = "fake",
                SharedAccessKey = "fake"
            },
            "only shared key specified" };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ParseValidatesArguments(string connectionString)
        {
            ExactTypeConstraint typeConstraint = connectionString is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            Assert.That(() => EventHubsConnectionStringProperties.Parse(connectionString), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
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
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.SharedAccessSignature, Is.EqualTo(sharedAccessSignature), "The precomputed SAS should match.");
            Assert.That(parsed.EventHubName, Is.Null, "The Event Hub path was not included in the connection string");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseCorrectlyParsesAnEventHubConnectionString()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var sharedAccessSignature = "fakeSAS";
            var connectionString = $"Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };EntityPath={ eventHub };SharedAccessSignature={ sharedAccessSignature }";
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.SharedAccessSignature, Is.EqualTo(sharedAccessSignature), "The precomputed SAS should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ParseDoesNotForceTokenOrderingCases))]
        public void ParseCorrectlyParsesPartialConnectionStrings(string connectionString,
                                                                 string endpoint,
                                                                 string eventHub,
                                                                 string sasKeyName,
                                                                 string sasKey,
                                                                 string sharedAccessSignature)
        {
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.SharedAccessSignature, Is.EqualTo(sharedAccessSignature), "The precomputed SAS should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
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
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
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
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
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
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
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
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ParseDoesNotForceTokenOrderingCases))]
        public void ParseDoesNotForceTokenOrdering(string connectionString,
                                                   string endpoint,
                                                   string eventHub,
                                                   string sasKeyName,
                                                   string sasKey,
                                                   string shardAccessSignature)
        {
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.SharedAccessSignature, Is.EqualTo(shardAccessSignature), "The precomputed SAS should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
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
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
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
        public void ParseAcceptsHostNamesAndUrisForTheEndpoint(string endpointValue)
        {
            var connectionString = $"Endpoint={ endpointValue };EntityPath=dummy";
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            if (!Uri.TryCreate(endpointValue, UriKind.Absolute, out var valueUri))
            {
                valueUri = new Uri($"fake://{ endpointValue }");
            }

            Assert.That(parsed.Endpoint.Port, Is.EqualTo(valueUri.IsDefaultPort ? -1 : valueUri.Port), "The default port should be used.");
            Assert.That(parsed.Endpoint.Host, Does.Not.Contain(" "), "The host name should not contain any spaces.");
            Assert.That(parsed.Endpoint.Host, Does.Not.Contain(":"), "The host name should not contain any port separators (:).");
            Assert.That(parsed.Endpoint.Host, Does.Not.Contain(valueUri.Port), "The host name should not contain the port.");
            Assert.That(parsed.Endpoint.Host, Is.EqualTo(valueUri.Host), "The host name should have been normalized.");
            Assert.That(parsed.Endpoint.ToString(), Does.StartWith(GetEventHubsEndpointScheme()), "The parser's endpoint scheme should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("test-endpoint|com:443")]
        [TestCase("notvalid=[broke]")]
        public void ParseDoesNotAllowAnInvalidEndpointFormat(string endpointValue)
        {
            var connectionString = $"Endpoint={endpointValue }";
            Assert.That(() => EventHubsConnectionStringProperties.Parse(connectionString), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
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
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];UseDevelopmentEmulator")]
        public void ParseConsidersMissingValuesAsMalformed(string connectionString)
        {
            Assert.That(() => EventHubsConnectionStringProperties.Parse(connectionString), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseDetectsDevelopmentEmulatorUse()
        {
            var connectionString = "Endpoint=localhost:1234;SharedAccessKeyName=[name];SharedAccessKey=[value];UseDevelopmentEmulator=true";
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint.IsLoopback, Is.True, "The endpoint should be a local address.");
            Assert.That(parsed.UseDevelopmentEmulator, Is.True, "The development emulator flag should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseRespectsDevelopmentEmulatorValue()
        {
            var connectionString = "Endpoint=localhost:1234;SharedAccessKeyName=[name];SharedAccessKey=[value];UseDevelopmentEmulator=false";
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint.IsLoopback, Is.True, "The endpoint should be a local address.");
            Assert.That(parsed.UseDevelopmentEmulator, Is.False, "The development emulator flag should have been unset.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("localhost")]
        [TestCase("localhost:9084")]
        [TestCase("127.0.0.1")]
        [TestCase("local.docker.com")]
        [TestCase("local.docker.com:8080")]
        [TestCase("www.fake.com")]
        [TestCase("www.fake.com:443")]
        public void ParseRespectsTheEndpointForDevelopmentEmulatorValue(string host)
        {
            var connectionString = $"Endpoint={ host };SharedAccessKeyName=[name];SharedAccessKey=[value];UseDevelopmentEmulator=true";
            var endpoint = new Uri(string.Concat(GetEventHubsEndpointScheme(), host));
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint.Host, Is.EqualTo(endpoint.Host), "The endpoint hosts should match.");
            Assert.That(parsed.Endpoint.Port, Is.EqualTo(endpoint.Port), "The endpoint ports should match.");
            Assert.That(parsed.UseDevelopmentEmulator, Is.True, "The development emulator flag should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("sb://localhost")]
        [TestCase("http://localhost:9084")]
        [TestCase("sb://local.docker.com")]
        [TestCase("amqps://local.docker.com:8080")]
        [TestCase("sb://www.fake.com")]
        [TestCase("amqp://www.fake.com:443")]
        public void ParseRespectsTheUrlFormatEndpointForDevelopmentEmulatorValue(string host)
        {
            var endpoint = new UriBuilder(host)
            {
                Scheme = GetEventHubsEndpointScheme()
            };

            var connectionString = $"Endpoint={ host };SharedAccessKeyName=[name];SharedAccessKey=[value];UseDevelopmentEmulator=true";
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint.Host, Is.EqualTo(endpoint.Host), "The endpoint hosts should match.");
            Assert.That(parsed.Endpoint.Port, Is.EqualTo(endpoint.Port), "The endpoint ports should match.");
            Assert.That(parsed.UseDevelopmentEmulator, Is.True, "The development emulator flag should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Parse" />
        ///   method.
        /// </summary>
        ///
        [TestCase("1")]
        [TestCase("Unset")]
        [TestCase("|")]
        public void ParseToleratesDevelopmentEmulatorInvalidValues(string emulatorValue)
        {
            var connectionString = $"Endpoint=sb://localhost:1234;SharedAccessKeyName=[name];SharedAccessKey=[value];UseDevelopmentEmulator={ emulatorValue }";
            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);

            Assert.That(parsed.Endpoint.IsLoopback, Is.True, "The endpoint should be a local address.");
            Assert.That(parsed.UseDevelopmentEmulator, Is.False, $"The development emulator flag should have been unset because { emulatorValue } is not a boolean.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Create" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ToConnectionStringValidatesArgumentCases))]
        public void ToConnectionStringValidatesProperties(EventHubsConnectionStringProperties properties,
                                                          string testDescription)
        {
            Assert.That(() => properties.ToConnectionString(), Throws.InstanceOf<ArgumentException>(), $"The case for `{ testDescription }` failed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Create" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToConnectionStringProducesTheConnectionStringForSharedAccessSignatures()
        {
            var properties = new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri("sb://place.endpoint.ext"),
                EventHubName = "HubName",
                SharedAccessSignature = "FaKe#$1324@@"
            };

            var connectionString = properties.ToConnectionString();
            Assert.That(connectionString, Is.Not.Null, "The connection string should not be null.");
            Assert.That(connectionString.Length, Is.GreaterThan(0), "The connection string should have content.");

            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);
            Assert.That(parsed, Is.Not.Null, "The connection string should be parsable.");
            Assert.That(PropertiesAreEquivalent(properties, parsed), Is.True, "The connection string should parse into the source properties.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Create" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToConnectionStringProducesTheConnectionStringForSharedKeys()
        {
            var properties = new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri("sb://place.endpoint.ext"),
                EventHubName = "HubName",
                SharedAccessKey = "FaKe#$1324@@",
                SharedAccessKeyName = "RootSharedAccessManagementKey"
            };

            var connectionString = properties.ToConnectionString();
            Assert.That(connectionString, Is.Not.Null, "The connection string should not be null.");
            Assert.That(connectionString.Length, Is.GreaterThan(0), "The connection string should have content.");

            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);
            Assert.That(parsed, Is.Not.Null, "The connection string should be parsable.");
            Assert.That(PropertiesAreEquivalent(properties, parsed), Is.True, "The connection string should parse into the source properties.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Create" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToConnectionStringProducesTheConnectionStringForTheLocalEmulator()
        {
            var properties = new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri("sb://127.0.0.1"),
                EventHubName = "HubName",
                SharedAccessKey = "FaKe#$1324@@",
                SharedAccessKeyName = "RootSharedAccessManagementKey",
                UseDevelopmentEmulator = true
            };

            var connectionString = properties.ToConnectionString();
            Assert.That(connectionString, Is.Not.Null, "The connection string should not be null.");
            Assert.That(connectionString.Length, Is.GreaterThan(0), "The connection string should have content.");

            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);
            Assert.That(parsed, Is.Not.Null, "The connection string should be parsable.");
            Assert.That(PropertiesAreEquivalent(properties, parsed), Is.True, "The connection string should parse into the source properties.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Create" />
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
            var properties = new EventHubsConnectionStringProperties
            {
                Endpoint = new Uri(string.Concat(scheme, "myhub.servicebus.windows.net")),
                EventHubName = "HubName",
                SharedAccessKey = "FaKe#$1324@@",
                SharedAccessKeyName = "RootSharedAccessManagementKey"
            };

            var connectionString = properties.ToConnectionString();
            Assert.That(connectionString, Is.Not.Null, "The connection string should not be null.");
            Assert.That(connectionString.Length, Is.GreaterThan(0), "The connection string should have content.");

            var parsed = EventHubsConnectionStringProperties.Parse(connectionString);
            Assert.That(parsed, Is.Not.Null, "The connection string should be parsable.");
            Assert.That(parsed.Endpoint.Host, Is.EqualTo(properties.Endpoint.Host), "The host name of the endpoints should match.");

            var expectedScheme = new Uri(string.Concat(GetEventHubsEndpointScheme(), "fake.fake.com")).Scheme;
            Assert.That(parsed.Endpoint.Scheme, Is.EqualTo(expectedScheme), "The endpoint scheme should have been overridden.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Validate" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=sb://value.com;SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=sb://value.com;SharedAccessKeyName=[value];EntityPath=[value]")]
        [TestCase("Endpoint=sb://value.com;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        public void ValidateDetectsMissingConnectionStringInformation(string connectionString)
        {
            var properties = EventHubsConnectionStringProperties.Parse(connectionString);
            Assert.That(() => properties.Validate(null, "Dummy"), Throws.ArgumentException.And.Message.StartsWith(Resources.MissingConnectionInformation));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Validate" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void ValidateDetectsMultipleEventHubNames()
        {
            var eventHubName = "myHub";
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=[unique_fake]";
            var properties = EventHubsConnectionStringProperties.Parse(fakeConnection);

            Assert.That(() => properties.Validate(eventHubName, "Dummy"), Throws.ArgumentException.And.Message.StartsWith(Resources.OnlyOneEventHubNameMayBeSpecified));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Validate" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void ValidateAllowsMultipleEventHubNamesIfEqual()
        {
            var eventHubName = "myHub";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ eventHubName }";
            var properties = EventHubsConnectionStringProperties.Parse(fakeConnection);

            Assert.That(() => properties.Validate(eventHubName, "dummy"), Throws.Nothing, "Validation should accept the same Event Hub in multiple places.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Validate" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCase("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=[unique_fake];SharedAccessSignature=[not_real]")]
        [TestCase("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;EntityPath=[unique_fake];SharedAccessSignature=[not_real]")]
        [TestCase("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKey=[not_real];EntityPath=[unique_fake];SharedAccessSignature=[not_real]")]
        public void ValidateDetectsMultipleAuthorizationCredentials(string connectionString)
        {
            var properties = EventHubsConnectionStringProperties.Parse(connectionString);
            Assert.That(() => properties.Validate(null, "Dummy"), Throws.ArgumentException.And.Message.StartsWith(Resources.OnlyOneSharedAccessAuthorizationMayBeSpecified));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Validate" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void ValidateAllowsSharedAccessKeyAuthorization()
        {
            var eventHubName = "myHub";
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]";
            var properties = EventHubsConnectionStringProperties.Parse(fakeConnection);

            Assert.That(() => properties.Validate(eventHubName, "dummy"), Throws.Nothing, "Validation should accept the shared access key authorization.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubsConnectionStringProperties.Validate" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void ValidateAllowsSharedAccessSignatureAuthorization()
        {
            var eventHubName = "myHub";
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessSignature=[not_real]";
            var properties = EventHubsConnectionStringProperties.Parse(fakeConnection);

            Assert.That(() => properties.Validate(eventHubName, "dummy"), Throws.Nothing, "Validation should accept the shared access signature authorization.");
        }

        /// <summary>
        ///   Compares two <see cref="EventHubsConnectionStringProperties" /> instances for
        ///   structural equality.
        /// </summary>
        ///
        /// <param name="first">The first instance to consider.</param>
        /// <param name="second">The second instance to consider.</param>
        ///
        /// <returns><c>true</c> if the instances are equivalent; otherwise, <c>false</c>.</returns>
        ///
        private static bool PropertiesAreEquivalent(EventHubsConnectionStringProperties first,
                                                    EventHubsConnectionStringProperties second)
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
                && string.Equals(first.EventHubName, second.EventHubName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(first.SharedAccessSignature, second.SharedAccessSignature, StringComparison.OrdinalIgnoreCase)
                && string.Equals(first.SharedAccessKeyName, second.SharedAccessKeyName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(first.SharedAccessKey, second.SharedAccessKey, StringComparison.OrdinalIgnoreCase)
                && (first.UseDevelopmentEmulator == second.UseDevelopmentEmulator);
        }

        /// <summary>
        ///   Gets the Event Hubs endpoint scheme used by the <see cref="EventHubsConnectionStringProperties" />
        ///   using its private field.
        /// </summary>
        ///
        /// <returns>The endpoint scheme used by the parser.</returns>
        ///
        private static string GetEventHubsEndpointScheme() =>
            (string)
                typeof(EventHubsConnectionStringProperties)
                    .GetField("EventHubsEndpointScheme", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);
    }
}
