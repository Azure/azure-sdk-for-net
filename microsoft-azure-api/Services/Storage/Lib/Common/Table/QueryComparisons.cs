// -----------------------------------------------------------------------------------------
// <copyright file="QueryComparisons.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines the set of comparison operators that may be used for constructing queries.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Due to Javascript projection limitations.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1303:ConstFieldNamesMustBeginWithUpperCaseLetter", Justification = "Due to Javascript projection limitations..")]
    public static class QueryComparisons
    {
#if WINDOWS_RT
        internal const string equal = "eq";
        internal const string notEqual = "ne";
        internal const string greaterThan = "gt";
        internal const string greaterThanOrEqual = "ge";
        internal const string lessThan = "lt";
        internal const string lessThanOrEqual = "le";

        public static string Equal
        {
            get { return equal; }
        }

        public static string NotEqual
        {
            get { return notEqual; }
        }

        public static string GreaterThan
        {
            get { return greaterThan; }
        }

        public static string GreaterThanOrEqual
        {
            get { return greaterThanOrEqual; }
        }

        public static string LessThan
        {
            get { return lessThan; }
        }

        public static string LessThanOrEqual
        {
            get { return lessThanOrEqual; }
        }
#else
        /// <summary>
        /// Represents the Equal operator.
        /// </summary>
        public const string Equal = "eq";

        /// <summary>
        /// Represents the Not Equal operator.
        /// </summary>
        public const string NotEqual = "ne";

        /// <summary>
        /// Represents the Greater Than operator.
        /// </summary>
        public const string GreaterThan = "gt";

        /// <summary>
        /// Represents the Greater Than or Equal operator.
        /// </summary>
        public const string GreaterThanOrEqual = "ge";

        /// <summary>
        /// Represents the Less Than operator.
        /// </summary>
        public const string LessThan = "lt";

        /// <summary>
        /// Represents the Less Than or Equal operator.
        /// </summary>
        public const string LessThanOrEqual = "le";
#endif
    }
}
