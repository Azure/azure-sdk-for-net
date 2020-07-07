// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Class containing helper methods for path binding
    /// </summary>
    internal static class BindingDataPathHelper
    {
        /// <summary>
        /// Convert a parameter value of supported type into path compatible string value.
        /// The set of supported types is limited to built-in signed/unsigned integer types, 
        /// strings, JToken, and Guid (which is translated in canonical form without curly braces).
        /// </summary>
        /// <param name="parameterValue">The parameter value to convert</param>
        /// <param name="format">Optional format string</param>
        /// <returns>Path compatible string representation of the given parameter or null if its type is not supported.</returns>
        public static string ConvertParameterValueToString(object parameterValue, string format = null)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = null; // normalize. 
            }
            if (parameterValue != null)
            {
                switch (Type.GetTypeCode(parameterValue.GetType()))
                {
                    case TypeCode.String:
                        return (string)parameterValue;
                    case TypeCode.Int16:
                        return ((Int16)parameterValue).ToString(CultureInfo.InvariantCulture);
                    case TypeCode.Int32:
                        return ((Int32)parameterValue).ToString(CultureInfo.InvariantCulture);
                    case TypeCode.Int64:
                        return ((Int64)parameterValue).ToString(CultureInfo.InvariantCulture);
                    case TypeCode.UInt16:
                        return ((UInt16)parameterValue).ToString(CultureInfo.InvariantCulture);
                    case TypeCode.UInt32:
                        return ((UInt32)parameterValue).ToString(CultureInfo.InvariantCulture);
                    case TypeCode.UInt64:
                        return ((UInt64)parameterValue).ToString(CultureInfo.InvariantCulture);
                    case TypeCode.Char:
                        return ((Char)parameterValue).ToString(CultureInfo.InvariantCulture);
                    case TypeCode.Byte:
                        return ((Byte)parameterValue).ToString(CultureInfo.InvariantCulture);
                    case TypeCode.SByte:
                        return ((SByte)parameterValue).ToString(CultureInfo.InvariantCulture);
                    case TypeCode.DateTime:                        
                        format = format ?? "yyyy-MM-ddTHH-mm-ssK"; // default to ISO 8601
                        var dateTime = (DateTime)parameterValue;
                        return dateTime.ToString(format, CultureInfo.InvariantCulture);
                    case TypeCode.Object:
                        if (parameterValue is Guid)
                        {
                            if (format == null)
                            {
                                return parameterValue.ToString();
                            }
                            else
                            {
                                return ((Guid)parameterValue).ToString(format, CultureInfo.InvariantCulture);
                            }
                        }
                        if (parameterValue is Newtonsoft.Json.Linq.JToken)
                        {
                            // Only accept primitive Json values. Don't accept complex objects. 
                            if (!(parameterValue is JContainer))
                            {
                                return parameterValue.ToString();
                            }
                        }
                        return null;
                }
            }

            return null;
        }
    }
}
