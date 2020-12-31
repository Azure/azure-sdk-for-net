// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Data.Tables.Queryable
{
    internal static class ClientConvert
    {
        private static readonly Type[] s_knownTypes = CreateKnownPrimitives();

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

        private static int IndexOfStorage(Type type)
        {
            int index = ClientConvert.IndexOfReference(ClientConvert.s_knownTypes, type);
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
    }
}
