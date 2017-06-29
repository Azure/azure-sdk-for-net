// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Text;

namespace TestCommon
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

        /// <summary>
        /// Generate a random name that can be ingested by Azure or AzureStack
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string GenerateRandomName(string prefix = "okaytodelete", bool useGuid = true)
        {
            StringBuilder sb = new StringBuilder(prefix);
            if (useGuid) {
                sb.Append(Guid.NewGuid());
            } else {
                const string acceptableCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";
                const int maxLength = 24;

                Random rand = new Random();
                
                for(int i = 0; sb.Length < maxLength; ++i) {
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
        public static uint CountElements(IEnumerable iter)
        {
            if (iter == null) return 0;
            uint count = 0;
            foreach(var item in iter) {
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
        public static uint CountElementsInPages<T>(IPage<T> page, Func<string, IPage<T>> next)
        {
            uint count = 0;

            while(page != null) {
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
        public static void RetryOperation(Func<bool> func, uint retries = 10, int delay = 250 * Common.Milliseconds)
        {
            while (retries > 0) {
                if (func()) {
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
        public static Func<bool> RetryExceptionExpected(Action act)
        {
            return () => {
                try {
                    act();
                } catch {
                    return true;
                }
                return false;
            };
        }
    }
}
