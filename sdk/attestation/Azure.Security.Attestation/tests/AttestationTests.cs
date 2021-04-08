// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
    public class AttestationTests : RecordedTestBase<AttestationClientTestEnvironment>
    {
        private readonly string _openEnclaveReport = "AQAAAAIAAADoEQAAAAAAAAMAAgAAAAAABQAKAJOacjP3nEyplAoNs5V_Bgfl_L18zrEJejtqk6RDB0IzAAAAABERAwX_gAYAAAAAAAAAAA" +
                                                    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAcAAAAAAAAABwAAAAAAAAApKh9LUZ5GYn6yR4o9mFFAVlPFtLCmkl3oQ4NNkhaF" +
                                                    "DgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAASupfmg7QSxH4iarf5qHTdiE6Kalahc5zN65vf-zmYQwAAAAAAAAAAAAAAAAAAA" +
                                                    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                                                    "AAABAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAKFQuRP5-c_ZhD2sxrn" +
                                                    "V2kl8JzNu0xWRlg-zBVhM3qP8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADQQAACJx8e27oQ0pijs3lXQ9HfKWP9NMqVHQFL9" +
                                                    "SOjC_KGDcbv-I2fCafTHJ__AmNqVXy7XTXnzmLp1HhUCy1_9AORSATqGZ1PtvBf4Q2NfNxqVkNrGJAjYuqMPStdg0MuM21nN-Qc9BWNycR" +
                                                    "MMsU7YfHSzmw7eGjBb_Ewfb3k6N4ZYRhERAwX_gAYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABUAAAAAAAAA" +
                                                    "BwAAAAAAAAA_sKzghp0uMPKOhtcMdmQDpU-7zWWO7ODhuUipFVkXQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAjE9XddeWUD" +
                                                    "6WE393xoqCmgBWrI3tcBQLCBsJRJDFe_8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                                                    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAUAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                                                    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH_mzVQFF8XbJCRGdNkA3SPx9ZUPgtx3874VyDYQnFRIAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                                                    "AAAAAAAAAAAAAEUP2-pxe7LoyevtN5BdE4KKikxKK6-hwG0xCDmxmfLphcnrVskSbKmiKUfzkWUBehrF8gHCGNGIPX3QQDwmtZ4gAAABAg" +
                                                    "MEBQYHCAkKCwwNDg8QERITFBUWFxgZGhscHR4fBQDMDQAALS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tCk1JSUVnVENDQkNhZ0F3SUJB" +
                                                    "Z0lVU3I5VmRiSnFWbzVyZzRadUpCRWo2SjNoak9jd0NnWUlLb1pJemowRUF3SXcKY1RFak1DRUdBMVVFQXd3YVNXNTBaV3dnVTBkWUlGQk" +
                                                    "RTeUJRY205alpYTnpiM0lnUTBFeEdqQVlCZ05WQkFvTQpFVWx1ZEdWc0lFTnZjbkJ2Y21GMGFXOXVNUlF3RWdZRFZRUUhEQXRUWVc1MFlT" +
                                                    "QkRiR0Z5WVRFTE1Ba0dBMVVFCkNBd0NRMEV4Q3pBSkJnTlZCQVlUQWxWVE1CNFhEVEl4TURNeE9UQTBOVEl3T0ZvWERUSTRNRE14T1RBME" +
                                                    "5USXcKT0Zvd2NERWlNQ0FHQTFVRUF3d1pTVzUwWld3Z1UwZFlJRkJEU3lCRFpYSjBhV1pwWTJGMFpURWFNQmdHQTFVRQpDZ3dSU1c1MFpX" +
                                                    "d2dRMjl5Y0c5eVlYUnBiMjR4RkRBU0JnTlZCQWNNQzFOaGJuUmhJRU5zWVhKaE1Rc3dDUVlEClZRUUlEQUpEUVRFTE1Ba0dBMVVFQmhNQ1" +
                                                    "ZWTXdXVEFUQmdjcWhrak9QUUlCQmdncWhrak9QUU1CQndOQ0FBUlQKVGRNNVhTMGFiRTA2ZUdVTVU3S1JOQXJlRGRtTWJHK25KVHlucDZX" +
                                                    "ankyeXJ6NmlEa3h1R1F3WGZ1b25uUVBuZApjdHgwbHIyR3I0WjF1YXNsQjM2Vm80SUNtekNDQXBjd0h3WURWUjBqQkJnd0ZvQVUwT2lxMm" +
                                                    "5YWCtTNUpGNWc4CmV4UmwwTlh5V1Uwd1h3WURWUjBmQkZnd1ZqQlVvRktnVUlaT2FIUjBjSE02THk5aGNHa3VkSEoxYzNSbFpITmwKY25a" +
                                                    "cFkyVnpMbWx1ZEdWc0xtTnZiUzl6WjNndlkyVnlkR2xtYVdOaGRHbHZiaTkyTWk5d1kydGpjbXcvWTJFOQpjSEp2WTJWemMyOXlNQjBHQT" +
                                                    "FVZERnUVdCQlRMejZNQ3VHcVZobFYrR2Q0ZGtacmx4YndCV2pBT0JnTlZIUThCCkFmOEVCQU1DQnNBd0RBWURWUjBUQVFIL0JBSXdBREND" +
                                                    "QWRRR0NTcUdTSWI0VFFFTkFRU0NBY1V3Z2dIQk1CNEcKQ2lxR1NJYjRUUUVOQVFFRUVMOEhhRExXWWdVUFUzU3c3Tm1Ibkhrd2dnRmtCZ2" +
                                                    "9xaGtpRytFMEJEUUVDTUlJQgpWREFRQmdzcWhraUcrRTBCRFFFQ0FRSUJFVEFRQmdzcWhraUcrRTBCRFFFQ0FnSUJFVEFRQmdzcWhraUcr" +
                                                    "RTBCCkRRRUNBd0lCQWpBUUJnc3Foa2lHK0UwQkRRRUNCQUlCQkRBUUJnc3Foa2lHK0UwQkRRRUNCUUlCQVRBUkJnc3EKaGtpRytFMEJEUU" +
                                                    "VDQmdJQ0FJQXdFQVlMS29aSWh2aE5BUTBCQWdjQ0FRWXdFQVlMS29aSWh2aE5BUTBCQWdnQwpBUUF3RUFZTEtvWklodmhOQVEwQkFna0NB" +
                                                    "UUF3RUFZTEtvWklodmhOQVEwQkFnb0NBUUF3RUFZTEtvWklodmhOCkFRMEJBZ3NDQVFBd0VBWUxLb1pJaHZoTkFRMEJBZ3dDQVFBd0VBWU" +
                                                    "xLb1pJaHZoTkFRMEJBZzBDQVFBd0VBWUwKS29aSWh2aE5BUTBCQWc0Q0FRQXdFQVlMS29aSWh2aE5BUTBCQWc4Q0FRQXdFQVlMS29aSWh2" +
                                                    "aE5BUTBCQWhBQwpBUUF3RUFZTEtvWklodmhOQVEwQkFoRUNBUW93SHdZTEtvWklodmhOQVEwQkFoSUVFQkVSQWdRQmdBWUFBQUFBCkFBQU" +
                                                    "FBQUF3RUFZS0tvWklodmhOQVEwQkF3UUNBQUF3RkFZS0tvWklodmhOQVEwQkJBUUdBSkJ1MVFBQU1BOEcKQ2lxR1NJYjRUUUVOQVFVS0FR" +
                                                    "QXdDZ1lJS29aSXpqMEVBd0lEU1FBd1JnSWhBSzZPMS9GNy80NFprcWhUN2FhNgp5QVh6QlltRWxUVHRvL25rVUd4N1BtUktBaUVBMXliSW" +
                                                    "t6SjVwcXR1L21jOW5DUWNwRUJOdk5KZFNIcW1jc04rCkV2dWJ3WlU9Ci0tLS0tRU5EIENFUlRJRklDQVRFLS0tLS0KLS0tLS1CRUdJTiBD" +
                                                    "RVJUSUZJQ0FURS0tLS0tCk1JSUNsekNDQWo2Z0F3SUJBZ0lWQU5Eb3F0cDExL2t1U1JlWVBIc1VaZERWOGxsTk1Bb0dDQ3FHU000OUJBTU" +
                                                    "MKTUdneEdqQVlCZ05WQkFNTUVVbHVkR1ZzSUZOSFdDQlNiMjkwSUVOQk1Sb3dHQVlEVlFRS0RCRkpiblJsYkNCRApiM0p3YjNKaGRHbHZi" +
                                                    "akVVTUJJR0ExVUVCd3dMVTJGdWRHRWdRMnhoY21FeEN6QUpCZ05WQkFnTUFrTkJNUXN3CkNRWURWUVFHRXdKVlV6QWVGdzB4T0RBMU1qRX" +
                                                    "hNRFExTURoYUZ3MHpNekExTWpFeE1EUTFNRGhhTUhFeEl6QWgKQmdOVkJBTU1Ha2x1ZEdWc0lGTkhXQ0JRUTBzZ1VISnZZMlZ6YzI5eUlF" +
                                                    "TkJNUm93R0FZRFZRUUtEQkZKYm5SbApiQ0JEYjNKd2IzSmhkR2x2YmpFVU1CSUdBMVVFQnd3TFUyRnVkR0VnUTJ4aGNtRXhDekFKQmdOVk" +
                                                    "JBZ01Ba05CCk1Rc3dDUVlEVlFRR0V3SlZVekJaTUJNR0J5cUdTTTQ5QWdFR0NDcUdTTTQ5QXdFSEEwSUFCTDlxK05NcDJJT2cKdGRsMWJr" +
                                                    "L3VXWjUrVEdRbThhQ2k4ejc4ZnMrZktDUTNkK3VEelhuVlRBVDJaaERDaWZ5SXVKd3ZOM3dOQnA5aQpIQlNTTUpNSnJCT2pnYnN3Z2Jnd0" +
                                                    "h3WURWUjBqQkJnd0ZvQVVJbVVNMWxxZE5JbnpnN1NWVXI5UUd6a25CcXd3ClVnWURWUjBmQkVzd1NUQkhvRVdnUTRaQmFIUjBjSE02THk5" +
                                                    "alpYSjBhV1pwWTJGMFpYTXVkSEoxYzNSbFpITmwKY25acFkyVnpMbWx1ZEdWc0xtTnZiUzlKYm5SbGJGTkhXRkp2YjNSRFFTNWpjbXd3SF" +
                                                    "FZRFZSME9CQllFRk5EbwpxdHAxMS9rdVNSZVlQSHNVWmREVjhsbE5NQTRHQTFVZER3RUIvd1FFQXdJQkJqQVNCZ05WSFJNQkFmOEVDREFH" +
                                                    "CkFRSC9BZ0VBTUFvR0NDcUdTTTQ5QkFNQ0EwY0FNRVFDSUMvOWorODRUK0h6dFZPL3NPUUJXSmJTZCsvMnVleEsKNCthQTBqY0ZCTGNwQW" +
                                                    "lBM2RoTXJGNWNENTJ0NkZxTXZBSXBqOFhkR215MmJlZWxqTEpLK3B6cGNSQT09Ci0tLS0tRU5EIENFUlRJRklDQVRFLS0tLS0KLS0tLS1C" +
                                                    "RUdJTiBDRVJUSUZJQ0FURS0tLS0tCk1JSUNqakNDQWpTZ0F3SUJBZ0lVSW1VTTFscWROSW56ZzdTVlVyOVFHemtuQnF3d0NnWUlLb1pJem" +
                                                    "owRUF3SXcKYURFYU1CZ0dBMVVFQXd3UlNXNTBaV3dnVTBkWUlGSnZiM1FnUTBFeEdqQVlCZ05WQkFvTUVVbHVkR1ZzSUVOdgpjbkJ2Y21G" +
                                                    "MGFXOXVNUlF3RWdZRFZRUUhEQXRUWVc1MFlTQkRiR0Z5WVRFTE1Ba0dBMVVFQ0F3Q1EwRXhDekFKCkJnTlZCQVlUQWxWVE1CNFhEVEU0TU" +
                                                    "RVeU1URXdOREV4TVZvWERUTXpNRFV5TVRFd05ERXhNRm93YURFYU1CZ0cKQTFVRUF3d1JTVzUwWld3Z1UwZFlJRkp2YjNRZ1EwRXhHakFZ" +
                                                    "QmdOVkJBb01FVWx1ZEdWc0lFTnZjbkJ2Y21GMAphVzl1TVJRd0VnWURWUVFIREF0VFlXNTBZU0JEYkdGeVlURUxNQWtHQTFVRUNBd0NRME" +
                                                    "V4Q3pBSkJnTlZCQVlUCkFsVlRNRmt3RXdZSEtvWkl6ajBDQVFZSUtvWkl6ajBEQVFjRFFnQUVDNm5Fd01ESVlaT2ovaVBXc0N6YUVLaTcK" +
                                                    "MU9pT1NMUkZoV0dqYm5CVkpmVm5rWTR1M0lqa0RZWUwwTXhPNG1xc3lZamxCYWxUVll4RlAyc0pCSzV6bEtPQgp1ekNCdURBZkJnTlZIU0" +
                                                    "1FR0RBV2dCUWlaUXpXV3AwMGlmT0R0SlZTdjFBYk9TY0dyREJTQmdOVkhSOEVTekJKCk1FZWdSYUJEaGtGb2RIUndjem92TDJObGNuUnBa" +
                                                    "bWxqWVhSbGN5NTBjblZ6ZEdWa2MyVnlkbWxqWlhNdWFXNTAKWld3dVkyOXRMMGx1ZEdWc1UwZFlVbTl2ZEVOQkxtTnliREFkQmdOVkhRNE" +
                                                    "VGZ1FVSW1VTTFscWROSW56ZzdTVgpVcjlRR3prbkJxd3dEZ1lEVlIwUEFRSC9CQVFEQWdFR01CSUdBMVVkRXdFQi93UUlNQVlCQWY4Q0FR" +
                                                    "RXdDZ1lJCktvWkl6ajBFQXdJRFNBQXdSUUlnUVFzLzA4cnljZFBhdUNGazhVUFFYQ01BbHNsb0JlN053YVFHVGNkcGEwRUMKSVFDVXQ4U0" +
                                                    "d2eEttanBjTS96MFdQOUR2bzhoMms1ZHUxaVdEZEJrQW4rMGlpQT09Ci0tLS0tRU5EIENFUlRJRklDQVRFLS0tLS0KAA";

        private readonly string _runtimeData = "CiAgICAgICAgewogICAgICAgICAgICAiandrIiA6IHsKICAgICAgICAgICAgICAgICJrdHkiOiJFQyI" +
                                                  "sCiAgICAgICAgICAgICAgICAidXNlIjoic2lnIiwKICAgICAgICAgICAgICAgICJjcnYiOiJQLTI1Ni" +
                                                  "IsCiAgICAgICAgICAgICAgICAieCI6IjE4d0hMZUlnVzl3Vk42VkQxVHhncHF5MkxzellrTWY2Sjhua" +
                                                  "lZBaWJ2aE0iLAogICAgICAgICAgICAgICAgInkiOiJjVjRkUzRVYUxNZ1BfNGZZNGo4aXI3Y2wxVFhs" +
                                                  "RmRBZ2N4NTVvN1RrY1NBIgogICAgICAgICAgICB9CiAgICAgICAgfQogICAgICAgIAA";

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

                var attestationResult = await client.AttestSgxEnclaveAsync(binaryQuote, null, false, BinaryData.FromBytes(binaryRuntimeData), false);

                // Confirm that the attestation token contains the enclave held data we specified.
                CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.DeprecatedEnclaveHeldData);
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

            var client = TestEnvironment.GetSharedAttestationClient(this, new TokenValidationOptions(
                validateExpirationTime: TestEnvironment.IsTalkingToLiveServer,
                validationCallback: (attestationToken, signer) =>
                {
                    // Verify that the callback can access the enclave held data field.
                    CollectionAssert.AreEqual(binaryRuntimeData, attestationToken.GetBody<AttestationResult>().EnclaveHeldData);

                    // The MAA service always sends a Key ID for the signer.
                    Assert.IsNotNull(signer.CertificateKeyId);
                    Assert.AreEqual(TestEnvironment.SharedAttestationUrl, attestationToken.Issuer);
                    callbackInvoked = true;
                    return true;
                }));

            IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
            {
                // Collect quote and enclave held data from an SGX enclave.

                var attestationResult = await client.AttestSgxEnclaveAsync(binaryQuote, null, false, BinaryData.FromBytes(binaryRuntimeData), false);

                // Confirm that the attestation token contains the enclave held data we specified.
                CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.DeprecatedEnclaveHeldData);
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

                var attestationResult = await client.AttestOpenEnclaveAsync(binaryReport, null, false, BinaryData.FromBytes(binaryRuntimeData), false);

                // Confirm that the attestation token contains the enclave held data we specified.
               CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.DeprecatedEnclaveHeldData);
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

            var client = TestEnvironment.GetSharedAttestationClient(this, new TokenValidationOptions(
                validateExpirationTime: TestEnvironment.IsTalkingToLiveServer,
                validationCallback: (attestationToken, signer) =>
            {
                // Verify that the callback can access the enclave held data field.
                CollectionAssert.AreEqual(binaryRuntimeData, attestationToken.GetBody<AttestationResult>().EnclaveHeldData);

                // The MAA service always sends a Key ID for the signer.
                Assert.IsNotNull(signer.CertificateKeyId);
                Assert.AreEqual(TestEnvironment.SharedAttestationUrl, attestationToken.Issuer);
                callbackInvoked = true;
                return true;
            }));

            IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
            {
                // Collect quote and enclave held data from an SGX enclave.

                var attestationResult = await client.AttestOpenEnclaveAsync(binaryReport, null, false, BinaryData.FromBytes(binaryRuntimeData), false);

                // Confirm that the attestation token contains the enclave held data we specified.
                CollectionAssert.AreEqual(binaryRuntimeData, attestationResult.Value.DeprecatedEnclaveHeldData);
                // VERIFY ATTESTATIONRESULT.
                // Encrypt Data using DeprecatedEnclaveHeldData
                // Send to enclave.
                Assert.IsTrue(callbackInvoked);
            }
        }
    }
}
