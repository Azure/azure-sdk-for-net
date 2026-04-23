// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.Communication
{
    public class CommunicationIdentifierTest
    {
        [Test]
        public void RawIdTakesPrecendenceInEqualityCheck()
        {
            // Teams users
            ClassicAssert.AreEqual(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true), new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true));
            ClassicAssert.AreNotEqual(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Raw Id"), new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Another Raw Id"));

            ClassicAssert.AreEqual(new MicrosoftTeamsUserIdentifier("override", isAnonymous: true, rawId: "8:teamsvisitor:45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true));
            ClassicAssert.AreEqual(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true), new MicrosoftTeamsUserIdentifier("override", isAnonymous: true, rawId: "8:teamsvisitor:45ab2481-1c1c-4005-be24-0ffb879b1130"));

            // Phone numbers
            ClassicAssert.AreEqual(new PhoneNumberIdentifier("+14255550123"), new PhoneNumberIdentifier("+14255550123"));
            ClassicAssert.AreNotEqual(new PhoneNumberIdentifier("+14255550123", "Raw Id"), new PhoneNumberIdentifier("+14255550123", "Another Raw Id"));

            ClassicAssert.AreEqual(new PhoneNumberIdentifier("+override", "4:14255550123"), new PhoneNumberIdentifier("14255550123"));
            ClassicAssert.AreEqual(new PhoneNumberIdentifier("14255550123"), new PhoneNumberIdentifier("+override", "4:14255550123"));

            // Teams app
            ClassicAssert.AreEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"));
            ClassicAssert.AreEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Public));
            ClassicAssert.AreNotEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Dod));
            ClassicAssert.AreNotEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Gcch));

            ClassicAssert.AreNotEqual(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), new MicrosoftTeamsAppIdentifier("override"));

            // Teams extension user
            ClassicAssert.AreEqual(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"), new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"));
            ClassicAssert.AreEqual(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"), new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Public));
            ClassicAssert.AreNotEqual(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"), new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Gcch));
            ClassicAssert.AreNotEqual(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"), new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Dod));
        }

        [Test]
        public void InitializeIdentifierWithNullOrEmptyParameters()
        {
            ClassicAssert.Throws<ArgumentException>(() => new CommunicationUserIdentifier(string.Empty));
            ClassicAssert.Throws<ArgumentException>(() => new MicrosoftTeamsUserIdentifier(string.Empty));
            ClassicAssert.Throws<ArgumentException>(() => new PhoneNumberIdentifier(string.Empty));
            ClassicAssert.Throws<ArgumentException>(() => new MicrosoftTeamsAppIdentifier(string.Empty));
            ClassicAssert.Throws<ArgumentException>(() => new TeamsExtensionUserIdentifier(string.Empty, string.Empty, string.Empty));

            ClassicAssert.Throws<ArgumentNullException>(() => new CommunicationUserIdentifier(null));
            ClassicAssert.Throws<ArgumentNullException>(() => new MicrosoftTeamsUserIdentifier(null));
            ClassicAssert.Throws<ArgumentNullException>(() => new PhoneNumberIdentifier(null));
            ClassicAssert.Throws<ArgumentNullException>(() => new MicrosoftTeamsAppIdentifier(null));
            ClassicAssert.Throws<ArgumentNullException>(() => new TeamsExtensionUserIdentifier(null, "b", "c"));
            ClassicAssert.Throws<ArgumentNullException>(() => new TeamsExtensionUserIdentifier("a", null, "c"));
            ClassicAssert.Throws<ArgumentNullException>(() => new TeamsExtensionUserIdentifier("a", "b", null));
        }

        [Test]
        public void DefaultCloudIsPublic()
        {
            ClassicAssert.AreEqual(CommunicationCloudEnvironment.Public, new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Raw Id").Cloud);
            ClassicAssert.AreEqual(CommunicationCloudEnvironment.Public, new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130").Cloud);
            ClassicAssert.AreEqual(CommunicationCloudEnvironment.Public, new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd").Cloud);
        }

        [Test]
        public void PhoneNumberIdentifier_ComputedProperties()
        {
            ClassicAssert.AreEqual(false, new PhoneNumberIdentifier("14255550123").IsAnonymous);
            ClassicAssert.AreEqual(true, new PhoneNumberIdentifier("anonymous").IsAnonymous);
            ClassicAssert.AreEqual(true, new PhoneNumberIdentifier("override", "4:anonymous").IsAnonymous);
            ClassicAssert.AreEqual(false, new PhoneNumberIdentifier("override", "4:anonymous123").IsAnonymous);
            ClassicAssert.AreEqual(false, new PhoneNumberIdentifier("override", "4:_anonymous").IsAnonymous);

            ClassicAssert.AreEqual(null, new PhoneNumberIdentifier("14255550121").AssertedId);
            ClassicAssert.AreEqual(null, new PhoneNumberIdentifier("14255550121.123").AssertedId);
            ClassicAssert.AreEqual(null, new PhoneNumberIdentifier("14255550121-123").AssertedId);
            ClassicAssert.AreEqual("123", new PhoneNumberIdentifier("14255550121_123").AssertedId);
            ClassicAssert.AreEqual("123", new PhoneNumberIdentifier("14255550121", "4:14255550121_123").AssertedId);
            ClassicAssert.AreEqual("456", new PhoneNumberIdentifier("14255550121_123_456").AssertedId);
            ClassicAssert.AreEqual("456", new PhoneNumberIdentifier("14255550121", "4:14255550121_123_456").AssertedId);

            var staticPhoneNumberIdentifier = new PhoneNumberIdentifier("14255550121_123");
            ClassicAssert.AreEqual("123", staticPhoneNumberIdentifier.AssertedId); // first use: compute assertedId
            ClassicAssert.AreEqual("123", staticPhoneNumberIdentifier.AssertedId); // second use: reuse previously computed assertedId
        }

        [Test]
        public void GetRawIdOfIdentifier()
        {
            static void AssertRawId(CommunicationIdentifier identifier, string expectedRawId) => ClassicAssert.AreEqual(expectedRawId, identifier.RawId);

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
            AssertRawId(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"), "8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRawId(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Public), "8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRawId(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Gcch), "8:gcch-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRawId(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Dod), "8:dod-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768");
        }

        [Test]
        public void CreateIdentifierFromRawId()
        {
            static void AssertIdentifier(string rawId, CommunicationIdentifier expectedIdentifier)
            {
                ClassicAssert.AreEqual(expectedIdentifier, CommunicationIdentifier.FromRawId(rawId));
                ClassicAssert.AreEqual(expectedIdentifier.GetHashCode(), CommunicationIdentifier.FromRawId(rawId).GetHashCode());
                ClassicAssert.IsTrue(CommunicationIdentifier.FromRawId(rawId) == expectedIdentifier);
                ClassicAssert.IsFalse(CommunicationIdentifier.FromRawId(rawId) != expectedIdentifier);
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

            AssertIdentifier("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768", new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"));
            AssertIdentifier("8:gcch-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768", new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Gcch));
            AssertIdentifier("8:dod-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768", new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Dod));

            ClassicAssert.Throws<ArgumentNullException>(() => CommunicationIdentifier.FromRawId(null));
        }

        [Test]
        public void RawIdStaysTheSameAfterConversionToIdentifierAndBack()
        {
            static void AssertRoundtrip(string rawId) => ClassicAssert.AreEqual(rawId, CommunicationIdentifier.FromRawId(rawId).RawId);

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
            AssertRoundtrip("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRoundtrip("8:gcch-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768");
            AssertRoundtrip("8:dod-acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768");
        }

        [Test]
        public void RawIdIsOverriddenBySubTypes()
        {
            var baseType = typeof(CommunicationIdentifier);
            IEnumerable<Type>? implementations = baseType.Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(CommunicationIdentifier)));
            foreach (Type implementation in implementations)
            {
                ClassicAssert.AreNotEqual(baseType, implementation.GetProperty(nameof(CommunicationIdentifier.RawId))?.DeclaringType);
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
                { new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"), nameof(TeamsExtensionUserIdentifier) },
                { new UnknownIdentifier("48:45ab2481-1c1c-4005-be24-0ffb879b1130"), nameof(UnknownIdentifier) }
            };

            var hashSet = new HashSet<CommunicationIdentifier>
            {
                new CommunicationUserIdentifier("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new PhoneNumberIdentifier("+14255550123"),
                new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"),
                new UnknownIdentifier("48:45ab2481-1c1c-4005-be24-0ffb879b1130")
            };

            var list = new List<CommunicationIdentifier>
            {
                new CommunicationUserIdentifier("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new PhoneNumberIdentifier("+14255550123"),
                new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"),
                new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"),
                new UnknownIdentifier("48:45ab2481-1c1c-4005-be24-0ffb879b1130")
            };

            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130")).WithValue(nameof(CommunicationUserIdentifier)));
            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130")).WithValue(nameof(MicrosoftTeamsUserIdentifier)));
            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("4:+14255550123")).WithValue(nameof(PhoneNumberIdentifier)));
            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("28:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130")).WithValue(nameof(MicrosoftTeamsAppIdentifier)));
            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768")).WithValue(nameof(TeamsExtensionUserIdentifier)));
            Assert.That(dictionary, Does.ContainKey(CommunicationIdentifier.FromRawId("48:45ab2481-1c1c-4005-be24-0ffb879b1130")).WithValue(nameof(UnknownIdentifier)));

            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("4:+14255550123"));
            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("28:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768"));
            CollectionAssert.Contains(hashSet, CommunicationIdentifier.FromRawId("48:45ab2481-1c1c-4005-be24-0ffb879b1130"));

            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("4:+14255550123"));
            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("28:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130"));
            CollectionAssert.Contains(list, CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768"));
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

            ClassicAssert.False(identifier == null);
            ClassicAssert.False(null == identifier);
            ClassicAssert.True(identifier != null);
            ClassicAssert.True(null != identifier);

            ClassicAssert.True(null as CommunicationIdentifier == null as CommunicationIdentifier);
            ClassicAssert.False(identifier == null as CommunicationIdentifier);
            ClassicAssert.False(null as CommunicationIdentifier == identifier);
            ClassicAssert.True(identifier != null as CommunicationIdentifier);
            ClassicAssert.True(null as CommunicationIdentifier != identifier);

            ClassicAssert.True(null == nullIdentifier);
            ClassicAssert.False(nullIdentifier == identifier);

#pragma warning disable CS1718 // Comparison made to same variable
            ClassicAssert.True(identifier == identifier);
#pragma warning restore CS1718 // Comparison made to same variable
            ClassicAssert.True(identifier == sameIdentifier);
            ClassicAssert.False(identifier != sameIdentifier);
            ClassicAssert.True(sameIdentifier == identifier);
            ClassicAssert.False(sameIdentifier != identifier);
            ClassicAssert.False(identifier == otherIdentifier);
            ClassicAssert.True(identifier != otherIdentifier);
            ClassicAssert.False(identifier == otherTypeIdentifier);
            ClassicAssert.True(identifier != otherTypeIdentifier);
        }
    }
}
