using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Dictionary for custom properties.
    /// </summary>
    internal class CustomPropertiesDictionary: Dictionary<string, object>
    {
        /// <summary>
        /// Initializes a dictionary with no properties.
        /// </summary>
        internal CustomPropertiesDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// Initializes a dictionary with properties from the response.
        /// </summary>
        /// <param name="response">Response.</param>
        internal CustomPropertiesDictionary(HttpResponseMessage response)
            : this()
        {
            foreach (KeyValuePair<string, IEnumerable<string>> item in response.Headers)
            {
                string key = item.Key;
                string valueString = string.Join(string.Empty, item.Value);
                JsonValue translatedValue;

                if (JsonValue.TryParse(valueString, out translatedValue) && IsSupportedType(translatedValue.ValueType))
                {
                    Add(key, DecodeValue(translatedValue));
                }
                else
                {
                    // The string could not be deserialized into Json value; storing raw string data.
                    Add(key, valueString);
                }
            }
        }

        /// <summary>
        /// Submits stored properties to the request.
        /// </summary>
        /// <param name="request">HTTP request.</param>
        internal void SubmitTo(HttpRequestMessage request)
        {
            foreach (KeyValuePair<string, object> item in this)
            {
                JsonValue value = EncodeValue(item.Value);
                request.Headers.Add(item.Key, value.Stringify());
            }
        }

        /// <summary>
        /// Extracts actual value from the given Json value.
        /// </summary>
        /// <param name="value">Json value.</param>
        /// <returns>Actual value.</returns>
        private static object DecodeValue(JsonValue value)
        {
            switch (value.ValueType)
            {
                case JsonValueType.Boolean: return value.GetBoolean();
                case JsonValueType.Null: return null;
                case JsonValueType.Number: return value.GetNumber();
                default:
                    Debug.Assert(value.ValueType == JsonValueType.String);
                    return value.GetString();
            }
        }

        /// <summary>
        /// Checks if the dictionary supports serialization/deserialization of 
        /// values of the given type.
        /// </summary>
        /// <param name="type">Json value type.</param>
        /// <returns>True if supported.</returns>
        private static bool IsSupportedType(JsonValueType type)
        { 
            switch (type)
            {
                case JsonValueType.Boolean:
                case JsonValueType.Null:
                case JsonValueType.Number:
                case JsonValueType.String:
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Translates an object into Json value.
        /// </summary>
        /// <param name="value">Object to translate.</param>
        /// <returns>Translated Json object.</returns>
        private static JsonValue EncodeValue(object value)
        {
            Type type = value == null? null : value.GetType();

            if (type == null)
            {
                return JsonValue.Parse(Constants.JsonNullValue);
            }
            else if (IsType<System.Boolean>(type))
            {
                return JsonValue.CreateBooleanValue((bool)value);
            }
            else if (IsType<System.Int16>(type) || IsType<System.Int32>(type) || IsType<System.Int64>(type) ||
                IsType<System.UInt16>(type) || IsType<System.UInt32>(type) || IsType<System.UInt64>(type) ||
                IsType<System.Byte>(type) || IsType<System.Decimal>(type) || IsType<System.Double>(type) ||
                IsType<System.SByte>(type) || IsType<System.Single>(type))
            {
                return JsonValue.CreateNumberValue(Convert.ToDouble(value));
            }
            else if (IsType<System.String>(type))
            {
                return JsonValue.CreateStringValue((string)value);
            }
            else
            {
                //TODO: error message!
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// Compares types.
        /// </summary>
        /// <typeparam name="T">Type 1.</typeparam>
        /// <param name="type">Type 2.</param>
        /// <returns>Result of comparison.</returns>
        private static bool IsType<T>(Type type)
        {
            return object.ReferenceEquals(typeof(T), type);
        }
    }
}
