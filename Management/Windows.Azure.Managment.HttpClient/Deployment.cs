using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

//disable warning about field never assigned to. It gets assigned at deserialization time
#pragma warning disable 649

namespace Windows.Azure.Management.v1_7
{
    [DataContract]
    public enum DeploymentSlot
    {
        [EnumMember]
        Production,

        [EnumMember]
        Staging
    }

    [DataContract(Name = "Status")]
    public enum DeploymentStatus
    {
        [EnumMember]
        Unavailable,

        [EnumMember]
        Running,

        [EnumMember]
        Suspended,

        [EnumMember]
        RunningTransitioning,

        [EnumMember]
        SuspendedTransistioning,

        [EnumMember]
        Starting,

        [EnumMember]
        Suspending,

        [EnumMember]
        Deploying,

        [EnumMember]
        Deleting,
    }

    [DataContract]
    public enum InstanceStatus
    {
        [EnumMember(Value = "RoleStateUnknown")]
        Unknown,

        [EnumMember]
        CreatingVM,

        [EnumMember]
        StartingVM,

        [EnumMember]
        CreatingRole,

        [EnumMember]
        StartingRole,

        [EnumMember]
        ReadyRole,

        [EnumMember]
        BusyRole,

        [EnumMember]
        StoppingRole,

        [EnumMember]
        StoppingVM,

        [EnumMember]
        DeletingVM,

        [EnumMember]
        StoppedVM,

        [EnumMember]
        RestartingRole,

        [EnumMember]
        CyclingRole,

        [EnumMember]
        FailedStartingVM,

        [EnumMember]
        UnresponsiveRole
    }

    [DataContract]
    public enum UpgradeType
    {
        [EnumMember]
        Auto,

        [EnumMember]
        Manual
    }

    [DataContract]
    public enum UpgradeDomainState
    {
        [EnumMember]
        Before,

        [EnumMember]
        During
    }

    [DataContract]
    public enum PowerState
    {
        [EnumMember]
        Unknown,

        [EnumMember]
        Starting,

        [EnumMember]
        Started,

        [EnumMember]
        Stopping,

        [EnumMember]
        Stopped
    }

    [DataContract(Name = "Deployment", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class Deployment : AzureDataContractBase
    {
        private Deployment() { }

        [DataMember(Order = 0)]
        public String Name { get; private set; }

        [DataMember(Order = 1)]
        public DeploymentSlot DeploymentSlot { get; private set; }

        [DataMember(Order = 2)]
        public String PrivateID { get; private set; }

        [DataMember(Order = 3)]
        public DeploymentStatus Status { get; private set; }

        //TODO: store decoded like config? It is small...
        public String Label { get { return this._label.DecodeBase64(); } }

        [DataMember(Name = "Label", Order = 4)]
        private String _label;

        [DataMember(Order = 5)]
        public Uri Url { get; private set; }

        //TODO: XDocument instead?
        public String Configuration
        {
            get
            {
                if (_decodedConfig == null)
                {
                    _decodedConfig = this._config.DecodeBase64();
                }
                return this._decodedConfig;
            }
        }

        [DataMember(Name = "Configuration", Order = 6)]
        private String _config;

        private String _decodedConfig;

        [DataMember(Name = "RoleInstanceList", Order = 7)]
        public List<RoleInstance> RoleInstances { get; private set; }

        [DataMember(Order = 8, EmitDefaultValue = false, IsRequired = false)]
        public UpgradeStatus UpgradeStatus { get; private set; }

        [DataMember(Order = 9)]
        public Int32 UpgradeDomainCount { get; private set; }

        [DataMember(Name = "RoleList", Order = 10)]
        public List<Role> Roles { get; private set; }

        [DataMember(Order = 11)]
        public String SdkVersion { get; private set; }

        [DataMember(Order = 13)]
        public Boolean Locked { get; private set; }

        [DataMember(Order = 14)]
        public Boolean RollbackAllowed { get; private set; }

        [DataMember(Order = 15, IsRequired = false, EmitDefaultValue = false)]
        public String VirtualNetworkName { get; private set; }

        [DataMember(Order = 16)]
        public DateTime CreatedTime { get; private set; }

        [DataMember(Order = 17)]
        public DateTime LastModifiedTime { get; private set; }

        [DataMember(Order = 18)]
        public ExtendedPropertyCollection ExtendedProperties { get; private set; }

        [DataMember(Order = 19, IsRequired = false, EmitDefaultValue = false)]
        public DnsSettings DnsSettings { get; private set; }

        [DataMember(Order = 20, IsRequired = false, EmitDefaultValue = false)]
        public PersistentVMDowntimeInfo PersistentVMDowntime { get; private set; }
    }

    [DataContract(Name = "RoleInstance", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class RoleInstance : AzureDataContractBase
    {
        private RoleInstance()
        {
        }

        [DataMember(Order = 0)]
        public String RoleName { get; private set; }

        [DataMember(Name = "InstanceName", Order = 1)]
        public String Name { get; private set; }

        [DataMember(Name = "InstanceStatus", Order = 2)]
        public InstanceStatus Status { get; private set; }

        [DataMember(Name = "InstanceUpgradeDomain", Order = 3)]
        public Int32 UpgradeDomain { get; private set; }

        [DataMember(Name = "InstanceFaultDomain", Order = 4)]
        public Int32 FaultDomain { get; private set; }

        [DataMember(Name = "InstanceSize", Order = 5)]
        public String Size { get; private set; } //TODO: Enum?

        [DataMember(Name = "InstanceStateDetails", Order = 6, IsRequired=false, EmitDefaultValue=false)]
        public String StateDetails { get; private set; }

        [DataMember(Name = "InstanceErrorCode", Order = 7, IsRequired = false, EmitDefaultValue = false)]
        public String ErrorCode { get; private set; }

        [DataMember(Name = "IpAddress", Order = 8, IsRequired = false, EmitDefaultValue = false)]
        public String IPAddress { get; private set; }

        [DataMember(Order = 9, IsRequired = false, EmitDefaultValue = false)]
        public List<InstanceEndpoint> InstanceEndpoints { get; private set; }

        [DataMember(Order = 10, IsRequired = false, EmitDefaultValue = false)]
        public PowerState PowerState { get; private set; }

        [DataMember(Order = 11, IsRequired = false, EmitDefaultValue = false)]
        public String HostName { get; private set; }

    }

    [DataContract(Name = "Role", Namespace = AzureConstants.AzureSchemaNamespace)]
    [KnownType(typeof(PersistentVMRole))]
    public class Role : AzureDataContractBase
    {
        protected Role() {}

        [DataMember(Name = "RoleName", Order = 0)]
        public String Name { get; private set; }

        [DataMember(Order = 1)]
        public String OsVersion { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public String RoleType { get; private set; } //TODO: Enum?

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        public List<ConfigurationSet> ConfigurationSets { get; private set; }

        //NOTE: MS.Samples... has a ReadWrite property called "NetworkConfigurationSet" that sets and gets from the ConfigSet colleciont
        //not sure what good the "set" is...
    }

    //Configuration set has multiple sub classes. 
    [DataContract(Name = "ConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    [KnownType(typeof(NetworkConfigurationSet))]
    [KnownType(typeof(ProvisioningConfigurationSet))]
    [KnownType(typeof(WindowsProvisioningConfigurationSet))]
    [KnownType(typeof(LinuxProvisioningConfigurationSet))]
    [KnownType(typeof(GenericProvisioningConfigurationSet))]
    public abstract class ConfigurationSet : AzureDataContractBase
    {
        #region Public Properties
        [DataMember(Order = 0)]
        public String ConfigurationSetType { get; private set; }
        #endregion

        //NOTE: MS.Samples... has a "ResolveType" method
    }

    [DataContract(Name = "NetworkConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class NetworkConfigurationSet : ConfigurationSet
    {
        private NetworkConfigurationSet()
        {
        }

        #region Public Properties
        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public List<InputEndpoint> InputEndpoints { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public List<String> SubnetNames { get; private set; }
        #endregion
    }

    //there are other configuration set types, which I'm not going to fill in right now.
    //they need to exist as known types if serialization is going to work, if they show up...
    [DataContract(Name = "ProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public abstract class ProvisioningConfigurationSet : ConfigurationSet
    {
    }

    [DataContract(Name = "WindowsProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class WindowsProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        private WindowsProvisioningConfigurationSet() { }
    }

    [DataContract(Name = "LinuxProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class LinuxProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        private LinuxProvisioningConfigurationSet() { }
    }

    [DataContract(Name = "GenericProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class GenericProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        private GenericProvisioningConfigurationSet() { }
    }

    [DataContract(Name = "InputEndpoint", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class InputEndpoint : AzureDataContractBase
    {
        private InputEndpoint()
        {
        }

        #region Public Properties
        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public String LoadBalancedEndpointSetName { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public Int32 LocalPort { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public String Name { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        public Int32 Port { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        public LoadBalancerProbe LoadBalancerProbe { get; private set; }

        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        public String Protocol { get; private set; }

        [DataMember(Order = 6, Name = "Vip", IsRequired = false, EmitDefaultValue = false)]
        public String VirtualIPAddress { get; private set; }
        #endregion
    }

    [DataContract(Name = "InstanceEndpoint", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class InstanceEndpoint : AzureDataContractBase
    {
        private InstanceEndpoint() { }

        [DataMember(Order = 0)]
        public String Name { get; private set; }

        [DataMember(Name = "Vip", Order = 1)]
        public String VirtualIPAddress { get; private set; }

        [DataMember(Order = 2)]
        public Int32 PublicPort { get; private set; }

        [DataMember(Order = 3)]
        public Int32 LocalPort { get; private set; }

        [DataMember(Order = 4)]
        public String Protocol { get; private set; }
    }

    [DataContract(Name = "UpgradeStatus", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class UpgradeStatus : AzureDataContractBase
    {
        private UpgradeStatus() { }

        [DataMember(Name = "UpgradeType", Order = 0)]
        public UpgradeType Type { get; private set; }

        [DataMember(Order = 1)]
        public UpgradeDomainState CurrentUpgradeDomainState { get; private set; }

        [DataMember(Order = 2)]
        public Int32 CurrentUpgradeDomain { get; private set; }
    }

    [DataContract(Name = "LoadBalancerProbe", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class LoadBalancerProbe : AzureDataContractBase
    {
        private LoadBalancerProbe() { }

        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public String Path { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public Int32 Port { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public String Protocol { get; private set; }


    }

    [DataContract(Name = "DnsSettings", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class DnsSettings : AzureDataContractBase
    {
        private DnsSettings() { }

        [DataMember(Order=0)]
        public List<DnsServer> DnsServers { get; set; }
    }

    [DataContract(Name = "PersistentVMDowntimeInfo", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class PersistentVMDowntimeInfo : AzureDataContractBase
    {
        private PersistentVMDowntimeInfo() { }

        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public DateTime StartTime { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public DateTime EndTime { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public String Status { get; private set; }
    }

    [DataContract(Name = "DnsServer", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class DnsServer : AzureDataContractBase
    {
        private DnsServer() { }

        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public String Name { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public String Address { get; private set; }
    }

    //TODO: Fill this in...
    [DataContract(Name = "PersistentVMRole", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class PersistentVMRole : Role
    {
        private PersistentVMRole() { }
    }
}
