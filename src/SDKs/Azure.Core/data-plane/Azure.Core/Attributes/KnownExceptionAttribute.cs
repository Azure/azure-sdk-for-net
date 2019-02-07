// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Core
{
    public class KnownExceptionAttribute : Attribute
    {
        public KnownExceptionAttribute(Type exceptionType)
            => ExceptionType = exceptionType;

        public Type ExceptionType { get; }

        public string Message { get; set; }
    }
}
