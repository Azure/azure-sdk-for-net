// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using Azure.Core.TestFramework;
using System.Diagnostics.Tracing;

namespace Azure.Identity.Tests
{
    public class TokenHelperTests
    {
        private static string tenantId = Guid.NewGuid().ToString();
        private static string objectId = Guid.NewGuid().ToString();
        private static string clientId = Guid.NewGuid().ToString();
        private static string myUpn = "some.name@contoso.com";
        private string _encodedToken;

        [SetUp]
        public void Setup()
        {
            _encodedToken = TokenGenerator.GenerateToken(tenantId, clientId, objectId, myUpn, DateTime.Now.AddHours(1));
        }

        [Test]
        public void ParseAccountInfoFromToken_ParsesNormalToken()
        {
            var result = TokenHelper.ParseAccountInfoFromToken(_encodedToken);

            Assert.AreEqual(clientId, result.ClientId);
            Assert.AreEqual(tenantId, result.TenantId);
            Assert.AreEqual(myUpn, result.Upn);
            Assert.AreEqual(objectId, result.ObjectId);
        }

        [Test]
        public void ParseAccountInfoFromToken_ThrowsOnInvalidToken()
        {
            using var _listener = new TestEventListener();
            _listener.EnableEvents(AzureIdentityEventSource.Singleton, EventLevel.Verbose);

            var loggedEvents = _listener.EventsById(AzureIdentityEventSource.UnableToParseAccountDetailsFromTokenEvent);
            TokenHelper.ParseAccountInfoFromToken("header.token.signature");

            CollectionAssert.IsNotEmpty(loggedEvents);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("notEnough.Parts")]
        public void ParseAccountInfoFromToken_ValidatesArgs(string token)
        {
            Assert.Catch<ArgumentException>(() => TokenHelper.ParseAccountInfoFromToken(token));
        }
    }
}
