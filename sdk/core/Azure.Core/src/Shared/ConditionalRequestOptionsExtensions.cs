// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Http
{
    internal static class ConditionalRequestOptionsExtensions
    {
        public static void ApplyHeaders(Request request, ConditionalRequestOptions options)
        {
            ConditionalRequestHelpers.Apply(request, options);
        }

        private class ConditionalRequestHelpers : ConditionalRequestOptions
        {
            public static void Apply(Request request, ConditionalRequestOptions options) =>
                ApplyHeaders(request, options);
        }
    }
}
