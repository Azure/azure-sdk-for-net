using ManagedServiceIdentity.Tests.Helpers;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.ManagedServiceIdentity.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ManagedServiceIdentity.Tests.Tests
{
    public class IdentityTests : IDisposable
    {
        private string ResourceGroupName = "SDKTest";
        private string ExplicitIdentityType = "Microsoft.ManagedIdentity/userAssignedIdentities";
        private string CanaryCentralRegion = "centraluseuap";
        private string FirstTagKey = "firstTag";
        private string SecondTagKey = "secondTag";
        private string firstIdentityName = "testIdentity1";
        private string secondIdentityName = "testIdentity2";

        public void Dispose()
        {
            var handler = new RecordedDelegatingHandler { IsPassThrough = true };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var msiMgmtClient = context.GetServiceClient<ManagedServiceIdentityClient>(handlers: handler);
                msiMgmtClient.UserAssignedIdentities.Delete(ResourceGroupName, firstIdentityName);
                msiMgmtClient.UserAssignedIdentities.Delete(ResourceGroupName, secondIdentityName);
            }
        }

        [Fact]
        public async Task TestIdentityCRUD()
        {
            var handler = new RecordedDelegatingHandler { IsPassThrough = true };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var msiMgmtClient = context.GetServiceClient<ManagedServiceIdentityClient>(handlers: handler);

                string firstTagValue = "first tag value";
                string secondTagValue = "second tag value";
                string updatedFirstTagValue = "updated first tag value";
                string updatedSecondTagValue = "updated second tag value";

                /*-------------PUT-------------*/
                // Create new identities
                var identityParameters = new Identity(location: CanaryCentralRegion, tags: new Dictionary<string, string>() { { FirstTagKey, firstTagValue }, { SecondTagKey, secondTagValue } });
                var createResponse1 = await msiMgmtClient.UserAssignedIdentities.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, firstIdentityName, identityParameters);
                Assert.Equal(HttpStatusCode.Created, createResponse1.Response.StatusCode);
                VerifyIdentity(createResponse1.Body, msiMgmtClient.SubscriptionId, firstIdentityName, CanaryCentralRegion, firstTagValue, secondTagValue);

                AzureOperationResponse<Identity> createResponse2 = await msiMgmtClient.UserAssignedIdentities.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, secondIdentityName, identityParameters);
                Assert.Equal(HttpStatusCode.Created, createResponse2.Response.StatusCode);
                VerifyIdentity(createResponse2.Body, msiMgmtClient.SubscriptionId, secondIdentityName, CanaryCentralRegion, firstTagValue, secondTagValue);

                // Put on existing identity
                var createResponse3 = await msiMgmtClient.UserAssignedIdentities.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, firstIdentityName, identityParameters);
                Assert.Equal(HttpStatusCode.OK, createResponse3.Response.StatusCode);
                VerifyIdentity(createResponse3.Body, msiMgmtClient.SubscriptionId, firstIdentityName, CanaryCentralRegion, firstTagValue, secondTagValue);

                /*-------------GET-------------*/
                // Get the created identities
                var getResponse1 = await msiMgmtClient.UserAssignedIdentities.GetWithHttpMessagesAsync(ResourceGroupName, firstIdentityName);
                Assert.Equal(HttpStatusCode.OK, getResponse1.Response.StatusCode);
                VerifyIdentity(getResponse1.Body, msiMgmtClient.SubscriptionId, firstIdentityName, CanaryCentralRegion, firstTagValue, secondTagValue);

                var getResponse2 = await msiMgmtClient.UserAssignedIdentities.GetWithHttpMessagesAsync(ResourceGroupName, secondIdentityName);
                Assert.Equal(HttpStatusCode.OK, getResponse2.Response.StatusCode);
                VerifyIdentity(getResponse2.Body, msiMgmtClient.SubscriptionId, secondIdentityName, CanaryCentralRegion, firstTagValue, secondTagValue);

                /*-------------PATCH-------------*/
                var updateParameters = new Identity(location: CanaryCentralRegion, tags: new Dictionary<string, string>() { { FirstTagKey, updatedFirstTagValue }, { SecondTagKey, updatedSecondTagValue } });
                var updateResponse = await msiMgmtClient.UserAssignedIdentities.UpdateWithHttpMessagesAsync(ResourceGroupName, firstIdentityName, updateParameters);
                Assert.Equal(HttpStatusCode.OK, updateResponse.Response.StatusCode);
                VerifyIdentity(updateResponse.Body, msiMgmtClient.SubscriptionId, firstIdentityName, CanaryCentralRegion, updatedFirstTagValue, updatedSecondTagValue);

                /*-------------List by ResourceGroup-------------*/
                var listResourceGroupResponse = await msiMgmtClient.UserAssignedIdentities.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listResourceGroupResponse.Response.StatusCode);
                string[] identityNames = new string[] { firstIdentityName, secondIdentityName };
                VerifyIdentityCollection(listResourceGroupResponse.Body, identityNames);

                /*-------------DELETE-------------*/
                var deleteResponse1 = await msiMgmtClient.UserAssignedIdentities.DeleteWithHttpMessagesAsync(ResourceGroupName, firstIdentityName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse1.Response.StatusCode);
                // Delete identity that does not exist
                var deleteResponse2 = await msiMgmtClient.UserAssignedIdentities.DeleteWithHttpMessagesAsync(ResourceGroupName, firstIdentityName);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse2.Response.StatusCode);

                var deleteResponse3 = await msiMgmtClient.UserAssignedIdentities.DeleteWithHttpMessagesAsync(ResourceGroupName, secondIdentityName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse3.Response.StatusCode);
                // Delete identity that does not exist
                var deleteResponse4 = await msiMgmtClient.UserAssignedIdentities.DeleteWithHttpMessagesAsync(ResourceGroupName, secondIdentityName);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse4.Response.StatusCode);
            }
        }

        [Fact]
        public async Task TestOperationsApi()
        {
            var handler = new RecordedDelegatingHandler { IsPassThrough = true };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var msiMgmtClient = context.GetServiceClient<ManagedServiceIdentityClient>(handlers: handler);
                var operationsResult = await msiMgmtClient.Operations.ListWithHttpMessagesAsync();
                Assert.Equal(HttpStatusCode.OK, operationsResult.Response.StatusCode);
                Assert.NotNull(operationsResult.Body);
            }
        }

        private void VerifyIdentityCollection(IPage<Identity> identities, string[] identityNames)
        {
            int identityCount = 0;
            foreach (Identity identity in identities)
            {
                identityCount++;
                Assert.Contains(identityNames, x => x.Equals(identity.Name));
            }
            Assert.Equal(2, identityCount);
        }

        private void VerifyIdentity(Identity identity, string subscriptionId, string identityName, string location, string expectedFirstTagValue, string expectedSecondTagValue)
        {
            string expectedIdentityId = $"/subscriptions/{subscriptionId}/resourcegroups/{ResourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}";
            Assert.Equal(expectedIdentityId, identity.Id);
            Assert.Equal(location, identity.Location);
            Assert.Equal(identityName, identity.Name);
            Assert.NotNull(identity.ClientId);
            Assert.Null(identity.ClientSecretUrl);
            Assert.NotNull(identity.PrincipalId);
            Assert.NotNull(identity.TenantId);
            string firstTagValue, secondTagValue;
            identity.Tags.TryGetValue(FirstTagKey, out firstTagValue);
            identity.Tags.TryGetValue(SecondTagKey, out secondTagValue);
            Assert.Equal(expectedFirstTagValue, firstTagValue);
            Assert.Equal(expectedSecondTagValue, secondTagValue);
            Assert.Equal(ExplicitIdentityType, identity.Type);
        }
    }
}

