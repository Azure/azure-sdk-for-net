// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Class to wrap System.Json.Text.JsonElement.</summary>
    internal class AuthEventJsonElement : ICloneable
    {
        private JsonElement _jsonElement;

        /// <summary>Gets or sets the properties.</summary>
        /// <value>The properties.</value>
        internal Dictionary<string, object> Properties { get; } = new Dictionary<string, object>();
        /// <summary>Gets or sets the string value.</summary>
        /// <value>The value.</value>
        internal string Value { get; set; }
        /// <summary>Gets or sets the child json elements.</summary>
        /// <value>The elements.</value>
        internal List<AuthEventJsonElement> Elements { get; } = new List<AuthEventJsonElement>();
        /// <summary>If the object is derived from a property, the is represents the property name.</summary>
        /// <value>The key.</value>
        internal string Key { get; set; }

        /// <summary>Initializes a new instance of the <see cref="AuthEventJsonElement" /> class.</summary>
        internal AuthEventJsonElement() { }

        /// <summary>Initializes a new instance of the <see cref="AuthEventJsonElement" /> class.</summary>
        /// <param name="properties">Predefined properties and values.</param>
        internal AuthEventJsonElement(Dictionary<string, object> properties)
        {
            Properties = properties;
        }

        /// <summary>Initializes a new instance of the <see cref="AuthEventJsonElement" /> class.</summary>
        /// <param name="value">A json string to build the object from.</param>
        internal AuthEventJsonElement(string value)
        {
            Utf8JsonReader reader = new(new ReadOnlySequence<byte>(Encoding.UTF8.GetBytes(value)));
            if (!BuildElement(ref reader))
            {
                Value = value;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="AuthEventJsonElement" /> class.</summary>
        /// <param name="reader">A json reader to build the object from.</param>
        internal AuthEventJsonElement(ref Utf8JsonReader reader)
        {
            BuildElement(ref reader);
        }

        /// <summary>Initializes a new instance of the <see cref="AuthEventJsonElement" /> class.</summary>
        /// <param name="jsonElement">A System.Text.Json.JsonElement to build the object from.</param>
        internal AuthEventJsonElement(JsonElement jsonElement)
        {
            BuildElement(jsonElement);
        }

        /// <summary>Builds the element.</summary>
        /// <param name="reader">The reader.</param>
        /// <returns>If the element was built successfully then true.</returns>
        internal bool BuildElement(ref Utf8JsonReader reader)
        {
            return JsonDocument.TryParseValue(ref reader, out JsonDocument jDoc) ? BuildElement(jDoc.RootElement) : false;
        }

        /// <summary>Builds the element.</summary>
        /// <param name="jsonElement">The json element.</param>
        /// <returns>True.</returns>
        internal bool BuildElement(JsonElement jsonElement)
        {
            _jsonElement = jsonElement;

            if (_jsonElement.ValueKind == JsonValueKind.String)
            {
                Value = _jsonElement.GetString();
            }
            else if (_jsonElement.ValueKind == JsonValueKind.Object)
            {
                foreach (var prop in _jsonElement.EnumerateObject())
                    Properties.Add(prop.Name, GetUnderlying(prop.Value, prop.Name));
            }
            else if (_jsonElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var prop in _jsonElement.EnumerateArray())
                    Elements.Add(new AuthEventJsonElement(prop));
            }

            return true;
        }

        /// <summary>Sets the property value.</summary>
        /// <typeparam name="T">The type of the property value to be set.</typeparam>
        /// <param name="propertyValue">The property value.</param>
        /// <param name="path">The json path.</param>
        /// <returns>If the property exists and was set successfully then true else false.</returns>
        internal bool SetProperty<T>(T propertyValue, params string[] path)
        {
            (string key, Dictionary<string, object> props) = FindPropertyDictionary(false, path);
            if (key != null)
            {
                props[key] = propertyValue;
                return true;
            }

            return false;
        }

        /// <summary>Finds the elements based on the parent property name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>A list of all elements that match the name.</returns>
        internal List<AuthEventJsonElement> FindElementsNamed(string name)
        {
            List<AuthEventJsonElement> result = new();
            SearchForElements(name, result, this);
            return result;
        }

        /// <summary>Finds the elements with that has a child property that matches the name parameter.</summary>
        /// <param name="name">The name.</param>
        /// <returns>A list of elements that contain the property name.</returns>
        internal List<AuthEventJsonElement> FindElementsWithPropertyNamed(string name)
        {
            List<AuthEventJsonElement> result = new();
            SearchForElements(name, result, this, false, true);
            return result;
        }

        /// <summary>Finds the first element that that property name matches the name parameter.</summary>
        /// <param name="name">The name.</param>
        /// <returns>The first element found else null.</returns>
        internal AuthEventJsonElement FindFirstElementNamed(string name)
        {
            List<AuthEventJsonElement> result = new();
            SearchForElements(name, result, this, true);
            return result.FirstOrDefault();
        }

        /// <summary>Finds the first element with that has a child property that matches the name parameter.</summary>
        /// <param name="name">The name.</param>
        /// <returns>The first element matched or null.</returns>
        internal AuthEventJsonElement FindFirstElementWithPropertyNamed(string name)
        {
            List<AuthEventJsonElement> result = new();
            SearchForElements(name, result, this, true, true);
            return result.FirstOrDefault();
        }

        /// <summary>Finds the elements that property matches the regular expression parameter.</summary>
        /// <param name="expression">The regular expression.</param>
        /// <returns>
        ///   A list of elements that match.
        /// </returns>
        internal List<AuthEventJsonElement> FindElementsByExpression(Regex expression)
        {
            List<AuthEventJsonElement> result = new();
            SearchForElementsByRegex(expression, result, this);
            return result;
        }

        /// <summary>Finds the elements with that has a child property that matches on the regular expression parameter.</summary>
        /// <param name="expression">The regular expression.</param>
        /// <returns>All elements that matching child properties.</returns>
        internal List<AuthEventJsonElement> FindElementsByPropertyExpression(Regex expression)
        {
            List<AuthEventJsonElement> result = new();
            SearchForElementsByRegex(expression, result, this, true);
            return result;
        }
        private void SearchForElementsByRegex(Regex expresson, List<AuthEventJsonElement> container, AuthEventJsonElement element, bool withPropertyValue = false)
        {
            foreach (KeyValuePair<string, object> keyValue in element.Properties)
            {
                if (expresson.IsMatch(keyValue.Key))
                {
                    if (keyValue.Value is AuthEventJsonElement ele)
                    {
                        container.Add(ele);
                    }
                    else if (withPropertyValue)
                    {
                        container.Add(element);
                    }
                }
                else if (withPropertyValue && keyValue.Value is string checkValue && expresson.IsMatch(checkValue))
                {
                    container.Add(element);
                }

                if (keyValue.Value is AuthEventJsonElement e)
                {
                    SearchForElementsByRegex(expresson, container, e, withPropertyValue);
                }
            }
            foreach (AuthEventJsonElement eventJsonElement in element.Elements)
                SearchForElementsByRegex(expresson, container, eventJsonElement, withPropertyValue);
        }

        private void SearchForElements(string name, List<AuthEventJsonElement> container, AuthEventJsonElement element, bool findFirst = false, bool withPropertyValue = false)
        {
            foreach (KeyValuePair<string, object> keyValue in element.Properties)
            {
                if (keyValue.Key.Equals(name))
                {
                    if (keyValue.Value is AuthEventJsonElement ele)
                    {
                        container.Add(ele);
                    }
                    else if (withPropertyValue)
                    {
                        container.Add(element);
                    }

                    if (findFirst)
                    {
                        break;
                    }
                }
                else if (withPropertyValue && keyValue.Value is string checkValue && name.Equals(checkValue))
                {
                    container.Add(element);
                }

                if ((container.Count == 0 || !findFirst) && (keyValue.Value is AuthEventJsonElement e))
                {
                    SearchForElements(name, container, e, findFirst, withPropertyValue);
                }
            }
            if (container.Count == 0 || !findFirst)
            {
                foreach (AuthEventJsonElement eventJsonElement in element.Elements)
                    SearchForElements(name, container, eventJsonElement, findFirst, withPropertyValue);
            }
        }

        /// <summary>Gets the property value for a string value.</summary>
        /// <param name="path">The path to the element. (For example "ParentElement", "ChildElement").</param>
        /// <returns>String value of the property or null.</returns>
        internal string GetPropertyValue(params string[] path)
        {
            return GetPropertyValue<string>(path);
        }

        /// <summary>Gets the property value of a certain type.</summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="path">The path to the element. (For example "ParentElement", "ChildElement").</param>
        /// <returns>The object if able to case or null if not found.</returns>
        internal T GetPropertyValue<T>(params string[] path)
        {
            return FindPropertyValue<T>(out T result, path) ? result : default;
        }

        /// <summary>Gets the property value of a certain type.</summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="result">If the property exists return the result of type T.</param>
        /// <param name="path">The path to the element. (For example "ParentElement", "ChildElement").</param>
        /// <returns>True of the property exists else false.</returns>
        internal bool FindPropertyValue<T>(out T result, params string[] path)
        {
            (string key, Dictionary<string, object> props) = FindPropertyDictionary(false, path);
            if (key != null)
            {
                result = (T)props[key];
                return true;
            }
            else
            {
                result = (T)Activator.CreateInstance(typeof(T));
                return false;
            }
        }

        /// <summary>Verfies that a json path exists.</summary>
        /// <param name="path">The path.</param>
        /// <returns>True if the elements and sub-elements are present.</returns>
        internal bool PathExists(params string[] path)
        {
            (string key, Dictionary<string, object> props) = FindPropertyDictionary(false, path);
            return key != null && props.ContainsKey(key);
        }

        /// <summary>Finds the property dictionary that the property key belongs to based on the json path..</summary>
        /// <param name="create">if set to <c>true created the property if it does not exists in the current search path.</c>.</param>
        /// <param name="path">The path to the element. (For example "ParentElement", "ChildElement").</param>
        /// <returns>Returns the key and it's related dictionary.</returns>
        internal (string Key, Dictionary<string, object> Container) FindPropertyDictionary(bool create = false, params string[] path)
        {
            AuthEventJsonElement current = this;
            for (int i = 0; i < path.Length - 1; i++)
            {
                if (current != null && current.Properties.ContainsKey(path[i]) && current.Properties[path[i]] is AuthEventJsonElement jsonElement)
                {
                    current = jsonElement;
                }
                else
                {
                    if (create)
                    {
                        AuthEventJsonElement newEle = new();
                        current.Properties.Add(path[i], newEle);
                        current = newEle;
                    }
                    else
                        current = null;
                }
            }

            if (current != null && current.Properties.ContainsKey(path.Last()) && current.Properties[path.Last()] != null)
            {
                return (path.Last(), current.Properties);
            }
            else if (create)
            {
                AuthEventJsonElement newEle = new();
                current.Properties.Add(path.Last(), newEle);
                return (path.Last(), current.Properties);
            }

            return (null, null);
        }

        /// <summary>Removes all elements and properties.</summary>
        internal void RemoveAll()
        {
            Properties.Clear();
            Value = null;
            Elements.Clear();
        }

        /// <summary>Merges the specified element with another element, coping the parameter element's properties and elements. If there is a conflict, the parameter element value is used.</summary>
        /// <param name="element">The element to merge in.</param>
        internal void Merge(AuthEventJsonElement element)
        {
            foreach (string key in element.Properties.Keys)
            {
                object value = element.Properties[key];

                if (!Properties.ContainsKey(key))
                {
                    Properties.Add(key, (value is ICloneable cloneable) ? cloneable.Clone() : value);
                }
                else
                {
                    if (Properties[key] is AuthEventJsonElement subElement && value is AuthEventJsonElement mergeSubElement)
                    {
                        subElement.Merge(mergeSubElement);
                    }
                    else
                    {
                        Properties[key] = (value is ICloneable cloneable) ? cloneable.Clone() : value;
                    }
                }
            }
            Value = element.Value;
            foreach (AuthEventJsonElement e in element.Elements)
                Elements.Add((AuthEventJsonElement)e.Clone());
        }

        /// <summary>Output the element to a json string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance as json.</returns>
        public override string ToString()
        {
            using MemoryStream ms = new();
            using var jsonWriter = new Utf8JsonWriter(ms);
            WriteTo(jsonWriter);

            jsonWriter.Flush();
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        private void WriteTo(Utf8JsonWriter jsonWriter)
        {
            if (_jsonElement.ValueKind == JsonValueKind.Object || _jsonElement.ValueKind == JsonValueKind.Undefined)
            {
                if (Properties.Count > 0)
                {
                    jsonWriter.WriteStartObject();
                    foreach (string propertyName in Properties.Keys)
                    {
                        jsonWriter.WritePropertyName(propertyName);
                        WriteObjectToWriter(jsonWriter, Properties[propertyName]);
                    }
                    jsonWriter.WriteEndObject();
                }
                else if (Elements.Count == 1)//If there are no properties but one child element attached to the parent property write it out.
                {
                    WriteObjectToWriter(jsonWriter, Elements[0]);
                }
                else if (Elements.Count > 1)//If there are no properties but child elements attached to the parent property write it out to array.
                {
                    WriteObjectToWriter(jsonWriter, Elements);
                }
                else if (_jsonElement.ValueKind == JsonValueKind.Object)//Write out empty object.
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WriteEndObject();
                }
            }
            else if (_jsonElement.ValueKind == JsonValueKind.Array)
            {
                WriteObjectToWriter(jsonWriter, Elements);
            }
            else if (_jsonElement.ValueKind == JsonValueKind.String)
            {
                WriteObjectToWriter(jsonWriter, Value);
            }
        }

        private static void WriteObjectToWriter(Utf8JsonWriter writer, object value)
        {
            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                switch (value)
                {
                    case string v:
                        writer.WriteStringValue(v);
                        break;
                    case bool v:
                        writer.WriteBooleanValue(v);
                        break;
                    case decimal v:
                        writer.WriteNumberValue(v);
                        break;
                    case int v:
                        writer.WriteNumberValue(v);
                        break;
                    case double v:
                        writer.WriteNumberValue(v);
                        break;
                    case float v:
                        writer.WriteNumberValue(v);
                        break;
                    case DateTime v:
                        writer.WriteStringValue(v);
                        break;
                    case Guid v:
                        writer.WriteStringValue(v);
                        break;
                    case AuthEventJsonElement v:
                        v.WriteTo(writer);
                        break;
                    case List<AuthEventJsonElement> arr:
                        writer.WriteStartArray();
                        foreach (var item in arr)
                            item.WriteTo(writer);
                        writer.WriteEndArray();
                        break;
                    default:
                        writer.WriteStringValue(value.ToString());
                        break;
                }
            }
        }

        private static object GetUnderlying(JsonElement value, string key)
        {
            return value.ValueKind switch
            {
                JsonValueKind.False => false,
                JsonValueKind.Null => null,
                JsonValueKind.Number => value.GetInt32(),
                JsonValueKind.True => true,
                JsonValueKind.String => value.GetString(),
                _ => new AuthEventJsonElement(value)
                {
                    Key = key
                },
            };
        }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}