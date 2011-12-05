//-----------------------------------------------------------------------
// <copyright file="ParseExtensions.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
//    Contains code for the ParseExtensions class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;

    /// <summary>
    /// A class to help with parsing.
    /// </summary>
    internal static class ParseExtensions
    {
        /// <summary>
        /// Converts a string to UTC time.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>A UTC representation of the string.</returns>
        internal static DateTime ToUTCTime(this string str)
        {
            return DateTime.Parse(
                str,
                System.Globalization.DateTimeFormatInfo.InvariantInfo,
                System.Globalization.DateTimeStyles.AdjustToUniversal);
        }
    }
}