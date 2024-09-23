// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Authorization;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Roles;
using Azure.Provisioning.ServiceBus;
using Azure.Provisioning.Storage;

namespace Azure.Provisioning.CloudMachine;

public class CloudMachineInfrastructure : Infrastructure
{
    private readonly string _name;
    private UserAssignedIdentity _identity;
    private StorageAccount _storage;
    private BlobService _blobs;
    private BlobContainer _container;
    private ServiceBusNamespace _serviceBusNamespace;
    private ServiceBusNamespaceAuthorizationRule _serviceBusNamespaceAuthorizationRule;
    private ServiceBusTopic _serviceBusTopic_main;
    private ServiceBusTopic _serviceBusTopic_app;
    private ServiceBusSubscription _serviceBusSubscription_main;
    private ServiceBusSubscription _serviceBusSubscription_app;
    private SystemTopic _eventGridTopic_Blobs;
    private SystemTopicEventSubscription _systemTopicEventSubscription;

    /// <summary>
    /// The common principalId parameter.
    /// </summary>
    public BicepParameter PrincipalIdParameter => new BicepParameter("principalId", typeof(string));

    /// <summary>
    /// The common principalType parameter.
    /// </summary>
    public BicepParameter PrincipalTypeParameter => new BicepParameter("principalType", typeof(string));

    /// <summary>
    /// The common principalName parameter.
    /// </summary>
    public BicepParameter PrincipalNameParameter => new BicepParameter("principalName", typeof(string));

    public CloudMachineInfrastructure(string name = "cm") : base(name!)
    {
        _name = name ?? "cm";
        _identity = new($"{_name}_identity");
        ManagedServiceIdentity managedServiceIdentity = new()
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
            UserAssignedIdentities = { { BicepFunction.Interpolate($"{_identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
        };

        _storage = StorageResources.CreateAccount($"{_name}_sa");
        _storage.Identity = managedServiceIdentity;

        _blobs = new($"{_name}_blobs")
        {
            Parent = _storage,
        };
        _container = new BlobContainer($"{_name}_container", "2023-01-01")
        {
            Parent = _blobs,
            Name = "default"
        };

        _serviceBusNamespace = new($"{_name}_sb")
        {
            Sku = new ServiceBusSku
            {
                Name = ServiceBusSkuName.Standard,
                Tier = ServiceBusSkuTier.Standard
            },
        };
        _serviceBusNamespaceAuthorizationRule = new($"{_name}_sb_auth_rule", "2021-11-01")
        {
            Parent = _serviceBusNamespace,
            Rights = [ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send, ServiceBusAccessRight.Manage]
        };
        _serviceBusTopic_main = new($"{_name}_sb_topic_main", "2021-11-01")
        {
            Parent = _serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = new StringLiteral("P14D"),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _serviceBusSubscription_main = new($"{_name}_sb_sub_main", "2021-11-01")
        {
            Parent = _serviceBusTopic_main,
            IsClientAffine = false,
            LockDuration = new StringLiteral("PT30S"),
            RequiresSession = false,
            DefaultMessageTimeToLive = new StringLiteral("P14D"),
            DeadLetteringOnFilterEvaluationExceptions = true,
            DeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 10,
            EnableBatchedOperations = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _serviceBusTopic_app = new($"{_name}_sb_topic_app", "2021-11-01")
        {
            Parent = _serviceBusNamespace,
            // Name = "default",
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = new StringLiteral("P14D"),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _serviceBusSubscription_app = new($"{_name}_sb_sub_app", "2021-11-01")
        {
            Parent = _serviceBusTopic_app,
            IsClientAffine = false,
            LockDuration = new StringLiteral("PT30S"),
            RequiresSession = false,
            DefaultMessageTimeToLive = new StringLiteral("P14D"),
            DeadLetteringOnFilterEvaluationExceptions = true,
            DeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 10,
            EnableBatchedOperations = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _eventGridTopic_Blobs = new($"{_name}_eg_blob", "2022-06-15")
        {
            TopicType = "Microsoft.Storage.StorageAccounts",
            Source = _storage.Id,
            Identity = managedServiceIdentity
        };
        _systemTopicEventSubscription = new($"{_name}_eg_blob_sub", "2022-06-15")
        {
            Parent = _eventGridTopic_Blobs,
            DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity
            {
                Identity = new EventSubscriptionIdentity
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = _identity.Id
                },
                Destination = new EventHubEventSubscriptionDestination
                {
                    ResourceId = _serviceBusTopic_main.Id
                }
            },
            Filter = new EventSubscriptionFilter
            {
                IncludedEventTypes =
                [
                    "Microsoft.Storage.BlobCreated",
                    "Microsoft.Storage.BlobDeleted",
                    "Microsoft.Storage.BlobRenamed"
                ],
                IsAdvancedFilteringOnArraysEnabled = true
            },
            EventDeliverySchema = EventDeliverySchema.EventGridSchema,
            RetryPolicy = new EventSubscriptionRetryPolicy
            {
                MaxDeliveryAttempts = 30,
                EventTimeToLiveInMinutes = 1440
            }
        };
    }

    public override ProvisioningPlan Build(ProvisioningContext? context = null)
    {
        // Always add a default location parameter.
        // azd assumes there will be a location parameter for every module.
        // The Infrastructure location resolver will resolve unset Location properties to this parameter.
        Add(new BicepParameter("location", typeof(string))
        {
            Description = "The location for the resource(s) to be deployed.",
            Value = BicepFunction.GetResourceGroup().Location
        });

        Add(PrincipalIdParameter);
        Add(PrincipalTypeParameter);
        Add(PrincipalNameParameter);

        Add(_identity);
        Add(_storage);
        Add(_storage.AssignRole(StorageBuiltInRole.StorageBlobDataContributor, RoleManagementPrincipalType.User, PrincipalIdParameter));
        Add(_storage.AssignRole(StorageBuiltInRole.StorageTableDataContributor, RoleManagementPrincipalType.User, PrincipalIdParameter));
        Add(_container);
        Add(_blobs);
        Add(_serviceBusNamespace);
        Add(_serviceBusNamespace.AssignRole(ServiceBusBuiltInRole.AzureServiceBusDataOwner, RoleManagementPrincipalType.User, PrincipalIdParameter));
        Add(_serviceBusNamespaceAuthorizationRule);
        Add(_serviceBusTopic_main);
        Add(_serviceBusTopic_app);
        Add(_serviceBusSubscription_main);
        Add(_serviceBusSubscription_app);

        // This is necessary until SystemTopic adds an AssignRole method.
        var role = ServiceBusBuiltInRole.AzureServiceBusDataOwner;
        RoleAssignment roleAssignment = new RoleAssignment(_eventGridTopic_Blobs.ResourceName + "_" + _identity.ResourceName + "_" + ServiceBusBuiltInRole.GetBuiltInRoleName(role));
        roleAssignment.Name = BicepFunction.CreateGuid(_eventGridTopic_Blobs.Id, _identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()));
        roleAssignment.Scope = new IdentifierExpression(_eventGridTopic_Blobs.ResourceName);
        roleAssignment.PrincipalType = RoleManagementPrincipalType.ServicePrincipal;
        roleAssignment.RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString());
        roleAssignment.PrincipalId = _identity.PrincipalId;
        Add(roleAssignment);
        Add(_systemTopicEventSubscription);
        Add(_eventGridTopic_Blobs);

        // Placeholders for now.
        Add(new BicepOutput($"storage_name", typeof(string)) { Value = _storage.Name });
        Add(new BicepOutput($"servicebus_name", typeof(string)) { Value = _serviceBusNamespace.Name });

        return base.Build(context);
    }
}
