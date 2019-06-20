using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Az.Auth.Net452.Test
{
    public class CertAuthTests : AuthNet452TestBase
    {
        public CertAuthTests()
        {

        }


        [Theory(Skip = "Interactive tests")]
        [InlineData("AADTenant=dcfa120f-9293-4f06-b3d2-cf728bcabb10;" +
                "ServicePrincipal=b8a1058e-25e8-4b08-b40b-d8d871dda591;" +
                "SubscriptionId=2c224e7e-3ef5-431d-a57b-e71f4662e3a6;" +
                "CertSubject=TestCertForAuthLib;" +
                "Environment=Prod;"
            )]
        public void CertAuthWithSPN(string cnnStr)
        {
            LiteralCnnString = cnnStr;
            ServiceClientCredentials svcClientCred = null;

            X509Certificate2 localCert = null;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certCol = store.Certificates;
                X509Certificate2Collection certsWithSubject = certCol.Find(X509FindType.FindBySubjectName, "TestCertForAuthLib", false);
                localCert = certsWithSubject[0];
            }
            finally
            {
                store.Close();
            }
            
            ActiveDirectoryServiceSettings aadServiceSettings = new ActiveDirectoryServiceSettings()
            {
                AuthenticationEndpoint = new Uri(CloudEndPoints.AADAuthUri.ToString() + TenantId),
                TokenAudience = CloudEndPoints.AADTokenAudienceUri
            };

            ClientAssertionCertificate certAssertion = new ClientAssertionCertificate(ClientId, localCert);

            svcClientCred = ApplicationTokenProvider.LoginSilentWithCertificateAsync(TenantId, certAssertion, aadServiceSettings).GetAwaiter().GetResult();
            Assert.NotNull(svcClientCred);
        }
    }
}
