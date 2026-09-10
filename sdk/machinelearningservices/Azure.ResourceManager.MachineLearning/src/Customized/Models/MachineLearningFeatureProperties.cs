// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore GA parameterless construction and settable feature properties.
    [CodeGenSuppress("MachineLearningFeatureProperties")]
    [CodeGenSuppress("DataType")]
    [CodeGenSuppress("FeatureName")]
    public partial class MachineLearningFeatureProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningFeatureProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningFeatureProperties()
        {
        }

        /// <summary> Specifies type. </summary>
        [WirePath("dataType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FeatureDataType? DataType { get; set; }

        /// <summary> Specifies name. </summary>
        [WirePath("featureName")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FeatureName { get; set; }
    }
}
