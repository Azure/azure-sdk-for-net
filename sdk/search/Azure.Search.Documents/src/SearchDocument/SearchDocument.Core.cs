// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core;

// This logic belongs in DynamicData, but they may not ship at the same time
// so we optionally compile a private version of it into SearchDocument.
#if EXPERIMENTAL_DYNAMIC
namespace Azure.Core
{
    public partial class DynamicData
#else
namespace Azure.Search.Documents.Models
{
    public partial class SearchDocument
#endif
    {
        /// <summary>
        /// The document properties.
        /// </summary>
        private readonly IDictionary<string, object> _values;

        /// <summary>
        /// Set a document property.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        private protected void SetValue(string name, object value)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            _values[name] = value;
        }

        /// <summary>
        /// Get a document property.
        /// </summary>
        /// <typeparam name="T">The expected type of the property value.</typeparam>
        /// <param name="name">The property name.</param>
        /// <returns>The value of the property.</returns>
        private protected T GetValue<T>(string name) => (T)GetValue(name, typeof(T));

        /// <summary>
        /// Get a document property.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The expected type of the property value.</param>
        /// <returns>The value of the property.</returns>
        private protected object GetValue(string name, Type type = null)
        {
            if (!TryGetValue(name, type, out object value))
            {
                KeyNotFoundException exception = new KeyNotFoundException(
                    "Could not find a member called '" + name + "' in the document.");
                exception.Data["MissingName"] = name;
                throw exception;
            }
            return value;
        }

        /// <summary>
        /// Try to get a document property.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The expected type of the property value.</param>
        /// <param name="value">The value of the property if found.</param>
        /// <returns>A value indicating whether the property was found.</returns>
        private protected bool TryGetValue(string name, Type type, out object value)
        {
            if (string.IsNullOrEmpty(name))
            {
                value = null;
                return false;
            }

            type ??= typeof(object);
            bool found = _values.TryGetValue(name, out value);
            if (found && type != typeof(object))
            {
                value = ConvertValue(value, type);
            }
            return found;
        }

        /// <summary>
        /// Attempt to convert a value to the desired type.  This is full of
        /// Search specific conversions and I'd expect to be able to override
        /// a base version of this provided by DynamicData.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type to convert to.</param>
        /// <returns>The converted value.</returns>
        private protected static object ConvertValue(object value, Type type)
        {
            // Short circuit values that are already in the right format
            if (value == null || type == null || type.IsAssignableFrom(value.GetType()))
            {
                return value;
            }

            // Just unwrap Nullable<>s since we've already handled null above
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type elementType = type.GetGenericArguments()[0];
                return ConvertValue(value, elementType);
            }

            // Arrays deserialize as object[] but we usually want T[]
            if (type.IsArray && type.GetArrayRank() == 1 && value is Array values)
            {
                Type elementType = type.GetElementType();
                int length = values.Length;
                Array converted = Array.CreateInstance(elementType, length);
                for (int i = 0; i < length; i++)
                {
                    converted.SetValue(
                        ConvertValue(values.GetValue(i), elementType),
                        i);
                }
                return converted;
            }

            // Special case DateTime/DateTimeOffset/and textual doubles that we
            // don't convert until a user requests them in a given format
            if (value is string text)
            {
                if (type == typeof(DateTime) &&
                    DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
                else if (type == typeof(DateTimeOffset) &&
                    DateTimeOffset.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeOffset dateOffset))
                {
                    return dateOffset;
                }
                else if (type == typeof(double))
                {
                    if (string.Equals(text, Constants.NanValue, StringComparison.Ordinal))
                    {
                        return double.NaN;
                    }
                    else if (string.Equals(text, Constants.InfValue, StringComparison.Ordinal))
                    {
                        return double.PositiveInfinity;
                    }
                    else if (string.Equals(text, Constants.NegativeInfValue, StringComparison.Ordinal))
                    {
                        return double.NegativeInfinity;
                    }
                }
            }

            // Otherwise we'll use Convert.ChangeType on primitives, except we
            // don't want to turn bools to/from numbers, strings to/from other
            // types, or cast doubles to integral types
            bool canChange =
                type.IsPrimitive &&
                !(value is bool) && type != typeof(bool) &&
                !(value is string) && type != typeof(string) &&
                (!(value is double) || (type != typeof(int) && type != typeof(long)));
            if (canChange)
            {
                value = Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
            }

            return value;
        }
    }
}
