// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// HealthcareRelation class.
    /// </summary>
    public partial class HealthcareRelation
    {
        /// <summary> Initializes a new instance of HealthcareRelation. </summary>
        /// <param name="relationType"> Type of relation. Examples include: `DosageOfMedication` or `FrequencyOfMedication`, etc. </param>
        /// <param name="bidirectional"> If true the relation between the entities is bidirectional, otherwise directionality is source to target. </param>
        /// <param name="source"> Reference link to the source entity. </param>
        /// <param name="target"> Reference link to the target entity. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relationType"/>, <paramref name="source"/>, or <paramref name="target"/> is null. </exception>
        internal HealthcareRelation(string relationType, bool bidirectional, HealthcareEntity source, HealthcareEntity target)
        {
            if (relationType == null)
            {
                throw new ArgumentNullException(nameof(relationType));
            }
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            RelationType = relationType;
            Bidirectional = bidirectional;
            Source = source;
            Target = target;
        }

        /// <summary>
        /// Source Entity
        /// </summary>
        public HealthcareEntity Source { get; }

        /// <summary>
        /// Target Entity
        /// </summary>
        public HealthcareEntity Target { get; }

        /// <summary> Type of relation. Examples include: `DosageOfMedication` or `FrequencyOfMedication`, etc. </summary>
        public string RelationType { get; }
        /// <summary> If true the relation between the entities is bidirectional, otherwise directionality is source to target. </summary>
        public bool Bidirectional { get; }
    }
}
