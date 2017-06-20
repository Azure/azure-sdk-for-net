// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for PhpVersion.
    /// </summary>
    public class PhpVersion : ExpandableStringEnum<PhpVersion>
    {
        public static readonly PhpVersion Off = Parse("null");
        public static readonly PhpVersion V5_5 = Parse("5.5");
        public static readonly PhpVersion V5_6 = Parse("5.6");
        public static readonly PhpVersion V7 = Parse("7.0");
        public static readonly PhpVersion V7_1 = Parse("7.1");
    }
}
