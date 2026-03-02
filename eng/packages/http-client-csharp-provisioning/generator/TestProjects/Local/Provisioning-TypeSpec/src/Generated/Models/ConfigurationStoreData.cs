
namespace Azure.Provisioning.ProvisioningTypeSpec
{
    /// <summary></summary>
    public partial class ConfigurationStoreData : Provisioning.Primitives.ProvisionableConstruct
    {
        private ConfigurationStoreProperties _properties;

        /// <summary> Creates a new ConfigurationStoreData. </summary>
        public ConfigurationStoreData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        public ConfigurationStoreProperties Properties
        {
            get
            {
                this.Initialize();
                return _properties;
            }
            set
            {
                this.Initialize();
                this.AssignOrReplace(ref _properties, value);
            }
        }

        /// <summary> Define all the provisionable properties for ConfigurationStoreData. </summary>
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _properties = this.DefineModelProperty<ConfigurationStoreProperties>("Properties", new string[] { "properties" });
        }
    }
}
