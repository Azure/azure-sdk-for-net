// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

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

        public override bool IsErrorResponse(HttpMessage message)
        {
            if (TryClassify(message, out var isError))
            {
                return isError;
            }

            return !IsNonError(message.Response.Status);
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

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public void AddClassifiers(RequestContext context)
        {
            if (context.StatusCodes?.Count > 0)
            {
                foreach (var classification in context.StatusCodes)
                {
                    AddClassifier(classification.Status, classification.IsError);
                }
            }

            if (context.MessageClassifiers != null)
            {
                var length = context.MessageClassifiers.Length;
                HttpMessageClassifier[] classifiers = new HttpMessageClassifier[length];
                Array.Copy(context.MessageClassifiers, classifiers, length);
                MessageClassifiers = classifiers;
            }
        }
    }
}
