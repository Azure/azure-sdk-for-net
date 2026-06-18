// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> API data returned from gateway API operations. </summary>
    public partial class GatewayApiData : ApiData, IJsonModel<GatewayApiData>, IPersistableModel<GatewayApiData>
    {
        /// <summary> Initializes a new instance of <see cref="GatewayApiData"/>. </summary>
        public GatewayApiData()
        {
        }

        internal GatewayApiData(ApiData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, default)
        {
        }

        void IJsonModel<GatewayApiData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ApiData>)this).Write(writer, options);

        GatewayApiData IJsonModel<GatewayApiData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ApiData data = ((IJsonModel<ApiData>)new ApiData()).Create(ref reader, options);
            return data is null ? null : new GatewayApiData(data);
        }

        BinaryData IPersistableModel<GatewayApiData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiData>)this).Write(options);

        GatewayApiData IPersistableModel<GatewayApiData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ApiData value = ((IPersistableModel<ApiData>)new ApiData()).Create(data, options);
            return value is null ? null : new GatewayApiData(value);
        }

        string IPersistableModel<GatewayApiData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiData>)new ApiData()).GetFormatFromOptions(options);
    }

    /// <summary> API data returned from product API operations. </summary>
    public partial class ProductApiData : ApiData, IJsonModel<ProductApiData>, IPersistableModel<ProductApiData>
    {
        /// <summary> Initializes a new instance of <see cref="ProductApiData"/>. </summary>
        public ProductApiData()
        {
        }

        internal ProductApiData(ApiData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, default)
        {
        }

        void IJsonModel<ProductApiData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ApiData>)this).Write(writer, options);

        ProductApiData IJsonModel<ProductApiData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ApiData data = ((IJsonModel<ApiData>)new ApiData()).Create(ref reader, options);
            return data is null ? null : new ProductApiData(data);
        }

        BinaryData IPersistableModel<ProductApiData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiData>)this).Write(options);

        ProductApiData IPersistableModel<ProductApiData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ApiData value = ((IPersistableModel<ApiData>)new ApiData()).Create(data, options);
            return value is null ? null : new ProductApiData(value);
        }

        string IPersistableModel<ProductApiData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiData>)new ApiData()).GetFormatFromOptions(options);
    }

    /// <summary> Group data returned from product group operations. </summary>
    public partial class ProductGroupData : ApiManagementGroupData, IJsonModel<ProductGroupData>, IPersistableModel<ProductGroupData>
    {
        /// <summary> Initializes a new instance of <see cref="ProductGroupData"/>. </summary>
        public ProductGroupData()
        {
        }

        internal ProductGroupData(ApiManagementGroupData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, default)
        {
        }

        void IJsonModel<ProductGroupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ApiManagementGroupData>)this).Write(writer, options);

        ProductGroupData IJsonModel<ProductGroupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ApiManagementGroupData data = ((IJsonModel<ApiManagementGroupData>)new ApiManagementGroupData()).Create(ref reader, options);
            return data is null ? null : new ProductGroupData(data);
        }

        BinaryData IPersistableModel<ProductGroupData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiManagementGroupData>)this).Write(options);

        ProductGroupData IPersistableModel<ProductGroupData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ApiManagementGroupData value = ((IPersistableModel<ApiManagementGroupData>)new ApiManagementGroupData()).Create(data, options);
            return value is null ? null : new ProductGroupData(value);
        }

        string IPersistableModel<ProductGroupData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiManagementGroupData>)new ApiManagementGroupData()).GetFormatFromOptions(options);
    }

    /// <summary> User data returned from group user operations. </summary>
    public partial class ApiManagementGroupUserData : UserContractData, IJsonModel<ApiManagementGroupUserData>, IPersistableModel<ApiManagementGroupUserData>
    {
        /// <summary> Initializes a new instance of <see cref="ApiManagementGroupUserData"/>. </summary>
        public ApiManagementGroupUserData()
        {
        }

        internal ApiManagementGroupUserData(UserContractData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, default)
        {
        }

        void IJsonModel<ApiManagementGroupUserData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<UserContractData>)this).Write(writer, options);

        ApiManagementGroupUserData IJsonModel<ApiManagementGroupUserData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            UserContractData data = ((IJsonModel<UserContractData>)new UserContractData()).Create(ref reader, options);
            return data is null ? null : new ApiManagementGroupUserData(data);
        }

        BinaryData IPersistableModel<ApiManagementGroupUserData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<UserContractData>)this).Write(options);

        ApiManagementGroupUserData IPersistableModel<ApiManagementGroupUserData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            UserContractData value = ((IPersistableModel<UserContractData>)new UserContractData()).Create(data, options);
            return value is null ? null : new ApiManagementGroupUserData(value);
        }

        string IPersistableModel<ApiManagementGroupUserData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<UserContractData>)new UserContractData()).GetFormatFromOptions(options);
    }

    public static partial class ArmApiManagementModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ApiManagementGroupUserData"/>. </summary>
        public static ApiManagementGroupUserData ApiManagementGroupUserData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ApiManagementUserState? state = default, string note = default, IEnumerable<UserIdentityContract> identities = default, string firstName = default, string lastName = default, string email = default, DateTimeOffset? registriesOn = default, IEnumerable<GroupContractProperties> groups = default)
            => new ApiManagementGroupUserData(UserContractData(id, name, resourceType, systemData, state, note, identities, firstName, lastName, email, registriesOn, groups));

        /// <summary> Initializes a new instance of <see cref="Models.GatewayApiData"/>. </summary>
        public static GatewayApiData GatewayApiData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, AuthenticationSettingsContract authenticationSettings, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames, ApiType? apiType, string apiRevision, string apiVersion, bool? isCurrent, bool? isOnline, string apiRevisionDescription, string apiVersionDescription, ResourceIdentifier apiVersionSetId, bool? isSubscriptionRequired, Uri termsOfServiceUri, ApiContactInformation contact, ApiLicenseInformation license, ResourceIdentifier sourceApiId, string displayName, Uri serviceUri, string path = default, IEnumerable<ApiOperationInvokableProtocol> protocols = default, ApiVersionSetContractDetails apiVersionSet = default)
            => new GatewayApiData(ApiData(id, name, resourceType, systemData, description, authenticationSettings, subscriptionKeyParameterNames, apiType, apiRevision, apiVersion, isCurrent, isOnline, apiRevisionDescription, apiVersionDescription, apiVersionSetId, isSubscriptionRequired, termsOfServiceUri, contact, license, sourceApiId, displayName, serviceUri, path, protocols, apiVersionSet));

        /// <summary> Initializes a new instance of <see cref="Models.GatewayApiData"/>. </summary>
        public static GatewayApiData GatewayApiData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, AuthenticationSettingsContract authenticationSettings, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames, ApiType? apiType, string apiRevision, string apiVersion, bool? isCurrent, bool? isOnline, string apiRevisionDescription, string apiVersionDescription, ResourceIdentifier apiVersionSetId, bool? isSubscriptionRequired, string termsOfServiceLink, ApiContactInformation contact, ApiLicenseInformation license, ResourceIdentifier sourceApiId, string displayName, string serviceLink, string path, IEnumerable<ApiOperationInvokableProtocol> protocols, ApiVersionSetContractDetails apiVersionSet)
            => new GatewayApiData(ApiData(id, name, resourceType, systemData, description, authenticationSettings, subscriptionKeyParameterNames, apiType, apiRevision, apiVersion, isCurrent, isOnline, apiRevisionDescription, apiVersionDescription, apiVersionSetId, isSubscriptionRequired, termsOfServiceLink, contact, license, sourceApiId, displayName, serviceLink, path, protocols, apiVersionSet));

        /// <summary> Initializes a new instance of <see cref="Models.GatewayApiData"/>. </summary>
        public static GatewayApiData GatewayApiData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string description = default, AuthenticationSettingsContract authenticationSettings = default, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames = default, ApiType? apiType = default, string apiRevision = default, string apiVersion = default, bool? isCurrent = default, bool? isOnline = default, string apiRevisionDescription = default, string apiVersionDescription = default, ResourceIdentifier apiVersionSetId = default, bool? isSubscriptionRequired = default, string termsOfServiceLink = default, ApiContactInformation contact = default, ApiLicenseInformation license = default, ResourceIdentifier sourceApiId = default, string displayName = default, string serviceLink = default, string path = default, IEnumerable<ApiOperationInvokableProtocol> protocols = default, ApiVersionSetContractDetails apiVersionSet = default, string provisioningState = default)
            => new GatewayApiData(ApiData(id, name, resourceType, systemData, description, authenticationSettings, subscriptionKeyParameterNames, apiType, apiRevision, apiVersion, isCurrent, isOnline, apiRevisionDescription, apiVersionDescription, apiVersionSetId, isSubscriptionRequired, termsOfServiceLink, contact, license, sourceApiId, displayName, serviceLink, path, protocols, apiVersionSet, provisioningState));

        /// <summary> Initializes a new instance of <see cref="Models.ProductApiData"/>. </summary>
        public static ProductApiData ProductApiData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, AuthenticationSettingsContract authenticationSettings, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames, ApiType? apiType, string apiRevision, string apiVersion, bool? isCurrent, bool? isOnline, string apiRevisionDescription, string apiVersionDescription, ResourceIdentifier apiVersionSetId, bool? isSubscriptionRequired, Uri termsOfServiceUri, ApiContactInformation contact, ApiLicenseInformation license, ResourceIdentifier sourceApiId, string displayName, Uri serviceUri, string path = default, IEnumerable<ApiOperationInvokableProtocol> protocols = default, ApiVersionSetContractDetails apiVersionSet = default)
            => new ProductApiData(ApiData(id, name, resourceType, systemData, description, authenticationSettings, subscriptionKeyParameterNames, apiType, apiRevision, apiVersion, isCurrent, isOnline, apiRevisionDescription, apiVersionDescription, apiVersionSetId, isSubscriptionRequired, termsOfServiceUri, contact, license, sourceApiId, displayName, serviceUri, path, protocols, apiVersionSet));

        /// <summary> Initializes a new instance of <see cref="Models.ProductApiData"/>. </summary>
        public static ProductApiData ProductApiData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, AuthenticationSettingsContract authenticationSettings, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames, ApiType? apiType, string apiRevision, string apiVersion, bool? isCurrent, bool? isOnline, string apiRevisionDescription, string apiVersionDescription, ResourceIdentifier apiVersionSetId, bool? isSubscriptionRequired, string termsOfServiceLink, ApiContactInformation contact, ApiLicenseInformation license, ResourceIdentifier sourceApiId, string displayName, string serviceLink, string path, IEnumerable<ApiOperationInvokableProtocol> protocols, ApiVersionSetContractDetails apiVersionSet)
            => new ProductApiData(ApiData(id, name, resourceType, systemData, description, authenticationSettings, subscriptionKeyParameterNames, apiType, apiRevision, apiVersion, isCurrent, isOnline, apiRevisionDescription, apiVersionDescription, apiVersionSetId, isSubscriptionRequired, termsOfServiceLink, contact, license, sourceApiId, displayName, serviceLink, path, protocols, apiVersionSet));

        /// <summary> Initializes a new instance of <see cref="Models.ProductApiData"/>. </summary>
        public static ProductApiData ProductApiData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string description = default, AuthenticationSettingsContract authenticationSettings = default, SubscriptionKeyParameterNamesContract subscriptionKeyParameterNames = default, ApiType? apiType = default, string apiRevision = default, string apiVersion = default, bool? isCurrent = default, bool? isOnline = default, string apiRevisionDescription = default, string apiVersionDescription = default, ResourceIdentifier apiVersionSetId = default, bool? isSubscriptionRequired = default, string termsOfServiceLink = default, ApiContactInformation contact = default, ApiLicenseInformation license = default, ResourceIdentifier sourceApiId = default, string displayName = default, string serviceLink = default, string path = default, IEnumerable<ApiOperationInvokableProtocol> protocols = default, ApiVersionSetContractDetails apiVersionSet = default, string provisioningState = default)
            => new ProductApiData(ApiData(id, name, resourceType, systemData, description, authenticationSettings, subscriptionKeyParameterNames, apiType, apiRevision, apiVersion, isCurrent, isOnline, apiRevisionDescription, apiVersionDescription, apiVersionSetId, isSubscriptionRequired, termsOfServiceLink, contact, license, sourceApiId, displayName, serviceLink, path, protocols, apiVersionSet, provisioningState));

        /// <summary> Initializes a new instance of <see cref="Models.ProductGroupData"/>. </summary>
        public static ProductGroupData ProductGroupData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string displayName = default, string description = default, bool? isBuiltIn = default, ApiManagementGroupType? groupType = default, string externalId = default)
            => new ProductGroupData(ApiManagementGroupData(id, name, resourceType, systemData, displayName, description, isBuiltIn, groupType, externalId));
    }
}
