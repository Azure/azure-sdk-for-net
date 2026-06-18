// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
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
