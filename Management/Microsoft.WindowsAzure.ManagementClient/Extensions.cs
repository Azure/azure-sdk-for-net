//-----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains internal extension methods.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ManagementClient
{
    //internal helper extensions for reading content
    internal static class HttpContentExtensions
    {
        //for calls to http client, when we get the result
        //the content has already been read, so ReadAsAsync
        //will end upt being synchronous anyway.
        //this helper also sets the formatter...
        internal static T ReadAsSync<T>(this HttpContent content, MediaTypeFormatter formatter)
        {
            Task<T> resTask;

            if (formatter != null)
            {
                resTask = content.ReadAsAsync<T>(new List<MediaTypeFormatter> { formatter });
            }
            else
            {
                resTask = content.ReadAsAsync<T>();
            }

            //this will block if necessary, but it never should be...
            //even if we did, this is running in a separate thread already, as part of a task.
            return resTask.Result;

        }
    }

    //internal helper extensions for string encoding/decoding
    internal static class StringExtensions
    {
        internal static string DecodeBase64(this string input)
        {
            Byte[] strBytes = Convert.FromBase64String(input);

            return Encoding.UTF8.GetString(strBytes);
        }

        internal static string EncodeBase64(this string input)
        {
            Byte[] strBytes = Encoding.UTF8.GetBytes(input);

            return Convert.ToBase64String(strBytes);
        }
    }
}

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    //internal helpers for throwing extended exceptions
    internal static class HttpResponseMessageExtensions
    {
        internal static void EnsureSuccessStatusCodeEx(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new AzureHttpRequestException(response);
            }
        }
    }
}
