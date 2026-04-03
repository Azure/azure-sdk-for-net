// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class DomainValidationProperties
    {
        // Backward compatibility: old API exposed ExpiresOn as DateTimeOffset
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? ExpiresOn
        {
            get
            {
                if (ExpirationDate != null && DateTimeOffset.TryParse(ExpirationDate, out var result))
                {
                    return result;
                }
                return null;
            }
        }
    }
}
