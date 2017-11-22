using System.Linq;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.IotHub.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ProvisioningServices.Tests
{
    public class ProvisioningClientCertificates : DeviceProvisioningTestBase
    {

        [Fact(Skip = "DeviceProvisioningCertificatesList")]
        public void List()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);
                var testName = "unitTestingDPSCertificatesList";
                this.GetResourceGroup(testName);
                this.GetService(testName, testName);

                //get certificates list
                var certificateList = this.provisioningClient.DpsCertificates.List(testName,
                    testName);

                if (certificateList.Value.Any(x => x.Name == Constants.Certificate.Name))
                {
                    this.provisioningClient.DpsCertificate.Delete(testName,
                        testName, Constants.Certificate.Name);
                    certificateList =
                        this.provisioningClient.DpsCertificates.List(testName,
                            testName);
                    Assert.DoesNotContain(certificateList.Value, x => x.Name == Constants.Certificate.Name);
                }
            }
        }

        [Fact(Skip = "DeviceProvisioningCertificatesCreateAndDelete")]
        public void CreateAndDelete()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);
                var testName = "unitTestingDPSCertificatesCreateAndDelete";
                this.GetResourceGroup(testName);
                this.GetService(testName, testName);

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
                Assert.Equal(certificateDetails.Properties.Subject, Constants.Certificate.Subject);
                Assert.Equal(certificateDetails.Properties.Thumbprint, Constants.Certificate.Thumbprint);

                //delete certificate
                this.provisioningClient.DpsCertificate.Delete(testName,
                    testName, Constants.Certificate.Name);
                Assert.DoesNotContain(certificateList.Value, x => x.Name == Constants.Certificate.Name);
            }
        }
    }
}