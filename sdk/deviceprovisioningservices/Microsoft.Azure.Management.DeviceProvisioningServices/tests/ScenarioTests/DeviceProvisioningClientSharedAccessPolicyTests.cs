using DeviceProvisioningServices.Tests.Helpers;
using FluentAssertions;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientSharedAccessPolicyTests : DeviceProvisioningTestBase
    {
        [Fact]
        public async Task ListCreateDelete()
        {
            using var context = MockContext.Start(GetType());
            Initialize(context);
            var testName = "unitTestingDPSSharedAccessPoliciesListCreateDelete";
            ResourceGroup resourceGroup = await GetResourceGroupAsync(testName).ConfigureAwait(false);
            ProvisioningServiceDescription testedService = await GetServiceAsync(testName, testName).ConfigureAwait(false);

            // verify owner has been created
            var ownerKey = await _provisioningClient.IotDpsResource
                .ListKeysForKeyNameAsync(
                    testedService.Name,
                    Constants.AccessKeyName,
                    resourceGroup.Name)
                .ConfigureAwait(false);
            ownerKey.KeyName.Should().Be(Constants.AccessKeyName);

            // this access policy should not exist
            var keyInfo = await TryGetKeyByNameAsync(testName).ConfigureAwait(false);
            keyInfo.hasKey.Should().BeFalse();
            keyInfo.accessPolicy.Should().BeNull();

            // new key
            testedService.Properties.AuthorizationPolicies =
                new List<SharedAccessSignatureAuthorizationRuleAccessRightsDescription>(
                    new[]
                    {
                        ownerKey,
                        new SharedAccessSignatureAuthorizationRuleAccessRightsDescription(
                            testName,
                            rights: "RegistrationStatusWrite"),
                    });

            var attempts = Constants.ArmAttemptLimit;
            while (attempts > 0)
            {
                try
                {
                    await _provisioningClient.IotDpsResource
                        .CreateOrUpdateAsync(testName, testedService.Name, testedService)
                        .ConfigureAwait(false);
                    break;
                }
                catch
                {
                    // Let ARM finish
                    await Task.Delay(Constants.ArmAttemptWaitMs).ConfigureAwait(false);
                    attempts--;
                }
            }

            // this access policy exists now
            keyInfo = await TryGetKeyByNameAsync(testName).ConfigureAwait(false);
            keyInfo.hasKey.Should().BeTrue();
            keyInfo.accessPolicy.Should().NotBeNull();

            testedService.Properties.AuthorizationPolicies =
                new List<SharedAccessSignatureAuthorizationRuleAccessRightsDescription>(
                    new[]
                    {
                        ownerKey,
                    });
            attempts = Constants.ArmAttemptLimit;
            while (attempts > 0)
            {
                try
                {
                    await _provisioningClient.IotDpsResource
                        .CreateOrUpdateAsync(testName, testedService.Name, testedService)
                        .ConfigureAwait(false);
                    break;
                }
                catch
                {
                    // Let ARM finish
                    await Task.Delay(Constants.ArmAttemptWaitMs).ConfigureAwait(false);

                    attempts--;
                }
            }

            // the policy has been removed
            keyInfo = await TryGetKeyByNameAsync(testName).ConfigureAwait(false);
            keyInfo.hasKey.Should().BeFalse();
            keyInfo.accessPolicy.Should().BeNull();
        }

        private async Task<(bool hasKey, SharedAccessSignatureAuthorizationRuleAccessRightsDescription accessPolicy)> TryGetKeyByNameAsync(string testName)
        {
            try
            {
                SharedAccessSignatureAuthorizationRuleAccessRightsDescription accessPolicy = await _provisioningClient.IotDpsResource
                    .ListKeysForKeyNameAsync(testName, testName, testName)
                    .ConfigureAwait(false);
                return (true, accessPolicy);
            }
            catch (ErrorDetailsException ex)
            {
                ex.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
                return (false, null);
            }
        }
    }
}
