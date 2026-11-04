namespace Azure.Provisioning.SerialConsole
{
    public partial class SerialPort : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SerialPort(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SerialConsole.SerialPortConnectionState> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SerialConsole.SerialPortState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SerialConsole.SerialPort FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
        }
    }
    public enum SerialPortConnectionState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="active")]
        Active = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="inactive")]
        Inactive = 1,
    }
    public enum SerialPortState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
}
