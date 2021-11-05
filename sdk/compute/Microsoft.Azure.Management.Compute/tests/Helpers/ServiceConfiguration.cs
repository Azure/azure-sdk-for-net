// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Compute.Tests
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration", IsNullable = false)]
    public partial class ServiceConfiguration
    {

        private ServiceConfigurationRole[] roleField;

        private ServiceConfigurationNetworkConfiguration networkConfigurationField;

        private Setting[] serviceSettingsField;

        private string serviceNameField;

        private string osFamilyField;

        private string osVersionField;

        private string schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration", IsNullable = false)]
        public ServiceConfigurationRole[] Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }

        /// <remarks/>
        public ServiceConfigurationNetworkConfiguration NetworkConfiguration
        {
            get { return this.networkConfigurationField; }
            set { this.networkConfigurationField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string serviceName
        {
            get
            {
                return this.serviceNameField;
            }
            set
            {
                this.serviceNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string osFamily
        {
            get
            {
                return this.osFamilyField;
            }
            set
            {
                this.osFamilyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string osVersion
        {
            get
            {
                return this.osVersionField;
            }
            set
            {
                this.osVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Setting", IsNullable = true)]
        public Setting[] ServiceSettings
        {
            get
            {
                return this.serviceSettingsField;
            }
            set
            {
                this.serviceSettingsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationRole
    {

        private ServiceConfigurationRoleInstances instancesField;

        private ServiceConfigurationRoleSetting[] configurationSettingsField;

        private ServiceConfigurationRoleCertificate[] certificatesField;

        private ServiceConfigurationRoleSecurityConfigurations securityConfigurationsField;

        private string nameField;

        /// <remarks/>
        public ServiceConfigurationRoleInstances Instances
        {
            get
            {
                return this.instancesField;
            }
            set
            {
                this.instancesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Setting", IsNullable = false)]
        public ServiceConfigurationRoleSetting[] ConfigurationSettings
        {
            get
            {
                return this.configurationSettingsField;
            }
            set
            {
                this.configurationSettingsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Certificate", IsNullable = false)]
        public ServiceConfigurationRoleCertificate[] Certificates
        {
            get
            {
                return this.certificatesField;
            }
            set
            {
                this.certificatesField = value;
            }
        }

        /// <remarks/>
        public ServiceConfigurationRoleSecurityConfigurations SecurityConfigurations
        {
            get
            {
                return this.securityConfigurationsField;
            }
            set
            {
                this.securityConfigurationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationRoleInstances
    {

        private string countField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationRoleSetting
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationRoleCertificate
    {

        private string nameField;

        private string thumbprintField;

        private string thumbprintAlgorithmField;

        private string sourceLocationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string thumbprint
        {
            get
            {
                return this.thumbprintField;
            }
            set
            {
                this.thumbprintField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string thumbprintAlgorithm
        {
            get
            {
                return this.thumbprintAlgorithmField;
            }
            set
            {
                this.thumbprintAlgorithmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sourceLocation
        {
            get
            {
                return this.sourceLocationField;
            }
            set
            {
                this.sourceLocationField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationNetworkConfiguration
    {

        private ServiceConfigurationNetworkConfigurationVirtualNetworkSite virtualNetworkSiteField;

        private ServiceConfigurationNetworkConfigurationAddressAssignments addressAssignmentsField;

        /// <remarks/>
        public ServiceConfigurationNetworkConfigurationVirtualNetworkSite VirtualNetworkSite
        {
            get { return this.virtualNetworkSiteField; }
            set { this.virtualNetworkSiteField = value; }
        }

        /// <remarks/>
        public ServiceConfigurationNetworkConfigurationAddressAssignments AddressAssignments
        {
            get { return this.addressAssignmentsField; }
            set { this.addressAssignmentsField = value; }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationNetworkConfigurationVirtualNetworkSite
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationNetworkConfigurationAddressAssignments
    {

        private ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddress[] instanceAddressField;
        private ServiceConfigurationNetworkConfigurationAddressAssignmentsReservedIPs reservedIPField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration", IsNullable = false)]
        public ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddress[] InstanceAddress
        {
            get { return this.instanceAddressField; }
            set { this.instanceAddressField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get { return this.textField; }
            set { this.textField = value; }
        }

        /// <remarks/>
        public ServiceConfigurationNetworkConfigurationAddressAssignmentsReservedIPs ReservedIPs
        {
            get
            {
                return this.reservedIPField;
            }
            set
            {
                this.reservedIPField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationNetworkConfigurationAddressAssignmentsReservedIPs
    {

        private ServiceConfigurationNetworkConfigurationAddressAssignmentsReservedIPsReservedIP reservedIPField;

        /// <remarks/>
        public ServiceConfigurationNetworkConfigurationAddressAssignmentsReservedIPsReservedIP ReservedIP
        {
            get
            {
                return this.reservedIPField;
            }
            set
            {
                this.reservedIPField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationNetworkConfigurationAddressAssignmentsReservedIPsReservedIP
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddress
    {

        private ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddressSubnets subnetsField;

        private string roleNameField;

        /// <remarks/>
        public ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddressSubnets Subnets
        {
            get { return this.subnetsField; }
            set { this.subnetsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string roleName
        {
            get { return this.roleNameField; }
            set { this.roleNameField = value; }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddressSubnets
    {

        private ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddressSubnetsSubnet subnetField;

        /// <remarks/>
        public ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddressSubnetsSubnet Subnet
        {
            get { return this.subnetField; }
            set { this.subnetField = value; }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddressSubnetsSubnet
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class Setting
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationRoleSecurityConfigurations
    {

        private ServiceConfigurationRoleSecurityConfigurationsConfiguration[] securityConfigurationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Configuration", IsNullable = false)]
        public ServiceConfigurationRoleSecurityConfigurationsConfiguration[] SecurityConfiguration
        {
            get
            {
                return this.securityConfigurationField;
            }
            set
            {
                this.securityConfigurationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration")]
    public partial class ServiceConfigurationRoleSecurityConfigurationsConfiguration
    {

        private string nameField;

        private string typeField;

        private string subTypeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string subType
        {
            get
            {
                return this.subTypeField;
            }
            set
            {
                this.subTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}


