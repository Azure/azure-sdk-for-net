// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.Attestation.Models;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests.Samples
{
    public class AttestationServiceAttestationSamples : SamplesBase<AttestationClientTestEnvironment>
    {
        private readonly string _openEnclaveReport = "AQAAAAIAAADkEQAAAAAAAAMAAg" +
            "AAAAAABQAKAJOacjP3nEyplAoNs5V_Bgc42MPzGo7hPWS_h-3tExJrAAAAABERAwX_g" +
            "AYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUAAAAAAAAA" +
            "BwAAAAAAAAC3eSAmGL7LY2do5dkC8o1SQiJzX6-1OeqboHw_wXGhwgAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAALBpElSroIHE1xsKbdbjAKTcu6UtnfhXCC9QjQP" +
            "ENQaoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB" +
            "AAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAA7RGp65ffwXBToyppkucdBPfsmW5FUZq3EJNq-0j5BB0AAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADAQAAB4iv_XjOJsrFMrPvIYOBCeMR2q6" +
            "xB08KluTNAtIgpZQUIzLNyy78Gmb5LE77UIVye2sao77dOGiz3wP2f5jhEE5iovgPhy" +
            "6-Qg8JQkqe8XJI6B5ZlWsfq3E7u9EvH7ZZ33MihT7aM-sXca4u92L8OIhpM2cfJguOS" +
            "AS3Q4pR4NdRERAwX_gAYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAABUAAAAAAAAABwAAAAAAAAA_sKzghp0uMPKOhtcMdmQDpU-7zWWO7ODhuUipF" +
            "VkXQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAjE9XddeWUD6WE393xoqC" +
            "mgBWrI3tcBQLCBsJRJDFe_8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAABAAUAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD9rOmAu-jSSf1BAj_cC0mu7YCnx4QosD" +
            "78yj3sQX81IAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH5Au8JZ_dpXiLY" +
            "aE1TtyGjGz0dtFZa7eGooRGTQzoJJuR8Xj-zUvyCKE4ABy0pajfE8lOGSUHuJoifisJ" +
            "NAhg4gAAABAgMEBQYHCAkKCwwNDg8QERITFBUWFxgZGhscHR4fBQDIDQAALS0tLS1CR" +
            "UdJTiBDRVJUSUZJQ0FURS0tLS0tCk1JSUVmekNDQkNhZ0F3SUJBZ0lVRk5xSnZZZTU4" +
            "ZXlpUjI2Yzd0L2lxU0pNYnFNd0NnWUlLb1pJemowRUF3SXcKY1RFak1DRUdBMVVFQXd" +
            "3YVNXNTBaV3dnVTBkWUlGQkRTeUJRY205alpYTnpiM0lnUTBFeEdqQVlCZ05WQkFvTQ" +
            "pFVWx1ZEdWc0lFTnZjbkJ2Y21GMGFXOXVNUlF3RWdZRFZRUUhEQXRUWVc1MFlTQkRiR" +
            "0Z5WVRFTE1Ba0dBMVVFCkNBd0NRMEV4Q3pBSkJnTlZCQVlUQWxWVE1CNFhEVEl4TURR" +
            "eU1USXdOVGt6T0ZvWERUSTRNRFF5TVRJd05Ua3oKT0Zvd2NERWlNQ0FHQTFVRUF3d1p" +
            "TVzUwWld3Z1UwZFlJRkJEU3lCRFpYSjBhV1pwWTJGMFpURWFNQmdHQTFVRQpDZ3dSU1" +
            "c1MFpXd2dRMjl5Y0c5eVlYUnBiMjR4RkRBU0JnTlZCQWNNQzFOaGJuUmhJRU5zWVhKa" +
            "E1Rc3dDUVlEClZRUUlEQUpEUVRFTE1Ba0dBMVVFQmhNQ1ZWTXdXVEFUQmdjcWhrak9Q" +
            "UUlCQmdncWhrak9QUU1CQndOQ0FBUTgKU2V1NWV4WCtvMGNkclhkeEtHMGEvQXRzdnV" +
            "lNVNoUFpmOHgwa2czc0xSM2E5TzVHWWYwcW1XSkptL0c4bzZyVgpvbVI2Nmh3cFJXNl" +
            "pqSm9ocXdvT280SUNtekNDQXBjd0h3WURWUjBqQkJnd0ZvQVUwT2lxMm5YWCtTNUpGN" +
            "Wc4CmV4UmwwTlh5V1Uwd1h3WURWUjBmQkZnd1ZqQlVvRktnVUlaT2FIUjBjSE02THk5" +
            "aGNHa3VkSEoxYzNSbFpITmwKY25acFkyVnpMbWx1ZEdWc0xtTnZiUzl6WjNndlkyVnl" +
            "kR2xtYVdOaGRHbHZiaTkyTWk5d1kydGpjbXcvWTJFOQpjSEp2WTJWemMyOXlNQjBHQT" +
            "FVZERnUVdCQlFzbnhWelhVWnhwRkd5YUtXdzhWZmdOZXBjcHpBT0JnTlZIUThCCkFmO" +
            "EVCQU1DQnNBd0RBWURWUjBUQVFIL0JBSXdBRENDQWRRR0NTcUdTSWI0VFFFTkFRU0NB" +
            "Y1V3Z2dIQk1CNEcKQ2lxR1NJYjRUUUVOQVFFRUVEeEI4dUNBTVU0bmw1ZlBFaktxdG8" +
            "wd2dnRmtCZ29xaGtpRytFMEJEUUVDTUlJQgpWREFRQmdzcWhraUcrRTBCRFFFQ0FRSU" +
            "JFVEFRQmdzcWhraUcrRTBCRFFFQ0FnSUJFVEFRQmdzcWhraUcrRTBCCkRRRUNBd0lCQ" +
            "WpBUUJnc3Foa2lHK0UwQkRRRUNCQUlCQkRBUUJnc3Foa2lHK0UwQkRRRUNCUUlCQVRB" +
            "UkJnc3EKaGtpRytFMEJEUUVDQmdJQ0FJQXdFQVlMS29aSWh2aE5BUTBCQWdjQ0FRWXd" +
            "FQVlMS29aSWh2aE5BUTBCQWdnQwpBUUF3RUFZTEtvWklodmhOQVEwQkFna0NBUUF3RU" +
            "FZTEtvWklodmhOQVEwQkFnb0NBUUF3RUFZTEtvWklodmhOCkFRMEJBZ3NDQVFBd0VBW" +
            "UxLb1pJaHZoTkFRMEJBZ3dDQVFBd0VBWUxLb1pJaHZoTkFRMEJBZzBDQVFBd0VBWUwK" +
            "S29aSWh2aE5BUTBCQWc0Q0FRQXdFQVlMS29aSWh2aE5BUTBCQWc4Q0FRQXdFQVlMS29" +
            "aSWh2aE5BUTBCQWhBQwpBUUF3RUFZTEtvWklodmhOQVEwQkFoRUNBUW93SHdZTEtvWk" +
            "lodmhOQVEwQkFoSUVFQkVSQWdRQmdBWUFBQUFBCkFBQUFBQUF3RUFZS0tvWklodmhOQ" +
            "VEwQkF3UUNBQUF3RkFZS0tvWklodmhOQVEwQkJBUUdBSkJ1MVFBQU1BOEcKQ2lxR1NJ" +
            "YjRUUUVOQVFVS0FRQXdDZ1lJS29aSXpqMEVBd0lEUndBd1JBSWdjREZEZHl1UFRHRVR" +
            "ORm5BU0QzOApDWTNSNmlBREpEVHZBbHZTWDNIekk4a0NJRDZsVm1DWklYUHk4ekpKMW" +
            "gvMnJ1NjJsdlVVWDJJaU1ibVFOUEEwClBzMC8KLS0tLS1FTkQgQ0VSVElGSUNBVEUtL" +
            "S0tLQotLS0tLUJFR0lOIENFUlRJRklDQVRFLS0tLS0KTUlJQ2x6Q0NBajZnQXdJQkFn" +
            "SVZBTkRvcXRwMTEva3VTUmVZUEhzVVpkRFY4bGxOTUFvR0NDcUdTTTQ5QkFNQwpNR2d" +
            "4R2pBWUJnTlZCQU1NRVVsdWRHVnNJRk5IV0NCU2IyOTBJRU5CTVJvd0dBWURWUVFLRE" +
            "JGSmJuUmxiQ0JECmIzSndiM0poZEdsdmJqRVVNQklHQTFVRUJ3d0xVMkZ1ZEdFZ1Eye" +
            "GhjbUV4Q3pBSkJnTlZCQWdNQWtOQk1Rc3cKQ1FZRFZRUUdFd0pWVXpBZUZ3MHhPREEx" +
            "TWpFeE1EUTFNRGhhRncwek16QTFNakV4TURRMU1EaGFNSEV4SXpBaApCZ05WQkFNTUd" +
            "rbHVkR1ZzSUZOSFdDQlFRMHNnVUhKdlkyVnpjMjl5SUVOQk1Sb3dHQVlEVlFRS0RCRk" +
            "piblJsCmJDQkRiM0p3YjNKaGRHbHZiakVVTUJJR0ExVUVCd3dMVTJGdWRHRWdRMnhoY" +
            "21FeEN6QUpCZ05WQkFnTUFrTkIKTVFzd0NRWURWUVFHRXdKVlV6QlpNQk1HQnlxR1NN" +
            "NDlBZ0VHQ0NxR1NNNDlBd0VIQTBJQUJMOXErTk1wMklPZwp0ZGwxYmsvdVdaNStUR1F" +
            "tOGFDaTh6NzhmcytmS0NRM2QrdUR6WG5WVEFUMlpoRENpZnlJdUp3dk4zd05CcDlpCk" +
            "hCU1NNSk1KckJPamdic3dnYmd3SHdZRFZSMGpCQmd3Rm9BVUltVU0xbHFkTkluemc3U" +
            "1ZVcjlRR3prbkJxd3cKVWdZRFZSMGZCRXN3U1RCSG9FV2dRNFpCYUhSMGNITTZMeTlq" +
            "WlhKMGFXWnBZMkYwWlhNdWRISjFjM1JsWkhObApjblpwWTJWekxtbHVkR1ZzTG1OdmJ" +
            "TOUpiblJsYkZOSFdGSnZiM1JEUVM1amNtd3dIUVlEVlIwT0JCWUVGTkRvCnF0cDExL2" +
            "t1U1JlWVBIc1VaZERWOGxsTk1BNEdBMVVkRHdFQi93UUVBd0lCQmpBU0JnTlZIUk1CQ" +
            "WY4RUNEQUcKQVFIL0FnRUFNQW9HQ0NxR1NNNDlCQU1DQTBjQU1FUUNJQy85ais4NFQr" +
            "SHp0Vk8vc09RQldKYlNkKy8ydWV4Swo0K2FBMGpjRkJMY3BBaUEzZGhNckY1Y0Q1MnQ" +
            "2RnFNdkFJcGo4WGRHbXkyYmVlbGpMSksrcHpwY1JBPT0KLS0tLS1FTkQgQ0VSVElGSU" +
            "NBVEUtLS0tLQotLS0tLUJFR0lOIENFUlRJRklDQVRFLS0tLS0KTUlJQ2pqQ0NBalNnQ" +
            "XdJQkFnSVVJbVVNMWxxZE5JbnpnN1NWVXI5UUd6a25CcXd3Q2dZSUtvWkl6ajBFQXdJ" +
            "dwphREVhTUJnR0ExVUVBd3dSU1c1MFpXd2dVMGRZSUZKdmIzUWdRMEV4R2pBWUJnTlZ" +
            "CQW9NRVVsdWRHVnNJRU52CmNuQnZjbUYwYVc5dU1SUXdFZ1lEVlFRSERBdFRZVzUwWV" +
            "NCRGJHRnlZVEVMTUFrR0ExVUVDQXdDUTBFeEN6QUoKQmdOVkJBWVRBbFZUTUI0WERUR" +
            "TRNRFV5TVRFd05ERXhNVm9YRFRNek1EVXlNVEV3TkRFeE1Gb3dhREVhTUJnRwpBMVVF" +
            "QXd3UlNXNTBaV3dnVTBkWUlGSnZiM1FnUTBFeEdqQVlCZ05WQkFvTUVVbHVkR1ZzSUV" +
            "OdmNuQnZjbUYwCmFXOXVNUlF3RWdZRFZRUUhEQXRUWVc1MFlTQkRiR0Z5WVRFTE1Ba0" +
            "dBMVVFQ0F3Q1EwRXhDekFKQmdOVkJBWVQKQWxWVE1Ga3dFd1lIS29aSXpqMENBUVlJS" +
            "29aSXpqMERBUWNEUWdBRUM2bkV3TURJWVpPai9pUFdzQ3phRUtpNwoxT2lPU0xSRmhX" +
            "R2pibkJWSmZWbmtZNHUzSWprRFlZTDBNeE80bXFzeVlqbEJhbFRWWXhGUDJzSkJLNXp" +
            "sS09CCnV6Q0J1REFmQmdOVkhTTUVHREFXZ0JRaVpReldXcDAwaWZPRHRKVlN2MUFiT1" +
            "NjR3JEQlNCZ05WSFI4RVN6QkoKTUVlZ1JhQkRoa0ZvZEhSd2N6b3ZMMk5sY25ScFptb" +
            "GpZWFJsY3k1MGNuVnpkR1ZrYzJWeWRtbGpaWE11YVc1MApaV3d1WTI5dEwwbHVkR1Zz" +
            "VTBkWVVtOXZkRU5CTG1OeWJEQWRCZ05WSFE0RUZnUVVJbVVNMWxxZE5JbnpnN1NWClV" +
            "yOVFHemtuQnF3d0RnWURWUjBQQVFIL0JBUURBZ0VHTUJJR0ExVWRFd0VCL3dRSU1BWU" +
            "JBZjhDQVFFd0NnWUkKS29aSXpqMEVBd0lEU0FBd1JRSWdRUXMvMDhyeWNkUGF1Q0ZrO" +
            "FVQUVhDTUFsc2xvQmU3TndhUUdUY2RwYTBFQwpJUUNVdDhTR3Z4S21qcGNNL3owV1A5" +
            "RHZvOGgyazVkdTFpV0RkQmtBbiswaWlBPT0KLS0tLS1FTkQgQ0VSVElGSUNBVEUtLS0" +
            "tLQoA";

        private readonly string _runtimeData = "CiAgICAgICAgewogI" +
            "CAgICAgICAgICAiandrIiA6IHsKICAgICAgICAgICAgICAgICJrdHkiOiJFQyIsCiAg" +
            "ICAgICAgICAgICAgICAidXNlIjoic2lnIiwKICAgICAgICAgICAgICAgICJjcnYiOiJ" +
            "QLTI1NiIsCiAgICAgICAgICAgICAgICAieCI6IjE4d0hMZUlnVzl3Vk42VkQxVHhncH" +
            "F5MkxzellrTWY2SjhualZBaWJ2aE0iLAogICAgICAgICAgICAgICAgInkiOiJjVjRkU" +
            "zRVYUxNZ1BfNGZZNGo4aXI3Y2wxVFhsRmRBZ2N4NTVvN1RrY1NBIgogICAgICAgICAg" +
            "ICB9CiAgICAgICAgfQogICAgICAgIA";

        [Test]
        public async Task AttestingAnSgxEnclave()
        {
            byte[] binaryRuntimeData = Base64Url.Decode(_runtimeData);
            var report = Base64Url.Decode(_openEnclaveReport);
            var quoteList = report.ToList();
            quoteList.RemoveRange(0, 0x10);
            byte[] binaryQuote = quoteList.ToArray();
            #region Snippet:GetSigningCertificates
            var client = GetAttestationClient();

            IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
            #endregion
            {
                #region Snippet:AttestSgxEnclave
                // Collect quote and runtime data from an SGX enclave.
                // For the "Secure Key Release" scenario, the runtime data is normally a serialized asymmetric key.
                // When the 'quote' (attestation evidence) is created specify the SHA256 hash of the runtime data when
                // creating the evidence.
                //
                // When the generated evidence is created, the hash of the runtime data is included in the
                // secured portion of the evidence.
                //
                // The Attestation service will validate that the Evidence is valid and that the SHA256 of the RuntimeData
                // parameter is included in the evidence.
                AttestationResponse<AttestationResult> attestationResult = client.AttestSgxEnclave(new AttestationRequest
                {
                    Evidence = BinaryData.FromBytes(binaryQuote),
                    RuntimeData = new AttestationData(BinaryData.FromBytes(binaryRuntimeData), false),
                });

                // At this point, the EnclaveHeldData field in the attestationResult.Value property will hold the
                // contain the input binaryRuntimeData.

                // The token is now passed to the "relying party". The relying party will validate that the token was
                // issued by the Attestation Service. It then extracts the asymmetric key from the EnclaveHeldData field.
                // The relying party will then Encrypt it's "key" data using the asymmetric key and transmits it back
                // to the enclave.
                var encryptedData = SendTokenToRelyingParty(attestationResult.Token);

                // Now the encrypted data can be passed into the enclave which can decrypt that data.

                #endregion
            }

            {
                var runtimeDataList = Base64Url.Decode(_runtimeData).ToList();
                runtimeDataList.Add(1);
                binaryRuntimeData = runtimeDataList.ToArray();

                #region Snippet:AttestSgxEnclaveWithException

                try
                {
                    AttestationResponse<AttestationResult> attestationResult = client.AttestSgxEnclave(new AttestationRequest
                    {
                        Evidence = BinaryData.FromBytes(binaryQuote),
                        RuntimeData = new AttestationData(BinaryData.FromBytes(binaryRuntimeData), false),
                    });
                }
                catch (RequestFailedException ex)
                    when (ex.ErrorCode == "InvalidParameter")
                    {
                    // Ignore invalid quote errors.
                    }
                #endregion

            }
            return;
        }

        private BinaryData SendTokenToRelyingParty(AttestationToken token)
        {
            return null;
        }

        public async Task GetAttestationPolicy()
        {
            var tokenOptions = new AttestationTokenValidationOptions();
            tokenOptions.TokenValidated += (AttestationTokenValidationEventArgs args) => { args.IsValid = true; return Task.CompletedTask; };
            var client = new AttestationAdministrationClient(new Uri(TestEnvironment.AadAttestationUrl), new DefaultAzureCredential());
            var attestClient = new AttestationClient(new Uri(TestEnvironment.AadAttestationUrl), new DefaultAzureCredential(),
                new AttestationClientOptions(tokenOptions:tokenOptions));
            ;
            IReadOnlyList<AttestationSigner> signingCertificates = attestClient.GetSigningCertificates().Value;
            var policyResult = await client.GetPolicyAsync(AttestationType.SgxEnclave);
            var result = policyResult.Value;
        }

        [Test]
        public async Task SettingAttestationPolicy()
        {
            var endpoint = TestEnvironment.AadAttestationUrl;
#region Snippet:GetPolicy
            var client = new AttestationAdministrationClient(new Uri(endpoint), new DefaultAzureCredential());

            AttestationResponse<string> policyResult = await client.GetPolicyAsync(AttestationType.SgxEnclave);
            string result = policyResult.Value;
            #endregion

#region Snippet:SetPolicy
            string attestationPolicy = "version=1.0; authorizationrules{=> permit();}; issuancerules{};";

            //@@ X509Certificate2 policyTokenCertificate = new X509Certificate2(<Attestation Policy Signing Certificate>);
            //@@ AsymmetricAlgorithm policyTokenKey = <Attestation Policy Signing Key>;
            /*@@*/var policyTokenCertificate = TestEnvironment.PolicyCertificate0;
            /*@@*/var policyTokenKey = TestEnvironment.PolicySigningKey0;

            var setResult = client.SetPolicy(AttestationType.SgxEnclave, attestationPolicy, new AttestationTokenSigningKey(policyTokenKey, policyTokenCertificate));
            #endregion

            #region Snippet:VerifySigningHash

            // The SetPolicyAsync API will create an AttestationToken signed with the TokenSigningKey to transmit the policy.
            // To verify that the policy specified by the caller was received by the service inside the enclave, we
            // verify that the hash of the policy document returned from the Attestation Service matches the hash
            // of an attestation token created locally.
            //@@ TokenSigningKey signingKey = new TokenSigningKey(<Customer provided signing key>, <Customer provided certificate>)
            /*@@*/AttestationTokenSigningKey signingKey =  new AttestationTokenSigningKey(policyTokenKey, policyTokenCertificate);
            var policySetToken = new AttestationToken(
                BinaryData.FromObjectAsJson(new StoredAttestationPolicy { AttestationPolicy = attestationPolicy }),
                signingKey);

            using var shaHasher = SHA256.Create();
            byte[] attestationPolicyHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.Serialize()));

            Debug.Assert(attestationPolicyHash.SequenceEqual(setResult.Value.PolicyTokenHash.ToArray()));
#endregion
            var resetResult = client.ResetPolicy(AttestationType.SgxEnclave);

            // When the attestation instance is in Isolated mode, the ResetPolicy API requires using a signing key/certificate to authorize the user.
            var resetResult2 = client.ResetPolicy(
                AttestationType.SgxEnclave,
                new AttestationTokenSigningKey(TestEnvironment.PolicySigningKey0, policyTokenCertificate));
            return;
        }
        private AttestationClient GetAttestationClient()
        {
            String regionShortName = TestEnvironment.LocationShortName;

            string endpoint = "https://shared" + regionShortName + "." + regionShortName + ".test.attest.azure.net";

            #region Snippet:CreateAttestationClient
            var options = new AttestationClientOptions();
            return new AttestationClient(new Uri(endpoint), new DefaultAzureCredential(), options);
            #endregion
        }
    }
}
