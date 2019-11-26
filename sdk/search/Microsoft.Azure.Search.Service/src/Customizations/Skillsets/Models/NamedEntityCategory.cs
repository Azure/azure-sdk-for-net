// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for NamedEntityCategory. This is deprecated, use <see cref="EntityCategory"/> instead
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [Obsolete("Use EntityCategory instead.")]
    public enum NamedEntityCategory
    {
        [EnumMember(Value = "location")]
        Location,
        [EnumMember(Value = "organization")]
        Organization,
        [EnumMember(Value = "person")]
        Person
    }

    [Obsolete("Use EntityCategoryEnumExtension instead.")]
    internal static class NamedEntityCategoryEnumExtension
    {
        internal static string ToSerializedValue(this NamedEntityCategory? value)
        {
            return value == null ? null : ((NamedEntityCategory)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this NamedEntityCategory value)
        {
            switch (value)
            {
                case NamedEntityCategory.Location:
                    return "location";
                case NamedEntityCategory.Organization:
                    return "organization";
                case NamedEntityCategory.Person:
                    return "person";
            }
            return null;
        }

        internal static NamedEntityCategory? ParseNamedEntityCategory(this string value)
        {
            switch (value)
            {
                case "location":
                    return NamedEntityCategory.Location;
                case "organization":
                    return NamedEntityCategory.Organization;
                case "person":
                    return NamedEntityCategory.Person;
            }
            return null;
        }
    }
}
