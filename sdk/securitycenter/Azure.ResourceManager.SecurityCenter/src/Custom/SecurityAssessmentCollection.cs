// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    public partial class SecurityAssessmentCollection
    {
        /// <summary> Create a security assessment on your resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public virtual Task<ArmOperation<SecurityAssessmentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string assessmentName, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");

        /// <summary> Create a security assessment on your resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public virtual ArmOperation<SecurityAssessmentResource> CreateOrUpdate(WaitUntil waitUntil, string assessmentName, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");

        /// <summary> Get a security assessment on your scanned resource. </summary>
        public virtual Task<Response<SecurityAssessmentResource>> GetAsync(string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => GetAsyncWrapper(assessmentName, expand, cancellationToken);

        /// <summary> Get a security assessment on your scanned resource. </summary>
        public virtual Response<SecurityAssessmentResource> Get(string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
        {
            NullableResponse<SecurityAssessmentResource> response = GetIfExists(assessmentName, expand, cancellationToken);
            return Response.FromValue(response.Value, response.GetRawResponse());
        }

        /// <summary> Check if a security assessment exists. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => ExistsAsyncWrapper(assessmentName, expand, cancellationToken);

        /// <summary> Check if a security assessment exists. </summary>
        public virtual Response<bool> Exists(string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
        {
            NullableResponse<SecurityAssessmentResource> response = GetIfExists(assessmentName, expand, cancellationToken);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        private async Task<Response<SecurityAssessmentResource>> GetAsyncWrapper(string assessmentName, SecurityAssessmentODataExpand? expand, CancellationToken cancellationToken)
        {
            NullableResponse<SecurityAssessmentResource> response = await GetIfExistsAsync(assessmentName, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value, response.GetRawResponse());
        }

        private async Task<Response<bool>> ExistsAsyncWrapper(string assessmentName, SecurityAssessmentODataExpand? expand, CancellationToken cancellationToken)
        {
            NullableResponse<SecurityAssessmentResource> response = await GetIfExistsAsync(assessmentName, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }
    }
}
