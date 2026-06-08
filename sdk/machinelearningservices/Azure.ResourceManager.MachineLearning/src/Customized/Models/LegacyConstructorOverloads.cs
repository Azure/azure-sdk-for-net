// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat constructor overloads are grouped to keep related shims together.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Backward-compat overloads for constructor parameter ordering and formerly public simple constructors.
    public partial class EncryptionUpdateProperties
    {
        /// <summary> Initializes a new instance of <see cref="EncryptionUpdateProperties"/>. </summary>
        public EncryptionUpdateProperties(EncryptionKeyVaultUpdateProperties keyVaultProperties) : this(keyVaultProperties, null)
        {
        }
    }

    public partial class FeatureAttributionDriftMonitoringSignal
    {
        /// <summary> Initializes a new instance of <see cref="FeatureAttributionDriftMonitoringSignal"/>. </summary>
        public FeatureAttributionDriftMonitoringSignal(FeatureAttributionMetricThreshold metricThreshold, FeatureImportanceSettings featureImportanceSettings, IEnumerable<MonitoringInputDataBase> productionData, MonitoringInputDataBase referenceData)
            : this(featureImportanceSettings, metricThreshold, productionData, referenceData)
        {
        }
    }

    public partial class MonitorDefinition
    {
        /// <summary> Initializes a new instance of <see cref="MonitorDefinition"/>. </summary>
        public MonitorDefinition(IDictionary<string, MonitoringSignalBase> signals, MonitorComputeConfigurationBase computeConfiguration)
            : this(computeConfiguration, signals)
        {
        }
    }

    public partial class MachineLearningEncryptionKeyVaultProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningEncryptionKeyVaultProperties"/>. </summary>
        public MachineLearningEncryptionKeyVaultProperties(Azure.Core.ResourceIdentifier keyVaultArmId, string keyIdentifier)
            : this(keyIdentifier, keyVaultArmId)
        {
        }
    }

    public partial class MachineLearningDatastoreProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningDatastoreProperties"/>. </summary>
        public MachineLearningDatastoreProperties(MachineLearningDatastoreCredentials credentials)
            : this(credentials, default)
        {
        }
    }

    [CodeGenSuppress("MachineLearningJobProperties")]
    public partial class MachineLearningJobProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningJobProperties"/>. </summary>
        public MachineLearningJobProperties()
            : this(default)
        {
        }
    }

    [CodeGenSuppress("MachineLearningOnlineDeploymentProperties")]
    public partial class MachineLearningOnlineDeploymentProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningOnlineDeploymentProperties"/>. </summary>
        public MachineLearningOnlineDeploymentProperties()
            : this(default)
        {
        }
    }
}

#pragma warning restore SA1402
