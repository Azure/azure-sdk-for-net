// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CommvaultContentStore.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CommvaultContentStore.Tests
{
    public class CommvaultNamingTests
    {
        private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");

        [Test]
        public void BackupUsesExistingWireNames()
        {
            var backup = new BackupProtectionGroupContent(
                new[] { new CommvaultVirtualMachineReference("vm-guid") },
                new CommvaultBackupConfiguration("nightly", true, false, true)
                {
                    BackupLevel = CommvaultBackupLevel.SyntheticFull
                });

            using JsonDocument document = Serialize(backup);
            JsonElement root = document.RootElement;
            Assert.That(root.GetProperty("vmList")[0].GetProperty("vmGuid").GetString(), Is.EqualTo("vm-guid"));
            JsonElement options = root.GetProperty("backupOptions");
            Assert.That(options.GetProperty("backupLevel").GetString(), Is.EqualTo("SYNTHETIC_FULL"));
            Assert.That(options.GetProperty("backupCopyImmediately").GetBoolean(), Is.True);
            Assert.That(options.GetProperty("runSnapShotBackup").GetBoolean(), Is.False);
            Assert.That(options.GetProperty("notifyUserOnJobCompletion").GetBoolean(), Is.True);
        }

        [Test]
        public void RestoreVirtualMachinesRoundTripUsingExistingWireNames()
        {
            var restore = new RestoreProtectedItemContent(false, new[]
            {
                new CommvaultVirtualMachineRestoreSettings("source-vm", "storage")
                {
                    ResourceGroupName = "target-rg",
                    VirtualNetworkId = "target-network",
                    ShouldPowerOnVirtualMachineAfterRestore = true
                }
            });
            BinaryData data = ModelReaderWriter.Write(restore, WireOptions, AzureResourceManagerCommvaultContentStoreContext.Default);

            using JsonDocument document = JsonDocument.Parse(data);
            JsonElement vm = document.RootElement.GetProperty("vmDestinationInfo").GetProperty("vmInfoList")[0];
            Assert.That(vm.GetProperty("sourceVmGuid").GetString(), Is.EqualTo("source-vm"));
            Assert.That(vm.GetProperty("resourceGroup").GetString(), Is.EqualTo("target-rg"));
            Assert.That(vm.GetProperty("networkId").GetString(), Is.EqualTo("target-network"));
            Assert.That(vm.GetProperty("powerOnVmAfterRestore").GetBoolean(), Is.True);

            RestoreProtectedItemContent result = ModelReaderWriter.Read<RestoreProtectedItemContent>(
                data, WireOptions, AzureResourceManagerCommvaultContentStoreContext.Default);
            Assert.That(result.VirtualMachines, Has.Count.EqualTo(1));
            Assert.That(result.VirtualMachines[0].SourceVirtualMachineGuid, Is.EqualTo("source-vm"));
            Assert.That(result.VirtualMachines[0].VirtualNetworkId, Is.EqualTo("target-network"));
        }

        [Test]
        public void MatchCriteriaRoundTripsExistingWireNamesAndValues()
        {
            var selection = new ProtectionGroupResourceSelection
            {
                ManuallySelectedItems = { "vm-one" },
                MatchRules = new ProtectionGroupResourceMatchCriteria(
                    new[] { new ProtectionGroupRule(ProtectionGroupRuleProperty.Name, CommvaultMatchOperator.DoesNotContain, "test") },
                    ProtectionGroupMatchType.Any)
            };
            BinaryData data = ModelReaderWriter.Write(selection, WireOptions, AzureResourceManagerCommvaultContentStoreContext.Default);

            using JsonDocument document = JsonDocument.Parse(data);
            JsonElement root = document.RootElement;
            Assert.That(root.GetProperty("manual")[0].GetString(), Is.EqualTo("vm-one"));
            JsonElement matchRules = root.GetProperty("matchRules");
            Assert.That(matchRules.GetProperty("matchType").GetString(), Is.EqualTo("any"));
            Assert.That(matchRules.GetProperty("rules")[0].GetProperty("operator").GetString(), Is.EqualTo("doesNotContains"));

            ProtectionGroupResourceSelection result = ModelReaderWriter.Read<ProtectionGroupResourceSelection>(
                data, WireOptions, AzureResourceManagerCommvaultContentStoreContext.Default);
            Assert.That(result.MatchRules.MatchType, Is.EqualTo(ProtectionGroupMatchType.Any));
            Assert.That(result.MatchRules.Rules[0].Operator, Is.EqualTo(CommvaultMatchOperator.DoesNotContain));
        }

        [Test]
        public void RolePrincipalsUseExistingWireNamesAndValues()
        {
            var assignment = new CommvaultRoleAssignment(CommvaultRoleName.BackupAdministrator, new[]
            {
                new CommvaultRolePrincipal { Id = "principal", PrincipalType = CommvaultRolePrincipalType.User }
            });

            using JsonDocument document = Serialize(assignment);
            JsonElement root = document.RootElement;
            Assert.That(root.GetProperty("roleName").GetString(), Is.EqualTo("BackupAdmin"));
            Assert.That(root.GetProperty("entities")[0].GetProperty("entityType").GetString(), Is.EqualTo("User"));
        }

        [TestCase("https://login.example.com/sso")]
        [TestCase("o")]
        [TestCase("")]
        public void SingleSignOnValueRoundTripsAsAString(string value)
        {
            var properties = ModelReaderWriter.Read<CloudAccountProperties>(
                BinaryData.FromString($$$"""{"ssoUrl":"{{{value}}}","marketplace":{"offerDetails":{}},"user":{}}"""),
                ModelReaderWriterOptions.Json, AzureResourceManagerCommvaultContentStoreContext.Default);
            Assert.That(properties.SingleSignOnUriString, Is.EqualTo(value));

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(
                properties, ModelReaderWriterOptions.Json, AzureResourceManagerCommvaultContentStoreContext.Default));
            Assert.That(document.RootElement.GetProperty("ssoUrl").GetString(), Is.EqualTo(value));
        }

        [Test]
        public void CompanyWebsiteRemainsAFreeFormString()
        {
            var company = new CommvaultCompanyProfile { Website = "contoso.com" };
            using JsonDocument document = Serialize(company);
            Assert.That(document.RootElement.GetProperty("website").GetString(), Is.EqualTo("contoso.com"));
        }

        [Test]
        public void IdentityPatchCanOmitIdentityType()
        {
            const string identityId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var patch = new CloudAccountPatch { Identity = new CloudAccountIdentityPatch() };
            patch.Identity.UserAssignedIdentities.Add(identityId, new UserAssignedIdentity());

            using JsonDocument document = Serialize(patch);
            JsonElement identity = document.RootElement.GetProperty("identity");
            Assert.That(identity.TryGetProperty("type", out _), Is.False);
            Assert.That(identity.GetProperty("userAssignedIdentities").TryGetProperty(identityId, out _), Is.True);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task GetLatestLinkedSaaSUsesExistingPostRoute(bool isAsync)
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000000";
            const string accountId = "/subscriptions/" + subscriptionId + "/resourceGroups/rg/providers/Commvault.ContentStore/cloudAccounts/account";
            const string saasId = "/subscriptions/" + subscriptionId + "/resourceGroups/rg/providers/Microsoft.SaaS/resources/saas";
            var transport = new MockTransport(new MockResponse(200).SetContent(
                $$"""{"saaSResourceId":"{{saasId}}","isHiddenSaaS":true}"""));
            var client = new ArmClient(new MockCredential(), subscriptionId, new ArmClientOptions { Transport = transport });
            CloudAccountResource account = client.GetCloudAccountResource(new ResourceIdentifier(accountId));

            Response<LatestLinkedSaaSResult> response = isAsync
                ? await account.GetLatestLinkedSaaSAsync()
                : account.GetLatestLinkedSaaS();

            Assert.That(transport.SingleRequest.Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(transport.SingleRequest.Uri.ToString(), Is.EqualTo(
                $"https://management.azure.com{accountId}/latestLinkedSaaS?api-version=2026-11-03"));
            Assert.That(response.Value.SaaSResourceId.ToString(), Is.EqualTo(saasId));
            Assert.That(response.Value.IsHiddenSaaS, Is.True);
        }

        private static JsonDocument Serialize<T>(T model) where T : IPersistableModel<T>
        {
            return JsonDocument.Parse(ModelReaderWriter.Write(model, WireOptions, AzureResourceManagerCommvaultContentStoreContext.Default));
        }
    }
}
