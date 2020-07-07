// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal static class TToStringConverterFactory
    {
        public static IConverter<TInput, string> TryCreate<TInput>()
        {
            if (typeof(TInput) == typeof(string))
            {
                return (IConverter<TInput, string>)new IdentityConverter<string>();
            }

            if (typeof(TInput) == typeof(char))
            {
                return (IConverter<TInput, string>)new CharToStringConverter();
            }

            if (typeof(TInput) == typeof(byte))
            {
                return (IConverter<TInput, string>)new ByteToStringConverter();
            }

            if (typeof(TInput) == typeof(sbyte))
            {
                return (IConverter<TInput, string>)new SByteToStringConverter();
            }

            if (typeof(TInput) == typeof(short))
            {
                return (IConverter<TInput, string>)new Int16ToStringConverter();
            }

            if (typeof(TInput) == typeof(ushort))
            {
                return (IConverter<TInput, string>)new UInt16ToStringConverter();
            }

            if (typeof(TInput) == typeof(int))
            {
                return (IConverter<TInput, string>)new Int32ToStringConverter();
            }

            if (typeof(TInput) == typeof(uint))
            {
                return (IConverter<TInput, string>)new UInt32ToStringConverter();
            }

            if (typeof(TInput) == typeof(long))
            {
                return (IConverter<TInput, string>)new Int64ToStringConverter();
            }

            if (typeof(TInput) == typeof(ulong))
            {
                return (IConverter<TInput, string>)new UInt64ToStringConverter();
            }

            if (typeof(TInput) == typeof(Guid))
            {
                return (IConverter<TInput, string>)new GuidToStringConverter();
            }

            return null;
        }
    }
}
