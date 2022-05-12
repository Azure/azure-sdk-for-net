// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Gets the entity category inferred by the Language service's named entity recognition model.
    /// The list of available categories is described at <see href="https://docs.microsoft.com/azure/cognitive-services/language-service/named-entity-recognition/concepts/named-entity-categories">
    /// Supported entity categories in Named Entity Recognition</see>.
    /// </summary>
    public readonly struct EntityCategory : IEquatable<EntityCategory>
    {
        /// <summary>
        /// Specifies that the entity corresponds to a Person.
        /// </summary>
        public static readonly EntityCategory Person = new EntityCategory("Person");

        /// <summary>
        /// Specifies that the entity corresponds to a job type or role held by a person.
        /// </summary>
        public static readonly EntityCategory PersonType = new EntityCategory("PersonType");

        /// <summary>
        /// Specifies that the entity contains natural or human-made landmarks, structures, or geographical features.
        /// </summary>
        public static readonly EntityCategory Location = new EntityCategory("Location");

        /// <summary>
        /// Specifies that the entity contains the name of an organization, corporation, agency, or other group of people.
        /// </summary>
        public static readonly EntityCategory Organization = new EntityCategory("Organization");

        /// <summary>
        /// Specifies that the entity contains historical, social and natural-occuring events.
        /// </summary>
        public static readonly EntityCategory Event = new EntityCategory("Event");

        /// <summary>
        /// Specifies that the entity contains physical objects of various categories.
        /// </summary>
        public static readonly EntityCategory Product = new EntityCategory("Product");

        /// <summary>
        /// Specifies an entity describing a capability or expertise.
        /// </summary>
        public static readonly EntityCategory Skill = new EntityCategory("Skill");

        /// <summary>
        /// Specifies that the entity contains a date, time or duration.
        /// </summary>
        public static readonly EntityCategory DateTime = new EntityCategory("DateTime");

        /// <summary>
        /// Specifies that the entity contains a phone number (US phone numbers only).
        /// </summary>
        public static readonly EntityCategory PhoneNumber = new EntityCategory("PhoneNumber");

        /// <summary>
        /// Specifies that the entity contains an email address.
        /// </summary>
        public static readonly EntityCategory Email = new EntityCategory("Email");

        /// <summary>
        /// Specifies that the entity contains an Internet URL.
        /// </summary>
        public static readonly EntityCategory Url = new EntityCategory("URL");

        /// <summary>
        /// Specifies that the entity contains an Internet Protocol Address.
        /// </summary>
        public static readonly EntityCategory IPAddress = new EntityCategory("IPAddress");

        /// <summary>
        /// Specifies that the entity contains a number or numeric quantity.
        /// </summary>
        public static readonly EntityCategory Quantity = new EntityCategory("Quantity");

        /// <summary>
        /// Specifies that the entity contains an address.
        /// </summary>
        public static readonly EntityCategory Address = new EntityCategory("Address");

        private readonly string _value;

        private EntityCategory(string category)
        {
            Argument.AssertNotNull(category, nameof(category));
            _value = category;
        }

        /// <summary>
        /// Defines implicit conversion from string to EntityCategory.
        /// </summary>
        /// <param name="category">string to convert.</param>
        /// <returns>The string as an EntityCategory.</returns>
        public static implicit operator EntityCategory(string category) => new EntityCategory(category);

        /// <summary>
        /// Defines explicit conversion from EntityCategory to string.
        /// </summary>
        /// <param name="category">EntityCategory to convert.</param>
        /// <returns>The EntityCategory as a string.</returns>
        public static explicit operator string(EntityCategory category) => category._value;

        /// <summary>
        /// Compares two EntityCategory values for equality.
        /// </summary>
        /// <param name="left">The first EntityCategory to compare.</param>
        /// <param name="right">The second EntityCategory to compare.</param>
        /// <returns>true if the EntityCategory objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(EntityCategory left, EntityCategory right) => Equals(left, right);

        /// <summary>
        /// Compares two EntityCategory values for inequality.
        /// </summary>
        /// <param name="left">The first EntityCategory to compare.</param>
        /// <param name="right">The second EntityCategory to compare.</param>
        /// <returns>true if the EntityCategory objects are not equal; false otherwise.</returns>
        public static bool operator !=(EntityCategory left, EntityCategory right) => !Equals(left, right);

        /// <summary>
        /// Compares the EntityCategory for equality with another EntityCategory.
        /// </summary>
        /// <param name="other">The EntityCategory with which to compare.</param>
        /// <returns><c>true</c> if the EntityCategory objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(EntityCategory other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EntityCategory category && Equals(category);

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
