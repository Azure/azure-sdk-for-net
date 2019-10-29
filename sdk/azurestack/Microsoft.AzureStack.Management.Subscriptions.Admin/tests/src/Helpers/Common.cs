// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Subscriptions.Tests
{

    /// <summary>
    /// A collection of common values and functions
    /// </summary>
    public class Common
    {

        public const string AcceptableCharactersForResourceName = "abcdefghijklmnopqrstuvwxyz0123456789";
        public const int MaxResourceNameLength = 24;

        // This is just for code readability
        public const int Milliseconds = 1;
        public const int Seconds = 1000 * Milliseconds;
        public const int Minutes = 60 * Seconds;
        public const int Hours = 60 * Minutes;

        /// <summary>
        /// Allows tests to retrieve content from Azure Stack directly.
        /// </summary>
        /// <param name="client">The client used to connect.</param>
        /// <param name="creds">Credentials used to connect.</param>
        /// <param name="uri">The location of the object.</param>
        /// <returns>Body of the request.</returns>
        ///
        public static string RetrieveObject(HttpClient client, ServiceClientCredentials creds, string uri) {
            return RetrieveObject(client, creds, new Uri(uri));
        }


        /// <summary>
        /// Allows tests to retrieve content from Azure Stack directly.
        /// </summary>
        /// <param name="client">The client used to connect.</param>
        /// <param name="creds">Credentials used to connect.</param>
        /// <param name="uri">The location of the object.</param>
        /// <returns>Body of the request.</returns>
        public static string RetrieveObject(HttpClient client, ServiceClientCredentials creds, Uri uri) {
            var message = new HttpRequestMessage(HttpMethod.Get, uri);
            creds.ProcessHttpRequestAsync(message, System.Threading.CancellationToken.None);
            var result = client.SendAsync(message).Result;
            return result.Content.ToString();
        }

        /// <summary>
        /// Generate a random name that can be ingested by Azure or AzureStack.
        /// </summary>
        /// <param name="prefix">The prefix added to the string.  The default is okaytodelete.</param>
        /// <returns>The generated string.</returns>
        public static string GenerateRandomName(string prefix = "okaytodelete", bool useGuid = true) {
            StringBuilder sb = new StringBuilder(prefix);
            if (useGuid)
            {
                sb.Append(Guid.NewGuid());
            }
            else
            {
                Random rand = new Random();
                for (int i = 0; sb.Length < MaxResourceNameLength; ++i)
                {
                    sb.Append(AcceptableCharactersForResourceName[rand.Next(AcceptableCharactersForResourceName.Length)]);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Given an operation retry it either some given number of times or until it succeeds
        /// </summary>
        /// <param name="func">Function which returns true if it succeeds, false otherwise</param>
        /// <param name="retries">Maximum number of retries</param>
        /// <param name="delay">Delay between retries</param>
        public static bool RetryOperation(Func<bool> func, uint retries = 10, int delay = 250 * Common.Milliseconds) {
            while (retries > 0)
            {
                if (func())
                {
                    break;
                }
                --retries;
                System.Threading.Thread.Sleep(delay);
            }
            return retries >= 0;
        }

        /// <summary>
        ///     Given an operation retry it either some given number of times or until an exception is thrown.
        /// </summary>
        /// <param name="act">The action we want to perform.</param>
        /// <param name="retries">Maximum number of retries</param>
        /// <param name="delay">Delay between retries</param>
        /// <returns>True if an exception is thrown, false if we reach our retry limit.</returns>
        public static bool RetryExceptionExpected(Action act, uint retries = 10, int delay = 250 * Common.Milliseconds) {
            Func<bool> func = () => { try { act(); return false; } catch { } return true; };
            return RetryOperation(func, retries, delay);
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
                curr.ForEach(action);

                if (string.IsNullOrEmpty(curr.NextPageLink))
                {
                    break;
                }

                curr = getNext(curr.NextPageLink);
            }
        }

        /// <summary>
        /// Write IPages to a given file from a starting IPage.
        /// </summary>
        /// <typeparam name="T">The type of object each IPage holds.</typeparam>  
        /// <param name="start">The starting IPage.</param>
        /// <param name="getNext">Given a valid URI returns the next IPage.</param>
        /// <param name="filename">The name of the file.</param>
        /// <param name="toString">Returns a string representation of object of type T.</param>
        ///
        public static void WriteIPagesToFile<T>(IPage<T> start, Func<string, IPage<T>> getNext, System.String filename, Func<T, string> toString = null) {
            using (System.IO.FileStream stream = System.IO.File.Create(filename))
            {
                WriteIPagesToStream(start, getNext, stream, toString);
            }
        }

        /// <summary>
        /// Write all element in an enumerable to a file on their own line.
        /// </summary>
        /// <typeparam name="T">Type held in Enumerable.</typeparam>
        /// <param name="iter">Input IEnumerable.</param>
        /// <param name="filename">The name of the file.</param>
        /// <param name="toString">Returns a string representation of object of type T.  Default action is to call ToString.</param>
        public static void WriteIEnumerableToFile<T>(IEnumerable<T> iter, System.String filename, Func<T, string> toString = null) {
            using (System.IO.FileStream stream = System.IO.File.Create(filename))
            {
                WriteIEnumerableToStream(iter, stream, toString);
            }
        }

        /// <summary>
        /// Write all IPage 
        /// </summary>
        /// <typeparam name="T">Type held in each page.</typeparam>
        /// <param name="start">Starting page.</param>
        /// <param name="getNext">Given a valid URI returns the next IPage.</param>
        /// <param name="stream">The stream written to.</param>
        /// <param name="toString">Returns a string representation of object of type T.  Default action is to call ToString.</param>
        public static void WriteIPagesToStream<T>(IPage<T> start, Func<string, IPage<T>> getNext, System.IO.Stream stream, Func<T, string> toString = null) {
            toString = toString ?? delegate (T t) { return t.ToString(); };
            StringBuilder sb = new StringBuilder();
            Action<T> action = (obj) => { sb.Append(toString(obj)); sb.AppendLine(); };
            MapOverIPage<T>(start, getNext, action);
            var str = sb.ToString();
            var bytes = Encoding.ASCII.GetBytes(sb.ToString());
            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Iterate through each item in the pages and write its string representation to a file.
        /// The default action to get a string representation is to call toString on each object.
        /// </summary>
        /// <typeparam name="T">Type held in Enumerable.</typeparam>
        /// <param name="iter">Input IEnumerable.</param>
        /// <param name="stream">The stream written to.</param>
        /// <param name="toString">Returns a string representation of object of type T.  Default action is to call ToString.</param>
        public static void WriteIEnumerableToStream<T>(IEnumerable<T> iter, System.IO.Stream stream, Func<T, string> toString = null) {
            toString = toString ?? delegate (T t) { return t.ToString(); };
            StringBuilder sb = new StringBuilder();
            Action<T> action = (obj) => { sb.Append(toString(obj)); sb.AppendLine(); };
            iter.ForEach(action);
            var bytes = Encoding.ASCII.GetBytes(sb.ToString());
            stream.Write(bytes, 0, bytes.Length);
        }

        public static string GetResourceGroupFromId(string id) {
            string result = null;
            var split = id.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < split.Length - 1; ++i) { 
                if(split[i].Equals("resourceGroups", StringComparison.OrdinalIgnoreCase))
                {
                    result = split[i + 1];
                    break;
                }
            }
            return result;
        }

    }
}

public static class Extensions
{

    /// <summary>
    /// Round down the dateTimeOffset to interval.
    /// </summary>
    /// <param name="dateTimeOffset">The date time offset.</param>
    /// <param name="interval">The interval.</param>
    public static DateTimeOffset Floor(this DateTimeOffset dateTimeOffset, TimeSpan interval) {
        return new DateTimeOffset(dateTimeOffset.UtcTicks - (dateTimeOffset.UtcTicks % interval.Ticks), TimeSpan.Zero);
    }

    /// <summary>
    /// Round down to the day.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    public static DateTime Floor(this DateTime dateTime) {
        return dateTime.Floor(TimeSpan.FromDays(1));
    }

    /// <summary>
    /// Round down the DateTime to interval.
    /// </summary>
    /// <param name="dateTime">The date.</param>
    /// <param name="interval">The interval.</param>
    public static DateTime Floor(this DateTime dateTime, TimeSpan interval) {
        return new DateTimeOffset(dateTime).Floor(interval).DateTime;
    }


    /// <summary>
    /// Apply an operation over an IList object
    /// </summary>
    /// <typeparam name="T">Underlying type stored in IEnumerable.</typeparam>
    /// <param name="list">IEnumerable to apply operation to.</param>
    /// <param name="action">The action performed.</param>
    public static void ForEach<T>(this IEnumerable<T> list, Action<T> action = default(Action<T>)) {
        foreach (var item in list)
        {
            action(item);
        }
    }

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
            foreach (var r in page)
            {
                result = r;
                break;
            }
        }
        return result;
    }

    /// <summary>
    /// Convert pagination to a list
    /// </summary>
    /// <typeparam name="T">Type contained in each Page</typeparam>
    /// <param name="start">Starting page we want to covert from.</param>
    /// <param name="getNext">A function that returns the next page.</param>
    /// <returns></returns>
    public static IList<T> PageToList<T>(this IPage<T> start, Func<string, IPage<T>> getNext) {
        List<T> result = new List<T>();
        Subscriptions.Tests.Common.MapOverIPage(start, getNext, (page) => {
            result.Add(page);
        });
        return result;
    }

    public static void ForEach<T>(this IPage<T> page, Func<string,IPage<T>> next, Action<T> action ) {
        Subscriptions.Tests.Common.MapOverIPage(page, next, action);
    }

}