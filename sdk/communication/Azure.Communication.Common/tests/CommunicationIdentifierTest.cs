// Copyright (c) Microsoft Corporation. All rights reserved.
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
            Assert.Multiple(() =>
            {
                // Teams users
                Assert.That(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true), Is.EqualTo(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true)));
                Assert.That(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Another Raw Id"), Is.Not.EqualTo(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Raw Id")));
            });

            Assert.That(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true), Is.EqualTo(new MicrosoftTeamsUserIdentifier("override", isAnonymous: true, rawId: "8:teamsvisitor:45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(new MicrosoftTeamsUserIdentifier("override", isAnonymous: true, rawId: "8:teamsvisitor:45ab2481-1c1c-4005-be24-0ffb879b1130"), Is.EqualTo(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true)));

            // Phone numbers
            Assert.That(new PhoneNumberIdentifier("+14255550123"), Is.EqualTo(new PhoneNumberIdentifier("+14255550123")));
            Assert.That(new PhoneNumberIdentifier("+14255550123", "Another Raw Id"), Is.Not.EqualTo(new PhoneNumberIdentifier("+14255550123", "Raw Id")));

            Assert.That(new PhoneNumberIdentifier("14255550123"), Is.EqualTo(new PhoneNumberIdentifier("+override", "4:14255550123")));
            Assert.That(new PhoneNumberIdentifier("+override", "4:14255550123"), Is.EqualTo(new PhoneNumberIdentifier("14255550123")));

            // Teams app
            Assert.That(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130"), Is.EqualTo(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Public), Is.EqualTo(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Dod), Is.Not.EqualTo(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", cloud: CommunicationCloudEnvironment.Gcch), Is.Not.EqualTo(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130")));

            Assert.That(new MicrosoftTeamsAppIdentifier("override"), Is.Not.EqualTo(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130")));

            // Teams extension user
            Assert.That(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd"), Is.EqualTo(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd")));
            Assert.That(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Public), Is.EqualTo(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd")));
            Assert.That(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Gcch), Is.Not.EqualTo(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd")));
            Assert.That(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd", CommunicationCloudEnvironment.Dod), Is.Not.EqualTo(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd")));
        }

        [Test]
        public void InitializeIdentifierWithNullOrEmptyParameters()
        {
            Assert.Throws<ArgumentException>(() => new CommunicationUserIdentifier(string.Empty));
            Assert.Throws<ArgumentException>(() => new MicrosoftTeamsUserIdentifier(string.Empty));
            Assert.Throws<ArgumentException>(() => new PhoneNumberIdentifier(string.Empty));
            Assert.Throws<ArgumentException>(() => new MicrosoftTeamsAppIdentifier(string.Empty));
            Assert.Throws<ArgumentException>(() => new TeamsExtensionUserIdentifier(string.Empty, string.Empty, string.Empty));

            Assert.Throws<ArgumentNullException>(() => new CommunicationUserIdentifier(null));
            Assert.Throws<ArgumentNullException>(() => new MicrosoftTeamsUserIdentifier(null));
            Assert.Throws<ArgumentNullException>(() => new PhoneNumberIdentifier(null));
            Assert.Throws<ArgumentNullException>(() => new MicrosoftTeamsAppIdentifier(null));
            Assert.Throws<ArgumentNullException>(() => new TeamsExtensionUserIdentifier(null, "b", "c"));
            Assert.Throws<ArgumentNullException>(() => new TeamsExtensionUserIdentifier("a", null, "c"));
            Assert.Throws<ArgumentNullException>(() => new TeamsExtensionUserIdentifier("a", "b", null));
        }

        [Test]
        public void DefaultCloudIsPublic()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new MicrosoftTeamsUserIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130", isAnonymous: true, rawId: "Raw Id").Cloud, Is.EqualTo(CommunicationCloudEnvironment.Public));
                Assert.That(new MicrosoftTeamsAppIdentifier("45ab2481-1c1c-4005-be24-0ffb879b1130").Cloud, Is.EqualTo(CommunicationCloudEnvironment.Public));
                Assert.That(new TeamsExtensionUserIdentifier("207ffef6-9444-41fb-92ab-20eacaae2768", "45ab2481-1c1c-4005-be24-0ffb879b1130", "bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd").Cloud, Is.EqualTo(CommunicationCloudEnvironment.Public));
            });
        }

        [Test]
        public void PhoneNumberIdentifier_ComputedProperties()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new PhoneNumberIdentifier("14255550123").IsAnonymous, Is.EqualTo(false));
                Assert.That(new PhoneNumberIdentifier("anonymous").IsAnonymous, Is.EqualTo(true));
                Assert.That(new PhoneNumberIdentifier("override", "4:anonymous").IsAnonymous, Is.EqualTo(true));
                Assert.That(new PhoneNumberIdentifier("override", "4:anonymous123").IsAnonymous, Is.EqualTo(false));
                Assert.That(new PhoneNumberIdentifier("override", "4:_anonymous").IsAnonymous, Is.EqualTo(false));

                Assert.That(new PhoneNumberIdentifier("14255550121").AssertedId, Is.EqualTo(null));
                Assert.That(new PhoneNumberIdentifier("14255550121.123").AssertedId, Is.EqualTo(null));
                Assert.That(new PhoneNumberIdentifier("14255550121-123").AssertedId, Is.EqualTo(null));
                Assert.That(new PhoneNumberIdentifier("14255550121_123").AssertedId, Is.EqualTo("123"));
                Assert.That(new PhoneNumberIdentifier("14255550121", "4:14255550121_123").AssertedId, Is.EqualTo("123"));
                Assert.That(new PhoneNumberIdentifier("14255550121_123_456").AssertedId, Is.EqualTo("456"));
                Assert.That(new PhoneNumberIdentifier("14255550121", "4:14255550121_123_456").AssertedId, Is.EqualTo("456"));
            });

            var staticPhoneNumberIdentifier = new PhoneNumberIdentifier("14255550121_123");
            Assert.That(staticPhoneNumberIdentifier.AssertedId, Is.EqualTo("123")); // first use: compute assertedId
            Assert.That(staticPhoneNumberIdentifier.AssertedId, Is.EqualTo("123")); // second use: reuse previously computed assertedId
        }

        [Test]
        public void GetRawIdOfIdentifier()
        {
            static void AssertRawId(CommunicationIdentifier identifier, string expectedRawId) => Assert.That(identifier.RawId, Is.EqualTo(expectedRawId));

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
                Assert.That(CommunicationIdentifier.FromRawId(rawId), Is.EqualTo(expectedIdentifier));
                Assert.Multiple(() =>
                {
                    Assert.That(CommunicationIdentifier.FromRawId(rawId).GetHashCode(), Is.EqualTo(expectedIdentifier.GetHashCode()));
                    Assert.That(CommunicationIdentifier.FromRawId(rawId) == expectedIdentifier, Is.True);
                    Assert.That(CommunicationIdentifier.FromRawId(rawId) != expectedIdentifier, Is.False);
                });
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

            Assert.Throws<ArgumentNullException>(() => CommunicationIdentifier.FromRawId(null));
        }

        [Test]
        public void RawIdStaysTheSameAfterConversionToIdentifierAndBack()
        {
            static void AssertRoundtrip(string rawId) => Assert.That(CommunicationIdentifier.FromRawId(rawId).RawId, Is.EqualTo(rawId));

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
                Assert.That(implementation.GetProperty(nameof(CommunicationIdentifier.RawId))?.DeclaringType, Is.Not.EqualTo(baseType));
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

            Assert.That(hashSet, Has.Member(CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(hashSet, Has.Member(CommunicationIdentifier.FromRawId("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(hashSet, Has.Member(CommunicationIdentifier.FromRawId("4:+14255550123")));
            Assert.That(hashSet, Has.Member(CommunicationIdentifier.FromRawId("28:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(hashSet, Has.Member(CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768")));
            Assert.That(hashSet, Has.Member(CommunicationIdentifier.FromRawId("48:45ab2481-1c1c-4005-be24-0ffb879b1130")));

            Assert.That(list, Has.Member(CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(list, Has.Member(CommunicationIdentifier.FromRawId("8:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(list, Has.Member(CommunicationIdentifier.FromRawId("4:+14255550123")));
            Assert.That(list, Has.Member(CommunicationIdentifier.FromRawId("28:orgid:45ab2481-1c1c-4005-be24-0ffb879b1130")));
            Assert.That(list, Has.Member(CommunicationIdentifier.FromRawId("8:acs:bbbcbc1e-9f06-482a-b5d8-20e3f26ef0cd_45ab2481-1c1c-4005-be24-0ffb879b1130_207ffef6-9444-41fb-92ab-20eacaae2768")));
            Assert.That(list, Has.Member(CommunicationIdentifier.FromRawId("48:45ab2481-1c1c-4005-be24-0ffb879b1130")));
        }

        [Test]
        public void EqualityOperatorOverrideDoesntThrow()
        {
            var identifier = new CommunicationUserIdentifier("123");
            var sameIdentifier = new CommunicationUserIdentifier("123");
            var otherIdentifier = new CommunicationUserIdentifier("124");
            var otherTypeIdentifier = new MicrosoftTeamsUserIdentifier("123");
            CommunicationIdentifier? nullIdentifier = null;

            Assert.That(identifier == null, Is.False);
            Assert.That(null == identifier, Is.False);
            Assert.That(identifier != null, Is.True);
            Assert.That(null != identifier, Is.True);

            Assert.Multiple(() =>
            {
                Assert.That(null as CommunicationIdentifier == null as CommunicationIdentifier, Is.True);
                Assert.That(identifier, Is.Not.EqualTo(null as CommunicationIdentifier));
                Assert.That(null as CommunicationIdentifier, Is.Not.EqualTo(identifier));
            });
            Assert.That(identifier, Is.Not.EqualTo(null as CommunicationIdentifier));
            Assert.That(null as CommunicationIdentifier, Is.Not.EqualTo(identifier));

            Assert.That(null == nullIdentifier, Is.True);
            Assert.That(nullIdentifier, Is.Not.EqualTo(identifier));

#pragma warning disable CS1718 // Comparison made to same variable
            Assert.That(identifier == identifier, Is.True);
#pragma warning restore CS1718 // Comparison made to same variable
            Assert.That(identifier == sameIdentifier, Is.True);
            Assert.That(identifier != sameIdentifier, Is.False);
            Assert.That(sameIdentifier == identifier, Is.True);
            Assert.That(sameIdentifier != identifier, Is.False);
            Assert.That(identifier, Is.Not.EqualTo(otherIdentifier));
            Assert.That(identifier, Is.Not.EqualTo(otherIdentifier));
            Assert.That(identifier, Is.Not.EqualTo(otherTypeIdentifier));
            Assert.That(identifier, Is.Not.EqualTo(otherTypeIdentifier));
        }
    }
}
