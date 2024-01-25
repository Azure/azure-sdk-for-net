// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.using System;

using System;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Framework
{
    [TestFixture]
    public class AuthenticationEventDataTests
    {
        public static string TenantId = "00000000-0000-0000-0000-000000000001";
        public static string AuthenticationEventListenerId = "00000000-0000-0000-0000-000000000002";
        public static string CustomAuthenticationExtensionId = "00000000-0000-0000-0000-000000000003";

        public static string BuildDataString(
            bool hasTenantIdKey = true,
            bool hasTenantIdValue = true,
            bool hasAuthenticationEventListenerIdKey = true,
            bool hasAuthenticationEventListenerIdValue = true,
            bool hasCustomAuthenticationExtensionIdKey = true,
            bool hasCustomAuthenticationExtensionIdValue = true)
        {
            JObject obj = new();

            JObject context = new();
            context["protocol"] = "SAML";

            JObject dataObj = new();
            obj["data"] = dataObj;
            dataObj["authenticationContext"] = context;
            dataObj["@odata.type"] = "microsoft.graph.onTokenIssuanceStartCalloutData";

            if (hasTenantIdKey)
            {
                dataObj["tenantId"] = hasTenantIdValue ? TenantId : string.Empty;
            }
            if (hasAuthenticationEventListenerIdKey)
            {
                dataObj["authenticationEventListenerId"] = hasAuthenticationEventListenerIdValue ? AuthenticationEventListenerId : string.Empty;
            }
            if (hasCustomAuthenticationExtensionIdKey)
            {
                dataObj["customAuthenticationExtensionId"] = hasCustomAuthenticationExtensionIdValue ? CustomAuthenticationExtensionId : string.Empty;
            }

            return obj.ToString();
        }

        [Test]
        public void TestCreate()
        {
            Assert.Throws<ArgumentNullException>(() => AuthenticationEventData.CreateInstance(null, null));

            Type type = typeof(TokenIssuanceStartData);
            AuthenticationEventData data = AuthenticationEventData.CreateInstance(type, new AuthenticationEventJsonElement(BuildDataString()));
            Assert.AreEqual(TenantId, data.TenantId.ToString());
            Assert.AreEqual(AuthenticationEventListenerId, data.AuthenticationEventListenerId.ToString());
            Assert.AreEqual(CustomAuthenticationExtensionId, data.CustomAuthenticationExtensionId.ToString());

            var ex = Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(
                () => Helpers.ValidateGraph(
                    AuthenticationEventData.CreateInstance(
                        type: type,
                        json: new AuthenticationEventJsonElement(BuildDataString(hasTenantIdKey: false)))));

            Assert.IsTrue(ex.Message.Contains("tenantid", StringComparison.InvariantCultureIgnoreCase));

            ex = Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(
                () => Helpers.ValidateGraph(
                    AuthenticationEventData.CreateInstance(
                        type: type,
                        json: new AuthenticationEventJsonElement(BuildDataString(hasAuthenticationEventListenerIdKey: false)))));

            Assert.IsTrue(ex.Message.Contains("authenticationEventListenerId", StringComparison.InvariantCultureIgnoreCase));

            ex = Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(
                () => Helpers.ValidateGraph(
                    AuthenticationEventData.CreateInstance(
                        type: type,
                        json: new AuthenticationEventJsonElement(BuildDataString(hasCustomAuthenticationExtensionIdKey: false)))));

            Assert.IsTrue(ex.Message.Contains("customAuthenticationExtensionId", StringComparison.InvariantCultureIgnoreCase));


        }
    }
}
