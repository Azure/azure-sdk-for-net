// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CustomerCertificateProperties
    {
        // Backward compatibility: old API used ctor(WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CustomerCertificateProperties(WritableSubResource secretSource) : this()
        {
            if (secretSource != null)
            {
                SecretSource = new ResourceReference { Id = secretSource.Id };
            }
        }

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
