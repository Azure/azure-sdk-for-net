// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Diagnostics
{
    public class KnownExceptionAttribute : Attribute
    {
        public KnownExceptionAttribute(Type exceptionType)
            => ExceptionType = exceptionType;

        public Type ExceptionType { get; }

        public string Message { get; set; }
    }
}
