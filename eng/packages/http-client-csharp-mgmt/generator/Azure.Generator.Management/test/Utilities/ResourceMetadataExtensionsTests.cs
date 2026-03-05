// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Utilities;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    public class ResourceMetadataExtensionsTests
    {
        [Test]
        public void CategorizeMethods_ListWithMatchingParentScope_GoesToCollection()
        {
            // Standard case: list operation's resourceScope matches parentResourceId
            var resourceIdPattern = "/subscriptions/{subscriptionId}/providers/Microsoft.Support/supportTickets/{supportTicketName}/chatTranscripts/{chatTranscriptName}";
            var parentResourceId = "/subscriptions/{subscriptionId}/providers/Microsoft.Support/supportTickets/{supportTicketName}";
            var listOperationPath = "/subscriptions/{subscriptionId}/providers/Microsoft.Support/supportTickets/{supportTicketName}/chatTranscripts";

            var listMethod = new ResourceMethod(
                ResourceOperationKind.List,
                InputMethod: null!,
                OperationPath: listOperationPath,
                OperationScope: ResourceScope.Subscription,
                ResourceScope: parentResourceId,
                InputClient: null!);

            var metadata = new ResourceMetadata(
                ResourceIdPattern: resourceIdPattern,
                ResourceName: "ChatTranscript",
                ResourceType: "Microsoft.Support/supportTickets/chatTranscripts",
                ResourceModel: null!,
                ResourceScope: ResourceScope.Subscription,
                Methods: [listMethod],
                SingletonResourceName: null,
                ParentResourceId: parentResourceId,
                ChildResourceIds: []);

            var result = metadata.CategorizeMethods();

            Assert.AreEqual(1, result.MethodsInCollection.Count, "List method should be routed to collection");
            Assert.AreEqual(0, result.MethodsInExtension.Count, "No methods should be routed to extension");
        }

        [Test]
        public void CategorizeMethods_ListWithCrossScopeParent_GoesToCollection()
        {
            // Cross-scope case: resource is tenant-scoped but parent is subscription-scoped.
            // The list operation's resourceScope (tenant) doesn't match parentResourceId (subscription),
            // but the list path structurally IS "list children of parent" for this resource.
            var resourceIdPattern = "/providers/Microsoft.Support/supportTickets/{supportTicketName}/chatTranscripts/{chatTranscriptName}";
            var parentResourceId = "/subscriptions/{subscriptionId}/providers/Microsoft.Support/supportTickets/{supportTicketName}";
            var listOperationPath = "/providers/Microsoft.Support/supportTickets/{supportTicketName}/chatTranscripts";

            // The emitter resolves resourceScope to the tenant-scoped support ticket
            var tenantScopedParent = "/providers/Microsoft.Support/supportTickets/{supportTicketName}";

            var listMethod = new ResourceMethod(
                ResourceOperationKind.List,
                InputMethod: null!,
                OperationPath: listOperationPath,
                OperationScope: ResourceScope.Tenant,
                ResourceScope: tenantScopedParent,
                InputClient: null!);

            var metadata = new ResourceMetadata(
                ResourceIdPattern: resourceIdPattern,
                ResourceName: "SupportTicketNoSubChatTranscript",
                ResourceType: "Microsoft.Support/supportTickets/chatTranscripts",
                ResourceModel: null!,
                ResourceScope: ResourceScope.Tenant,
                Methods: [listMethod],
                SingletonResourceName: null,
                ParentResourceId: parentResourceId,
                ChildResourceIds: []);

            var result = metadata.CategorizeMethods();

            Assert.AreEqual(1, result.MethodsInCollection.Count, "Cross-scope list method should be routed to collection");
            Assert.AreEqual(0, result.MethodsInExtension.Count, "Cross-scope list method should NOT be routed to extension");
        }

        [Test]
        public void CategorizeMethods_ListWithDifferentResourceType_GoesToExtension()
        {
            // A list operation for a different resource type should still go to extension
            var resourceIdPattern = "/providers/Microsoft.Support/supportTickets/{supportTicketName}/chatTranscripts/{chatTranscriptName}";
            var parentResourceId = "/subscriptions/{subscriptionId}/providers/Microsoft.Support/supportTickets/{supportTicketName}";

            // This list operation lists something else entirely (e.g., communications, not chatTranscripts)
            var listOperationPath = "/providers/Microsoft.Support/supportTickets/{supportTicketName}/communications";
            var tenantScopedParent = "/providers/Microsoft.Support/supportTickets/{supportTicketName}";

            var listMethod = new ResourceMethod(
                ResourceOperationKind.List,
                InputMethod: null!,
                OperationPath: listOperationPath,
                OperationScope: ResourceScope.Tenant,
                ResourceScope: tenantScopedParent,
                InputClient: null!);

            var metadata = new ResourceMetadata(
                ResourceIdPattern: resourceIdPattern,
                ResourceName: "SupportTicketNoSubChatTranscript",
                ResourceType: "Microsoft.Support/supportTickets/chatTranscripts",
                ResourceModel: null!,
                ResourceScope: ResourceScope.Tenant,
                Methods: [listMethod],
                SingletonResourceName: null,
                ParentResourceId: parentResourceId,
                ChildResourceIds: []);

            var result = metadata.CategorizeMethods();

            Assert.AreEqual(0, result.MethodsInCollection.Count, "List for different resource type should NOT go to collection");
            Assert.AreEqual(1, result.MethodsInExtension.Count, "List for different resource type should go to extension");
        }
    }
}
