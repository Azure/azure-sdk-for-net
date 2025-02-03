// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HealthcareApis.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmHealthcareApisModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="HealthcareApis.DicomServiceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="authenticationConfiguration"> Dicom Service authentication configuration. </param>
        /// <param name="corsConfiguration"> Dicom Service Cors configuration. </param>
        /// <param name="serviceUri"> The url of the Dicom Services. </param>
        /// <param name="privateEndpointConnections"> The list of private endpoint connections that are set up for this resource. </param>
        /// <param name="publicNetworkAccess"> Control permission for data plane traffic coming from public networks while private endpoint is enabled. </param>
        /// <param name="identity"> Setting indicating whether the service has a managed identity associated with it. </param>
        /// <param name="etag"> An etag associated with the resource, used for optimistic concurrency when editing it. </param>
        /// <returns> A new <see cref="HealthcareApis.DicomServiceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DicomServiceData DicomServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, HealthcareApisProvisioningState? provisioningState, DicomServiceAuthenticationConfiguration authenticationConfiguration, DicomServiceCorsConfiguration corsConfiguration, Uri serviceUri, IEnumerable<HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections, HealthcareApisPublicNetworkAccess? publicNetworkAccess, ManagedServiceIdentity identity, ETag? etag)
            => DicomServiceData(id, name, resourceType, systemData, tags, location, provisioningState, authenticationConfiguration, corsConfiguration, serviceUri, privateEndpointConnections, publicNetworkAccess, null, null, identity, etag);

        /// <summary> Initializes a new instance of <see cref="HealthcareApis.FhirServiceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="kind"> The kind of the service. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="accessPolicies"> Fhir Service access policies. </param>
        /// <param name="acrConfiguration"> Fhir Service Azure container registry configuration. </param>
        /// <param name="authenticationConfiguration"> Fhir Service authentication configuration. </param>
        /// <param name="corsConfiguration"> Fhir Service Cors configuration. </param>
        /// <param name="exportStorageAccountName"> Fhir Service export configuration. </param>
        /// <param name="privateEndpointConnections"> The list of private endpoint connections that are set up for this resource. </param>
        /// <param name="publicNetworkAccess"> Control permission for data plane traffic coming from public networks while private endpoint is enabled. </param>
        /// <param name="eventState"> Fhir Service event support status. </param>
        /// <param name="resourceVersionPolicyConfiguration"> Determines tracking of history for resources. </param>
        /// <param name="importConfiguration"> Fhir Service import configuration. </param>
        /// <param name="identity"> Setting indicating whether the service has a managed identity associated with it. </param>
        /// <param name="etag"> An etag associated with the resource, used for optimistic concurrency when editing it. </param>
        /// <returns> A new <see cref="HealthcareApis.FhirServiceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FhirServiceData FhirServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, FhirServiceKind? kind, HealthcareApisProvisioningState? provisioningState, IEnumerable<FhirServiceAccessPolicyEntry> accessPolicies, FhirServiceAcrConfiguration acrConfiguration, FhirServiceAuthenticationConfiguration authenticationConfiguration, FhirServiceCorsConfiguration corsConfiguration, string exportStorageAccountName, IEnumerable<HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections, HealthcareApisPublicNetworkAccess? publicNetworkAccess, FhirServiceEventState? eventState, FhirServiceResourceVersionPolicyConfiguration resourceVersionPolicyConfiguration, FhirServiceImportConfiguration importConfiguration, ManagedServiceIdentity identity, ETag? etag)
            => FhirServiceData(id, name, resourceType, systemData, tags, location, kind, provisioningState, acrConfiguration, authenticationConfiguration, corsConfiguration, null, privateEndpointConnections, publicNetworkAccess, eventState, resourceVersionPolicyConfiguration, importConfiguration, null, null, identity, etag);
    }
}
