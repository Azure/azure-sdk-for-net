// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterTenantResource
    {
        public virtual TenantAssessmentMetadataCollection GetAllTenantAssessmentMetadata() => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual Azure.Response<TenantAssessmentMetadataResource> GetTenantAssessmentMetadata(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
        public virtual System.Threading.Tasks.Task<Azure.Response<TenantAssessmentMetadataResource>> GetTenantAssessmentMetadataAsync(string assessmentMetadataName, System.Threading.CancellationToken cancellationToken = default) => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface.");
    }
}
