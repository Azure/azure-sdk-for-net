// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Test.HttpRecorder
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.Serialization.Formatters;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    public static class RecorderUtilities
    {
        static Regex binaryMimeRegex = new Regex("(image/*|audio/*|video/*|application/octet-stream|multipart/form-data)");

        public static bool IsHttpContentBinary(HttpContent content)
        {
            bool isBinary = false;
            var contentType = content?.Headers?.ContentType?.MediaType;

            if (contentType != null)
                isBinary = ( (content != null) && (binaryMimeRegex.IsMatch(contentType)) );

            return isBinary;
        }

        public static string SerializeBinary(byte[] content)
        {
            return Convert.ToBase64String(content);
        }

        public static byte[] DeserializeBinary(string content)
        {
            return Convert.FromBase64String(content);
        }

        public static string FormatString(string content)
        {
            if (IsXml(content))
            {
                return TryFormatXml(content);
            }
            else if (IsJson(content))
            {
                return TryFormatJson(content);
            }
            else
            {
                return content;
            }
        }

        public static string FormatHttpContent(HttpContent httpContent)
        {
            string formattedContent = string.Empty;
            if (IsHttpContentBinary(httpContent))
            {
                formattedContent = Convert.ToBase64String(httpContent.ReadAsByteArrayAsync().Result);
            }
            else
            {
                formattedContent = FormatString(httpContent.ReadAsStringAsync().Result);
            }

            return formattedContent;
        }

        public static HttpContent CreateHttpContent(string contentData)
        {
            HttpContent createdContent = null;
            byte[] hashBytes = null;
            bool isContentDataBinary = true;
            
            if (contentData != null)
            {
                try
                {
                    hashBytes = Convert.FromBase64String(contentData);
                    if (hashBytes != null)
                    {
                        createdContent = new ByteArrayContent(hashBytes);
                    }
                }
                catch { isContentDataBinary = false; }

                if (isContentDataBinary == false)
                {
                    createdContent = new StringContent(contentData);
                }
            }
            else
            {
                createdContent = new StringContent(string.Empty);
            }

            return createdContent;
        }

        /// <summary>
        /// Formats the given XML into indented way.
        /// </summary>
        /// <param name="content">The input xml string</param>
        /// <returns>The formatted xml string</returns>
        public static string TryFormatXml(string content)
        {
            try
            {
                XDocument doc = XDocument.Parse(content);
                return doc.ToString();
            }
            catch (Exception)
            {
                return content;
            }
        }

        /// <summary>
        /// Checks if the content is valid XML or not.
        /// </summary>
        /// <param name="content">The text to check</param>
        /// <returns>True if XML, false otherwise</returns>
        public static bool IsXml(string content)
        {
            try
            {
                XDocument doc = XDocument.Parse(content);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Handling the failure by returning the original string.")]
        public static string TryFormatJson(string str)
        {
            try
            {
                object parsedJson = JsonConvert.DeserializeObject(str);
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            }
            catch
            {
                // can't parse JSON, return the original string
                return str;
            }
        }

        public static bool IsJson(string content)
        {
            content = content.Trim();
            return content.StartsWith("{") && content.EndsWith("}")
                   || content.StartsWith("[") && content.EndsWith("]");
        }

        /// <summary>
        /// Perform an action on each element of a sequence.
        /// </summary>
        /// <typeparam name="T">Type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="action">The action to perform.</param>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            Debug.Assert(sequence != null, "sequence cannot be null!");
            Debug.Assert(action != null, "action cannot be null!");

            foreach (T element in sequence)
            {
                action(element);
            }
        }

        public static void SerializeJson<T>(T data, string path)
        {
            HttpMockServer.FileSystemUtilsObject.WriteFile(
                path, JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameAssemblyFormat = 0, // Simple = 0, Full = 1 (we have an issue with duplicate namespace between newtonsoft and System.Runtime.Serialization. Once we upgrade to newtonsoft 11.x, we can start using TypeNameAssemblyFormatHandling instead)
                    TypeNameHandling = TypeNameHandling.None
                }));
        }

        public static T DeserializeJson<T>(string path)
        {
            string json = HttpMockServer.FileSystemUtilsObject.ReadFileAsText(path);
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                {
                    TypeNameAssemblyFormat = 0, // Simple = 0, Full = 1 (we have an issue with duplicate namespace between newtonsoft and System.Runtime.Serialization. Once we upgrade to newtonsoft 11.x, we can start using TypeNameAssemblyFormatHandling instead)
                    TypeNameHandling = TypeNameHandling.None
                });
        }

        public static void CleanDirectory(string dir)
        {
            if (HttpMockServer.FileSystemUtilsObject.DirectoryExists(dir))
            {
                foreach (string file in HttpMockServer.FileSystemUtilsObject.GetFiles(dir, "*.*", true))
                {
                    HttpMockServer.FileSystemUtilsObject.DeleteFile(file);
                }
                foreach (string subDirectory in HttpMockServer.FileSystemUtilsObject.GetDirectories(dir, "*", true))
                {
                    HttpMockServer.FileSystemUtilsObject.DeleteDirectory(subDirectory);
                }
            }
        }

        public static void EnsureDirectoryExists(string dir)
        {
            if (!HttpMockServer.FileSystemUtilsObject.DirectoryExists(dir))
            {
                HttpMockServer.FileSystemUtilsObject.CreateDirectory(dir);
            }
        }        
        public static string EncodeUriAsBase64(Uri requestUri)
        {
            return RecorderUtilities.EncodeUriAsBase64(requestUri.PathAndQuery);
        }
        public static string EncodeUriAsBase64(string uriToEncode)
        {
            byte[] encodedUri = Encoding.UTF8.GetBytes(uriToEncode);
            return Convert.ToBase64String(encodedUri);
        }
        public static string DecodeBase64AsUri(string uriToDecode)
        {
            if (string.IsNullOrEmpty(uriToDecode))
            {
                return uriToDecode;
            }
            string[] uriSplit = uriToDecode.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (uriSplit.Length < 2)
            {
                return uriToDecode;
            }
            string headers = string.Empty;
            if (uriSplit.Length > 2)
            {
                headers = " " + string.Join(" ", uriSplit.Skip(2));
            }
            byte[] encodedUri = Convert.FromBase64String(uriSplit[1]);
            return string.Format("{0} {1}{2}", uriSplit[0], Encoding.UTF8.GetString(encodedUri, 0, encodedUri.Length), headers);
        }
    }
}
