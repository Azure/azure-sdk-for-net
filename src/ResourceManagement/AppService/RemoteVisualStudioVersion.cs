// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for RemoteVisualStudioVersion.
    /// </summary>
    public class RemoteVisualStudioVersion : ExpandableStringEnum<RemoteVisualStudioVersion>
    {
        public static readonly RemoteVisualStudioVersion VS2012 = Parse("VS2012");
        public static readonly RemoteVisualStudioVersion VS2013 = Parse("VS2013");
        public static readonly RemoteVisualStudioVersion VS2015 = Parse("VS2015");
    }
}
