// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// This is the concrete ResponseClassifier type that is designed
    /// to work with customizations specified in <see cref="RequestContext"/>.
    /// It implements the Chain of Responsibility design pattern.
    /// </summary>
    public class CoreResponseClassifier : ResponseClassifier
    {
        // We need 10 ulongs to represent status codes 100 - 599.
        private const int Length = 10;
        private ulong[] _nonErrors;

        internal ResponseClassificationHandler[]? Handlers { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="CoreResponseClassifier"/>
        /// </summary>
        /// <param name="nonErrors"></param>
        public CoreResponseClassifier(ReadOnlySpan<int> nonErrors)
        {
            _nonErrors = new ulong[Length];

            foreach (int statusCode in nonErrors)
            {
                AddClassifier(statusCode, isError: false);
            }
        }

        private CoreResponseClassifier(ulong[] nonErrors, ResponseClassificationHandler[]? handlers)
        {
            Debug.Assert(nonErrors?.Length == Length);

            _nonErrors = nonErrors!;
            Handlers = handlers;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        internal virtual CoreResponseClassifier Clone()
        {
            ulong[] nonErrors = new ulong[Length];
            Array.Copy(_nonErrors, nonErrors, Length);

            return new CoreResponseClassifier(nonErrors, Handlers);
        }

        /// <inheritdoc/>
        public override bool IsErrorResponse(HttpMessage message)
        {
            bool isError;

            if (Handlers != null)
            {
                foreach (var handler in Handlers)
                {
                    if (handler.TryClassify(message, out isError))
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
