// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Sql
{
    using System;
    using System.Linq;

    /// <summary>
    /// Helpers methods for working with resource ids.
    /// </summary>
    internal static class ResourceIdHelpers
    {
        /// <summary>
        /// Gets the last segments of a resource id, or null if the id is null.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        public static string GetLastSegment(string resourceId)
        {
            if (resourceId == null)
            {
                return null;
            }

            // Uri.Segments is only supported for absolute uris, so we give
            // a fake host name.
            Uri uri = new Uri(
                new Uri("https://my.example"), // Dummy host name
                resourceId);

            return uri.Segments.Last();
        }
    }
}
