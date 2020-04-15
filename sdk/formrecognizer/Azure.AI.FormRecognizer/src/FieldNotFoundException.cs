// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.FormRecognizer.Models
{
#pragma warning disable CA1064 // Exceptions should be public
    internal class FieldNotFoundException : Exception
#pragma warning restore CA1064 // Exceptions should be public
    {
        public FieldNotFoundException(string message) : base(message)
        {
        }
    }
}
