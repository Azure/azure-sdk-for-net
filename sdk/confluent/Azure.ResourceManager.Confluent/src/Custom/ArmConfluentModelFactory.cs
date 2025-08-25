// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Confluent.Models
{
    /// <summary> Model factory for models. </summary>
    public partial class ArmConfluentModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ConfluentOfferDetail"/>. </summary>
        /// <param name="publisherId"> Publisher Id. </param>
        /// <param name="id"> Offer Id. </param>
        /// <param name="planId"> Offer Plan Id. </param>
        /// <param name="planName"> Offer Plan Name. </param>
        /// <param name="termUnit"> Offer Plan Term unit. </param>
        /// <param name="status"> SaaS Offer Status. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConfluentOfferDetail ConfluentOfferDetail(string publisherId, string id, string planId, string planName, string termUnit, ConfluentSaaSOfferStatus? status)
        {
            return new ConfluentOfferDetail(publisherId, id, planId, planName, termUnit, status);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ClusterStatusEntity"/>. </summary>
        /// <param name="phase"> The lifecycle phase of the cluster. </param>
        /// <param name="cku"> The number of Confluent Kafka Units. </param>
        /// <returns> A new <see cref="Models.ClusterStatusEntity"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ClusterStatusEntity ClusterStatusEntity(string phase = null, int? cku = null)
        {
            return new ClusterStatusEntity(phase, cku, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of ConfluentOrganizationData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="createdOn"> The creation time of the resource. </param>
        /// <param name="provisioningState"> Provision states for confluent RP. </param>
        /// <param name="organizationId"> Id of the Confluent organization. </param>
        /// <param name="ssoUri"> SSO url for the Confluent organization. </param>
        /// <param name="offerDetail"> Confluent offer detail. </param>
        /// <param name="userDetail"> Subscriber detail. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Confluent.ConfluentOrganizationData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConfluentOrganizationData ConfluentOrganizationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, DateTimeOffset? createdOn, ConfluentProvisionState? provisioningState, Guid? organizationId, Uri ssoUri, ConfluentOfferDetail offerDetail, ConfluentUserDetail userDetail)
        {
            return ConfluentOrganizationData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, createdOn: createdOn, provisioningState: provisioningState, organizationId: organizationId, ssoUri: ssoUri, offerDetail: offerDetail, userDetail: userDetail, linkOrganizationToken: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SCClusterByokEntity"/>. </summary>
        /// <param name="id"> ID of the referred resource. </param>
        /// <param name="related"> API URL for accessing or modifying the referred object. </param>
        /// <param name="resourceName"> CRN reference to the referred resource. </param>
        /// <returns> A new <see cref="Models.SCClusterByokEntity"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SCClusterByokEntity SCClusterByokEntity(string id = null, string related = null, string resourceName = null)
        {
            return new SCClusterByokEntity(id, related, resourceName, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SCClusterNetworkEnvironmentEntity"/>. </summary>
        /// <param name="id"> ID of the referred resource. </param>
        /// <param name="environment"> Environment of the referred resource. </param>
        /// <param name="related"> API URL for accessing or modifying the referred object. </param>
        /// <param name="resourceName"> CRN reference to the referred resource. </param>
        /// <returns> A new <see cref="Models.SCClusterNetworkEnvironmentEntity"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SCClusterNetworkEnvironmentEntity SCClusterNetworkEnvironmentEntity(string id = null, string environment = null, string related = null, string resourceName = null)
        {
            return new SCClusterNetworkEnvironmentEntity(id, environment, related, resourceName, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SCClusterRecord"/>. </summary>
        /// <param name="kind"> Type of cluster. </param>
        /// <param name="id"> Id of the cluster. </param>
        /// <param name="name"> Display name of the cluster. </param>
        /// <param name="metadata"> Metadata of the record. </param>
        /// <param name="spec"> Specification of the cluster. </param>
        /// <param name="status"> Specification of the cluster status. </param>
        /// <returns> A new <see cref="Models.SCClusterRecord"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SCClusterRecord SCClusterRecord(string kind = null, string id = null, string name = null, SCMetadataEntity metadata = null, SCClusterSpecEntity spec = null, ClusterStatusEntity status = null)
        {
            return new SCClusterRecord(
                kind,
                id,
                name,
                metadata,
                spec,
                status,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SCClusterSpecEntity"/>. </summary>
        /// <param name="name"> The name of the cluster. </param>
        /// <param name="availability"> The availability zone configuration of the cluster. </param>
        /// <param name="cloud"> The cloud service provider. </param>
        /// <param name="zone"> type of zone availability. </param>
        /// <param name="region"> The cloud service provider region. </param>
        /// <param name="kafkaBootstrapEndpoint"> The bootstrap endpoint used by Kafka clients to connect to the cluster. </param>
        /// <param name="httpEndpoint"> The cluster HTTP request URL. </param>
        /// <param name="apiEndpoint"> The Kafka API cluster endpoint. </param>
        /// <param name="configKind"> Specification of the cluster configuration. </param>
        /// <param name="environment"> Specification of the cluster environment. </param>
        /// <param name="network"> Specification of the cluster network. </param>
        /// <param name="byok"> Specification of the cluster byok. </param>
        /// <returns> A new <see cref="Models.SCClusterSpecEntity"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SCClusterSpecEntity SCClusterSpecEntity(string name, string availability, string cloud, string zone, string region = null, string kafkaBootstrapEndpoint = null, string httpEndpoint = null, string apiEndpoint = null, string configKind = null, SCClusterNetworkEnvironmentEntity environment = null, SCClusterNetworkEnvironmentEntity network = null, SCClusterByokEntity byok = null)
        {
            return new SCClusterSpecEntity(
                name,
                availability,
                cloud,
                zone,
                null,
                region,
                kafkaBootstrapEndpoint,
                httpEndpoint,
                apiEndpoint,
                configKind != null ? new ClusterConfigEntity(configKind, serializedAdditionalRawData: null) : null,
                environment,
                network,
                byok,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SCEnvironmentRecord"/>. </summary>
        /// <param name="kind"> Type of environment. </param>
        /// <param name="id"> Id of the environment. </param>
        /// <param name="name"> Display name of the environment. </param>
        /// <param name="metadata"> Metadata of the record. </param>
        /// <returns> A new <see cref="Models.SCEnvironmentRecord"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SCEnvironmentRecord SCEnvironmentRecord(string kind = null, string id = null, string name = null, SCMetadataEntity metadata = null)
        {
            return new SCEnvironmentRecord(kind, id, name, metadata, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SCMetadataEntity"/>. </summary>
        /// <param name="self"> Self lookup url. </param>
        /// <param name="resourceName"> Resource name of the record. </param>
        /// <param name="createdOn"> Created Date Time. </param>
        /// <param name="updatedOn"> Updated Date time. </param>
        /// <param name="deletedOn"> Deleted Date time. </param>
        /// <returns> A new <see cref="Models.SCMetadataEntity"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SCMetadataEntity SCMetadataEntity(string self = null, string resourceName = null, DateTimeOffset? createdOn = null, DateTimeOffset? updatedOn = null, DateTimeOffset? deletedOn = null)
        {
            return new SCMetadataEntity(
                self,
                resourceName,
                createdOn,
                updatedOn,
                deletedOn,
                serializedAdditionalRawData: null);
        }
    }
}
