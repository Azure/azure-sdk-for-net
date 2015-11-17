// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Microsoft.Azure.Test.HttpRecorder
{
    public static class Utilities
    {
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
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                    TypeNameHandling = TypeNameHandling.None
                }));
        }

        public static T DeserializeJson<T>(string path)
        {
            string json = HttpMockServer.FileSystemUtilsObject.ReadFileAsText(path);
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                {
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
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
            return Utilities.EncodeUriAsBase64(requestUri.PathAndQuery);
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
