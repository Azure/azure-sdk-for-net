// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// This type inherits from ResponseClassifier and is designed to work
    /// efficiently with classifier customizations specified in <see cref="RequestContext"/>.
    /// </summary>
    public class StatusCodeClassifier : ResponseClassifier
    {
        // We need 10 ulongs to represent status codes 100 - 599.
        private const int Length = 10;
        private ulong[] _successCodes;

        internal ResponseClassificationHandler[]? Handlers { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="StatusCodeClassifier"/>
        /// </summary>
        /// <param name="successStatusCodes">The status codes that this classifier will consider
        /// not to be errors.</param>
        public StatusCodeClassifier(ReadOnlySpan<ushort> successStatusCodes)
        {
            _successCodes = new ulong[Length];

            foreach (int statusCode in successStatusCodes)
            {
                AddClassifier(statusCode, isError: false);
            }
        }

        private StatusCodeClassifier(ulong[] successCodes, ResponseClassificationHandler[]? handlers)
        {
            Debug.Assert(successCodes?.Length == Length);

            _successCodes = successCodes!;
            Handlers = handlers;
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

            return !IsSuccessCode(message.Response.Status);
        }

        internal virtual StatusCodeClassifier Clone()
        {
            ulong[] successCodes = new ulong[Length];
            Array.Copy(_successCodes, successCodes, Length);

            return new StatusCodeClassifier(successCodes, Handlers);
        }

        internal void AddClassifier(int statusCode, bool isError)
        {
            Argument.AssertInRange(statusCode, 0, 639, nameof(statusCode));

            var index = statusCode >> 6;        // divides by 64
            int bit = statusCode & 0b111111;    // keeps the bits up to 63
            ulong mask = 1ul << bit;      // shifts a 1 to the position of code

            ulong value = _successCodes[index];
            if (!isError)
            {
                value |= mask;
            }
            else
            {
                value &= ~mask;
            }

            _successCodes[index] = value;
        }

        private bool IsSuccessCode(int statusCode)
        {
            var index = statusCode >> 6;      // divides by 64
            int bit = statusCode & 0b111111;  // keeps the bits up to 63
            ulong mask = 1ul << bit;    // shifts a 1 to the position of code

            ulong value = _successCodes[index];
            return (value & mask) != 0;
        }
    }
}
