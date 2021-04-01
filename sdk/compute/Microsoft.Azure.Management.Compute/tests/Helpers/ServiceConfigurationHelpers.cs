// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using static Compute.Tests.CloudServiceTestsBase;

namespace Compute.Tests
{
    public static class ServiceConfigurationHelpers
    {

        [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
        internal const string CertStatusBlobSasUri = "https://paastest2.blob.core.windows.net/deploymentstatus/statusBlob.txt?st=2019-12-06T00%3A20%3A39Z&se=2025-12-07T00%3A20%3A00Z&sp=rl&sv=2018-03-28&sr=b&sig=RzHk3kJ2SBxeDYVBugH1n1BxQ8QNo4FRunUNzH9wq%2Bs%3D";

        public static string GenerateServiceConfiguration(
            string serviceName,
            int osFamily,
            string osVersion,
            string schemaVersion,
            Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping,
            string vNetName,
            string subnetName,
            ServiceConfigurationNetworkConfigurationAddressAssignmentsReservedIPs reservedIPs = null,
            List<ServiceConfigurationRoleCertificate> certificates = null,
            ServiceConfigurationRoleSecurityConfigurations securityConfigurations = null,
            Setting[] serviceSettings = null)
        {
            ConfigureRoleSettings(roleNameToPropertiesMapping, certificates);

            List<ServiceConfigurationRole> roles = new List<ServiceConfigurationRole>();
            List<ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddress> roleInstanceAddresses = new List<ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddress>();

            AddRoleConfigurations(roleNameToPropertiesMapping, roles, certificates, securityConfigurations, roleInstanceAddresses, subnetName);

            ServiceConfiguration serviceConfiguration = GenerateServiceConfiguration(serviceName, osFamily, osVersion, schemaVersion, roles, vNetName, roleInstanceAddresses, serviceSettings, reservedIPs);

            return SerializeToXML(serviceConfiguration);
        }

        private static void ConfigureRoleSettings(Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping, List<ServiceConfigurationRoleCertificate> certificates)
        {
            foreach (string roleName in roleNameToPropertiesMapping.Keys)
            {
                if (roleNameToPropertiesMapping[roleName].Settings == null)
                {
                    roleNameToPropertiesMapping[roleName].Settings = new Dictionary<string, string>
                    {
                        { "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString", "UseDevelopmentStorage=true" }
                    };
                }

                Dictionary<string, string> roleSettings = roleNameToPropertiesMapping[roleName].Settings;

                if (!roleSettings.ContainsKey("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString"))
                {
                    roleSettings["Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString"] = "UseDevelopmentStorage=true";
                }

                if (certificates != null)
                {
                    string thumbprints = "";
                    thumbprints = string.Join(",", certificates.Select(c => c.thumbprint));
                    if (!string.IsNullOrEmpty(thumbprints))
                    {
                        roleSettings["Microsoft.WindowsAzure.StatusBlobUri"] = CertStatusBlobSasUri;
                        roleSettings["Microsoft.WindowsAzure.Thumbprints"] = thumbprints;
                    }
                }
            }
        }

        private static void AddRoleConfigurations(
            Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping,
            List<ServiceConfigurationRole> roles,
            List<ServiceConfigurationRoleCertificate> certificates,
            ServiceConfigurationRoleSecurityConfigurations securityConfigurations,
            List<ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddress> roleInstanceAddresses,
            string subnetName)
        {
            foreach (string roleName in roleNameToPropertiesMapping.Keys)
            {
                RoleConfiguration roleConfiguration = roleNameToPropertiesMapping[roleName];
                ServiceConfigurationRoleSetting[] settingsArray = roleConfiguration.Settings.Keys.Select(key => new ServiceConfigurationRoleSetting { name = key, value = roleConfiguration.Settings[key] }).ToArray();

                // Add Configuration for each role
                roles.Add(new ServiceConfigurationRole()
                {
                    name = roleName,
                    Instances = new ServiceConfigurationRoleInstances()
                    {
                        count = roleConfiguration.InstanceCount.ToString()
                    },
                    // Note: For now these settings and certificates are same for all roles.
                    // They can be handled later as we add support for other scenarios.
                    ConfigurationSettings = settingsArray,
                    Certificates = certificates?.ToArray(),
                    SecurityConfigurations = securityConfigurations
                });

                // Add the required subnet for each role
                roleInstanceAddresses.Add(new ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddress()
                {
                    roleName = roleName,
                    Subnets = new ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddressSubnets()
                    {
                        Subnet = new ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddressSubnetsSubnet()
                        {
                            name = subnetName
                        }
                    }
                });
            }
        }

        private static ServiceConfiguration GenerateServiceConfiguration(string serviceName,
            int osFamily,
            string osVersion,
            string schemaVersion,
            List<ServiceConfigurationRole> roles,
            string vNetName,
            List<ServiceConfigurationNetworkConfigurationAddressAssignmentsInstanceAddress> roleInstanceAddresses,
            Setting[] serviceSettings,
            ServiceConfigurationNetworkConfigurationAddressAssignmentsReservedIPs reservedIPs = null)
        {
            return new ServiceConfiguration()
            {
                serviceName = serviceName,
                osFamily = osFamily.ToString(),
                osVersion = osVersion,
                schemaVersion = schemaVersion,
                Role = roles.ToArray(),
                NetworkConfiguration = new ServiceConfigurationNetworkConfiguration()
                {
                    VirtualNetworkSite = new ServiceConfigurationNetworkConfigurationVirtualNetworkSite()
                    {
                        name = vNetName
                    },
                    AddressAssignments = new ServiceConfigurationNetworkConfigurationAddressAssignments()
                    {
                        InstanceAddress = roleInstanceAddresses.ToArray(),
                        ReservedIPs = reservedIPs
                    }
                },
                ServiceSettings = serviceSettings
            };
        }

        private static string SerializeToXML(ServiceConfiguration serviceConfiguration)
        {
            using (var stringWriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(ServiceConfiguration));
                serializer.Serialize(stringWriter, serviceConfiguration);
                return stringWriter.ToString();
            };
        }
    }
}

