// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Redis.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis
{
    // Mitigation for closed mgmt-generator bug
    // https://github.com/Azure/azure-sdk-for-net/issues/58288 — when a required
    // value-type field (here: `objectId: string` in the spec, mapped via
    // @@alternateType to Azure.Core.uuid → C# Guid) lives inside an optional
    // `properties?:` envelope, FlattenPropertyVisitor.PropertyFlatten failed to
    // surface a Guid? on the parent. ObjectIdAlias / AccessPolicyName (string,
    // already nullable) flatten correctly; ObjectId (Guid) is missing on the
    // generated parent. The fix landed upstream on 2026-04-24, but this repo's
    // emitter is still pinned to @azure-typespec/http-client-csharp-mgmt
    // 1.0.0-alpha.20260423.3 (one day before the fix).
    //
    // TODO: Once eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json
    // bumps to a build that includes the #58288 fix, regenerate, confirm
    // ObjectId appears as a flattened Guid? on the parent, and delete this file.
    public partial class RedisCacheAccessPolicyAssignmentData
    {
        /// <summary> Object Id to assign access policy to. </summary>
        [WirePath("properties.objectId")]
        public Guid? ObjectId
        {
            get
            {
                return Properties is null ? default(Guid?) : Properties.ObjectId;
            }
            set
            {
                if (value.HasValue)
                {
                    if (Properties is null)
                    {
                        Properties = new RedisCacheAccessPolicyAssignmentProperties();
                    }
                    Properties.ObjectId = value.Value;
                }
            }
        }
    }
}
