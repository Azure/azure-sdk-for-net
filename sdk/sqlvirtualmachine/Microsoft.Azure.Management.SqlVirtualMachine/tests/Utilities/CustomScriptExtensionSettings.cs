// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities
{
    public class CustomScriptExtensionSettings
    {
        public List<string> FileUris { get; set; }
        public string CommandToExecute { get; set; }
        public string ContentVersion { get; set; }
    }
}
