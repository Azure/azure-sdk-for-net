// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Tests
{
    [LiveOnly(Reason = "JWT cannot be stored in recordings.")]
    public class AttestationTests : RecordedTestBase<AttestationClientTestEnvironment>
    {
        // A Base64Url encoded pre-canned OpenEnclave Report, used to test
        // the attestation APIs.
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

        // A Base64Url encoded pre-canned JSON Web Key, used to test
        // the attestation APIs.
        private readonly string _runtimeData = "CiAgICAgICAgewogI" +
            "CAgICAgICAgICAiandrIiA6IHsKICAgICAgICAgICAgICAgICJrdHkiOiJFQyIsCiAg" +
            "ICAgICAgICAgICAgICAidXNlIjoic2lnIiwKICAgICAgICAgICAgICAgICJjcnYiOiJ" +
            "QLTI1NiIsCiAgICAgICAgICAgICAgICAieCI6IjE4d0hMZUlnVzl3Vk42VkQxVHhncH" +
            "F5MkxzellrTWY2SjhualZBaWJ2aE0iLAogICAgICAgICAgICAgICAgInkiOiJjVjRkU" +
            "zRVYUxNZ1BfNGZZNGo4aXI3Y2wxVFhsRmRBZ2N4NTVvN1RrY1NBIgogICAgICAgICAg" +
            "ICB9CiAgICAgICAgfQogICAgICAgIA";

        public AttestationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AttestSgxEnclaveShared()
        {
            // An SGX Quote is an OpenEnclave report with the first 16 bytes stripped from it.
            var report = Base64Url.Decode(_openEnclaveReport);
            var quoteList = report.ToList();
            quoteList.RemoveRange(0, 0x10);

            byte[] binaryQuote = quoteList.ToArray();
            byte[] binaryRuntimeData = Base64Url.Decode(_runtimeData);

            var client = TestEnvironment.GetSharedAttestationClient(this);

            IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
            {
                // Collect quote and enclave held data from an SGX enclave.

                var attestationResult = await client.AttestSgxEnclaveAsync(
                    new AttestationRequest
                    {
                        Evidence = BinaryData.FromBytes(binaryQuote),
                        RuntimeData = new AttestationData(BinaryData.FromBytes(binaryRuntimeData), false),
                    });

                // Confirm that the attestation token contains the enclave held data we specified.
                CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.EnclaveHeldData.ToArray());
                // VERIFY ATTESTATIONRESULT.
                // Encrypt Data using DeprecatedEnclaveHeldData
                // Send to enclave.
            }
            {
                // Collect quote and enclave held data from an SGX enclave.

                var attestationResult = await client.AttestSgxEnclaveAsync(
                    new AttestationRequest
                    {
                        Evidence = BinaryData.FromBytes(binaryQuote),
                        RuntimeData = new AttestationData(BinaryData.FromBytes(binaryRuntimeData), true),
                    });

                // Confirm that the attestation token contains the enclave held data we specified.
                Assert.IsNull(attestationResult.Value.EnclaveHeldData);
                // VERIFY ATTESTATIONRESULT.
                // Encrypt Data using DeprecatedEnclaveHeldData
                // Send to enclave.
            }
        }

        [RecordedTest]
        public async Task AttestSgxEnclaveSharedValidateCallback()
        {
            // An SGX Quote is an OpenEnclave report with the first 16 bytes stripped from it.
            var report = Base64Url.Decode(_openEnclaveReport);
            var quoteList = report.ToList();
            quoteList.RemoveRange(0, 0x10);

            byte[] binaryQuote = quoteList.ToArray();
            byte[] binaryRuntimeData = Base64Url.Decode(_runtimeData);

            bool callbackInvoked = false;
            var tokenValidationOptions = new AttestationTokenValidationOptions
            {
                ValidateExpirationTime = TestEnvironment.IsTalkingToLiveServer,
            };
            tokenValidationOptions.TokenValidated += (AttestationTokenValidationEventArgs args) =>
            {
                // Verify that the callback can access the enclave held data field.
                CollectionAssert.AreEqual(binaryRuntimeData, args.Token.GetBody<AttestationResult>().EnclaveHeldData.ToArray());

                // The MAA service always sends a Key ID for the signer.
                Assert.IsNotNull(args.Signer.CertificateKeyId);
                Assert.AreEqual(TestEnvironment.SharedAttestationUrl, args.Token.Issuer);
                callbackInvoked = true;
                return Task.CompletedTask;
            };

            var client = TestEnvironment.GetSharedAttestationClient(this, tokenValidationOptions);

            IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
            {
                // Collect quote and enclave held data from an SGX enclave.

                var attestationResult = await client.AttestSgxEnclaveAsync(
                    new AttestationRequest
                    {
                        Evidence = BinaryData.FromBytes(binaryQuote),
                        RuntimeData = new AttestationData(BinaryData.FromBytes(binaryRuntimeData), false),
                    });

                // Confirm that the attestation token contains the enclave held data we specified.
                CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.EnclaveHeldData.ToArray());
                // VERIFY ATTESTATIONRESULT.
                // Encrypt Data using DeprecatedEnclaveHeldData
                // Send to enclave.
                Assert.IsTrue(callbackInvoked);
            }
        }

        [RecordedTest]
        public async Task AttestOpenEnclaveShared()
        {
            byte[] binaryReport = Base64Url.Decode(_openEnclaveReport);
            byte[] binaryRuntimeData = Base64Url.Decode(_runtimeData);

            var client = TestEnvironment.GetSharedAttestationClient(this);

            IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
            {
                // Collect quote and enclave held data from an SGX enclave.

                var attestationResult = await client.AttestOpenEnclaveAsync(
                    new AttestationRequest
                    {
                        Evidence = BinaryData.FromBytes(binaryReport),
                        RuntimeData = new AttestationData(BinaryData.FromBytes(binaryRuntimeData), false),
                    });

                // Confirm that the attestation token contains the enclave held data we specified.
                CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.EnclaveHeldData.ToArray());
                // VERIFY ATTESTATIONRESULT.
                // Encrypt Data using DeprecatedEnclaveHeldData
                // Send to enclave.
            }
        }

        [RecordedTest]
        public async Task AttestOpenEnclaveSharedValidateCallback()
        {
            byte[] binaryReport = Base64Url.Decode(_openEnclaveReport);
            byte[] binaryRuntimeData = Base64Url.Decode(_runtimeData);
            bool callbackInvoked = false;

            AttestationTokenValidationOptions tokenValidationOptions = new AttestationTokenValidationOptions
            {
                ValidateExpirationTime = TestEnvironment.IsTalkingToLiveServer,
            };

            tokenValidationOptions.TokenValidated += (args) =>
            {
                // Verify that the callback can access the enclave held data field.
                CollectionAssert.AreEqual(binaryRuntimeData, args.Token.GetBody<AttestationResult>().EnclaveHeldData.ToArray());

                // The MAA service always sends a Key ID for the signer.
                args.IsValid =
                    null != args.Signer.CertificateKeyId &&
                    1 == args.Signer.SigningCertificates.Count &&
                    null != args.Signer.SigningCertificates[0] &&
                    TestEnvironment.SharedAttestationUrl == args.Token.Issuer;
                callbackInvoked = true;
                return Task.CompletedTask;
            };

            var client = TestEnvironment.GetSharedAttestationClient(this, tokenValidationOptions);

            IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
            {
                // Collect quote and enclave held data from an SGX enclave.

                var attestationResult = await client.AttestOpenEnclaveAsync(
                    new AttestationRequest
                    {
                        Evidence = BinaryData.FromBytes(binaryReport),
                        RuntimeData = new AttestationData(BinaryData.FromBytes(binaryRuntimeData), false),
                    });
                // Confirm that the attestation token contains the enclave held data we specified.
                CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.EnclaveHeldData.ToArray());

#pragma warning disable CS0618 // Type or member is obsolete
                Assert.IsNotNull(attestationResult.Value.DeprecatedEnclaveHeldData);
                CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.DeprecatedEnclaveHeldData.ToArray());
                Assert.IsNotNull(attestationResult.Value.DeprecatedEnclaveHeldData2);
                CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.DeprecatedEnclaveHeldData2.ToArray());
#pragma warning restore CS0618 // Type or member is obsolete
                // VERIFY ATTESTATIONRESULT.
                // Encrypt Data using DeprecatedEnclaveHeldData
                // Send to enclave.
                Assert.IsTrue(callbackInvoked);
            }
        }

        [RecordedTest]
        public async Task AttestOpenEnclaveSharedCallbackRejects()
        {
            byte[] binaryReport = Base64Url.Decode(_openEnclaveReport);
            byte[] binaryRuntimeData = Base64Url.Decode(_runtimeData);
            bool callbackInvoked = false;

            AttestationTokenValidationOptions tokenValidationOptions = new AttestationTokenValidationOptions
            {
                ValidateExpirationTime = TestEnvironment.IsTalkingToLiveServer,
            };

            tokenValidationOptions.TokenValidated += (args) =>
            {
                callbackInvoked = true;
                args.IsValid = false;
                return Task.CompletedTask;
            };

            var client = TestEnvironment.GetSharedAttestationClient(this, tokenValidationOptions);

            IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
            {
                // Collect quote and enclave held data from an SGX enclave.

                Assert.ThrowsAsync(typeof(AttestationTokenValidationFailedException), async () => await client.AttestOpenEnclaveAsync(
                    new AttestationRequest
                    {
                        Evidence = BinaryData.FromBytes(binaryReport),
                        RuntimeData = new AttestationData(BinaryData.FromBytes(binaryRuntimeData), false),
                    }));

                Assert.IsTrue(callbackInvoked);
            }
        }

        private class TpmInit
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }
        }

        // TpmAttest requires a TpmPayload object.
        private class TpmPayload
        {
            [JsonPropertyName("payload")]
            public object Payload { get; set; }
        }

        [RecordedTest]
        public async Task AttestTpmMinimalAad()
        {
            // TPM attestation requires that there be an attestation policy applied before it can succeed.
            string attestationPolicy = "version=1.0; authorizationrules{=> permit();}; issuancerules{};";
            var adminClient = TestEnvironment.GetAadAdministrationClient(this);

            var setResult = await adminClient.SetPolicyAsync(AttestationType.Tpm, attestationPolicy);

            var tpmPayload = new TpmPayload
            {
                Payload = new TpmInit
                {
                    Type = "aikcert"
                },
            };

            var client = TestEnvironment.GetAadAttestationClient(this);
            Response<TpmAttestationResponse> tpmResponse = null;
            tpmResponse = await client.AttestTpmAsync(new TpmAttestationRequest { Data = BinaryData.FromObjectAsJson(tpmPayload) });

            // Make sure that the response from the service looks like it's supposed to look.
            var parsedValue = JsonDocument.Parse(tpmResponse.Value.Data);
            Assert.IsNotNull(parsedValue.RootElement.GetProperty("payload"));
            var payload = parsedValue.RootElement.GetProperty("payload");
            Assert.IsNotNull(payload.GetProperty("challenge"));
            Assert.IsNotNull(payload.GetProperty("service_context"));
        }
    }
}
