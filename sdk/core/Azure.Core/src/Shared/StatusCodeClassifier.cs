// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

#nullable enable

namespace Azure.Core
{
    internal class StatusCodeClassifier : ResponseClassifier
    {
        // We need 10 ulongs to represent status codes 100 - 599.
        private const int Length = 10;
        private ulong[] _nonErrors;

        internal HttpMessageClassifier[]? TryClassifiers { get; set; }

        public StatusCodeClassifier(ReadOnlySpan<int> nonErrors)
        {
            _nonErrors = new ulong[Length];

            foreach (int statusCode in nonErrors)
            {
                AddClassifier(statusCode, isError: false);
            }
        }

        private StatusCodeClassifier(ulong[] nonErrors, HttpMessageClassifier[]? tryClassifiers)
        {
            Debug.Assert(nonErrors?.Length == Length);

            _nonErrors = nonErrors!;
            TryClassifiers = tryClassifiers;
        }

        public virtual StatusCodeClassifier Clone()
        {
            ulong[] nonErrors = new ulong[Length];
            Array.Copy(_nonErrors, nonErrors, Length);

            return new StatusCodeClassifier(nonErrors, TryClassifiers);
        }

        public override bool IsErrorResponse(HttpMessage message)
        {
            bool isError;

            if (TryClassifiers != null)
            {
                for (int i = TryClassifiers.Length - 1; i >= 0; i--)
                {
                    if (TryClassifiers[i].TryClassify(message, out isError))
                    {
                        return isError;
                    }
                }
            }

            return !IsNonError(message.Response.Status);
        }

        internal void AddClassifier(int statusCode, bool isError)
        {
            var index = statusCode >> 6;        // divides by 64
            int bit = statusCode & 0b111111;    // keeps the bits up to 63
            ulong mask = 1ul << bit;      // shifts a 1 to the position of code

            ulong value = _nonErrors[index];
            if (!isError)
            {
                value |= mask;
            }
            else
            {
                value &= ~mask;
            }

            _nonErrors[index] = value;
        }

        private bool IsNonError(int statusCode)
        {
            var index = statusCode >> 6;      // divides by 64
            int bit = statusCode & 0b111111;  // keeps the bits up to 63
            ulong mask = 1ul << bit;    // shifts a 1 to the position of code

            ulong value = _nonErrors[index];
            return (value & mask) != 0;
        }
    }
}
