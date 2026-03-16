// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class AdministrativeCredentials
    {
        /// <summary> Initializes a new instance of <see cref="AdministrativeCredentials"/>. </summary>
        /// <param name="password"> The password of the administrator of the device used during initialization. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AdministrativeCredentials(string password)
            : this(password, null, null)
        {
        }
    }
}
