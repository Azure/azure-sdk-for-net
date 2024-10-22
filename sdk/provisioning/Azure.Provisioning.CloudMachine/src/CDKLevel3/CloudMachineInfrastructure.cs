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
using System.Security.Principal;

namespace Azure.Provisioning.CloudMachine;

public class CloudMachineInfrastructure
{
    internal const string SB_PRIVATE_TOPIC = "cm_servicebus_topic_private";
    internal const string SB_PRIVATE_SUB = "cm_servicebus_subscription_private";
    private readonly string _cmid;

    private Infrastructure _infrastructure = new Infrastructure("cm");
    private List<Provisionable> _resources = new();

    // storage
    private StorageAccount _storage;
    private BlobService _blobs;
    private BlobContainer _container;

    // servicebus
    private ServiceBusNamespace _serviceBusNamespace;
    private ServiceBusNamespaceAuthorizationRule _serviceBusNamespaceAuthorizationRule;

    private ServiceBusTopic _serviceBusTopic_default;
    private ServiceBusSubscription _serviceBusSubscription_default;

    private ServiceBusTopic _serviceBusTopic_private;
    private ServiceBusSubscription _serviceBusSubscription_private;

    // eventgrid
    private SystemTopic _eventGridTopic_blobs;
    private SystemTopicEventSubscription _eventGridSubscription_blobs;

    public UserAssignedIdentity Identity { get; private set; }
    public string Id => _cmid;

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

    public CloudMachineInfrastructure(string cmId)
    {
        _cmid = cmId;

        // setup CM identity
        Identity = new UserAssignedIdentity("cm_identity");
        Identity.Name = _cmid;
        _infrastructure.Add(new ProvisioningOutput($"cm_managed_identity_id", typeof(string)) { Value = Identity.Id });
        ManagedServiceIdentity managedServiceIdentity = new()
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
            UserAssignedIdentities = { { BicepFunction.Interpolate($"{Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
        };

        _storage = StorageResources.CreateAccount("cm_storage");
        _storage.Identity = managedServiceIdentity;
        _storage.Name = _cmid;

        _blobs = new("cm_storage_blobs")
        {
            Parent = _storage,
        };
        _container = new BlobContainer("cm_storage_blobs_container", "2023-01-01")
        {
            Parent = _blobs,
            Name = "default"
        };

        _serviceBusNamespace = new("cm_servicebus")
        {
            Sku = new ServiceBusSku
            {
                Name = ServiceBusSkuName.Standard,
                Tier = ServiceBusSkuTier.Standard
            },
            Name = _cmid,
        };
        _serviceBusNamespaceAuthorizationRule = new("cm_servicebus_auth_rule", "2021-11-01")
        {
            Parent = _serviceBusNamespace,
            Rights = [ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send, ServiceBusAccessRight.Manage]
        };
        _serviceBusTopic_private = new("cm_servicebus_topic_private", "2021-11-01")
        {
            Name = "cm_servicebus_topic_private",
            Parent = _serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = new StringLiteralExpression("P14D"),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _serviceBusSubscription_private = new(SB_PRIVATE_SUB, "2021-11-01")
        {
            Name = SB_PRIVATE_SUB,
            Parent = _serviceBusTopic_private,
            IsClientAffine = false,
            LockDuration = new StringLiteralExpression("PT30S"),
            RequiresSession = false,
            DefaultMessageTimeToLive = new StringLiteralExpression("P14D"),
            DeadLetteringOnFilterEvaluationExceptions = true,
            DeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 10,
            EnableBatchedOperations = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _serviceBusTopic_default = new("cm_servicebus_topic_default", "2021-11-01")
        {
            Name = "cm_servicebus_default_topic",
            Parent = _serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = new StringLiteralExpression("P14D"),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _serviceBusSubscription_default = new("cm_servicebus_subscription_default", "2021-11-01")
        {
            Name = "cm_servicebus_subscription_default",
            Parent = _serviceBusTopic_default,
            IsClientAffine = false,
            LockDuration = new StringLiteralExpression("PT30S"),
            RequiresSession = false,
            DefaultMessageTimeToLive = new StringLiteralExpression("P14D"),
            DeadLetteringOnFilterEvaluationExceptions = true,
            DeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 10,
            EnableBatchedOperations = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        _eventGridTopic_blobs = new("cm_eventgrid_topic_blob", "2022-06-15")
        {
            TopicType = "Microsoft.Storage.StorageAccounts",
            Source = _storage.Id,
            Identity = managedServiceIdentity,
            Name = _cmid
        };
        _eventGridSubscription_blobs = new("cm_eventgrid_subscription_blob", "2022-06-15")
        {
            Name = "cm-eventgrid-subscription-blob",
            Parent = _eventGridTopic_blobs,
            DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity
            {
                Identity = new EventSubscriptionIdentity
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = Identity.Id
                },
                Destination = new ServiceBusTopicEventSubscriptionDestination
                {
                    ResourceId = _serviceBusTopic_private.Id
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

    public void AddResource(NamedProvisionableConstruct resource)
    {
        _resources.Add(resource);
    }
    public void AddFeature(CloudMachineFeature resource)
    {
        resource.AddTo(this);
    }

    public ProvisioningPlan Build(ProvisioningBuildOptions? context = null)
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
        _infrastructure.Add(_serviceBusTopic_private);
        _infrastructure.Add(_serviceBusTopic_default);
        _infrastructure.Add(_serviceBusSubscription_private);
        _infrastructure.Add(_serviceBusSubscription_default);

        // This is necessary until SystemTopic adds an AssignRole method.
        var role = ServiceBusBuiltInRole.AzureServiceBusDataSender;
        RoleAssignment roleAssignment = new RoleAssignment("cm_servicebus_role");
        roleAssignment.Name = BicepFunction.CreateGuid(_serviceBusNamespace.Id, Identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()));
        roleAssignment.Scope = new IdentifierExpression(_serviceBusNamespace.BicepIdentifier);
        roleAssignment.PrincipalType = RoleManagementPrincipalType.ServicePrincipal;
        roleAssignment.RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString());
        roleAssignment.PrincipalId = Identity.PrincipalId;
        _infrastructure.Add(roleAssignment);
        // the role assignment must exist before the system topic event subscription is created.
        _eventGridSubscription_blobs.DependsOn.Add(roleAssignment);
        _infrastructure.Add(_eventGridSubscription_blobs);

        _infrastructure.Add(_eventGridTopic_blobs);

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
