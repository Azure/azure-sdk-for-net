// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Description;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Authentication Event Trigger that will trigger incoming authentication events.</summary>
    [AttributeUsage(AttributeTargets.Parameter)]
#pragma warning disable CS0618 // Type or member is obsolete
    [Binding(TriggerHandlesReturnValue = true)]
#pragma warning restore CS0618 // Type or member is obsolete

    public class AuthenticationEventsTriggerAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="AuthenticationEventsTriggerAttribute" /> class.</summary>
        public AuthenticationEventsTriggerAttribute()
        {
        }

        /// <summary>Gets or sets the tenant identifier.</summary>
        /// <value>The tenant identifier.</value>
        public string TenantId { get; set; }

        /// <summary>Gets or sets the audience application identifier.</summary>
        /// <value>The audience application identifier.</value>
        public string AudienceAppId { get; set; }

        /// <summary>Gets or sets the open identifier connect host. (default: Microsoft on-line).</summary>
        /// <value>The open identifier connect host.</value>
        public string OpenIdConnectHost { get; set; } = ConfigurationManager.OPENID_CONNECTHOST;

        internal bool IsString { get; set; } = true;
    }
}
