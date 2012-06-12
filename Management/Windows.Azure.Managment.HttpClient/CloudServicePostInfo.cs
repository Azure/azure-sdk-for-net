using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;

namespace Windows.Azure.Management.v1_7
{

    [DataContract(Name= "UpdateHostedService", Namespace = AzureConstants.AzureSchemaNamespace)]
    class UpdateCloudServiceInfo : AzureDataContractBase
    {
        //private constructor, use Create factory method to create, q.v.
        private UpdateCloudServiceInfo()
        {
        }

        internal static UpdateCloudServiceInfo Create(
            String label, String description, String location, String affinityGroup, IDictionary<String,String> extendedProperties)
        {
            Validation.ValidateAllNotNull(label, description, location, affinityGroup, extendedProperties);
            Validation.ValidateLabel(label, true);
            Validation.ValidateDescription(description);

            if(!String.IsNullOrEmpty(location) || !String.IsNullOrEmpty(affinityGroup))
            {
                Validation.ValidateLocationOrAffinityGroup(location, affinityGroup);
            }

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new UpdateCloudServiceInfo
            {
                Label = String.IsNullOrEmpty(label) ? null : label.EncodeBase64(),
                Description = description,
                Location = location,
                AffinityGroup = affinityGroup,
                ExtendedProperties = collection
            };
        }

        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        internal String Label { get; private set; }

        [DataMember(Order=1, IsRequired=false, EmitDefaultValue=false)]
        internal String Description { get; private set; }

        [DataMember(Order=2, IsRequired=false, EmitDefaultValue=false)]
        internal String Location { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        internal String AffinityGroup { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }
    }

    [DataContract(Name = "CreateHostedService", Namespace = AzureConstants.AzureSchemaNamespace)]
    class CreateCloudServiceInfo : AzureDataContractBase
    {
        //private constructor, use Create factory method to create, q.v.
        private CreateCloudServiceInfo()
        {
        }

        internal static CreateCloudServiceInfo Create(
            String name, String label, String description,
            String location, String affinityGroup, IDictionary<String,String> extendedProperties)
        {
            Validation.ValidateStringArg(name, "name");
            Validation.ValidateLabel(label);
            Validation.ValidateDescription(description);
            Validation.ValidateLocationOrAffinityGroup(location, affinityGroup);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new CreateCloudServiceInfo
            {
                Name = name,
                Label = label.EncodeBase64(),
                Description = description,
                Location = location,
                AffinityGroup = affinityGroup,
                ExtendedProperties = collection
            };
        }

        [DataMember(Name="ServiceName", Order = 0, IsRequired = true)]
        internal String Name { get; private set; }

        [DataMember(Order = 1, IsRequired=true)]
        internal String Label { get; private set; }

        [DataMember(Order = 2, IsRequired=false, EmitDefaultValue=false)]
        internal String Description { get; private set; }

        [DataMember(Order = 3, IsRequired=false, EmitDefaultValue=false)]
        internal String Location { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue=false)]
        internal String AffinityGroup { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }
    }

    //Class used to post to CreateDeployment
    //it is not exposed to callers, so marked internal
    [DataContract(Name = "CreateDeployment", Namespace = AzureConstants.AzureSchemaNamespace)]
    class CreateDeploymentInfo : AzureDataContractBase
    {
        private const Int32 LabelMax = 100;

        //private constructor, use Create factory method to create, q.v.
        private CreateDeploymentInfo()
        {
        }

        internal static CreateDeploymentInfo Create(
            String name, Uri packageUrl, String label, 
            String configPath, Boolean startDeployment = false, 
            Boolean treatWarningsAsError = false,
            ExtendedPropertyCollection extendedProperties = null)
        {
            Validation.ValidateStringArg(name, "name");
            Validation.NotNull(packageUrl, "packageUrl");
            Validation.ValidateLabel(label);
            Validation.ValidateStringArg(configPath, "configPath");
            if (!File.Exists(configPath)) throw new FileNotFoundException(String.Format(Resources.ConfigFileNotFound, configPath), configPath);

            string configText = File.ReadAllText(configPath);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new CreateDeploymentInfo
            {
                Name = name,
                PackageUrl = packageUrl,
                Label = label.EncodeBase64(),
                Configuration = configText.EncodeBase64(),
                StartDeployment = startDeployment,
                TreatWarningsAsError = treatWarningsAsError,
                ExtendedProperties = extendedProperties
            };
        }

        [DataMember(Order = 0, IsRequired=true)]
        internal String Name { get; private set;}

        [DataMember(Order = 1, IsRequired = true)]
        internal Uri PackageUrl { get; private set; }

        //NOTE: this must be base64 encoded, see Create factory method
        [DataMember(Order = 2, IsRequired = true)]
        internal String Label { get; private set; }

        //NOTE: this must be base64 encoded, see Create factory method
        [DataMember(Order = 3, IsRequired = true)]
        internal String Configuration { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        internal Boolean StartDeployment { get; private set; }

        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        internal Boolean TreatWarningsAsError { get; private set; }

        [DataMember(Order = 6, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }

    }

    [DataContract(Name = "Swap", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class VipSwapInfo : AzureDataContractBase
    {
        private VipSwapInfo() { }

        internal static VipSwapInfo Create(String productionName, String stagingName)
        {
            //production allowed to be null...
            Validation.ValidateStringArg(stagingName, "stagingName");

            return new VipSwapInfo
            {
                Production = productionName,
                Staging = stagingName
            };
        }

        [DataMember(Order = 0, IsRequired=false, EmitDefaultValue=false)]
        internal String Production { get; private set; }

        [DataMember(Name="SourceDeployment", Order = 1)]
        internal String Staging { get; private set; }
    }

    [DataContract(Name = "ChangeConfiguration", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class ChangeDeploymentConfigurationInfo : AzureDataContractBase
    {
        private ChangeDeploymentConfigurationInfo()
        {
        }

        internal static ChangeDeploymentConfigurationInfo Create(String configFilePath, Boolean treatWarningsAsError, UpgradeType mode, IDictionary<String, String> extendedProperties)
        {
            Validation.ValidateStringArg(configFilePath, "configuration");
            if (!File.Exists(configFilePath)) throw new FileNotFoundException(String.Format(Resources.ConfigFileNotFound, configFilePath), configFilePath);

            string configText = File.ReadAllText(configFilePath);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new ChangeDeploymentConfigurationInfo
            {
                Configuration = configText.EncodeBase64(),
                TreatWarningsAsError = treatWarningsAsError,
                Mode = mode
            };
        }

        [DataMember(Order = 0, IsRequired=true)]
        internal String Configuration { get; private set; }

        [DataMember(Order = 1, Name = "TreatWarningAsError", IsRequired = false, EmitDefaultValue = false)]
        internal Boolean TreatWarningsAsError { get; private set; }

        [DataMember(Order = 2, Name="Mode", IsRequired = false, EmitDefaultValue = false)]
        internal UpgradeType Mode { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }

    }

    [DataContract(Name = "UpdateDeploymentStatus", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class UpdateDeploymentStatusInfo : AzureDataContractBase
    {
        private UpdateDeploymentStatusInfo()
        {
        }

        internal static UpdateDeploymentStatusInfo Create(bool startDeployment)
        {
            return new UpdateDeploymentStatusInfo
            {
                Status = startDeployment ? DeploymentStatus.Running : DeploymentStatus.Suspended
            };
        }

        [DataMember]
        internal DeploymentStatus Status { get; private set; }
    }

    [DataContract(Name = "UpdateDeployment", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class UpgradeDeploymentInfo : AzureDataContractBase
    {
        private UpgradeDeploymentInfo()
        {
        }

        internal static UpgradeDeploymentInfo Create(UpgradeType mode, Uri packageUrl, String configFilePath, String label, String roleToUpgrade, Boolean treatWarningsAsError, Boolean force, IDictionary<string, string> extendedProperties)
        {
            Validation.NotNull(packageUrl, "packageUrl");
            Validation.ValidateLabel(label);
            Validation.ValidateStringArg(configFilePath, "configPath");
            if (!File.Exists(configFilePath)) throw new FileNotFoundException(String.Format(Resources.ConfigFileNotFound, configFilePath), configFilePath);

            string configText = File.ReadAllText(configFilePath);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new UpgradeDeploymentInfo
            {
                Mode = mode,
                PackageUrl = packageUrl,
                Configuration = configText.EncodeBase64(),
                Label = label.EncodeBase64(),
                RoleToUpgrade = roleToUpgrade,
                TreatWarningsAsError = treatWarningsAsError,
                Force = force,
                ExtendedProperties = collection
            };
        }

        [DataMember(Order = 0, IsRequired=true)]
        internal UpgradeType Mode { get; private set; }

        [DataMember(Order = 1, IsRequired=true)]
        internal Uri PackageUrl { get; private set; }

        [DataMember(Order=2, IsRequired=true)]
        internal String Configuration { get; private set; }

        [DataMember(Order=3, IsRequired=true)]
        internal String Label { get; private set; }

        [DataMember(Order=4, IsRequired=false, EmitDefaultValue=false)]
        internal String RoleToUpgrade { get; private set; }

        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        internal Boolean TreatWarningsAsError { get; private set; }

        [DataMember(Order=5, IsRequired=false, EmitDefaultValue=false)]
        internal Boolean Force { get; private set; }

        [DataMember(Order = 6, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }
    }

    [DataContract(Name = "WalkUpgradeDomain", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class WalkUpgradeDomainInfo : AzureDataContractBase
    {
        private WalkUpgradeDomainInfo()
        {
        }

        internal static WalkUpgradeDomainInfo Create(Int32 upgradeDomain)
        {
            return new WalkUpgradeDomainInfo
            {
                UpgradeDomain = upgradeDomain
            };
        }

        [DataMember]
        internal Int32 UpgradeDomain { get; private set; }
    }

}
