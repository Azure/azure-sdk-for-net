// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Numerics;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class KnownTypesParseToStringConverterFactory : IStringToTConverterFactory
    {
        public IConverter<string, TOutput> TryCreate<TOutput>()
        {
            if (typeof(TOutput) == typeof(byte))
            {
                return (IConverter<string, TOutput>)new StringToByteConverter();
            }

            if (typeof(TOutput) == typeof(sbyte))
            {
                return (IConverter<string, TOutput>)new StringToSByteConverter();
            }

            if (typeof(TOutput) == typeof(short))
            {
                return (IConverter<string, TOutput>)new StringToInt16Converter();
            }

            if (typeof(TOutput) == typeof(ushort))
            {
                return (IConverter<string, TOutput>)new StringToUInt16Converter();
            }

            if (typeof(TOutput) == typeof(int))
            {
                return (IConverter<string, TOutput>)new StringToInt32Converter();
            }

            if (typeof(TOutput) == typeof(uint))
            {
                return (IConverter<string, TOutput>)new StringToUInt32Converter();
            }

            if (typeof(TOutput) == typeof(long))
            {
                return (IConverter<string, TOutput>)new StringToInt64Converter();
            }

            if (typeof(TOutput) == typeof(ulong))
            {
                return (IConverter<string, TOutput>)new StringToUInt64Converter();
            }

            if (typeof(TOutput) == typeof(float))
            {
                return (IConverter<string, TOutput>)new StringToSingleConverter();
            }

            if (typeof(TOutput) == typeof(double))
            {
                return (IConverter<string, TOutput>)new StringToDoubleConverter();
            }

            if (typeof(TOutput) == typeof(decimal))
            {
                return (IConverter<string, TOutput>)new StringToDecimalConverter();
            }

            if (typeof(TOutput) == typeof(BigInteger))
            {
                return (IConverter<string, TOutput>)new StringToBigIntegerConverter();
            }

            if (typeof(TOutput) == typeof(Guid))
            {
                return (IConverter<string, TOutput>)new StringToGuidConverter();
            }

            if (typeof(TOutput) == typeof(DateTime))
            {
                return (IConverter<string, TOutput>)new StringToDateTimeConverter();
            }

            if (typeof(TOutput) == typeof(DateTimeOffset))
            {
                return (IConverter<string, TOutput>)new StringToDateTimeOffsetConverter();
            }

            if (typeof(TOutput) == typeof(TimeSpan))
            {
                return (IConverter<string, TOutput>)new StringToTimeSpanConverter();
            }

            return null;
        }
    }
}
