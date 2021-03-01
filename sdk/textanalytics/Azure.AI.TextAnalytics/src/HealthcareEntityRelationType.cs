// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// HealthcareEntityRelationType
    /// </summary>
    public readonly struct HealthcareEntityRelationType : IEquatable<HealthcareEntityRelationType>
    {
        /// <summary>
        /// Specifies the relation type DirectionOfBodyStructure.
        /// </summary>
        public static readonly HealthcareEntityRelationType DirectionOfBodyStructure = new HealthcareEntityRelationType("DirectionOfBodyStructure");

        /// <summary>
        /// Specifies the relation type DirectionOfExamination.
        /// </summary>
        public static readonly HealthcareEntityRelationType DirectionOfExamination = new HealthcareEntityRelationType("DirectionOfExamination");

        /// <summary>
        /// Specifies the relation type RelationOfExamination.
        /// </summary>
        public static readonly HealthcareEntityRelationType RelationOfExamination = new HealthcareEntityRelationType("RelationOfExamination");

        /// <summary>
        /// Specifies the relation type TimeOfExamination.
        /// </summary>
        public static readonly HealthcareEntityRelationType TimeOfExamination = new HealthcareEntityRelationType("TimeOfExamination");

        /// <summary>
        /// Specifies the relation type DosageOfMedication.
        /// </summary>
        public static readonly HealthcareEntityRelationType DosageOfMedication = new HealthcareEntityRelationType("DosageOfMedication");

        private readonly string _value;

        private HealthcareEntityRelationType(string relationtype)
        {
            Argument.AssertNotNull(relationtype, nameof(relationtype));
            _value = relationtype;
        }

        /// <summary>
        /// Defines implicit conversion from string to HealthcareEntityRelationType.
        /// </summary>
        /// <param name="relationtype">string to convert.</param>
        /// <returns>The string as an HealthcareEntityRelationType.</returns>
        public static implicit operator HealthcareEntityRelationType(string relationtype) => new HealthcareEntityRelationType(relationtype);

        /// <summary>
        /// Defines explicit conversion from HealthcareEntityRelationType to string.
        /// </summary>
        /// <param name="relationtype">HealthcareEntityRelationType to convert.</param>
        /// <returns>The HealthcareEntityRelationType as a string.</returns>
        public static explicit operator string(HealthcareEntityRelationType relationtype) => relationtype._value;

        /// <summary>
        /// Compares two HealthcareEntityRelationType values for equality.
        /// </summary>
        /// <param name="left">The first HealthcareEntityRelationType to compare.</param>
        /// <param name="right">The second HealthcareEntityRelationType to compare.</param>
        /// <returns>true if the HealthcareEntityRelationType objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(HealthcareEntityRelationType left, HealthcareEntityRelationType right) => Equals(left, right);

        /// <summary>
        /// Compares two HealthcareEntityRelationType values for inequality.
        /// </summary>
        /// <param name="left">The first HealthcareEntityRelationType to compare.</param>
        /// <param name="right">The second HealthcareEntityRelationType to compare.</param>
        /// <returns>true if the HealthcareEntityRelationType objects are not equal; false otherwise.</returns>
        public static bool operator !=(HealthcareEntityRelationType left, HealthcareEntityRelationType right) => !Equals(left, right);

        /// <summary>
        /// Compares the HealthcareEntityRelationType for equality with another HealthcareEntityRelationType.
        /// </summary>
        /// <param name="other">The HealthcareEntityRelationType with which to compare.</param>
        /// <returns><c>true</c> if the HealthcareEntityRelationType objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(HealthcareEntityRelationType other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HealthcareEntityRelationType relationtype && Equals(relationtype);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the HealthcareEntityRelationType.
        /// </summary>
        /// <returns>The HealthcareEntityRelationType as a string.</returns>
        public override string ToString() => _value;
    }
}
