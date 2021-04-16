// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Security.Claims;

using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class WebPubSubConnectionAttribute : Attribute
    {
        [ConnectionString]
        public string ConnectionStringSetting { get; set; } = Constants.WebPubSubConnectionStringName;

        [AutoResolve]
        public string Hub { get; set; }

        [AutoResolve]
        public string UserId { get; set; }

        internal IEnumerable<Claim> GetClaims()
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(UserId))
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, UserId));
            }
            
            return claims;
        }
    }
}
