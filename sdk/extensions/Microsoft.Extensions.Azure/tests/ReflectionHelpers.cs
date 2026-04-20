// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.Core.Extensions.Tests
{
    /// <summary>
    /// Helpers for accessing non-public members via reflection in tests.
    /// Provides clear failure messages when a member is not found.
    /// </summary>
    internal static class ReflectionHelpers
    {
        private const BindingFlags NonPublicInstance = BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// Gets the value of a non-public instance property from the specified object.
        /// </summary>
        public static object GetNonPublicPropertyValue(object target, string propertyName)
        {
            Assert.IsNotNull(target, $"Cannot get property '{propertyName}' from a null target.");
            Type type = target.GetType();
            PropertyInfo property = type.GetProperty(propertyName, NonPublicInstance);
            Assert.IsNotNull(property, $"Non-public instance property '{propertyName}' was not found on type '{type.FullName}'.");
            return property.GetValue(target);
        }

        /// <summary>
        /// Gets the value of a non-public instance property from the specified type rather than the runtime type.
        /// </summary>
        public static object GetNonPublicPropertyValue(Type declaringType, object target, string propertyName)
        {
            Assert.IsNotNull(target, $"Cannot get property '{propertyName}' from a null target.");
            PropertyInfo property = declaringType.GetProperty(propertyName, NonPublicInstance);
            Assert.IsNotNull(property, $"Non-public instance property '{propertyName}' was not found on type '{declaringType.FullName}'.");
            return property.GetValue(target);
        }

        /// <summary>
        /// Gets the value of a non-public instance field from the specified object.
        /// </summary>
        public static object GetNonPublicFieldValue(object target, string fieldName)
        {
            Assert.IsNotNull(target, $"Cannot get field '{fieldName}' from a null target.");
            Type type = target.GetType();
            FieldInfo field = type.GetField(fieldName, NonPublicInstance);
            Assert.IsNotNull(field, $"Non-public instance field '{fieldName}' was not found on type '{type.FullName}'.");
            return field.GetValue(target);
        }

        /// <summary>
        /// Gets the value of a non-public instance field from the specified type rather than the runtime type.
        /// </summary>
        public static object GetNonPublicFieldValue(Type declaringType, object target, string fieldName)
        {
            Assert.IsNotNull(target, $"Cannot get field '{fieldName}' from a null target.");
            FieldInfo field = declaringType.GetField(fieldName, NonPublicInstance);
            Assert.IsNotNull(field, $"Non-public instance field '{fieldName}' was not found on type '{declaringType.FullName}'.");
            return field.GetValue(target);
        }

        /// <summary>
        /// Gets the value of a non-public instance field whose name ends with the given suffix.
        /// </summary>
        public static object GetNonPublicFieldValueBySuffix(Type declaringType, object target, string fieldNameSuffix)
        {
            Assert.IsNotNull(target, $"Cannot get field ending with '{fieldNameSuffix}' from a null target.");
            FieldInfo field = declaringType
                .GetFields(NonPublicInstance)
                .FirstOrDefault(f => f.Name.EndsWith(fieldNameSuffix));
            Assert.IsNotNull(field, $"Non-public instance field ending with '{fieldNameSuffix}' was not found on type '{declaringType.FullName}'.");
            return field.GetValue(target);
        }
    }
}
