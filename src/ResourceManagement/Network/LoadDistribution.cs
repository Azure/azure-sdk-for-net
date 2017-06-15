// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for LoadDistribution.
    /// </summary>
    public class LoadDistribution : ExpandableStringEnum<LoadDistribution>
    {
        public static readonly LoadDistribution Default = Parse("Default");
        public static readonly LoadDistribution SourceIP = Parse("SourceIP");
        public static readonly LoadDistribution SourceIPProtocol = Parse("SourceIPProtocol");
    }
}

