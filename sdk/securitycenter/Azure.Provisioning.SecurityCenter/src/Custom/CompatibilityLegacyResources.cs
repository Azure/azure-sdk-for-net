// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

#nullable disable
#pragma warning disable CS1591 // Compatibility resources preserve the released beta.1 API.

namespace Azure.Provisioning.SecurityCenter;

public partial class AdaptiveApplicationControlGroup : ProvisionableResource
{
    private BicepValue<SecurityCenterConfigurationStatus> _configurationStatus;
    private BicepValue<AdaptiveApplicationControlEnforcementMode> _enforcementMode;
    private BicepValue<ResourceIdentifier> _id;
    private BicepList<AdaptiveApplicationControlIssueSummary> _issues;
    private BicepValue<AzureLocation> _location;
    private BicepValue<string> _name;
    private BicepList<PathRecommendation> _pathRecommendations;
    private SecurityCenterFileProtectionMode _protectionMode;
    private BicepValue<RecommendationStatus> _recommendationStatus;
    private BicepValue<AdaptiveApplicationControlGroupSourceSystem> _sourceSystem;
    private SystemData _systemData;
    private BicepList<VmRecommendation> _vmRecommendations;

    public AdaptiveApplicationControlGroup(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Security/applicationWhitelistings", resourceVersion ?? "2020-01-01")
    {
    }

    public BicepValue<SecurityCenterConfigurationStatus> ConfigurationStatus { get { Initialize(); return _configurationStatus; } }
    public BicepValue<AdaptiveApplicationControlEnforcementMode> EnforcementMode { get { Initialize(); return _enforcementMode; } set { Initialize(); _enforcementMode.Assign(value); } }
    public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }
    public BicepList<AdaptiveApplicationControlIssueSummary> Issues { get { Initialize(); return _issues; } }
    public BicepValue<AzureLocation> Location { get { Initialize(); return _location; } }
    public BicepValue<string> Name { get { Initialize(); return _name; } set { Initialize(); _name.Assign(value); } }
    public BicepList<PathRecommendation> PathRecommendations { get { Initialize(); return _pathRecommendations; } set { Initialize(); _pathRecommendations.Assign(value); } }
    public SecurityCenterFileProtectionMode ProtectionMode { get { Initialize(); return _protectionMode; } set { Initialize(); AssignOrReplace(ref _protectionMode, value); } }
    public BicepValue<RecommendationStatus> RecommendationStatus { get { Initialize(); return _recommendationStatus; } }
    public BicepValue<AdaptiveApplicationControlGroupSourceSystem> SourceSystem { get { Initialize(); return _sourceSystem; } }
    public SystemData SystemData { get { Initialize(); return _systemData; } }
    public BicepList<VmRecommendation> VmRecommendations { get { Initialize(); return _vmRecommendations; } set { Initialize(); _vmRecommendations.Assign(value); } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new[] { "id" }, isOutput: true);
        _name = DefineProperty<string>(nameof(Name), new[] { "name" });
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new[] { "systemData" }, isOutput: true);
        _location = DefineProperty<AzureLocation>(nameof(Location), new[] { "location" }, isOutput: true);
        _configurationStatus = DefineProperty<SecurityCenterConfigurationStatus>(nameof(ConfigurationStatus), new[] { "properties", "configurationStatus" }, isOutput: true);
        _enforcementMode = DefineProperty<AdaptiveApplicationControlEnforcementMode>(nameof(EnforcementMode), new[] { "properties", "enforcementMode" });
        _issues = DefineListProperty<AdaptiveApplicationControlIssueSummary>(nameof(Issues), new[] { "properties", "issues" }, isOutput: true);
        _pathRecommendations = DefineListProperty<PathRecommendation>(nameof(PathRecommendations), new[] { "properties", "pathRecommendations" });
        _protectionMode = DefineModelProperty<SecurityCenterFileProtectionMode>(nameof(ProtectionMode), new[] { "properties", "protectionMode" });
        _recommendationStatus = DefineProperty<RecommendationStatus>(nameof(RecommendationStatus), new[] { "properties", "recommendationStatus" }, isOutput: true);
        _sourceSystem = DefineProperty<AdaptiveApplicationControlGroupSourceSystem>(nameof(SourceSystem), new[] { "properties", "sourceSystem" }, isOutput: true);
        _vmRecommendations = DefineListProperty<VmRecommendation>(nameof(VmRecommendations), new[] { "properties", "vmRecommendations" });
    }

    public static AdaptiveApplicationControlGroup FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        AdaptiveApplicationControlGroup result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }

    public static partial class ResourceVersions
    {
        public static readonly string V2020_01_01 = "2020-01-01";
    }
}

public partial class CustomAssessmentAutomation : ProvisionableResource
{
    private BicepValue<string> _assessmentKey;
    private BicepValue<string> _compressedQuery;
    private BicepValue<string> _description;
    private BicepValue<string> _displayName;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private BicepValue<string> _remediationDescription;
    private BicepValue<CustomAssessmentSeverity> _severity;
    private BicepValue<CustomAssessmentAutomationSupportedCloud> _supportedCloud;
    private SystemData _systemData;

    public CustomAssessmentAutomation(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Security/customAssessmentAutomations", resourceVersion ?? "2019-01-01-preview")
    {
    }

    public BicepValue<string> AssessmentKey { get { Initialize(); return _assessmentKey; } }
    public BicepValue<string> CompressedQuery { get { Initialize(); return _compressedQuery; } set { Initialize(); _compressedQuery.Assign(value); } }
    public BicepValue<string> Description { get { Initialize(); return _description; } set { Initialize(); _description.Assign(value); } }
    public BicepValue<string> DisplayName { get { Initialize(); return _displayName; } set { Initialize(); _displayName.Assign(value); } }
    public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }
    public BicepValue<string> Name { get { Initialize(); return _name; } set { Initialize(); _name.Assign(value); } }
    public BicepValue<string> RemediationDescription { get { Initialize(); return _remediationDescription; } set { Initialize(); _remediationDescription.Assign(value); } }
    public BicepValue<CustomAssessmentSeverity> Severity { get { Initialize(); return _severity; } set { Initialize(); _severity.Assign(value); } }
    public BicepValue<CustomAssessmentAutomationSupportedCloud> SupportedCloud { get { Initialize(); return _supportedCloud; } set { Initialize(); _supportedCloud.Assign(value); } }
    public SystemData SystemData { get { Initialize(); return _systemData; } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new[] { "id" }, isOutput: true);
        _name = DefineProperty<string>(nameof(Name), new[] { "name" });
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new[] { "systemData" }, isOutput: true);
        _assessmentKey = DefineProperty<string>(nameof(AssessmentKey), new[] { "properties", "assessmentKey" }, isOutput: true);
        _compressedQuery = DefineProperty<string>(nameof(CompressedQuery), new[] { "properties", "compressedQuery" });
        _description = DefineProperty<string>(nameof(Description), new[] { "properties", "description" });
        _displayName = DefineProperty<string>(nameof(DisplayName), new[] { "properties", "displayName" });
        _remediationDescription = DefineProperty<string>(nameof(RemediationDescription), new[] { "properties", "remediationDescription" });
        _severity = DefineProperty<CustomAssessmentSeverity>(nameof(Severity), new[] { "properties", "severity" });
        _supportedCloud = DefineProperty<CustomAssessmentAutomationSupportedCloud>(nameof(SupportedCloud), new[] { "properties", "supportedCloud" });
    }

    public static CustomAssessmentAutomation FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        CustomAssessmentAutomation result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}

public partial class CustomEntityStoreAssignment : ProvisionableResource
{
    private BicepValue<string> _entityStoreDatabaseLink;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private BicepValue<string> _principal;
    private SystemData _systemData;

    public CustomEntityStoreAssignment(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Security/customEntityStoreAssignments", resourceVersion ?? "2019-08-01-preview")
    {
    }

    public BicepValue<string> EntityStoreDatabaseLink { get { Initialize(); return _entityStoreDatabaseLink; } }
    public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }
    public BicepValue<string> Name { get { Initialize(); return _name; } set { Initialize(); _name.Assign(value); } }
    public BicepValue<string> Principal { get { Initialize(); return _principal; } set { Initialize(); _principal.Assign(value); } }
    public SystemData SystemData { get { Initialize(); return _systemData; } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new[] { "id" }, isOutput: true);
        _name = DefineProperty<string>(nameof(Name), new[] { "name" });
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new[] { "systemData" }, isOutput: true);
        _entityStoreDatabaseLink = DefineProperty<string>(nameof(EntityStoreDatabaseLink), new[] { "properties", "entityStoreDatabaseLink" }, isOutput: true);
        _principal = DefineProperty<string>(nameof(Principal), new[] { "properties", "principal" });
    }

    public static CustomEntityStoreAssignment FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        CustomEntityStoreAssignment result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}

public partial class SecurityCloudConnector : ProvisionableResource
{
    private AuthenticationDetailsProperties _authenticationDetails;
    private HybridComputeSettingsProperties _hybridComputeSettings;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private SystemData _systemData;

    public SecurityCloudConnector(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Security/securityConnectors", resourceVersion ?? "2020-01-01-preview")
    {
    }

    public AuthenticationDetailsProperties AuthenticationDetails { get { Initialize(); return _authenticationDetails; } set { Initialize(); AssignOrReplace(ref _authenticationDetails, value); } }
    public HybridComputeSettingsProperties HybridComputeSettings { get { Initialize(); return _hybridComputeSettings; } set { Initialize(); AssignOrReplace(ref _hybridComputeSettings, value); } }
    public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }
    public BicepValue<string> Name { get { Initialize(); return _name; } set { Initialize(); _name.Assign(value); } }
    public SystemData SystemData { get { Initialize(); return _systemData; } }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new[] { "id" }, isOutput: true);
        _name = DefineProperty<string>(nameof(Name), new[] { "name" });
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new[] { "systemData" }, isOutput: true);
        _authenticationDetails = DefineModelProperty<AuthenticationDetailsProperties>(nameof(AuthenticationDetails), new[] { "properties", "authenticationDetails" });
        _hybridComputeSettings = DefineModelProperty<HybridComputeSettingsProperties>(nameof(HybridComputeSettings), new[] { "properties", "hybridComputeSettings" });
    }

    public static SecurityCloudConnector FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        SecurityCloudConnector result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}
