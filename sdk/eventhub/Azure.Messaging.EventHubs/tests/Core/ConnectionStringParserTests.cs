// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;
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
        public void ParseDoesNotAllowAnInvalidEndpointFormat()
        {
            var connectionString = $"Endpoint=notvalid=[broke]";
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
    }
}
