// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for NetFrameworkVersion.
    /// </summary>
    public class NetFrameworkVersion : ExpandableStringEnum<NetFrameworkVersion>
    {
        public static readonly NetFrameworkVersion V3_0 = Parse("v3.0");
        public static readonly NetFrameworkVersion V4_6 = Parse("v4.6");
    }
}
