// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Attestation.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xunit;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Attestation.Tests.BasicTests
{
    public class AttestationOperationsTests : IClassFixture<AttestationTestFixture> 
    {
        private AttestationTestFixture fixture;
        private const string tenantBaseUrl = "https://tradewinds4.us.attest.azure.net";
        private const string tenantBaseUrlWithTrustedSigners = "https://tradewinds3.us.attest.azure.net";

        // Get-AzAttestation -Name tradewinds3 -ResourceGroupName sdk-test-do-not-delete
        //
        //    Id         : subscriptions/a724c543-53ce-44a6-b633-e11ef27839b7/resourceGroups/sdk-test-do-not-delete/providers/Microsoft.Attestation/attestationProviders/tradewinds3
        //    Location   : East US
        //    Name       : tradewinds3
        //    Status     : Ready
        //    TrustModel : Isolated
        //    AttestUri  : https://tradewinds3.us.attest.azure.net
        //    Tags       : {Test}
        //    TagsTable  :
        //                 Name Value
        //                 ====  =====
        //                 Test yes
        //
        // Get-AzAttestation -Name tradewinds4 -ResourceGroupName sdk-test-do-not-delete
        //
        //    Id         : subscriptions/a724c543-53ce-44a6-b633-e11ef27839b7/resourceGroups/sdk-test-do-not-delete/providers/Microsoft.Attestation/attestationProviders/tradewinds4
        //    Location   : East US
        //    Name       : tradewinds4
        //    Status     : Ready
        //    TrustModel : AAD
        //    AttestUri  : https://tradewinds4.us.attest.azure.net
        //    TagsTable  :
        //                 Name Value
        //                 ====  =====
        //                 Test yes
        //

        public AttestationOperationsTests(AttestationTestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void UpdatePolicyCertificates()
        {
            string newCertText = File.ReadAllText(@"./DataFiles/cert2.signed.add.txt");

            using (MockContext ctx = MockContext.Start(this.GetType()))
            {
                var attestationClient = GetAttestationClient();

                // Test Get (tenantBaseUrl should have no trusted policy signers)
                var serviceCallResult = attestationClient.PolicyCertificates.GetWithHttpMessagesAsync(tenantBaseUrl);
                Assert.Equal(HttpStatusCode.OK, serviceCallResult.Result.Response.StatusCode);

                var jsonBody = ExtractJoseBody(serviceCallResult);
                Assert.Equal(JTokenType.Array, jsonBody["aas-policyCertificates"]["keys"].Type);
                Assert.Empty(jsonBody["aas-policyCertificates"]["keys"].ToArray());

                // Test Get (tenantBaseUrlWithTrustedSigners should have one trusted policy signers)
                serviceCallResult = attestationClient.PolicyCertificates.GetWithHttpMessagesAsync(tenantBaseUrlWithTrustedSigners);
                Assert.Equal(HttpStatusCode.OK, serviceCallResult.Result.Response.StatusCode);
                Assert.NotNull(serviceCallResult.Result.Body as string);
                Assert.True((serviceCallResult.Result.Body as string).Length > 0);

                jsonBody = ExtractJoseBody(serviceCallResult);
                Assert.Equal(JTokenType.Array, jsonBody["aas-policyCertificates"]["keys"].Type);
                Assert.Single(jsonBody["aas-policyCertificates"]["keys"].ToArray());

                var certificateText = (string) jsonBody["aas-policyCertificates"]["keys"][0]["x5c"][0];
                X509Certificate2 certificateObject = new X509Certificate2(Convert.FromBase64String(certificateText));
                Assert.NotNull(certificateObject.SubjectName);
                Assert.Equal("CN=MaaTestCert1", certificateObject.SubjectName.Name);

                // Test Add
                serviceCallResult = attestationClient.PolicyCertificates.AddWithHttpMessagesAsync(tenantBaseUrlWithTrustedSigners, newCertText);
                Assert.Equal(HttpStatusCode.OK, serviceCallResult.Result.Response.StatusCode);
                Assert.NotNull(serviceCallResult.Result.Body as string);
                Assert.True((serviceCallResult.Result.Body as string).Length > 0);

                jsonBody = ExtractJoseBody(serviceCallResult);
                Assert.Equal(JTokenType.Array, jsonBody["aas-policyCertificates"]["keys"].Type);
                Assert.Equal(2, jsonBody["aas-policyCertificates"]["keys"].ToArray().Length);

                string expectedSubjectName = "MaaTestCert2";
                bool expectedSubjectNameFound = false;
                foreach (var trustedSigningKey in jsonBody["aas-policyCertificates"]["keys"].ToArray())
                {
                    foreach (var certificate in trustedSigningKey["x5c"])
                    {
                        certificateObject = new X509Certificate2(Convert.FromBase64String((string)certificate));
                        if (certificateObject.SubjectName.Name.Contains(expectedSubjectName))
                        {
                            expectedSubjectNameFound = true;
                            break;
                        }
                    }

                    if (expectedSubjectNameFound)
                        break;
                }
                Assert.True(expectedSubjectNameFound);

                // Test Remove
                serviceCallResult = attestationClient.PolicyCertificates.RemoveWithHttpMessagesAsync(tenantBaseUrlWithTrustedSigners, newCertText);
                Assert.Equal(HttpStatusCode.OK, serviceCallResult.Result.Response.StatusCode);
                Assert.NotNull(serviceCallResult.Result.Body as string);
                Assert.True((serviceCallResult.Result.Body as string).Length > 0);

                jsonBody = ExtractJoseBody(serviceCallResult);
                Assert.Equal(JTokenType.Array, jsonBody["aas-policyCertificates"]["keys"].Type);
                Assert.Single(jsonBody["aas-policyCertificates"]["keys"].ToArray());

                certificateText = (string)jsonBody["aas-policyCertificates"]["keys"][0]["x5c"][0];
                certificateObject = new X509Certificate2(Convert.FromBase64String(certificateText));
                Assert.NotNull(certificateObject.SubjectName);
                Assert.Equal("CN=MaaTestCert1", certificateObject.SubjectName.Name);
            }
        }

        private static JObject ExtractJoseBody(Task<AzureOperationResponse<object>> serviceCallResult)
        {
            string[] joseParts = (serviceCallResult.Result.Body as string).Split('.');
            var decodedBody = Base64UrlEncoder.Decode(joseParts[1]);
            JObject jsonBody = JObject.Parse(decodedBody);
            return jsonBody;
        }

        [Fact]
        public void UpdatePolicy()
        {
            using (MockContext ctx = MockContext.Start(this.GetType()))
            {
                var attestationClient = GetAttestationClient();

                string policyJws =
                    "eyJhbGciOiJub25lIn0.eyJBdHRlc3RhdGlvblBvbGljeSI6ICJ7XHJcbiAgICBcIiR2ZXJzaW9uXCI6IDEsXHJcbiAgICBcIiRhbGxvdy1kZWJ1Z2dhYmxlXCIgOiB0cnVlLFxyXG4gICAgXCIkY2xhaW1zXCI6W1xyXG4gICAgICAgIFwiaXMtZGVidWdnYWJsZVwiICxcclxuICAgICAgICBcInNneC1tcnNpZ25lclwiLFxyXG4gICAgICAgIFwic2d4LW1yZW5jbGF2ZVwiLFxyXG4gICAgICAgIFwicHJvZHVjdC1pZFwiLFxyXG4gICAgICAgIFwic3ZuXCIsXHJcbiAgICAgICAgXCJ0ZWVcIixcclxuICAgICAgICBcIk5vdERlYnVnZ2FibGVcIlxyXG4gICAgXSxcclxuICAgIFwiTm90RGVidWdnYWJsZVwiOiB7XCJ5ZXNcIjp7XCIkaXMtZGVidWdnYWJsZVwiOnRydWUsIFwiJG1hbmRhdG9yeVwiOnRydWUsIFwiJHZpc2libGVcIjpmYWxzZX19LFxyXG4gICAgXCJpcy1kZWJ1Z2dhYmxlXCIgOiBcIiRpcy1kZWJ1Z2dhYmxlXCIsXHJcbiAgICBcInNneC1tcnNpZ25lclwiIDogXCIkc2d4LW1yc2lnbmVyXCIsXHJcbiAgICBcInNneC1tcmVuY2xhdmVcIiA6IFwiJHNneC1tcmVuY2xhdmVcIixcclxuICAgIFwicHJvZHVjdC1pZFwiIDogXCIkcHJvZHVjdC1pZFwiLFxyXG4gICAgXCJzdm5cIiA6IFwiJHN2blwiLFxyXG4gICAgXCJ0ZWVcIiA6IFwiJHRlZVwiXHJcbn0ifQ.";
                
                // preprepare to set policy
                var getResult = attestationClient.Policy.PrepareToSetWithHttpMessagesAsync(tenantBaseUrl, "SgxEnclave",
                    policyJws).Result;
                Assert.Equal(HttpStatusCode.OK, getResult.Response.StatusCode);
                string newAttestationPolicy = getResult.Body.ToString();

                // set policy
                var setResult = attestationClient.Policy.SetWithHttpMessagesAsync(tenantBaseUrl, "SgxEnclave", newAttestationPolicy).Result;
                Assert.Equal(HttpStatusCode.OK, setResult.Response.StatusCode);

                // get policy
                var getPolicyResult = attestationClient.Policy.GetWithHttpMessagesAsync(tenantBaseUrl, "SgxEnclave").Result;
                Assert.Equal(HttpStatusCode.OK, getPolicyResult.Response.StatusCode);
                var returnedPolicy = getPolicyResult.Body;
                Assert.True(returnedPolicy is AttestationPolicy);
                Assert.Equal(policyJws, ((AttestationPolicy)returnedPolicy).Policy);

                // reset policy 
                var resetResult = attestationClient.Policy.ResetWithHttpMessagesAsync(tenantBaseUrl, "SgxEnclave", "eyJhbGciOiJub25lIn0..").Result;
                Assert.Equal(HttpStatusCode.OK, resetResult.Response.StatusCode);
            }
        }

        [Fact]
        public void RetrieveMetadataConfiguration()
        {
            using (MockContext ctx = MockContext.Start(this.GetType()))
            {
                var attestationClient = GetAttestationClient();
                var response = attestationClient.MetadataConfiguration.Get(tenantBaseUrl);
                var json = JsonConvert.DeserializeObject(response.ToString()) as JObject;
                Assert.NotNull(json);

                Assert.Equal(JTokenType.Array,json["response_types_supported"].Type);
                Assert.Equal(2,json["response_types_supported"].ToArray().Length);
                Assert.Equal(JTokenType.String,json["response_types_supported"][0].Type);
                Assert.Equal("token",json["response_types_supported"][0]);
                Assert.Equal(JTokenType.String,json["response_types_supported"][1].Type);
                Assert.Equal("none",json["response_types_supported"][1]);

                Assert.Equal(JTokenType.Array,json["id_token_signing_alg_values_supported"].Type);
                Assert.Single(json["id_token_signing_alg_values_supported"].ToArray());
                Assert.Equal(JTokenType.String,json["id_token_signing_alg_values_supported"][0].Type);
                Assert.Equal("RS256",json["id_token_signing_alg_values_supported"][0]);

                // Verify the revocation endpoint value.
                Assert.Equal(JTokenType.String,json["revocation_endpoint"].Type);
                Assert.Equal(json["revocation_endpoint"].ToString(), tenantBaseUrl + "/revoke");

                // Verify the jwks_uri value.
                Assert.Equal(JTokenType.String,json["jwks_uri"].Type);
                Assert.Equal(json["jwks_uri"].ToString(), tenantBaseUrl + "/certs");

                // Verify the claims_supported array.
                Assert.Equal(JTokenType.Array,json["claims_supported"].Type);
                Assert.Equal(9,json["claims_supported"].ToArray().Length);
                Assert.Equal(JTokenType.String,json["claims_supported"][0].Type);
                Assert.Equal("is-debuggable",json["claims_supported"][0]);
                Assert.Equal(JTokenType.String,json["claims_supported"][1].Type);
                Assert.Equal("sgx-mrsigner",json["claims_supported"][1]);
                Assert.Equal(JTokenType.String, json["claims_supported"][2].Type);
                Assert.Equal("sgx-mrenclave",json["claims_supported"][2]);
                Assert.Equal(JTokenType.String,json["claims_supported"][3].Type);
                Assert.Equal("product-id",json["claims_supported"][3]);
                Assert.Equal(JTokenType.String,json["claims_supported"][4].Type);
                Assert.Equal("svn",json["claims_supported"][4]);
                Assert.Equal(JTokenType.String,json["claims_supported"][5].Type);
                Assert.Equal("tee",json["claims_supported"][5]);
                Assert.Equal(JTokenType.String,json["claims_supported"][6].Type);
                Assert.Equal("device_id",json["claims_supported"][6]);
                Assert.Equal(JTokenType.String,json["claims_supported"][7].Type);
                Assert.Equal("component_0_id",json["claims_supported"][7]);
                Assert.Equal(JTokenType.String,json["claims_supported"][8].Type);
                Assert.Equal("expected_components",json["claims_supported"][8]);
            }
        }

        [Fact]
        public void RetrieveMetadataSigningKeys()
        {
            using (MockContext ctx = MockContext.Start(this.GetType()))
            {
                var attestationClient = GetAttestationClient();
                var response = attestationClient.SigningCertificates.Get(tenantBaseUrl);

                var json = JsonConvert.DeserializeObject(response.ToString()) as JObject;
                Assert.NotNull(json);

                var jwks = new JsonWebKeySet(response.ToString());
                var signingKeys = jwks.GetSigningKeys();
                foreach (var key in signingKeys)
                {
                    Assert.True(key is X509SecurityKey);
                    var x509Key = key as X509SecurityKey;
                }

            }

        }

        private AttestationClient GetAttestationClient()
        {
            return fixture.CreateAttestationClient();
        }
    }
}
