// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.AgentServer.Optimization
{
    /// <summary>
    /// Model factory that allows creating instances of output models for mocking and testing.
    /// </summary>
    public static partial class AgentServerOptimizationModelFactory
    {
        /// <summary> Creates a new <see cref="CandidateDeployConfig"/> instance for mocking. </summary>
        /// <param name="instructions"> System prompt / instructions. </param>
        /// <param name="model"> Foundry deployment name. </param>
        /// <param name="temperature"> Optional sampling temperature. </param>
        /// <param name="skills"> Optional skill overrides. </param>
        /// <returns> A new <see cref="CandidateDeployConfig"/> instance. </returns>
        public static CandidateDeployConfig CandidateDeployConfig(
            string instructions = default,
            string model = default,
            float? temperature = default,
            IEnumerable<OptimizationAgentSkill> skills = default)
        {
            return new CandidateDeployConfig(
                instructions,
                model,
                temperature,
                skills?.ToList() ?? new List<OptimizationAgentSkill>(),
                additionalBinaryDataProperties: null);
        }
    }
}
