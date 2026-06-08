// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat base model constructors are grouped to keep related shims together.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Backward-compat constructors for legacy extensible base models.
    public abstract partial class AutoMLVertical
    {
        /// <summary> Initializes a new instance of <see cref="AutoMLVertical"/>. </summary>
        protected AutoMLVertical(MachineLearningTableJobInput trainingData)
        {
            TrainingData = trainingData;
        }
    }

    [CodeGenSuppress("BatchDeploymentConfiguration")]
    public abstract partial class BatchDeploymentConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="BatchDeploymentConfiguration"/>. </summary>
        protected BatchDeploymentConfiguration()
        {
        }
    }

    [CodeGenSuppress("DataDriftMetricThresholdBase")]
    public abstract partial class DataDriftMetricThresholdBase
    {
        /// <summary> Initializes a new instance of <see cref="DataDriftMetricThresholdBase"/>. </summary>
        protected DataDriftMetricThresholdBase()
        {
        }
    }

    [CodeGenSuppress("DataQualityMetricThresholdBase")]
    public abstract partial class DataQualityMetricThresholdBase
    {
        /// <summary> Initializes a new instance of <see cref="DataQualityMetricThresholdBase"/>. </summary>
        protected DataQualityMetricThresholdBase()
        {
        }
    }

    [CodeGenSuppress("DataReferenceCredential")]
    public abstract partial class DataReferenceCredential
    {
        /// <summary> Initializes a new instance of <see cref="DataReferenceCredential"/>. </summary>
        protected DataReferenceCredential()
        {
        }
    }

    [CodeGenSuppress("ForecastHorizon")]
    public abstract partial class ForecastHorizon
    {
        /// <summary> Initializes a new instance of <see cref="ForecastHorizon"/>. </summary>
        protected ForecastHorizon()
        {
        }
    }

    [CodeGenSuppress("ForecastingSeasonality")]
    public abstract partial class ForecastingSeasonality
    {
        /// <summary> Initializes a new instance of <see cref="ForecastingSeasonality"/>. </summary>
        protected ForecastingSeasonality()
        {
        }
    }

    [CodeGenSuppress("JobNodes")]
    public abstract partial class JobNodes
    {
        /// <summary> Initializes a new instance of <see cref="JobNodes"/>. </summary>
        protected JobNodes()
        {
        }
    }

    [CodeGenSuppress("MachineLearningAssetReferenceBase")]
    public abstract partial class MachineLearningAssetReferenceBase
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningAssetReferenceBase"/>. </summary>
        protected MachineLearningAssetReferenceBase()
        {
        }
    }

    [CodeGenSuppress("MachineLearningComputeProperties")]
    public abstract partial class MachineLearningComputeProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningComputeProperties"/>. </summary>
        protected MachineLearningComputeProperties()
        {
        }
    }

    [CodeGenSuppress("MachineLearningComputeSecrets")]
    public abstract partial class MachineLearningComputeSecrets
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningComputeSecrets"/>. </summary>
        protected MachineLearningComputeSecrets()
        {
        }
    }

    [CodeGenSuppress("MachineLearningDatastoreCredentials")]
    public abstract partial class MachineLearningDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningDatastoreCredentials"/>. </summary>
        protected MachineLearningDatastoreCredentials()
        {
        }
    }

    [CodeGenSuppress("MachineLearningDatastoreSecrets")]
    public abstract partial class MachineLearningDatastoreSecrets
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningDatastoreSecrets"/>. </summary>
        protected MachineLearningDatastoreSecrets()
        {
        }
    }

    [CodeGenSuppress("MachineLearningDistributionConfiguration")]
    public abstract partial class MachineLearningDistributionConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningDistributionConfiguration"/>. </summary>
        protected MachineLearningDistributionConfiguration()
        {
        }
    }

    [CodeGenSuppress("MachineLearningEarlyTerminationPolicy")]
    public abstract partial class MachineLearningEarlyTerminationPolicy
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningEarlyTerminationPolicy"/>. </summary>
        protected MachineLearningEarlyTerminationPolicy()
        {
        }
    }

    [CodeGenSuppress("MachineLearningIdentityConfiguration")]
    public abstract partial class MachineLearningIdentityConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningIdentityConfiguration"/>. </summary>
        protected MachineLearningIdentityConfiguration()
        {
        }
    }

    [CodeGenSuppress("MachineLearningJobInput")]
    public abstract partial class MachineLearningJobInput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningJobInput"/>. </summary>
        protected MachineLearningJobInput()
        {
        }
    }

    [CodeGenSuppress("MachineLearningJobLimits")]
    public abstract partial class MachineLearningJobLimits
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningJobLimits"/>. </summary>
        protected MachineLearningJobLimits()
        {
        }
    }

    [CodeGenSuppress("MachineLearningJobOutput")]
    public abstract partial class MachineLearningJobOutput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningJobOutput"/>. </summary>
        protected MachineLearningJobOutput()
        {
        }
    }

    [CodeGenSuppress("MachineLearningOnlineScaleSettings")]
    public abstract partial class MachineLearningOnlineScaleSettings
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningOnlineScaleSettings"/>. </summary>
        protected MachineLearningOnlineScaleSettings()
        {
        }
    }

    [CodeGenSuppress("MachineLearningOutboundRule")]
    public abstract partial class MachineLearningOutboundRule
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningOutboundRule"/>. </summary>
        protected MachineLearningOutboundRule()
        {
        }
    }

    [CodeGenSuppress("MachineLearningScheduleAction")]
    public abstract partial class MachineLearningScheduleAction
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningScheduleAction"/>. </summary>
        protected MachineLearningScheduleAction()
        {
        }
    }

    [CodeGenSuppress("MachineLearningTriggerBase")]
    public abstract partial class MachineLearningTriggerBase
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningTriggerBase"/>. </summary>
        protected MachineLearningTriggerBase()
        {
        }
    }

    [CodeGenSuppress("MachineLearningWebhook")]
    public abstract partial class MachineLearningWebhook
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningWebhook"/>. </summary>
        protected MachineLearningWebhook()
        {
        }
    }

    [CodeGenSuppress("MachineLearningWorkspaceConnectionProperties")]
    public abstract partial class MachineLearningWorkspaceConnectionProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningWorkspaceConnectionProperties"/>. </summary>
        protected MachineLearningWorkspaceConnectionProperties()
        {
        }
    }

    [CodeGenSuppress("MonitorComputeConfigurationBase")]
    public abstract partial class MonitorComputeConfigurationBase
    {
        /// <summary> Initializes a new instance of <see cref="MonitorComputeConfigurationBase"/>. </summary>
        protected MonitorComputeConfigurationBase()
        {
        }
    }

    [CodeGenSuppress("MonitorComputeIdentityBase")]
    public abstract partial class MonitorComputeIdentityBase
    {
        /// <summary> Initializes a new instance of <see cref="MonitorComputeIdentityBase"/>. </summary>
        protected MonitorComputeIdentityBase()
        {
        }
    }

    [CodeGenSuppress("MonitoringFeatureFilterBase")]
    public abstract partial class MonitoringFeatureFilterBase
    {
        /// <summary> Initializes a new instance of <see cref="MonitoringFeatureFilterBase"/>. </summary>
        protected MonitoringFeatureFilterBase()
        {
        }
    }

    public abstract partial class MonitoringInputDataBase
    {
        /// <summary> Initializes a new instance of <see cref="MonitoringInputDataBase"/>. </summary>
        protected MonitoringInputDataBase(JobInputType jobInputType, System.Uri uri)
        {
            Columns = new ChangeTrackingDictionary<string, string>();
            JobInputType = jobInputType;
            Uri = uri;
        }
    }

    [CodeGenSuppress("MonitoringSignalBase")]
    public abstract partial class MonitoringSignalBase
    {
        /// <summary> Initializes a new instance of <see cref="MonitoringSignalBase"/>. </summary>
        protected MonitoringSignalBase()
        {
        }
    }

    [CodeGenSuppress("NCrossValidations")]
    public abstract partial class NCrossValidations
    {
        /// <summary> Initializes a new instance of <see cref="NCrossValidations"/>. </summary>
        protected NCrossValidations()
        {
        }
    }

    public abstract partial class OneLakeArtifact
    {
        /// <summary> Initializes a new instance of <see cref="OneLakeArtifact"/>. </summary>
        protected OneLakeArtifact(string artifactName)
        {
            ArtifactName = artifactName;
        }
    }

    [CodeGenSuppress("PendingUploadCredentialDto")]
    public abstract partial class PendingUploadCredentialDto
    {
        /// <summary> Initializes a new instance of <see cref="PendingUploadCredentialDto"/>. </summary>
        protected PendingUploadCredentialDto()
        {
        }
    }

    [CodeGenSuppress("PredictionDriftMetricThresholdBase")]
    public abstract partial class PredictionDriftMetricThresholdBase
    {
        /// <summary> Initializes a new instance of <see cref="PredictionDriftMetricThresholdBase"/>. </summary>
        protected PredictionDriftMetricThresholdBase()
        {
        }
    }

    [CodeGenSuppress("SamplingAlgorithm")]
    public abstract partial class SamplingAlgorithm
    {
        /// <summary> Initializes a new instance of <see cref="SamplingAlgorithm"/>. </summary>
        protected SamplingAlgorithm()
        {
        }
    }

    [CodeGenSuppress("SparkJobEntry")]
    public abstract partial class SparkJobEntry
    {
        /// <summary> Initializes a new instance of <see cref="SparkJobEntry"/>. </summary>
        protected SparkJobEntry()
        {
        }
    }

    [CodeGenSuppress("TargetLags")]
    public abstract partial class TargetLags
    {
        /// <summary> Initializes a new instance of <see cref="TargetLags"/>. </summary>
        protected TargetLags()
        {
        }
    }

    [CodeGenSuppress("TargetRollingWindowSize")]
    public abstract partial class TargetRollingWindowSize
    {
        /// <summary> Initializes a new instance of <see cref="TargetRollingWindowSize"/>. </summary>
        protected TargetRollingWindowSize()
        {
        }
    }
}

#pragma warning restore SA1402
