// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the AwsAssumeRoleAuthenticationDetailsProperties class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AwsAssumeRoleAuthenticationDetailsProperties : AuthenticationDetailsProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AwsAssumeRoleAuthenticationDetailsProperties"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="awsAssumeRoleArn">The value preserved for API compatibility.</param>
        /// <param name="awsExternalId">The value preserved for API compatibility.</param>
        public AwsAssumeRoleAuthenticationDetailsProperties(string awsAssumeRoleArn, System.Guid awsExternalId) { }
        /// <summary>
        /// Gets or sets the AwsAssumeRoleArn value preserved from the previous public API surface.
        /// </summary>
        public string AwsAssumeRoleArn { get; set; }
        /// <summary>
        /// Gets or sets the AwsExternalId value preserved from the previous public API surface.
        /// </summary>
        public System.Guid AwsExternalId { get; set; }
        /// <summary>
        /// Gets or sets the AccountId value preserved from the previous public API surface.
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// Gets or sets the RoleArn value preserved from the previous public API surface.
        /// </summary>
        public string RoleArn { get; set; }
    }
}
