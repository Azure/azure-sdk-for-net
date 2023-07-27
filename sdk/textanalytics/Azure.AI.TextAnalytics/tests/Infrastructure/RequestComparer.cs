// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Tests.Infrastructure
{
    internal class RequestComparer : IEqualityComparer<Request>
    {
        public static RequestComparer Shared { get; } = new RequestComparer();

        public bool Equals(Request x, Request y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            return x.Method == y.Method
                && string.Equals(x.Uri.Scheme, y.Uri.Scheme, StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Uri.Host, y.Uri.Host, StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Uri.Path, y.Uri.Path, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Request obj) => HashCodeBuilder.Combine(
            obj.Method,
            obj.Uri.Scheme.ToLowerInvariant(),
            obj.Uri.Host.ToLowerInvariant(),
            obj.Uri.Path.ToLowerInvariant());
    }
}
