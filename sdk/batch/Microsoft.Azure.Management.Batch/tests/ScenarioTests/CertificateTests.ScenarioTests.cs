using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using System.Threading.Tasks;
using Xunit;


namespace Batch.Tests.ScenarioTests
{
    public class CertificateTests : BatchScenarioTestBase
    {
        [Fact]
        public async Task BatchCertificateEndToEndAsync()
        {
            using (MockContext context = StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                string resourceGroupName = TestUtilities.GenerateName();
                string batchAccountName = TestUtilities.GenerateName();
                string batchCertName = "SHA1-cff2ab63c8c955aaf71989efa641b906558d9fb7";

                ResourceGroup group = new ResourceGroup(this.Location);
                await this.ResourceManagementClient.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, group);

                // Create an account
                BatchAccountCreateParameters createParams = new BatchAccountCreateParameters(this.Location);
                await this.BatchManagementClient.BatchAccount.CreateAsync(resourceGroupName, batchAccountName, createParams);

                try
                {
                    // Create a certificate
                    CertificateCreateOrUpdateParameters param = new CertificateCreateOrUpdateParameters("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");
                    param.Format = CertificateFormat.Pfx;
                    param.Password = "nodesdk";
                    param.Thumbprint = "cff2ab63c8c955aaf71989efa641b906558d9fb7";
                    param.ThumbprintAlgorithm = "sha1";

                    var certResponse = await this.BatchManagementClient.Certificate.CreateAsync(resourceGroupName, batchAccountName, batchCertName, param);
                    Assert.Equal("CFF2AB63C8C955AAF71989EFA641B906558D9FB7", certResponse.Thumbprint);
                    var referenceId =
                        $"/subscriptions/{this.BatchManagementClient.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{batchAccountName}/certificates/{batchCertName.ToUpperInvariant()}";
                    Assert.Equal(referenceId, certResponse.Id);
                    Assert.Equal(CertificateProvisioningState.Succeeded, certResponse.ProvisioningState);
                    Assert.Equal("SHA1", certResponse.ThumbprintAlgorithm);
                    Assert.Equal(CertificateFormat.Pfx, certResponse.Format);

                    // List the certificates
                    var certs = await this.BatchManagementClient.Certificate.ListByBatchAccountAsync(resourceGroupName, batchAccountName);
                    Assert.Single(certs);

                    // Get the cert
                    var cert = await this.BatchManagementClient.Certificate.GetAsync(resourceGroupName, batchAccountName, batchCertName);
                    Assert.Equal("CFF2AB63C8C955AAF71989EFA641B906558D9FB7", cert.Thumbprint);
                    Assert.Equal(referenceId, cert.Id);
                    Assert.Equal(CertificateProvisioningState.Succeeded, cert.ProvisioningState);
                    Assert.Equal("SHA1", cert.ThumbprintAlgorithm);
                    Assert.Equal(CertificateFormat.Pfx, cert.Format);
                    Assert.Null(cert.DeleteCertificateError);

                    // Update the cert
                    param = new CertificateCreateOrUpdateParameters("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");
                    param.Password = "nodesdk";
                    certResponse = await this.BatchManagementClient.Certificate.UpdateAsync(resourceGroupName, batchAccountName, batchCertName, param);
                    Assert.Equal(referenceId, certResponse.Id);

                    // Cancel the deletetion
                    await this.BatchManagementClient.Certificate.CancelDeletionAsync(resourceGroupName, batchAccountName, batchCertName);

                    // Delete the certificate
                    try
                    {
                        await this.BatchManagementClient.Certificate.DeleteAsync(resourceGroupName, batchAccountName, batchCertName);
                    }
                    catch (CloudException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }

                    // Verify certificate was deleted. A GET operation will return a 404 error and result in an exception
                    try
                    {
                        await this.BatchManagementClient.Certificate.GetAsync(resourceGroupName, batchAccountName, batchCertName);
                    }
                    catch (CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }

                }
                finally
                {
                    // Clean up
                    await this.BatchManagementClient.BatchAccount.DeleteAsync(resourceGroupName, batchAccountName);
                    await this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroupName);
                }
            }
        }
    }
}
