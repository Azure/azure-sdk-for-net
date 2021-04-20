// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Tests.Shared
{
    /// <summary>
    /// We have plenty of tests that fail in live mode because RBAC roles assignments has not yet propagated.
    /// </summary>
    public class RetryOnAuthorizationPermissionMismatchAttribute : RetryOnFailedRequestAttribute
    {
        public RetryOnAuthorizationPermissionMismatchAttribute() : base(60, 10, "AuthorizationPermissionMismatch")
        {
        }
    }
}
