// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class AssociationType : ExpandableStringEnum<AssociationType>
    {
        public static readonly AssociationType Associated = Parse("Associated");
        public static readonly AssociationType Contains = Parse("Contains");
    }
}
