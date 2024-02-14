﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

        /// <summary>
        /// Well known OpenId configuration endpoint.
        /// </summary>
        public string OidcMetadataUrl { get; set; }

        /// <summary>
        /// Token Issuer for v1 versions of tokens.
        /// </summary>
        public string TokenIssuerV1 { get; set; }

        /// <summary>
        /// Token Issuer for v2 versions of tokens.
        /// </summary>
        public string TokenIssuerV2 { get; set; }

        internal bool IsParameterString { get; set; } = true;
    }
}
