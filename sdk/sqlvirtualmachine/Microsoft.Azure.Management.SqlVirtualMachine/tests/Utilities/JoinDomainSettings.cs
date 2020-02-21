// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities
{
    public class JoinDomainSettings
    {
        public string Name { get; set; }
        public string OUPath { get; set; }
        public string User { get; set; }
        public string Restart { get; set; }
        public string Options { get; set; }
    }

    public class JoinDomainProtectedSettings
    {
        public string Password { get; set; }
    }
}
