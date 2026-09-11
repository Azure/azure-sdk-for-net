// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ApiManagement;

public partial class ApiGateway
{
    /// <summary> Gets or sets the backend subnet resource identifier. </summary>
    public BicepValue<ResourceIdentifier> SubnetId
    {
        get => BackendSubnetId;
        set => BackendSubnetId = value;
    }
}

public partial class ApiManagementGroup
{
    /// <summary> Gets or sets the group type. </summary>
    public BicepValue<ApiManagementGroupType> GroupType
    {
        get => ApiManagementGroupType;
        set => ApiManagementGroupType = value;
    }
}

public partial class ServiceWorkspaceGroup
{
    /// <summary> Gets or sets the group type. </summary>
    public BicepValue<ApiManagementGroupType> GroupType
    {
        get => ApiManagementGroupType;
        set => ApiManagementGroupType = value;
    }
}

public partial class ApiManagementApi
{
    /// <summary> Gets or sets the API version-set resource identifier. </summary>
    [CodeGenMember("ApiVersionSetId")]
    public BicepValue<ResourceIdentifier> ApiVersionSetId
    {
        get => Properties is null ? default : Properties.ApiVersionSetId;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.ApiVersionSetId = value;
        }
    }

    /// <summary> Gets or sets the API import format. </summary>
    public BicepValue<ContentFormat> Format
    {
        get => Properties is null ? default : Properties.Format;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.Format = value;
        }
    }

    /// <summary> Gets or sets the imported API type. </summary>
    public BicepValue<SoapApiType> SoapApiType
    {
        get => Properties is null ? default : Properties.SoapApiType;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.SoapApiType = value;
        }
    }

    /// <summary> Gets or sets how required query parameters are translated. </summary>
    public BicepValue<TranslateRequiredQueryParametersConduct> TranslateRequiredQueryParametersConduct
    {
        get => Properties is null ? default : Properties.TranslateRequiredQueryParametersConduct;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.TranslateRequiredQueryParametersConduct = value;
        }
    }

    /// <summary> Gets or sets the content used to import the API. </summary>
    public BicepValue<string> Value
    {
        get => Properties is null ? default : Properties.Value;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.Value = value;
        }
    }

    /// <summary> Gets or sets the WSDL import selector. </summary>
    public ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector
    {
        get => Properties is null ? default : Properties.WsdlSelector;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.WsdlSelector = value;
        }
    }
}

public partial class ServiceWorkspaceApi
{
    /// <summary> Gets or sets the API version-set resource identifier. </summary>
    [CodeGenMember("ApiVersionSetId")]
    public BicepValue<ResourceIdentifier> ApiVersionSetId
    {
        get => Properties is null ? default : Properties.ApiVersionSetId;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.ApiVersionSetId = value;
        }
    }

    /// <summary> Gets or sets the API import format. </summary>
    public BicepValue<ContentFormat> Format
    {
        get => Properties is null ? default : Properties.Format;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.Format = value;
        }
    }

    /// <summary> Gets or sets the imported API type. </summary>
    public BicepValue<SoapApiType> SoapApiType
    {
        get => Properties is null ? default : Properties.SoapApiType;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.SoapApiType = value;
        }
    }

    /// <summary> Gets or sets how required query parameters are translated. </summary>
    public BicepValue<TranslateRequiredQueryParametersConduct> TranslateRequiredQueryParametersConduct
    {
        get => Properties is null ? default : Properties.TranslateRequiredQueryParametersConduct;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.TranslateRequiredQueryParametersConduct = value;
        }
    }

    /// <summary> Gets or sets the content used to import the API. </summary>
    public BicepValue<string> Value
    {
        get => Properties is null ? default : Properties.Value;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.Value = value;
        }
    }

    /// <summary> Gets or sets the WSDL import selector. </summary>
    public ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector
    {
        get => Properties is null ? default : Properties.WsdlSelector;
        set
        {
            Properties ??= new ApiContractProperties();
            Properties.WsdlSelector = value;
        }
    }
}

public partial class ApiSchema
{
    private BicepValue<string> _compatibilityContentType;
    private BicepValue<string> _compatibilityValue;
    private BicepValue<BinaryData> _compatibilityDefinitions;
    private BicepValue<BinaryData> _compatibilityComponents;

    /// <summary> Gets or sets the schema document content type. </summary>
    [CodeGenMember("ContentType")]
    public BicepValue<string> ContentType
    {
        get { Initialize(); return _compatibilityContentType; }
        set { Initialize(); _compatibilityContentType.Assign(value); }
    }

    /// <summary> Gets or sets the schema document value. </summary>
    [CodeGenMember("Value")]
    public BicepValue<string> Value
    {
        get { Initialize(); return _compatibilityValue; }
        set { Initialize(); _compatibilityValue.Assign(value); }
    }

    /// <summary> Gets or sets the OpenAPI v1 definitions. </summary>
    [CodeGenMember("Definitions")]
    public BicepValue<BinaryData> Definitions
    {
        get { Initialize(); return _compatibilityDefinitions; }
        set { Initialize(); _compatibilityDefinitions.Assign(value); }
    }

    /// <summary> Gets or sets the OpenAPI v2 or v3 components. </summary>
    [CodeGenMember("Components")]
    public BicepValue<BinaryData> Components
    {
        get { Initialize(); return _compatibilityComponents; }
        set { Initialize(); _compatibilityComponents.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        string[] documentPath = ResourceVersion == ResourceVersions.V2024_05_01
            ? ["properties"]
            : ["properties", "document"];
        _compatibilityContentType = DefineProperty<string>(
            nameof(ContentType),
            ["properties", "contentType"],
            isRequired: true);
        _compatibilityValue = DefineProperty<string>(nameof(Value), [.. documentPath, "value"]);
        _compatibilityDefinitions = DefineProperty<BinaryData>(nameof(Definitions), [.. documentPath, "definitions"]);
        _compatibilityComponents = DefineProperty<BinaryData>(nameof(Components), [.. documentPath, "components"]);
    }

    /// <inheritdoc />
    protected override void Resolve(ProvisioningBuildOptions options)
    {
        Initialize();
        string[] documentPath = ResourceVersion == ResourceVersions.V2024_05_01
            ? ["properties"]
            : ["properties", "document"];
        ((IBicepValue)_compatibilityValue).Self = new BicepValueReference(this, nameof(Value), [.. documentPath, "value"]);
        ((IBicepValue)_compatibilityDefinitions).Self = new BicepValueReference(this, nameof(Definitions), [.. documentPath, "definitions"]);
        ((IBicepValue)_compatibilityComponents).Self = new BicepValueReference(this, nameof(Components), [.. documentPath, "components"]);
        base.Resolve(options);
    }
}

public partial class ServiceWorkspaceApiSchema
{
    private BicepValue<string> _compatibilityContentType;
    private BicepValue<string> _compatibilityValue;
    private BicepValue<BinaryData> _compatibilityDefinitions;
    private BicepValue<BinaryData> _compatibilityComponents;

    /// <summary> Gets or sets the schema document content type. </summary>
    [CodeGenMember("ContentType")]
    public BicepValue<string> ContentType
    {
        get { Initialize(); return _compatibilityContentType; }
        set { Initialize(); _compatibilityContentType.Assign(value); }
    }

    /// <summary> Gets or sets the schema document value. </summary>
    [CodeGenMember("Value")]
    public BicepValue<string> Value
    {
        get { Initialize(); return _compatibilityValue; }
        set { Initialize(); _compatibilityValue.Assign(value); }
    }

    /// <summary> Gets or sets the OpenAPI v1 definitions. </summary>
    [CodeGenMember("Definitions")]
    public BicepValue<BinaryData> Definitions
    {
        get { Initialize(); return _compatibilityDefinitions; }
        set { Initialize(); _compatibilityDefinitions.Assign(value); }
    }

    /// <summary> Gets or sets the OpenAPI v2 or v3 components. </summary>
    [CodeGenMember("Components")]
    public BicepValue<BinaryData> Components
    {
        get { Initialize(); return _compatibilityComponents; }
        set { Initialize(); _compatibilityComponents.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        string[] documentPath = ResourceVersion == ResourceVersions.V2024_05_01
            ? ["properties"]
            : ["properties", "document"];
        _compatibilityContentType = DefineProperty<string>(
            nameof(ContentType),
            ["properties", "contentType"],
            isRequired: true);
        _compatibilityValue = DefineProperty<string>(nameof(Value), [.. documentPath, "value"]);
        _compatibilityDefinitions = DefineProperty<BinaryData>(nameof(Definitions), [.. documentPath, "definitions"]);
        _compatibilityComponents = DefineProperty<BinaryData>(nameof(Components), [.. documentPath, "components"]);
    }

    /// <inheritdoc />
    protected override void Resolve(ProvisioningBuildOptions options)
    {
        Initialize();
        string[] documentPath = ResourceVersion == ResourceVersions.V2024_05_01
            ? ["properties"]
            : ["properties", "document"];
        ((IBicepValue)_compatibilityValue).Self = new BicepValueReference(this, nameof(Value), [.. documentPath, "value"]);
        ((IBicepValue)_compatibilityDefinitions).Self = new BicepValueReference(this, nameof(Definitions), [.. documentPath, "definitions"]);
        ((IBicepValue)_compatibilityComponents).Self = new BicepValueReference(this, nameof(Components), [.. documentPath, "components"]);
        base.Resolve(options);
    }
}

public partial class ApiManagementCertificate
{
    /// <summary> Gets or sets the base64-encoded certificate data. </summary>
    public BicepValue<string> Data
    {
        get => Properties is null ? default : Properties.Data;
        set
        {
            Properties ??= new CertificateContractProperties();
            Properties.Data = value;
        }
    }

    /// <summary> Gets or sets the certificate password. </summary>
    public BicepValue<string> Password
    {
        get => Properties is null ? default : Properties.Password;
        set
        {
            Properties ??= new CertificateContractProperties();
            Properties.Password = value;
        }
    }

    /// <summary> Gets or sets the Key Vault certificate details. </summary>
    [CodeGenMember("KeyVaultDetails")]
    public KeyVaultContractCreateProperties KeyVaultDetails
    {
        get => Properties is null ? default : Properties.KeyVaultDetails;
        set
        {
            Properties ??= new CertificateContractProperties();
            Properties.KeyVaultDetails = value;
        }
    }

    /// <summary> Gets the certificate expiration date. </summary>
    public BicepValue<DateTimeOffset> ExpireOn => ExpiresOn;
}

public partial class ServiceWorkspaceCertificate
{
    /// <summary> Gets or sets the base64-encoded certificate data. </summary>
    public BicepValue<string> Data
    {
        get => Properties is null ? default : Properties.Data;
        set
        {
            Properties ??= new CertificateContractProperties();
            Properties.Data = value;
        }
    }

    /// <summary> Gets or sets the certificate password. </summary>
    public BicepValue<string> Password
    {
        get => Properties is null ? default : Properties.Password;
        set
        {
            Properties ??= new CertificateContractProperties();
            Properties.Password = value;
        }
    }

    /// <summary> Gets or sets the Key Vault certificate details. </summary>
    [CodeGenMember("KeyVaultDetails")]
    public KeyVaultContractCreateProperties KeyVaultDetails
    {
        get => Properties is null ? default : Properties.KeyVaultDetails;
        set
        {
            Properties ??= new CertificateContractProperties();
            Properties.KeyVaultDetails = value;
        }
    }

    /// <summary> Gets the certificate expiration date. </summary>
    public BicepValue<DateTimeOffset> ExpireOn => ExpiresOn;
}

public partial class ApiManagementUser
{
    /// <summary> Gets or sets the application that sent the create-user request. </summary>
    public BicepValue<AppType> AppType
    {
        get => Properties is null ? default : Properties.AppType;
        set
        {
            Properties ??= new UserContractProperties();
            Properties.AppType = value;
        }
    }

    /// <summary> Gets or sets the confirmation email type. </summary>
    public BicepValue<ConfirmationEmailType> Confirmation
    {
        get => Properties is null ? default : Properties.Confirmation;
        set
        {
            Properties ??= new UserContractProperties();
            Properties.Confirmation = value;
        }
    }

    /// <summary> Gets or sets the user password. </summary>
    public BicepValue<string> Password
    {
        get => Properties is null ? default : Properties.Password;
        set
        {
            Properties ??= new UserContractProperties();
            Properties.Password = value;
        }
    }
}

public partial class TenantAccessInfo
{
    /// <summary> Gets or sets the primary access key. </summary>
    public BicepValue<string> PrimaryKey
    {
        get => Properties is null ? default : Properties.PrimaryKey;
        set
        {
            Properties ??= new AccessInformationContractProperties();
            Properties.PrimaryKey = value;
        }
    }

    /// <summary> Gets or sets the secondary access key. </summary>
    public BicepValue<string> SecondaryKey
    {
        get => Properties is null ? default : Properties.SecondaryKey;
        set
        {
            Properties ??= new AccessInformationContractProperties();
            Properties.SecondaryKey = value;
        }
    }
}

public partial class ApiManagementSubscription
{
    /// <summary> Gets or sets the subscription start date. </summary>
    public BicepValue<DateTimeOffset> StartOn
    {
        get => StartsOn;
        set => StartsOn = value;
    }

    /// <summary> Gets or sets the subscription expiration date. </summary>
    public BicepValue<DateTimeOffset> ExpireOn
    {
        get => ExpiresOn;
        set => ExpiresOn = value;
    }

    /// <summary> Gets or sets the subscription end date. </summary>
    public BicepValue<DateTimeOffset> EndOn
    {
        get => EndsOn;
        set => EndsOn = value;
    }
}

public partial class ServiceWorkspaceSubscription
{
    /// <summary> Gets or sets the subscription start date. </summary>
    public BicepValue<DateTimeOffset> StartOn
    {
        get => StartsOn;
        set => StartsOn = value;
    }

    /// <summary> Gets or sets the subscription expiration date. </summary>
    public BicepValue<DateTimeOffset> ExpireOn
    {
        get => ExpiresOn;
        set => ExpiresOn = value;
    }

    /// <summary> Gets or sets the subscription end date. </summary>
    public BicepValue<DateTimeOffset> EndOn
    {
        get => EndsOn;
        set => EndsOn = value;
    }
}

public partial class ApiManagementPortalDelegationSetting
{
    private BicepValue<string> _compatibilityName;

    /// <summary> Gets or sets the resource name. </summary>
    [CodeGenMember("Name")]
    public BicepValue<string> Name
    {
        get { Initialize(); return _compatibilityName; }
        set { Initialize(); _compatibilityName.Assign(value); }
    }

    /// <summary> Gets or sets whether subscription delegation is enabled. </summary>
    public BicepValue<bool> IsSubscriptionDelegationEnabled
    {
        get => SubscriptionsIsSubscriptionDelegationEnabled;
        set => SubscriptionsIsSubscriptionDelegationEnabled = value;
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityName = DefineProperty<string>(nameof(Name), ["name"], isRequired: true);
}

public partial class PortalConfigContract
{
    /// <summary> Gets or sets whether sign-in is required. </summary>
    public BicepValue<bool> Require
    {
        get => SigninRequire;
        set => SigninRequire = value;
    }
}

public partial class ApiManagementPrivateEndpointConnection
{
    private BicepValue<ResourceIdentifier> _compatibilityId;

    /// <summary> Gets or sets the private endpoint connection resource identifier. </summary>
    [CodeGenMember("Id")]
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _compatibilityId; }
        set { Initialize(); _compatibilityId.Assign(value); }
    }

    /// <summary> Gets the private-link service connection state. </summary>
    public ApiManagementPrivateLinkServiceConnectionState ConnectionState =>
        PrivateLinkServiceConnectionState;

    partial void DefineAdditionalProperties() =>
        _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), ["id"]);
}

public partial class ApiManagementNamedValue
{
    /// <summary> Gets or sets the Key Vault location details. </summary>
    public KeyVaultContractCreateProperties KeyVault
    {
        get => Properties is null ? default : Properties.KeyVault;
        set
        {
            Properties ??= new NamedValueContractProperties();
            Properties.KeyVault = value;
        }
    }
}

public partial class ServiceWorkspaceNamedValue
{
    /// <summary> Gets or sets the Key Vault location details. </summary>
    public KeyVaultContractCreateProperties KeyVault
    {
        get => Properties is null ? default : Properties.KeyVault;
        set
        {
            Properties ??= new NamedValueContractProperties();
            Properties.KeyVault = value;
        }
    }
}

public partial class ApiManagementGateway
{
    // Provisioning generation does not emit custom ARM actions yet.
    /// <summary> Gets the access keys for this gateway resource. </summary>
    /// <returns> The gateway keys. </returns>
    public GatewayKeysContract GetKeys()
    {
        GatewayKeysContract keys = new();
        ((IBicepValue)keys).Expression = new FunctionCallExpression(
            new MemberExpression(
                new IdentifierExpression(BicepIdentifier),
                "listKeys"));
        return keys;
    }
}

public partial class ApiManagementPortalSignInSetting
{
    private BicepValue<string> _compatibilityName;

    /// <summary> Gets or sets the resource name. </summary>
    [CodeGenMember("Name")]
    public BicepValue<string> Name
    {
        get { Initialize(); return _compatibilityName; }
        set { Initialize(); _compatibilityName.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityName = DefineProperty<string>(nameof(Name), ["name"], isRequired: true);
}

public partial class ApiManagementPortalSignUpSetting
{
    private BicepValue<string> _compatibilityName;

    /// <summary> Gets or sets the resource name. </summary>
    [CodeGenMember("Name")]
    public BicepValue<string> Name
    {
        get { Initialize(); return _compatibilityName; }
        set { Initialize(); _compatibilityName.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityName = DefineProperty<string>(nameof(Name), ["name"], isRequired: true);
}

public partial class ServiceApiWiki
{
    private BicepValue<string> _compatibilityName;

    /// <summary> Gets or sets the resource name. </summary>
    [CodeGenMember("Name")]
    public BicepValue<string> Name
    {
        get { Initialize(); return _compatibilityName; }
        set { Initialize(); _compatibilityName.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityName = DefineProperty<string>(nameof(Name), ["name"], isRequired: true);
}

public partial class ServiceProductWiki
{
    private BicepValue<string> _compatibilityName;

    /// <summary> Gets or sets the resource name. </summary>
    [CodeGenMember("Name")]
    public BicepValue<string> Name
    {
        get { Initialize(); return _compatibilityName; }
        set { Initialize(); _compatibilityName.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityName = DefineProperty<string>(nameof(Name), ["name"], isRequired: true);
}
