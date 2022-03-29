﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Determines the assertions for the healthcare entity. <see cref="HealthcareEntityAssertion"/>
    /// Exposes <see cref="EntityConditionality"/>, <see cref="EntityAssociation"/> and <see cref="EntityCertainty"/>.
    /// </summary>
    [CodeGenModel("HealthcareAssertion")]
    public partial class HealthcareEntityAssertion
    {
        /// <summary>
        /// Returns a string that contains the values for the
        /// <see cref="HealthcareEntityAssertion"/> object.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(Association)}:'{Association}', {nameof(Certainty)}:'{Certainty}', {nameof(Conditionality)}:'{Conditionality}'";
        }
    }
}
