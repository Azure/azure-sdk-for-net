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
using Azure.Provisioning.Primitives;
using System.Collections.Generic;

namespace Azure.Provisioning.CloudMachine;

public class CloudMachineInfrastructure
{
    private Infrastructure _infrastructure = new Infrastructure("cm");
    private List<Provisionable> _resources = new();
    private readonly string _cmid;
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

    public UserAssignedIdentity Identity { get; private set; }

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

    public CloudMachineInfrastructure(string cloudMachineId)
    {
        _cmid = cloudMachineId;
        Identity = new("cm_identity");
        Identity.Name = _cmid;

        _infrastructure.Add(new ProvisioningOutput($"cm_managed_identity_id", typeof(string)) { Value = Identity.Id });

        ManagedServiceIdentity managedServiceIdentity = new()
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
            UserAssignedIdentities = { { BicepFunction.Interpolate($"{Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
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
                    UserAssignedIdentity = Identity.Id
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

    public void AddResource(NamedProvisioningConstruct resource)
    {
        _resources.Add(resource);
    }
    public void AddFeature(CloudMachineFeature resource)
    {
        resource.AddTo(this);
    }

    public ProvisioningPlan Build(ProvisioningContext? context = null)
    {
        // Always add a default location parameter.
        // azd assumes there will be a location parameter for every module.
        // The Infrastructure location resolver will resolve unset Location properties to this parameter.
        _infrastructure.Add(new ProvisioningParameter("location", typeof(string))
        {
            Description = "The location for the resource(s) to be deployed.",
            Value = BicepFunction.GetResourceGroup().Location
        });

        _infrastructure.Add(PrincipalIdParameter);
        //Add(PrincipalTypeParameter);
        //Add(PrincipalNameParameter);

        _infrastructure.Add(Identity);
        _infrastructure.Add(_storage);
        _infrastructure.Add(_storage.CreateRoleAssignment(StorageBuiltInRole.StorageBlobDataContributor, RoleManagementPrincipalType.User, PrincipalIdParameter));
        _infrastructure.Add(_storage.CreateRoleAssignment(StorageBuiltInRole.StorageTableDataContributor, RoleManagementPrincipalType.User, PrincipalIdParameter));
        _infrastructure.Add(_container);
        _infrastructure.Add(_blobs);
        _infrastructure.Add(_serviceBusNamespace);
        _infrastructure.Add(_serviceBusNamespace.CreateRoleAssignment(ServiceBusBuiltInRole.AzureServiceBusDataOwner, RoleManagementPrincipalType.User, PrincipalIdParameter));
        _infrastructure.Add(_serviceBusNamespaceAuthorizationRule);
        _infrastructure.Add(_serviceBusTopic_main);
        _infrastructure.Add(_serviceBusTopic_app);
        _infrastructure.Add(_serviceBusSubscription_main);
        _infrastructure.Add(_serviceBusSubscription_app);

        RoleAssignment roleAssignment = _serviceBusNamespace.CreateRoleAssignment(ServiceBusBuiltInRole.AzureServiceBusDataSender, Identity);
        _infrastructure.Add(roleAssignment);
        // the role assignment must exist before the system topic event subscription is created.
        _systemTopicEventSubscription.DependsOn.Add(roleAssignment);

        _infrastructure.Add(_systemTopicEventSubscription);
        _infrastructure.Add(_eventGridTopic_Blobs);

        // Placeholders for now.
        _infrastructure.Add(new ProvisioningOutput($"storage_name", typeof(string)) { Value = _storage.Name });
        _infrastructure.Add(new ProvisioningOutput($"servicebus_name", typeof(string)) { Value = _serviceBusNamespace.Name });

        // Add any add-on resources to the infrastructure.
        foreach (Provisionable resource in _resources)
        {
            _infrastructure.Add(resource);
        }

        return _infrastructure.Build(context);
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
