using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Windows.Azure.Management
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
        internal static String DecodeBase64(this String input)
        {
            Byte[] strBytes = Convert.FromBase64String(input);

            return Encoding.UTF8.GetString(strBytes);
        }

        internal static String EncodeBase64(this String input)
        {
            Byte[] strBytes = Encoding.UTF8.GetBytes(input);

            return Convert.ToBase64String(strBytes);
        }
    }
}

namespace Windows.Azure.Management.v1_7
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
