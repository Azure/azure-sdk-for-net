using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data;
using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Framework
{
    /// <summary>
    /// Tests for AuthenticationEventData
    /// </summary>
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
                dataObj["tenantId"] = hasTenantIdValue ? TenantId : "";
            }
            if (hasAuthenticationEventListenerIdKey)
            {
                dataObj["authenticationEventListenerId"] = hasAuthenticationEventListenerIdValue ? AuthenticationEventListenerId : "";
            }
            if (hasCustomAuthenticationExtensionIdKey)
            {
                dataObj["customAuthenticationExtensionId"] = hasCustomAuthenticationExtensionIdValue ? CustomAuthenticationExtensionId : "";
            }

            return obj.ToString();
        }

        [Fact]
        public void TestCreate()
        {
            Assert.Throws<ArgumentNullException>(() => AuthenticationEventData.CreateInstance(null, null));

            Type type = typeof(TokenIssuanceStartData);
            AuthenticationEventData data = AuthenticationEventData.CreateInstance(type, new AuthenticationEventJsonElement(BuildDataString()));
            Assert.Equal(TenantId, data.TenantId.ToString());
            Assert.Equal(AuthenticationEventListenerId, data.AuthenticationEventListenerId.ToString());
            Assert.Equal(CustomAuthenticationExtensionId, data.CustomAuthenticationExtensionId.ToString());

            var ex = Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(
                () => Helpers.ValidateGraph(
                    AuthenticationEventData.CreateInstance(
                        type: type,
                        json: new AuthenticationEventJsonElement(BuildDataString(hasTenantIdKey: false)))));

            Assert.Contains("tenantid", ex.Message, StringComparison.InvariantCultureIgnoreCase);

            ex = Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(
                () => Helpers.ValidateGraph(
                    AuthenticationEventData.CreateInstance(
                        type: type,
                        json: new AuthenticationEventJsonElement(BuildDataString(hasAuthenticationEventListenerIdKey: false)))));

            Assert.Contains("authenticationEventListenerId", ex.Message, StringComparison.InvariantCultureIgnoreCase);

            ex = Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(
                () => Helpers.ValidateGraph(
                    AuthenticationEventData.CreateInstance(
                        type: type,
                        json: new AuthenticationEventJsonElement(BuildDataString(hasCustomAuthenticationExtensionIdKey: false)))));

            Assert.Contains("customAuthenticationExtensionId", ex.Message, StringComparison.InvariantCultureIgnoreCase);


        }
    }
}
