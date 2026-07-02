// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore protected constructors for legacy extensible base models that customers may subclass; TypeSpec generation does not emit these non-wire constructors.
    public abstract partial class PredictionDriftMetricThresholdBase
    {
        /// <summary> Initializes a new instance of <see cref="PredictionDriftMetricThresholdBase"/>. </summary>
        protected PredictionDriftMetricThresholdBase()
        {
        }
    }
}
