// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Active Directory. </summary>
    public partial class NetAppAccountActiveDirectory
    {
        internal NetAppAccountActiveDirectory(string activeDirectoryId, string username, string password, string domain, string dns, NetAppAccountActiveDirectoryStatus? status, string statusDetails, string smbServerName, string organizationalUnit, string site, IList<string> backupOperators, IList<string> administrators, IPAddress kdcIP, string adName, string serverRootCACertificate, bool? aesEncryption, bool? ldapSigning, IList<string> securityOperators, bool? ldapOverTLS, bool? allowLocalNfsUsersWithLdap, bool? encryptDCConnections, NetAppLdapSearchScopeConfiguration ldapSearchScope, string preferredServersForLdapClient, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
        }
    }
}
