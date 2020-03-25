// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities
{
    public class DomainSettings
    {
        public string ModulesURL { get; set; }
        public string ConfigurationFunction { get; set; }
        public DomainProperties Properties { get; set; }
    }

    public class DomainProperties
    {
        public string DomainName { get; set; }
        public DomainAdminCredentials Admincreds { get; set; }
    }

    public class DomainAdminCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class DomainProtectedSettings
    {
        public DomainProtectedSettingsItems Items { get; set; } 
    }

    public class DomainProtectedSettingsItems
    {
        public string AdminPassword { get; set; }
    }
}
