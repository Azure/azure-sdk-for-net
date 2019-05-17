// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage
{
    static partial class Errors
    {
        public static InvalidOperationException NonNullMethodFactoryRequiresDecodingPolicy() => new InvalidOperationException("Non-null methodFactory requires DecodingPolicyFactory in the pipeline");
        public static InvalidOperationException DecodingPolicyCanOnlyAppearOnce() => new InvalidOperationException("DecodingPolicyFactory can only appear once in the pipeline");
        public static ArgumentNullException ArgumentNull(string paramName) => new ArgumentNullException(paramName);
        public static ArgumentException StreamMustBeReadable(string paramName) => new ArgumentException("Stream must be readable", paramName);
        public static ArgumentOutOfRangeException MustBeGreaterThanOrEqualTo(string paramName, long value) => new ArgumentOutOfRangeException(paramName, $"Value must be greater than or equal to {value}");
        public static InvalidOperationException TokenCredentialsRequireHttps() => new InvalidOperationException("Use of token credentials requires HTTPS");
    }
}
