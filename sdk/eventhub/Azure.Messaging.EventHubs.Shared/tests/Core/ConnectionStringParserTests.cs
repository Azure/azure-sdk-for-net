// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ConnectionStringParser" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ConnectionStringParserTests
    {
        /// <summary>
        ///   Provides the reordered token test cases for the <see cref="ConnectionStringParser.Parse" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ParseDoesNotforceTokenOrderingCases()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";

            yield return new object[] { $"Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };EntityPath={ eventHub }", endpoint, eventHub, sasKeyName, sasKey };
            yield return new object[] { $"Endpoint=sb://{ endpoint };SharedAccessKey={ sasKey };EntityPath={ eventHub };SharedAccessKeyName={ sasKeyName }", endpoint, eventHub, sasKeyName, sasKey };
            yield return new object[] { $"Endpoint=sb://{ endpoint };EntityPath={ eventHub };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey }", endpoint, eventHub, sasKeyName, sasKey };
            yield return new object[] { $"SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };Endpoint=sb://{ endpoint };EntityPath={ eventHub }", endpoint, eventHub, sasKeyName, sasKey };
            yield return new object[] { $"EntityPath={ eventHub };SharedAccessKey={ sasKey };SharedAccessKeyName={ sasKeyName };Endpoint=sb://{ endpoint }", endpoint, eventHub, sasKeyName, sasKey };
        }

        /// <summary>
        ///   Provides the reordered token test cases for the <see cref="ConnectionStringParser.Parse" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ParseCorrectlyParsesPartialConnectionStrings()
        {
            var endpoint = "test.endpoint.com";
            var eventHub = "some-path";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";

            yield return new object[] { $"Endpoint=sb://{ endpoint }", endpoint, null, null, null };
            yield return new object[] { $"SharedAccessKey={ sasKey }", null, null, sasKeyName, null };
            yield return new object[] { $"EntityPath={ eventHub };SharedAccessKeyName={ sasKeyName }", null, eventHub, sasKeyName, null };
            yield return new object[] { $"SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey }", null, null, sasKeyName, sasKey };
            yield return new object[] { $"EntityPath={ eventHub };SharedAccessKey={ sasKey };SharedAccessKeyName={ sasKeyName }", null, eventHub, sasKeyName, sasKey };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ParseValidatesArguments(string connectionString)
        {
            ExactTypeConstraint typeConstraint = connectionString is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            Assert.That(() => ConnectionStringParser.Parse(connectionString), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseCorrectlyParsesANamespaceConnectionString()
        {
            var endpoint = "test.endpoint.com";
            var sasKey = "sasKey";
            var sasKeyName = "sasName";
            var connectionString = $"Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey }";
            ConnectionStringProperties parsed = ConnectionStringParser.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.Null, "The Event Hub path was not included in the connection string");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
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
            var connectionString = $"Endpoint=sb://{ endpoint };SharedAccessKeyName={ sasKeyName };SharedAccessKey={ sasKey };EntityPath={ eventHub }";
            ConnectionStringProperties parsed = ConnectionStringParser.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ParseDoesNotforceTokenOrderingCases))]
        public void ParseCorrectlyParsesPartialConnectionStrings(string connectionString,
                                                                 string endpoint,
                                                                 string eventHub,
                                                                 string sasKeyName,
                                                                 string sasKey)
        {
            ConnectionStringProperties parsed = ConnectionStringParser.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
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
            ConnectionStringProperties parsed = ConnectionStringParser.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
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
            ConnectionStringProperties parsed = ConnectionStringParser.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
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
            ConnectionStringProperties parsed = ConnectionStringParser.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
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
            ConnectionStringProperties parsed = ConnectionStringParser.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ParseDoesNotforceTokenOrderingCases))]
        public void ParseDoesNotForceTokenOrdering(string connectionString,
                                                   string endpoint,
                                                   string eventHub,
                                                   string sasKeyName,
                                                   string sasKey)
        {
            ConnectionStringProperties parsed = ConnectionStringParser.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
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
            ConnectionStringProperties parsed = ConnectionStringParser.Parse(connectionString);

            Assert.That(parsed.Endpoint?.Host, Is.EqualTo(endpoint).Using((IComparer<string>)StringComparer.OrdinalIgnoreCase), "The endpoint host should match.");
            Assert.That(parsed.SharedAccessKeyName, Is.EqualTo(sasKeyName), "The SAS key name should match.");
            Assert.That(parsed.SharedAccessKey, Is.EqualTo(sasKey), "The SAS key value should match.");
            Assert.That(parsed.EventHubName, Is.EqualTo(eventHub), "The Event Hub path should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
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
            var parsed = ConnectionStringParser.Parse(connectionString);

            if (!Uri.TryCreate(endpointValue, UriKind.Absolute, out var valueUri))
            {
                valueUri = new Uri($"fake://{ endpointValue }");
            }

            Assert.That(parsed.Endpoint.Port, Is.EqualTo(-1), "The default port should be used.");
            Assert.That(parsed.Endpoint.Host, Does.Not.Contain(" "), "The host name should not contain any spaces.");
            Assert.That(parsed.Endpoint.Host, Does.Not.Contain(":"), "The host name should not contain any port separators (:).");
            Assert.That(parsed.Endpoint.Host, Does.Not.Contain(valueUri.Port), "The host name should not contain the port.");
            Assert.That(parsed.Endpoint.Host, Is.EqualTo(valueUri.Host), "The host name should have been normalized.");
            Assert.That(parsed.Endpoint.ToString(), Does.StartWith(GetEventHubsEndpointScheme()), "The parser's endpoint scheme should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("test.endpoint.com:443")]
        [TestCase("notvalid=[broke]")]
        public void ParseDoesNotAllowAnInvalidEndpointFormat(string endpointValue)
        {
            var connectionString = $"Endpoint={endpointValue }";
            Assert.That(() => ConnectionStringParser.Parse(connectionString), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ConnectionStringParser.Parse" />
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
            Assert.That(() => ConnectionStringParser.Parse(connectionString), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Gets the Event Hubs endpoint scheme used by the <see cref="ConnectionStringParser" />
        ///   using its private field.
        /// </summary>
        ///
        /// <returns>The endpoint scheme used by the parser.</returns>
        ///
        private static string GetEventHubsEndpointScheme() =>
            (string)
                typeof(ConnectionStringParser)
                    .GetField("EventHubsEndpointScheme", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);
    }
}
