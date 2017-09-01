// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Microsoft.AzureStack.TestFramework
{

    /// <summary>
    /// A collection of common values and functions
    /// </summary>
    public class Common
    {
        // This is just for code readability
        public const int Milliseconds = 1;
        public const int Seconds = 1000 * Milliseconds;
        public const int Minutes = 60 * Seconds;
        public const int Hours = 60 * Minutes;

        public static string RetrieveObject(HttpClient client, ServiceClientCredentials creds, string uri) {
            return RetrieveObject(client, creds, new Uri(uri));
        }

        public static string RetrieveObject(HttpClient client, ServiceClientCredentials creds, Uri uri) {
            var message = new HttpRequestMessage(HttpMethod.Get, uri);
            creds.ProcessHttpRequestAsync(message, System.Threading.CancellationToken.None);
            var result = client.SendAsync(message).Result;
            return result.Content.ToString();
        }

        public static string ExtractOperationId(string str) {
            int startIndex = str.LastIndexOf('/') + 1;
            int endIndex = str.LastIndexOf('?');
            int length = endIndex - startIndex;
            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// Generate a random name that can be ingested by Azure or AzureStack
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string GenerateRandomName(string prefix = "okaytodelete", bool useGuid = true) {
            StringBuilder sb = new StringBuilder(prefix);
            if (useGuid)
            {
                sb.Append(Guid.NewGuid());
            }
            else
            {
                const string acceptableCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";
                const int maxLength = 24;

                Random rand = new Random();

                for (int i = 0; sb.Length < maxLength; ++i)
                {
                    sb.Append(acceptableCharacters[rand.Next(acceptableCharacters.Length)]);
                }
            }
            return sb.ToString();

        }

        /// <summary>
        /// Count the number of elements in an IEnumerable.  If null then we return 0.
        /// </summary>
        /// <param name="iter">The IEnumerable containing the objects we want to count</param>
        /// <returns>The number of elements in the IEnumerable</returns>
        public static uint CountElements(IEnumerable iter) {
            if (iter == null) return 0;
            uint count = 0;
            foreach (var item in iter)
            {
                ++count;
            }
            return count;
        }

        /// <summary>
        /// Count the number of elements in the Pages
        /// </summary>
        /// <typeparam name="T">Elements in each page</typeparam>
        /// <param name="page">The first page to count from</param>
        /// <param name="next">A function to get the next page</param>
        /// <returns></returns>
        public static uint CountElementsInPages<T>(IPage<T> page, Func<string, IPage<T>> next) {
            uint count = 0;

            while (page != null)
            {
                count += CountElements(page);
                page = next(page.NextPageLink);
            }
            return count;
        }

        /// <summary>
        /// Given an operation retry it either some given number of times or until it succeeds
        /// </summary>
        /// <param name="retries">Maximum number of retries</param>
        /// <param name="func">Function which returns true if it succeeds, false otherwise</param>
        /// <param name="delay">Delay between retries</param>
        public static void RetryOperation(Func<bool> func, uint retries = 10, int delay = 250 * Common.Milliseconds) {
            while (retries > 0)
            {
                if (func())
                {
                    break;
                }
                --retries;
                System.Threading.Thread.Sleep(delay);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        public static Func<bool> RetryExceptionExpected(Action act) {
            return () => {
                try
                {
                    act();
                }
                catch
                {
                    return true;
                }
                return false;
            };
        }

        /// <summary>
        /// Apply an operation over an IList object
        /// </summary>
        /// <typeparam name="T">Underlying type stored in IList.</typeparam>
        /// <param name="list">List of items we will apply the operation over.</param>
        /// <param name="action">The action we wish to perform.</param>
        public static void MapOverIEnumerable<T>(IEnumerable<T> list, Action<T> action = default(Action<T>)) {
            foreach (var item in list)
            {
                action(item);
            }
        }

        /// <summary>
        /// Go over each page and perform some action on it.
        /// </summary>
        /// <typeparam name="T">Type of object held within the pages.</typeparam>
        /// <param name="start">Page we start from.</param>
        /// <param name="getNext">Function will return the next page.</param>
        /// <param name="action">What action to perform on each object.</param>
        public static void MapOverIPage<T>(IPage<T> start, Func<string, IPage<T>> getNext, Action<T> action = default(Action<T>)) {
            var curr = start;
            for (;;)
            {
                foreach (var obj in curr)
                {
                    action(obj);
                }

                if (string.IsNullOrEmpty(curr.NextPageLink))
                {
                    break;
                }

                curr = getNext(curr.NextPageLink);
            }
        }

        /// <summary>
        /// Iterate through each item in the pages and write its string representation to a file.
        /// The default action to get a string representation is to call toString on each object.
        /// </summary>
        /// <typeparam name="T">Type held in each page.</typeparam>
        /// <param name="start">The first page we want to start on.</param>
        /// <param name="getNext">A function which will return the next page.</param>
        /// <param name="filename">The filename we wish to write to.</param>
        public static void WriteIPagesToFile<T>(IPage<T> start, Func<string, IPage<T>> getNext, string filename) {
            WriteIPagesToFile(start, getNext, filename, (t) => t.ToString());
        }

        public static void WriteIEnumerableToFile<T>(IEnumerable<T> list, string filename) {
            WriteIEnumerableToFile(list, filename, (t) => t.ToString());
        }

        public static void WriteIEnumerableToFile<T>(IEnumerable<T> list, string filename, Func<T, string> toString) {
            StringBuilder sb = new StringBuilder();
            Action<T> action = (obj) => { sb.Append(toString(obj)); sb.AppendLine(); };
            MapOverIEnumerable<T>(list, action);
            System.IO.File.WriteAllText(filename, sb.ToString());
        }

        /// <summary>
        /// Iterate through each item in the pages and write its string representation to a file.
        /// </summary>
        /// <typeparam name="T">Type held in each page.</typeparam>
        /// <param name="start">The first page we want to start on.</param>
        /// <param name="getNext">A function which will return the next page.</param>
        /// <param name="filename">The filename we wish to write to.</param>
        /// <param name="toString">The function that will convert the object to a string.</param>
        public static void WriteIPagesToFile<T>(IPage<T> start, Func<string, IPage<T>> getNext, string filename, Func<T, string> toString) {
            StringBuilder sb = new StringBuilder();
            Action<T> action = (obj) => { sb.Append(toString(obj)); sb.AppendLine(); };
            MapOverIPage<T>(start, getNext, action);
            System.IO.File.WriteAllText(filename, sb.ToString());
        }

        /// <summary>
        /// Convert pagination to a list
        /// </summary>
        /// <typeparam name="T">Type contained in each Page</typeparam>
        /// <param name="start">Starting page we want to covert from.</param>
        /// <param name="getNext">A function that returns the next page.</param>
        /// <returns></returns>
        public static IList<T> PageToList<T>(IPage<T> start, Func<string, IPage<T>> getNext) {
            List<T> result = new List<T>();
            MapOverIPage(start, getNext, (page) => {
                result.Add(page);
            });
            return result;
        }
    }
}

public static class Extensions
{
    /// <summary>
    /// Given a page we try to grab the first element we can find
    /// </summary>
    /// <typeparam name="T">The value that is held within the page.</typeparam>
    /// <param name="page">The page we wish to extract the object from</param>
    /// <returns></returns>
    public static T GetFirst<T>(this IPage<T> page) where T : class {
        T result = null;
        if (page != null)
        {
            foreach (var val in page)
            {
                result = val;
                break;
            }
        }
        return result;
    }


    /// <summary>
    /// Round down the dateTimeOffset to interval.
    /// </summary>
    /// <param name="dateTimeOffset">The date time offset.</param>
    /// <param name="interval">The interval.</param>
    public static DateTimeOffset Floor(this DateTimeOffset dateTimeOffset, TimeSpan interval) {
        return new DateTimeOffset(dateTimeOffset.UtcTicks - (dateTimeOffset.UtcTicks % interval.Ticks), TimeSpan.Zero);
    }

    public static DateTime Floor(this DateTime dateTime) {
        return dateTime.Floor(TimeSpan.FromDays(1));
    }

    public static DateTime Floor(this DateTime dateTime, TimeSpan interval) {
        return new DateTimeOffset(dateTime).Floor(interval).DateTime;
    }

}