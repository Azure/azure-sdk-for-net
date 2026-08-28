// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningSweepJob
    {
        // The current generated constructor order follows TypeSpec, but GA exposed a Swagger-era overload with searchSpace first.
        // TypeSpec decorators do not control constructor overload ordering, so keep the old overload and delegate to the generated shape.
        /// <summary> Initializes a new instance of <see cref="MachineLearningSweepJob"/>. </summary>
        public MachineLearningSweepJob(MachineLearningObjective objective, SamplingAlgorithm samplingAlgorithm, BinaryData searchSpace, MachineLearningTrialComponent trial)
            : this(description: null, properties: null, tags: null, additionalBinaryDataProperties: null, componentId: null, computeId: null, displayName: null, experimentName: null, identity: null, isArchived: null, jobType: JobType.Sweep, notificationSetting: null, parentJobName: null, services: null, status: null, earlyTermination: null, inputs: null, limits: null, objective, outputs: null, queueSettings: null, samplingAlgorithm, searchSpace, trial)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningSweepJob"/>. </summary>
        public MachineLearningSweepJob(BinaryData searchSpace, SamplingAlgorithm samplingAlgorithm, MachineLearningObjective objective, MachineLearningTrialComponent trial)
            : this(objective, samplingAlgorithm, searchSpace, trial)
        {
        }
    }
}
