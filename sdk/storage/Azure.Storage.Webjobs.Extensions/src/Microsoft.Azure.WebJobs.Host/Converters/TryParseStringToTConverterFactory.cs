// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class TryParseStringToTConverterFactory : IStringToTConverterFactory
    {
        public IConverter<string, TOutput> TryCreate<TOutput>()
        {
            // bool succeeded = TOutput.TryParse(string input, out TOutput result);
            MethodInfo tryParseMethod = typeof(TOutput).GetMethod("TryParse", BindingFlags.Public | BindingFlags.Static,
                null, new[] { typeof(string), typeof(TOutput).MakeByRefType() }, null);

            // Can't convert for the following close non-matches (don't match TryParseDelegate<TOutput>):
            // *<non-bool>* TryParse(string input, out TOutput result)
            // bool TryParse(string input, *ref* TOutput result)
            if (tryParseMethod == null || tryParseMethod.ReturnType != typeof(bool) ||
                !tryParseMethod.GetParameters()[1].IsOut)
            {
                return null;
            }

            TryParseDelegate<TOutput> tryParseDelegate =
                (TryParseDelegate<TOutput>)Delegate.CreateDelegate(typeof(TryParseDelegate<TOutput>), tryParseMethod);
            return new TryParseStringToTConverter<TOutput>(tryParseDelegate);
        }
    }
}
