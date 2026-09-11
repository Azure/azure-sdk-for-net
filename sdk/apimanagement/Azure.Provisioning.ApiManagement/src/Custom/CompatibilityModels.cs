// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using System.Runtime.Serialization;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ApiManagement;

// Preserve the model types and strongly typed properties shipped in 1.0.0-beta.1.
/// <summary> Criteria used to select a WSDL service and endpoint for import. </summary>
public partial class ApiCreateOrUpdatePropertiesWsdlSelector : ProvisionableConstruct
{
    private BicepValue<string> _wsdlServiceName;
    private BicepValue<string> _wsdlEndpointName;

    /// <summary> Creates a new <see cref="ApiCreateOrUpdatePropertiesWsdlSelector"/>. </summary>
    public ApiCreateOrUpdatePropertiesWsdlSelector()
    {
    }

    /// <summary> Gets or sets the name of the service to import from WSDL. </summary>
    public BicepValue<string> WsdlServiceName
    {
        get { Initialize(); return _wsdlServiceName; }
        set { Initialize(); _wsdlServiceName.Assign(value); }
    }

    /// <summary> Gets or sets the name of the endpoint to import from WSDL. </summary>
    public BicepValue<string> WsdlEndpointName
    {
        get { Initialize(); return _wsdlEndpointName; }
        set { Initialize(); _wsdlEndpointName.Assign(value); }
    }

    /// <inheritdoc />
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _wsdlServiceName = DefineProperty<string>(nameof(WsdlServiceName), ["wsdlServiceName"]);
        _wsdlEndpointName = DefineProperty<string>(nameof(WsdlEndpointName), ["wsdlEndpointName"]);
    }
}

// Provisioning generation does not emit custom ARM actions or their result models.
/// <summary> Gateway authentication keys. </summary>
public partial class GatewayKeysContract : ProvisionableConstruct
{
    private BicepValue<string> _primary;
    private BicepValue<string> _secondary;

    /// <summary> Creates a new <see cref="GatewayKeysContract"/>. </summary>
    public GatewayKeysContract()
    {
    }

    /// <summary> Gets the primary gateway key. </summary>
    public BicepValue<string> Primary
    {
        get { Initialize(); return _primary; }
    }

    /// <summary> Gets the secondary gateway key. </summary>
    public BicepValue<string> Secondary
    {
        get { Initialize(); return _secondary; }
    }

    /// <inheritdoc />
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _primary = DefineProperty<string>(nameof(Primary), ["primary"], isOutput: true);
        _secondary = DefineProperty<string>(nameof(Secondary), ["secondary"], isOutput: true);
    }
}

/// <summary> Determines which application sent the create-user request. </summary>
public enum AppType
{
    /// <summary> The legacy developer portal. </summary>
    [DataMember(Name = "portal")]
    Portal,

    /// <summary> The current developer portal. </summary>
    [DataMember(Name = "developerPortal")]
    DeveloperPortal,
}

/// <summary> Determines the confirmation email sent to a newly created user. </summary>
public enum ConfirmationEmailType
{
    /// <summary> Confirm that the user signed up successfully. </summary>
    [DataMember(Name = "signup")]
    SignUp,

    /// <summary> Invite the user to complete registration. </summary>
    [DataMember(Name = "invite")]
    Invite,
}

/// <summary> The content format used when importing an API. </summary>
public enum ContentFormat
{
    /// <summary> Inline WADL XML. </summary>
    [DataMember(Name = "wadl-xml")]
    WadlXml,

    /// <summary> A link to a WADL document. </summary>
    [DataMember(Name = "wadl-link-json")]
    WadlLinkJson,

    /// <summary> Inline OpenAPI 2.0 JSON. </summary>
    [DataMember(Name = "swagger-json")]
    SwaggerJson,

    /// <summary> A link to an OpenAPI 2.0 JSON document. </summary>
    [DataMember(Name = "swagger-link-json")]
    SwaggerLinkJson,

    /// <summary> Inline WSDL. </summary>
    [DataMember(Name = "wsdl")]
    Wsdl,

    /// <summary> A link to a WSDL document. </summary>
    [DataMember(Name = "wsdl-link")]
    WsdlLink,

    /// <summary> Inline OpenAPI 3.0 YAML. </summary>
    [DataMember(Name = "openapi")]
    OpenApi,

    /// <summary> Inline OpenAPI 3.0 JSON. </summary>
    [DataMember(Name = "openapi+json")]
    OpenApiJson,

    /// <summary> A link to an OpenAPI 3.0 YAML document. </summary>
    [DataMember(Name = "openapi-link")]
    OpenApiLink,

    /// <summary> A link to an OpenAPI 3.0 JSON document. </summary>
    [DataMember(Name = "openapi+json-link")]
    OpenApiJsonLink,

    /// <summary> A link to a GraphQL endpoint. </summary>
    [DataMember(Name = "graphql-link")]
    GraphQLLink,

    /// <summary> Inline OData metadata. </summary>
    [DataMember(Name = "odata")]
    Odata,

    /// <summary> A link to OData metadata. </summary>
    [DataMember(Name = "odata-link")]
    OdataLink,

    /// <summary> Inline gRPC protobuf content. </summary>
    [DataMember(Name = "grpc")]
    Grpc,

    /// <summary> A link to a gRPC protobuf file. </summary>
    [DataMember(Name = "grpc-link")]
    GrpcLink,
}

/// <summary> The API type used when importing an API. </summary>
public enum SoapApiType
{
    /// <summary> A SOAP API with a REST front end. </summary>
    [DataMember(Name = "http")]
    SoapToRest,

    /// <summary> A SOAP API with a SOAP front end. </summary>
    [DataMember(Name = "soap")]
    SoapPassThrough,

    /// <summary> A WebSocket API. </summary>
    [DataMember(Name = "websocket")]
    WebSocket,

    /// <summary> A GraphQL API. </summary>
    [DataMember(Name = "graphql")]
    GraphQL,

    /// <summary> An OData API. </summary>
    [DataMember(Name = "odata")]
    OData,

    /// <summary> A gRPC API. </summary>
    [DataMember(Name = "grpc")]
    Grpc,

    /// <summary> A Model Context Protocol API. </summary>
    [DataMember(Name = "mcp")]
    Mcp,
}

/// <summary> Controls how required query parameters are translated. </summary>
public enum TranslateRequiredQueryParametersConduct
{
    /// <summary> Translate required query parameters to template parameters. </summary>
    [DataMember(Name = "template")]
    Template,

    /// <summary> Keep required query parameters as query parameters. </summary>
    [DataMember(Name = "query")]
    Query,
}

public partial class AdditionalLocation
{
    private BicepValue<AzureLocation> _compatibilityLocation;
    private BicepList<IPAddress> _compatibilityPublicIPAddresses;
    private BicepList<IPAddress> _compatibilityPrivateIPAddresses;
    private BicepValue<Uri> _compatibilityGatewayRegionalUri;

    /// <summary> Gets or sets the Azure location. </summary>
    [CodeGenMember("Location")]
    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _compatibilityLocation; }
        set { Initialize(); _compatibilityLocation.Assign(value); }
    }

    /// <summary> Gets the public IP addresses. </summary>
    [CodeGenMember("PublicIPAddresses")]
    public BicepList<IPAddress> PublicIPAddresses
    {
        get { Initialize(); return _compatibilityPublicIPAddresses; }
    }

    /// <summary> Gets the private IP addresses. </summary>
    [CodeGenMember("PrivateIPAddresses")]
    public BicepList<IPAddress> PrivateIPAddresses
    {
        get { Initialize(); return _compatibilityPrivateIPAddresses; }
    }

    /// <summary> Gets the regional gateway URI. </summary>
    [CodeGenMember("GatewayRegionalUri")]
    public BicepValue<Uri> GatewayRegionalUri
    {
        get { Initialize(); return _compatibilityGatewayRegionalUri; }
    }

    partial void DefineAdditionalProperties()
    {
        _compatibilityLocation = DefineProperty<AzureLocation>(nameof(Location), ["location"]);
        _compatibilityPublicIPAddresses = DefineListProperty<IPAddress>(nameof(PublicIPAddresses), ["publicIPAddresses"], isOutput: true);
        _compatibilityPrivateIPAddresses = DefineListProperty<IPAddress>(nameof(PrivateIPAddresses), ["privateIPAddresses"], isOutput: true);
        _compatibilityGatewayRegionalUri = DefineProperty<Uri>(nameof(GatewayRegionalUri), ["gatewayRegionalUrl"], isOutput: true);
    }
}

public partial class ApiContactInformation
{
    private BicepValue<Uri> _compatibilityUri;

    /// <summary> Gets or sets the contact URI. </summary>
    [CodeGenMember("Uri")]
    public BicepValue<Uri> Uri
    {
        get { Initialize(); return _compatibilityUri; }
        set { Initialize(); _compatibilityUri.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityUri = DefineProperty<Uri>(nameof(Uri), ["url"]);
}

public partial class ApiLicenseInformation
{
    private BicepValue<Uri> _compatibilityUri;

    /// <summary> Gets or sets the license URI. </summary>
    [CodeGenMember("Uri")]
    public BicepValue<Uri> Uri
    {
        get { Initialize(); return _compatibilityUri; }
        set { Initialize(); _compatibilityUri.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityUri = DefineProperty<Uri>(nameof(Uri), ["url"]);
}

public partial class AuthorizationProviderOAuth2Settings
{
    private BicepValue<Uri> _compatibilityRedirectUri;

    /// <summary> Gets or sets the OAuth redirect URI. </summary>
    [CodeGenMember("RedirectUri")]
    public BicepValue<Uri> RedirectUri
    {
        get { Initialize(); return _compatibilityRedirectUri; }
        set { Initialize(); _compatibilityRedirectUri.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityRedirectUri = DefineProperty<Uri>(nameof(RedirectUri), ["redirectUrl"]);
}

public partial class BackendProxyContract
{
    private BicepValue<Uri> _compatibilityUri;

    /// <summary> Gets or sets the proxy URI. </summary>
    [CodeGenMember("Uri")]
    public BicepValue<Uri> Uri
    {
        get { Initialize(); return _compatibilityUri; }
        set { Initialize(); _compatibilityUri.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityUri = DefineProperty<Uri>(nameof(Uri), ["url"]);
}

public partial class HostnameConfiguration
{
    private BicepValue<Uri> _compatibilityKeyVaultSecretUri;

    /// <summary> Gets or sets the Key Vault secret URI. </summary>
    [CodeGenMember("KeyVaultSecretUri")]
    public BicepValue<Uri> KeyVaultSecretUri
    {
        get { Initialize(); return _compatibilityKeyVaultSecretUri; }
        set { Initialize(); _compatibilityKeyVaultSecretUri.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityKeyVaultSecretUri = DefineProperty<Uri>(nameof(KeyVaultSecretUri), ["keyVaultId"]);
}

public partial class PortalConfigDelegationProperties
{
    private BicepValue<Uri> _compatibilityDelegationUri;

    /// <summary> Gets or sets the delegation URI. </summary>
    [CodeGenMember("DelegationUri")]
    public BicepValue<Uri> DelegationUri
    {
        get { Initialize(); return _compatibilityDelegationUri; }
        set { Initialize(); _compatibilityDelegationUri.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityDelegationUri = DefineProperty<Uri>(nameof(DelegationUri), ["delegationUrl"]);
}

public partial class OpenIdAuthenticationSettingsContract
{
    private BicepList<BearerTokenSendingMethod> _compatibilityBearerTokenSendingMethods;

    /// <summary> Gets or sets how the bearer token is sent. </summary>
    [CodeGenMember("BearerTokenSendingMethods")]
    public BicepList<BearerTokenSendingMethod> BearerTokenSendingMethods
    {
        get { Initialize(); return _compatibilityBearerTokenSendingMethods; }
        set { Initialize(); _compatibilityBearerTokenSendingMethods.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityBearerTokenSendingMethods = DefineListProperty<BearerTokenSendingMethod>(
            nameof(BearerTokenSendingMethods),
            ["bearerTokenSendingMethods"]);
}

public partial class PortalConfigCspProperties
{
    private BicepList<Uri> _compatibilityReportUri;

    /// <summary> Gets or sets the CSP violation report URIs. </summary>
    [CodeGenMember("ReportUri")]
    public BicepList<Uri> ReportUri
    {
        get { Initialize(); return _compatibilityReportUri; }
        set { Initialize(); _compatibilityReportUri.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityReportUri = DefineListProperty<Uri>(nameof(ReportUri), ["reportUri"]);
}

public partial class CertificateInformation
{
    private BicepValue<DateTimeOffset> _compatibilityExpireOn;

    /// <summary> Gets or sets the certificate expiration date. </summary>
    [CodeGenMember("ExpiresOn")]
    public BicepValue<DateTimeOffset> ExpireOn
    {
        get { Initialize(); return _compatibilityExpireOn; }
        set { Initialize(); _compatibilityExpireOn.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityExpireOn = DefineProperty<DateTimeOffset>(nameof(ExpireOn), ["expiry"]);
}

internal partial class ApiEntityBaseContract
{
    private BicepValue<ResourceIdentifier> _compatibilityApiVersionSetId;

    [CodeGenMember("ApiVersionSetId")]
    public BicepValue<ResourceIdentifier> ApiVersionSetId
    {
        get { Initialize(); return _compatibilityApiVersionSetId; }
        set { Initialize(); _compatibilityApiVersionSetId.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityApiVersionSetId = DefineProperty<ResourceIdentifier>(
            nameof(ApiVersionSetId),
            ["apiVersionSetId"]);
}

internal partial class ApiContractProperties
{
    private BicepValue<ContentFormat> _compatibilityFormat;
    private BicepValue<SoapApiType> _compatibilitySoapApiType;
    private BicepValue<TranslateRequiredQueryParametersConduct> _compatibilityTranslateRequiredQueryParametersConduct;
    private BicepValue<string> _compatibilityValue;
    private ApiCreateOrUpdatePropertiesWsdlSelector _compatibilityWsdlSelector;

    public BicepValue<ContentFormat> Format
    {
        get { Initialize(); return _compatibilityFormat; }
        set { Initialize(); _compatibilityFormat.Assign(value); }
    }

    public BicepValue<SoapApiType> SoapApiType
    {
        get { Initialize(); return _compatibilitySoapApiType; }
        set { Initialize(); _compatibilitySoapApiType.Assign(value); }
    }

    public BicepValue<TranslateRequiredQueryParametersConduct> TranslateRequiredQueryParametersConduct
    {
        get { Initialize(); return _compatibilityTranslateRequiredQueryParametersConduct; }
        set { Initialize(); _compatibilityTranslateRequiredQueryParametersConduct.Assign(value); }
    }

    public BicepValue<string> Value
    {
        get { Initialize(); return _compatibilityValue; }
        set { Initialize(); _compatibilityValue.Assign(value); }
    }

    public ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector
    {
        get { Initialize(); return _compatibilityWsdlSelector; }
        set { Initialize(); AssignOrReplace(ref _compatibilityWsdlSelector, value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatibilityFormat = DefineProperty<ContentFormat>(nameof(Format), ["format"]);
        _compatibilitySoapApiType = DefineProperty<SoapApiType>(nameof(SoapApiType), ["apiType"]);
        _compatibilityTranslateRequiredQueryParametersConduct =
            DefineProperty<TranslateRequiredQueryParametersConduct>(
                nameof(TranslateRequiredQueryParametersConduct),
                ["translateRequiredQueryParameters"]);
        _compatibilityValue = DefineProperty<string>(nameof(Value), ["value"]);
        _compatibilityWsdlSelector = DefineModelProperty<ApiCreateOrUpdatePropertiesWsdlSelector>(
            nameof(WsdlSelector),
            ["wsdlSelector"]);
    }
}

internal partial class CertificateContractProperties
{
    private BicepValue<string> _compatibilityData;
    private BicepValue<string> _compatibilityPassword;
    private KeyVaultContractCreateProperties _compatibilityKeyVaultDetails;

    public BicepValue<string> Data
    {
        get { Initialize(); return _compatibilityData; }
        set { Initialize(); _compatibilityData.Assign(value); }
    }

    public BicepValue<string> Password
    {
        get { Initialize(); return _compatibilityPassword; }
        set { Initialize(); _compatibilityPassword.Assign(value); }
    }

    [CodeGenMember("KeyVaultDetails")]
    public KeyVaultContractCreateProperties KeyVaultDetails
    {
        get { Initialize(); return _compatibilityKeyVaultDetails; }
        set { Initialize(); AssignOrReplace(ref _compatibilityKeyVaultDetails, value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatibilityData = DefineProperty<string>(nameof(Data), ["data"]);
        _compatibilityPassword = DefineProperty<string>(nameof(Password), ["password"]);
        _compatibilityKeyVaultDetails = DefineModelProperty<KeyVaultContractCreateProperties>(
            nameof(KeyVaultDetails),
            ["keyVault"]);
    }
}

internal partial class UserContractProperties
{
    private BicepValue<AppType> _compatibilityAppType;
    private BicepValue<ConfirmationEmailType> _compatibilityConfirmation;
    private BicepValue<string> _compatibilityPassword;

    public BicepValue<AppType> AppType
    {
        get { Initialize(); return _compatibilityAppType; }
        set { Initialize(); _compatibilityAppType.Assign(value); }
    }

    public BicepValue<ConfirmationEmailType> Confirmation
    {
        get { Initialize(); return _compatibilityConfirmation; }
        set { Initialize(); _compatibilityConfirmation.Assign(value); }
    }

    public BicepValue<string> Password
    {
        get { Initialize(); return _compatibilityPassword; }
        set { Initialize(); _compatibilityPassword.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatibilityAppType = DefineProperty<AppType>(nameof(AppType), ["appType"]);
        _compatibilityConfirmation = DefineProperty<ConfirmationEmailType>(nameof(Confirmation), ["confirmation"]);
        _compatibilityPassword = DefineProperty<string>(nameof(Password), ["password"]);
    }
}

internal partial class AccessInformationContractProperties
{
    private BicepValue<string> _compatibilityPrimaryKey;
    private BicepValue<string> _compatibilitySecondaryKey;

    public BicepValue<string> PrimaryKey
    {
        get { Initialize(); return _compatibilityPrimaryKey; }
        set { Initialize(); _compatibilityPrimaryKey.Assign(value); }
    }

    public BicepValue<string> SecondaryKey
    {
        get { Initialize(); return _compatibilitySecondaryKey; }
        set { Initialize(); _compatibilitySecondaryKey.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatibilityPrimaryKey = DefineProperty<string>(nameof(PrimaryKey), ["primaryKey"]);
        _compatibilitySecondaryKey = DefineProperty<string>(nameof(SecondaryKey), ["secondaryKey"]);
    }
}

internal partial class NamedValueContractProperties
{
    private KeyVaultContractCreateProperties _compatibilityKeyVault;

    public KeyVaultContractCreateProperties KeyVault
    {
        get { Initialize(); return _compatibilityKeyVault; }
        set { Initialize(); AssignOrReplace(ref _compatibilityKeyVault, value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityKeyVault = DefineModelProperty<KeyVaultContractCreateProperties>(
            nameof(KeyVault),
            ["keyVault"]);
}
