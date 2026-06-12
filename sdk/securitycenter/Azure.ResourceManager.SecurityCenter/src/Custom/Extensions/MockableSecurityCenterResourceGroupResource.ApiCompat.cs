// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shims do not need public docs.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterResourceGroupResource
    {
        public virtual ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(string resourceNamespace, string resourceType, string resourceName)
        {
            Argument.AssertNotNullOrEmpty(resourceNamespace, nameof(resourceNamespace));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            return new ServerVulnerabilityAssessmentCollection(Client, Id, resourceNamespace, resourceType, resourceName);
        }

        [ForwardsClientCalls]
        public virtual Task<Response<ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(string resourceNamespace, string resourceType, string resourceName, CancellationToken cancellationToken = default)
            => GetServerVulnerabilityAssessments(resourceNamespace, resourceType, resourceName).GetAsync(cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(string resourceNamespace, string resourceType, string resourceName, CancellationToken cancellationToken = default)
            => GetServerVulnerabilityAssessments(resourceNamespace, resourceType, resourceName).Get(cancellationToken);
    }
}
