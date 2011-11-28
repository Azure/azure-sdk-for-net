//-----------------------------------------------------------------------
// <copyright file="ParseExtensions.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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