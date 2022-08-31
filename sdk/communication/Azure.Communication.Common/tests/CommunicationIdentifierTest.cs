﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

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

            Assert.AreEqual(new PhoneNumberIdentifier("+override", "4:14255550123"), new PhoneNumberIdentifier("+14255550123"));
            Assert.AreEqual(new PhoneNumberIdentifier("+14255550123"), new PhoneNumberIdentifier("+override", "4:14255550123"));
        }

        [Test]
        public void MicrosoftTeamsUserIdentifier_DefaultCloudIsPublic()
            => Assert.AreEqual(CommunicationCloudEnvironment.Public, new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Raw Id").Cloud);

        [Test]
        public void GetRawIdOfIdentifier()
        {
            static void AssertRawId(CommunicationIdentifier identifier, string expectedRawId) => Assert.AreEqual(identifier.RawId, expectedRawId);

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
            AssertRawId(new PhoneNumberIdentifier("+112345556789"), "4:112345556789");
            AssertRawId(new PhoneNumberIdentifier("+112345556789", rawId: "4:otherFormat"), "4:otherFormat");
            AssertRawId(new UnknownIdentifier("28:45ab2481-1c1c-4005-be24-0ffb879b1130"), "28:45ab2481-1c1c-4005-be24-0ffb879b1130");
            AssertRawId(new UnknownIdentifier("someFutureFormat"), "someFutureFormat");
        }

        [Test]
        public void CreateIdentifierFromRawId()
        {
            static void AssertIdentifier(string rawId, CommunicationIdentifier expectedIdentifier)
            {
                Assert.AreEqual(CommunicationIdentifier.FromRawId(rawId), expectedIdentifier);
                Assert.AreEqual(CommunicationIdentifier.FromRawId(rawId).GetHashCode(), expectedIdentifier.GetHashCode());
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
            AssertIdentifier("4:112345556789", new PhoneNumberIdentifier("+112345556789"));
            AssertIdentifier("4:otherFormat", new PhoneNumberIdentifier("+otherFormat"));
            AssertIdentifier("28:45ab2481-1c1c-4005-be24-0ffb879b1130", new UnknownIdentifier("28:45ab2481-1c1c-4005-be24-0ffb879b1130"));

            Assert.Throws<ArgumentNullException>(() => CommunicationIdentifier.FromRawId(null));
        }

        [Test]
        public void RawIdStaysTheSameAfterConversionToIdentifierAndBack()
        {
            static void AssertRoundtrip(string rawId) => Assert.AreEqual(CommunicationIdentifier.FromRawId(rawId).RawId, rawId);

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
            AssertRoundtrip("4:otherFormat");
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
