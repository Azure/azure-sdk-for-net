// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    using System.Linq;

    /// <summary>
    /// Subscription details.
    /// </summary>
    public partial class SubscriptionContract
    {
        public string ScopeIdentifier
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Scope))
                {
                    return this.Scope.Split(new[] { '/' }).Last();
                }

                return null;
            }
        }

        public string OwnerIdentifier
        {
            get
            {
                if (!string.IsNullOrEmpty(this.OwnerId))
                {
                    return this.OwnerId.Split(new[] { '/' }).Last();
                }

                return null;
            }
        }
    }
}
