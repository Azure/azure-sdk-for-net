// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CA1822 // Compatibility instance members intentionally preserve previous signatures.
#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class SecuritySolutionsReferenceData
    {
        public SecuritySolutionsReferenceData(SecurityFamily securityFamily, string alertVendorName, System.Uri packageInfoUri, string productName, string publisher, string publisherDisplayName, string template) : this(new SecuritySolutionsReferenceDataProperties(securityFamily, alertVendorName, packageInfoUri?.AbsoluteUri, productName, publisher, publisherDisplayName, template))
        {
        }

        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SecurityFamily SecurityFamily { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AlertVendorName { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProductName { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Publisher { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PublisherDisplayName { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Template { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.Uri PackageInfoUri { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
    }
}
