// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateClientTests : ClientTestBase
    {
        public CertificateClientTests(bool isAsync) : base(isAsync)
        {
            CertificateClientOptions options = new CertificateClientOptions
            {
                Transport = new MockTransport(),
            };

            Client = InstrumentClient(new CertificateClient(new Uri("http://localhost"), new MockCredential(), options));
        }

        public CertificateClient Client { get; }

        [Test]
        public void CreateIssuerArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateIssuerAsync(null));
            Assert.AreEqual("issuer", ex.ParamName);

            CertificateIssuer issuer = new CertificateIssuer();
            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateIssuerAsync(issuer));
            Assert.AreEqual("issuer", ex.ParamName);
            StringAssert.StartsWith("issuer.Name cannot be null or an empty string.", ex.Message);

            issuer = new CertificateIssuer("test");
            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateIssuerAsync(issuer));
            Assert.AreEqual("issuer", ex.ParamName);
            StringAssert.StartsWith("issuer.Provider cannot be null or an empty string.", ex.Message);
        }

        [Test]
        public void GetIssuerArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetIssuerAsync(null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.GetIssuerAsync(string.Empty));
            Assert.AreEqual("issuerName", ex.ParamName);
            StringAssert.StartsWith("Value cannot be an empty string.", ex.Message);
        }

        [Test]
        public void UpdateIssuerArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateIssuerAsync(null));
            Assert.AreEqual("issuer", ex.ParamName);

            CertificateIssuer issuer = new CertificateIssuer();
            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.UpdateIssuerAsync(issuer));
            Assert.AreEqual("issuer", ex.ParamName);
            StringAssert.StartsWith("issuer.Name cannot be null or an empty string.", ex.Message);
        }

        [Test]
        public void DeleteIssuerArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.DeleteIssuerAsync(null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.DeleteIssuerAsync(string.Empty));
            Assert.AreEqual("issuerName", ex.ParamName);
        }

        [Test]
        public void SetContactsArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetContactsAsync(null));
            Assert.AreEqual("contacts", ex.ParamName);
        }

        [Test]
        public void GetCertificatePolicyArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetCertificatePolicyAsync(null));
            Assert.AreEqual("certificateName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.GetCertificatePolicyAsync(string.Empty));
            Assert.AreEqual("certificateName", ex.ParamName);
            StringAssert.StartsWith("Value cannot be an empty string.", ex.Message);
        }

        [Test]
        public void UpdateCertificatePolicyArgumentValidation()
        {
            CertificatePolicy policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=Azure SDK");

            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateCertificatePolicyAsync(null, policy));
            Assert.AreEqual("certificateName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.UpdateCertificatePolicyAsync(string.Empty, policy));
            Assert.AreEqual("certificateName", ex.ParamName);
            StringAssert.StartsWith("Value cannot be an empty string.", ex.Message);
        }

        [Test]
        public void ChallengeBasedAuthenticationRequiresHttps()
        {
            // After passing parameter validation, ChallengeBasedAuthenticationPolicy should throw for "http" requests.
            Assert.ThrowsAsync<InvalidOperationException>(() => Client.GetCertificateAsync("test"));
        }

        [Test]
        public void DownloadSecretDenied()
        {
            CertificateClientOptions options = new CertificateClientOptions
            {
                Transport = new MockTransport(request =>
                {
                    if (request.Uri.Path.Contains("/certificates/"))
                    {
                        MockResponse response = new MockResponse(200);
                        response.AddHeader(Core.HttpHeader.Common.JsonContentType);

                        response.SetContent(@"{
  ""id"": ""https://heathskeyvault.vault.azure.net/certificates/1611349050/548e19c596cf49779ca1706240a788e3"",
  ""kid"": ""https://heathskeyvault.vault.azure.net/keys/1611349050/548e19c596cf49779ca1706240a788e3"",
  ""sid"": ""https://heathskeyvault.vault.azure.net/secrets/1611349050/548e19c596cf49779ca1706240a788e3"",
  ""x5t"": ""SM_LGoask0yHvMVSk3h-0Kf3gqE"",
  ""cer"": ""MIIDKjCCAhKgAwIBAgIQYV16SxDIQkKURxXo6sQkUTANBgkqhkiG9w0BAQsFADASMRAwDgYDVQQDEwdkZWZhdWx0MB4XDTIwMTExMDA0MjYxNloXDTIxMTExMDA0MzYxNlowEjEQMA4GA1UEAxMHZGVmYXVsdDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALrumIRenUa5LmJsRurAhrRoJP0hyCg8jQz5ujXFoyf/flklfyqxnau5/a2yS4mnfJm9fX1aFF1/OdEg5qxcyHSBR66\u002BdPV27oxIfM6JKVqbHBcaG07OVFHh\u002B2yWBwTjAiPZjOxCxEMw37tdgDctnEBQzaTackhFU21seBWnHCC74mF2N3Iy93itptOguvwIh6CnLcduvIeb6o9lfr72XJg0BjJ/Bmpf92W5VwMWinHUumomCeLjA5lnIiOGGrmVNqaRJWf1ezhg3JtzNJRSV0sbLjHoCmziKAL4pFLEiF6tz\u002B6apvz1voDufit6r0gKwez8YaOnQjUAmXetoZmSOQkCAwEAAaN8MHowDgYDVR0PAQH/BAQDAgSQMAkGA1UdEwQCMAAwHQYDVR0lBBYwFAYIKwYBBQUHAwEGCCsGAQUFBwMCMB8GA1UdIwQYMBaAFNwU63f97Oel4UIAJt6/nQ9Ka12HMB0GA1UdDgQWBBTcFOt3/eznpeFCACbev50PSmtdhzANBgkqhkiG9w0BAQsFAAOCAQEAcs\u002B0b3\u002BUI0AmrvwQZVugfnbngNN5jDpuEyP8gms4Txpg93auVXgXlgiNsrKUgIi2U2CQLY6pdUUSilBHifCdxM3lxgB7wIkYc8ihu8eVBI7m4KNo1io0Jxwsw9KKG3612NUXuKDz8oHMUsJ49Iq8IaRaJdVpiydZCA9ltwhajWpgauOTMRsxtZdkG\u002BlakSCehBCgmjGR04NRG0jGNRaTh4ANHNQgFqP4Vp6mkzDxQu8B4PI5YKZfhpusqEDOSb5HeM8nwLYntNH32in1XKx3s5BSMUmbrdmeihAIyYxR3Imal5LwjckXvu6eXlRfe6BynbDW1g3IwNASMIwt3u0dhQ=="",
  ""attributes"": {
    ""enabled"": true,
    ""nbf"": 1604982376,
    ""exp"": 1636518976,
    ""created"": 1604982976,
    ""updated"": 1604982976,
    ""recoveryLevel"": ""Recoverable\u002BPurgeable"",
    ""recoverableDays"": 90
  },
  ""policy"": {
    ""id"": ""https://heathskeyvault.vault.azure.net/certificates/1611349050/policy"",
    ""key_props"": {
      ""exportable"": true,
      ""kty"": ""RSA"",
      ""key_size"": 2048,
      ""reuse_key"": false
    },
    ""secret_props"": {
      ""contentType"": ""application/x-pkcs12""
    },
    ""x509_props"": {
      ""subject"": ""CN=default"",
      ""ekus"": [
        ""1.3.6.1.5.5.7.3.1"",
        ""1.3.6.1.5.5.7.3.2""
      ],
      ""key_usage"": [
        ""dataEncipherment"",
        ""digitalSignature""
      ],
      ""validity_months"": 12,
      ""basic_constraints"": {
        ""ca"": false
      }
    },
    ""lifetime_actions"": [
      {
        ""trigger"": {
          ""lifetime_percentage"": 80
        },
        ""action"": {
          ""action_type"": ""AutoRenew""
        }
      }
    ],
    ""issuer"": {
      ""name"": ""Self"",
      ""cert_transparency"": false
    },
    ""attributes"": {
      ""enabled"": true,
      ""created"": 1604982971,
      ""updated"": 1604982971
    }
  },
  ""pending"": {
    ""id"": ""https://heathskeyvault.vault.azure.net/certificates/1611349050/pending""
  }
}");
                        return response;
                    }
                    else if (request.Uri.Path.StartsWith("/secrets/1611349050/548e19c596cf49779ca1706240a788e3"))
                    {
                        MockResponse response = new MockResponse(403);
                        response.AddHeader(Core.HttpHeader.Common.JsonContentType);

                        response.SetContent(@"{
  ""error"": {
    ""code"": ""Forbidden"",
    ""message"": ""The user, group or application 'appid=f9ab11db-b032-44b3-af0a-44713541cc40;oid=0aa95430-9a7f-4c8e-8cf6-579278e68947;iss=https://sts.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47/' does not have secrets get permission on key vault 'heathskeyvault;location=westus2'. For help resolving this issue, please see https://go.microsoft.com/fwlink/?linkid=2125287"",
    ""innererror"": {
      ""code"": ""ForbiddenByPolicy""
    }
  }
}");
                        return response;
                    }
                    else
                    {
                        return new MockResponse(404);
                    }
                }),
            };

            CertificateClient client = InstrumentClient(new CertificateClient(new Uri("https://heathskeyvault.vault.azure.net"), new MockCredential(), options));

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.DownloadCertificateAsync("test"));
            Assert.AreEqual(403, ex.Status);
            Assert.AreEqual("Forbidden", ex.ErrorCode);
        }
    }
}
