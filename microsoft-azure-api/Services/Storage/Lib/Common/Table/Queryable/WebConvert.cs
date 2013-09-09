// -----------------------------------------------------------------------------------------
// <copyright file="WebConvert.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table.Queryable
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Xml;
#if ASTORIA_CLIENT
    using System.Data.Services.Client;
#else
    using System.Globalization;
#endif

    internal static class WebConvert
    {
        private const string HexValues = "0123456789ABCDEF";

        private const string XmlHexEncodePrefix = "0x";

#if ASTORIA_SERVER
        private static char[] XmlWhitespaceChars = new char[] { ' ', '\t', '\n', '\r' };

        internal static bool IsCharHexDigit(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
        }

#endif

        internal static string ConvertByteArrayToKeyString(byte[] byteArray)
        {
            StringBuilder hexBuilder = new StringBuilder(3 + (byteArray.Length * 2));
            hexBuilder.Append(XmlConstants.XmlBinaryPrefix);
            hexBuilder.Append("'");
            for (int i = 0; i < byteArray.Length; i++)
            {
                hexBuilder.Append(HexValues[byteArray[i] >> 4]);
                hexBuilder.Append(HexValues[byteArray[i] & 0x0F]);
            }

            hexBuilder.Append("'");
            return hexBuilder.ToString();
        }

#if ASTORIA_SERVER

        internal static bool IsKeyValueQuoted(string text)
        {
            Debug.Assert(text != null, "text != null");
            if (text.Length < 2 || text[0] != '\'' || text[text.Length - 1] != '\'')
            {
                return false;
            }
            else
            {
                int startIndex = 1;
                while (startIndex < text.Length - 1)
                {
                    int match = text.IndexOf('\'', startIndex, text.Length - startIndex - 1);
                    if (match == -1)
                    {
                        break;
                    }
                    else if (match == text.Length - 2 || text[match + 1] != '\'')
                    {
                        return false;
                    }
                    else
                    {
                        startIndex = match + 2;
                    }
                }

                return true;
            }
        }

#endif

        internal static bool IsKeyTypeQuoted(Type type)
        {
            Debug.Assert(type != null, "type != null");
            return type == typeof(System.Xml.Linq.XElement) || type == typeof(string);
        }

        internal static bool TryKeyPrimitiveToString(object value, out string result)
        {
            Debug.Assert(value != null, "value != null");
            if (value.GetType() == typeof(byte[]))
            {
                result = ConvertByteArrayToKeyString((byte[])value);
            }
            else
            {
                if (!TryXmlPrimitiveToString(value, out result))
                {
                    return false;
                }

                Debug.Assert(result != null, "result != null");
                if (value.GetType() == typeof(DateTime))
                {
                    result = XmlConstants.LiteralPrefixDateTime + "'" + result + "'";
                }
                else if (value.GetType() == typeof(decimal))
                {
                    result = result + XmlConstants.XmlDecimalLiteralSuffix;
                }
                else if (value.GetType() == typeof(Guid))
                {
                    result = XmlConstants.LiteralPrefixGuid + "'" + result + "'";
                }
                else if (value.GetType() == typeof(long))
                {
                    result = result + XmlConstants.XmlInt64LiteralSuffix;
                }
                else if (value.GetType() == typeof(float))
                {
                    result = result + XmlConstants.XmlSingleLiteralSuffix;
                }
#if ASTORIA_SERVER
                else if (value.GetType() == typeof(double))
                {
                    double d = (double)value;
                    if (!Double.IsInfinity(d) && !Double.IsNaN(d))
                    {
                        result = result + XmlConstants.XmlDoubleLiteralSuffix;
                    }
                }
#else
                else if (value.GetType() == typeof(double))
                {
                    result = AppendDecimalMarkerToDouble(result);
                }
#endif
                else if (IsKeyTypeQuoted(value.GetType()))
                {
                    result = "'" + result.Replace("'", "''") + "'";
                }
            }

            return true;
        }

#if ASTORIA_SERVER
        internal static string RemoveQuotes(string text)
        {
            Debug.Assert(!String.IsNullOrEmpty(text), "!String.IsNullOrEmpty(text)");

            char quote = text[0];
            Debug.Assert(quote == '\'', "quote == '\''");
            Debug.Assert(text[text.Length - 1] == '\'', "text should end with '\''.");

            string s = text.Substring(1, text.Length - 2);
            int start = 0;
            while (true)
            {
                int i = s.IndexOf(quote, start);
                if (i < 0)
                {
                    break;
                }

                Debug.Assert(i + 1 < s.Length && s[i + 1] == '\'', @"Each single quote should be propertly escaped with double single quotes.");
                s = s.Remove(i, 1);
                start = i + 1;
            }

            return s;
        }

        internal static bool TryKeyStringToByteArray(string text, out byte[] targetValue)
        {
            Debug.Assert(text != null, "text != null");

            if (!TryRemoveLiteralPrefix(XmlConstants.LiteralPrefixBinary, ref text) &&
                !TryRemoveLiteralPrefix(XmlConstants.XmlBinaryPrefix, ref text))
            {
                targetValue = null;
                return false;
            }

            if (!TryRemoveQuotes(ref text))
            {
                targetValue = null;
                return false;
            }

            if ((text.Length % 2) != 0)
            {
                targetValue = null;
                return false;
            }

            byte[] result = new byte[text.Length / 2];
            int resultIndex = 0;
            int textIndex = 0;
            while (resultIndex < result.Length)
            {
                char ch0 = text[textIndex];
                char ch1 = text[textIndex + 1];
                if (!IsCharHexDigit(ch0) || !IsCharHexDigit(ch1))
                {
                    targetValue = null;
                    return false;
                }

                result[resultIndex] = (byte)((byte)(HexCharToNibble(ch0) << 4) + HexCharToNibble(ch1));
                textIndex += 2;
                resultIndex++;
            }

            targetValue = result;
            return true;
        }

        internal static bool TryKeyStringToDateTime(string text, out DateTime targetValue)
        {
            if (!TryRemoveLiteralPrefix(XmlConstants.LiteralPrefixDateTime, ref text))
            {
                targetValue = default(DateTime);
                return false;
            }

            if (!TryRemoveQuotes(ref text))
            {
                targetValue = default(DateTime);
                return false;
            }

            try
            {
                targetValue = XmlConvert.ToDateTime(text, XmlDateTimeSerializationMode.RoundtripKind);
                return true;
            }
            catch (FormatException)
            {
                targetValue = default(DateTime);
                return false;
            }
        }

        internal static bool TryKeyStringToGuid(string text, out Guid targetValue)
        {
            if (!TryRemoveLiteralPrefix(XmlConstants.LiteralPrefixGuid, ref text))
            {
                targetValue = default(Guid);
                return false;
            }

            if (!TryRemoveQuotes(ref text))
            {
                targetValue = default(Guid);
                return false;
            }

            try
            {
                targetValue = XmlConvert.ToGuid(text);
                return true;
            }
            catch (FormatException)
            {
                targetValue = default(Guid);
                return false;
            }
        }

        internal static bool TryKeyStringToPrimitive(string text, Type targetType, out object targetValue)
        {
            Debug.Assert(text != null, "text != null");
            Debug.Assert(targetType != null, "targetType != null");

            targetType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            byte[] byteArrayValue;
            bool binaryResult = TryKeyStringToByteArray(text, out byteArrayValue);
            if (targetType == typeof(byte[]) || targetType == typeof(System.Data.Linq.Binary))
            {
                targetValue =
                    (byteArrayValue != null && targetType == typeof(System.Data.Linq.Binary)) ?
                    (object)new System.Data.Linq.Binary(byteArrayValue) : (object)byteArrayValue;
                return binaryResult;
            }
            else if (binaryResult)
            {
                string keyValue = Encoding.UTF8.GetString(byteArrayValue);
                return TryKeyStringToPrimitive(keyValue, targetType, out targetValue);
            }
            else if (targetType == typeof(Guid))
            {
                Guid guidValue;
                bool result = TryKeyStringToGuid(text, out guidValue);
                targetValue = guidValue;
                return result;
            }
            else if (targetType == typeof(DateTime))
            {
                DateTime dateTimeValue;
                bool result = TryKeyStringToDateTime(text, out dateTimeValue);
                targetValue = dateTimeValue;
                return result;
            }

            bool quoted = WebConvert.IsKeyTypeQuoted(targetType);
            if (quoted != WebConvert.IsKeyValueQuoted(text))
            {
                targetValue = null;
                return false;
            }

            if (quoted)
            {
                Debug.Assert(IsKeyValueQuoted(text), "IsKeyValueQuoted(text) - otherwise caller didn't check this before");
                text = RemoveQuotes(text);
            }

            try
            {
                if (typeof(String) == targetType)
                {
                    targetValue = text;
                }
                else if (typeof(Boolean) == targetType)
                {
                    targetValue = XmlConvert.ToBoolean(text);
                }
                else if (typeof(Byte) == targetType)
                {
                    targetValue = XmlConvert.ToByte(text);
                }
                else if (typeof(SByte) == targetType)
                {
                    targetValue = XmlConvert.ToSByte(text);
                }
                else if (typeof(Int16) == targetType)
                {
                    targetValue = XmlConvert.ToInt16(text);
                }
                else if (typeof(Int32) == targetType)
                {
                    targetValue = XmlConvert.ToInt32(text);
                }
                else if (typeof(Int64) == targetType)
                {
                    if (TryRemoveLiteralSuffix(XmlConstants.XmlInt64LiteralSuffix, ref text))
                    {
                        targetValue = XmlConvert.ToInt64(text);
                    }
                    else
                    {
                        targetValue = default(Int64);
                        return false;
                    }
                }
                else if (typeof(Single) == targetType)
                {
                    if (TryRemoveLiteralSuffix(XmlConstants.XmlSingleLiteralSuffix, ref text))
                    {
                        targetValue = XmlConvert.ToSingle(text);
                    }
                    else
                    {
                        targetValue = default(Single);
                        return false;
                    }
                }
                else if (typeof(Double) == targetType)
                {
                    TryRemoveLiteralSuffix(XmlConstants.XmlDoubleLiteralSuffix, ref text);
                    targetValue = XmlConvert.ToDouble(text);
                }
                else if (typeof(Decimal) == targetType)
                {
                    if (TryRemoveLiteralSuffix(XmlConstants.XmlDecimalLiteralSuffix, ref text))
                    {
                        try
                        {
                            targetValue = XmlConvert.ToDecimal(text);
                        }
                        catch (FormatException)
                        {
                            decimal result;
                            if (Decimal.TryParse(text, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out result))
                            {
                                targetValue = result;
                            }
                            else
                            {
                                targetValue = default(Decimal);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        targetValue = default(Decimal);
                        return false;
                    }
                }
                else
                {
                    Debug.Assert(typeof(System.Xml.Linq.XElement) == targetType, "XElement == " + targetType);
                    targetValue = System.Xml.Linq.XElement.Parse(text, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                }

                return true;
            }
            catch (FormatException)
            {
                targetValue = null;
                return false;
            }
        }

        internal static object StringToPrimitive(string text, Type targetType)
        {
            Debug.Assert(text != null, "text != null");
            Debug.Assert(targetType != null, "targetType != null");

            object targetValue = null;
            targetType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (typeof(String) == targetType)
            {
                targetValue = text;
            }
            else if (typeof(Boolean) == targetType)
            {
                targetValue = XmlConvert.ToBoolean(text);
            }
            else if (typeof(Byte) == targetType)
            {
                targetValue = XmlConvert.ToByte(text);
            }
            else if (typeof(byte[]) == targetType)
            {
                targetValue = Convert.FromBase64String(text);
            }
            else if (typeof(System.Data.Linq.Binary) == targetType)
            {
                targetValue = new System.Data.Linq.Binary(Convert.FromBase64String(text));
            }
            else if (typeof(SByte) == targetType)
            {
                targetValue = XmlConvert.ToSByte(text);
            }
            else if (typeof(DateTime) == targetType)
            {
                targetValue = XmlConvert.ToDateTime(text, XmlDateTimeSerializationMode.RoundtripKind);
            }
            else if (typeof(Decimal) == targetType)
            {
                targetValue = XmlConvert.ToDecimal(text);
            }
            else if (typeof(Double) == targetType)
            {
                targetValue = XmlConvert.ToDouble(text);
            }
            else if (typeof(Guid) == targetType)
            {
                targetValue = new Guid(text);
            }
            else if (typeof(Int16) == targetType)
            {
                targetValue = XmlConvert.ToInt16(text);
            }
            else if (typeof(Int32) == targetType)
            {
                targetValue = XmlConvert.ToInt32(text);
            }
            else if (typeof(Int64) == targetType)
            {
                targetValue = XmlConvert.ToInt64(text);
            }
            else if (typeof(System.Xml.Linq.XElement) == targetType)
            {
                targetValue = System.Xml.Linq.XElement.Parse(text, System.Xml.Linq.LoadOptions.PreserveWhitespace);
            }
            else
            {
                Debug.Assert(typeof(Single) == targetType, "typeof(Single) == targetType(" + targetType + ")");
                targetValue = XmlConvert.ToSingle(text);
            }

            return targetValue;
        }

        internal static bool TryRemoveQuotes(ref string text)
        {
            if (text.Length < 2)
            {
                return false;
            }

            char quote = text[0];
            if (quote != '\'' || text[text.Length - 1] != quote)
            {
                return false;
            }

            string s = text.Substring(1, text.Length - 2);
            int start = 0;
            while (true)
            {
                int i = s.IndexOf(quote, start);
                if (i < 0)
                {
                    break;
                }

                s = s.Remove(i, 1);
                if (s.Length < i + 1 || s[i] != quote)
                {
                    return false;
                }

                start = i + 1;
            }

            text = s;
            return true;
        }
#endif

        internal static bool TryXmlPrimitiveToString(object value, out string result)
        {
            Debug.Assert(value != null, "value != null");
            result = null;

            Type valueType = value.GetType();
            valueType = Nullable.GetUnderlyingType(valueType) ?? valueType;

            if (typeof(string) == valueType)
            {
                result = (string)value;
            }
            else if (typeof(bool) == valueType)
            {
                result = XmlConvert.ToString((bool)value);
            }
            else if (typeof(byte) == valueType)
            {
                result = XmlConvert.ToString((byte)value);
            }
            else if (typeof(DateTime) == valueType)
            {
                result = XmlConvert.ToString((DateTime)value, XmlDateTimeSerializationMode.RoundtripKind);
            }
            else if (typeof(decimal) == valueType)
            {
                result = XmlConvert.ToString((decimal)value);
            }
            else if (typeof(double) == valueType)
            {
                result = XmlConvert.ToString((double)value);
            }
            else if (typeof(Guid) == valueType)
            {
                result = value.ToString();
            }
            else if (typeof(short) == valueType)
            {
                result = XmlConvert.ToString((short)value);
            }
            else if (typeof(int) == valueType)
            {
                result = XmlConvert.ToString((int)value);
            }
            else if (typeof(long) == valueType)
            {
                result = XmlConvert.ToString((long)value);
            }
            else if (typeof(sbyte) == valueType)
            {
                result = XmlConvert.ToString((sbyte)value);
            }
            else if (typeof(float) == valueType)
            {
                result = XmlConvert.ToString((float)value);
            }
            else if (typeof(byte[]) == valueType)
            {
                byte[] byteArray = (byte[])value;
                result = Convert.ToBase64String(byteArray);
            }
#if ASTORIA_SERVER
            else if (typeof(System.Data.Linq.Binary) == valueType)
            {
                return TryXmlPrimitiveToString(((System.Data.Linq.Binary)value).ToArray(), out result);
            }
#else
#if !ASTORIA_LIGHT
            else if (ClientConvert.IsBinaryValue(value))
            {
                return ClientConvert.TryKeyBinaryToString(value, out result);
            }
#endif
#endif
            else if (typeof(System.Xml.Linq.XElement) == valueType)
            {
                result = ((System.Xml.Linq.XElement)value).ToString(System.Xml.Linq.SaveOptions.None);
            }
            else
            {
                result = null;
                return false;
            }

            Debug.Assert(result != null, "result != null");
            return true;
        }

#if ASTORIA_SERVER
        private static byte HexCharToNibble(char c)
        {
            Debug.Assert(IsCharHexDigit(c));
            switch (c)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'a':
                case 'A':
                    return 10;
                case 'b':
                case 'B':
                    return 11;
                case 'c':
                case 'C':
                    return 12;
                case 'd':
                case 'D':
                    return 13;
                case 'e':
                case 'E':
                    return 14;
                case 'f':
                case 'F':
                    return 15;
                default:
                    throw new InvalidOperationException();
            }
        }

        private static bool TryRemoveLiteralSuffix(string suffix, ref string text)
        {
            Debug.Assert(text != null, "text != null");
            Debug.Assert(suffix != null, "suffix != null");

            text = text.Trim(XmlWhitespaceChars);
            if (text.Length <= suffix.Length || !text.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                text = text.Substring(0, text.Length - suffix.Length);
                return true;
            }
        }

        private static bool TryRemoveLiteralPrefix(string prefix, ref string text)
        {
            Debug.Assert(prefix != null, "prefix != null");
            if (text.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                text = text.Remove(0, prefix.Length);
                return true;
            }
            else
            {
                return false;
            }
        }
#else
        private static string AppendDecimalMarkerToDouble(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return input;
                }
            }

            return input + ".0";
        }
#endif
    }
}
