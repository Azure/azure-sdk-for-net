// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class ServicePrincipalInformation
    {
        /// <summary> Initializes a new instance of <see cref="ServicePrincipalInformation"/>. </summary>
        /// <param name="applicationId"> The application ID, also known as client ID, of the service principal. </param>
        /// <param name="principalId"> The principal ID, also known as the object ID, of the service principal. </param>
        /// <param name="tenantId"> The tenant ID, also known as the directory ID, of the tenant in which the service principal is created. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationId"/>, <paramref name="principalId"/> or <paramref name="tenantId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ServicePrincipalInformation(string applicationId, string principalId, string tenantId)
            : this(applicationId, null, principalId, tenantId, null)
        {
        }
    }
}
