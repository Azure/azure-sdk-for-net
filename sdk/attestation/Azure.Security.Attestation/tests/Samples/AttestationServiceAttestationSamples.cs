// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        private readonly string _runtimeData =
"wFdC6gBMrrej2JTuNlTjWOe-ebL7Rz34WjmEUnbfFEc_5BITs2t4V8uuEI8JX73t0g_nUTu6g07xyC6rx9wl8IUQFYyP" +
"KhsMk3FLESkryhb5dz9cDxoxwMNnGbu-B7AsOBCe3lckQmoRAEf4_5qUm-PS26DD3SkbNRT-XjMQMQ19Q33dpKFvXPrQ" +
"yvCK0ly0pL-JXXdnT4hsJUn8tJKW152W2gZWeXIKO8Ge2er_8xXUvQ6gCLZwwcD1--Whg90h9n5tVRNQdqCnWwsFL0LE" +
"KVNiCj7Cbii8_XpjYjTTSQKSOiC_i_VbZZF9cY4W_1ZpUj7WWkSSkPhNSuqBHOvmuFrVTlfQvgdsKYQ5zYbSnPtqJ1_4" +
"QUoPJsYQIxyFFncIDbuGWuTPd_FDKLBLQADyO4kYWjnVMXdM1p_xjtqo2_UWTznEfrQpoZttQE99GZVEVSXPBn0GXzph" +
"4JDKyWq3rDIvzFMhumG5ay1eyQ622hxwBN4WVxVjJ-BtaWMnU15o4OZZVReCpTodGZabT0RgAmJqKNZnH_Vx_ECLKxss" +
"xEHoNWZBUCWAS9Qy4OpdQZ1-vINHJaTIZsehSZrkk1a5ttJdghTSUJGbEPWt3Azstjidyq8x1l5q-PIClhJE_Q_vHOvT" +
"zxCebqZOhFJl08rx8I2OYxzekLA1miJ4aZs8h3eB6tOHZF06gJC8wcIORvy8d8ysEZvja40AWSg";

        private readonly string _sgxQuote  =
            "AwACAAAAAAAFAAoAk5pyM_ecTKmUCg2zlX8GBxikFG2RGHbLfXx_vS5gtP8AAAAADg4CBf-ABwAAAAAAAA" +
    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABQAAAAAAAAAHAAAAAAAAANlxlh9yS3HfxfFV" +
    "OsTvtorRYOhJYCzdhRy4QEI-WSpzAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACFaCMSMCcBDt" +
    "DOH31RW2vh11BeWCj7oZeFZ2Aw2P_8KAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB8SAQ" +
    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAj" +
    "KYv2t_KVJfL8eJMumYwKEA--jtZ1UOGFrKEaj6Tm6gAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
    "AAMBAAANfCXfxRtqOqDZV2NJAxIFTxDg0BuV-LLuq_D2YGtwp3x331XC_I13E1BqX7zR8dL4GiEACndxFk" +
    "LGaAv7NTLL6pLrutcGj8wPA8MTOlV4BI9ZLcEwlNobvHIWKrrjtzDs_Wekb9nq08xb-P_yg0R0RvYNMkgI" +
    "z61v6jPXeuq_n-Dg4CBf-ABwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFQAA" +
    "AAAAAAAHAAAAAAAAAD-wrOCGnS4w8o6G1wx2ZAOlT7vNZY7s4OG5SKkVWRdAAAAAAAAAAAAAAAAAAAAAAA" +
    "AAAAAAAAAAAAAAAAAAAACMT1d115ZQPpYTf3fGioKaAFasje1wFAsIGwlEkMV7_wAAAAAAAAAAAAAAAAAA" +
    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAEABQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAACJ_xj1I2YFmziAVUcpkwhFu4bxfwGQ71nD4Xoz4lKoNwAAAAAAAA" +
    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAKsDZgMr9cfiWsAr8sI9X5cwgnD3ob0ETj44vViBmw41w5Q7Z" +
    "pSaH6cAfnRI3-QimRJnpzr_9V5LzIEBCVmloPyAAAAECAwQFBgcICQoLDA0ODxAREhMUFRYXGBkaGxwdHh" +
    "8FAMgNAAAtLS0tLUJFR0lOIENFUlRJRklDQVRFLS0tLS0KTUlJRWdEQ0NCQ2FnQXdJQkFnSVVmakNyOUhX" +
    "bmVSZzdLUUEra3krRmRybXdmMXd3Q2dZSUtvWkl6ajBFQXdJd2NURWpNQ0VHQTFVRQpBd3dhU1c1MFpXd2" +
    "dVMGRZSUZCRFN5QlFjbTlqWlhOemIzSWdRMEV4R2pBWUJnTlZCQW9NRVVsdWRHVnNJRU52Y25CdmNtRjBh" +
    "Vzl1Ck1SUXdFZ1lEVlFRSERBdFRZVzUwWVNCRGJHRnlZVEVMTUFrR0ExVUVDQXdDUTBFeEN6QUpCZ05WQk" +
    "FZVEFsVlRNQjRYRFRFNU1EY3gKT0RJeU16STFObG9YRFRJMk1EY3hPREl5TXpJMU5sb3djREVpTUNBR0Ex" +
    "VUVBd3daU1c1MFpXd2dVMGRZSUZCRFN5QkRaWEowYVdacApZMkYwWlRFYU1CZ0dBMVVFQ2d3UlNXNTBaV3" +
    "dnUTI5eWNHOXlZWFJwYjI0eEZEQVNCZ05WQkFjTUMxTmhiblJoSUVOc1lYSmhNUXN3CkNRWURWUVFJREFK" +
    "RFFURUxNQWtHQTFVRUJoTUNWVk13V1RBVEJnY3Foa2pPUFFJQkJnZ3Foa2pPUFFNQkJ3TkNBQVNpdG1MQT" +
    "NJYjYKY3R1SGZ0ZnR3R1Qray90UGxwN2VvTVpnSlFDZSsxZFlXKzFvNTUwRXpXREM3dFRreWQ2NTJKdlBD" +
    "VXBBZVMyUitDYUFRaGlPSThtNQpvNElDbXpDQ0FwY3dId1lEVlIwakJCZ3dGb0FVME9pcTJuWFgrUzVKRj" +
    "VnOGV4UmwwTlh5V1Uwd1h3WURWUjBmQkZnd1ZqQlVvRktnClVJWk9hSFIwY0hNNkx5OWhjR2t1ZEhKMWMz" +
    "UmxaSE5sY25acFkyVnpMbWx1ZEdWc0xtTnZiUzl6WjNndlkyVnlkR2xtYVdOaGRHbHYKYmk5Mk1TOXdZMn" +
    "RqY213L1kyRTljSEp2WTJWemMyOXlNQjBHQTFVZERnUVdCQlN6czNGTVF1UlBLcGtSNWxTbXRkckl5V3Bt" +
    "N2pBTwpCZ05WSFE4QkFmOEVCQU1DQnNBd0RBWURWUjBUQVFIL0JBSXdBRENDQWRRR0NTcUdTSWI0VFFFTk" +
    "FRU0NBY1V3Z2dIQk1CNEdDaXFHClNJYjRUUUVOQVFFRUVNTDZ5K01oZG4vNkJiSWV6WEdkUHlNd2dnRmtC" +
    "Z29xaGtpRytFMEJEUUVDTUlJQlZEQVFCZ3NxaGtpRytFMEIKRFFFQ0FRSUJCakFRQmdzcWhraUcrRTBCRF" +
    "FFQ0FnSUJCakFRQmdzcWhraUcrRTBCRFFFQ0F3SUJBakFRQmdzcWhraUcrRTBCRFFFQwpCQUlCQkRBUUJn" +
    "c3Foa2lHK0UwQkRRRUNCUUlCQVRBUkJnc3Foa2lHK0UwQkRRRUNCZ0lDQUlBd0VBWUxLb1pJaHZoTkFRME" +
    "JBZ2NDCkFRRXdFQVlMS29aSWh2aE5BUTBCQWdnQ0FRQXdFQVlMS29aSWh2aE5BUTBCQWdrQ0FRQXdFQVlM" +
    "S29aSWh2aE5BUTBCQWdvQ0FRQXcKRUFZTEtvWklodmhOQVEwQkFnc0NBUUF3RUFZTEtvWklodmhOQVEwQk" +
    "Fnd0NBUUF3RUFZTEtvWklodmhOQVEwQkFnMENBUUF3RUFZTApLb1pJaHZoTkFRMEJBZzRDQVFBd0VBWUxL" +
    "b1pJaHZoTkFRMEJBZzhDQVFBd0VBWUxLb1pJaHZoTkFRMEJBaEFDQVFBd0VBWUxLb1pJCmh2aE5BUTBCQW" +
    "hFQ0FRY3dId1lMS29aSWh2aE5BUTBCQWhJRUVBWUdBZ1FCZ0FFQUFBQUFBQUFBQUFBd0VBWUtLb1pJaHZo" +
    "TkFRMEIKQXdRQ0FBQXdGQVlLS29aSWh2aE5BUTBCQkFRR0FKQnVvUUFBTUE4R0NpcUdTSWI0VFFFTkFRVU" +
    "tBUUF3Q2dZSUtvWkl6ajBFQXdJRApTQUF3UlFJaEFMN25wNTZieGtESFVRRStTaUQ1K1M4eTFEOWFOK0Zy" +
    "MHY1VENUQlUyazNkQWlCbVdQZUVIOW1ySkJ3SWU5eHV1aHo0Clp4cTlzTnlPaDRCc3NzdEQwV0Jkd3c9PQ" +
    "otLS0tLUVORCBDRVJUSUZJQ0FURS0tLS0tCi0tLS0tQkVHSU4gQ0VSVElGSUNBVEUtLS0tLQpNSUlDbHpD" +
    "Q0FqNmdBd0lCQWdJVkFORG9xdHAxMS9rdVNSZVlQSHNVWmREVjhsbE5NQW9HQ0NxR1NNNDlCQU1DCk1HZ3" +
    "hHakFZQmdOVkJBTU1FVWx1ZEdWc0lGTkhXQ0JTYjI5MElFTkJNUm93R0FZRFZRUUtEQkZKYm5SbGJDQkQK" +
    "YjNKd2IzSmhkR2x2YmpFVU1CSUdBMVVFQnd3TFUyRnVkR0VnUTJ4aGNtRXhDekFKQmdOVkJBZ01Ba05CTV" +
    "FzdwpDUVlEVlFRR0V3SlZVekFlRncweE9EQTFNakV4TURRMU1EaGFGdzB6TXpBMU1qRXhNRFExTURoYU1I" +
    "RXhJekFoCkJnTlZCQU1NR2tsdWRHVnNJRk5IV0NCUVEwc2dVSEp2WTJWemMyOXlJRU5CTVJvd0dBWURWUV" +
    "FLREJGSmJuUmwKYkNCRGIzSndiM0poZEdsdmJqRVVNQklHQTFVRUJ3d0xVMkZ1ZEdFZ1EyeGhjbUV4Q3pB" +
    "SkJnTlZCQWdNQWtOQgpNUXN3Q1FZRFZRUUdFd0pWVXpCWk1CTUdCeXFHU000OUFnRUdDQ3FHU000OUF3RU" +
    "hBMElBQkw5cStOTXAySU9nCnRkbDFiay91V1o1K1RHUW04YUNpOHo3OGZzK2ZLQ1EzZCt1RHpYblZUQVQy" +
    "WmhEQ2lmeUl1Snd2TjN3TkJwOWkKSEJTU01KTUpyQk9qZ2Jzd2diZ3dId1lEVlIwakJCZ3dGb0FVSW1VTT" +
    "FscWROSW56ZzdTVlVyOVFHemtuQnF3dwpVZ1lEVlIwZkJFc3dTVEJIb0VXZ1E0WkJhSFIwY0hNNkx5OWpa" +
    "WEowYVdacFkyRjBaWE11ZEhKMWMzUmxaSE5sCmNuWnBZMlZ6TG1sdWRHVnNMbU52YlM5SmJuUmxiRk5IV0" +
    "ZKdmIzUkRRUzVqY213d0hRWURWUjBPQkJZRUZORG8KcXRwMTEva3VTUmVZUEhzVVpkRFY4bGxOTUE0R0Ex" +
    "VWREd0VCL3dRRUF3SUJCakFTQmdOVkhSTUJBZjhFQ0RBRwpBUUgvQWdFQU1Bb0dDQ3FHU000OUJBTUNBMG" +
    "NBTUVRQ0lDLzlqKzg0VCtIenRWTy9zT1FCV0piU2QrLzJ1ZXhLCjQrYUEwamNGQkxjcEFpQTNkaE1yRjVj" +
    "RDUydDZGcU12QUlwajhYZEdteTJiZWVsakxKSytwenBjUkE9PQotLS0tLUVORCBDRVJUSUZJQ0FURS0tLS" +
    "0tCi0tLS0tQkVHSU4gQ0VSVElGSUNBVEUtLS0tLQpNSUlDampDQ0FqU2dBd0lCQWdJVUltVU0xbHFkTklu" +
    "emc3U1ZVcjlRR3prbkJxd3dDZ1lJS29aSXpqMEVBd0l3CmFERWFNQmdHQTFVRUF3d1JTVzUwWld3Z1UwZF" +
    "lJRkp2YjNRZ1EwRXhHakFZQmdOVkJBb01FVWx1ZEdWc0lFTnYKY25CdmNtRjBhVzl1TVJRd0VnWURWUVFI" +
    "REF0VFlXNTBZU0JEYkdGeVlURUxNQWtHQTFVRUNBd0NRMEV4Q3pBSgpCZ05WQkFZVEFsVlRNQjRYRFRFNE" +
    "1EVXlNVEV3TkRFeE1Wb1hEVE16TURVeU1URXdOREV4TUZvd2FERWFNQmdHCkExVUVBd3dSU1c1MFpXd2dV" +
    "MGRZSUZKdmIzUWdRMEV4R2pBWUJnTlZCQW9NRVVsdWRHVnNJRU52Y25CdmNtRjAKYVc5dU1SUXdFZ1lEVl" +
    "FRSERBdFRZVzUwWVNCRGJHRnlZVEVMTUFrR0ExVUVDQXdDUTBFeEN6QUpCZ05WQkFZVApBbFZUTUZrd0V3" +
    "WUhLb1pJemowQ0FRWUlLb1pJemowREFRY0RRZ0FFQzZuRXdNRElZWk9qL2lQV3NDemFFS2k3CjFPaU9TTF" +
    "JGaFdHamJuQlZKZlZua1k0dTNJamtEWVlMME14TzRtcXN5WWpsQmFsVFZZeEZQMnNKQks1emxLT0IKdXpD" +
    "QnVEQWZCZ05WSFNNRUdEQVdnQlFpWlF6V1dwMDBpZk9EdEpWU3YxQWJPU2NHckRCU0JnTlZIUjhFU3pCSg" +
    "pNRWVnUmFCRGhrRm9kSFJ3Y3pvdkwyTmxjblJwWm1sallYUmxjeTUwY25WemRHVmtjMlZ5ZG1salpYTXVh" +
    "VzUwClpXd3VZMjl0TDBsdWRHVnNVMGRZVW05dmRFTkJMbU55YkRBZEJnTlZIUTRFRmdRVUltVU0xbHFkTk" +
    "luemc3U1YKVXI5UUd6a25CcXd3RGdZRFZSMFBBUUgvQkFRREFnRUdNQklHQTFVZEV3RUIvd1FJTUFZQkFm" +
    "OENBUUV3Q2dZSQpLb1pJemowRUF3SURTQUF3UlFJZ1FRcy8wOHJ5Y2RQYXVDRms4VVBRWENNQWxzbG9CZT" +
    "dOd2FRR1RjZHBhMEVDCklRQ1V0OFNHdnhLbWpwY00vejBXUDlEdm84aDJrNWR1MWlXRGRCa0FuKzBpaUE9" +
    "PQotLS0tLUVORCBDRVJUSUZJQ0FURS0tLS0tCgA";

        [Test]
        public async Task AttestingAnSgxEnclave()
        {
            var endpoint = TestEnvironment.SharedEusTest;

            byte[] binaryQuote = Base64Url.Decode(_sgxQuote);
            byte[] binaryRuntimeData = Base64Url.Decode(_runtimeData);

            var client = GetAttestationClient();

            IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
            {
                // Collect quote and enclave held data from OpenEnclave enclave.

                var attestationResult = client.AttestSgxEnclave(binaryQuote, null, false, BinaryData.FromBytes(binaryRuntimeData), false).Value;
                Assert.AreEqual(binaryRuntimeData, attestationResult.DeprecatedEnclaveHeldData);
                // VERIFY ATTESTATIONRESULT.
                // Encrypt Data using DeprecatedEnclaveHeldData
                // Send to enclave.
            }
            return;
        }

        public async Task GetAttestationPolicy()
        {
            var client = new AttestationAdministrationClient(new Uri(TestEnvironment.AadAttestationUrl), new DefaultAzureCredential());
            var attestClient = new AttestationClient(new Uri(TestEnvironment.AadAttestationUrl), new DefaultAzureCredential(),
                new AttestationClientOptions(validationCallback: (attestationToken, signer) => true));

            IReadOnlyList<AttestationSigner> signingCertificates = attestClient.GetSigningCertificates().Value;

            var policyResult = await client.GetPolicyAsync(AttestationType.SgxEnclave);
            var result = policyResult.Value.AttestationPolicy;
        }

        [Test]
        public async Task SettingAttestationPolicy()
        {
            var endpoint = TestEnvironment.AadAttestationUrl;
#region Snippet:GetPolicy
            var client = new AttestationAdministrationClient(new Uri(endpoint), new DefaultAzureCredential());
            var attestClient = new AttestationClient(new Uri(endpoint), new DefaultAzureCredential(),
                new AttestationClientOptions(validationCallback: (attestationToken, signer) => true));
            var policyResult = await client.GetPolicyAsync(AttestationType.SgxEnclave);
            var result = policyResult.Value.AttestationPolicy;
            #endregion

#region Snippet:SetPolicy
            string attestationPolicy = "version=1.0; authorizationrules{=> permit();}; issuancerules{};";

            var policyTokenSigner = TestEnvironment.PolicyCertificate0;

            AttestationToken policySetToken = new SecuredAttestationToken(
                new StoredAttestationPolicy { AttestationPolicy = Base64Url.EncodeString(attestationPolicy), },
                TestEnvironment.PolicySigningKey0,
                policyTokenSigner);

            var setResult = client.SetPolicy(AttestationType.SgxEnclave, policySetToken);
#endregion
            var resetResult = client.ResetPolicy(AttestationType.SgxEnclave);

            // When the attestation instance is in Isolated mode, the ResetPolicy API requires using a signing key/certificate to authorize the user.
            var resetResult2 = client.ResetPolicy(
                AttestationType.SgxEnclave,
                new SecuredAttestationToken(TestEnvironment.PolicySigningKey0, policyTokenSigner));
            return;
        }
        private AttestationClient GetAttestationClient()
        {
            string endpoint = TestEnvironment.SharedUkSouth;

            /*TokenCredential credential = TestEnvironment.Credential;*/

            var options = new AttestationClientOptions();
//            string powerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";
            return new AttestationClient(new Uri(endpoint), new DefaultAzureCredential(), options);
        }
    }
}
