using DeviceProvisioningServices.Tests.Helpers;
using FluentAssertions;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientCertificates : DeviceProvisioningTestBase
    {
        [Fact]
        public async Task CreateAndDelete()
        {
            using MockContext context = MockContext.Start(GetType());
            Initialize(context);
            var testName = "unitTestingDPSCertificatesCreateAndDelete";
            ResourceGroup resourceGroup = await GetResourceGroupAsync(testName).ConfigureAwait(false);
            ProvisioningServiceDescription service = await GetServiceAsync(resourceGroup.Name, testName).ConfigureAwait(false);

            //add a cert
            await _provisioningClient.DpsCertificate
                .CreateOrUpdateAsync(
                    testName,
                    testName,
                    Constants.Certificate.Name,
                    null,
                    Constants.Certificate.Content)
                .ConfigureAwait(false);

            CertificateListDescription certificateList = await _provisioningClient.DpsCertificate
                .ListAsync(
                    testName,
                    testName)
                .ConfigureAwait(false);

            certificateList.Value.Should().Contain(x => x.Name == Constants.Certificate.Name);

            // verify certificate details
            var certificateDetails = certificateList.Value.FirstOrDefault(x => x.Name == Constants.Certificate.Name);
            certificateDetails.Should().NotBeNull();
            certificateDetails.Properties.Subject.Should().Be(Constants.Certificate.Subject);
            certificateDetails.Properties.Thumbprint.Should().Be(Constants.Certificate.Thumbprint);

            // can get a verification code
            var verificationCodeResponse = await _provisioningClient.DpsCertificate
                .GenerateVerificationCodeAsync(
                    certificateDetails.Name,
                    certificateDetails.Etag,
                    resourceGroup.Name,
                    service.Name)
                .ConfigureAwait(false);
            verificationCodeResponse.Properties.Should().NotBeNull();
            verificationCodeResponse.Properties.VerificationCode.Should().NotBeNullOrEmpty();

            // delete certificate
            await _provisioningClient.DpsCertificate
                .DeleteAsync(
                    resourceGroup.Name,
                    verificationCodeResponse.Etag,
                    service.Name,
                    Constants.Certificate.Name)
                .ConfigureAwait(false);

            certificateList = await _provisioningClient.DpsCertificate
                .ListAsync(testName, testName)
                .ConfigureAwait(false);
            certificateList.Value.Should().NotContain(Constants.Certificate.Name);
        }
    }
}
