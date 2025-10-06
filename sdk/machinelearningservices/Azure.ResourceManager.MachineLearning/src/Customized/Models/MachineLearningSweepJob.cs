// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Sweep job definition. </summary>
    public partial class MachineLearningSweepJob : MachineLearningJobProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningSweepJob"/>. </summary>
        /// <param name="objective"> [Required] Optimization objective. </param>
        /// <param name="samplingAlgorithm">
        /// [Required] The hyperparameter sampling algorithm
        /// Please note <see cref="Models.SamplingAlgorithm"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="BayesianSamplingAlgorithm"/>, <see cref="GridSamplingAlgorithm"/> and <see cref="RandomSamplingAlgorithm"/>.
        /// </param>
        /// <param name="searchSpace"> [Required] A dictionary containing each parameter and its distribution. The dictionary key is the name of the parameter. </param>
        /// <param name="trial"> [Required] Trial component definition. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objective"/>, <paramref name="samplingAlgorithm"/>, <paramref name="searchSpace"/> or <paramref name="trial"/> is null. </exception>
        public MachineLearningSweepJob(MachineLearningObjective objective, SamplingAlgorithm samplingAlgorithm, BinaryData searchSpace, MachineLearningTrialComponent trial)
        {
            Argument.AssertNotNull(searchSpace, nameof(searchSpace));
            Argument.AssertNotNull(samplingAlgorithm, nameof(samplingAlgorithm));
            Argument.AssertNotNull(objective, nameof(objective));
            Argument.AssertNotNull(trial, nameof(trial));

            SearchSpace = searchSpace;
            SamplingAlgorithm = samplingAlgorithm;
            Objective = objective;
            Trial = trial;
            Inputs = new ChangeTrackingDictionary<string, MachineLearningJobInput>();
            Outputs = new ChangeTrackingDictionary<string, MachineLearningJobOutput>();
            JobType = JobType.Sweep;
        }
    }
}
