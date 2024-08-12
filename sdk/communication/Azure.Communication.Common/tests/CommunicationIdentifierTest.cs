// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using System.Runtime.InteropServices;

namespace Azure.Communication
{
    public class CommunicationIdentifierTest
    {
        [Test]
        public void RawIdTakesPrecendenceInEqualityCheck()
        {
            // Teams users
            Assert.AreEqual(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true), new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true));
            Assert.AreNotEqual(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Raw Id"), new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Another Raw Id"));

            Assert.AreEqual(new MicrosoftTeamsUserIdentifier("override", isAnonymous: true, rawId: "8:teamsvisitor:45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true));
            Assert.AreEqual(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true), new MicrosoftTeamsUserIdentifier("override", isAnonymous: true, rawId: "8:teamsvisitor:45ab2481-1c1c-4005-be24-0ffb879b1130"));

            // Phone numbers
            Assert.AreEqual(new PhoneNumberIdentifier("+14255550123"), new PhoneNumberIdentifier("+14255550123"));
            Assert.AreNotEqual(new PhoneNumberIdentifier("+14255550123", "Raw Id"), new PhoneNumberIdentifier("+14255550123", "Another Raw Id"));

            Assert.AreEqual(new PhoneNumberIdentifier("+override", "4:14255550123"), new PhoneNumberIdentifier("14255550123"));
            Assert.AreEqual(new PhoneNumberIdentifier("14255550123"), new PhoneNumberIdentifier("+override", "4:14255550123"));

            // Teams app
            Assert.AreEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"));
            Assert.AreEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Public));
            Assert.AreNotEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Dod));
            Assert.AreNotEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Gcch));

            Assert.AreNotEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("override"));
        }

        [Test]
        public void InitializeIdentifierWithNullOrEmptyParameters()
        {
            Assert.Throws<ArgumentException>(() => new CommunicationUserIdentifier(string.Empty));
            Assert.Throws<ArgumentException>(() => new MicrosoftTeamsUserIdentifier(string.Empty));
            Assert.Throws<ArgumentException>(() => new PhoneNumberIdentifier(string.Empty));
            Assert.Throws<ArgumentException>(() => new MicrosoftTeamsAppIdentifier(string.Empty));

            Assert.Throws<ArgumentNullException>(() => new CommunicationUserIdentifier(null));
            Assert.Throws<ArgumentNullException>(() => new MicrosoftTeamsUserIdentifier(null));
            Assert.Throws<ArgumentNullException>(() => new PhoneNumberIdentifier(null));
            Assert.Throws<ArgumentNullException>(() => new MicrosoftTeamsAppIdentifier(null));
        }

        [Test]
        public void MicrosoftTeamsUserIdentifier_DefaultCloudIsPublic()
            => Assert.AreEqual(CommunicationCloudEnvironment.Public, new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Raw Id").Cloud);

        [Test]
        public void GetRawIdOfIdentifier()
        {
            static void AssertRawId(CommunicationIdentifier identifier, string expectedRawId) => Assert.AreEqual(expectedRawId, identifier.RawId);

            AssertRawId(new CommunicationUserIdentifier("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"), "8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRawId(new CommunicationUserIdentifier("8:gcch-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"), "8:gcch-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRawId(new CommunicationUserIdentifier("someFutureFormat"), "someFutureFormat");
            AssertRawId(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), "8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRawId(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Public), "8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRawId(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Dod), "8:dod:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRawId(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Gcch), "8:gcch:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRawId(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: false), "8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRawId(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true), "8:teamsvisitor:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRawId(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", rawId: "8:orgid:legacyFormat", isAnonymous: true), "8:orgid:legacyFormat");
            AssertRawId(new PhoneNumberIdentifier("+112345556789"), "4:+112345556789");
            AssertRawId(new PhoneNumberIdentifier("+112345556789", rawId: "4:otherFormat"), "4:otherFormat");
            AssertRawId(new MicrosoftTeamsAppIdentifier("01234567-89ab-cdef-0123-456789abcdef", CommunicationCloudEnvironment.Public), "28:orgid:01234567-89ab-cdef-0123-456789abcdef");
            AssertRawId(new MicrosoftTeamsAppIdentifier("01234567-89ab-cdef-0123-456789abcdef", CommunicationCloudEnvironment.Gcch), "28:gcch:01234567-89ab-cdef-0123-456789abcdef");
            AssertRawId(new MicrosoftTeamsAppIdentifier("01234567-89ab-cdef-0123-456789abcdef", CommunicationCloudEnvironment.Dod), "28:dod:01234567-89ab-cdef-0123-456789abcdef");
            AssertRawId(new UnknownIdentifier("28:ag08-global:01234567-89ab-cdef-0123-456789abcdef"), "28:ag08-global:01234567-89ab-cdef-0123-456789abcdef");
            AssertRawId(new PhoneNumberIdentifier("+112345556789"), "4:+112345556789");
            AssertRawId(new PhoneNumberIdentifier("112345556789"), "4:112345556789");
            AssertRawId(new PhoneNumberIdentifier("otherFormat", rawId: "4:207ffef6-9444-41fb-92ab-20eacaae2768"), "4:207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRawId(new PhoneNumberIdentifier("otherFormat", rawId: "4:207ffef6-9444-41fb-92ab-20eacaae2768_207ffef6-9444-41fb-92ab-20eacaae2768"), "4:207ffef6-9444-41fb-92ab-20eacaae2768_207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRawId(new PhoneNumberIdentifier("otherFormat", rawId: "4:+112345556789_207ffef6-9444-41fb-92ab-20eacaae2768"), "4:+112345556789_207ffef6-9444-41fb-92ab-20eacaae2768");
        }

        [Test]
        public void CreateIdentifierFromRawId()
        {
            static void AssertIdentifier(string rawId, CommunicationIdentifier expectedIdentifier)
            {
                Assert.AreEqual(expectedIdentifier,CommunicationIdentifier.FromRawId(rawId));
                Assert.AreEqual(expectedIdentifier.GetHashCode(), CommunicationIdentifier.FromRawId(rawId).GetHashCode());
                Assert.IsTrue(CommunicationIdentifier.FromRawId(rawId) == expectedIdentifier);
                Assert.IsFalse(CommunicationIdentifier.FromRawId(rawId) != expectedIdentifier);
            }

             AssertIdentifier("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130", new CommunicationUserIdentifier("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"));
             AssertIdentifier("8:spool:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130", new CommunicationUserIdentifier("8:spool:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"));
             AssertIdentifier("8:dod-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130", new CommunicationUserIdentifier("8:dod-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"));
             AssertIdentifier("8:gcch-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130", new CommunicationUserIdentifier("8:gcch-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"));
             AssertIdentifier("8:acs:something", new CommunicationUserIdentifier("8:acs:something"));
             AssertIdentifier("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130", new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", false, CommunicationCloudEnvironment.Public));
             AssertIdentifier("8:dod:45ab2481-1c1c-4005-be24-0ffb879b1130", new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", false, CommunicationCloudEnvironment.Dod));
             AssertIdentifier("8:gcch:45ab2481-1c1c-4005-be24-0ffb879b1130", new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", false, CommunicationCloudEnvironment.Gcch));
             AssertIdentifier("8:teamsvisitor:45ab2481-1c1c-4005-be24-0ffb879b1130", new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", true, CommunicationCloudEnvironment.Public));
             AssertIdentifier("8:orgid:legacyFormat", new MicrosoftTeamsUserIdentifier("legacyFormat", false, CommunicationCloudEnvironment.Public));
             AssertIdentifier("4:+112345556789", new PhoneNumberIdentifier("+112345556789"));
             AssertIdentifier("4:112345556789", new PhoneNumberIdentifier("112345556789"));
             AssertIdentifier("4:207ffef6-9444-41fb-92ab-20eacaae2768", new PhoneNumberIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768"));
             AssertIdentifier("4:207ffef6-9444-41fb-92ab-20eacaae2768_207ffef6-9444-41fb-92ab-20eacaae2768", new PhoneNumberIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768_207ffef6-9444-41fb-92ab-20eacaae2768"));
             AssertIdentifier("4:+112345556789_207ffef6-9444-41fb-92ab-20eacaae2768", new PhoneNumberIdentifier("+112345556789_207ffef6-9444-41fb-92ab-20eacaae2768"));
             AssertIdentifier("28:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130", new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"));
             AssertIdentifier("48:45ab2481-1c1c-4005-be24-0ffb879b1130", new UnknownIdentifier("48:45ab2481-1c1c-4005-be24-0ffb879b1130"));
             AssertIdentifier("8:gcch-acs:segment4:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130", new UnknownIdentifier("8:gcch-acs:segment4:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"));

            Assert.Throws<ArgumentNullException>(() => CommunicationIdentifier.FromRawId(null));
        }

        [Test]
        public void RawIdStaysTheSameAfterConversionToIdentifierAndBack()
        {
            static void AssertRoundtrip(string rawId) => Assert.AreEqual(rawId,CommunicationIdentifier.FromRawId(rawId).RawId);

            AssertRoundtrip("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRoundtrip("8:spool:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRoundtrip("8:dod-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRoundtrip("8:gcch-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRoundtrip("8:acs:something");
            AssertRoundtrip("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRoundtrip("8:dod:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRoundtrip("8:gcch:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRoundtrip("8:teamsvisitor:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRoundtrip("8:orgid:legacyFormat");
            AssertRoundtrip("4:112345556789");
            AssertRoundtrip("4:+112345556789");
            AssertRoundtrip("4:207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRoundtrip("4:207ffef6-9444-41fb-92ab-20eacaae2768_207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRoundtrip("4:+112345556789_207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRoundtrip("28:45ab2481-1c1c-4005-be24-0ffb879b1130");
        }

        [Test]
        public void RawIdIsOverriddenBySubTypes()
        {
            var baseType = typeof(CommunicationIdentifier);
            IEnumerable<Type>? implementations = baseType.Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(CommunicationIdentifier)));
            foreach (Type implementation in implementations)
            {
                Assert.AreNotEqual(baseType, implementation.GetProperty(nameof(CommunicationIdentifier.RawId))?.DeclaringType);
            }
        }

        [Test]
        public void RawIdGeneratedIdentifiersSupportedAsKeysInCollections()
        {
            var dictionary = new Dictionary<CommunicationIdentifier, string>
            {
                { new CommunicationUserIdentifier("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"), nameof(CommunicationUserIdentifier)},
                { new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), nameof(MicrosoftTeamsUserIdentifier) },
                { new PhoneNumberIdentifier("+14255550123"), nameof(PhoneNumberIdentifier) },
                { new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), nameof(MicrosoftTeamsAppIdentifier) },
                { new UnknownIdentifier("48:45ab2481-1c1c-4005-be24-0ffb879b1130"), nameof(UnknownIdentifier) }
            };

            var hashSet = new HashSet<CommunicationIdentifier>
            {
                new CommunicationUserIdentifier("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new PhoneNumberIdentifier("+14255550123"),
                new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new UnknownIdentifier("48:45ab2481-1c1c-4005-be24-0ffb879b1130")
            };

            var list = new List<CommunicationIdentifier>
            {
                new CommunicationUserIdentifier("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new PhoneNumberIdentifier("+14255550123"),
                new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new UnknownIdentifier("48:45ab2481-1c1c-4005-be24-0ffb879b1130")
            };

            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130")).WithValue(nameof(CommunicationUserIdentifier)));
            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130")).WithValue(nameof(MicrosoftTeamsUserIdentifier)));
            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("4:+14255550123")).WithValue(nameof(PhoneNumberIdentifier)));
            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("28:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130")).WithValue(nameof(MicrosoftTeamsAppIdentifier)));
            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("48:45ab2481-1c1c-4005-be24-0ffb879b1130")).WithValue(nameof(UnknownIdentifier)));

            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("4:+14255550123"));
            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("28:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("48:45ab2481-1c1c-4005-be24-0ffb879b1130"));

            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("4:+14255550123"));
            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("28:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("48:45ab2481-1c1c-4005-be24-0ffb879b1130"));
        }

        [Test]
        public void EqualityOperatorOverrideDoesntThrow()
        {
            var identifier = new CommunicationUserIdentifier("123");
            var sameIdentifier = new CommunicationUserIdentifier("123");
            var otherIdentifier = new CommunicationUserIdentifier("124");
            var otherTypeIdentifier = new MicrosoftTeamsUserIdentifier("123");
            CommunicationIdentifier? nullIdentifier = null;

            Assert.False(identifier == null);
            Assert.False(null == identifier);
            Assert.True(identifier != null);
            Assert.True(null != identifier);

            Assert.True(null as CommunicationIdentifier == null as CommunicationIdentifier);
            Assert.False(identifier == null as CommunicationIdentifier);
            Assert.False(null as CommunicationIdentifier == identifier);
            Assert.True(identifier != null as CommunicationIdentifier);
            Assert.True(null as CommunicationIdentifier != identifier);

            Assert.True(null == nullIdentifier);
            Assert.False(nullIdentifier == identifier);

#pragma warning disable CS1718 // Comparison made to same variable
            Assert.True(identifier == identifier);
#pragma warning restore CS1718 // Comparison made to same variable
            Assert.True(identifier == sameIdentifier);
            Assert.False(identifier != sameIdentifier);
            Assert.True(sameIdentifier == identifier);
            Assert.False(sameIdentifier != identifier);
            Assert.False(identifier == otherIdentifier);
            Assert.True(identifier != otherIdentifier);
            Assert.False(identifier == otherTypeIdentifier);
            Assert.True(identifier != otherTypeIdentifier);
        }
    }
}
