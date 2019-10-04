using System.Linq;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using DeviceProvisioningServices.Tests.Helpers;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientCertificates : DeviceProvisioningTestBase
    {

        [Fact]
        public void CreateAndDelete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.Initialize(context);
                var testName = "unitTestingDPSCertificatesCreateAndDelete";
                var resourceGroup = this.GetResourceGroup(testName);
                var service = this.GetService(resourceGroup.Name, testName);

                //add a cert
                this.provisioningClient.DpsCertificate.CreateOrUpdate(testName,
                    testName, Constants.Certificate.Name,
                    new CertificateBodyDescription(Constants.Certificate.Content));

                var certificateList = this.provisioningClient.DpsCertificates.List(testName,
                    testName);

                Assert.Contains(certificateList.Value, x => x.Name == Constants.Certificate.Name);

                //verify certificate details
                var certificateDetails =
                    certificateList.Value.FirstOrDefault(x => x.Name == Constants.Certificate.Name);
                Assert.NotNull(certificateDetails);
                Assert.Equal(certificateDetails.Properties.Subject, Constants.Certificate.Subject);
                Assert.Equal(certificateDetails.Properties.Thumbprint, Constants.Certificate.Thumbprint);

                //can get a verification code
                var verificationCodeResponse =
                    this.provisioningClient.DpsCertificate.GenerateVerificationCode(certificateDetails.Name,
                        certificateDetails.Etag, resourceGroup.Name, service.Name);
                Assert.NotNull(verificationCodeResponse.Properties);
                Assert.False(string.IsNullOrEmpty(verificationCodeResponse.Properties.VerificationCode));

                //delete certificate
                this.provisioningClient.DpsCertificate.Delete(resourceGroup.Name, verificationCodeResponse.Etag, service.Name, Constants.Certificate.Name);
                certificateList = this.provisioningClient.DpsCertificates.List(testName,
                    testName);
                Assert.DoesNotContain(certificateList.Value, x => x.Name == Constants.Certificate.Name);
            }
        }
    }
}
