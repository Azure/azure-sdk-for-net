// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DataFactory.Tests.Framework
{
    public class Common
    {
        public const string ResourceGroupName = "ResourceGroup";

        /// <summary>
        /// The property name for object types that allow 
        /// a schema to be specified as a top-level property.
        /// </summary>
        public const string SchemaPropertyName = "$schema";

        /// <summary>
        /// Asserts if the items within the given two dictionaries are not the same.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="description"></param>
        /// <param name="onlyCompareDataMembers">When true, only data contracts members are compared.</param>
        /// <param name="treatNullSameAsEmptyString">When true, when comparing strings, null and and empty string are considered equivalent.</param>
        /// <param name="ignoreCollectionOrder">When true, expected and actual collections items do not have to be in the same order</param>
        /// <param name="getSortId">Value types and strings are already handled. If handling of more complex types is required, put it here.</param>
        /// <param name="tryConvertMismatchedTypes">if the actual type is not the same as the expected type, try to convert it. This allows a string representation of a Guid, for example, to be considered a match of the corresponding Guid.</param>
        public static void ValidateDictionariesItemsAreSame(
            IDictionary expected,
            IDictionary actual,
            string description = null,
            bool onlyCompareDataMembers = true,
            bool treatNullSameAsEmptyString = false,
            bool ignoreCollectionOrder = false,
            Func<object, IComparable> getSortId = null,
            bool tryConvertMismatchedTypes = false)
        {
            if (object.ReferenceEquals(expected, actual))
            {
                // if the two instances are the same, no need to do further validation.
                return;
            }

            Assert.Equal(expected.Count, actual.Count);
            foreach (object expectedKey in expected.Keys)
            {
                Assert.True(actual.Contains(expectedKey), description + ". Actual does not contain key " + expectedKey);
                Common.ValidateAreSame(
                    expected[expectedKey],
                    actual[expectedKey],
                    string.Format(CultureInfo.InvariantCulture, "{0}[\"{1}\"]", description, expectedKey),
                    onlyCompareDataMembers,
                    treatNullSameAsEmptyString,
                    ignoreCollectionOrder,
                    getSortId,
                    tryConvertMismatchedTypes);
            }
        }

        /// <summary>
        /// Asserts if the items within the given two collections are not the same.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="description"></param>
        /// <param name="onlyCompareDataMembers">When true, only data contracts members are compared.</param>
        /// <param name="treatNullSameAsEmptyString">When true, when comparing strings, null and and empty string are considered equivalent.</param>
        /// <param name="ignoreCollectionOrder">When true, expected and actual collections items do not have to be in the same order</param>
        /// <param name="getSortId">Value types and strings are already handled. If handling of more complex types is required, put it here.</param>
        /// <param name="tryConvertMismatchedTypes">if the actual type is not the same as the expected type, try to convert it. This allows a string representation of a Guid, for example, to be considered a match of the corresponding Guid.</param>
        public static void ValidateListItemsAreSame<T>(
            IList<T> expected,
            IList<T> actual,
            string description = null,
            bool onlyCompareDataMembers = true,
            bool treatNullSameAsEmptyString = false,
            bool ignoreCollectionOrder = false,
            Func<object, IComparable> getSortId = null,
            bool tryConvertMismatchedTypes = false)
        {
            if (object.ReferenceEquals(expected, actual))
            {
                // if the two instances are the same, no need to do further validation.
                return;
            }

            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Common.ValidateAreSame(
                    expected[i],
                    actual[i],
                    string.Format(CultureInfo.InvariantCulture, "{0}[{1}]", description, i),
                    onlyCompareDataMembers,
                    treatNullSameAsEmptyString,
                    ignoreCollectionOrder,
                    getSortId,
                    tryConvertMismatchedTypes);
            }
        }

        /// <summary>
        /// Asserts if the two instances are not the same.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="description"></param>
        /// <param name="onlyCompareDataMembers">When true, only data contracts members are compared.</param>
        /// <param name="treatNullSameAsEmptyString">When true, when comparing strings, null and and empty string are considered equivalent.</param>
        /// <param name="ignoreCollectionOrder">When true, expected and actual collections items do not have to be in the same order</param>
        /// <param name="getSortId">Value types and strings are already handled. If handling of more complex types is required, put it here.</param>
        /// <param name="tryConvertMismatchedTypes">if the actual type is not the same as the expected type, try to convert it. This allows a string representation of a Guid, for example, to be considered a match of the corresponding Guid.</param>
        public static void ValidateAreSame(
            object expected, 
            object actual, 
            string description = null, 
            bool onlyCompareDataMembers = true, 
            bool treatNullSameAsEmptyString = false, 
            bool ignoreCollectionOrder = false, 
            Func<object, IComparable> getSortId = null, 
            bool tryConvertMismatchedTypes = false)
        {
            if (object.ReferenceEquals(expected, actual))
            {
                // if the two instances are the same, no need to do further validation.
                return;
            }

            // If only one is null, fail.
            if ((expected == null) != (actual == null))
            {
                if (treatNullSameAsEmptyString && (expected is string || actual is string))
                {
                    expected = expected ?? string.Empty;
                    actual = actual ?? string.Empty;
                }
                Assert.Equal(expected, actual);
                return;
            }

            if (tryConvertMismatchedTypes)
            {
                Common.TryConvertMismatchedTypes(ref expected, ref actual);
            }
            Type itemType = expected.GetType();
            Type actualType = actual.GetType();

            Assert.Equal(itemType, actualType);

            if ((itemType.IsValueType && !itemType.IsConstructedGenericType) || itemType == typeof(string) || itemType == typeof(JValue))
            {
                Assert.Equal(expected, actual);
            }
            else
            {
                bool isTypeDataContract = (itemType.GetCustomAttribute<DataContractAttribute>() != null);
                IDictionary expectedAsDictionary = expected as IDictionary;

                BindingFlags getPropertiesFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty;
                foreach (PropertyInfo property in itemType.GetProperties(getPropertiesFlags))
                {
                    bool isPropertyReadOnly = false;
                    ReadOnlyAttribute readOnlyAttribute = property.GetCustomAttribute<ReadOnlyAttribute>();
                    if (readOnlyAttribute != null)
                    {
                        isPropertyReadOnly = readOnlyAttribute.IsReadOnly;
                    }
                    string childPropertyName = property.Name;
                    if (!property.GetMethod.GetParameters().Any() &&// skip properties that have input parameters, like indexers on collections, dictionaries, etc.
                        !isPropertyReadOnly && // skip properties that are decorated with the ReadOnlyAttribute. This is used to flag properties that should not be evaluated here, such as properties that are set on the server (like ChangeTag)
                        (!onlyCompareDataMembers || !isTypeDataContract || property.GetCustomAttribute<DataMemberAttribute>() != null) && // skip non-DataMember properties, if required
                        (expectedAsDictionary == null || (childPropertyName != "Keys" && childPropertyName != "Values"))// skip dictionary-specific properties that are compared later in an order-insensitive fashion
                        )
                    {
                        object expectedPropertyValue = property.GetValue(expected, null);
                        if (!object.ReferenceEquals(expected, expectedPropertyValue))// Protect against infinite recursion (can happen with the SyncRoot property of arrays)
                        {
                            object actualPropertyValue = property.GetValue(actual, null);
                            Common.ValidateAreSame(expectedPropertyValue, actualPropertyValue, string.Format(CultureInfo.InvariantCulture, "{0}.{1}", description, childPropertyName), onlyCompareDataMembers, treatNullSameAsEmptyString, ignoreCollectionOrder, getSortId, tryConvertMismatchedTypes);
                        }
                    }
                    else
                    {
                        // skipped property
                    }
                }


                var expectedAsEnumerable = expected as IEnumerable;

                if (expectedAsEnumerable != null)
                {
                    if (expectedAsDictionary != null)
                    {
                        Common.ValidateDictionariesItemsAreSame(
                            expectedAsDictionary,
                            (IDictionary)actual,
                            description,
                            onlyCompareDataMembers,
                            treatNullSameAsEmptyString,
                            ignoreCollectionOrder,
                            getSortId,
                            tryConvertMismatchedTypes);
                    }
                    else
                    {
                        var expectedItems = expectedAsEnumerable.Cast<object>().ToList();
                        var actualItems = ((IEnumerable)actual).Cast<object>().ToList();

                        if (ignoreCollectionOrder)
                        {
                            // Reorder the actual list to be in the same order as the expected list.
                            object firstExpectedItem = expectedItems.FirstOrDefault();
                            if (firstExpectedItem != null)
                            {
                                if (firstExpectedItem.GetType().IsValueType || firstExpectedItem is string || firstExpectedItem is IComparable || firstExpectedItem is byte[])
                                {
                                    var reorderedActualItems = new List<object>();
                                    foreach (object expectedItem in expectedItems)
                                    {
                                        int matchingActualItemIndex;
                                        if (expectedItem == null)
                                        {
                                            matchingActualItemIndex = actualItems.FindIndex(item => item == null);
                                        }
                                        else
                                        {
                                            var expectedBytes = expectedItem as byte[];
                                            if (expectedBytes != null)
                                            {
                                                matchingActualItemIndex = actualItems.FindIndex(item =>
                                                {
                                                    var bytes = item as byte[];
                                                    if (bytes != null && expectedBytes.Length == bytes.Length)
                                                    {
                                                        for (int i = 0; i < bytes.Length; i++)
                                                        {
                                                            if (bytes[i] != expectedBytes[i])
                                                            {
                                                                return false;
                                                            }
                                                        }
                                                        return true;
                                                    }
                                                    return false;
                                                });
                                            }
                                            else
                                            {
                                                matchingActualItemIndex = actualItems.FindIndex(item => expectedItem.Equals(item));
                                            }
                                        }
                                        Assert.True(matchingActualItemIndex >= 0, description + ". Actual collection does not contain a item =" + expectedItem);
                                        reorderedActualItems.Add(actualItems[matchingActualItemIndex]);
                                        actualItems.RemoveAt(matchingActualItemIndex);
                                    }
                                    reorderedActualItems.AddRange(actualItems);
                                    actualItems = reorderedActualItems;
                                }
                                else if (getSortId != null && getSortId(firstExpectedItem) != null) // If the user provided a function to help sort, then use it.
                                {
                                    var reorderedActualItems = new List<object>();
                                    foreach (object expectedItem in expectedItems)
                                    {
                                        IComparable expectedSortId = getSortId(expectedItem);
                                        int matchingActualItemIndex = actualItems.FindIndex(item => getSortId(item).Equals(expectedSortId));
                                        Assert.True(matchingActualItemIndex >= 0, description + ". Actual collection does not contain an item with sort id=" + expectedSortId);
                                        reorderedActualItems.Add(actualItems[matchingActualItemIndex]);
                                        actualItems.RemoveAt(matchingActualItemIndex);
                                    }
                                    reorderedActualItems.AddRange(actualItems);
                                    actualItems = reorderedActualItems;
                                }
                            }
                        }

                        Common.ValidateListItemsAreSame(
                            expectedItems,
                            actualItems,
                            description,
                            onlyCompareDataMembers,
                            treatNullSameAsEmptyString,
                            ignoreCollectionOrder,
                            getSortId,
                            tryConvertMismatchedTypes);
                    }
                }
            }
        }

        public static void TryConvertMismatchedTypes(ref object expectedValue, ref object actualValue)
        {
            if (expectedValue == null || actualValue == null)
            {
                return;
            }

            Type expectedType = expectedValue.GetType();
            Type actualType = actualValue.GetType();

            if (expectedType != actualType)
            {
                // Try to convert the actual value to the expected type.
                if (!ValueWrapper.TryConvertToType(actualValue, expectedType, out actualValue))
                {
                    // Try to convert the expected value to the actual type.
                    ValueWrapper.TryConvertToType(expectedValue, actualType, out expectedValue);
                }
            }
        }

        public static void AssertAreEqual(Object expected, Object actual)
        {
            string jsonExpected = JsonConvert.SerializeObject(expected);
            string jsonActual = JsonConvert.SerializeObject(actual);
            string description = null;
            if (expected != null)
            {
                description = expected.GetType().Name;
            }

            JsonComparer.ValidateAreSame(
                JObject.Parse(jsonExpected),
                JObject.Parse(jsonActual),
                description,
                ignoreCase: true,
                ignoreDefaultValues: true);
        }
    }
}
