﻿using System.Linq;
using Microsoft.Azure.Management.ProvisioningServices;
using Microsoft.Azure.Management.ProvisioningServices.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ProvisioningServices.Tests.Helpers;
using Xunit;

namespace ProvisioningServices.Tests.ScenarioTests
{
    public class ProvisioningClientCertificates : DeviceProvisioningTestBase
    {

        [Fact]
        public void CreateAndDelete()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
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

                //verify ownership
                Assert.False(certificateDetails.Properties.IsVerified);
                var verificationCodeResponse =
                    this.provisioningClient.DpsCertificate.GenerateVerificationCode(certificateDetails.Name,
                        certificateDetails.Etag, resourceGroup.Name, service.Name);
                Assert.NotNull(verificationCodeResponse.Properties);
                Assert.False(string.IsNullOrEmpty(verificationCodeResponse.Properties.VerificationCode));

                var verificationRequest = new VerificationCodeRequest(verificationCodeResponse.Properties.VerificationCode);
                var verificationResponse = this.provisioningClient.DpsCertificate.VerifyCertificate(certificateDetails.Name,
                    verificationCodeResponse.Etag, verificationRequest, resourceGroup.Name, service.Name);
                Assert.True(verificationResponse.Properties.IsVerified);

                //verify the cert is now showing verified
                certificateDetails =
                    certificateList.Value.FirstOrDefault(x => x.Name == Constants.Certificate.Name);
                Assert.True(certificateDetails.Properties.IsVerified);

                //delete certificate
                this.provisioningClient.DpsCertificate.Delete(resourceGroup.Name, certificateDetails.Etag, service.Name, Constants.Certificate.Name);
                certificateList = this.provisioningClient.DpsCertificates.List(testName,
                    testName);
                Assert.DoesNotContain(certificateList.Value, x => x.Name == Constants.Certificate.Name);
            }
        }
    }
}