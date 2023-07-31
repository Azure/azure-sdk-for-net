// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Framework
{
	[TestFixture]
	public class AuthenticationEventMetadataTests
	{
		[Test]
		[TestCaseSource(nameof(TestScenarios))]
		public void TestRequestCreateInstance(object testObject, string message, bool success)
		{
			string payload = testObject.ToString();
			AuthenticationEventMetadata eventMetadata = AuthenticationEventMetadataLoader.GetEventMetadata(payload);
			HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:7278/runtime/webhooks/customauthenticationextension?code=opVsbQul8-MsRuM9x6yVoghE2Xda5G-MeV_Ybv1MdEfuAzFuVtpEpg==&functionName=onTokenIssuanceStart");

			if (success == false)
			{
				var ex = Assert.Throws<ValidationException>(() => eventMetadata.CreateEventRequestValidate(requestMessage, payload, string.Empty));
				Assert.AreEqual("TokenIssuanceStartRequest: The Source field is required.", ex.Message); 
			}
			else
			{
				Assert.DoesNotThrow(() => eventMetadata.CreateEventRequestValidate(requestMessage, payload, string.Empty));
			}
		}

		private static IEnumerable<object[]> TestScenarios()
		{
#region Invalid
			yield return new TestCaseStructure()
			{
				Test = $"{{\r\n    \"type\": \"microsoft.graph.authenticationEvent.tokenIssuanceStart\",\r\n    \"data\": {{\r\n        \"@odata.type\": \"microsoft.graph.onTokenIssuanceStartCalloutData\",\r\n        \"tenantId\": \"d33b1c3f-49c2-8cb3-963b-ca195de1e704\",\r\n        \"authenticationEventListenerId\": \"6fd9cb25-ff72-304b-7b27-5fd793aa3c2f\",\r\n        \"customAuthenticationExtensionId\": \"ce1b2217-fdf9-a19f-2f46-a639514a4107\",\r\n        \"authenticationContext\": {{\r\n            \"correlationId\": \"1dc14bea-414b-a99e-64de-b4702d82ab59\",\r\n            \"client\": {{\r\n                \"ip\": \"30.51.176.110\",\r\n                \"locale\": \"en-us\",\r\n                \"market\": \"en-us\"\r\n            }},\r\n            \"protocol\": \"OAUTH2.0\",\r\n            \"clientServicePrincipal\": {{\r\n                \"id\": \"1dc14bea-414b-a99e-64de-b4702d82ab59\",\r\n                \"appId\": \"d56ef0c3-a4e8-b26c-484c-8873b560eab3\",\r\n                \"appDisplayName\": \"My Test application\",\r\n                \"displayName\": \"My Test application\"\r\n            }},\r\n            \"resourceServicePrincipal\": {{\r\n                \"id\": \"8de396f3-6559-a65c-398e-43a2fc6a2141\",\r\n                \"appId\": \"d56ef0c3-a4e8-b26c-484c-8873b560eab3\",\r\n                \"appDisplayName\": \"My Test application\",\r\n                \"displayName\": \"My Test application\"\r\n            }},\r\n            \"user\": {{\r\n                \"createdDateTime\": \"2016-03-01T15:23:40Z\",\r\n                \"displayName\": \"Bob\",\r\n                \"givenName\": \"Bob Smith\",\r\n                \"id\": \"90847c2a-e29d-4d2f-9f54-c5b4d3f26471\",\r\n                \"mail\": \"bob@contoso.com\",\r\n                \"preferredLanguage\": \"en-us\",\r\n                \"surname\": \"Smith\",\r\n                \"userPrincipalName\": \"bob@contoso.com\",\r\n                \"userType\": \"Member\"\r\n            }}\r\n        }}\r\n    }}\r\n}}\r\n   ",
				Message = "Testing request payload without source field passed",
			}.ToArray;
#endregion

#region Valid
			yield return new TestCaseStructure()
			{
				Test = $"{{\r\n    \"type\": \"microsoft.graph.authenticationEvent.tokenIssuanceStart\",\r\n    \"source\": \"/tenants/d33b1c3f-49c2-8cb3-963b-ca195de1e704/applications/d56ef0c3-a4e8-b26c-484c-8873b560eab3\",\r\n    \"data\": {{\r\n        \"@odata.type\": \"microsoft.graph.onTokenIssuanceStartCalloutData\",\r\n        \"tenantId\": \"d33b1c3f-49c2-8cb3-963b-ca195de1e704\",\r\n        \"authenticationEventListenerId\": \"6fd9cb25-ff72-304b-7b27-5fd793aa3c2f\",\r\n        \"customAuthenticationExtensionId\": \"ce1b2217-fdf9-a19f-2f46-a639514a4107\",\r\n        \"authenticationContext\": {{\r\n            \"correlationId\": \"1dc14bea-414b-a99e-64de-b4702d82ab59\",\r\n            \"client\": {{\r\n                \"ip\": \"30.51.176.110\",\r\n                \"locale\": \"en-us\",\r\n                \"market\": \"en-us\"\r\n            }},\r\n            \"protocol\": \"OAUTH2.0\",\r\n            \"clientServicePrincipal\": {{\r\n                \"id\": \"1dc14bea-414b-a99e-64de-b4702d82ab59\",\r\n                \"appId\": \"d56ef0c3-a4e8-b26c-484c-8873b560eab3\",\r\n                \"appDisplayName\": \"My Test application\",\r\n                \"displayName\": \"My Test application\"\r\n            }},\r\n            \"resourceServicePrincipal\": {{\r\n                \"id\": \"8de396f3-6559-a65c-398e-43a2fc6a2141\",\r\n                \"appId\": \"d56ef0c3-a4e8-b26c-484c-8873b560eab3\",\r\n                \"appDisplayName\": \"My Test application\",\r\n                \"displayName\": \"My Test application\"\r\n            }},\r\n            \"user\": {{\r\n                \"createdDateTime\": \"2016-03-01T15:23:40Z\",\r\n                \"displayName\": \"Bob\",\r\n                \"givenName\": \"Bob Smith\",\r\n                \"id\": \"90847c2a-e29d-4d2f-9f54-c5b4d3f26471\",\r\n                \"mail\": \"bob@contoso.com\",\r\n                \"preferredLanguage\": \"en-us\",\r\n                \"surname\": \"Smith\",\r\n                \"userPrincipalName\": \"bob@contoso.com\",\r\n                \"userType\": \"Member\"\r\n            }}\r\n        }}\r\n    }}\r\n}}\r\n   ",
				Message = "Testing valid full request payload",
				Success = true,
			}.ToArray;
#endregion
		}
	}
}
