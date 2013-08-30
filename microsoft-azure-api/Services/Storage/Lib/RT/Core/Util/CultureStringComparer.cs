// -----------------------------------------------------------------------------------------
// <copyright file="CultureStringComparer.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Represents a string comparison operation that uses specific case and culture-based rules.
    /// </summary>
    internal class CultureStringComparer : StringComparer
    {
        private CultureInfo cultureInfo;
        private CompareOptions compareOptions;

        /// <summary>
        /// Creates a CultureStringComparer object that compares strings according to the rules of a specified culture.
        /// </summary>
        /// <param name="culture">A culture whose linguistic rules are used to perform a string comparison.</param>
        /// <param name="ignoreCase"><c>true</c> to specify that comparison operations be case-insensitive; <c>false</c> to specify that comparison operations be case-sensitive.</param>
        public CultureStringComparer(CultureInfo culture, bool ignoreCase)
            : base()
        {
            this.cultureInfo = culture;
            this.compareOptions = ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None;
        }

        /// <summary>
        /// Compares two strings and returns an indication of their relative sort order.
        /// </summary>
        /// <param name="x">A string to compare to y.</param>
        /// <param name="y">A string to compare to x.</param>
        /// <returns>A signed integer that indicates the relative values of x and y.</returns>
        public override int Compare(string x, string y)
        {
            return this.cultureInfo.CompareInfo.Compare(x, y, this.compareOptions);
        }

        /// <summary>
        /// Indicates whether two strings are equal.
        /// </summary>
        /// <param name="x">A string to compare to y.</param>
        /// <param name="y">A string to compare to x.</param>
        /// <returns><c>true</c> if x and y refer to the same object, or x and y are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(string x, string y)
        {
            return this.Compare(x, y) == 0;
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">An object.</param>
        /// <returns>A 32-bit signed hash code calculated from the value of the parameter.</returns>
        public override int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
