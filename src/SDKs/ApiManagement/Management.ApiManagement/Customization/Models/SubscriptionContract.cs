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
        public string ProductIdentifier
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ProductId))
                {
                    return this.ProductId.Split(new[] { '/' }).Last();
                }

                return null;
            }
        }

        public string UserIdentifier
        {
            get
            {
                if (!string.IsNullOrEmpty(this.UserId))
                {
                    return this.UserId.Split(new[] { '/' }).Last();
                }

                return null;
            }
        }

    }
}
