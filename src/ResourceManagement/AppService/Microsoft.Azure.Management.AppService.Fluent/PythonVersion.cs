// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for PythonVersion.
    /// </summary>
    public class PythonVersion : ExpandableStringEnum<PythonVersion>
    {
        public static readonly PythonVersion Off = Parse("null");
        public static readonly PythonVersion V27 = Parse("2.7");
        public static readonly PythonVersion V34 = Parse("3.4");
    }
}
