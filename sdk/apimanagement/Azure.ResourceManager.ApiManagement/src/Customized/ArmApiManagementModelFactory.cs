// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmApiManagementModelFactory
    {
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="description"> Description of the API. May include HTML formatting tags. </param>
        /// <param name="authenticationSettings"> Collection of authentication settings included into this API. </param>
        /// <param name="subscriptionKeyParameterNames"> Protocols over which API is made available. </param>
        /// <param name="apiType"> Type of API. </param>
        /// <param name="apiRevision"> Describes the revision of the API. If no value is provided, default revision 1 is created. </param>
        /// <param name="apiVersion"> Indicates the version identifier of the API if the API is versioned. </param>
        /// <param name="isCurrent"> Indicates if API revision is current api revision. </param>
        /// <param name="isOnline"> Indicates if API revision is accessible via the gateway. </param>
        /// <param name="apiRevisionDescription"> Description of the API Revision. </param>
        /// <param name="apiVersionDescription"> Description of the API Version. </param>
        /// <param name="apiVersionSetId"> A resource identifier for the related ApiVersionSet. </param>
        /// <param name="isSubscriptionRequired"> Specifies whether an API or Product subscription is required for accessing the API. </param>
        /// <param name="termsOfServiceUri"> A URL to the Terms of Service for the API. MUST be in the format of a URL. </param>
        /// <param name="contact"> Contact information for the API. </param>
        /// <param name="license"> License information for the API. </param>
        /// <param name="sourceApiId"> API identifier of the source API. </param>
        /// <param name="displayName"> API name. Must be 1 to 300 characters long. </param>
        /// <param name="serviceUri"> Absolute URL of the backend service implementing this API. Cannot be more than 2000 characters long. </param>
        /// <param name="path"> Relative URL uniquely identifying this API and all of its resource paths within the API Management service instance. It is appended to the API endpoint base URL specified during the service instance creation to form a public URL for this API. </param>
        /// <param name="protocols"> Describes on which protocols the operations in this API can be invoked. </param>
        /// <param name="apiVersionSet"> Version set details. </param>
        /// <returns> A new <see cref="ApiManagement.ApiData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ApiData ApiData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string description = null, AuthenticationSettingsContract authenticationSettings = null, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames = null, ApiType? apiType = null, string apiRevision = null, string apiVersion = null, bool? isCurrent = null, bool? isOnline = null, string apiRevisionDescription = null, string apiVersionDescription = null, ResourceIdentifier apiVersionSetId = null, bool? isSubscriptionRequired = null, Uri termsOfServiceUri = null, ApiContactInformation contact = null, ApiLicenseInformation license = null, ResourceIdentifier sourceApiId = null, string displayName = null, Uri serviceUri = null, string path = null, IEnumerable<ApiOperationInvokableProtocol> protocols = null, ApiVersionSetContractDetails apiVersionSet = null)
        {
            protocols ??= new List<ApiOperationInvokableProtocol>();

            return new ApiData(
                id,
                name,
                resourceType,
                systemData,
                description,
                authenticationSettings,
                subscriptionKeyParameterNames,
                apiType,
                apiRevision,
                apiVersion,
                isCurrent,
                isOnline,
                apiRevisionDescription,
                apiVersionDescription,
                apiVersionSetId,
                isSubscriptionRequired,
                termsOfServiceUri.AbsoluteUri.ToString(),
                contact,
                license,
                sourceApiId,
                displayName,
                serviceUri.AbsoluteUri.ToString(),
                path,
                protocols?.ToList(),
                apiVersionSet,
                serializedAdditionalRawData: null);
        }

        /// <param name="description"> Description of the API. May include HTML formatting tags. </param>
        /// <param name="authenticationSettings"> Collection of authentication settings included into this API. </param>
        /// <param name="subscriptionKeyParameterNames"> Protocols over which API is made available. </param>
        /// <param name="apiType"> Type of API. </param>
        /// <param name="apiRevision"> Describes the revision of the API. If no value is provided, default revision 1 is created. </param>
        /// <param name="apiVersion"> Indicates the version identifier of the API if the API is versioned. </param>
        /// <param name="isCurrent"> Indicates if API revision is current api revision. </param>
        /// <param name="isOnline"> Indicates if API revision is accessible via the gateway. </param>
        /// <param name="apiRevisionDescription"> Description of the API Revision. </param>
        /// <param name="apiVersionDescription"> Description of the API Version. </param>
        /// <param name="apiVersionSetId"> A resource identifier for the related ApiVersionSet. </param>
        /// <param name="isSubscriptionRequired"> Specifies whether an API or Product subscription is required for accessing the API. </param>
        /// <param name="termsOfServiceUri"> A URL to the Terms of Service for the API. MUST be in the format of a URL. </param>
        /// <param name="contact"> Contact information for the API. </param>
        /// <param name="license"> License information for the API. </param>
        /// <param name="displayName"> API name. </param>
        /// <param name="serviceUri"> Absolute URL of the backend service implementing this API. </param>
        /// <param name="path"> Relative URL uniquely identifying this API and all of its resource paths within the API Management service instance. It is appended to the API endpoint base URL specified during the service instance creation to form a public URL for this API. </param>
        /// <param name="protocols"> Describes on which protocols the operations in this API can be invoked. </param>
        /// <returns> A new <see cref="Models.ApiPatch"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ApiPatch ApiPatch(string description = null, AuthenticationSettingsContract authenticationSettings = null, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames = null, ApiType? apiType = null, string apiRevision = null, string apiVersion = null, bool? isCurrent = null, bool? isOnline = null, string apiRevisionDescription = null, string apiVersionDescription = null, ResourceIdentifier apiVersionSetId = null, bool? isSubscriptionRequired = null, Uri termsOfServiceUri = null, ApiContactInformation contact = null, ApiLicenseInformation license = null, string displayName = null, Uri serviceUri = null, string path = null, IEnumerable<ApiOperationInvokableProtocol> protocols = null)
        {
            protocols ??= new List<ApiOperationInvokableProtocol>();

            return new ApiPatch(
                description,
                authenticationSettings,
                subscriptionKeyParameterNames,
                apiType,
                apiRevision,
                apiVersion,
                isCurrent,
                isOnline,
                apiRevisionDescription,
                apiVersionDescription,
                apiVersionSetId,
                isSubscriptionRequired,
                termsOfServiceUri.AbsoluteUri.ToString(),
                contact,
                license,
                displayName,
                serviceUri.AbsoluteUri.ToString(),
                path,
                protocols?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ApiEntityBaseContract"/>. </summary>
        /// <param name="description"> Description of the API. May include HTML formatting tags. </param>
        /// <param name="authenticationSettings"> Collection of authentication settings included into this API. </param>
        /// <param name="subscriptionKeyParameterNames"> Protocols over which API is made available. </param>
        /// <param name="apiType"> Type of API. </param>
        /// <param name="apiRevision"> Describes the revision of the API. If no value is provided, default revision 1 is created. </param>
        /// <param name="apiVersion"> Indicates the version identifier of the API if the API is versioned. </param>
        /// <param name="isCurrent"> Indicates if API revision is current api revision. </param>
        /// <param name="isOnline"> Indicates if API revision is accessible via the gateway. </param>
        /// <param name="apiRevisionDescription"> Description of the API Revision. </param>
        /// <param name="apiVersionDescription"> Description of the API Version. </param>
        /// <param name="apiVersionSetId"> A resource identifier for the related ApiVersionSet. </param>
        /// <param name="isSubscriptionRequired"> Specifies whether an API or Product subscription is required for accessing the API. </param>
        /// <param name="termsOfServiceUri"> A URL to the Terms of Service for the API. MUST be in the format of a URL. </param>
        /// <param name="contact"> Contact information for the API. </param>
        /// <param name="license"> License information for the API. </param>
        /// <returns> A new <see cref="Models.ApiEntityBaseContract"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ApiEntityBaseContract ApiEntityBaseContract(string description = null, AuthenticationSettingsContract authenticationSettings = null, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames = null, ApiType? apiType = null, string apiRevision = null, string apiVersion = null, bool? isCurrent = null, bool? isOnline = null, string apiRevisionDescription = null, string apiVersionDescription = null, ResourceIdentifier apiVersionSetId = null, bool? isSubscriptionRequired = null, Uri termsOfServiceUri = null, ApiContactInformation contact = null, ApiLicenseInformation license = null)
        {
            return new ApiEntityBaseContract(
                 description,
                 authenticationSettings,
                 subscriptionKeyParameterNames,
                 apiType,
                 apiRevision,
                 apiVersion,
                 isCurrent,
                 isOnline,
                 apiRevisionDescription,
                 apiVersionDescription,
                 apiVersionSetId,
                 isSubscriptionRequired,
                 termsOfServiceUri.AbsoluteUri.ToString(),
                 contact,
                 license,
                 serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ApiCreateOrUpdateContent"/>. </summary>
        /// <param name="description"> Description of the API. May include HTML formatting tags. </param>
        /// <param name="authenticationSettings"> Collection of authentication settings included into this API. </param>
        /// <param name="subscriptionKeyParameterNames"> Protocols over which API is made available. </param>
        /// <param name="apiType"> Type of API. </param>
        /// <param name="apiRevision"> Describes the revision of the API. If no value is provided, default revision 1 is created. </param>
        /// <param name="apiVersion"> Indicates the version identifier of the API if the API is versioned. </param>
        /// <param name="isCurrent"> Indicates if API revision is current api revision. </param>
        /// <param name="isOnline"> Indicates if API revision is accessible via the gateway. </param>
        /// <param name="apiRevisionDescription"> Description of the API Revision. </param>
        /// <param name="apiVersionDescription"> Description of the API Version. </param>
        /// <param name="apiVersionSetId"> A resource identifier for the related ApiVersionSet. </param>
        /// <param name="isSubscriptionRequired"> Specifies whether an API or Product subscription is required for accessing the API. </param>
        /// <param name="termsOfServiceUri"> A URL to the Terms of Service for the API. MUST be in the format of a URL. </param>
        /// <param name="contact"> Contact information for the API. </param>
        /// <param name="license"> License information for the API. </param>
        /// <param name="sourceApiId"> API identifier of the source API. </param>
        /// <param name="displayName"> API name. Must be 1 to 300 characters long. </param>
        /// <param name="serviceUri"> Absolute URL of the backend service implementing this API. Cannot be more than 2000 characters long. </param>
        /// <param name="path"> Relative URL uniquely identifying this API and all of its resource paths within the API Management service instance. It is appended to the API endpoint base URL specified during the service instance creation to form a public URL for this API. </param>
        /// <param name="protocols"> Describes on which protocols the operations in this API can be invoked. </param>
        /// <param name="apiVersionSet"> Version set details. </param>
        /// <param name="value"> Content value when Importing an API. </param>
        /// <param name="format"> Format of the Content in which the API is getting imported. </param>
        /// <param name="wsdlSelector"> Criteria to limit import of WSDL to a subset of the document. </param>
        /// <param name="soapApiType">
        /// Type of API to create.
        ///  * `http` creates a REST API
        ///  * `soap` creates a SOAP pass-through API
        ///  * `websocket` creates websocket API
        ///  * `graphql` creates GraphQL API.
        /// </param>
        /// <returns> A new <see cref="Models.ApiCreateOrUpdateContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ApiCreateOrUpdateContent ApiCreateOrUpdateContent(string description = null, AuthenticationSettingsContract authenticationSettings = null, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames = null, ApiType? apiType = null, string apiRevision = null, string apiVersion = null, bool? isCurrent = null, bool? isOnline = null, string apiRevisionDescription = null, string apiVersionDescription = null, ResourceIdentifier apiVersionSetId = null, bool? isSubscriptionRequired = null, Uri termsOfServiceUri = null, ApiContactInformation contact = null, ApiLicenseInformation license = null, ResourceIdentifier sourceApiId = null, string displayName = null, Uri serviceUri = null, string path = null, IEnumerable<ApiOperationInvokableProtocol> protocols = null, ApiVersionSetContractDetails apiVersionSet = null, string value = null, ContentFormat? format = null, ApiCreateOrUpdatePropertiesWsdlSelector wsdlSelector = null, SoapApiType? soapApiType = null)
        {
            protocols ??= new List<ApiOperationInvokableProtocol>();

            return new ApiCreateOrUpdateContent(
                description,
                authenticationSettings,
                subscriptionKeyParameterNames,
                apiType,
                apiRevision,
                apiVersion,
                isCurrent,
                isOnline,
                apiRevisionDescription,
                apiVersionDescription,
                apiVersionSetId,
                isSubscriptionRequired,
                termsOfServiceUri.AbsoluteUri.ToString(),
                contact,
                license,
                sourceApiId,
                displayName,
                serviceUri.AbsoluteUri.ToString(),
                path,
                protocols?.ToList(),
                apiVersionSet,
                value,
                format,
                wsdlSelector,
                soapApiType,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AssociatedApiProperties"/>. </summary>
        /// <param name="description"> Description of the API. May include HTML formatting tags. </param>
        /// <param name="authenticationSettings"> Collection of authentication settings included into this API. </param>
        /// <param name="subscriptionKeyParameterNames"> Protocols over which API is made available. </param>
        /// <param name="apiType"> Type of API. </param>
        /// <param name="apiRevision"> Describes the revision of the API. If no value is provided, default revision 1 is created. </param>
        /// <param name="apiVersion"> Indicates the version identifier of the API if the API is versioned. </param>
        /// <param name="isCurrent"> Indicates if API revision is current api revision. </param>
        /// <param name="isOnline"> Indicates if API revision is accessible via the gateway. </param>
        /// <param name="apiRevisionDescription"> Description of the API Revision. </param>
        /// <param name="apiVersionDescription"> Description of the API Version. </param>
        /// <param name="apiVersionSetId"> A resource identifier for the related ApiVersionSet. </param>
        /// <param name="isSubscriptionRequired"> Specifies whether an API or Product subscription is required for accessing the API. </param>
        /// <param name="termsOfServiceUri"> A URL to the Terms of Service for the API. MUST be in the format of a URL. </param>
        /// <param name="contact"> Contact information for the API. </param>
        /// <param name="license"> License information for the API. </param>
        /// <param name="id"> API identifier in the form /apis/{apiId}. </param>
        /// <param name="name"> API name. </param>
        /// <param name="serviceUri"> Absolute URL of the backend service implementing this API. </param>
        /// <param name="path"> Relative URL uniquely identifying this API and all of its resource paths within the API Management service instance. It is appended to the API endpoint base URL specified during the service instance creation to form a public URL for this API. </param>
        /// <param name="protocols"> Describes on which protocols the operations in this API can be invoked. </param>
        /// <returns> A new <see cref="Models.AssociatedApiProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AssociatedApiProperties AssociatedApiProperties(string description = null, AuthenticationSettingsContract authenticationSettings = null, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames = null, ApiType? apiType = null, string apiRevision = null, string apiVersion = null, bool? isCurrent = null, bool? isOnline = null, string apiRevisionDescription = null, string apiVersionDescription = null, ResourceIdentifier apiVersionSetId = null, bool? isSubscriptionRequired = null, Uri termsOfServiceUri = null, ApiContactInformation contact = null, ApiLicenseInformation license = null, string id = null, string name = null, Uri serviceUri = null, string path = null, IEnumerable<ApiOperationInvokableProtocol> protocols = null)
        {
            protocols ??= new List<ApiOperationInvokableProtocol>();

            return new AssociatedApiProperties(
                description,
                authenticationSettings,
                subscriptionKeyParameterNames,
                apiType,
                apiRevision,
                apiVersion,
                isCurrent,
                isOnline,
                apiRevisionDescription,
                apiVersionDescription,
                apiVersionSetId,
                isSubscriptionRequired,
                termsOfServiceUri.AbsoluteUri.ToString(),
                contact,
                license,
                serializedAdditionalRawData: null,
                id,
                name,
                serviceUri,
                path,
                protocols?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.GatewayApiData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="description"> Description of the API. May include HTML formatting tags. </param>
        /// <param name="authenticationSettings"> Collection of authentication settings included into this API. </param>
        /// <param name="subscriptionKeyParameterNames"> Protocols over which API is made available. </param>
        /// <param name="apiType"> Type of API. </param>
        /// <param name="apiRevision"> Describes the revision of the API. If no value is provided, default revision 1 is created. </param>
        /// <param name="apiVersion"> Indicates the version identifier of the API if the API is versioned. </param>
        /// <param name="isCurrent"> Indicates if API revision is current api revision. </param>
        /// <param name="isOnline"> Indicates if API revision is accessible via the gateway. </param>
        /// <param name="apiRevisionDescription"> Description of the API Revision. </param>
        /// <param name="apiVersionDescription"> Description of the API Version. </param>
        /// <param name="apiVersionSetId"> A resource identifier for the related ApiVersionSet. </param>
        /// <param name="isSubscriptionRequired"> Specifies whether an API or Product subscription is required for accessing the API. </param>
        /// <param name="termsOfServiceUri"> A URL to the Terms of Service for the API. MUST be in the format of a URL. </param>
        /// <param name="contact"> Contact information for the API. </param>
        /// <param name="license"> License information for the API. </param>
        /// <param name="sourceApiId"> API identifier of the source API. </param>
        /// <param name="displayName"> API name. Must be 1 to 300 characters long. </param>
        /// <param name="serviceUri"> Absolute URL of the backend service implementing this API. Cannot be more than 2000 characters long. </param>
        /// <param name="path"> Relative URL uniquely identifying this API and all of its resource paths within the API Management service instance. It is appended to the API endpoint base URL specified during the service instance creation to form a public URL for this API. </param>
        /// <param name="protocols"> Describes on which protocols the operations in this API can be invoked. </param>
        /// <param name="apiVersionSet"> Version set details. </param>
        /// <returns> A new <see cref="Models.GatewayApiData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GatewayApiData GatewayApiData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string description = null, AuthenticationSettingsContract authenticationSettings = null, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames = null, ApiType? apiType = null, string apiRevision = null, string apiVersion = null, bool? isCurrent = null, bool? isOnline = null, string apiRevisionDescription = null, string apiVersionDescription = null, ResourceIdentifier apiVersionSetId = null, bool? isSubscriptionRequired = null, Uri termsOfServiceUri = null, ApiContactInformation contact = null, ApiLicenseInformation license = null, ResourceIdentifier sourceApiId = null, string displayName = null, Uri serviceUri = null, string path = null, IEnumerable<ApiOperationInvokableProtocol> protocols = null, ApiVersionSetContractDetails apiVersionSet = null)
        {
            protocols ??= new List<ApiOperationInvokableProtocol>();

            return new GatewayApiData(
                id,
                name,
                resourceType,
                systemData,
                description,
                authenticationSettings,
                subscriptionKeyParameterNames,
                apiType,
                apiRevision,
                apiVersion,
                isCurrent,
                isOnline,
                apiRevisionDescription,
                apiVersionDescription,
                apiVersionSetId,
                isSubscriptionRequired,
                termsOfServiceUri.AbsoluteUri.ToString(),
                contact,
                license,
                sourceApiId,
                displayName,
                serviceUri.AbsoluteUri.ToString(),
                path,
                protocols?.ToList(),
                apiVersionSet,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ProductApiData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="description"> Description of the API. May include HTML formatting tags. </param>
        /// <param name="authenticationSettings"> Collection of authentication settings included into this API. </param>
        /// <param name="subscriptionKeyParameterNames"> Protocols over which API is made available. </param>
        /// <param name="apiType"> Type of API. </param>
        /// <param name="apiRevision"> Describes the revision of the API. If no value is provided, default revision 1 is created. </param>
        /// <param name="apiVersion"> Indicates the version identifier of the API if the API is versioned. </param>
        /// <param name="isCurrent"> Indicates if API revision is current api revision. </param>
        /// <param name="isOnline"> Indicates if API revision is accessible via the gateway. </param>
        /// <param name="apiRevisionDescription"> Description of the API Revision. </param>
        /// <param name="apiVersionDescription"> Description of the API Version. </param>
        /// <param name="apiVersionSetId"> A resource identifier for the related ApiVersionSet. </param>
        /// <param name="isSubscriptionRequired"> Specifies whether an API or Product subscription is required for accessing the API. </param>
        /// <param name="termsOfServiceUri"> A URL to the Terms of Service for the API. MUST be in the format of a URL. </param>
        /// <param name="contact"> Contact information for the API. </param>
        /// <param name="license"> License information for the API. </param>
        /// <param name="sourceApiId"> API identifier of the source API. </param>
        /// <param name="displayName"> API name. Must be 1 to 300 characters long. </param>
        /// <param name="serviceUri"> Absolute URL of the backend service implementing this API. Cannot be more than 2000 characters long. </param>
        /// <param name="path"> Relative URL uniquely identifying this API and all of its resource paths within the API Management service instance. It is appended to the API endpoint base URL specified during the service instance creation to form a public URL for this API. </param>
        /// <param name="protocols"> Describes on which protocols the operations in this API can be invoked. </param>
        /// <param name="apiVersionSet"> Version set details. </param>
        /// <returns> A new <see cref="Models.ProductApiData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ProductApiData ProductApiData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string description = null, AuthenticationSettingsContract authenticationSettings = null, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames = null, ApiType? apiType = null, string apiRevision = null, string apiVersion = null, bool? isCurrent = null, bool? isOnline = null, string apiRevisionDescription = null, string apiVersionDescription = null, ResourceIdentifier apiVersionSetId = null, bool? isSubscriptionRequired = null, Uri termsOfServiceUri = null, ApiContactInformation contact = null, ApiLicenseInformation license = null, ResourceIdentifier sourceApiId = null, string displayName = null, Uri serviceUri = null, string path = null, IEnumerable<ApiOperationInvokableProtocol> protocols = null, ApiVersionSetContractDetails apiVersionSet = null)
        {
            protocols ??= new List<ApiOperationInvokableProtocol>();

            return new ProductApiData(
                id,
                name,
                resourceType,
                systemData,
                description,
                authenticationSettings,
                subscriptionKeyParameterNames,
                apiType,
                apiRevision,
                apiVersion,
                isCurrent,
                isOnline,
                apiRevisionDescription,
                apiVersionDescription,
                apiVersionSetId,
                isSubscriptionRequired,
                termsOfServiceUri.AbsoluteUri.ToString(),
                contact,
                license,
                sourceApiId,
                displayName,
                serviceUri.AbsoluteUri.ToString(),
                path,
                protocols?.ToList(),
                apiVersionSet,
                serializedAdditionalRawData: null);
        }
    }
}
