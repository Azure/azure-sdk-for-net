// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace Azure.Data.Tables.Queryable
{
    internal static class ClientConvert
    {
        private const string SystemDataLinq = "System.Data.Linq, Version=" + FXAssembly.Version + ", Culture=neutral, PublicKeyToken=" + AssemblyRef.EcmaPublicKeyToken;

        private static readonly Type[] KnownTypes = CreateKnownPrimitives();

        private static readonly Dictionary<string, Type> NamedTypesMap = CreateKnownNamesMap();

        private static bool needSystemDataLinqBinary = true;

        internal enum StorageType
        {
            Boolean,
            Byte,
            ByteArray,
            Char,
            CharArray,
            DateTime,
            DateTimeOffset,
            Decimal,
            Double,
            Guid,
            Int16,
            Int32,
            Int64,
            Single,
            String,
            SByte,
            TimeSpan,
            Type,
            UInt16,
            UInt32,
            UInt64,
            Uri,
            XDocument,
            XElement,
            Binary,
        }

        internal static bool IsBinaryValue(object value)
        {
            return StorageType.Binary == (StorageType)IndexOfStorage(value.GetType());
        }

        internal static bool TryKeyBinaryToString(object binaryValue, out string result)
        {
            const System.Reflection.BindingFlags Flags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod;
            byte[] bytes = (byte[])binaryValue.GetType().InvokeMember("ToArray", Flags, null, binaryValue, null, null /* ParamModifiers */, System.Globalization.CultureInfo.InvariantCulture, null /* NamedParams */);
            return WebConvert.TryKeyPrimitiveToString(bytes, out result);
        }

        internal static bool TryKeyPrimitiveToString(object value, out string result)
        {
            if (IsBinaryValue(value))
            {
                return TryKeyBinaryToString(value, out result);
            }
            // Support DateTimeOffset
            if (value is DateTimeOffset)
            {
                value = ((DateTimeOffset)value).UtcDateTime;
            }
            else if (value is DateTimeOffset?)
            {
                value = ((DateTimeOffset?)value).Value.UtcDateTime;
            }

            return WebConvert.TryKeyPrimitiveToString(value, out result);
        }

        internal static string ToTypeName(Type type)
        {
            foreach (var pair in ClientConvert.NamedTypesMap)
            {
                if (pair.Value == type)
                {
                    return pair.Key;
                }
            }

            return type.FullName;
        }

        internal static string ToString(object propertyValue, bool atomDateConstruct)
        {
            switch ((StorageType)IndexOfStorage(propertyValue.GetType()))
            {
                case StorageType.Boolean:
                    return XmlConvert.ToString((bool)propertyValue);
                case StorageType.Byte:
                    return XmlConvert.ToString((byte)propertyValue);
                case StorageType.ByteArray:
                    return Convert.ToBase64String((byte[])propertyValue);
                case StorageType.Char:
                    return XmlConvert.ToString((char)propertyValue);
                case StorageType.CharArray:
                    return new string((char[])propertyValue);
                case StorageType.DateTime:
                    DateTime dt = (DateTime)propertyValue;
                    return XmlConvert.ToString(dt.Kind == DateTimeKind.Unspecified && atomDateConstruct ? new DateTime(dt.Ticks, DateTimeKind.Utc) : dt, XmlDateTimeSerializationMode.RoundtripKind);
                case StorageType.DateTimeOffset:
                    return XmlConvert.ToString((DateTimeOffset)propertyValue);
                case StorageType.Decimal:
                    return XmlConvert.ToString((decimal)propertyValue);
                case StorageType.Double:
                    return XmlConvert.ToString((double)propertyValue);
                case StorageType.Guid:
                    return ((Guid)propertyValue).ToString();
                case StorageType.Int16:
                    return XmlConvert.ToString((short)propertyValue);
                case StorageType.Int32:
                    return XmlConvert.ToString((int)propertyValue);
                case StorageType.Int64:
                    return XmlConvert.ToString((long)propertyValue);
                case StorageType.Single:
                    return XmlConvert.ToString((float)propertyValue);
                case StorageType.String:
                    return (string)propertyValue;
                case StorageType.SByte:
                    return XmlConvert.ToString((sbyte)propertyValue);
                case StorageType.TimeSpan:
                    return XmlConvert.ToString((TimeSpan)propertyValue);
                case StorageType.Type:
                    return ((Type)propertyValue).AssemblyQualifiedName;
                case StorageType.UInt16:
                    return XmlConvert.ToString((ushort)propertyValue);
                case StorageType.UInt32:
                    return XmlConvert.ToString((uint)propertyValue);
                case StorageType.UInt64:
                    return XmlConvert.ToString((ulong)propertyValue);
                case StorageType.Uri:
                    return ((Uri)propertyValue).ToString();
                case StorageType.XDocument:
                    return ((System.Xml.Linq.XDocument)propertyValue).ToString();
                case StorageType.XElement:
                    return ((System.Xml.Linq.XElement)propertyValue).ToString();
                case StorageType.Binary:
                    return propertyValue.ToString();
                default:
                    return propertyValue.ToString();
            }
        }

        internal static bool IsKnownType(Type type)
        {
            return 0 <= IndexOfStorage(type);
        }

        internal static bool IsKnownNullableType(Type type)
        {
            return IsKnownType(Nullable.GetUnderlyingType(type) ?? type);
        }

        internal static bool IsSupportedPrimitiveTypeForUri(Type type)
        {
            return ClientConvert.ContainsReference(NamedTypesMap.Values.ToArray(), type);
        }

        internal static bool ContainsReference<T>(T[] array, T value) where T : class
        {
            return 0 <= IndexOfReference<T>(array, value);
        }

        internal static string GetEdmType(Type propertyType)
        {
            switch ((StorageType)IndexOfStorage(propertyType))
            {
                case StorageType.Boolean:
                    return XmlConstants.EdmBooleanTypeName;
                case StorageType.Byte:
                    return XmlConstants.EdmByteTypeName;
                case StorageType.Binary:
                case StorageType.ByteArray:
                    return XmlConstants.EdmBinaryTypeName;
                case StorageType.DateTime:
                    return XmlConstants.EdmDateTimeTypeName;
                case StorageType.Decimal:
                    return XmlConstants.EdmDecimalTypeName;
                case StorageType.Double:
                    return XmlConstants.EdmDoubleTypeName;
                case StorageType.Guid:
                    return XmlConstants.EdmGuidTypeName;
                case StorageType.Int16:
                    return XmlConstants.EdmInt16TypeName;
                case StorageType.Int32:
                    return XmlConstants.EdmInt32TypeName;
                case StorageType.Int64:
                    return XmlConstants.EdmInt64TypeName;
                case StorageType.Single:
                    return XmlConstants.EdmSingleTypeName;
                case StorageType.SByte:
                    return XmlConstants.EdmSByteTypeName;
                case StorageType.DateTimeOffset:
                case StorageType.TimeSpan:
                case StorageType.UInt16:
                case StorageType.UInt32:
                case StorageType.UInt64:
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCantCastToUnsupportedPrimitive, propertyType.Name));
                case StorageType.Char:
                case StorageType.CharArray:
                case StorageType.String:
                case StorageType.Type:
                case StorageType.Uri:
                case StorageType.XDocument:
                case StorageType.XElement:
                    return null;
                default:
                    return null;
            }
        }

        private static Type[] CreateKnownPrimitives()
        {
            Type[] types = new Type[1 + (int)StorageType.Binary];
            types[(int)StorageType.Boolean] = typeof(bool);
            types[(int)StorageType.Byte] = typeof(byte);
            types[(int)StorageType.ByteArray] = typeof(byte[]);
            types[(int)StorageType.Char] = typeof(char);
            types[(int)StorageType.CharArray] = typeof(char[]);
            types[(int)StorageType.DateTime] = typeof(DateTime);
            types[(int)StorageType.DateTimeOffset] = typeof(DateTimeOffset);
            types[(int)StorageType.Decimal] = typeof(decimal);
            types[(int)StorageType.Double] = typeof(double);
            types[(int)StorageType.Guid] = typeof(Guid);
            types[(int)StorageType.Int16] = typeof(short);
            types[(int)StorageType.Int32] = typeof(int);
            types[(int)StorageType.Int64] = typeof(long);
            types[(int)StorageType.Single] = typeof(float);
            types[(int)StorageType.String] = typeof(string);
            types[(int)StorageType.SByte] = typeof(sbyte);
            types[(int)StorageType.TimeSpan] = typeof(TimeSpan);
            types[(int)StorageType.Type] = typeof(Type);
            types[(int)StorageType.UInt16] = typeof(ushort);
            types[(int)StorageType.UInt32] = typeof(uint);
            types[(int)StorageType.UInt64] = typeof(ulong);
            types[(int)StorageType.Uri] = typeof(Uri);
            types[(int)StorageType.XDocument] = typeof(System.Xml.Linq.XDocument);
            types[(int)StorageType.XElement] = typeof(System.Xml.Linq.XElement);
            types[(int)StorageType.Binary] = null;
            return types;
        }

        private static Dictionary<string, Type> CreateKnownNamesMap()
        {
            Dictionary<string, Type> named = new Dictionary<string, Type>(EqualityComparer<string>.Default);

            named.Add(XmlConstants.EdmStringTypeName, typeof(string));
            named.Add(XmlConstants.EdmBooleanTypeName, typeof(bool));
            named.Add(XmlConstants.EdmByteTypeName, typeof(byte));
            named.Add(XmlConstants.EdmDateTimeTypeName, typeof(DateTime));
            named.Add(XmlConstants.EdmDecimalTypeName, typeof(decimal));
            named.Add(XmlConstants.EdmDoubleTypeName, typeof(double));
            named.Add(XmlConstants.EdmGuidTypeName, typeof(Guid));
            named.Add(XmlConstants.EdmInt16TypeName, typeof(short));
            named.Add(XmlConstants.EdmInt32TypeName, typeof(int));
            named.Add(XmlConstants.EdmInt64TypeName, typeof(long));
            named.Add(XmlConstants.EdmSByteTypeName, typeof(sbyte));
            named.Add(XmlConstants.EdmSingleTypeName, typeof(float));
            named.Add(XmlConstants.EdmBinaryTypeName, typeof(byte[]));
            return named;
        }

        private static int IndexOfStorage(Type type)
        {
            int index = ClientConvert.IndexOfReference(ClientConvert.KnownTypes, type);
            if ((index < 0) && needSystemDataLinqBinary && (type.Name == "Binary"))
            {
                return LoadSystemDataLinqBinary(type);
            }
            return index;
        }

        internal static int IndexOfReference<T>(T[] array, T value) where T : class
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (object.ReferenceEquals(array[i], value))
                {
                    return i;
                }
            }

            return -1;
        }

        internal static Uri CreateUri(string value, UriKind kind)
        {
            return value == null ? null : new Uri(value, kind);
        }

        private static int LoadSystemDataLinqBinary(Type type)
        {
            if (type.Namespace == "System.Data.Linq" &&
                System.Reflection.AssemblyName.ReferenceMatchesDefinition(type.Assembly.GetName(), new System.Reflection.AssemblyName(SystemDataLinq)))
            {
                ClientConvert.KnownTypes[(int)StorageType.Binary] = type;
                needSystemDataLinqBinary = false;
                return (int)StorageType.Binary;
            }

            return -1;
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal static class FXAssembly
    {
        internal const string Version = "4.0.0.0";
    }

    internal static class AssemblyRef
    {
        internal const string MicrosoftPublicKeyToken = "b03f5f7f11d50a3a";

        internal const string EcmaPublicKeyToken = "b77a5c561934e089";
    }
#pragma warning restore SA1402 // File may only contain a single type
}
