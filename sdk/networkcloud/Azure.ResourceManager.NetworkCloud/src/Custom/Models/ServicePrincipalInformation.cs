// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> ServicePrincipalInformation represents the details of the service principal to be used by the cluster during Arc Appliance installation. </summary>
    public partial class ServicePrincipalInformation
    {
        /// <summary> Initializes a new instance of <see cref="ServicePrincipalInformation"/>. </summary>
        /// <param name="applicationId"> The application ID, also known as client ID, of the service principal. </param>

        /// <param name="principalId"> The principal ID, also known as the object ID, of the service principal. </param>
        /// <param name="tenantId"> The tenant ID, also known as the directory ID, of the tenant in which the service principal is created. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationId"/>, <paramref name="principalId"/> or <paramref name="tenantId"/> is null. </exception>
        public ServicePrincipalInformation(string applicationId, string principalId, string tenantId)
        {
            Argument.AssertNotNull(applicationId, nameof(applicationId));
            Argument.AssertNotNull(principalId, nameof(principalId));
            Argument.AssertNotNull(tenantId, nameof(tenantId));
            ApplicationId = applicationId;
            PrincipalId = principalId;
            TenantId = tenantId;
        }
    }
}
