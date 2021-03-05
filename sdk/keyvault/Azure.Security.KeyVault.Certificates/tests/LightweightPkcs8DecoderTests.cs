// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class LightweightPkcs8DecoderTests
    {
        [Test]
        public void VerifyECDecoderPrime256v1Imported() =>
            // TODO: Need to read in the full ECCurve and make sure this then works on macOS. By using OID 1.3.132.0.10 it will not since that OID is not supported on macOS.
            VerifyECDecoder(EcPrime256v1PrivateKeyImported, 256, @"Dqi/IwHjt2ttGyT0vleMvzsbStSOiDrevV4hhPGAXZoQ55b//keMmZ/weezuiSnliF4bTGWYxrqs73Yoj/6ddQ==");

        [Test]
        public void VerifyECDecoderSecp256k1()
        {
            try
            {
                VerifyECDecoder(EcSecp256k1PrivateKey, 256, @"YV+z2wZfDRqszLwcoPAnT4XmKMbfAqfwQYdYYU5FyicKWLtRmcaAX8Pd8h0OmSAdxoPO2sVyK2FP22pWq/6fJQ==");
            }
            catch (CryptographicException) when (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                Assert.Ignore("The curve OID 1.3.132.0.10 is not supported by the current platform");
            }
        }

        [Test]
        public void VerifyECDecoderPrime256v1() =>
            VerifyECDecoder(EcPrime256v1PrivateKey, 256, @"1Byf+UuKVAEj+lsGBLQ4HiUDd4v/wa/XgcGlOEHorg47kjN2V6EDhC5aLwqZnXkbr48Y1umvBRAWcRYT6f8WfA==");

        [Test]
        public void VerifyECDecoderSecp384r1() =>
            VerifyECDecoder(EcSecp384r1PrivateKey, 384, @"gHf3reGX71P7us9/fvcK1+6ONqRnkw5b9v+arz7G8iHk8BGflKwMlESIEEg2EezbNvLg6pURkCPC4OBngnM0OVYCjhb7Onh+zUogi2LSSCEIRZqrYcjzg8PHukp/sRyU");

        [Test]
        public void VerifyECDecoderSecp521r1() =>
            VerifyECDecoder(EcSecp521r1PrivateKey, 521, @"ADB74QoZQcAbO0gfOhcavQLhV+nYMfLtNXC0i7a7FOYCiyZIJFoZtEzWbVTe4de1yMoe0lwGnW1mkCoPtEb0Q8f+AYAgRYSXlYkaF96XZYGcSp+RyALtOUpSvvpIaffk/3farwiFlGj6Dqryd5wLRksfLNR4DSyZbpEtHOg2RwkQ+vsI");

        [Test]
        public void VerifyECDecoderBadData()
        {
            byte[] data = Convert.FromBase64String(InvalidEcSecp521r1PrivateKey);

            Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.DecodeECDsaPkcs8(data));
        }

        // Not using TestCaseSource because params too long for friendly test case rendering.
        private static void VerifyECDecoder(string key, int keySize, string signature)
        {
#if NET461
            Assert.Ignore("ECC is not supported before .NET Framework 4.7");
#endif
            byte[] data = Convert.FromBase64String(key);
            byte[] signatureBytes = Convert.FromBase64String(signature);

            using ECDsa ecdsa = LightweightPkcs8Decoder.DecodeECDsaPkcs8(data);

            Assert.AreEqual(keySize, ecdsa.KeySize);
            Assert.IsTrue(ecdsa.VerifyData(Encoding.UTF8.GetBytes("test"), signatureBytes, HashAlgorithmName.SHA256));
        }

        // This comes from Key Vault when a certificate using P-256K is generated
        // with OID 1.2.840.10045.1.1 that is not a recognized curve.
        private const string EcPrime256v1PrivateKeyImported = @"
MIIBYQIBADCB7AYHKoZIzj0CATCB4AIBATAsBgcqhkjOPQEBAiEA////////////
/////////////////////////v///C8wRAQgAAAAAAAAAAAAAAAAAAAAAAAAAAAA
AAAAAAAAAAAAAAAEIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHBEEE
eb5mfvncu6xVoGKVzocLBwKb/NstzijZWfKBWxb4F5hIOtp3JqPEZV2k+/wOEQio
/Re0SKaFVBmcR9CP+xDUuAIhAP////////////////////66rtzmr0igO7/SXozQ
NkFBAgEBBG0wawIBAQQg0hfpkSWI0DC9kCrcaQkc0dK9A6UjMUySJ+D8LwN9UCGh
RANCAASfEif6Nd3c9/AhykaRDH1vUv8FhccPM0g0M5PCY6S7d8b7Mjq9PdHdWQd9
x3sZH1onGnW13EyciQXFTZnV41Ve";

        private const string EcSecp256k1PrivateKey = @"
MIGEAgEAMBAGByqGSM49AgEGBSuBBAAKBG0wawIBAQQggIszi9CyyZSvzCmMVSnT
XlQQz+m62V3B1Uopp/Q2gOOhRANCAASy4TPJzmokaWtXadcXAC3tz8UhGCjEiygJ
OLBbWHiQCEJSk8du+JbQe0TzijhdFwqfbkenBxX7QpStBwCNqzFU";

        private const string EcPrime256v1PrivateKey = @"
MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQgZ5ry8UKYtXlBV4My
m3dN9KwpCNcwA5L5aiMYfDsP7c6hRANCAARQA1DgfLljdhBdEoP1kk6dNzmqfM4w
7giQjyBNuuYmWDGsQUHqUSEEhOH81a35aHuv7MvUQt9oM79IdctY19hW";

        private const string EcSecp384r1PrivateKey = @"
MIG2AgEAMBAGByqGSM49AgEGBSuBBAAiBIGeMIGbAgEBBDB0UXjGnA3vRZHZaTM5
RXsjrIydUQhkYPU//1pVjy89Iywtd9j36AxC13IaHuhnqyOhZANiAARv90hnBoAe
SNjkuMLQyG2SOkWLAW0Pc03lQ+0BziF8+SAjSnPfrrbHfsHtRWu6qbHUsLah65Cs
ePF2Msws1A5Xu+cMf4NwhfQbgBRukhVgDNG5iPGtf1/637JMyjgu26E=";

        private const string EcSecp521r1PrivateKey = @"
MIHuAgEAMBAGByqGSM49AgEGBSuBBAAjBIHWMIHTAgEBBEIAQz4QXON1QlQ33Tw1
LS8yaQk8cyMcbyrmEuV4IMjzRqgZy9hgAqqBeXcahn7iRVNm35rCPHfNEmuNdIMr
iuokqtehgYkDgYYABAB7EAgArfIE6n0reR499cptx7p8zhkIM0HbggmDXfYtS9m4
QReG1YX7Hi221vKmBuPbzGlFYLX1XwoncZ+hghgrFwHQKR0hJEbVwcibkz0bcfkb
jGZBHIhVzTJ00ukzBggiEPggBclQEND5ku2xIvnM8mFMOJbV0NGoJ4Y1AHQwcPG9
4Q==";

        private const string InvalidEcSecp521r1PrivateKey = @"
VALIDBASE64ENCODEDDATABUTNOTAVALIDSECP521R1BASE64ENCODEDPKCS8KEY
MIHuAgEAMBAGByqGSM49AgEGBSuBBAAjBIHWMIHTAgEBBEIAQz4QXON1QlQ33Tw1
LS8yaQk8cyMcbyrmEuV4IMjzRqgZy9hgAqqBeXcahn7iRVNm35rCPHfNEmuNdIMr
iuokqtehgYkDgYYABAB7EAgArfIE6n0reR499cptx7p8zhkIM0HbggmDXfYtS9m4
QReG1YX7Hi221vKmBuPbzGlFYLX1XwoncZ+hghgrFwHQKR0hJEbVwcibkz0bcfkb
jGZBHIhVzTJ00ukzBggiEPggBclQEND5ku2xIvnM8mFMOJbV0NGoJ4Y1AHQwcPG9
4Q==";

        private const string RsaPrivateKey = @"
MIIJQgIBADANBgkqhkiG9w0BAQEFAASCCSwwggkoAgEAAoICAQChq+kkeZaVqLTd
73521+VyMoxqpGEVKmWGbMDGL4OhCLpjH7LND5f+GUwylIh9lTSDFedw2mnbCPZg
vS+3wGNXYiLUpRpnnQ8uAGufYCRZyFR/jCdLIiV7mC7VfcB6UHqmodzWrj+3j3T3
o15waVqAmVw/m4nBPTYudkMX51GScbKlmbETQRS9E8UATnP7mFY15BIRdN6NTbc6
nGQPmFzBX1mH58lkvrP2J/O9ExMMt0p0+pmp8DWla3nIcLhktcwK5E3FF3+tiP1w
L+aDPpMnQXUwe3hVIsiI5pmIAXU6EODlJMrTnZuIcgbgM5FMexT7VSBK04JcNgIH
OG/h9r9WG39jwjh0LZysQcUo/zQK/j2DJBzUYwTYBRto1u+3qeVUzoqShM3Uxoky
aoRhAns/RvqwBpCrp6rHlNncfLdCNoUWHg0NNO6qWHKOYTJZZZLRsXGvs2gtY6fe
/faYMmgAgWT96WdWrytLlDZiGO6f6FmmszCAGjlewD6FWdqBjcEnet7/E17L+T2z
0bkoHQVHzWt6kupEYvd8iPkF0X3gr8CL2aT+8IhSVMdTJCsWxXUUd1aqADrSrqEq
pjgVrNJDlWj3cVG5tZk4F0mezDqtm3A1d1B4hL5AGx98xF2br3LJE8SCmCIremdt
k3vn+dt2NPdWoXcn/l6hEzBwrXrM4wIDAQABAoICACwjJs9Sco4BNP+yNrBzWKzI
qBUlM2v32yfL4QU6S5FXNKuDJ+lb7H7uoSLd8jV22pM/E6R3vJaT58+ZVsGvwG9G
14N+X6sR8eb5LmigcswgKRF5TfDxLZKEhaS7ZCUAe7uqTQQ/Jh4TCDfjXhEKci7R
r6Gd8QnUkEo29zI7cMWuTLtxLiq3hdXo48uln3x8pmyoC1bAtVGWegOCVr77NbeF
NIgp+42JktANMDnaT0UVdTpigDko3zx+Dw1t2KmGCGKg2aqJM85IrAhIy4HhP4Nk
F35Y9w0nJeBaNGgxHbPwj7V/SfBkAuZJWx8ydOSQZbYIE3zaKajLBdq6ybDDEJEe
Y44nufPpzqH7yt+dabXx49Pxz8p5E+vObUh0NVfzSO/Nk32/uXoZKVx5vViBwCnX
N28pvi88vFoCU/FowGimJHPcxBGyWejgXWDMrYi0okBXYkO0gpHAFskV21EttF8c
eEQXlTfUjOTOFpQNaUJu+Azq/jjDEXG6TMPElN+pj2hBY/euVl6TNakXW8yomYuj
SkoGPioK4mw+ASok4o20hy7p4kLnmQuiM7gKsga/ppygIPrdor7OlSCCYxBUBoSS
qmsBioIAs7PQU/jcocyxIz6P0mfj3jGUcMf4sZEX5us6dvC4uf7e8gS9lpAunnBw
GNZLIiGd5sJPgy6PV0WBAoIBAQDSYttzXUAduxLnvCs5IDzIuAzFGaLs9nKBCwHf
sveCMFZ5aI0mPCHl5Js1qaceIqsisv4PKKEIwNotgZ6SupCd3ohKJ2ZlNyw7ivWf
3NcpWjSMrhtfm3clzH2Nyj8y3cnFU/QJmpIcHcHLXogSYrbGpqMRPzQFoGpzXrvZ
xKstb6GEns2ryR9X7zvHVeGH4TBMmpb7UgBFfEgq3tTtCf54WhYFeJl0cs840mOG
xFWGECteE74hwGGeFJEy+Uh4i1bsw74mSAu1+ewNj9ucsMwBwKX2IDI6ExZvX0pK
1N4gsarAF92L1XbgIskhUwJ30DRpBA+cW+jrsDF8nYahr6XTAoIBAQDEuToGSMBI
2SGzl2TJqf4A9Oy0PDFG63jiT1+tCd5sB5e8gSaTSohuPksLDHxv+7JP33DvB/3f
l5aLQjYQMTaCqFtU16bVgLt9mFA2Zdt8kK4s6TGtKffZWXJQAMAdvIJiOIVTj+GQ
3iFoTRcJC8UScKBZJ8kr+VJzeGVhvjYXTamp16vn7WX7nZ3p7KIIt/oEQD6G0rI3
DrRj3NX6a32dfWsccORmONXguwrEAOsA0eB5gM3I4PA3PTsyEFjr1mWwKEMF79E1
KtJrQKRUL7ixyA9uoaflvP+f7Vj4kVtiHO51+5Rl8ZjyKgiqUIh9FaEqpsfoUAD5
uQVVItLjXIKxAoIBAQDP/Pdi5695NPaNrlM02I//ByVovd16UnIE7PLfSjiytkLn
J9tTD2ObuRNQS/ZxLmjtlvLf3ZTF6JJJJrmz6UkLKXKnjKgILDFIdCo77sGvmgQV
iBJ7xGBYN/9v65/rE6Rjtomt7OfBcBGkkkIHmxuC7D6N0GQHo/1ZLTCdK3bnJlMR
n0VJLT4VWudIO7kI8jEjqjjVIM4v45wc9cqexKCULstSgVWD7/S5AhVuqC68qMOW
8AGpsF1RQJgDQrrIoUhALYuQoO0i7H7XMX81OvuUR/ZKiq3dB/3IAPabYDJxM/PQ
kEdv9IrfLsSUc1IfTPBjWaZtN9ffGYLy5XCx68oNAoIBAC95pA8wL3dlL0TwHFqu
s6X3dchpXlsHKL00+pn/77WSf4P2hyC0tAgm8GVSNhWwYG/2NIL7IsF7C9G/wNxX
hBg0GRZ4lMKhtp2wzGrUWgvNvrsH6/0mS7Iga/3ysGp8u9qIWWS5LG6RrO5G7HA6
buzsUUYy29HI8aT8QTs9dEBbdb6PVeU63YnDmACEIvaHr8am2nAfGPNAkTgoa1tr
5XzEb70FYZlpzfPWL9rtfclM3Sd1djQsVMx/8nE6kLsZmqDQlpwwLATwuKc5im7m
tWPyLAc+7A39dpNZ7EbQjYU4BjRi6oVPsOGAU2cG2GmXdrWcWlIuPI4HoMnTBaHp
CYECggEAVEYRkltT41NeHpGfQsbk9Juif5Z8OzryjeniApEmtplrvk/NLnEgZuXo
Qrdu1greDG7hZYf/EsUj+NmYvAmqcs6X+JF1O/ngHc2cVOMewUR/wRKRdzyTJOgq
kuGDkPfpm5BJdAZb+5rO+nrW8ljtA2PdRZWqWGaHBEIDrfqz53fxfEtPU+0+Z+Zz
0580pTXrHiFMixoDyrbDPmUQlg9ncE3MUpz2yj/x2C47LxhYgpMx73q6S7ibZ04q
VCIWDNNihXPOMVKBXY1eEzAJ3/UxhO5oZwNEedkBSC7nvjdaZZaAx/hFo3DPBT8w
GCW0/fPxstiXQaANvVLWIIih4VlLHg==";
    }
}
