﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Internal;

namespace System.Net.ClientModel.Core
{
    public class ResponseStatusClassifier : MessageClassifier
    {
        // We need 10 ulongs to represent status codes 100 - 599.
        private const int Length = 10;
        private ulong[] _successCodes;

        /// <summary>
        /// Creates a new instance of <see cref="ResponseStatusClassifier"/>
        /// </summary>
        /// <param name="successStatusCodes">The status codes that this classifier will consider
        /// not to be errors.</param>
        public ResponseStatusClassifier(ReadOnlySpan<ushort> successStatusCodes)
        {
            _successCodes = new ulong[Length];

            foreach (int statusCode in successStatusCodes)
            {
                AddClassifier(statusCode, isError: false);
            }
        }

        public override bool IsError(PipelineMessage message)
        {
            return base.IsError(message);
        }

        private void AddClassifier(int statusCode, bool isError)
        {
            ClientUtilities.AssertInRange(statusCode, 0, 639, nameof(statusCode));

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
