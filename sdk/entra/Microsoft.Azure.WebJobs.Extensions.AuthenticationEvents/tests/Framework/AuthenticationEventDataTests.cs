using System;
using Xunit;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data;

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
            string jsonString = "{\"data\":" + "{\"@odata.type\":\"microsoft.graph.onTokenIssuanceStartCalloutData\"";
            if (hasTenantIdKey)
            {
                jsonString += ",";
                jsonString += "\"tenantId\":" + "\"" + (hasTenantIdValue ? TenantId : "") + "\"";
            }
            if (hasAuthenticationEventListenerIdKey)
            {
                jsonString += ",";
                jsonString += "\"authenticationEventListenerId\":" + "\"" + (hasAuthenticationEventListenerIdValue ? AuthenticationEventListenerId : "") + "\"";
            }
            if (hasCustomAuthenticationExtensionIdKey)
            {
                jsonString += ",";
                jsonString += "\"customAuthenticationExtensionId\":" + "\"" + (hasCustomAuthenticationExtensionIdValue ? CustomAuthenticationExtensionId : "") + "\"";
            }
            jsonString += "}}";

            return jsonString;
        }

        [Fact]
        public void TestCreate()
        {
            Assert.Throws<ArgumentNullException>(()=> AuthenticationEventData.CreateInstance(null, null));

            Type type = typeof(TokenIssuanceStartData);
            AuthenticationEventData data = AuthenticationEventData.CreateInstance(type, new AuthenticationEventJsonElement(BuildDataString()));
            Assert.Equal(TenantId, data.TenantId.ToString());
            Assert.Equal(AuthenticationEventListenerId, data.AuthenticationEventListenerId.ToString());
            Assert.Equal(CustomAuthenticationExtensionId, data.CustomAuthenticationExtensionId.ToString());

            Assert.Throws<System.Text.Json.JsonException>(()=> AuthenticationEventData.CreateInstance(type, new AuthenticationEventJsonElement(BuildDataString(hasTenantIdKey: false))));
            Assert.Throws<System.Text.Json.JsonException>(()=> AuthenticationEventData.CreateInstance(type, new AuthenticationEventJsonElement(BuildDataString(hasAuthenticationEventListenerIdKey: false))));
            Assert.Throws<System.Text.Json.JsonException>(()=> AuthenticationEventData.CreateInstance(type, new AuthenticationEventJsonElement(BuildDataString(hasCustomAuthenticationExtensionIdKey: false))));
        }
    }
}
