// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// TODO.
    /// </summary>
    [Serializable]
    public class ManagementException : RequestFailedException, System.Runtime.Serialization.ISerializable
    {
        /// <summary>
        /// Gets and set the Code of the response.
        /// </summary>
        public string? Code { get; }

        /// <summary>
        /// Gets and set the Target of the response.
        /// </summary>
        public string? Target { get; }

        /// <summary>
        /// Gets and set the Details of the response.
        /// </summary>
        public ArrayList Details { get; }

        /// <summary>
        /// Gets and set the AdditionalInfo of the response.
        /// </summary>
        public IDictionary AdditionalInfo { get; }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="message"> TODO. </param>
        public ManagementException(string message) : this(0, message)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="message"> TODO. </param>
        /// <param name="innerException"></param>
        public ManagementException(string message, Exception? innerException) : this(0, message, innerException)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="message"> TODO. </param>
        /// <param name="status"></param>
        public ManagementException(int status, string message)
            : this(status, message, null)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"> TODO. </param>
        /// <param name="innerException"></param>
        public ManagementException(int status, string message, Exception? innerException)
            : this(status, message, null, innerException, null)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="errorCode"> TODO. </param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="content"></param>
        public ManagementException(int status, string message, string? errorCode, Exception? innerException, string? content)
            : base(status, message, errorCode, innerException)
        {
            Code = ErrorCode;
            Target = (string)GetResponseProperty(content, "target");
            Data.Clear();
            foreach (KeyValuePair<string,string> item in (ArrayList)GetResponseProperty(content, "additionalInfo"))
            {
                Data.Add(item.Key, item.Value);
            }
            Details = (ArrayList)GetResponseProperty(content, "details");
            AdditionalInfo = this.Data;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"> TODO. </param>
        protected ManagementException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="propertyName"> TODO. </param>
        /// <param name="content"> TODO. </param>
        public static object GetResponseProperty(string content, string propertyName)
        {
            JsonDocument jsonObejct = JsonDocument.Parse(content);
            JsonElement error;
            if (jsonObejct.RootElement.TryGetProperty("error", out error))
            {
                return TryGetProperties(error, propertyName);
            }
            else
            {
                return TryGetProperties(jsonObejct.RootElement, propertyName);
            }
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="rootElements"> TODO. </param>
        /// <param name="propertyName"> TODO. </param>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        protected static object TryGetProperties(JsonElement rootElements, string propertyName)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            JsonElement targetProperty;
            if (rootElements.TryGetProperty(propertyName, out targetProperty))
            {
                switch (targetProperty.ValueKind)
                {
                    case JsonValueKind.String:
                        return targetProperty.GetString();
                    case JsonValueKind.Array:
                        ArrayList result = new ArrayList();
                        foreach (JsonElement item in targetProperty.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.String)
                            {
                                result.Add(item.GetString());
                            } else if (item.ValueKind == JsonValueKind.Object)
                            {
                                foreach (var childElement in item.EnumerateObject())
                                {
                                    result.Add(new KeyValuePair<string, string>(childElement.Name, childElement.Value.ToString()));
                                }     
                            }
                        }
                        return result;
                    default:
                        return targetProperty;
                }
            }
            else
            {
                throw new InvalidOperationException("No such Property: " + propertyName + " exsit in current Json");
            }
        }
    }
}
