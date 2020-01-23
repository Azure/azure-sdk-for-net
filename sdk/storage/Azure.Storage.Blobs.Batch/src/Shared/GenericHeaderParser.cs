// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/AspNetCore/tree/master/src/Http/Headers/src

using System;

#pragma warning disable IDE0016 // Simplify null check
#pragma warning disable IDE0044 // Make field readonly

namespace Azure.Core.Http.Multipart
{
    internal sealed class GenericHeaderParser<T> : BaseHeaderParser<T>
    {
        internal delegate int GetParsedValueLengthDelegate(StringSegment value, int startIndex, out T parsedValue);

        private GetParsedValueLengthDelegate _getParsedValueLength;

        internal GenericHeaderParser(bool supportsMultipleValues, GetParsedValueLengthDelegate getParsedValueLength)
            : base(supportsMultipleValues)
        {
            if (getParsedValueLength == null)
            {
                throw new ArgumentNullException(nameof(getParsedValueLength));
            }

            _getParsedValueLength = getParsedValueLength;
        }

        protected override int GetParsedValueLength(StringSegment value, int startIndex, out T parsedValue)
        {
            return _getParsedValueLength(value, startIndex, out parsedValue);
        }
    }
}
