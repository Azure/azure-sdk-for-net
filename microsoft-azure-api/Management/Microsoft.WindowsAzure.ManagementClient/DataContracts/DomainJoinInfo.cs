using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "DomainJoin", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class DomainJoinInfo : AzureDataContractBase
    {
        //TODO: Validation!
        public static DomainJoinInfo CreateLdapDomainJoinInfo(string ldapDistinguishedName, string accountData)
        {
            return new DomainJoinInfo
            {
                _provisioning = new Provisioning { AccountData = accountData },
                MachineOrganizationalUnitDistinguishedName = ldapDistinguishedName
            };
        }

        public static DomainJoinInfo CreateLdapDomainJoinInfoWithCredentials(string ldapDistinguishedName, string userDomain, string userName, SecureString password)
        {
            return new DomainJoinInfo
            {
                _credentials = new Credentials { Domain = userDomain, UserName = userName, _securePassword = password },
                MachineOrganizationalUnitDistinguishedName = ldapDistinguishedName
            };
        }

        public static DomainJoinInfo CreateDomainJoinInfo(string domainToJoin, string accountData)
        {
            return new DomainJoinInfo
            {
                _provisioning = new Provisioning { AccountData = accountData },
                DomainToJoin = domainToJoin
            };
        }

        public static DomainJoinInfo CreateDomainJoinInfoWithCredentials(string domainToJoin, string userDomain, string userName, SecureString password)
        {
            return new DomainJoinInfo
            {
                _credentials = new Credentials { Domain = userDomain, UserName = userName, _securePassword = password },
                DomainToJoin = domainToJoin
            };
        }

        [DataMember(Name="Provisioning", Order = 0, IsRequired=false, EmitDefaultValue=false)]
        private Provisioning _provisioning;

        [DataMember(Name="Credentials", Order=0, IsRequired=false, EmitDefaultValue=false)]
        private Credentials _credentials;

        public string ProvisioningAccountInfo { get { return this._provisioning == null ? null : this._provisioning.AccountData; } }

        public string UserDomain { get { return this._credentials == null ? null : this._credentials.Domain; } }

        public string UserName { get { return this._credentials == null ? null : this._credentials.UserName; } }

        public SecureString Password { get { return this._credentials == null ? null : this._credentials._securePassword; } }

        [DataMember(Name="JoinDomain", Order = 1, IsRequired=false, EmitDefaultValue=false)]
        public string DomainToJoin { get; private set; }

        [DataMember(Name = "MachineObjectOU", Order = 1, IsRequired=false, EmitDefaultValue=false)]
        public string MachineOrganizationalUnitDistinguishedName { get; private set; }

        [DataContract(Name = "Provisioning", Namespace = AzureConstants.AzureSchemaNamespace)]
        private class Provisioning : AzureDataContractBase
        {
            [DataMember(IsRequired=true)]
            internal string AccountData { get; set; }
        }

        [DataContract(Name = "Credentials", Namespace = AzureConstants.AzureSchemaNamespace)]
        private class Credentials : AzureDataContractBase
        {
            [DataMember(Order = 0, IsRequired=false, EmitDefaultValue=false)]
            internal string Domain { get; set; }

            [DataMember(Order = 1, IsRequired=true)]
            internal string UserName { get; set; }

            internal SecureString _securePassword;

            //this method is set during serialization and immediately reset after
            [DataMember(Name="Password", Order = 2, IsRequired=false, EmitDefaultValue=false)]
            private string _insecurePassword;

            [OnSerializing]
            private void SerializePassword(StreamingContext context)
            {
                this._insecurePassword = this._securePassword.EncodeBase64();
            }

            [OnSerialized]
            private void ClearPassword(StreamingContext contest)
            {
                this._insecurePassword = null;
            }
        }
    }
}
