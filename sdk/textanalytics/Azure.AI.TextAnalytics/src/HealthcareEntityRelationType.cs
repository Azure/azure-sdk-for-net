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
    public class HealthcareEntityRelationType : IEquatable<HealthcareEntityRelationType>
    {
        /// <summary>
        /// Specifies that the entity corresponds to a Person.
        /// </summary>
        public static readonly HealthcareEntityRelationType DirectionOfBodyStructure = new HealthcareEntityRelationType("DirectionOfBodyStructure");

        /// <summary>
        /// Specifies that the entity corresponds to a job type or role held by a person.
        /// </summary>
        public static readonly HealthcareEntityRelationType DirectionOfExamination = new HealthcareEntityRelationType("DirectionOfExamination");

        /// <summary>
        /// RelationOfExamination
        /// </summary>
        public static readonly HealthcareEntityRelationType RelationOfExamination = new HealthcareEntityRelationType("RelationOfExamination");

        /// <summary>
        /// TimeOfExamination
        /// </summary>
        public static readonly HealthcareEntityRelationType TimeOfExamination = new HealthcareEntityRelationType("TimeOfExamination");

        private readonly string _value;

        private HealthcareEntityRelationType(string category)
        {
            Argument.AssertNotNull(category, nameof(category));
            _value = category;
        }

        /// <summary>
        /// Defines implicit conversion from string to EntityCategory.
        /// </summary>
        /// <param name="category">string to convert.</param>
        /// <returns>The string as an EntityCategory.</returns>
        public static implicit operator HealthcareEntityRelationType(string category) => new HealthcareEntityRelationType(category);

        /// <summary>
        /// Defines explicit conversion from EntityCategory to string.
        /// </summary>
        /// <param name="category">EntityCategory to convert.</param>
        /// <returns>The EntityCategory as a string.</returns>
        public static explicit operator string(HealthcareEntityRelationType category) => category._value;

        /// <summary>
        /// Compares two EntityCategory values for equality.
        /// </summary>
        /// <param name="left">The first EntityCategory to compare.</param>
        /// <param name="right">The second EntityCategory to compare.</param>
        /// <returns>true if the EntityCategory objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(HealthcareEntityRelationType left, HealthcareEntityRelationType right) => Equals(left, right);

        /// <summary>
        /// Compares two EntityCategory values for inequality.
        /// </summary>
        /// <param name="left">The first EntityCategory to compare.</param>
        /// <param name="right">The second EntityCategory to compare.</param>
        /// <returns>true if the EntityCategory objects are not equal; false otherwise.</returns>
        public static bool operator !=(HealthcareEntityRelationType left, HealthcareEntityRelationType right) => !Equals(left, right);

        /// <summary>
        /// Compares the EntityCategory for equality with another EntityCategory.
        /// </summary>
        /// <param name="other">The EntityCategory with which to compare.</param>
        /// <returns><c>true</c> if the EntityCategory objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(HealthcareEntityRelationType other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HealthcareEntityRelationType category && Equals(category);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the EntityCategory.
        /// </summary>
        /// <returns>The EntityCategory as a string.</returns>
        public override string ToString() => _value;
    }
}
