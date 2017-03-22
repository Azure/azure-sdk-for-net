// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewayOperationalState : ExpandableStringEnum<ApplicationGatewayOperationalState>
    {
        public static readonly ApplicationGatewayOperationalState Stopped = Parse("Stopped");
        public static readonly ApplicationGatewayOperationalState Starting = Parse("Starting");
        public static readonly ApplicationGatewayOperationalState Running = Parse("Running");
        public static readonly ApplicationGatewayOperationalState Stopping = Parse("Stopping");
    }
}
