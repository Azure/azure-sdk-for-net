// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// PartnerDestination.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class PartnerDestination : ProvisionableResource
{
    /// <summary>
    /// Name of the partner destination.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }
    private BicepValue<string>? _name;

    /// <summary>
    /// Gets or sets the Location.
    /// </summary>
    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _location!; }
        set { Initialize(); _location!.Assign(value); }
    }
    private BicepValue<AzureLocation>? _location;

    /// <summary>
    /// Activation state of the partner destination.
    /// </summary>
    public BicepValue<PartnerDestinationActivationState> ActivationState
    {
        get { Initialize(); return _activationState!; }
        set { Initialize(); _activationState!.Assign(value); }
    }
    private BicepValue<PartnerDestinationActivationState>? _activationState;

    /// <summary>
    /// Endpoint Base URL of the partner destination.
    /// </summary>
    public BicepValue<Uri> EndpointBaseUri
    {
        get { Initialize(); return _endpointBaseUri!; }
        set { Initialize(); _endpointBaseUri!.Assign(value); }
    }
    private BicepValue<Uri>? _endpointBaseUri;

    /// <summary>
    /// Endpoint context associated with this partner destination.
    /// </summary>
    public BicepValue<string> EndpointServiceContext
    {
        get { Initialize(); return _endpointServiceContext!; }
        set { Initialize(); _endpointServiceContext!.Assign(value); }
    }
    private BicepValue<string>? _endpointServiceContext;

    /// <summary>
    /// Expiration time of the partner destination. If this timer expires and
    /// the partner destination was never activated,             the partner
    /// destination and corresponding channel are deleted.
    /// </summary>
    public BicepValue<DateTimeOffset> ExpirationTimeIfNotActivatedUtc
    {
        get { Initialize(); return _expirationTimeIfNotActivatedUtc!; }
        set { Initialize(); _expirationTimeIfNotActivatedUtc!.Assign(value); }
    }
    private BicepValue<DateTimeOffset>? _expirationTimeIfNotActivatedUtc;

    /// <summary>
    /// Context or helpful message that can be used during the approval process.
    /// </summary>
    public BicepValue<string> MessageForActivation
    {
        get { Initialize(); return _messageForActivation!; }
        set { Initialize(); _messageForActivation!.Assign(value); }
    }
    private BicepValue<string>? _messageForActivation;

    /// <summary>
    /// The immutable Id of the corresponding partner registration.
    /// </summary>
    public BicepValue<Guid> PartnerRegistrationImmutableId
    {
        get { Initialize(); return _partnerRegistrationImmutableId!; }
        set { Initialize(); _partnerRegistrationImmutableId!.Assign(value); }
    }
    private BicepValue<Guid>? _partnerRegistrationImmutableId;

    /// <summary>
    /// Gets or sets the Tags.
    /// </summary>
    public BicepDictionary<string> Tags
    {
        get { Initialize(); return _tags!; }
        set { Initialize(); _tags!.Assign(value); }
    }
    private BicepDictionary<string>? _tags;

    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier>? _id;

    /// <summary>
    /// Provisioning state of the partner destination.
    /// </summary>
    public BicepValue<PartnerDestinationProvisioningState> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
    }
    private BicepValue<PartnerDestinationProvisioningState>? _provisioningState;

    /// <summary>
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }
    private SystemData? _systemData;

    /// <summary>
    /// Creates a new PartnerDestination.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the PartnerDestination resource.  This
    /// can be used to refer to the resource in expressions, but is not the
    /// Azure name of the resource.  This value can contain letters, numbers,
    /// and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the PartnerDestination.</param>
    public PartnerDestination(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.EventGrid/partnerDestinations", resourceVersion)
    {
    }

    /// <summary>
    /// Define all the provisionable properties of PartnerDestination.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
        _activationState = DefineProperty<PartnerDestinationActivationState>("ActivationState", ["properties", "activationState"]);
        _endpointBaseUri = DefineProperty<Uri>("EndpointBaseUri", ["properties", "endpointBaseUrl"]);
        _endpointServiceContext = DefineProperty<string>("EndpointServiceContext", ["properties", "endpointServiceContext"]);
        _expirationTimeIfNotActivatedUtc = DefineProperty<DateTimeOffset>("ExpirationTimeIfNotActivatedUtc", ["properties", "expirationTimeIfNotActivatedUtc"]);
        _messageForActivation = DefineProperty<string>("MessageForActivation", ["properties", "messageForActivation"]);
        _partnerRegistrationImmutableId = DefineProperty<Guid>("PartnerRegistrationImmutableId", ["properties", "partnerRegistrationImmutableId"]);
        _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _provisioningState = DefineProperty<PartnerDestinationProvisioningState>("ProvisioningState", ["properties", "provisioningState"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
    }

    /// <summary>
    /// Creates a reference to an existing PartnerDestination.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the PartnerDestination resource.  This
    /// can be used to refer to the resource in expressions, but is not the
    /// Azure name of the resource.  This value can contain letters, numbers,
    /// and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the PartnerDestination.</param>
    /// <returns>The existing PartnerDestination resource.</returns>
    public static PartnerDestination FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
