// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace Azure.Data.Tables.Queryable
{
    internal static class WebConvert
    {
        private const string HexValues = "0123456789ABCDEF";

        internal static string ConvertByteArrayToKeyString(byte[] byteArray)
        {
            StringBuilder hexBuilder = new StringBuilder(3 + (byteArray.Length * 2));
            hexBuilder.Append(XmlConstants.XmlBinaryPrefix);
            hexBuilder.Append('\'');
            for (int i = 0; i < byteArray.Length; i++)
            {
                hexBuilder.Append(HexValues[byteArray[i] >> 4]);
                hexBuilder.Append(HexValues[byteArray[i] & 0x0F]);
            }

            hexBuilder.Append('\'');
            return hexBuilder.ToString();
        }

        internal static bool IsKeyTypeQuoted(Type type)
        {
            Debug.Assert(type != null, "type != null");
            return type == typeof(System.Xml.Linq.XElement) || type == typeof(string);
        }

        internal static bool TryKeyPrimitiveToString(object value, out string result)
        {
            Debug.Assert(value != null, "value != null");
            Type t = value.GetType();
            if (t == typeof(byte[]))
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
                if (t == typeof(DateTime))
                {
                    result = XmlConstants.LiteralPrefixDateTime + "'" + result + "'";
                }
                else if (t == typeof(decimal))
                {
                    result += XmlConstants.XmlDecimalLiteralSuffix;
                }
                else if (t == typeof(Guid))
                {
                    result = XmlConstants.LiteralPrefixGuid + "'" + result + "'";
                }
                else if (t == typeof(long))
                {
                    result += XmlConstants.XmlInt64LiteralSuffix;
                }
                else if (t == typeof(float))
                {
                    result += XmlConstants.XmlSingleLiteralSuffix;
                }
                else if (t == typeof(double))
                {
                    result = AppendDecimalMarkerToDouble(result);
                }
                else if (IsKeyTypeQuoted(t))
                {
                    result = "'" + result.Replace("'", "''") + "'";
                }
            }

            return true;
        }

        internal static bool TryXmlPrimitiveToString(object value, out string result)
        {
            Debug.Assert(value != null, "value != null");

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
            else if (ClientConvert.IsBinaryValue(value))
            {
                return ClientConvert.TryKeyBinaryToString(value, out result);
            }
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
    }
}
