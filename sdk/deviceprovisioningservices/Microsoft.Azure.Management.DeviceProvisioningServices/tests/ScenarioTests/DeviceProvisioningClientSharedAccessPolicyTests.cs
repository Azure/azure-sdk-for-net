using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using DeviceProvisioningServices.Tests.Helpers;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientSharedAccessPolicyTests : DeviceProvisioningTestBase
    {
        [Fact]
        public void ListCreateDelete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.Initialize(context);
                var testName = "unitTestingDPSSharedAccessPoliciesListCreateDelete";
                var resourceGroup = this.GetResourceGroup(testName);
                var testedService = GetService(testName, testName);

                //verify owner has been created
                var ownerKey = this.provisioningClient.IotDpsResource.ListKeysForKeyName(
                    testedService.Name,
                    Constants.AccessKeyName, 
                    resourceGroup.Name);
                Assert.Equal(Constants.AccessKeyName, ownerKey.KeyName);

                //this access policy should not exist
                Assert.False(TryGetKeyByName(testName, out var accessPolicy));
                Assert.Null(accessPolicy);


                //new key
                testedService.Properties.AuthorizationPolicies =
                    new List<SharedAccessSignatureAuthorizationRuleAccessRightsDescription>(
                        new[]
                        {
                            ownerKey,
                            new SharedAccessSignatureAuthorizationRuleAccessRightsDescription(testName,
                                rights: "RegistrationStatusWrite"),
                        });

                var attempts = Constants.ArmAttemptLimit;
                var success = false;
                while (attempts > 0 && !success)
                {
                    try
                    {
                        this.provisioningClient.IotDpsResource.CreateOrUpdate(testName, testedService.Name,
                            testedService);
                        success = true;
                    }
                    catch
                    {
                        //Let ARM finish
                        System.Threading.Thread.Sleep(Constants.ArmAttemptWaitMS);
                        attempts--;
                    }
                }
                //this access policy exists now
                Assert.True(TryGetKeyByName(testName, out accessPolicy));
                Assert.NotNull(accessPolicy);

                testedService.Properties.AuthorizationPolicies =
                    new List<SharedAccessSignatureAuthorizationRuleAccessRightsDescription>(
                        new[]
                        {
                            ownerKey
                        });
                attempts = Constants.ArmAttemptLimit;
                success = false;
                while (attempts > 0 && !success)
                {
                    try
                    {
                        this.provisioningClient.IotDpsResource.CreateOrUpdate(testName, testedService.Name, testedService);
                        success = true;
                    }
                    catch
                    {
                        //Let ARM finish
                        System.Threading.Thread.Sleep(Constants.ArmAttemptWaitMS);

                        attempts--;
                    }
                }
                
                //the policy has been removed
                Assert.False(TryGetKeyByName(testName, out accessPolicy));
                Assert.Null(accessPolicy);
            }
        }

        private bool TryGetKeyByName(string testName, out SharedAccessSignatureAuthorizationRuleAccessRightsDescription accessPolicy)
        {
            try
            {
                accessPolicy = this.provisioningClient.IotDpsResource.ListKeysForKeyName(testName, testName, testName);
                return true;
            }
            catch (ErrorDetailsException ex)
            {
                accessPolicy = null;
                Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                return false;
            }
        }
    }
}
