//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// The class implements various validation methods.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Throws the appropriate exception if the argument is null.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="value">Value to check.</param>
        internal static void ArgumentIsNotNull(string argumentName, object value)
        {
            Debug.Assert(!string.IsNullOrEmpty(argumentName));

            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Throws the appropriate exception if the argument is null or empty string.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="value">Value to check.</param>
        internal static void ArgumentIsNotNullOrEmptyString(string argumentName, string value)
        {
            Debug.Assert(!string.IsNullOrEmpty(argumentName));

            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                string message = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorArgumentMustBeNonEmpty, argumentName);
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Throws the appropriate exception if the argument does not represent
        /// a valid path.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="value">Value to check.</param>
        internal static void ArgumentIsValidPath(string argumentName, string value)
        {
            Debug.Assert(!string.IsNullOrEmpty(argumentName));

            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                string message = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorArgumentMustBeNonEmpty, argumentName);
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Throws the appropriate exception if the argument does not represent
        /// a correct enum value.
        /// </summary>
        /// <typeparam name="T">Enumeration to validate against.</typeparam>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="value">Value to check.</param>
        internal static void ArgumentIsValidEnumValue<T>(string argumentName, object value) where T: struct
        {
            Debug.Assert(!string.IsNullOrEmpty(argumentName));
            Debug.Assert(value != null);

            if (!Enum.IsDefined(typeof(T), value))
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        /// Throws the appropriate exception if the argument does not represent
        /// a value which is greater than or equals to zero.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="value">Value to check.</param>
        internal static void ArgumentIsNonNegative(string argumentName, int value)
        {
            Debug.Assert(!string.IsNullOrEmpty(argumentName));

            if (value < 0)
            {
                string message = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorArgumentMustBeZeroOrPositive, argumentName, value);
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Throws the appropriate exception if the argument does not represent
        /// a positive value.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="value">Value to check.</param>
        internal static void ArgumentIsPositive(string argumentName, int value)
        {
            Debug.Assert(!string.IsNullOrEmpty(argumentName));

            if (value <= 0)
            {
                string message = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorArgumentMustBePositive, argumentName, value);
                throw new ArgumentException(message);
            }
        }
    }
}
