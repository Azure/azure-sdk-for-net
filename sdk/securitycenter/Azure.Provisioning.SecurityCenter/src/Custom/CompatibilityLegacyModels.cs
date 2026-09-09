// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.Primitives;

#nullable disable
#pragma warning disable CS1591 // Compatibility models preserve the released beta.1 API.

namespace Azure.Provisioning.SecurityCenter;

public partial class AdaptiveApplicationControlIssueSummary : ProvisionableConstruct
{
    private BicepValue<AdaptiveApplicationControlIssue> _issue;
    private BicepValue<float> _numberOfVms;

    public AdaptiveApplicationControlIssueSummary()
    {
    }

    public BicepValue<AdaptiveApplicationControlIssue> Issue
    {
        get
        {
            Initialize();
            return _issue;
        }
    }

    public BicepValue<float> NumberOfVms
    {
        get
        {
            Initialize();
            return _numberOfVms;
        }
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _issue = DefineProperty<AdaptiveApplicationControlIssue>(nameof(Issue), new[] { "issue" }, isOutput: true);
        _numberOfVms = DefineProperty<float>(nameof(NumberOfVms), new[] { "numberOfVms" }, isOutput: true);
    }
}

public partial class AuthenticationDetailsProperties : ProvisionableConstruct
{
    private BicepValue<AuthenticationProvisioningState> _authenticationProvisioningState;
    private BicepList<SecurityCenterCloudPermission> _grantedPermissions;

    public AuthenticationDetailsProperties()
    {
    }

    public BicepValue<AuthenticationProvisioningState> AuthenticationProvisioningState
    {
        get
        {
            Initialize();
            return _authenticationProvisioningState;
        }
    }

    public BicepList<SecurityCenterCloudPermission> GrantedPermissions
    {
        get
        {
            Initialize();
            return _grantedPermissions;
        }
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _authenticationProvisioningState = DefineProperty<AuthenticationProvisioningState>(
            nameof(AuthenticationProvisioningState),
            new[] { "authenticationProvisioningState" },
            isOutput: true);
        _grantedPermissions = DefineListProperty<SecurityCenterCloudPermission>(
            nameof(GrantedPermissions),
            new[] { "grantedPermissions" },
            isOutput: true);
    }
}

public partial class AwsAssumeRoleAuthenticationDetailsProperties : AuthenticationDetailsProperties
{
    private BicepValue<string> _accountId;
    private BicepValue<string> _awsAssumeRoleArn;
    private BicepValue<Guid> _awsExternalId;

    public AwsAssumeRoleAuthenticationDetailsProperties()
    {
    }

    public BicepValue<string> AccountId
    {
        get
        {
            Initialize();
            return _accountId;
        }
    }

    public BicepValue<string> AwsAssumeRoleArn
    {
        get
        {
            Initialize();
            return _awsAssumeRoleArn;
        }
        set
        {
            Initialize();
            _awsAssumeRoleArn.Assign(value);
        }
    }

    public BicepValue<Guid> AwsExternalId
    {
        get
        {
            Initialize();
            return _awsExternalId;
        }
        set
        {
            Initialize();
            _awsExternalId.Assign(value);
        }
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _accountId = DefineProperty<string>(nameof(AccountId), new[] { "accountId" }, isOutput: true);
        _awsAssumeRoleArn = DefineProperty<string>(nameof(AwsAssumeRoleArn), new[] { "awsAssumeRoleArn" });
        _awsExternalId = DefineProperty<Guid>(nameof(AwsExternalId), new[] { "awsExternalId" });
    }
}

public partial class AwsCredsAuthenticationDetailsProperties : AuthenticationDetailsProperties
{
    private BicepValue<string> _accountId;
    private BicepValue<string> _awsAccessKeyId;
    private BicepValue<string> _awsSecretAccessKey;

    public AwsCredsAuthenticationDetailsProperties()
    {
    }

    public BicepValue<string> AccountId
    {
        get
        {
            Initialize();
            return _accountId;
        }
    }

    public BicepValue<string> AwsAccessKeyId
    {
        get
        {
            Initialize();
            return _awsAccessKeyId;
        }
        set
        {
            Initialize();
            _awsAccessKeyId.Assign(value);
        }
    }

    public BicepValue<string> AwsSecretAccessKey
    {
        get
        {
            Initialize();
            return _awsSecretAccessKey;
        }
        set
        {
            Initialize();
            _awsSecretAccessKey.Assign(value);
        }
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _accountId = DefineProperty<string>(nameof(AccountId), new[] { "accountId" }, isOutput: true);
        _awsAccessKeyId = DefineProperty<string>(nameof(AwsAccessKeyId), new[] { "awsAccessKeyId" });
        _awsSecretAccessKey = DefineProperty<string>(nameof(AwsSecretAccessKey), new[] { "awsSecretAccessKey" });
    }
}

public partial class GcpCredentialsDetailsProperties : AuthenticationDetailsProperties
{
    private BicepValue<Uri> _authProviderX509CertUri;
    private BicepValue<Uri> _authUri;
    private BicepValue<string> _clientEmail;
    private BicepValue<string> _clientId;
    private BicepValue<Uri> _clientX509CertUri;
    private BicepValue<string> _gcpCredentialType;
    private BicepValue<string> _organizationId;
    private BicepValue<string> _privateKey;
    private BicepValue<string> _privateKeyId;
    private BicepValue<string> _projectId;
    private BicepValue<Uri> _tokenUri;

    public GcpCredentialsDetailsProperties()
    {
    }

    public BicepValue<Uri> AuthProviderX509CertUri { get { Initialize(); return _authProviderX509CertUri; } set { Initialize(); _authProviderX509CertUri.Assign(value); } }
    public BicepValue<Uri> AuthUri { get { Initialize(); return _authUri; } set { Initialize(); _authUri.Assign(value); } }
    public BicepValue<string> ClientEmail { get { Initialize(); return _clientEmail; } set { Initialize(); _clientEmail.Assign(value); } }
    public BicepValue<string> ClientId { get { Initialize(); return _clientId; } set { Initialize(); _clientId.Assign(value); } }
    public BicepValue<Uri> ClientX509CertUri { get { Initialize(); return _clientX509CertUri; } set { Initialize(); _clientX509CertUri.Assign(value); } }
    public BicepValue<string> GcpCredentialType { get { Initialize(); return _gcpCredentialType; } set { Initialize(); _gcpCredentialType.Assign(value); } }
    public BicepValue<string> OrganizationId { get { Initialize(); return _organizationId; } set { Initialize(); _organizationId.Assign(value); } }
    public BicepValue<string> PrivateKey { get { Initialize(); return _privateKey; } set { Initialize(); _privateKey.Assign(value); } }
    public BicepValue<string> PrivateKeyId { get { Initialize(); return _privateKeyId; } set { Initialize(); _privateKeyId.Assign(value); } }
    public BicepValue<string> ProjectId { get { Initialize(); return _projectId; } set { Initialize(); _projectId.Assign(value); } }
    public BicepValue<Uri> TokenUri { get { Initialize(); return _tokenUri; } set { Initialize(); _tokenUri.Assign(value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _authProviderX509CertUri = DefineProperty<Uri>(nameof(AuthProviderX509CertUri), new[] { "authProviderX509CertUri" });
        _authUri = DefineProperty<Uri>(nameof(AuthUri), new[] { "authUri" });
        _clientEmail = DefineProperty<string>(nameof(ClientEmail), new[] { "clientEmail" });
        _clientId = DefineProperty<string>(nameof(ClientId), new[] { "clientId" });
        _clientX509CertUri = DefineProperty<Uri>(nameof(ClientX509CertUri), new[] { "clientX509CertUri" });
        _gcpCredentialType = DefineProperty<string>(nameof(GcpCredentialType), new[] { "type" });
        _organizationId = DefineProperty<string>(nameof(OrganizationId), new[] { "organizationId" });
        _privateKey = DefineProperty<string>(nameof(PrivateKey), new[] { "privateKey" });
        _privateKeyId = DefineProperty<string>(nameof(PrivateKeyId), new[] { "privateKeyId" });
        _projectId = DefineProperty<string>(nameof(ProjectId), new[] { "projectId" });
        _tokenUri = DefineProperty<Uri>(nameof(TokenUri), new[] { "tokenUri" });
    }
}

public partial class ProxyServerProperties : ProvisionableConstruct
{
    private BicepValue<string> _ip;
    private BicepValue<string> _port;

    public ProxyServerProperties()
    {
    }

    public BicepValue<string> IP { get { Initialize(); return _ip; } set { Initialize(); _ip.Assign(value); } }
    public BicepValue<string> Port { get { Initialize(); return _port; } set { Initialize(); _port.Assign(value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _ip = DefineProperty<string>(nameof(IP), new[] { "ip" });
        _port = DefineProperty<string>(nameof(Port), new[] { "port" });
    }
}

public partial class ServicePrincipalProperties : ProvisionableConstruct
{
    private BicepValue<Guid> _applicationId;
    private BicepValue<string> _secret;

    public ServicePrincipalProperties()
    {
    }

    public BicepValue<Guid> ApplicationId { get { Initialize(); return _applicationId; } set { Initialize(); _applicationId.Assign(value); } }
    public BicepValue<string> Secret { get { Initialize(); return _secret; } set { Initialize(); _secret.Assign(value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _applicationId = DefineProperty<Guid>(nameof(ApplicationId), new[] { "applicationId" });
        _secret = DefineProperty<string>(nameof(Secret), new[] { "secret" });
    }
}

public partial class HybridComputeSettingsProperties : ProvisionableConstruct
{
    private BicepValue<AutoProvisionState> _autoProvision;
    private BicepValue<HybridComputeProvisioningState> _provisioningState;
    private ProxyServerProperties _proxyServer;
    private BicepValue<string> _region;
    private BicepValue<string> _resourceGroupName;
    private ServicePrincipalProperties _servicePrincipal;

    public HybridComputeSettingsProperties()
    {
    }

    public BicepValue<AutoProvisionState> AutoProvision { get { Initialize(); return _autoProvision; } set { Initialize(); _autoProvision.Assign(value); } }
    public BicepValue<HybridComputeProvisioningState> HybridComputeProvisioningState { get { Initialize(); return _provisioningState; } }
    public ProxyServerProperties ProxyServer { get { Initialize(); return _proxyServer; } set { Initialize(); AssignOrReplace(ref _proxyServer, value); } }
    public BicepValue<string> Region { get { Initialize(); return _region; } set { Initialize(); _region.Assign(value); } }
    public BicepValue<string> ResourceGroupName { get { Initialize(); return _resourceGroupName; } set { Initialize(); _resourceGroupName.Assign(value); } }
    public ServicePrincipalProperties ServicePrincipal { get { Initialize(); return _servicePrincipal; } set { Initialize(); AssignOrReplace(ref _servicePrincipal, value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _autoProvision = DefineProperty<AutoProvisionState>(nameof(AutoProvision), new[] { "autoProvision" });
        _provisioningState = DefineProperty<HybridComputeProvisioningState>(
            nameof(HybridComputeProvisioningState),
            new[] { "hybridComputeProvisioningState" },
            isOutput: true);
        _proxyServer = DefineModelProperty<ProxyServerProperties>(nameof(ProxyServer), new[] { "proxyServer" });
        _region = DefineProperty<string>(nameof(Region), new[] { "region" });
        _resourceGroupName = DefineProperty<string>(nameof(ResourceGroupName), new[] { "resourceGroupName" });
        _servicePrincipal = DefineModelProperty<ServicePrincipalProperties>(nameof(ServicePrincipal), new[] { "servicePrincipal" });
    }
}

public partial class SecurityCenterFileProtectionMode : ProvisionableConstruct
{
    private BicepValue<AdaptiveApplicationControlEnforcementMode> _exe;
    private BicepValue<AdaptiveApplicationControlEnforcementMode> _executable;
    private BicepValue<AdaptiveApplicationControlEnforcementMode> _msi;
    private BicepValue<AdaptiveApplicationControlEnforcementMode> _script;

    public SecurityCenterFileProtectionMode()
    {
    }

    public BicepValue<AdaptiveApplicationControlEnforcementMode> Exe { get { Initialize(); return _exe; } set { Initialize(); _exe.Assign(value); } }
    public BicepValue<AdaptiveApplicationControlEnforcementMode> Executable { get { Initialize(); return _executable; } set { Initialize(); _executable.Assign(value); } }
    public BicepValue<AdaptiveApplicationControlEnforcementMode> Msi { get { Initialize(); return _msi; } set { Initialize(); _msi.Assign(value); } }
    public BicepValue<AdaptiveApplicationControlEnforcementMode> Script { get { Initialize(); return _script; } set { Initialize(); _script.Assign(value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _exe = DefineProperty<AdaptiveApplicationControlEnforcementMode>(nameof(Exe), new[] { "exe" });
        _executable = DefineProperty<AdaptiveApplicationControlEnforcementMode>(nameof(Executable), new[] { "executable" });
        _msi = DefineProperty<AdaptiveApplicationControlEnforcementMode>(nameof(Msi), new[] { "msi" });
        _script = DefineProperty<AdaptiveApplicationControlEnforcementMode>(nameof(Script), new[] { "script" });
    }
}

public partial class SecurityCenterPublisherInfo : ProvisionableConstruct
{
    private BicepValue<string> _binaryName;
    private BicepValue<string> _productName;
    private BicepValue<string> _publisherName;
    private BicepValue<string> _version;

    public SecurityCenterPublisherInfo()
    {
    }

    public BicepValue<string> BinaryName { get { Initialize(); return _binaryName; } set { Initialize(); _binaryName.Assign(value); } }
    public BicepValue<string> ProductName { get { Initialize(); return _productName; } set { Initialize(); _productName.Assign(value); } }
    public BicepValue<string> PublisherName { get { Initialize(); return _publisherName; } set { Initialize(); _publisherName.Assign(value); } }
    public BicepValue<string> Version { get { Initialize(); return _version; } set { Initialize(); _version.Assign(value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _binaryName = DefineProperty<string>(nameof(BinaryName), new[] { "binaryName" });
        _productName = DefineProperty<string>(nameof(ProductName), new[] { "productName" });
        _publisherName = DefineProperty<string>(nameof(PublisherName), new[] { "publisherName" });
        _version = DefineProperty<string>(nameof(Version), new[] { "version" });
    }
}

public partial class UserRecommendation : ProvisionableConstruct
{
    private BicepValue<RecommendationAction> _recommendationAction;
    private BicepValue<string> _username;

    public UserRecommendation()
    {
    }

    public BicepValue<RecommendationAction> RecommendationAction { get { Initialize(); return _recommendationAction; } set { Initialize(); _recommendationAction.Assign(value); } }
    public BicepValue<string> Username { get { Initialize(); return _username; } set { Initialize(); _username.Assign(value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _recommendationAction = DefineProperty<RecommendationAction>(nameof(RecommendationAction), new[] { "recommendationAction" });
        _username = DefineProperty<string>(nameof(Username), new[] { "username" });
    }
}

public partial class VmRecommendation : ProvisionableConstruct
{
    private BicepValue<SecurityCenterConfigurationStatus> _configurationStatus;
    private BicepValue<SecurityCenterVmEnforcementSupportState> _enforcementSupport;
    private BicepValue<RecommendationAction> _recommendationAction;
    private BicepValue<ResourceIdentifier> _resourceId;

    public VmRecommendation()
    {
    }

    public BicepValue<SecurityCenterConfigurationStatus> ConfigurationStatus { get { Initialize(); return _configurationStatus; } set { Initialize(); _configurationStatus.Assign(value); } }
    public BicepValue<SecurityCenterVmEnforcementSupportState> EnforcementSupport { get { Initialize(); return _enforcementSupport; } set { Initialize(); _enforcementSupport.Assign(value); } }
    public BicepValue<RecommendationAction> RecommendationAction { get { Initialize(); return _recommendationAction; } set { Initialize(); _recommendationAction.Assign(value); } }
    public BicepValue<ResourceIdentifier> ResourceId { get { Initialize(); return _resourceId; } set { Initialize(); _resourceId.Assign(value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _configurationStatus = DefineProperty<SecurityCenterConfigurationStatus>(nameof(ConfigurationStatus), new[] { "configurationStatus" });
        _enforcementSupport = DefineProperty<SecurityCenterVmEnforcementSupportState>(nameof(EnforcementSupport), new[] { "enforcementSupport" });
        _recommendationAction = DefineProperty<RecommendationAction>(nameof(RecommendationAction), new[] { "recommendationAction" });
        _resourceId = DefineProperty<ResourceIdentifier>(nameof(ResourceId), new[] { "resourceId" });
    }
}

public partial class PathRecommendation : ProvisionableConstruct
{
    private BicepValue<RecommendationAction> _action;
    private BicepValue<SecurityCenterConfigurationStatus> _configurationStatus;
    private BicepValue<PathRecommendationFileType> _fileType;
    private BicepValue<IotSecurityRecommendationType> _iotSecurityRecommendationType;
    private BicepValue<bool> _isCommon;
    private BicepValue<string> _path;
    private SecurityCenterPublisherInfo _publisherInfo;
    private BicepList<UserRecommendation> _usernames;
    private BicepList<string> _userSids;

    public PathRecommendation()
    {
    }

    public BicepValue<RecommendationAction> Action { get { Initialize(); return _action; } set { Initialize(); _action.Assign(value); } }
    public BicepValue<SecurityCenterConfigurationStatus> ConfigurationStatus { get { Initialize(); return _configurationStatus; } set { Initialize(); _configurationStatus.Assign(value); } }
    public BicepValue<PathRecommendationFileType> FileType { get { Initialize(); return _fileType; } set { Initialize(); _fileType.Assign(value); } }
    public BicepValue<IotSecurityRecommendationType> IotSecurityRecommendationType { get { Initialize(); return _iotSecurityRecommendationType; } set { Initialize(); _iotSecurityRecommendationType.Assign(value); } }
    public BicepValue<bool> IsCommon { get { Initialize(); return _isCommon; } set { Initialize(); _isCommon.Assign(value); } }
    public BicepValue<string> Path { get { Initialize(); return _path; } set { Initialize(); _path.Assign(value); } }
    public SecurityCenterPublisherInfo PublisherInfo { get { Initialize(); return _publisherInfo; } set { Initialize(); AssignOrReplace(ref _publisherInfo, value); } }
    public BicepList<UserRecommendation> Usernames { get { Initialize(); return _usernames; } set { Initialize(); _usernames.Assign(value); } }
    public BicepList<string> UserSids { get { Initialize(); return _userSids; } set { Initialize(); _userSids.Assign(value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _action = DefineProperty<RecommendationAction>(nameof(Action), new[] { "action" });
        _configurationStatus = DefineProperty<SecurityCenterConfigurationStatus>(nameof(ConfigurationStatus), new[] { "configurationStatus" });
        _fileType = DefineProperty<PathRecommendationFileType>(nameof(FileType), new[] { "fileType" });
        _iotSecurityRecommendationType = DefineProperty<IotSecurityRecommendationType>(nameof(IotSecurityRecommendationType), new[] { "type" });
        _isCommon = DefineProperty<bool>(nameof(IsCommon), new[] { "isCommon" });
        _path = DefineProperty<string>(nameof(Path), new[] { "path" });
        _publisherInfo = DefineModelProperty<SecurityCenterPublisherInfo>(nameof(PublisherInfo), new[] { "publisherInfo" });
        _usernames = DefineListProperty<UserRecommendation>(nameof(Usernames), new[] { "usernames" });
        _userSids = DefineListProperty<string>(nameof(UserSids), new[] { "userSids" });
    }
}

public partial class InformationProtectionAwsOffering : SecurityCenterCloudOffering
{
    private BicepValue<string> _cloudRoleArn;
    private BicepValue<string> _legacyOfferingType;

    public InformationProtectionAwsOffering()
    {
    }

    public BicepValue<string> InformationProtectionCloudRoleArn
    {
        get
        {
            Initialize();
            return _cloudRoleArn;
        }
        set
        {
            Initialize();
            _cloudRoleArn.Assign(value);
        }
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _legacyOfferingType = DefineProperty<string>("LegacyOfferingType", new[] { "offeringType" }, isRequired: true);
        _legacyOfferingType.Assign("InformationProtectionAws");
        _cloudRoleArn = DefineProperty<string>(
            nameof(InformationProtectionCloudRoleArn),
            new[] { "informationProtection", "cloudRoleArn" });
    }
}
