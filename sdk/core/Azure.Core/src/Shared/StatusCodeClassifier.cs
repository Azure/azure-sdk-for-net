// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

#nullable enable

namespace Azure.Core
{
    internal class StatusCodeClassifier : ResponseClassifier
    {
        private ulong[] _nonErrors = new ulong[10];

        internal HttpMessageClassifier[]? MessageClassifiers { get; set; }

        public StatusCodeClassifier(int[] nonErrors)
        {
            for (int i = 0; i < nonErrors.Length; i++)
            {
                AddClassifier(nonErrors[i], true);
            }
        }

        private StatusCodeClassifier(ulong[] nonErrors)
        {
            Debug.Assert(nonErrors?.Length == 10);
            Array.Copy(nonErrors, _nonErrors, _nonErrors.Length);
        }

        public override bool IsErrorResponse(HttpMessage message)
        {
            if (TryClassify(message, out var isError))
            {
                return isError;
            }

            if (MessageClassifiers != null)
            {
                for (int i = MessageClassifiers.Length; i >= 0; i--)
                {
                    if (MessageClassifiers[i].TryClassify(message, out isError))
                    {
                        return isError;
                    }
                }
            }

            return !IsNonError(message.Response.Status);
        }

        public virtual StatusCodeClassifier Clone()
        {
            return new StatusCodeClassifier(_nonErrors);
        }

        internal void AddClassifier(int code, bool isNonError)
        {
            var index = code >> 6;        // divides by 64
            int bit = code & 0b111111;    // keeps the bits up to 63
            ulong mask = 1ul << bit;      // shifts a 1 to the position of code

            ulong value = _nonErrors[index];
            if (isNonError)
            {
                value |= mask;
            }
            else
            {
                value &= ~mask;
            }

            _nonErrors[index] = value;
        }

        private bool IsNonError(int code)
        {
            var index = code >> 6;      // divides by 64
            int bit = code & 0b111111;  // keeps the bits up to 63
            ulong mask = 1ul << bit;    // shifts a 1 to the position of code

            ulong value = _nonErrors[index];
            return (value & mask) != 0;
        }
    }
}
