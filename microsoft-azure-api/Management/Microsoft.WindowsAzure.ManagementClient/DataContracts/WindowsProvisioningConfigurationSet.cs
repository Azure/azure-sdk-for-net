using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents the Windows provisioning configuration set.
    /// </summary>
    [DataContract(Name = "WindowsProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class WindowsProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        //this constructor is unused, and private so it won't be,
        //since this class is serialized only
        private WindowsProvisioningConfigurationSet() { }

        public WindowsProvisioningConfigurationSet(string computerName, SecureString adminPassword)
            : this(computerName, adminPassword, null)
        {
        }

        public WindowsProvisioningConfigurationSet(string computerName, SecureString adminPassword, DomainJoinInfo domainJoinInfo)
            : this(computerName, adminPassword, domainJoinInfo, null)
        {
        }

        public WindowsProvisioningConfigurationSet(string computerName, SecureString adminPassword, DomainJoinInfo domainJoinInfo, CertificateSettingCollection certificateSettingCollection)
            : this(computerName, adminPassword, domainJoinInfo, certificateSettingCollection, false, true, null)
        {
        }

        public WindowsProvisioningConfigurationSet(string computerName, SecureString adminPassword, DomainJoinInfo domainJoinInfo, CertificateSettingCollection certificateSettingCollection,
            bool resetPasswordOnFirstLogon, bool enableAutomaticUpdate, TimeZoneInfo timezone)
            : base (ConfigurationSetType.WindowsProvisioningConfiguration)
        {
            //TODO: Validate Params
            this.ComputerName = computerName;
            this.AdminPassword = adminPassword;
            this.ResetPasswordOnFirstLogon = resetPasswordOnFirstLogon;
            this.EnableAutomaticUpdate = enableAutomaticUpdate;
            this.TimeZone = timezone == null ? null : timezone.Id;
        }

        [DataMember(Order = 0, IsRequired = true)]
        public string ComputerName { get; private set; }

        public SecureString AdminPassword { get; private set; }

        [DataMember(Name = "AdminPassword", Order = 1, IsRequired = true)]
        //this is set as we serialize and immediately reset after
        //gets base64 encoded on the wire...
        private string _insecurePassword;

        //while technically not required in the request,
        //these two bools will always be set, so might as well serialize them
        [DataMember(Order=2, IsRequired=true)]
        public bool ResetPasswordOnFirstLogon { get; private set; }

        [DataMember(Order=3, IsRequired=true)]
        public bool EnableAutomaticUpdate { get; private set; }

        [DataMember(Order=4, IsRequired=false, EmitDefaultValue=false)]
        public string TimeZone { get; private set; }

        [DataMember(Order=5, IsRequired=false, EmitDefaultValue=false)]
        public DomainJoinInfo DomainJoin { get; private set; }

        [DataMember(Order=6, IsRequired=false, EmitDefaultValue=false)]
        public CertificateSettingCollection StoredCertificateSettings { get; private set; }

        //Since the pwd comes in as a SecureString we attempt
        //to minimize the time the actual password spends in memory
        //we read it into native memory as a BSTR. From there we copy it into a 
        //char array (which we then zero out along with the bstr).
        //We could copy to a string which leaves it in memory for an indeteminate time
        //subject to GC, or, on the flip-side we could leave it as a char* which would 
        //necessitate unsafe code and make this CPU architecture dependent (which we also 
        //don't want).
        //So we copy to a char[] which then gets marshalled to a base64 string. 
        //That string *is* subject to GC, and if you could get your hands on it you could
        //decode it to the pwd, but we think this is obscured enough to be OK...
        [OnSerializing]
        private void SerializePassword(StreamingContext context)
        {
            this._insecurePassword = this.AdminPassword.EncodeBase64();
        }

        [OnSerialized]
        private void ClearPassword(StreamingContext contest)
        {
            this._insecurePassword = null;
        }
    }
}
