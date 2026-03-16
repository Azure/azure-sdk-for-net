// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class ServicePrincipalInformation
    {
        /// <summary> Initializes a new instance of <see cref="ServicePrincipalInformation"/>. </summary>
        /// <param name="applicationId"> The application ID, also known as client ID, of the service principal. </param>
        /// <param name="password"> The password of the service principal. </param>
        /// <param name="principalId"> The principal ID, also known as the object ID, of the service principal. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ServicePrincipalInformation(string applicationId, string password, string principalId)
            : this(applicationId, password, principalId, null, null)
        {
        }
    }
}
