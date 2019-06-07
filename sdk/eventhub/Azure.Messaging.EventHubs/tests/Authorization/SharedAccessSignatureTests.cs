// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs.Authorization;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Authorization
{
    /// <summary>
    ///   The suite of unit tests for the <see cref="SharedAccessSignature" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class SharedAccessSignatureTests
    {
        /// <summary>A string that is 300 characters long, breaking invariants for argument maximum lengths.</summary>
        private const string ThreeHundredCharacterString = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

        /// <summary>
        ///   The set of test cases for the different signature-based constructors.
        /// </summary>
        ///
        public static IEnumerable<object[]> SignatureConstructorTestCases()
        {
            Func<string, string, object> signatureOnly = (signature, key) => new SharedAccessSignature(signature);
            yield return new object[] { signatureOnly, "signature only constructor" };

            Func<string, string, object> signatureAndKey = (signature, key) => new SharedAccessSignature(signature, key);
            yield return new object[] { signatureAndKey, "signature and key constructor" };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.ToString" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToStringReflectsTheValue()
        {
            var expected = "This is the value of the SAS";
            var signature = new SettablePropertiesMock(value: expected);

            Assert.That(signature.ToString(), Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CompositeConstructorValidatesTheHost(string host)
        {
            Assert.That(() => new SharedAccessSignature(ConnectionType.AmqpWebSockets, host, "fake", "Yay", "OMG!", TimeSpan.FromMilliseconds(500)), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CompositeConstructorValidatesTheEventHubPath(string path)
        {
            Assert.That(() => new SharedAccessSignature(ConnectionType.AmqpWebSockets, "my.eh.com", path, "Yay", "OMG!", TimeSpan.FromMilliseconds(500)), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(ThreeHundredCharacterString)]
        public void CompositeConstructorValidatesTheKeyName(string keyName)
        {
            Assert.That(() => new SharedAccessSignature(ConnectionType.AmqpWebSockets, "my.eh.com", "hub", keyName, "OMG!", TimeSpan.FromMilliseconds(500)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(ThreeHundredCharacterString)]
        public void CompositeConstructorValidatesTheKey(string key)
        {
            Assert.That(() => new SharedAccessSignature(ConnectionType.AmqpWebSockets, "my.eh.com", "hub", "myKey", key, TimeSpan.FromMilliseconds(500)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorDisallowsNegativeDuration()
        {
            Assert.That(() => new SharedAccessSignature(ConnectionType.AmqpWebSockets, "my.eh.com", "hub", "myKey", "key", TimeSpan.FromMilliseconds(-1)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorSetsSimpleProperties()
        {
            var path = "ExpectedPath";
            var keyName = "ExpectedKeyName";
            var keyValue = "ExpectedKeyValue";
            var signature = new SharedAccessSignature(ConnectionType.AmqpWebSockets, "my.eh.com", path, keyName, keyValue, TimeSpan.FromSeconds(30));

            Assert.That(signature.SharedAccessKeyName, Is.EqualTo(keyName), "The shared access key name should match.");
            Assert.That(signature.SharedAccessKey, Is.EqualTo(keyValue), "The shared access key should match.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorComputesTheExpiration()
        {
            var timeToLive = TimeSpan.FromMinutes(10);
            var expectedExpiration = DateTime.UtcNow.Add(timeToLive);
            var allowedVariance = TimeSpan.FromSeconds(5);
            var signature = new SharedAccessSignature(ConnectionType.AmqpWebSockets, "my.eh.com", "path", "theKey", "keykeykey", timeToLive);

            Assert.That(signature.ExpirationUtc, Is.EqualTo(expectedExpiration).Within(allowedVariance));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorNormalizesTheResource()
        {
            var host = "my.eventhub.com";
            var path = "someHub";
            var signature = new SharedAccessSignature(ConnectionType.AmqpWebSockets, host, path, "theKey", "keykeykey", TimeSpan.FromSeconds(30));

            Assert.That(signature.Resource, Is.Not.Null.Or.Empty, "The resource should have been populated.");
            Assert.That(signature.Resource, Is.EqualTo(signature.Resource.ToLowerInvariant()), "The resource should have been normalized to lower case.");

            var uri = new Uri(signature.Resource, UriKind.Absolute);

            Assert.That(uri.AbsolutePath.StartsWith("/"), Is.True, "The resource path have been normalized to begin with a trailing slash.");
            Assert.That(uri.AbsolutePath.EndsWith("/"), Is.True, "The resource path have been normalized to end with a trailing slash.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorBuildsTheResourceFromHostAndPath()
        {
            var host = "my.eventhub.com";
            var path = "someHub";
            var expectedPath = $"/{ path.ToLowerInvariant() }/";
            var signature = new SharedAccessSignature(ConnectionType.AmqpTcp, host, path, "theKey", "keykeykey", TimeSpan.FromSeconds(30));

            Assert.That(signature.Resource, Is.Not.Null.Or.Empty, "The resource should have been populated.");

            var uri = new Uri(signature.Resource, UriKind.Absolute);

            Assert.That(uri.Host, Is.EqualTo(host), "The resource should match the host.");
            Assert.That(uri.AbsolutePath, Is.EqualTo(expectedPath), "The resource path should match the Event Hub path.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorCreatesTheSignatureValue()
        {
            var longLegalString = new String('G', 250);
            var signature = new SharedAccessSignature(ConnectionType.AmqpTcp, "my.eh.com", "somePath", longLegalString, longLegalString, TimeSpan.FromDays(30));
            Assert.That(signature.Value, Is.Not.Null.Or.Empty);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void SignatureKeyConstructorValidatesTheSignature(string signature)
        {
            Assert.That(() => new SharedAccessSignature(signature, "key"), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SignatureKeyConstructorValidatesTheKey()
        {
            Assert.That(() => new SharedAccessSignature("invalid-signature", ThreeHundredCharacterString), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SignatureKeyConstructorSetsTheKey()
        {
            var key = "an-amazing-KEY";
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey&notreal=123", key);

            Assert.That(signature.SharedAccessKey, Is.EqualTo(key));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void SignatureOnlyConstructorValidatesTheSignature(string signature)
        {
            Assert.That(() => new SharedAccessSignature(signature), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SignatureOnlyConstructorDoesNotSetTheKey()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey&notreal=123");
            Assert.That(signature.SharedAccessKey, Is.Null);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(SignatureConstructorTestCases))]
        public void SignatureConstructorsOnFailMalformedSignature(Func<string, string, object> constructor,
                                                                  string description)
        {
            var invalid = "sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey";
            Assert.That(() => constructor(invalid, "key"), Throws.ArgumentException, $"The { description } should fail for a malformed signature");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(SignatureConstructorTestCases))]
        public void SignatureConstructorsParseTheSignature(Func<string, string, object> constructor,
                                                           string description)
        {
            var host = "my.hubthing.com";
            var path = "someHubInstance";
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            var expiration = DateTime.UtcNow.Add(validFor);
            var composedSignature = new SharedAccessSignature(ConnectionType.AmqpTcp, host, path, keyName, key, validFor);
            var parsedSignature = constructor(composedSignature.ToString(), keyName) as SharedAccessSignature;

            Assert.That(parsedSignature, Is.Not.Null, "There should have been a result returned.");
            Assert.That(parsedSignature.Resource, Contains.Substring(host.ToLower()), "The resource should contain the host.");
            Assert.That(parsedSignature.Resource, Contains.Substring(path.ToLower()), "The resource should contain the Event Hub path.");
            Assert.That(parsedSignature.SharedAccessKeyName, Is.EqualTo(keyName), "The key name should have been parsed.");
            Assert.That(parsedSignature.ExpirationUtc, Is.EqualTo(expiration).Within(TimeSpan.FromSeconds(5)), "The expiration should be parsed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&")]
        public void ParseSignatureFailsWhenComponentsAreMissing(string signature)
        {
            var parser = new ParserMock();
            Assert.That(() => parser.Parse(signature), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessSignature sr=&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=&se=1562258488&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn")]
        public void ParseSignatureFailsWhenValuesAreMissing(string signature)
        {
            var parser = new ParserMock();
            Assert.That(() => parser.Parse(signature), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=  &skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=hello&skn=keykeykey")]
        public void ParseSignatureFailsWhenExpirationIsInvalid(string signature)
        {
            var parser = new ParserMock();
            Assert.That(() => parser.Parse(signature), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn = keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn= keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn =keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D& se=1562258488&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F  &sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D& se=1562258488&skn=keykeykey")]
        public void ParseToleratesExtraSpacing(string signature)
        {
            var parser = new ParserMock();
            Assert.That(() => parser.Parse(signature), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey&")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey")]
        public void ParseToleratesTrailingDelimiters(string signature)
        {
            var parser = new ParserMock();
            Assert.That(() => parser.Parse(signature), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey&notreal=123")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&fale=test&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey")]
        public void ParseToleratesExtraTokens(string signature)
        {
            var parser = new ParserMock();
            Assert.That(() => parser.Parse(signature), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseExtractsValues()
        {
            var signature = "SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey";
            var parsed = new ParserMock().Parse(signature);

            Assert.That(parsed, Is.Not.Null, "There should have been a result returned.");
            Assert.That(parsed.Resource, Is.Not.Null.Or.Empty, "The resource should have been parsed.");
            Assert.That(parsed.KeyName, Is.Not.Null.Or.Empty, "The key should have been parsed.");
            Assert.That(parsed.ExpirationUtc, Is.Not.EqualTo(default(DateTime)), "The expiration should be parsed.");
        }

        /// <summary>
        ///   Validates functionality of the <see cref="SharedAccessSignature.ExtendExpiration" />
        ///   method.
        /// </summary>
        [Test]
        public void ExtendValidityValidatesTheDuration()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey&notreal=123");
            Assert.That(() => signature.ExtendExpiration(TimeSpan.FromMilliseconds(-1)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Validates functionality of the <see cref="SharedAccessSignature.ExtendExpiration" />
        ///   method.
        /// </summary>
        [Test]
        public void ExtendValidityValidatesTheKey()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey&notreal=123");
            Assert.That(() => signature.ExtendExpiration(TimeSpan.FromMilliseconds(21)), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Validates functionality of the <see cref="SharedAccessSignature.ExtendExpiration" />
        ///   method.
        /// </summary>
        [Test]
        public void ExtendExpirationUpdatesTheSignatureValue()
        {
            var host = "my.hubthing.com";
            var path = "someHubInstance";
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            var composedSignature = new SharedAccessSignature(ConnectionType.AmqpTcp, host, path, keyName, key, validFor);
            var parsedSignature = new SharedAccessSignature(composedSignature.ToString(), keyName) as SharedAccessSignature;
            var initialParsedValue = parsedSignature.Value;

            parsedSignature.ExtendExpiration(TimeSpan.FromHours(4));
            Assert.That(parsedSignature.Value, Is.Not.EqualTo(initialParsedValue));
        }

        /// <summary>
        ///   Validates functionality of the <see cref="SharedAccessSignature.ExtendExpiration" />
        ///   method.
        /// </summary>
        [Test]
        public void ExtendExpirationUpdatesTheExpirationTime()
        {
            var host = "my.hubthing.com";
            var path = "someHubInstance";
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            var extendBy = TimeSpan.FromHours(1);
            var expiration = DateTime.UtcNow.Add(extendBy);
            var composedSignature = new SharedAccessSignature(ConnectionType.AmqpTcp, host, path, keyName, key, validFor);
            var parsedSignature = new SharedAccessSignature(composedSignature.ToString(), keyName) as SharedAccessSignature;

            parsedSignature.ExtendExpiration(extendBy);
            Assert.That(parsedSignature.ExpirationUtc, Is.EqualTo(expiration).Within(TimeSpan.FromSeconds(5)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseProducesCorrectValues()
        {
            var host = "my.hubthing.com";
            var path = "someHubInstance";
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            var expiration = DateTime.UtcNow.Add(validFor);
            var signature = new SharedAccessSignature(ConnectionType.AmqpTcp, host, path, keyName, key, validFor);
            var parsed = new ParserMock().Parse(signature.ToString());

            Assert.That(parsed, Is.Not.Null, "There should have been a result returned.");
            Assert.That(parsed.Resource, Contains.Substring(host.ToLower()), "The resource should contain the host.");
            Assert.That(parsed.Resource, Contains.Substring(path.ToLower()), "The resource should contain the Event Hub path.");
            Assert.That(parsed.KeyName, Is.EqualTo(keyName), "The key name should have been parsed.");
            Assert.That(parsed.ExpirationUtc, Is.EqualTo(expiration).Within(TimeSpan.FromSeconds(5)), "The expiration should be parsed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneCreatesTheCopy()
        {
            var host = "my.hubthing.com";
            var path = "someHubInstance";
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            var signature = new SharedAccessSignature(ConnectionType.AmqpTcp, host, path, keyName, key, validFor);
            var clone = signature.Clone();

            Assert.That(clone, Is.Not.Null, "There should have been a copy produced.");
            Assert.That(clone, Is.Not.SameAs(signature), "The clone should be a unique instance.");
            Assert.That(clone.Resource, Is.EqualTo(signature.Resource), "The resource should match.");
            Assert.That(clone.SharedAccessKeyName, Is.EqualTo(signature.SharedAccessKeyName), "The key name should match.");
            Assert.That(clone.SharedAccessKey, Is.EqualTo(signature.SharedAccessKey), "The key should match.");
            Assert.That(clone.ExpirationUtc, Is.EqualTo(signature.ExpirationUtc), "The expiration should match.");
        }

        /// <summary>
        ///   Allows for the properties of the shared access signature to be manually set for
        ///   testing purposes.
        /// </summary>
        ///
        private class SettablePropertiesMock : SharedAccessSignature
        {
            public SettablePropertiesMock(string sharedAccessKeyName = default,
                                          string sharedAccessKey = default,
                                          DateTime expirationUtc = default,
                                          string resource = default,
                                          string value = default) : base()
            {
                SharedAccessKeyName = sharedAccessKeyName;
                SharedAccessKey = sharedAccessKey;
                ExpirationUtc = expirationUtc;
                Resource = resource;
                Value = value;
            }
        }

        /// <summary>
        ///   Allows for the signature parser to be exposed for testing purposes.
        /// </summary>
        ///
        private class ParserMock : SharedAccessSignature
        {
            public ParserMock() : base()
            {
            }

            public (string KeyName, string Resource, DateTime ExpirationUtc) Parse(string signature) =>
                base.ParseSignature(signature);
        }
    }
}
