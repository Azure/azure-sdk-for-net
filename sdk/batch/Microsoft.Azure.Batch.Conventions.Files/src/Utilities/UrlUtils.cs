// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.Utilities
{
    internal static class UrlUtils
    {
        internal static string GetUrlValueSegment(string url, string containerSegment)
        {
            Validate.IsNotNullOrEmpty(url, nameof(url));
            Validate.IsNotNullOrEmpty(containerSegment, nameof(containerSegment));

            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                throw new ArgumentException("url must be a valid absolute URI", nameof(url));
            }

            var segments = uri.Segments
                              .Select(s => s.Trim('/'))
                              .ToList();

            var containerSegmentIndex = segments.FindIndex(s => String.Equals(containerSegment, s, StringComparison.OrdinalIgnoreCase));

            // If the containerSegment is not present, or is the last segment, then there
            // is no value.
            if (containerSegmentIndex < 0)
            {
                return null;
            }
            if (containerSegmentIndex == segments.Count - 1)
            {
                return null;
            }

            var valueSegmentIndex = containerSegmentIndex + 1;

            return segments[valueSegmentIndex];
        }
    }
}
