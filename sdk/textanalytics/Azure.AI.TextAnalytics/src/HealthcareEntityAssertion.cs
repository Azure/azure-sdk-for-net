// Copyright (c) Microsoft Corporation. All rights reserved.
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

        /// <summary> Initializes a new instance of HealthcareEntityAssertion. </summary>
        internal HealthcareEntityAssertion()
        {
            // See https://github.com/Azure/azure-sdk-for-net/issues/28323 for why this constructor and the following properties were redefined.
        }

        /// <summary> Describes any conditionality on the entity. </summary>
        public EntityConditionality? Conditionality { get; }
        /// <summary> Describes the entities certainty and polarity. </summary>
        public EntityCertainty? Certainty { get; }
        /// <summary> Describes if the entity is the subject of the text or if it describes someone else. </summary>
        public EntityAssociation? Association { get; }
    }
}
