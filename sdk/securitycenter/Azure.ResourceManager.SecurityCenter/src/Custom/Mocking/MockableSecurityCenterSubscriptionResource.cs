// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterSubscriptionResource
    {
        /// <summary> Get all security controls within a scope. </summary>
        public virtual Pageable<SecureScoreControlDetails> GetSecureScoreControls(SecurityScoreODataExpand? expand = default, CancellationToken cancellationToken = default)
            => GetAll(expand, cancellationToken);
    }
}
