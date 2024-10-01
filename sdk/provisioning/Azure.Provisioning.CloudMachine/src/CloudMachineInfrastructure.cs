// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.CloudMachine;
using System.IO;
using System;
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
    private readonly string _cmid;
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
    public ProvisioningParameter PrincipalIdParameter => new ProvisioningParameter("principalId", typeof(string));

    ///// <summary>
    ///// The common principalType parameter.
    ///// </summary>
    //public ProvisioningParameter PrincipalTypeParameter => new BicepParameter("principalType", typeof(string));

    ///// <summary>
    ///// The common principalName parameter.
    ///// </summary>
    //public ProvisioningParameter PrincipalNameParameter => new BicepParameter("principalName", typeof(string));

    public CloudMachineInfrastructure(string cloudMachineId) : base("cm")
    {
        _cmid = cloudMachineId;
        _identity = new("cm_identity");
        _identity.Name = _cmid;
        ManagedServiceIdentity managedServiceIdentity = new()
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
            UserAssignedIdentities = { { BicepFunction.Interpolate($"{_identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
        };

        _storage = StorageResources.CreateAccount($"cm_sa");
        _storage.Identity = managedServiceIdentity;
        _storage.Name = _cmid;

        _blobs = new("cm_blobs")
        {
            Parent = _storage,
        };
        _container = new BlobContainer("cm_container", "2023-01-01")
        {
            Parent = _blobs,
            Name = "default"
        };

        _serviceBusNamespace = new("cm_sb")
        {
            Sku = new ServiceBusSku
            {
                Name = ServiceBusSkuName.Standard,
                Tier = ServiceBusSkuTier.Standard
            },
            Name = _cmid,
        };
        _serviceBusNamespaceAuthorizationRule = new($"cm_sb_auth_rule", "2021-11-01")
        {
            Parent = _serviceBusNamespace,
            Rights = [ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send, ServiceBusAccessRight.Manage]
        };
        _serviceBusTopic_main = new("cm_internal_topic", "2021-11-01")
        {
            Name = "cm_internal_topic",
            Parent = _serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = new StringLiteral("P14D"),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _serviceBusSubscription_main = new("cm_internal_subscription", "2021-11-01")
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
        _serviceBusTopic_app = new("cm_default_topic", "2021-11-01")
        {
            Name = "cm_default_topic",
            Parent = _serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = new StringLiteral("P14D"),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _serviceBusSubscription_app = new("cm_default_subscription", "2021-11-01")
        {
            Name = "cm_default_subscription",
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
        _eventGridTopic_Blobs = new("cm_eg_blob", "2022-06-15")
        {
            TopicType = "Microsoft.Storage.StorageAccounts",
            Source = _storage.Id,
            Identity = managedServiceIdentity,
            Name = _cmid
        };
        _systemTopicEventSubscription = new($"cm_eg_blob_sub", "2022-06-15")
        {
            Parent = _eventGridTopic_Blobs,
            DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity
            {
                Identity = new EventSubscriptionIdentity
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = _identity.Id
                },
                Destination = new ServiceBusTopicEventSubscriptionDestination
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
        Add(new ProvisioningParameter("location", typeof(string))
        {
            Description = "The location for the resource(s) to be deployed.",
            Value = BicepFunction.GetResourceGroup().Location
        });

        Add(PrincipalIdParameter);
        //Add(PrincipalTypeParameter);
        //Add(PrincipalNameParameter);

        Add(_identity);
        Add(_storage);
        Add(_storage.CreateRoleAssignment(StorageBuiltInRole.StorageBlobDataContributor, RoleManagementPrincipalType.User, PrincipalIdParameter));
        Add(_storage.CreateRoleAssignment(StorageBuiltInRole.StorageTableDataContributor, RoleManagementPrincipalType.User, PrincipalIdParameter));
        Add(_container);
        Add(_blobs);
        Add(_serviceBusNamespace);
        Add(_serviceBusNamespace.CreateRoleAssignment(ServiceBusBuiltInRole.AzureServiceBusDataOwner, RoleManagementPrincipalType.User, PrincipalIdParameter));
        Add(_serviceBusNamespaceAuthorizationRule);
        Add(_serviceBusTopic_main);
        Add(_serviceBusTopic_app);
        Add(_serviceBusSubscription_main);
        Add(_serviceBusSubscription_app);

        RoleAssignment roleAssignment = _serviceBusNamespace.CreateRoleAssignment(ServiceBusBuiltInRole.AzureServiceBusDataSender, _identity);
        Add(roleAssignment);
        // the role assignment must exist before the system topic event subscription is created.
        _systemTopicEventSubscription.DependsOn.Add(roleAssignment);

        Add(_systemTopicEventSubscription);
        Add(_eventGridTopic_Blobs);

        // Placeholders for now.
        Add(new ProvisioningOutput($"storage_name", typeof(string)) { Value = _storage.Name });
        Add(new ProvisioningOutput($"servicebus_name", typeof(string)) { Value = _serviceBusNamespace.Name });

        return base.Build(context);
    }

    public static bool Configure(string[] args, Action<CloudMachineInfrastructure>? configure = default)
    {
        if (args.Length < 1 || args[0] != "--init")
        {
            return false;
        }

        string cmid = Azd.ReadOrCreateCmid();

        CloudMachineInfrastructure cmi = new(cmid);
        if (configure != default)
        {
            configure(cmi);
        }

        string infraDirectory = Path.Combine(".", "infra");
        Azd.Init(infraDirectory, cmi);
        return true;
    }
}
