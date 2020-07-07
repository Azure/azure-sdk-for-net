// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class TryParseStringToTConverter<TOutput> : IConverter<string, TOutput>
    {
        private TryParseDelegate<TOutput> _tryParseDelegate;

        public TryParseStringToTConverter(TryParseDelegate<TOutput> tryParse)
        {
            _tryParseDelegate = tryParse;
        }

        public TOutput Convert(string input)
        {
            TOutput parsed;

            if (!_tryParseDelegate.Invoke(input, out parsed))
            {
                string msg = String.Format(CultureInfo.CurrentCulture,
                    "Input string was not in a correct format for type '{0}'.", typeof(TOutput).FullName);
                throw new FormatException(msg);
            }

            return parsed;
        }
    }
}
