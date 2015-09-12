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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace DataFactory.Tests.Framework
{
    public class JsonComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actualJObject"></param>
        /// <param name="settings"></param>
        /// <param name="description"></param>
        /// <param name="propertiesToIgnore">The full paths of properties to ignore. Should contain properties that correspond to user-provided property bag keys. 
        /// Since they don't correspond to OM properties, their casing is left exactly how the user specified.</param>
        public static void ValidatePropertyNameCasing(
            JObject actualJObject,
            JsonSerializerSettings settings,
            string description,
            HashSet<string> propertiesToIgnore)
        {
            JsonComparer.ValidatePropertyNameCasing(
                actualJObject,
                JsonComparer.IsCamelCase(settings),
                description,
                propertiesToIgnore);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actualJToken"></param>
        /// <param name="isCamelCase"></param>
        /// <param name="description"></param>
        /// <param name="propertiesToIgnore">The full paths of properties to ignore. Should contain properties that correspond to user-provided property bag keys. 
        /// Since they don't correspond to OM properties, their casing is left exactly how the user specified.</param>
        public static void ValidatePropertyNameCasing(JToken actualJToken, bool isCamelCase, string description, HashSet<string> propertiesToIgnore)
        {
            if (actualJToken == null)
            {
                return;
            }

            switch (actualJToken.Type)
            {
                case JTokenType.Object:
                    JObject actualJObject = (JObject)actualJToken;

                    foreach (KeyValuePair<string, JToken> pair in actualJObject)
                    {
                        string propertyName = pair.Key;
                        JToken value = pair.Value;

                        string propertyPath = string.IsNullOrEmpty(description)
                                                  ? propertyName
                                                  : description + "." + propertyName;

                        if (!string.Equals(propertyName, JsonUtilities.Type, JsonUtilities.PropertyNameComparison))
                        {
                            if (propertiesToIgnore == null || !propertiesToIgnore.Contains(propertyPath))
                            {
                                // Check the property name.
                                if (isCamelCase)
                                {
                                    bool isFirstCharLowerCase = (propertyName[0] == char.ToLower(propertyName[0], CultureInfo.CurrentCulture));
                                    Assert.True(isFirstCharLowerCase, propertyPath + " is not camelCase.");
                                }
                                else
                                {
                                    bool isFirstCharUpperCase = (propertyName[0] == char.ToUpper(propertyName[0], CultureInfo.CurrentCulture));
                                    Assert.True(isFirstCharUpperCase, propertyPath + " is not PascalCase.");
                                }

                                // Check nested values
                                JsonComparer.ValidatePropertyNameCasing(value, isCamelCase, propertyPath, propertiesToIgnore);
                            }
                            else
                            {
                                // Ensure the property casing did not get changed.
                                string expectedPath = propertiesToIgnore.Single(val => propertiesToIgnore.Comparer.Equals(val, propertyPath));
                                string expectedName = expectedPath.Substring(expectedPath.Length - propertyName.Length);
                                Assert.Equal(expectedName, propertyName);
                            }
                        }
                    }
                    break;

                case JTokenType.Array:
                    JArray jArray = (JArray)actualJToken;
                    for (int i = 0; i < jArray.Count; i++)
                    {
                        JsonComparer.ValidatePropertyNameCasing(jArray[i], isCamelCase, description + "[" + i + "]", propertiesToIgnore);
                    }
                    break;

                case JTokenType.Boolean:
                case JTokenType.Bytes:
                case JTokenType.Comment:
                case JTokenType.Date:
                case JTokenType.Float:
                case JTokenType.Guid:
                case JTokenType.Integer:
                case JTokenType.Raw:
                case JTokenType.String:
                case JTokenType.TimeSpan:
                case JTokenType.Uri:
                case JTokenType.Property:
                case JTokenType.Null:
                    // Nothing to do.
                    break;

                case JTokenType.Constructor:
                case JTokenType.None:
                case JTokenType.Undefined:
                default:
                    throw new NotImplementedException("Validation logic not implemented for JTokenType " + actualJToken.Type);
            }
        }

        private static bool IsCamelCase(JsonSerializerSettings settings)
        {
            return settings.ContractResolver is CamelCasePropertyNamesContractResolver;
        }

        public static void ValidateAreSame(string expected, string actual, string description = null, bool ignoreCase = false, bool ignoreDefaultValues = false)
        {
            JObject expectedJson = JObject.Parse(expected);
            JObject actualJson = JObject.Parse(actual);

            JsonComparer.ValidateAreSame(expectedJson, actualJson, description, ignoreCase, ignoreDefaultValues);
        }

        /// <summary>
        /// Asserts if the two instances are not the same.
        /// </summary>
        public static void ValidateAreSame(
            JObject expected, 
            JObject actual, 
            string description = null, 
            bool ignoreCase = false,
            bool ignoreDefaultValues = false)
        {
            if (object.ReferenceEquals(expected, actual))
            {
                // if the two instances are the same, no need to do further validation.
                return;
            }

            // If only one is null, fail.
            if ((expected == null) != (actual == null))
            {
                Assert.Equal(expected, actual);
                return;
            }

            var expectedKeys = new HashSet<string>(((IDictionary<string, JToken>)expected).Keys);
            var actualKeys = new HashSet<string>(((IDictionary<string, JToken>)actual).Keys);

            List<string> missingKeys = expectedKeys.Except(actualKeys, JsonUtilities.PropertyNameComparer).ToList();
            List<string> unexpectedKeys = actualKeys.Except(expectedKeys, JsonUtilities.PropertyNameComparer).ToList();

            JsonComparer.HandleKeyDiscrepancies(missingKeys, expected, ignoreDefaultValues, "{0} is missing the following key(s): {1}", description);
            JsonComparer.HandleKeyDiscrepancies(unexpectedKeys, actual, ignoreDefaultValues, "{0} contains the following unexpected key(s): {1}", description);

            var commonKeys = new HashSet<string>(expectedKeys.Intersect(actualKeys, JsonUtilities.PropertyNameComparer));

            foreach (KeyValuePair<string, JToken> pair in expected)
            {
                string key = pair.Key;
                if (!commonKeys.Contains(key))
                {
                    continue;
                }

                //JToken expectedValue = pair.Value;
                JToken expectedValue = expected.GetValue(key, JsonUtilities.PropertyNameComparison);
                JToken actualValue = actual.GetValue(key, JsonUtilities.PropertyNameComparison);
                JsonComparer.ValidateAreSame(expectedValue, actualValue, description + "." + key, ignoreCase, ignoreDefaultValues);
            }
        }

        private static void HandleKeyDiscrepancies(
            List<string> discrepancyKeys,
            JObject discrepancyJObject,
            bool ignoreDefaultValues,
            string errorMessageFormat,
            string description)
        {
            if (discrepancyKeys != null && discrepancyKeys.Any())
            {
                if (ignoreDefaultValues)
                {
                    // Ignore discrepancies where the missing/unexpected value is the default type value.
                    for (int i = discrepancyKeys.Count - 1; i >= 0; i--)
                    {
                        string discrepancyKey = discrepancyKeys[i];
                        JToken discrepancyToken = discrepancyJObject[discrepancyKey];
                        if (JsonComparer.IsDefaultValue(discrepancyToken)
                            || String.Equals(discrepancyKey, "hubName", StringComparison.OrdinalIgnoreCase))
                        {
                            discrepancyKeys.RemoveAt(i);
                        }
                    }
                }

                Assert.False(discrepancyKeys.Any(), string.Format(
                        CultureInfo.InvariantCulture,
                        errorMessageFormat,
                        description,
                        string.Join(",", discrepancyKeys)));
            }
        }

        public static void ValidateAreSame(JToken expected, JToken actual, string description = null, bool ignoreCase = false, bool ignoreDefaultValues = false)
        {
            if (JsonComparer.IsDefaultValue(expected) && JsonComparer.IsDefaultValue(actual))
            {
                return;
            }
            if ((expected == null) != (actual == null))
            {
                Assert.Equal(expected, actual);
            }

            Action validateTypesAreEqual = () =>
            {
                Assert.Equal(expected.Type, actual.Type);
            };

            switch (expected.Type)
            {
                case JTokenType.Object:
                    validateTypesAreEqual();
                    JsonComparer.ValidateAreSame((JObject)expected, (JObject)actual, description, ignoreCase, ignoreDefaultValues);
                    break;

                case JTokenType.Array:
                    validateTypesAreEqual();
                    JsonComparer.ValidateAreSame((JArray)expected, (JArray)actual, description, ignoreCase, ignoreDefaultValues);
                    break;

                case JTokenType.Boolean:
                case JTokenType.Bytes:
                case JTokenType.Comment:
                case JTokenType.Date:
                case JTokenType.Float:
                case JTokenType.Guid:
                case JTokenType.Integer:
                case JTokenType.Raw:
                case JTokenType.String:
                case JTokenType.TimeSpan:
                case JTokenType.Uri:
                    if (!(actual is JValue))
                    {
                        validateTypesAreEqual();
                    }
                    JsonComparer.ValidateAreSame((JValue)expected, (JValue)actual, description, ignoreCase);
                    break;

                case JTokenType.Property:
                    validateTypesAreEqual();
                    JsonComparer.ValidateAreSame((JProperty)expected, (JProperty)actual, description, ignoreCase, ignoreDefaultValues);
                    break;

                case JTokenType.Null:
                    validateTypesAreEqual();
                    break;

                case JTokenType.Constructor:
                case JTokenType.None:
                case JTokenType.Undefined:
                default:
                    throw new NotImplementedException("Validation logic not implemented for JTokenType " + expected.Type);
            }
        }

        public static void ValidateAreSame(JProperty expected, JProperty actual, string description = null, bool ignoreCase = false, bool ignoreDefaultValues = false)
        {
            if ((expected == null) != (actual == null))
            {
                Assert.Equal(expected, actual);
            }
            JsonComparer.ValidateAreSame(expected.Value, expected.Value, description, ignoreCase, ignoreDefaultValues);
        }

        public static void ValidateAreSame(JArray expected, JArray actual, string description = null, bool ignoreCase = false, bool ignoreDefaultValues = false)
        {
            if ((expected == null) != (actual == null))
            {
                Assert.Equal(expected, actual);
            }

            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                JsonComparer.ValidateAreSame(expected[i], actual[i], description + "[" + i + "]", ignoreCase, ignoreDefaultValues);
            }
        }

        public static void ValidateAreSame(JValue expected, JValue actual, string description = null, bool ignoreCase = false)
        {
            if ((expected == null) != (actual == null))
            {
                Assert.Equal(expected, actual);
            }

            if (expected != null && actual != null)
            {
                object expectedValue = expected.Value;
                object actualValue = actual.Value;

                // If one token is a DateTime '01/01/2001 00:00:00AM' and the other is a String '2001-01-01',
                // we will convert the String into an Utc datetime for comparison.
                if (expected.Type == JTokenType.Date || actual.Type == JTokenType.Date)
                {
                    if (expected.Type == JTokenType.String)
                    {
                        expectedValue = ParseDateTime((string)expectedValue);
                    }

                    if (actual.Type == JTokenType.String)
                    {
                        actualValue = ParseDateTime((string)actualValue);
                    }
                }

                Common.TryConvertMismatchedTypes(ref expectedValue, ref actualValue);

                if (expectedValue is DateTime && actualValue is DateTime)
                {
                    DateTime expectedUtc = ((DateTime)expectedValue).EnforceUtcZone();
                    DateTime actualUtc = ((DateTime)actualValue).EnforceUtcZone();

                    Assert.True(expectedUtc.CompareTo(actualUtc) == 0, string.Format(
                            CultureInfo.InvariantCulture,
                            "Expected:{0}. Actual:{1}. {2}",
                            expectedUtc.ToString("MM/dd/yyyy HH:mm:ss fff", CultureInfo.InvariantCulture),
                            actualUtc.ToString("MM/dd/yyyy HH:mm:ss fff", CultureInfo.InvariantCulture),
                            description));
                }
                else
                {
                    Assert.Equal(expectedValue, actualValue);
                }
            }
        }


        /// <summary>
        /// Returns whether the given token is the default value for its type.
        /// </summary>
        /// <param name="jToken"></param>
        public static bool IsDefaultValue(JToken jToken)
        {
            bool isDefault = false;

            switch (jToken.Type)
            {
                case JTokenType.Array:
                    JArray jArray = (JArray)jToken;
                    isDefault = !jArray.Children().Any();
                    break;

                case JTokenType.Object:
                    JObject jObject = (JObject)jToken;
                    isDefault = !((IDictionary<string, JToken>)jObject).Any();
                    break;

                case JTokenType.Boolean:
                    isDefault = JsonComparer.IsDefault<bool>(jToken);
                    break;

                case JTokenType.Bytes:
                    IEnumerable<byte> bytes = jToken.ToObject<IEnumerable<byte>>();
                    isDefault = (bytes == null || !bytes.Any());
                    break;

                case JTokenType.Date:
                    isDefault = JsonComparer.IsDefault<DateTime>(jToken);
                    break;

                case JTokenType.Float:
                    isDefault = JsonComparer.IsDefault<double>(jToken);
                    break;

                case JTokenType.Guid:
                    isDefault = JsonComparer.IsDefault<Guid>(jToken);
                    break;

                case JTokenType.Integer:
                    isDefault = JsonComparer.IsDefault<long>(jToken);
                    break;

                case JTokenType.String:
                    isDefault = JsonComparer.IsDefault<string>(jToken);
                    if (!isDefault)
                    {
                        // Kludgy workaround for TimeSpans or DateTimes being serialized to strings.
                        TimeSpan timeSpan;
                        DateTime dateTime;
                        string value = jToken.ToObject<string>();
                        if (TimeSpan.TryParse(value, out timeSpan))
                        {
                            isDefault = JsonComparer.IsDefault<TimeSpan>(jToken);
                        }
                        else if (DateTime.TryParse(value, out dateTime))
                        {
                            isDefault = JsonComparer.IsDefault<DateTime>(jToken);
                        }
                    }
                    break;

                case JTokenType.TimeSpan:
                    isDefault = JsonComparer.IsDefault<TimeSpan>(jToken);
                    break;

                case JTokenType.Null:
                    isDefault = true;
                    break;

                default:
                    throw new InvalidOperationException("Unhandled JToken type: " + jToken.Type + ", " + jToken.ToString());
            }

            return isDefault;
        }

        private static bool IsDefault<T>(JToken jToken)
        {
            return object.Equals(jToken.ToObject<T>(), default(T));
        }

        private static DateTime ParseDateTime(string value)
        {
            try
            {
                return DateTime.ParseExact(value,
                    CustomIsoDateTimeConverter.ValidDateTimeFormats,
                    CustomIsoDateTimeConverter.DefaultCulture,
                    CustomIsoDateTimeConverter.DefaultDateTimeStyles);
            }
            catch (Exception ex)
            {
                // This happens when the Json was serialized with the Customization codes in the client side MAML layer.
                AdfTestLogger.LogVerbose(
                    "Failed to parse \"{0}\" with CustomIsoDateTimeConverter with exception {1}. Fall back to the default DateTime parser.",
                    value, ex.Message);

                return DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        } 
    }
}
