// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Template
{
    internal static partial class MultiVersion
    {
        // T is the Model - i.e. the instance the caller passed to the request
        // U is the ServiceVersion enum - i.e. the target service version
        public static void AssertValidInput<TModel, UVersion>(TModel value, UVersion version, RequestFailedException e) where TModel : IVersionValidatable<UVersion>
        {
            if (!value.IsValidInput(version, out string message))
            {
                throw new NotSupportedException(message, e);
            }
        }
    }
}
