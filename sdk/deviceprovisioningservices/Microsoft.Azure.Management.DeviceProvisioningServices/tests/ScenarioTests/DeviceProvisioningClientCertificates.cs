using DeviceProvisioningServices.Tests.Helpers;
using FluentAssertions;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
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
            ResourceGroup rg = await GetResourceGroupAsync(testName).ConfigureAwait(false);
            ProvisioningServiceDescription service = await GetServiceAsync(testName, rg.Name).ConfigureAwait(false);
            
            //add a cert
            await _provisioningClient.DpsCertificate
                .CreateOrUpdateAsync(
                    rg.Name,
                    testName,
                    Constants.Certificate.Name,
                    null,
                    new CertificateProperties(
                        Constants.Certificate.Subject,
                        null, Constants.Certificate.Thumbprint,
                        null, 
                        Convert.FromBase64String(Constants.Certificate.Content),
                        null,
                        null))
                .ConfigureAwait(false);

            CertificateListDescription certificateList = await _provisioningClient.DpsCertificate
                .ListAsync(rg.Name, testName)
                .ConfigureAwait(false);

            certificateList.Value.Should().Contain(x => x.Name == Constants.Certificate.Name);

            // verify certificate details
            CertificateResponse certificateDetails = certificateList.Value.FirstOrDefault(x => x.Name == Constants.Certificate.Name);
            certificateDetails.Should().NotBeNull();
            certificateDetails.Properties.Subject.Should().Be(Constants.Certificate.Subject);
            certificateDetails.Properties.Thumbprint.Should().Be(Constants.Certificate.Thumbprint);

            // can get a verification code
            VerificationCodeResponse verificationCodeResponse = await _provisioningClient.DpsCertificate
                .GenerateVerificationCodeAsync(
                    certificateDetails.Name,
                    certificateDetails.Etag,
                    rg.Name,
                    service.Name)
                .ConfigureAwait(false);
            verificationCodeResponse.Properties.Should().NotBeNull();
            verificationCodeResponse.Properties.VerificationCode.Should().NotBeNullOrEmpty();

            // delete certificate
            await _provisioningClient.DpsCertificate
                .DeleteAsync(
                    rg.Name,
                    verificationCodeResponse.Etag,
                    service.Name,
                    Constants.Certificate.Name)
                .ConfigureAwait(false);

            certificateList = await _provisioningClient.DpsCertificate
                .ListAsync(rg.Name, testName)
                .ConfigureAwait(false);
            certificateList.Value.Should().NotContain(x => x.Name == Constants.Certificate.Name);
        }
    }
}
