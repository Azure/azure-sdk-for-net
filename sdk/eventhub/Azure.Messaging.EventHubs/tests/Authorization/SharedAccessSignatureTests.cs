// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Messaging.EventHubs.Authorization;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventHubs.Tests
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
            var signature = new SharedAccessSignature(string.Empty, "keyName", "key", expected, DateTimeOffset.UtcNow.AddHours(4));

            Assert.That(signature.ToString(), Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CompositeConstructorValidatesTheResource(string resource)
        {
            ExactTypeConstraint typeConstraint = resource is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            Assert.That(() => new SharedAccessSignature(resource, "Yay", "OMG!", TimeSpan.FromMilliseconds(500)), typeConstraint);
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
            Assert.That(() => new SharedAccessSignature("amqps://some.namespace.com/hubName", keyName, "OMG!", TimeSpan.FromMilliseconds(500)), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new SharedAccessSignature("amqps://some.namespace.com/hubName", "myKey", key, TimeSpan.FromMilliseconds(500)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorDisallowsNegativeDuration()
        {
            Assert.That(() => new SharedAccessSignature("amqps://some.namespace.com/hubName", "myKey", "key", TimeSpan.FromMilliseconds(-1)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorSetsSimpleProperties()
        {
            var keyName = "ExpectedKeyName";
            var keyValue = "ExpectedKeyValue";
            var signature = new SharedAccessSignature("amqps://some.namespace.com/hubName", keyName, keyValue, TimeSpan.FromSeconds(30));

            Assert.That(signature.SharedAccessKeyName, Is.EqualTo(keyName), "The shared access key name should match.");
            Assert.That(signature.SharedAccessKey, Is.EqualTo(keyValue), "The shared access key should match.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorComputesTheExpirationWhenProvided()
        {
            var timeToLive = TimeSpan.FromMinutes(10);
            DateTimeOffset expectedExpiration = DateTimeOffset.UtcNow.Add(timeToLive);
            var allowedVariance = TimeSpan.FromSeconds(5);
            var signature = new SharedAccessSignature("amqps://some.namespace.com/hubName", "theKey", "keykeykey", timeToLive);

            Assert.That(signature.SignatureExpiration, Is.EqualTo(expectedExpiration).Within(allowedVariance));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorComputesTheExpirationWhenTheDefaultIsUsed()
        {
            DateTimeOffset minimumExpiration = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1));
            var signature = new SharedAccessSignature("amqps://some.namespace.com/hubName", "theKey", "keykeykey");

            Assert.That(signature.SignatureExpiration, Is.GreaterThan(minimumExpiration));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositePopulatesTheResource()
        {
            var resource = "amqps://some.namespace.com/hubName";
            var signature = new SharedAccessSignature(resource, "theKey", "keykeykey", TimeSpan.FromSeconds(30));

            Assert.That(signature.Resource, Is.Not.Null.Or.Empty, "The resource should have been populated.");
            Assert.That(signature.Resource, Is.EqualTo("amqps://some.namespace.com/hubName"), "The resource should match.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CompositeConstructorCreatesTheSignatureValue()
        {
            var longLegalString = new string('G', 250);
            var signature = new SharedAccessSignature("amqps://some.namespace.com/hubName", longLegalString, longLegalString, TimeSpan.FromDays(30));
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
            ExactTypeConstraint typeConstraint = signature is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            Assert.That(() => new SharedAccessSignature(signature, "key"), typeConstraint);
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
            ExactTypeConstraint typeConstraint = signature is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            Assert.That(() => new SharedAccessSignature(signature), typeConstraint);
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
        public void SignatureConstructorsFailWithMalformedSignature(Func<string, string, object> constructor,
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
            var resource = "amqps://some.namespace.com/hubName";
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            DateTimeOffset expiration = DateTimeOffset.UtcNow.Add(validFor);
            var composedSignature = new SharedAccessSignature("amqps://some.namespace.com/hubName", keyName, key, validFor);
            var parsedSignature = constructor(composedSignature.ToString(), keyName) as SharedAccessSignature;

            Assert.That(parsedSignature, Is.Not.Null, "There should have been a result returned.");
            Assert.That(parsedSignature.Resource, Is.EqualTo(resource), "The resource should match.");
            Assert.That(parsedSignature.SharedAccessKeyName, Is.EqualTo(keyName), "The key name should have been parsed.");
            Assert.That(parsedSignature.SignatureExpiration, Is.EqualTo(expiration).Within(TimeSpan.FromSeconds(5)), "The expiration should be parsed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&")]
        public void ParseSignatureFailsWhenComponentsAreMissing(string signature)
        {
            Assert.That(() => ParseSignature(signature), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ParseSignature" />
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
            Assert.That(() => ParseSignature(signature), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=&skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=  &skn=keykeykey")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=hello&skn=keykeykey")]
        public void ParseSignatureFailsWhenExpirationIsInvalid(string signature)
        {
            Assert.That(() => ParseSignature(signature), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ParseSignature" />
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
            Assert.That(() => ParseSignature(signature), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey&")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey")]
        public void ParseToleratesTrailingDelimiters(string signature)
        {
            Assert.That(() => ParseSignature(signature), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey&notreal=123")]
        [TestCase("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&false=test&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey")]
        public void ParseToleratesExtraTokens(string signature)
        {
            Assert.That(() => ParseSignature(signature), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseExtractsValues()
        {
            var signature = "SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey";
            (string KeyName, string Resource, DateTimeOffset ExpirationTime) parsed = ParseSignature(signature);

            Assert.That(parsed, Is.Not.Null, "There should have been a result returned.");
            Assert.That(parsed.Resource, Is.Not.Null.Or.Empty, "The resource should have been parsed.");
            Assert.That(parsed.KeyName, Is.Not.Null.Or.Empty, "The key should have been parsed.");
            Assert.That(parsed.ExpirationTime, Is.Not.EqualTo(default(DateTimeOffset)), "The expiration should be parsed.");
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
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            var composedSignature = new SharedAccessSignature("amqps://some.namespace.com/hubName", keyName, key, validFor);
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
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            var extendBy = TimeSpan.FromHours(1);
            DateTimeOffset expiration = DateTimeOffset.UtcNow.Add(extendBy);
            var composedSignature = new SharedAccessSignature("amqps://some.namespace.com/hubName", keyName, key, validFor);
            var parsedSignature = new SharedAccessSignature(composedSignature.ToString(), keyName) as SharedAccessSignature;

            parsedSignature.ExtendExpiration(extendBy);
            Assert.That(parsedSignature.SignatureExpiration, Is.EqualTo(expiration).Within(TimeSpan.FromSeconds(5)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ParseSignature" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ParseProducesCorrectValues()
        {
            var resource = "amqps://some.namespace.com/hubName";
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            DateTimeOffset expiration = DateTimeOffset.UtcNow.Add(validFor);
            var signature = new SharedAccessSignature(resource, keyName, key, validFor);
            (string KeyName, string Resource, DateTimeOffset ExpirationTime) parsed = ParseSignature(signature.ToString());

            Assert.That(parsed, Is.Not.Null, "There should have been a result returned.");
            Assert.That(parsed.Resource, Is.EqualTo("amqps://some.namespace.com/hubName"), "The resource should match.");
            Assert.That(parsed.KeyName, Is.EqualTo(keyName), "The key name should have been parsed.");
            Assert.That(parsed.ExpirationTime, Is.EqualTo(expiration).Within(TimeSpan.FromSeconds(5)), "The expiration should be parsed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignature.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var resource = "amqps://some.namespace.com/hubName";
            var keyName = "rootShared";
            var key = "ABC123FFF333";
            var validFor = TimeSpan.FromMinutes(30);
            var signature = new SharedAccessSignature(resource, keyName, key, validFor);
            SharedAccessSignature clone = signature.Clone();

            Assert.That(clone, Is.Not.Null, "There should have been a copy produced.");
            Assert.That(clone, Is.Not.SameAs(signature), "The clone should be a unique instance.");
            Assert.That(clone.Resource, Is.EqualTo(signature.Resource), "The resource should match.");
            Assert.That(clone.SharedAccessKeyName, Is.EqualTo(signature.SharedAccessKeyName), "The key name should match.");
            Assert.That(clone.SharedAccessKey, Is.EqualTo(signature.SharedAccessKey), "The key should match.");
            Assert.That(clone.SignatureExpiration, Is.EqualTo(signature.SignatureExpiration), "The expiration should match.");
        }

        /// <summary>
        ///  A test shim to allow direct access to the implementation of signature parsing
        ///  within the <see cref="SharedAccessSignature" />.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature">The shared access signature to parse.</param>
        ///
        /// <returns>The set of composite properties parsed from the signature.</returns>
        ///
        private static (string KeyName, string Resource, DateTimeOffset ExpirationTime) ParseSignature(string sharedAccessSignature)
        {
            try
            {
                return ((string KeyName, string Resource, DateTimeOffset ExpirationTime))
                    typeof(SharedAccessSignature)
                        .GetMethod(nameof(ParseSignature), BindingFlags.Static | BindingFlags.NonPublic)
                        .Invoke(null, new object[] { sharedAccessSignature });
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                throw ex.InnerException;
            }
        }
    }
}
