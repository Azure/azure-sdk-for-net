// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.SecurityCenter;

public partial class DataExportSettings
{
    /// <summary> Gets or sets whether the setting is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class SecurityAlertSyncSettings
{
    /// <summary> Gets or sets whether the setting is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderCspmAwsOfferingDatabasesDspm
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderCspmAwsOfferingDataSensitivityDiscovery
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderCspmAwsOfferingMdcContainersAgentlessDiscoveryK8S
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderCspmAwsOfferingMdcContainersImageAssessment
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderCspmGcpOfferingDataSensitivityDiscovery
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderCspmGcpOfferingMdcContainersAgentlessDiscoveryK8S
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderCspmGcpOfferingMdcContainersImageAssessment
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderCspmGcpOfferingVmScanners
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderFoDatabasesAwsOfferingDatabasesDspm
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForContainersAwsOfferingMdcContainersAgentlessDiscoveryK8S
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForContainersAwsOfferingMdcContainersImageAssessment
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForContainersGcpOfferingMdcContainersAgentlessDiscoveryK8S
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForContainersGcpOfferingMdcContainersImageAssessment
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForDatabasesAwsOfferingArcAutoProvisioning
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForDatabasesAwsOfferingRds
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForDatabasesGcpOfferingArcAutoProvisioning
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForServersAwsOfferingArcAutoProvisioning
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForServersAwsOfferingMdeAutoProvisioning
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForServersAwsOfferingVmScanners
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForServersGcpOfferingArcAutoProvisioning
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForServersGcpOfferingMdeAutoProvisioning
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class DefenderForServersGcpOfferingVmScanners
{
    /// <summary> Gets or sets whether the offering is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Enabled;
        set => Enabled = value;
    }
}

public partial class AdditionalWorkspacesProperties
{
    /// <summary> Gets or sets the additional workspace type. </summary>
    public BicepValue<AdditionalWorkspaceType> WorkspaceType
    {
        get => Type;
        set => Type = value;
    }
}

public partial class DefenderForServersAwsOffering
{
    /// <summary> Gets or sets the available sub-plan type. </summary>
    public BicepValue<AvailableSubPlanType> AvailableSubPlanType
    {
        get => SubPlanType;
        set => SubPlanType = value;
    }
}

public partial class DefenderForServersGcpOffering
{
    private DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning _legacyVulnerabilityAssessmentAutoProvisioning;

    /// <summary> Gets or sets the available sub-plan type. </summary>
    public BicepValue<AvailableSubPlanType> AvailableSubPlanType
    {
        get => SubPlanType;
        set => SubPlanType = value;
    }

    /// <summary> Gets or sets vulnerability assessment auto-provisioning. </summary>
    public DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning VulnerabilityAssessmentAutoProvisioning
    {
        get
        {
            Initialize();
            return _legacyVulnerabilityAssessmentAutoProvisioning;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _legacyVulnerabilityAssessmentAutoProvisioning, value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyVulnerabilityAssessmentAutoProvisioning =
            DefineModelProperty<DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning>(
                nameof(VulnerabilityAssessmentAutoProvisioning),
                new string[] { "vulnerabilityAssessmentAutoProvisioning" });
    }
}

public partial class DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning
{
    /// <summary> Gets or sets the vulnerability assessment auto-provisioning type. </summary>
    public BicepValue<VulnerabilityAssessmentAutoProvisioningType> VulnerabilityAssessmentAutoProvisioningType
    {
        get => Type;
        set => Type = value;
    }
}

public partial class DefenderCspmAwsOfferingVmScanners
{
    /// <summary> Gets or sets the VM scanner configuration. </summary>
    public new DefenderCspmAwsOfferingVmScannersConfiguration Configuration
    {
        get
        {
            if (base.Configuration is not DefenderCspmAwsOfferingVmScannersConfiguration configuration)
            {
                configuration = new DefenderCspmAwsOfferingVmScannersConfiguration();
                base.Configuration = configuration;
            }
            return configuration;
        }
        set => base.Configuration = value;
    }
}

public partial class DefenderCspmGcpOfferingVmScanners
{
    /// <summary> Gets or sets the VM scanner configuration. </summary>
    public new DefenderCspmGcpOfferingVmScannersConfiguration Configuration
    {
        get
        {
            if (base.Configuration is not DefenderCspmGcpOfferingVmScannersConfiguration configuration)
            {
                configuration = new DefenderCspmGcpOfferingVmScannersConfiguration();
                base.Configuration = configuration;
            }
            return configuration;
        }
        set => base.Configuration = value;
    }
}

public partial class DefenderForDatabasesGcpOfferingArcAutoProvisioning
{
    /// <summary> Gets or sets the Arc auto-provisioning configuration. </summary>
    public new DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration Configuration
    {
        get
        {
            if (base.Configuration is not DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration configuration)
            {
                configuration = new DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration();
                base.Configuration = configuration;
            }
            return configuration;
        }
        set => base.Configuration = value;
    }
}

public partial class DefenderForServersAwsOfferingArcAutoProvisioning
{
    /// <summary> Gets or sets the Arc auto-provisioning configuration. </summary>
    public new DefenderForServersAwsOfferingArcAutoProvisioningConfiguration Configuration
    {
        get
        {
            if (base.Configuration is not DefenderForServersAwsOfferingArcAutoProvisioningConfiguration configuration)
            {
                configuration = new DefenderForServersAwsOfferingArcAutoProvisioningConfiguration();
                base.Configuration = configuration;
            }
            return configuration;
        }
        set => base.Configuration = value;
    }
}

public partial class DefenderForServersAwsOfferingVmScanners
{
    /// <summary> Gets or sets the VM scanner configuration. </summary>
    public new DefenderForServersAwsOfferingVmScannersConfiguration Configuration
    {
        get
        {
            if (base.Configuration is not DefenderForServersAwsOfferingVmScannersConfiguration configuration)
            {
                configuration = new DefenderForServersAwsOfferingVmScannersConfiguration();
                base.Configuration = configuration;
            }
            return configuration;
        }
        set => base.Configuration = value;
    }
}

public partial class DefenderForServersGcpOfferingArcAutoProvisioning
{
    /// <summary> Gets or sets the Arc auto-provisioning configuration. </summary>
    public new DefenderForServersGcpOfferingArcAutoProvisioningConfiguration Configuration
    {
        get
        {
            if (base.Configuration is not DefenderForServersGcpOfferingArcAutoProvisioningConfiguration configuration)
            {
                configuration = new DefenderForServersGcpOfferingArcAutoProvisioningConfiguration();
                base.Configuration = configuration;
            }
            return configuration;
        }
        set => base.Configuration = value;
    }
}

public partial class DefenderForServersGcpOfferingVmScanners
{
    /// <summary> Gets or sets the VM scanner configuration. </summary>
    public new DefenderForServersGcpOfferingVmScannersConfiguration Configuration
    {
        get
        {
            if (base.Configuration is not DefenderForServersGcpOfferingVmScannersConfiguration configuration)
            {
                configuration = new DefenderForServersGcpOfferingVmScannersConfiguration();
                base.Configuration = configuration;
            }
            return configuration;
        }
        set => base.Configuration = value;
    }
}

public partial class DefenderForContainersAwsOffering
{
    private BicepValue<string> _legacyKubernetesScubaReaderCloudRoleArn;
    private BicepValue<string> _legacyContainerVulnerabilityAssessmentCloudRoleArn;
    private BicepValue<string> _legacyContainerVulnerabilityAssessmentTaskCloudRoleArn;
    private BicepValue<bool> _legacyIsContainerVulnerabilityAssessmentEnabled;
    private BicepValue<bool> _legacyIsAutoProvisioningEnabled;
    private BicepValue<string> _legacyScubaExternalId;

    /// <summary> Gets or sets the Kubernetes data reader cloud role ARN. </summary>
    public BicepValue<string> KubernetesScubaReaderCloudRoleArn
    {
        get
        {
            Initialize();
            return _legacyKubernetesScubaReaderCloudRoleArn;
        }
        set
        {
            Initialize();
            _legacyKubernetesScubaReaderCloudRoleArn.Assign(value);
        }
    }

    /// <summary> Gets or sets the container vulnerability assessment cloud role ARN. </summary>
    public BicepValue<string> ContainerVulnerabilityAssessmentCloudRoleArn
    {
        get
        {
            Initialize();
            return _legacyContainerVulnerabilityAssessmentCloudRoleArn;
        }
        set
        {
            Initialize();
            _legacyContainerVulnerabilityAssessmentCloudRoleArn.Assign(value);
        }
    }

    /// <summary> Gets or sets the container vulnerability assessment task cloud role ARN. </summary>
    public BicepValue<string> ContainerVulnerabilityAssessmentTaskCloudRoleArn
    {
        get
        {
            Initialize();
            return _legacyContainerVulnerabilityAssessmentTaskCloudRoleArn;
        }
        set
        {
            Initialize();
            _legacyContainerVulnerabilityAssessmentTaskCloudRoleArn.Assign(value);
        }
    }

    /// <summary> Gets or sets whether container vulnerability assessment is enabled. </summary>
    public BicepValue<bool> IsContainerVulnerabilityAssessmentEnabled
    {
        get
        {
            Initialize();
            return _legacyIsContainerVulnerabilityAssessmentEnabled;
        }
        set
        {
            Initialize();
            _legacyIsContainerVulnerabilityAssessmentEnabled.Assign(value);
        }
    }

    /// <summary> Gets or sets whether audit-log pipeline auto-provisioning is enabled. </summary>
    public BicepValue<bool> IsAutoProvisioningEnabled
    {
        get
        {
            Initialize();
            return _legacyIsAutoProvisioningEnabled;
        }
        set
        {
            Initialize();
            _legacyIsAutoProvisioningEnabled.Assign(value);
        }
    }

    /// <summary> Gets or sets the external identifier used by the data reader. </summary>
    public BicepValue<string> ScubaExternalId
    {
        get
        {
            Initialize();
            return _legacyScubaExternalId;
        }
        set
        {
            Initialize();
            _legacyScubaExternalId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyKubernetesScubaReaderCloudRoleArn = DefineProperty<string>(
            nameof(KubernetesScubaReaderCloudRoleArn),
            new string[] { "kubernetesScubaReader", "cloudRoleArn" });
        _legacyContainerVulnerabilityAssessmentCloudRoleArn = DefineProperty<string>(
            nameof(ContainerVulnerabilityAssessmentCloudRoleArn),
            new string[] { "containerVulnerabilityAssessment", "cloudRoleArn" });
        _legacyContainerVulnerabilityAssessmentTaskCloudRoleArn = DefineProperty<string>(
            nameof(ContainerVulnerabilityAssessmentTaskCloudRoleArn),
            new string[] { "containerVulnerabilityAssessmentTask", "cloudRoleArn" });
        _legacyIsContainerVulnerabilityAssessmentEnabled = DefineProperty<bool>(
            nameof(IsContainerVulnerabilityAssessmentEnabled),
            new string[] { "enableContainerVulnerabilityAssessment" });
        _legacyIsAutoProvisioningEnabled = DefineProperty<bool>(
            nameof(IsAutoProvisioningEnabled),
            new string[] { "autoProvisioning" });
        _legacyScubaExternalId = DefineProperty<string>(
            nameof(ScubaExternalId),
            new string[] { "scubaExternalId" });
    }
}

public partial class DefenderForContainersGcpOffering
{
    private BicepValue<bool> _legacyIsAuditLogsAutoProvisioningEnabled;
    private BicepValue<bool> _legacyIsDefenderAgentAutoProvisioningEnabled;
    private BicepValue<bool> _legacyIsPolicyAgentAutoProvisioningEnabled;

    /// <summary> Gets or sets whether audit-log auto-provisioning is enabled. </summary>
    public BicepValue<bool> IsAuditLogsAutoProvisioningEnabled
    {
        get
        {
            Initialize();
            return _legacyIsAuditLogsAutoProvisioningEnabled;
        }
        set
        {
            Initialize();
            _legacyIsAuditLogsAutoProvisioningEnabled.Assign(value);
        }
    }

    /// <summary> Gets or sets whether Defender agent auto-provisioning is enabled. </summary>
    public BicepValue<bool> IsDefenderAgentAutoProvisioningEnabled
    {
        get
        {
            Initialize();
            return _legacyIsDefenderAgentAutoProvisioningEnabled;
        }
        set
        {
            Initialize();
            _legacyIsDefenderAgentAutoProvisioningEnabled.Assign(value);
        }
    }

    /// <summary> Gets or sets whether policy agent auto-provisioning is enabled. </summary>
    public BicepValue<bool> IsPolicyAgentAutoProvisioningEnabled
    {
        get
        {
            Initialize();
            return _legacyIsPolicyAgentAutoProvisioningEnabled;
        }
        set
        {
            Initialize();
            _legacyIsPolicyAgentAutoProvisioningEnabled.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyIsAuditLogsAutoProvisioningEnabled = DefineProperty<bool>(
            nameof(IsAuditLogsAutoProvisioningEnabled),
            new string[] { "auditLogsAutoProvisioningFlag" });
        _legacyIsDefenderAgentAutoProvisioningEnabled = DefineProperty<bool>(
            nameof(IsDefenderAgentAutoProvisioningEnabled),
            new string[] { "defenderAgentAutoProvisioningFlag" });
        _legacyIsPolicyAgentAutoProvisioningEnabled = DefineProperty<bool>(
            nameof(IsPolicyAgentAutoProvisioningEnabled),
            new string[] { "policyAgentAutoProvisioningFlag" });
    }
}

public partial class DefenderCspmAwsOfferingCiem
{
    private BicepValue<string> _legacyCiemDiscoveryCloudRoleArn;

    /// <summary> Gets or sets the CIEM discovery cloud role ARN. </summary>
    public BicepValue<string> CiemDiscoveryCloudRoleArn
    {
        get
        {
            Initialize();
            return _legacyCiemDiscoveryCloudRoleArn;
        }
        set
        {
            Initialize();
            _legacyCiemDiscoveryCloudRoleArn.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyCiemDiscoveryCloudRoleArn = DefineProperty<string>(
            nameof(CiemDiscoveryCloudRoleArn),
            new string[] { "ciemDiscovery", "cloudRoleArn" });
    }
}

public partial class GovernanceEmailNotification
{
    /// <summary> Gets or sets whether manager email notifications are disabled. </summary>
    public BicepValue<bool> IsManagerEmailNotificationDisabled
    {
        get => DisableManagerEmailNotification;
        set => DisableManagerEmailNotification = value;
    }

    /// <summary> Gets or sets whether owner email notifications are disabled. </summary>
    public BicepValue<bool> IsOwnerEmailNotificationDisabled
    {
        get => DisableOwnerEmailNotification;
        set => DisableOwnerEmailNotification = value;
    }
}

public partial class GovernanceRuleEmailNotification
{
    /// <summary> Gets or sets whether manager email notifications are disabled. </summary>
    public BicepValue<bool> IsManagerEmailNotificationDisabled
    {
        get => DisableManagerEmailNotification;
        set => DisableManagerEmailNotification = value;
    }

    /// <summary> Gets or sets whether owner email notifications are disabled. </summary>
    public BicepValue<bool> IsOwnerEmailNotificationDisabled
    {
        get => DisableOwnerEmailNotification;
        set => DisableOwnerEmailNotification = value;
    }
}

public partial class DevOpsConfigurationProperties
{
    private BicepValue<DevOpsAutoDiscovery> _legacyAutoDiscovery;
    private BicepValue<DevOpsProvisioningState> _legacyProvisioningState;
    private BicepValue<DateTimeOffset> _legacyProvisioningStatusUpdateTimeUtc;

    /// <summary> Gets or sets the auto-discovery state. </summary>
    [CodeGenMember("AutoDiscovery")]
    public BicepValue<DevOpsAutoDiscovery> AutoDiscovery
    {
        get
        {
            Initialize();
            return _legacyAutoDiscovery;
        }
        set
        {
            Initialize();
            _legacyAutoDiscovery.Assign(value);
        }
    }

    /// <summary> Gets or sets the provisioning state. </summary>
    [CodeGenMember("ProvisioningState")]
    public BicepValue<DevOpsProvisioningState> ProvisioningState
    {
        get
        {
            Initialize();
            return _legacyProvisioningState;
        }
        set
        {
            Initialize();
            _legacyProvisioningState.Assign(value);
        }
    }

    /// <summary> Gets when the provisioning status was last updated. </summary>
    [CodeGenMember("ProvisioningStatusUpdatedOn")]
    public BicepValue<DateTimeOffset> ProvisioningStatusUpdateTimeUtc
    {
        get
        {
            Initialize();
            return _legacyProvisioningStatusUpdateTimeUtc;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyAutoDiscovery = DefineProperty<DevOpsAutoDiscovery>(
            nameof(AutoDiscovery),
            new string[] { "autoDiscovery" });
        _legacyProvisioningState = DefineProperty<DevOpsProvisioningState>(
            nameof(ProvisioningState),
            new string[] { "provisioningState" },
            isOutput: true);
        _legacyProvisioningStatusUpdateTimeUtc = DefineProperty<DateTimeOffset>(
            nameof(ProvisioningStatusUpdateTimeUtc),
            new string[] { "provisioningStatusUpdateTimeUtc" },
            isOutput: true,
            format: "O");
    }
}

public partial class DevOpsOrgProperties
{
    private BicepValue<ResourceOnboardingState> _legacyOnboardingState;
    private BicepValue<DevOpsProvisioningState> _legacyProvisioningState;

    /// <summary> Gets or sets the onboarding state. </summary>
    [CodeGenMember("OnboardingState")]
    public BicepValue<ResourceOnboardingState> OnboardingState
    {
        get
        {
            Initialize();
            return _legacyOnboardingState;
        }
        set
        {
            Initialize();
            _legacyOnboardingState.Assign(value);
        }
    }

    /// <summary> Gets or sets the provisioning state. </summary>
    [CodeGenMember("ProvisioningState")]
    public BicepValue<DevOpsProvisioningState> ProvisioningState
    {
        get
        {
            Initialize();
            return _legacyProvisioningState;
        }
        set
        {
            Initialize();
            _legacyProvisioningState.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyOnboardingState = DefineProperty<ResourceOnboardingState>(
            nameof(OnboardingState),
            new string[] { "onboardingState" });
        _legacyProvisioningState = DefineProperty<DevOpsProvisioningState>(
            nameof(ProvisioningState),
            new string[] { "provisioningState" },
            isOutput: true);
    }
}

public partial class DevOpsProjectProperties
{
    private BicepValue<ResourceOnboardingState> _legacyOnboardingState;
    private BicepValue<DevOpsProvisioningState> _legacyProvisioningState;

    /// <summary> Gets or sets the onboarding state. </summary>
    [CodeGenMember("OnboardingState")]
    public BicepValue<ResourceOnboardingState> OnboardingState
    {
        get
        {
            Initialize();
            return _legacyOnboardingState;
        }
        set
        {
            Initialize();
            _legacyOnboardingState.Assign(value);
        }
    }

    /// <summary> Gets or sets the provisioning state. </summary>
    [CodeGenMember("ProvisioningState")]
    public BicepValue<DevOpsProvisioningState> ProvisioningState
    {
        get
        {
            Initialize();
            return _legacyProvisioningState;
        }
        set
        {
            Initialize();
            _legacyProvisioningState.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyOnboardingState = DefineProperty<ResourceOnboardingState>(
            nameof(OnboardingState),
            new string[] { "onboardingState" });
        _legacyProvisioningState = DefineProperty<DevOpsProvisioningState>(
            nameof(ProvisioningState),
            new string[] { "provisioningState" },
            isOutput: true);
    }
}

public partial class DevOpsRepositoryProperties
{
    private BicepValue<ResourceOnboardingState> _legacyOnboardingState;
    private BicepValue<DevOpsProvisioningState> _legacyProvisioningState;
    private BicepValue<Uri> _legacyRepoUri;

    /// <summary> Gets or sets the onboarding state. </summary>
    [CodeGenMember("OnboardingState")]
    public BicepValue<ResourceOnboardingState> OnboardingState
    {
        get
        {
            Initialize();
            return _legacyOnboardingState;
        }
        set
        {
            Initialize();
            _legacyOnboardingState.Assign(value);
        }
    }

    /// <summary> Gets or sets the provisioning state. </summary>
    [CodeGenMember("ProvisioningState")]
    public BicepValue<DevOpsProvisioningState> ProvisioningState
    {
        get
        {
            Initialize();
            return _legacyProvisioningState;
        }
        set
        {
            Initialize();
            _legacyProvisioningState.Assign(value);
        }
    }

    /// <summary> Gets the repository URI. </summary>
    [CodeGenMember("RepoUri")]
    public BicepValue<Uri> RepoUri
    {
        get
        {
            Initialize();
            return _legacyRepoUri;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyOnboardingState = DefineProperty<ResourceOnboardingState>(
            nameof(OnboardingState),
            new string[] { "onboardingState" });
        _legacyProvisioningState = DefineProperty<DevOpsProvisioningState>(
            nameof(ProvisioningState),
            new string[] { "provisioningState" },
            isOutput: true);
        _legacyRepoUri = DefineProperty<Uri>(
            nameof(RepoUri),
            new string[] { "repoUri" },
            isOutput: true);
    }
}

public partial class SecurityCenterApiCollection
{
    private BicepValue<SecurityFamilyProvisioningState> _legacyProvisioningState;

    /// <summary> Gets the provisioning state. </summary>
    [CodeGenMember("ProvisioningState")]
    public BicepValue<SecurityFamilyProvisioningState> ProvisioningState
    {
        get
        {
            Initialize();
            return _legacyProvisioningState;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyProvisioningState = DefineProperty<SecurityFamilyProvisioningState>(
            nameof(ProvisioningState),
            new string[] { "properties", "provisioningState" },
            isOutput: true);
    }
}

public partial class SensitivitySetting
{
    private BicepList<Guid> _legacySensitiveInfoTypesIds;
    private BicepValue<Guid> _legacySensitivityThresholdLabelId;
    private BicepValue<float> _legacySensitivityThresholdLabelOrder;

    /// <summary> Gets or sets the selected sensitive information type identifiers. </summary>
    public BicepList<Guid> SensitiveInfoTypesIds
    {
        get
        {
            Initialize();
            return _legacySensitiveInfoTypesIds;
        }
        set
        {
            Initialize();
            _legacySensitiveInfoTypesIds.Assign(value);
        }
    }

    /// <summary> Gets or sets the sensitivity threshold label identifier. </summary>
    public BicepValue<Guid> SensitivityThresholdLabelId
    {
        get
        {
            Initialize();
            return _legacySensitivityThresholdLabelId;
        }
        set
        {
            Initialize();
            _legacySensitivityThresholdLabelId.Assign(value);
        }
    }

    /// <summary> Gets or sets the sensitivity threshold label order. </summary>
    public BicepValue<float> SensitivityThresholdLabelOrder
    {
        get
        {
            Initialize();
            return _legacySensitivityThresholdLabelOrder;
        }
        set
        {
            Initialize();
            _legacySensitivityThresholdLabelOrder.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacySensitiveInfoTypesIds = DefineListProperty<Guid>(
            nameof(SensitiveInfoTypesIds),
            new string[] { "sensitiveInfoTypesIds" },
            isRequired: true);
        _legacySensitivityThresholdLabelId = DefineProperty<Guid>(
            nameof(SensitivityThresholdLabelId),
            new string[] { "sensitivityThresholdLabelId" });
        _legacySensitivityThresholdLabelOrder = DefineProperty<float>(
            nameof(SensitivityThresholdLabelOrder),
            new string[] { "sensitivityThresholdLabelOrder" });
    }
}

public partial class MipSensitivityLabel
{
    private BicepValue<string> _legacyName;
    private BicepValue<Guid> _legacyId;
    private BicepValue<float> _legacyOrder;

    /// <summary> Gets the sensitivity label name. </summary>
    public BicepValue<string> Name
    {
        get
        {
            Initialize();
            return _legacyName;
        }
    }

    /// <summary> Gets the sensitivity label identifier. </summary>
    public BicepValue<Guid> Id
    {
        get
        {
            Initialize();
            return _legacyId;
        }
    }

    /// <summary> Gets the sensitivity label order. </summary>
    [CodeGenMember("Order")]
    public BicepValue<float> Order
    {
        get
        {
            Initialize();
            return _legacyOrder;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyName = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
        _legacyId = DefineProperty<Guid>(nameof(Id), new string[] { "id" }, isOutput: true);
        _legacyOrder = DefineProperty<float>(nameof(Order), new string[] { "order" }, isOutput: true);
    }
}

public partial class BuiltInInfoType
{
    private BicepValue<Guid> _legacyId;
    private BicepValue<string> _legacyBuiltInInfoTypeValue;

    /// <summary> Gets the information type identifier. </summary>
    [CodeGenMember("Id")]
    public BicepValue<Guid> Id
    {
        get
        {
            Initialize();
            return _legacyId;
        }
    }

    /// <summary> Gets the built-in information type category. </summary>
    public BicepValue<string> BuiltInInfoTypeValue
    {
        get
        {
            Initialize();
            return _legacyBuiltInInfoTypeValue;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyId = DefineProperty<Guid>(nameof(Id), new string[] { "id" }, isOutput: true);
        _legacyBuiltInInfoTypeValue = DefineProperty<string>(
            nameof(BuiltInInfoTypeValue),
            new string[] { "type" },
            isOutput: true);
    }
}

public partial class UserDefinedInformationType
{
    private BicepValue<string> _legacyName;
    private BicepValue<Guid> _legacyId;

    /// <summary> Gets the information type name. </summary>
    public BicepValue<string> Name
    {
        get
        {
            Initialize();
            return _legacyName;
        }
    }

    /// <summary> Gets the information type identifier. </summary>
    public BicepValue<Guid> Id
    {
        get
        {
            Initialize();
            return _legacyId;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyName = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
        _legacyId = DefineProperty<Guid>(nameof(Id), new string[] { "id" }, isOutput: true);
    }
}

public partial class SensitivitySettingsProperties
{
    private BicepValue<Guid> _legacySensitivityThresholdLabelId;

    /// <summary> Gets the sensitivity threshold label identifier. </summary>
    [CodeGenMember("SensitivityThresholdLabelId")]
    public BicepValue<Guid> SensitivityThresholdLabelId
    {
        get
        {
            Initialize();
            return _legacySensitivityThresholdLabelId;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacySensitivityThresholdLabelId = DefineProperty<Guid>(
            nameof(SensitivityThresholdLabelId),
            new string[] { "sensitivityThresholdLabelId" },
            isOutput: true);
    }
}

public partial class GetSensitivitySettingsResponsePropertiesMipInformation
{
    private BicepList<MipSensitivityLabel> _legacyLabels;
    private BicepList<UserDefinedInformationType> _legacyCustomInfoTypes;

    /// <summary> Gets the Microsoft information protection labels. </summary>
    [CodeGenMember("Labels")]
    public BicepList<MipSensitivityLabel> Labels
    {
        get
        {
            Initialize();
            return _legacyLabels;
        }
    }

    /// <summary> Gets the custom information types. </summary>
    [CodeGenMember("CustomInfoTypes")]
    public BicepList<UserDefinedInformationType> CustomInfoTypes
    {
        get
        {
            Initialize();
            return _legacyCustomInfoTypes;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyLabels = DefineListProperty<MipSensitivityLabel>(
            nameof(Labels),
            new string[] { "labels" },
            isOutput: true);
        _legacyCustomInfoTypes = DefineListProperty<UserDefinedInformationType>(
            nameof(CustomInfoTypes),
            new string[] { "customInfoTypes" },
            isOutput: true);
    }
}

public partial class JitNetworkAccessPolicyVirtualMachine
{
    private BicepValue<Azure.Core.ResourceIdentifier> _legacyId;

    /// <summary> Gets or sets the virtual machine resource identifier. </summary>
    [CodeGenMember("Id")]
    public BicepValue<Azure.Core.ResourceIdentifier> Id
    {
        get
        {
            Initialize();
            return _legacyId;
        }
        set
        {
            Initialize();
            _legacyId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyId = DefineProperty<Azure.Core.ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }
}

public partial class JitNetworkAccessRequestVirtualMachine
{
    private BicepValue<Azure.Core.ResourceIdentifier> _legacyId;

    /// <summary> Gets or sets the virtual machine resource identifier. </summary>
    [CodeGenMember("Id")]
    public BicepValue<Azure.Core.ResourceIdentifier> Id
    {
        get
        {
            Initialize();
            return _legacyId;
        }
        set
        {
            Initialize();
            _legacyId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyId = DefineProperty<Azure.Core.ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }
}

public partial class OnPremiseResourceDetails
{
    private BicepValue<Azure.Core.ResourceIdentifier> _legacyWorkspaceId;

    /// <summary> Gets or sets the workspace resource identifier. </summary>
    [CodeGenMember("WorkspaceId")]
    public BicepValue<Azure.Core.ResourceIdentifier> WorkspaceId
    {
        get
        {
            Initialize();
            return _legacyWorkspaceId;
        }
        set
        {
            Initialize();
            _legacyWorkspaceId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyWorkspaceId = DefineProperty<Azure.Core.ResourceIdentifier>(
            nameof(WorkspaceId),
            new string[] { "workspaceId" });
    }
}

public partial class SecurityAssessmentMetadataProperties
{
    private BicepValue<Azure.Core.ResourceIdentifier> _legacyPolicyDefinitionId;

    /// <summary> Gets or sets the policy definition resource identifier. </summary>
    [CodeGenMember("PolicyDefinitionId")]
    public BicepValue<Azure.Core.ResourceIdentifier> PolicyDefinitionId
    {
        get
        {
            Initialize();
            return _legacyPolicyDefinitionId;
        }
        set
        {
            Initialize();
            _legacyPolicyDefinitionId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyPolicyDefinitionId = DefineProperty<Azure.Core.ResourceIdentifier>(
            nameof(PolicyDefinitionId),
            new string[] { "policyDefinitionId" });
    }
}

public partial class SecurityAutomationActionEventHub
{
    private BicepValue<Azure.Core.ResourceIdentifier> _legacyEventHubResourceId;

    /// <summary> Gets or sets the Event Hub resource identifier. </summary>
    [CodeGenMember("EventHubResourceId")]
    public BicepValue<Azure.Core.ResourceIdentifier> EventHubResourceId
    {
        get
        {
            Initialize();
            return _legacyEventHubResourceId;
        }
        set
        {
            Initialize();
            _legacyEventHubResourceId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyEventHubResourceId = DefineProperty<Azure.Core.ResourceIdentifier>(
            nameof(EventHubResourceId),
            new string[] { "eventHubResourceId" });
    }
}

public partial class SecurityAutomationActionLogicApp
{
    private BicepValue<Azure.Core.ResourceIdentifier> _legacyLogicAppResourceId;

    /// <summary> Gets or sets the Logic App resource identifier. </summary>
    [CodeGenMember("LogicAppResourceId")]
    public BicepValue<Azure.Core.ResourceIdentifier> LogicAppResourceId
    {
        get
        {
            Initialize();
            return _legacyLogicAppResourceId;
        }
        set
        {
            Initialize();
            _legacyLogicAppResourceId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyLogicAppResourceId = DefineProperty<Azure.Core.ResourceIdentifier>(
            nameof(LogicAppResourceId),
            new string[] { "logicAppResourceId" });
    }
}

public partial class SecurityAutomationActionWorkspace
{
    private BicepValue<Azure.Core.ResourceIdentifier> _legacyWorkspaceResourceId;

    /// <summary> Gets or sets the workspace resource identifier. </summary>
    [CodeGenMember("WorkspaceResourceId")]
    public BicepValue<Azure.Core.ResourceIdentifier> WorkspaceResourceId
    {
        get
        {
            Initialize();
            return _legacyWorkspaceResourceId;
        }
        set
        {
            Initialize();
            _legacyWorkspaceResourceId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyWorkspaceResourceId = DefineProperty<Azure.Core.ResourceIdentifier>(
            nameof(WorkspaceResourceId),
            new string[] { "workspaceResourceId" });
    }
}

public partial class SqlVulnerabilityAssessmentBaselineRule
{
    private BicepValue<bool> _legacyLatestScan;
    private BicepList<BicepList<string>> _legacyResults;
    private BicepList<BicepList<string>> _legacyRuleResults;

    /// <summary> Gets or sets whether results should be taken from the latest scan. </summary>
    public BicepValue<bool> LatestScan
    {
        get
        {
            Initialize();
            return _legacyLatestScan;
        }
        set
        {
            Initialize();
            _legacyLatestScan.Assign(value);
        }
    }

    /// <summary> Gets or sets the expected results to insert into the baseline. </summary>
    public BicepList<BicepList<string>> Results
    {
        get
        {
            Initialize();
            return _legacyResults;
        }
        set
        {
            Initialize();
            _legacyResults.Assign(value);
        }
    }

    /// <summary> Gets the expected results in the baseline. </summary>
    public BicepList<BicepList<string>> RuleResults
    {
        get
        {
            Initialize();
            return _legacyRuleResults;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyLatestScan = DefineProperty<bool>(
            nameof(LatestScan),
            new string[] { "latestScan" });
        _legacyResults = DefineListProperty<BicepList<string>>(
            nameof(Results),
            new string[] { "results" });
        _legacyRuleResults = DefineListProperty<BicepList<string>>(
            nameof(RuleResults),
            new string[] { "properties", "results" },
            isOutput: true);
    }
}

public partial class SuppressionAlertsScopeElement
{
    private BicepDictionary<BinaryData> _legacyAdditionalProperties;

    /// <summary> Gets or sets additional suppression-scope properties. </summary>
    public BicepDictionary<BinaryData> AdditionalProperties
    {
        get
        {
            Initialize();
            return _legacyAdditionalProperties;
        }
        set
        {
            Initialize();
            _legacyAdditionalProperties.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyAdditionalProperties = DefineDictionaryProperty<BinaryData>(
            nameof(AdditionalProperties),
            new string[] { "AdditionalProperties" });
    }
}

public partial class DefenderForStorageSetting
{
    /// <summary> Gets or sets whether Defender for Storage is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get => Properties is null ? default : Properties.IsEnabled;
        set
        {
            Properties ??= new DefenderForStorageSettingProperties();
            Properties.IsEnabled = value;
        }
    }

    /// <summary> Gets or sets whether malware scanning on upload is enabled. </summary>
    public BicepValue<bool> IsMalwareScanningOnUploadEnabled
    {
        get => Properties?.MalwareScanning?.OnUpload is null ? default : Properties.MalwareScanning.OnUpload.IsEnabled;
        set
        {
            Properties ??= new DefenderForStorageSettingProperties();
            Properties.MalwareScanning ??= new MalwareScanningProperties();
            Properties.MalwareScanning.OnUpload ??= new OnUploadProperties();
            Properties.MalwareScanning.OnUpload.IsEnabled = value;
        }
    }

    /// <summary> Gets or sets the monthly malware scanning data cap in gigabytes. </summary>
    public BicepValue<int> CapGBPerMonth
    {
        get => Properties?.MalwareScanning?.OnUpload is null ? default : Properties.MalwareScanning.OnUpload.CapGBPerMonth;
        set
        {
            Properties ??= new DefenderForStorageSettingProperties();
            Properties.MalwareScanning ??= new MalwareScanningProperties();
            Properties.MalwareScanning.OnUpload ??= new OnUploadProperties();
            Properties.MalwareScanning.OnUpload.CapGBPerMonth = value;
        }
    }

    /// <summary> Gets or sets the Event Grid topic resource identifier for scan results. </summary>
    public BicepValue<Azure.Core.ResourceIdentifier> ScanResultsEventGridTopicResourceId
    {
        get => Properties?.MalwareScanning is null ? default : Properties.MalwareScanning.ScanResultsEventGridTopicResourceId;
        set
        {
            Properties ??= new DefenderForStorageSettingProperties();
            Properties.MalwareScanning ??= new MalwareScanningProperties();
            Properties.MalwareScanning.ScanResultsEventGridTopicResourceId = value;
        }
    }

    /// <summary> Gets the malware scanning operation status. </summary>
    public ExtensionOperationStatus MalwareScanningOperationStatus
    {
        get
        {
            Properties ??= new DefenderForStorageSettingProperties();
            Properties.MalwareScanning ??= new MalwareScanningProperties();
            return Properties.MalwareScanning.OperationStatus;
        }
    }

    /// <summary> Gets or sets whether sensitive data discovery is enabled. </summary>
    public BicepValue<bool> IsSensitiveDataDiscoveryEnabled
    {
        get => Properties?.SensitiveDataDiscovery is null ? default : Properties.SensitiveDataDiscovery.IsEnabled;
        set
        {
            Properties ??= new DefenderForStorageSettingProperties();
            Properties.SensitiveDataDiscovery ??= new SensitiveDataDiscoveryProperties();
            Properties.SensitiveDataDiscovery.IsEnabled = value;
        }
    }

    /// <summary> Gets the sensitive data discovery operation status. </summary>
    public ExtensionOperationStatus SensitiveDataDiscoveryOperationStatus
    {
        get
        {
            Properties ??= new DefenderForStorageSettingProperties();
            Properties.SensitiveDataDiscovery ??= new SensitiveDataDiscoveryProperties();
            return Properties.SensitiveDataDiscovery.OperationStatus;
        }
    }

    /// <summary> Gets or sets whether subscription-level settings are overridden. </summary>
    public BicepValue<bool> IsOverrideSubscriptionLevelSettingsEnabled
    {
        get => Properties is null ? default : Properties.IsOverrideSubscriptionLevelSettings;
        set
        {
            Properties ??= new DefenderForStorageSettingProperties();
            Properties.IsOverrideSubscriptionLevelSettings = value;
        }
    }
}

public partial class GovernanceRule
{
    private BicepValue<Guid> _legacyTenantId;

    /// <summary> Gets or sets whether the rule applies to member scopes. </summary>
    public BicepValue<bool> IncludeMemberScopes
    {
        get => IsIncludeMemberScopes;
        set => IsIncludeMemberScopes = value;
    }

    /// <summary> Gets the tenant identifier. </summary>
    [CodeGenMember("TenantId")]
    public BicepValue<Guid> TenantId
    {
        get
        {
            Initialize();
            return _legacyTenantId;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyTenantId = DefineProperty<Guid>(
            nameof(TenantId),
            new string[] { "properties", "tenantId" },
            isOutput: true);
    }
}

public partial class SecurityAlertsSuppressionRule
{
    /// <summary> Gets or sets when the suppression rule expires. </summary>
    public BicepValue<DateTimeOffset> ExpireOn
    {
        get => ExpiresOn;
        set => ExpiresOn = value;
    }
}

public partial class SecurityContact
{
    private SecurityContactPropertiesAlertNotifications _legacyAlertNotifications;

    /// <summary> Gets or sets the alert notification settings. </summary>
    public SecurityContactPropertiesAlertNotifications AlertNotifications
    {
        get
        {
            Initialize();
            return _legacyAlertNotifications;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _legacyAlertNotifications, value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyAlertNotifications = DefineModelProperty<SecurityContactPropertiesAlertNotifications>(
            nameof(AlertNotifications),
            new string[] { "properties", "alertNotifications" });
    }
}

public partial class GovernanceAssignment
{
    private ResourceReference<SecurityAssessment> _legacyParent;

    /// <summary> Gets or sets the parent security assessment. </summary>
    public SecurityAssessment Parent
    {
        get
        {
            Initialize();
            return _legacyParent.Value;
        }
        set
        {
            Initialize();
            _legacyParent.Value = value;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyParent = DefineResource<SecurityAssessment>(
            nameof(Parent),
            new string[] { "parent" },
            isRequired: true);
    }
}

public partial class SecurityCenterPricing
{
    /// <summary> Gets when the pricing tier was enabled. </summary>
    public BicepValue<DateTimeOffset> EnabledOn => EnablementOn;
}

public partial class SecurityConnector
{
    /// <summary> Gets when the hierarchy identifier trial ends. </summary>
    public BicepValue<DateTimeOffset> HierarchyIdentifierTrialEndOn => HierarchyIdentifierTrialEndsOn;
}

public partial class SecurityOperator
{
    private ManagedServiceIdentity _legacyIdentity;
    private ResourceReference<SecurityCenterPricing> _legacyParent;

    /// <summary> Gets the managed service identity. </summary>
    [CodeGenMember("Identity")]
    public ManagedServiceIdentity Identity
    {
        get
        {
            Initialize();
            return _legacyIdentity;
        }
    }

    /// <summary> Gets or sets the parent pricing resource. </summary>
    public SecurityCenterPricing Parent
    {
        get
        {
            Initialize();
            return _legacyParent.Value;
        }
        set
        {
            Initialize();
            _legacyParent.Value = value;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyIdentity = DefineModelProperty<ManagedServiceIdentity>(
            nameof(Identity),
            new string[] { "identity" },
            isOutput: true);
        _legacyParent = DefineResource<SecurityCenterPricing>(
            nameof(Parent),
            new string[] { "parent" },
            isRequired: true);
    }
}

public partial class PlanExtension
{
    private OperationStatusAutoGenerated _legacyOperationStatus;

    /// <summary> Gets the status of the extension operation. </summary>
    [CodeGenMember("OperationStatus")]
    public OperationStatusAutoGenerated OperationStatus
    {
        get
        {
            Initialize();
            return _legacyOperationStatus;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyOperationStatus = DefineModelProperty<OperationStatusAutoGenerated>(
            nameof(OperationStatus),
            new string[] { "operationStatus" },
            isOutput: true);
    }
}

/// <summary> A status describing the success or failure of an extension operation. </summary>
public partial class OperationStatusAutoGenerated : ProvisionableConstruct
{
    private BicepValue<ExtensionOperationStatusCode> _code;
    private BicepValue<string> _message;

    /// <summary> Creates a new operation status. </summary>
    public OperationStatusAutoGenerated()
    {
    }

    /// <summary> Gets the operation status code. </summary>
    public BicepValue<ExtensionOperationStatusCode> Code
    {
        get
        {
            Initialize();
            return _code;
        }
    }

    /// <summary> Gets the operation status message. </summary>
    public BicepValue<string> Message
    {
        get
        {
            Initialize();
            return _message;
        }
    }

    /// <summary> Defines the provisionable operation status properties. </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _code = DefineProperty<ExtensionOperationStatusCode>(nameof(Code), new string[] { "code" });
        _message = DefineProperty<string>(nameof(Message), new string[] { "message" });
    }
}

public partial class SecurityAssessment
{
    private BicepValue<Uri> _legacyLinksAzurePortalUri;
    private SecurityAssessmentStatus _legacyStatus;

    /// <summary> Gets the Azure portal link for the assessment. </summary>
    [CodeGenMember("LinksAzurePortalUri")]
    public BicepValue<Uri> LinksAzurePortalUri
    {
        get
        {
            Initialize();
            return _legacyLinksAzurePortalUri;
        }
    }

    /// <summary> Gets the assessment status. </summary>
    [CodeGenMember("Status")]
    public SecurityAssessmentStatus Status
    {
        get
        {
            Initialize();
            return _legacyStatus;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _legacyStatus, value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyLinksAzurePortalUri = DefineProperty<Uri>(
            nameof(LinksAzurePortalUri),
            new string[] { "properties", "links", "azurePortal" },
            isOutput: true);
        _legacyStatus = DefineModelProperty<SecurityAssessmentStatus>(
            nameof(Status),
            new string[] { "properties", "status" });
    }

    /// <summary> Supported API versions. </summary>
    public static partial class ResourceVersions
    {
        /// <summary> API version "2021-06-01". </summary>
        public static readonly string V2021_06_01 = "2021-06-01";
    }
}

public partial class SecurityCenterPricing
{
    /// <summary> Supported API versions. </summary>
    public static partial class ResourceVersions
    {
        /// <summary> API version "2023-01-01". </summary>
        public static readonly string V2023_01_01 = "2023-01-01";
    }
}

/// <summary> Alert notification settings for a security contact. </summary>
public partial class SecurityContactPropertiesAlertNotifications : ProvisionableConstruct
{
    private BicepValue<SecurityAlertMinimalSeverity> _minimalSeverity;
    private BicepValue<SecurityAlertNotificationState> _state;

    /// <summary> Creates new alert notification settings. </summary>
    public SecurityContactPropertiesAlertNotifications()
    {
    }

    /// <summary> Gets or sets the minimal alert severity. </summary>
    public BicepValue<SecurityAlertMinimalSeverity> MinimalSeverity
    {
        get
        {
            Initialize();
            return _minimalSeverity;
        }
        set
        {
            Initialize();
            _minimalSeverity.Assign(value);
        }
    }

    /// <summary> Gets or sets the notification state. </summary>
    public BicepValue<SecurityAlertNotificationState> State
    {
        get
        {
            Initialize();
            return _state;
        }
        set
        {
            Initialize();
            _state.Assign(value);
        }
    }

    /// <summary> Defines the provisionable alert notification properties. </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _minimalSeverity = DefineProperty<SecurityAlertMinimalSeverity>(
            nameof(MinimalSeverity),
            new string[] { "minimalSeverity" });
        _state = DefineProperty<SecurityAlertNotificationState>(
            nameof(State),
            new string[] { "state" });
    }
}

/// <summary> Configuration for AWS CSPM VM scanning. </summary>
public partial class DefenderCspmAwsOfferingVmScannersConfiguration : VmScannersBaseConfiguration
{
    private BicepValue<string> _cloudRoleArn;

    /// <summary> Gets or sets the cloud role ARN. </summary>
    public BicepValue<string> CloudRoleArn
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

    /// <inheritdoc />
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _cloudRoleArn = DefineProperty<string>(nameof(CloudRoleArn), new string[] { "cloudRoleArn" });
    }
}

/// <summary> Configuration for GCP CSPM VM scanning. </summary>
public partial class DefenderCspmGcpOfferingVmScannersConfiguration : VmScannersBaseConfiguration
{
}

/// <summary> Configuration for GCP database Arc auto-provisioning. </summary>
public partial class DefenderForDatabasesGcpOfferingArcAutoProvisioningConfiguration : DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration
{
}

/// <summary> Configuration for AWS server Arc auto-provisioning. </summary>
public partial class DefenderForServersAwsOfferingArcAutoProvisioningConfiguration : DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration
{
}

/// <summary> Configuration for AWS server VM scanning. </summary>
public partial class DefenderForServersAwsOfferingVmScannersConfiguration : VmScannersBaseConfiguration
{
    private BicepValue<string> _cloudRoleArn;

    /// <summary> Gets or sets the cloud role ARN. </summary>
    public BicepValue<string> CloudRoleArn
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

    /// <inheritdoc />
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _cloudRoleArn = DefineProperty<string>(nameof(CloudRoleArn), new string[] { "cloudRoleArn" });
    }
}

/// <summary> Configuration for GCP server Arc auto-provisioning. </summary>
public partial class DefenderForServersGcpOfferingArcAutoProvisioningConfiguration : DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration
{
}

/// <summary> Configuration for GCP server VM scanning. </summary>
public partial class DefenderForServersGcpOfferingVmScannersConfiguration : VmScannersBaseConfiguration
{
}

/// <summary> Vulnerability assessment auto-provisioning for GCP servers. </summary>
public partial class DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning : ProvisionableConstruct
{
    private BicepValue<bool> _isEnabled;
    private BicepValue<VulnerabilityAssessmentAutoProvisioningType> _type;

    /// <summary> Gets or sets whether vulnerability assessment auto-provisioning is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get
        {
            Initialize();
            return _isEnabled;
        }
        set
        {
            Initialize();
            _isEnabled.Assign(value);
        }
    }

    /// <summary> Gets or sets the vulnerability assessment auto-provisioning type. </summary>
    public BicepValue<VulnerabilityAssessmentAutoProvisioningType> VulnerabilityAssessmentAutoProvisioningType
    {
        get
        {
            Initialize();
            return _type;
        }
        set
        {
            Initialize();
            _type.Assign(value);
        }
    }

    /// <inheritdoc />
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _isEnabled = DefineProperty<bool>(nameof(IsEnabled), new string[] { "enabled" });
        _type = DefineProperty<VulnerabilityAssessmentAutoProvisioningType>(
            nameof(VulnerabilityAssessmentAutoProvisioningType),
            new string[] { "configuration", "type" });
    }
}

public partial class SubscriptionAssessmentMetadata
{
    private BicepValue<Azure.Core.ResourceIdentifier> _legacyPolicyDefinitionId;

    /// <summary> Gets the policy definition resource identifier. </summary>
    [CodeGenMember("PolicyDefinitionId")]
    public BicepValue<Azure.Core.ResourceIdentifier> PolicyDefinitionId
    {
        get
        {
            Initialize();
            return _legacyPolicyDefinitionId;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _legacyPolicyDefinitionId = DefineProperty<Azure.Core.ResourceIdentifier>(
            nameof(PolicyDefinitionId),
            new string[] { "properties", "policyDefinitionId" },
            isOutput: true);
    }

    /// <summary> Supported API versions. </summary>
    public static partial class ResourceVersions
    {
        /// <summary> API version "2021-06-01". </summary>
        public static readonly string V2021_06_01 = "2021-06-01";
    }
}
