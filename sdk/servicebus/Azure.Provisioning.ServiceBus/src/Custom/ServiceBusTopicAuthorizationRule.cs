// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.ServiceBus;

public partial class ServiceBusTopicAuthorizationRule
{
    public static partial class ResourceVersions
    {
        // Preserve historical API versions that shipped from the reflection-based provisioning generator.
        /// <summary> API version "2014-09-01". </summary>
        public static readonly string V2014_09_01 = "2014-09-01";
        /// <summary> API version "2015-08-01". </summary>
        public static readonly string V2015_08_01 = "2015-08-01";
        /// <summary> API version "2017-04-01". </summary>
        public static readonly string V2017_04_01 = "2017-04-01";
        /// <summary> API version "2021-11-01". </summary>
        public static readonly string V2021_11_01 = "2021-11-01";
        /// <summary> API version "2024-01-01". </summary>
        public static readonly string V2024_01_01 = "2024-01-01";
    }

    // The TypeSpec provisioning generator does not emit custom action helpers yet.
    // Preserve the shipped GetKeys() convenience API until action generation is supported.
    /// <summary> Get access keys for this ServiceBusTopicAuthorizationRule resource. </summary>
    /// <returns> The keys for this ServiceBusTopicAuthorizationRule resource. </returns>
    public ServiceBusAccessKeys GetKeys()
    {
        ServiceBusAccessKeys keys = new();
        ((IBicepValue)keys).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
        return keys;
    }
}
