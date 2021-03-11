// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// TODO.
    /// </summary>
    [Serializable]
    public class ArmException : RequestFailedException
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
        /// <param name="status"> The HTTP status code, or <c>0</c> if not available. </param>
        /// <param name="errorCode"> The error message that explains the reason for the exception. </param>
        /// <param name="message"> The service specific error code. </param>
        /// <param name="innerException"> The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        /// <param name="response"> The HTTP Response. </param>
        public ArmException(int status, string message, string? errorCode, Exception? innerException, Response? response)
            : base(status, message, errorCode, innerException)
        {
            var content = ReadContentAsync(response, true).ConfigureAwait(false).GetAwaiter().GetResult();
            if (GetResponseProperty(content, "code", out object code))
            {
                Code = (string)code;
            }
            if (GetResponseProperty(content, "code", out object target))
            {
                Target = (string)target;
            }
            if (GetResponseProperty(content, "code", out object additionalInfo))
            {
                Data.Clear();
                foreach (KeyValuePair<string, string> item in (ArrayList)additionalInfo)
                {
                    Data.Add(item.Key, item.Value);
                }
            }
            if (GetResponseProperty(content, "code", out object details))
            {
                Details = (ArrayList)details;
            }
            AdditionalInfo = Data;
        }

        /// <inheritdoc />
        protected ArmException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Get the content string from Response.
        /// </summary>
        /// <param name="response"> The source HTTP Response. </param>
        /// <param name="async"> Use this method async or not. </param>
        private static async ValueTask<string?> ReadContentAsync(Response response, bool async)
        {
            string? content = null;

            if (response.ContentStream != null &&
                ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out var encoding))
            {
                using (var streamReader = new StreamReader(response.ContentStream, encoding))
                {
                    content = async ? await streamReader.ReadToEndAsync().ConfigureAwait(false) : streamReader.ReadToEnd();
                }
            }

            return content;
        }

        /// <summary>
        /// Get specified property from provided JSON string.
        /// </summary>
        /// <param name="propertyName"> The name of property. </param>
        /// <param name="content"> The source JSON file. </param>
        /// <param name="properties"> The return result. </param>
        private static bool GetResponseProperty(string content, string propertyName, out object properties)
        {
            JsonDocument jsonObejct = JsonDocument.Parse(content);
            if (jsonObejct.RootElement.TryGetProperty("error", out JsonElement error))
            {
                if (TryGetProperties(error, propertyName, out properties))
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (TryGetProperties(jsonObejct.RootElement, propertyName, out properties))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Get specified property value from provided JSON Element.
        /// </summary>
        /// <param name="rootElements"> The source JSON element. </param>
        /// <param name="propertyName"> The name of property. </param>
        /// <param name="properties"> The return result. </param>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        protected static bool TryGetProperties(JsonElement rootElements, string propertyName, out object properties)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            JsonElement targetProperty;
            if (rootElements.TryGetProperty(propertyName, out targetProperty))
            {
                switch (targetProperty.ValueKind)
                {
                    case JsonValueKind.String:
                        properties = targetProperty.GetString();
                        return true;
                    case JsonValueKind.Array:
                        ArrayList result = new ();
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
                        properties = result;
                        return true;
                    default:
                        properties = targetProperty;
                        return true;
                }
            }
            else
            {
                properties = null;
                return false;
                // TODO: Do we need to throw exception here?
                // throw new InvalidOperationException("No such Property: " + propertyName + " exsit in current Json");
            }
        }
    }
}
