// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Redis.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using Microsoft.Azure.Management.Dns.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;

namespace Microsoft.Azure.Management.Samples.Common
{
    public static class Utilities
    {
        public static Action<string> LoggerMethod { get; set; }
        public static Func<string> PauseMethod { get; set; }

        static Utilities()
        {
            LoggerMethod = Console.WriteLine;
            PauseMethod = Console.ReadLine;
        }

        public static void Log(string message)
        {
            LoggerMethod.Invoke(message);
        }

        public static void Log(object obj)
        {
            if (obj != null)
            {
                LoggerMethod.Invoke(obj.ToString());
            }
            else
            {
                LoggerMethod.Invoke("(null)");
            }
        }

        public static void Log()
        {
            Utilities.Log("");
        }

        public static string ReadLine()
        {
            return PauseMethod.Invoke();
        }

        // Print app gateway info
        public static void PrintAppGateway(IApplicationGateway resource)
        {
            var info = new StringBuilder();
            info.Append("App gateway: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags.ToString())
                    .Append("\n\tSKU: ").Append(resource.Sku.ToString())
                    .Append("\n\tOperational state: ").Append(resource.OperationalState)
                    .Append("\n\tSSL policy: ").Append(resource.SslPolicy)
                    .Append("\n\tInternet-facing? ").Append(resource.IsPublic)
                    .Append("\n\tInternal? ").Append(resource.IsPrivate)
                    .Append("\n\tDefault private IP address: ").Append(resource.PrivateIpAddress)
                    .Append("\n\tPrivate IP address allocation method: ").Append(resource.PrivateIpAllocationMethod);

            // Show IP configs
            var ipConfigs = resource.IpConfigurations;
            info.Append("\n\tIP configurations: ").Append(ipConfigs.Count);
            foreach (var ipConfig in ipConfigs.Values)
            {
                info.Append("\n\t\tName: ").Append(ipConfig.Name)
                    .Append("\n\t\t\tNetwork id: ").Append(ipConfig.NetworkId)
                    .Append("\n\t\t\tSubnet name: ").Append(ipConfig.SubnetName);
            }

            // Show frontends
            var frontends = resource.Frontends;
            info.Append("\n\tFrontends: ").Append(frontends.Count);
            foreach (var frontend in frontends.Values)
            {
                info.Append("\n\t\tName: ").Append(frontend.Name)
                    .Append("\n\t\t\tPublic? ").Append(frontend.IsPublic);

                if (frontend.IsPublic)
                {
                    // Show public frontend info
                    info.Append("\n\t\t\tPublic IP address ID: ").Append(frontend.PublicIpAddressId);
                }

                if (frontend.IsPrivate)
                {
                    // Show private frontend info
                    info.Append("\n\t\t\tPrivate IP address: ").Append(frontend.PrivateIpAddress)
                        .Append("\n\t\t\tPrivate IP allocation method: ").Append(frontend.PrivateIpAllocationMethod)
                        .Append("\n\t\t\tSubnet name: ").Append(frontend.SubnetName)
                        .Append("\n\t\t\tVirtual network ID: ").Append(frontend.NetworkId);
                }
            }

            // Show backends
            var backends = resource.Backends;
            info.Append("\n\tBackends: ").Append(backends.Count);
            foreach (var backend in backends.Values)
            {
                info.Append("\n\t\tName: ").Append(backend.Name)
                    .Append("\n\t\t\tAssociated NIC IP configuration IDs: ").Append(string.Join(", ", backend.BackendNicIpConfigurationNames.Keys.ToArray()));

                // Show addresses
                var addresses = backend.Addresses;
                info.Append("\n\t\t\tAddresses: ").Append(addresses.Count);
                foreach (var address in addresses)
                {
                    info.Append("\n\t\t\t\tFQDN: ").Append(address.Fqdn)
                        .Append("\n\t\t\t\tIP: ").Append(address.IpAddress);
                }
            }

            // Show backend HTTP configurations
            var httpConfigs = resource.BackendHttpConfigurations;
            info.Append("\n\tHTTP Configurations: ").Append(httpConfigs.Count);
            foreach (var httpConfig in httpConfigs.Values)
            {
                info.Append("\n\t\tName: ").Append(httpConfig.Name)
                    .Append("\n\t\t\tCookie based affinity: ").Append(httpConfig.CookieBasedAffinity)
                    .Append("\n\t\t\tPort: ").Append(httpConfig.Port)
                    .Append("\n\t\t\tRequest timeout in seconds: ").Append(httpConfig.RequestTimeout)
                    .Append("\n\t\t\tProtocol: ").Append(httpConfig.Protocol.ToString());
            }

            // Show SSL certificates
            var sslCerts = resource.SslCertificates;
            info.Append("\n\tSSL certificates: ").Append(sslCerts.Count);
            foreach (var cert in sslCerts.Values)
            {
                info.Append("\n\t\tName: ").Append(cert.Name)
                    .Append("\n\t\t\tCert data: ").Append(cert.PublicData);
            }

            // Show HTTP listeners
            var listeners = resource.Listeners;
            info.Append("\n\tHTTP listeners: ").Append(listeners.Count);
            foreach (var listener in listeners.Values)
            {
                info.Append("\n\t\tName: ").Append(listener.Name)
                    .Append("\n\t\t\tHost name: ").Append(listener.HostName)
                    .Append("\n\t\t\tServer name indication required? ").Append(listener.RequiresServerNameIndication)
                    .Append("\n\t\t\tAssociated frontend name: ").Append(listener.Frontend.Name)
                    .Append("\n\t\t\tFrontend port name: ").Append(listener.FrontendPortName)
                    .Append("\n\t\t\tFrontend port number: ").Append(listener.FrontendPortNumber)
                    .Append("\n\t\t\tProtocol: ").Append(listener.Protocol.ToString());
                if (listener.SslCertificate != null)
                {
                    info.Append("\n\t\t\tAssociated SSL certificate: ").Append(listener.SslCertificate.Name);
                }
            }

            // Show request routing rules
            var rules = resource.RequestRoutingRules;
            info.Append("\n\tRequest routing rules: ").Append(rules.Count);
            foreach (var rule in rules.Values)
            {
                info.Append("\n\t\tName: ").Append(rule.Name)
                    .Append("\n\t\t\tType: ").Append(rule.RuleType.ToString())
                    .Append("\n\t\t\tPublic IP address ID: ").Append(rule.PublicIpAddressId)
                    .Append("\n\t\t\tHost name: ").Append(rule.HostName)
                    .Append("\n\t\t\tServer name indication required? ").Append(rule.RequiresServerNameIndication)
                    .Append("\n\t\t\tFrontend port: ").Append(rule.FrontendPort)
                    .Append("\n\t\t\tFrontend protocol: ").Append(rule.FrontendProtocol.ToString())
                    .Append("\n\t\t\tBackend port: ").Append(rule.BackendPort)
                    .Append("\n\t\t\tCookie based affinity enabled? ").Append(rule.CookieBasedAffinity);

                // Show backend addresses
                var addresses = rule.BackendAddresses;
                info.Append("\n\t\t\tBackend addresses: ").Append(addresses.Count);
                foreach (var address in addresses)
                {
                    info.Append("\n\t\t\t\t")
                        .Append(address.Fqdn)
                        .Append(" [").Append(address.IpAddress).Append("]");
                }

                // Show SSL cert
                info.Append("\n\t\t\tSSL certificate name: ");
                var cert = rule.SslCertificate;
                if (cert == null)
                {
                    info.Append("(None)");
                }
                else
                {
                    info.Append(cert.Name);
                }

                // Show backend
                info.Append("\n\t\t\tAssociated backend address pool: ");
                var backend = rule.Backend;
                if (backend == null)
                {
                    info.Append("(None)");
                }
                else
                {
                    info.Append(backend.Name);
                }

                // Show backend HTTP settings config
                info.Append("\n\t\t\tAssociated backend HTTP settings configuration: ");
                var config = rule.BackendHttpConfiguration;
                if (config == null)
                {
                    info.Append("(None)");
                }
                else
                {
                    info.Append(config.Name);
                }

                // Show frontend listener
                info.Append("\n\t\t\tAssociated frontend listener: ");
                var listener = rule.Listener;
                if (listener == null)
                {
                    info.Append("(None)");
                }
                else
                {
                    info.Append(config.Name);
                }
            }

            Utilities.Log(info.ToString());
        }

        public static void PrintVirtualMachineCustomImage(IVirtualMachineCustomImage image)
        {
            var builder = new StringBuilder().Append("Virtual machine custom image: ").Append(image.Id)
            .Append("Name: ").Append(image.Name)
            .Append("\n\tResource group: ").Append(image.ResourceGroupName)
            .Append("\n\tCreated from virtual machine: ").Append(image.SourceVirtualMachineId);

            builder.Append("\n\tOS disk image: ")
                    .Append("\n\t\tOperating system: ").Append(image.OsDiskImage.OsType)
                    .Append("\n\t\tOperating system state: ").Append(image.OsDiskImage.OsState)
                    .Append("\n\t\tCaching: ").Append(image.OsDiskImage.Caching)
                    .Append("\n\t\tSize (GB): ").Append(image.OsDiskImage.DiskSizeGB);
            if (image.IsCreatedFromVirtualMachine)
            {
                builder.Append("\n\t\tSource virtual machine: ").Append(image.SourceVirtualMachineId);
            }
            if (image.OsDiskImage.ManagedDisk != null)
            {
                builder.Append("\n\t\tSource managed disk: ").Append(image.OsDiskImage.ManagedDisk.Id);
            }
            if (image.OsDiskImage.Snapshot != null)
            {
                builder.Append("\n\t\tSource snapshot: ").Append(image.OsDiskImage.Snapshot.Id);
            }
            if (image.OsDiskImage.BlobUri != null)
            {
                builder.Append("\n\t\tSource un-managed vhd: ").Append(image.OsDiskImage.BlobUri);
            }
            if (image.DataDiskImages != null)
            {
                foreach (var diskImage  in image.DataDiskImages.Values)
                {
                    builder.Append("\n\tDisk Image (Lun) #: ").Append(diskImage.Lun)
                            .Append("\n\t\tCaching: ").Append(diskImage.Caching)
                            .Append("\n\t\tSize (GB): ").Append(diskImage.DiskSizeGB);
                    if (image.IsCreatedFromVirtualMachine)
                    {
                        builder.Append("\n\t\tSource virtual machine: ").Append(image.SourceVirtualMachineId);
                    }
                    if (diskImage.ManagedDisk != null)
                    {
                        builder.Append("\n\t\tSource managed disk: ").Append(diskImage.ManagedDisk.Id);
                    }
                    if (diskImage.Snapshot != null)
                    {
                        builder.Append("\n\t\tSource snapshot: ").Append(diskImage.Snapshot.Id);
                    }
                    if (diskImage.BlobUri != null)
                    {
                        builder.Append("\n\t\tSource un-managed vhd: ").Append(diskImage.BlobUri);
                    }
                }
            }
            Log(builder.ToString());
        }

        public static void PrintVirtualMachine(IVirtualMachine virtualMachine)
        {
            var storageProfile = new StringBuilder().Append("\n\tStorageProfile: ");
            if (virtualMachine.StorageProfile.ImageReference != null)
            {
                storageProfile.Append("\n\t\tImageReference:");
                storageProfile.Append("\n\t\t\tPublisher: ").Append(virtualMachine.StorageProfile.ImageReference.Publisher);
                storageProfile.Append("\n\t\t\tOffer: ").Append(virtualMachine.StorageProfile.ImageReference.Offer);
                storageProfile.Append("\n\t\t\tSKU: ").Append(virtualMachine.StorageProfile.ImageReference.Sku);
                storageProfile.Append("\n\t\t\tVersion: ").Append(virtualMachine.StorageProfile.ImageReference.Version);
            }

            if (virtualMachine.StorageProfile.OsDisk != null)
            {
                storageProfile.Append("\n\t\tOSDisk:");
                storageProfile.Append("\n\t\t\tOSType: ").Append(virtualMachine.StorageProfile.OsDisk.OsType);
                storageProfile.Append("\n\t\t\tName: ").Append(virtualMachine.StorageProfile.OsDisk.Name);
                storageProfile.Append("\n\t\t\tCaching: ").Append(virtualMachine.StorageProfile.OsDisk.Caching);
                storageProfile.Append("\n\t\t\tCreateOption: ").Append(virtualMachine.StorageProfile.OsDisk.CreateOption);
                storageProfile.Append("\n\t\t\tDiskSizeGB: ").Append(virtualMachine.StorageProfile.OsDisk.DiskSizeGB);
                if (virtualMachine.StorageProfile.OsDisk.Image != null)
                {
                    storageProfile.Append("\n\t\t\tImage Uri: ").Append(virtualMachine.StorageProfile.OsDisk.Image.Uri);
                }
                if (virtualMachine.StorageProfile.OsDisk.Vhd != null)
                {
                    storageProfile.Append("\n\t\t\tVhd Uri: ").Append(virtualMachine.StorageProfile.OsDisk.Vhd.Uri);
                }
                if (virtualMachine.StorageProfile.OsDisk.EncryptionSettings != null)
                {
                    storageProfile.Append("\n\t\t\tEncryptionSettings: ");
                    storageProfile.Append("\n\t\t\t\tEnabled: ").Append(virtualMachine.StorageProfile.OsDisk.EncryptionSettings.Enabled);
                    storageProfile.Append("\n\t\t\t\tDiskEncryptionKey Uri: ").Append(virtualMachine
                            .StorageProfile
                            .OsDisk
                            .EncryptionSettings
                            .DiskEncryptionKey.SecretUrl);
                    storageProfile.Append("\n\t\t\t\tKeyEncryptionKey Uri: ").Append(virtualMachine
                            .StorageProfile
                            .OsDisk
                            .EncryptionSettings
                            .KeyEncryptionKey.KeyUrl);
                }
            }

            if (virtualMachine.StorageProfile.DataDisks != null)
            {
                var i = 0;
                foreach (var disk in virtualMachine.StorageProfile.DataDisks)
                {
                    storageProfile.Append("\n\t\tDataDisk: #").Append(i++);
                    storageProfile.Append("\n\t\t\tName: ").Append(disk.Name);
                    storageProfile.Append("\n\t\t\tCaching: ").Append(disk.Caching);
                    storageProfile.Append("\n\t\t\tCreateOption: ").Append(disk.CreateOption);
                    storageProfile.Append("\n\t\t\tDiskSizeGB: ").Append(disk.DiskSizeGB);
                    storageProfile.Append("\n\t\t\tLun: ").Append(disk.Lun);
                    if (virtualMachine.IsManagedDiskEnabled)
                    {
                        if (disk.ManagedDisk != null)
                        {
                            storageProfile.Append("\n\t\t\tManaged Disk Id: ").Append(disk.ManagedDisk.Id);
                        }
                    }
                    else
                    {
                        if (disk.Vhd.Uri != null)
                        {
                            storageProfile.Append("\n\t\t\tVhd Uri: ").Append(disk.Vhd.Uri);
                        }
                    }
                    if (disk.Image != null)
                    {
                        storageProfile.Append("\n\t\t\tImage Uri: ").Append(disk.Image.Uri);
                    }
                }
            }
            StringBuilder osProfile;
            if (virtualMachine.OsProfile != null)
            {
                osProfile = new StringBuilder().Append("\n\tOSProfile: ");

                osProfile.Append("\n\t\tComputerName:").Append(virtualMachine.OsProfile.ComputerName);
                if (virtualMachine.OsProfile.WindowsConfiguration != null)
                {
                    osProfile.Append("\n\t\t\tWindowsConfiguration: ");
                    osProfile.Append("\n\t\t\t\tProvisionVMAgent: ")
                            .Append(virtualMachine.OsProfile.WindowsConfiguration.ProvisionVMAgent);
                    osProfile.Append("\n\t\t\t\tEnableAutomaticUpdates: ")
                            .Append(virtualMachine.OsProfile.WindowsConfiguration.EnableAutomaticUpdates);
                    osProfile.Append("\n\t\t\t\tTimeZone: ")
                            .Append(virtualMachine.OsProfile.WindowsConfiguration.TimeZone);
                }
                if (virtualMachine.OsProfile.LinuxConfiguration != null)
                {
                    osProfile.Append("\n\t\t\tLinuxConfiguration: ");
                    osProfile.Append("\n\t\t\t\tDisablePasswordAuthentication: ")
                            .Append(virtualMachine.OsProfile.LinuxConfiguration.DisablePasswordAuthentication);
                }
            }
            else
            {
                osProfile = new StringBuilder().Append("\n\tOSProfile: null");
            }


            var networkProfile = new StringBuilder().Append("\n\tNetworkProfile: ");
            foreach (var networkInterfaceId in virtualMachine.NetworkInterfaceIds)
            {
                networkProfile.Append("\n\t\tId:").Append(networkInterfaceId);
            }

            Utilities.Log(new StringBuilder().Append("Virtual Machine: ").Append(virtualMachine.Id)
                    .Append("Name: ").Append(virtualMachine.Name)
                    .Append("\n\tResource group: ").Append(virtualMachine.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(virtualMachine.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(virtualMachine.Tags))
                    .Append("\n\tHardwareProfile: ")
                    .Append("\n\t\tSize: ").Append(virtualMachine.Size)
                    .Append(storageProfile)
                    .Append(osProfile)
                    .Append(networkProfile)
                    .ToString());
        }

        public static void PrintStorageAccountKeys(IList<StorageAccountKey> storageAccountKeys)
        {
            foreach (var storageAccountKey in storageAccountKeys)
            {
                Utilities.Log($"Key {storageAccountKey.KeyName} = {storageAccountKey.Value}");
            }
        }

        public static void PrintStorageAccount(IStorageAccount storageAccount)
        {
            Utilities.Log($"{storageAccount.Name} created @ {storageAccount.CreationTime}");
        }

        public static string CreateRandomName(string namePrefix)
        {
            return SdkContext.RandomResourceName(namePrefix, 30);
        }

        public static void PrintAvailabilitySet(IAvailabilitySet resource)
        {
            Utilities.Log(new StringBuilder().Append("Availability Set: ").Append(resource.Id)
                .Append("Name: ").Append(resource.Name)
                .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                .Append("\n\tRegion: ").Append(resource.Region)
                .Append("\n\tTags: ").Append(FormatDictionary(resource.Tags))
                .Append("\n\tFault domain count: ").Append(resource.FaultDomainCount)
                .Append("\n\tUpdate domain count: ").Append(resource.UpdateDomainCount)
                .ToString());
        }

        public static void PrintBatchAccount(IBatchAccount batchAccount)
        {
            var applicationsOutput = new StringBuilder().Append("\n\tapplications: ");

            if (batchAccount.Applications.Count > 0)
            {
                foreach (var applicationEntry in batchAccount.Applications)
                {
                    var application = applicationEntry.Value;
                    var applicationPackages = new StringBuilder().Append("\n\t\t\tapplicationPackages : ");

                    foreach (var applicationPackageEntry in application.ApplicationPackages)
                    {
                        var applicationPackage = applicationPackageEntry.Value;
                        var singleApplicationPackage = new StringBuilder().Append("\n\t\t\t\tapplicationPackage : " + applicationPackage.Name);
                        singleApplicationPackage.Append("\n\t\t\t\tapplicationPackageState : " + applicationPackage.State);

                        applicationPackages.Append(singleApplicationPackage);
                        singleApplicationPackage.Append("\n");
                    }

                    var singleApplication = new StringBuilder().Append("\n\t\tapplication: " + application.Name);
                    singleApplication.Append("\n\t\tdisplayName: " + application.DisplayName);
                    singleApplication.Append("\n\t\tdefaultVersion: " + application.DefaultVersion);
                    singleApplication.Append(applicationPackages);
                    applicationsOutput.Append(singleApplication);
                    applicationsOutput.Append("\n");
                }
            }

            Utilities.Log(new StringBuilder().Append("BatchAccount: ").Append(batchAccount.Id)
                    .Append("Name: ").Append(batchAccount.Name)
                    .Append("\n\tResource group: ").Append(batchAccount.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(batchAccount.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(batchAccount.Tags))
                    .Append("\n\tAccountEndpoint: ").Append(batchAccount.AccountEndpoint)
                    .Append("\n\tPoolQuota: ").Append(batchAccount.PoolQuota)
                    .Append("\n\tActiveJobAndJobScheduleQuota: ").Append(batchAccount.ActiveJobAndJobScheduleQuota)
                    .Append("\n\tStorageAccount: ").Append(batchAccount.AutoStorage == null ? "No storage account attached" : batchAccount.AutoStorage.StorageAccountId)
                    .Append(applicationsOutput)
                    .ToString());
        }

        public static void PrintBatchAccountKey(BatchAccountKeys batchAccountKeys)
        {
            Utilities.Log("Primary Key (" + batchAccountKeys.Primary + ") Secondary key = ("
                    + batchAccountKeys.Secondary + ")");
        }

        public static void PrintNetworkSecurityGroup(INetworkSecurityGroup resource)
        {
            var nsgOutput = new StringBuilder();
            nsgOutput.Append("NSG: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.RegionName)
                    .Append("\n\tTags: ").Append(FormatDictionary(resource.Tags));

            // Output security rules
            foreach (var rule in resource.SecurityRules.Values)
            {
                nsgOutput.Append("\n\tRule: ").Append(rule.Name)
                        .Append("\n\t\tAccess: ").Append(rule.Access)
                        .Append("\n\t\tDirection: ").Append(rule.Direction)
                        .Append("\n\t\tFrom address: ").Append(rule.SourceAddressPrefix)
                        .Append("\n\t\tFrom port range: ").Append(rule.SourcePortRange)
                        .Append("\n\t\tTo address: ").Append(rule.DestinationAddressPrefix)
                        .Append("\n\t\tTo port: ").Append(rule.DestinationPortRange)
                        .Append("\n\t\tProtocol: ").Append(rule.Protocol)
                        .Append("\n\t\tPriority: ").Append(rule.Priority);
            }
            Utilities.Log(nsgOutput.ToString());
        }

        public static void PrintVirtualNetwork(INetwork network)
        {
            var info = new StringBuilder();
            info.Append("Network: ").Append(network.Id)
                    .Append("Name: ").Append(network.Name)
                    .Append("\n\tResource group: ").Append(network.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(network.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(network.Tags))
                    .Append("\n\tAddress spaces: ").Append(FormatCollection(network.AddressSpaces))
                    .Append("\n\tDNS server IPs: ").Append(FormatCollection(network.DnsServerIps));

            // Output subnets
            foreach (var subnet in network.Subnets.Values)
            {
                info.Append("\n\tSubnet: ").Append(subnet.Name)
                        .Append("\n\t\tAddress prefix: ").Append(subnet.AddressPrefix);
                var subnetNsg = subnet.GetNetworkSecurityGroup();
                if (subnetNsg != null)
                {
                    info.Append("\n\t\tNetwork security group: ").Append(subnetNsg.Id);
                }
            }

            Utilities.Log(info.ToString());
        }

        public static void PrintIpAddress(IPublicIpAddress publicIpAddress)
        {
            Utilities.Log(new StringBuilder().Append("Public IP Address: ").Append(publicIpAddress.Id)
                .Append("Name: ").Append(publicIpAddress.Name)
                .Append("\n\tResource group: ").Append(publicIpAddress.ResourceGroupName)
                .Append("\n\tRegion: ").Append(publicIpAddress.Region)
                .Append("\n\tTags: ").Append(FormatDictionary(publicIpAddress.Tags))
                .Append("\n\tIP Address: ").Append(publicIpAddress.IpAddress)
                .Append("\n\tLeaf domain label: ").Append(publicIpAddress.LeafDomainLabel)
                .Append("\n\tFQDN: ").Append(publicIpAddress.Fqdn)
                .Append("\n\tReverse FQDN: ").Append(publicIpAddress.ReverseFqdn)
                .Append("\n\tIdle timeout (minutes): ").Append(publicIpAddress.IdleTimeoutInMinutes)
                .Append("\n\tIP allocation method: ").Append(publicIpAddress.IpAllocationMethod)
                .ToString());
        }

        public static void PrintNetworkInterface(INetworkInterface resource)
        {
            var info = new StringBuilder();
            info.Append("NetworkInterface: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(resource.Tags))
                    .Append("\n\tInternal DNS name label: ").Append(resource.InternalDnsNameLabel)
                    .Append("\n\tInternal FQDN: ").Append(resource.InternalFqdn)
                    .Append("\n\tInternal domain name suffix: ").Append(resource.InternalDomainNameSuffix)
                    .Append("\n\tNetwork security group: ").Append(resource.NetworkSecurityGroupId)
                    .Append("\n\tApplied DNS servers: ").Append(FormatCollection(resource.AppliedDnsServers))
                    .Append("\n\tDNS server IPs: ");

            // Output dns servers
            foreach (var dnsServerIp in resource.DnsServers)
            {
                info.Append("\n\t\t").Append(dnsServerIp);
            }

            info.Append("\n\t IP forwarding enabled: ").Append(resource.IsIpForwardingEnabled)
                    .Append("\n\tMAC Address:").Append(resource.MacAddress)
                    .Append("\n\tPrivate IP:").Append(resource.PrimaryPrivateIp)
                    .Append("\n\tPrivate allocation method:").Append(resource.PrimaryPrivateIpAllocationMethod)
                    .Append("\n\tPrimary virtual network ID: ").Append(resource.PrimaryIpConfiguration.NetworkId)
                    .Append("\n\tPrimary subnet name:").Append(resource.PrimaryIpConfiguration.SubnetName);

            Utilities.Log(info.ToString());
        }

        public static void PrintLoadBalancer(ILoadBalancer loadBalancer)
        {
            var info = new StringBuilder();
            info.Append("Load balancer: ").Append(loadBalancer.Id)
                    .Append("Name: ").Append(loadBalancer.Name)
                    .Append("\n\tResource group: ").Append(loadBalancer.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(loadBalancer.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(loadBalancer.Tags))
                    .Append("\n\tBackends: ").Append(FormatCollection(loadBalancer.Backends.Keys));

            // Show public IP addresses
            info.Append("\n\tPublic IP address IDs: ")
                    .Append(loadBalancer.PublicIpAddressIds.Count);
            foreach (var pipId in loadBalancer.PublicIpAddressIds)
            {
                info.Append("\n\t\tPIP id: ").Append(pipId);
            }

            // Show TCP probes
            info.Append("\n\tTCP probes: ")
                    .Append(loadBalancer.TcpProbes.Count);
            foreach (var probe in loadBalancer.TcpProbes.Values)
            {
                info.Append("\n\t\tProbe name: ").Append(probe.Name)
                        .Append("\n\t\t\tPort: ").Append(probe.Port)
                        .Append("\n\t\t\tInterval in seconds: ").Append(probe.IntervalInSeconds)
                        .Append("\n\t\t\tRetries before unhealthy: ").Append(probe.NumberOfProbes);

                // Show associated load balancing rules
                info.Append("\n\t\t\tReferenced from load balancing rules: ")
                        .Append(probe.LoadBalancingRules.Count);
                foreach (var rule in probe.LoadBalancingRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }
            }

            // Show HTTP probes
            info.Append("\n\tHTTP probes: ")
                    .Append(loadBalancer.HttpProbes.Count);
            foreach (var probe in loadBalancer.HttpProbes.Values)
            {
                info.Append("\n\t\tProbe name: ").Append(probe.Name)
                        .Append("\n\t\t\tPort: ").Append(probe.Port)
                        .Append("\n\t\t\tInterval in seconds: ").Append(probe.IntervalInSeconds)
                        .Append("\n\t\t\tRetries before unhealthy: ").Append(probe.NumberOfProbes)
                        .Append("\n\t\t\tHTTP request path: ").Append(probe.RequestPath);

                // Show associated load balancing rules
                info.Append("\n\t\t\tReferenced from load balancing rules: ")
                        .Append(probe.LoadBalancingRules.Count);
                foreach (var rule in probe.LoadBalancingRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }
            }

            // Show load balancing rules
            info.Append("\n\tLoad balancing rules: ")
                    .Append(loadBalancer.LoadBalancingRules.Count);
            foreach (var rule in loadBalancer.LoadBalancingRules.Values)
            {
                info.Append("\n\t\tLB rule name: ").Append(rule.Name)
                        .Append("\n\t\t\tProtocol: ").Append(rule.Protocol)
                        .Append("\n\t\t\tFloating IP enabled? ").Append(rule.FloatingIpEnabled)
                        .Append("\n\t\t\tIdle timeout in minutes: ").Append(rule.IdleTimeoutInMinutes)
                        .Append("\n\t\t\tLoad distribution method: ").Append(rule.LoadDistribution);

                var frontend = rule.Frontend;
                info.Append("\n\t\t\tFrontend: ");
                if (frontend != null)
                {
                    info.Append(frontend.Name);
                }
                else
                {
                    info.Append("(None)");
                }

                info.Append("\n\t\t\tFrontend port: ").Append(rule.FrontendPort);

                var backend = rule.Backend;
                info.Append("\n\t\t\tBackend: ");
                if (backend != null)
                {
                    info.Append(backend.Name);
                }
                else
                {
                    info.Append("(None)");
                }

                info.Append("\n\t\t\tBackend port: ").Append(rule.BackendPort);

                var probe = rule.Probe;
                info.Append("\n\t\t\tProbe: ");
                if (probe == null)
                {
                    info.Append("(None)");
                }
                else
                {
                    info.Append(probe.Name).Append(" [").Append(probe.Protocol.ToString()).Append("]");
                }
            }

            // Show frontends
            info.Append("\n\tFrontends: ")
                    .Append(loadBalancer.Frontends.Count);
            foreach (var frontend in loadBalancer.Frontends.Values)
            {
                info.Append("\n\t\tFrontend name: ").Append(frontend.Name)
                        .Append("\n\t\t\tInternet facing: ").Append(frontend.IsPublic);
                if (frontend.IsPublic)
                {
                    info.Append("\n\t\t\tPublic IP Address ID: ").Append(((ILoadBalancerPublicFrontend)frontend).PublicIpAddressId);
                }
                else
                {
                    info.Append("\n\t\t\tVirtual network ID: ").Append(((ILoadBalancerPrivateFrontend)frontend).NetworkId)
                            .Append("\n\t\t\tSubnet name: ").Append(((ILoadBalancerPrivateFrontend)frontend).SubnetName)
                            .Append("\n\t\t\tPrivate IP address: ").Append(((ILoadBalancerPrivateFrontend)frontend).PrivateIpAddress)
                            .Append("\n\t\t\tPrivate IP allocation method: ").Append(((ILoadBalancerPrivateFrontend)frontend).PrivateIpAllocationMethod);
                }

                // Inbound NAT pool references
                info.Append("\n\t\t\tReferenced inbound NAT pools: ")
                        .Append(frontend.InboundNatPools.Count);
                foreach (var pool in frontend.InboundNatPools.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(pool.Name);
                }

                // Inbound NAT rule references
                info.Append("\n\t\t\tReferenced inbound NAT rules: ")
                        .Append(frontend.InboundNatRules.Count);
                foreach (var rule in frontend.InboundNatRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }

                // Load balancing rule references
                info.Append("\n\t\t\tReferenced load balancing rules: ")
                        .Append(frontend.LoadBalancingRules.Count);
                foreach (var rule in frontend.LoadBalancingRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }
            }

            // Show inbound NAT rules
            info.Append("\n\tInbound NAT rules: ")
                    .Append(loadBalancer.InboundNatRules.Count);
            foreach (var natRule in loadBalancer.InboundNatRules.Values)
            {
                info.Append("\n\t\tInbound NAT rule name: ").Append(natRule.Name)
                        .Append("\n\t\t\tProtocol: ").Append(natRule.Protocol.ToString())
                        .Append("\n\t\t\tFrontend: ").Append(natRule.Frontend.Name)
                        .Append("\n\t\t\tFrontend port: ").Append(natRule.FrontendPort)
                        .Append("\n\t\t\tBackend port: ").Append(natRule.BackendPort)
                        .Append("\n\t\t\tBackend NIC ID: ").Append(natRule.BackendNetworkInterfaceId)
                        .Append("\n\t\t\tBackend NIC IP config name: ").Append(natRule.BackendNicIpConfigurationName)
                        .Append("\n\t\t\tFloating IP? ").Append(natRule.FloatingIpEnabled)
                        .Append("\n\t\t\tIdle timeout in minutes: ").Append(natRule.IdleTimeoutInMinutes);
            }

            // Show inbound NAT pools
            info.Append("\n\tInbound NAT pools: ")
                    .Append(loadBalancer.InboundNatPools.Count);
            foreach (var natPool in loadBalancer.InboundNatPools.Values)
            {
                info.Append("\n\t\tInbound NAT pool name: ").Append(natPool.Name)
                        .Append("\n\t\t\tProtocol: ").Append(natPool.Protocol.ToString())
                        .Append("\n\t\t\tFrontend: ").Append(natPool.Frontend.Name)
                        .Append("\n\t\t\tFrontend port range: ")
                        .Append(natPool.FrontendPortRangeStart)
                        .Append("-")
                        .Append(natPool.FrontendPortRangeEnd)
                        .Append("\n\t\t\tBackend port: ").Append(natPool.BackendPort);
            }

            // Show backends
            info.Append("\n\tBackends: ")
                    .Append(loadBalancer.Backends.Count);
            foreach (var backend in loadBalancer.Backends.Values)
            {
                info.Append("\n\t\tBackend name: ").Append(backend.Name);

                // Show assigned backend NICs
                info.Append("\n\t\t\tReferenced NICs: ")
                        .Append(backend.BackendNicIpConfigurationNames.Count);
                foreach (var entry in backend.BackendNicIpConfigurationNames)
                {
                    info.Append("\n\t\t\t\tNIC ID: ").Append(entry.Key)
                            .Append(" - IP Config: ").Append(entry.Value);
                }

                // Show assigned virtual machines
                var vmIds = backend.GetVirtualMachineIds();
                info.Append("\n\t\t\tReferenced virtual machine ids: ")
                        .Append(vmIds.Count);
                foreach (string vmId in vmIds)
                {
                    info.Append("\n\t\t\t\tVM ID: ").Append(vmId);
                }

                // Show assigned load balancing rules
                info.Append("\n\t\t\tReferenced load balancing rules: ")
                        .Append(FormatCollection(backend.LoadBalancingRules.Keys));
            }

            Utilities.Log(info.ToString());
        }

        public static void PrintVault(IVault vault)
        {
            var info = new StringBuilder().Append("Key Vault: ").Append(vault.Id)
                .Append("Name: ").Append(vault.Name)
                .Append("\n\tResource group: ").Append(vault.ResourceGroupName)
                .Append("\n\tRegion: ").Append(vault.Region)
                .Append("\n\tSku: ").Append(vault.Sku.Name).Append(" - ").Append(KeyVault.Fluent.Models.Sku.Family)
                .Append("\n\tVault URI: ").Append(vault.VaultUri)
                .Append("\n\tAccess policies: ");
            foreach (var accessPolicy in vault.AccessPolicies)
            {
                info.Append("\n\t\tIdentity:").Append(accessPolicy.ObjectId)
                        .Append("\n\t\tKey permissions: ").Append(FormatCollection(accessPolicy.Permissions.Keys))
                        .Append("\n\t\tSecret permissions: ").Append(FormatCollection(accessPolicy.Permissions.Secrets));
            }

            Utilities.Log(info.ToString());
        }

        public static void PrintRedisCache(IRedisCache redisCache)
        {
            var redisInfo = new StringBuilder();
            redisInfo.Append("Redis Cache Name: ").AppendLine(redisCache.Name)
                     .Append("\tResource group: ").AppendLine(redisCache.ResourceGroupName)
                     .Append("\tRegion: ").AppendLine(redisCache.Region.ToString())
                     .Append("\tSKU Name: ").AppendLine(redisCache.Sku.Name)
                     .Append("\tSKU Family: ").AppendLine(redisCache.Sku.Family)
                     .Append("\tHost name: ").AppendLine(redisCache.HostName)
                     .Append("\tSSL port: ").AppendLine(redisCache.SslPort.ToString())
                     .Append("\tNon-SSL port (6379) enabled: ").AppendLine(redisCache.NonSslPort.ToString());
            if (redisCache.RedisConfiguration != null && redisCache.RedisConfiguration.Count > 0)
            {
                redisInfo.AppendLine("\tRedis Configuration:");
                foreach (KeyValuePair<string, string> rc in redisCache.RedisConfiguration)
                {
                    redisInfo.Append("\t  '").Append(rc.Key)
                             .Append("' : '").Append(rc.Value).AppendLine("'");
                }
            }
            if (redisCache.IsPremium)
            {
                var premium = redisCache.AsPremium();
                var scheduleEntries = premium.ListPatchSchedules();
                if (scheduleEntries != null && scheduleEntries.Any())
                {
                    redisInfo.AppendLine("\tRedis Patch Schedule:");
                    foreach (var schedule in scheduleEntries)
                    {
                        redisInfo.Append("\t\tDay: '").Append(schedule.DayOfWeek)
                                .Append("', start at: '").Append(schedule.StartHourUtc)
                                .Append("', maintenance window: '").Append(schedule.MaintenanceWindow)
                                .AppendLine("'");
                    }
                }
            }

            Utilities.Log(redisInfo.ToString());
        }

        public static void PrintRedisAccessKeys(IRedisAccessKeys redisAccessKeys)
        {
            var redisKeys = new StringBuilder();
            redisKeys.AppendLine("Redis Access Keys: ")
                     .Append("\tPrimary Key: '").Append(redisAccessKeys.PrimaryKey).AppendLine("', ")
                     .Append("\tSecondary Key: '").Append(redisAccessKeys.SecondaryKey).AppendLine("', ");

            Utilities.Log(redisKeys.ToString());
        }

        public static void Print(IAppServiceDomain resource)
        {
            var builder = new StringBuilder().Append("Domain: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tCreated time: ").Append(resource.CreatedTime)
                    .Append("\n\tExpiration time: ").Append(resource.ExpirationTime)
                    .Append("\n\tContact: ");
            var contact = resource.RegistrantContact;
            if (contact == null)
            {
                builder = builder.Append("Private");
            }
            else
            {
                builder = builder.Append("\n\t\tName: ").Append(contact.NameFirst + " " + contact.NameLast);
            }
            builder = builder.Append("\n\tName servers: ");
            foreach (String nameServer in resource.NameServers)
            {
                builder = builder.Append("\n\t\t" + nameServer);
            }
            Utilities.Log(builder.ToString());
        }

        public static void Print(IAppServiceCertificateOrder resource)
        {
            var builder = new StringBuilder().Append("App service certificate order: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tDistinguished name: ").Append(resource.DistinguishedName)
                    .Append("\n\tProduct type: ").Append(resource.ProductType)
                    .Append("\n\tValid years: ").Append(resource.ValidityInYears)
                    .Append("\n\tStatus: ").Append(resource.Status)
                    .Append("\n\tIssuance time: ").Append(resource.LastCertificateIssuanceTime)
                    .Append("\n\tSigned certificate: ").Append(resource.SignedCertificate == null ? null : resource.SignedCertificate.Thumbprint);
            Utilities.Log(builder.ToString());
        }

        public static void Print(IAppServicePlan resource)
        {
            var builder = new StringBuilder().Append("App service certificate order: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tPricing tier: ").Append(resource.PricingTier);
            Utilities.Log(builder.ToString());
        }

        public static void Print(IWebAppBase resource)
        {
            var builder = new StringBuilder().Append("Web app: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tState: ").Append(resource.State)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tDefault hostname: ").Append(resource.DefaultHostName)
                    .Append("\n\tApp service plan: ").Append(resource.AppServicePlanId)
                    .Append("\n\tHost name bindings: ");
            foreach (var binding in resource.GetHostNameBindings().Values)
            {
                builder = builder.Append("\n\t\t" + binding.ToString());
            }
            builder = builder.Append("\n\tSSL bindings: ");
            foreach (var binding in resource.HostNameSslStates.Values)
            {
                builder = builder.Append("\n\t\t" + binding.Name + ": " + binding.SslState);
                if (binding.SslState != null && binding.SslState != SslState.Disabled)
                {
                    builder = builder.Append(" - " + binding.Thumbprint);
                }
            }
            builder = builder.Append("\n\tApp settings: ");
            foreach (var setting in resource.AppSettings.Values)
            {
                builder = builder.Append("\n\t\t" + setting.Key + ": " + setting.Value + (setting.Sticky ? " - slot setting" : ""));
            }
            builder = builder.Append("\n\tConnection strings: ");
            foreach (var conn in resource.ConnectionStrings.Values)
            {
                builder = builder.Append("\n\t\t" + conn.Name + ": " + conn.Value + " - " + conn.Type + (conn.Sticky ? " - slot setting" : ""));
            }
            Utilities.Log(builder.ToString());
        }

        private static string FormatDictionary(IReadOnlyDictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                return string.Empty;
            }

            var outputString = new StringBuilder();

            foreach (var entity in dictionary)
            {
                outputString.AppendLine($"{entity.Key}: {entity.Value}");
            }

            return outputString.ToString();
        }

        private static string FormatCollection(IEnumerable<string> collection)
        {
            return string.Join(", ", collection);
        }

        public static void PrintSqlServer(ISqlServer sqlServer)
        {
            var builder = new StringBuilder().Append("Sql Server: ").Append(sqlServer.Id)
                    .Append("Name: ").Append(sqlServer.Name)
                    .Append("\n\tResource group: ").Append(sqlServer.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(sqlServer.Region)
                    .Append("\n\tSqlServer version: ").Append(sqlServer.Version)
                    .Append("\n\tFully qualified name for Sql Server: ").Append(sqlServer.FullyQualifiedDomainName);
            Utilities.Log(builder.ToString());
        }

        public static void PrintDatabase(ISqlDatabase database)
        {
            var builder = new StringBuilder().Append("Sql Database: ").Append(database.Id)
                    .Append("Name: ").Append(database.Name)
                    .Append("\n\tResource group: ").Append(database.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(database.Region)
                    .Append("\n\tSqlServer Name: ").Append(database.SqlServerName)
                    .Append("\n\tEdition of SQL database: ").Append(database.Edition)
                    .Append("\n\tCollation of SQL database: ").Append(database.Collation)
                    .Append("\n\tCreation date of SQL database: ").Append(database.CreationDate)
                    .Append("\n\tIs data warehouse: ").Append(database.IsDataWarehouse)
                    .Append("\n\tCurrent service objective of SQL database: ").Append(database.ServiceLevelObjective)
                    .Append("\n\tId of current service objective of SQL database: ").Append(database.CurrentServiceObjectiveId)
                    .Append("\n\tMax size bytes of SQL database: ").Append(database.MaxSizeBytes)
                    .Append("\n\tDefault secondary location of SQL database: ").Append(database.DefaultSecondaryLocation);

            Utilities.Log(builder.ToString());
        }

        public static void PrintFirewallRule(ISqlFirewallRule firewallRule)
        {
            var builder = new StringBuilder().Append("Sql firewall rule: ").Append(firewallRule.Id)
                    .Append("Name: ").Append(firewallRule.Name)
                    .Append("\n\tResource group: ").Append(firewallRule.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(firewallRule.Region)
                    .Append("\n\tSqlServer Name: ").Append(firewallRule.SqlServerName)
                    .Append("\n\tStart IP Address of the firewall rule: ").Append(firewallRule.StartIpAddress)
                    .Append("\n\tEnd IP Address of the firewall rule: ").Append(firewallRule.EndIpAddress);

            Utilities.Log(builder.ToString());
        }

        public static void PrintElasticPool(ISqlElasticPool elasticPool)
        {
            var builder = new StringBuilder().Append("Sql elastic pool: ").Append(elasticPool.Id)
                    .Append("Name: ").Append(elasticPool.Name)
                    .Append("\n\tResource group: ").Append(elasticPool.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(elasticPool.Region)
                    .Append("\n\tSqlServer Name: ").Append(elasticPool.SqlServerName)
                    .Append("\n\tEdition of elastic pool: ").Append(elasticPool.Edition)
                    .Append("\n\tTotal number of DTUs in the elastic pool: ").Append(elasticPool.Dtu)
                    .Append("\n\tMaximum DTUs a database can get in elastic pool: ").Append(elasticPool.DatabaseDtuMax)
                    .Append("\n\tMinimum DTUs a database is guaranteed in elastic pool: ").Append(elasticPool.DatabaseDtuMin)
                    .Append("\n\tCreation date for the elastic pool: ").Append(elasticPool.CreationDate)
                    .Append("\n\tState of the elastic pool: ").Append(elasticPool.State)
                    .Append("\n\tStorage capacity in MBs for the elastic pool: ").Append(elasticPool.StorageMB);

            Utilities.Log(builder.ToString());
        }

        public static void PrintElasticPoolActivity(IElasticPoolActivity elasticPoolActivity)
        {
            var builder = new StringBuilder().Append("Sql elastic pool activity: ").Append(elasticPoolActivity.Id)
                    .Append("Name: ").Append(elasticPoolActivity.Name)
                    .Append("\n\tResource group: ").Append(elasticPoolActivity.ResourceGroupName)
                    .Append("\n\tState: ").Append(elasticPoolActivity.State)
                    .Append("\n\tElastic pool name: ").Append(elasticPoolActivity.ElasticPoolName)
                    .Append("\n\tStart time of activity: ").Append(elasticPoolActivity.StartTime)
                    .Append("\n\tEnd time of activity: ").Append(elasticPoolActivity.EndTime)
                    .Append("\n\tError code of activity: ").Append(elasticPoolActivity.ErrorCode)
                    .Append("\n\tError message of activity: ").Append(elasticPoolActivity.ErrorMessage)
                    .Append("\n\tError severity of activity: ").Append(elasticPoolActivity.ErrorSeverity)
                    .Append("\n\tOperation: ").Append(elasticPoolActivity.Operation)
                    .Append("\n\tCompleted percentage of activity: ").Append(elasticPoolActivity.PercentComplete)
                    .Append("\n\tRequested DTU max limit in activity: ").Append(elasticPoolActivity.RequestedDatabaseDtuMax)
                    .Append("\n\tRequested DTU min limit in activity: ").Append(elasticPoolActivity.RequestedDatabaseDtuMin)
                    .Append("\n\tRequested DTU limit in activity: ").Append(elasticPoolActivity.RequestedDtu);

            Utilities.Log(builder.ToString());

        }

        public static void PrintDatabaseActivity(IElasticPoolDatabaseActivity databaseActivity)
        {
            var builder = new StringBuilder().Append("Sql elastic pool database activity: ").Append(databaseActivity.Id)
                    .Append("Name: ").Append(databaseActivity.Name)
                    .Append("\n\tResource group: ").Append(databaseActivity.ResourceGroupName)
                    .Append("\n\tSQL Server Name: ").Append(databaseActivity.ServerName)
                    .Append("\n\tDatabase name name: ").Append(databaseActivity.DatabaseName)
                    .Append("\n\tCurrent elastic pool name of the database: ").Append(databaseActivity.CurrentElasticPoolName)
                    .Append("\n\tState: ").Append(databaseActivity.State)
                    .Append("\n\tStart time of activity: ").Append(databaseActivity.StartTime)
                    .Append("\n\tEnd time of activity: ").Append(databaseActivity.EndTime)
                    .Append("\n\tCompleted percentage: ").Append(databaseActivity.PercentComplete)
                    .Append("\n\tError code of activity: ").Append(databaseActivity.ErrorCode)
                    .Append("\n\tError message of activity: ").Append(databaseActivity.ErrorMessage)
                    .Append("\n\tError severity of activity: ").Append(databaseActivity.ErrorSeverity);

            Utilities.Log(builder.ToString());
        }

        public static void Print(ITrafficManagerProfile profile)
        {
            var builder = new StringBuilder();
            builder.Append("Traffic Manager Profile: ").Append(profile.Id)
                    .Append("\n\tName: ").Append(profile.Name)
                    .Append("\n\tResource group: ").Append(profile.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(profile.RegionName)
                    .Append("\n\tTags: ").Append(profile.Tags)
                    .Append("\n\tDNSLabel: ").Append(profile.DnsLabel)
                    .Append("\n\tFQDN: ").Append(profile.Fqdn)
                    .Append("\n\tTTL: ").Append(profile.TimeToLive)
                    .Append("\n\tEnabled: ").Append(profile.IsEnabled)
                    .Append("\n\tRoutingMethod: ").Append(profile.TrafficRoutingMethod)
                    .Append("\n\tMonitor status: ").Append(profile.MonitorStatus)
                    .Append("\n\tMonitoring port: ").Append(profile.MonitoringPort)
                    .Append("\n\tMonitoring path: ").Append(profile.MonitoringPath);

            var azureEndpoints = profile.AzureEndpoints;
            if (!azureEndpoints.Any())
            {
                builder.Append("\n\tAzure endpoints:");
                var idx = 1;
                foreach (var endpoint in azureEndpoints.Values)
                {
                    builder.Append("\n\t\tAzure endpoint: #").Append(idx++)
                            .Append("\n\t\t\tId: ").Append(endpoint.Id)
                            .Append("\n\t\t\tType: ").Append(endpoint.EndpointType)
                            .Append("\n\t\t\tTarget resourceId: ").Append(endpoint.TargetAzureResourceId)
                            .Append("\n\t\t\tTarget resourceType: ").Append(endpoint.TargetResourceType)
                            .Append("\n\t\t\tMonitor status: ").Append(endpoint.MonitorStatus)
                            .Append("\n\t\t\tEnabled: ").Append(endpoint.IsEnabled)
                            .Append("\n\t\t\tRouting priority: ").Append(endpoint.RoutingPriority)
                            .Append("\n\t\t\tRouting weight: ").Append(endpoint.RoutingWeight);
                }
            }

            var externalEndpoints = profile.ExternalEndpoints;
            if (!externalEndpoints.Any())
            {
                builder.Append("\n\tExternal endpoints:");
                var idx = 1;
                foreach (var endpoint in externalEndpoints.Values)
                {
                    builder.Append("\n\t\tExternal endpoint: #").Append(idx++)
                            .Append("\n\t\t\tId: ").Append(endpoint.Id)
                            .Append("\n\t\t\tType: ").Append(endpoint.EndpointType)
                            .Append("\n\t\t\tFQDN: ").Append(endpoint.Fqdn)
                            .Append("\n\t\t\tSource Traffic Location: ").Append(endpoint.SourceTrafficLocation)
                            .Append("\n\t\t\tMonitor status: ").Append(endpoint.MonitorStatus)
                            .Append("\n\t\t\tEnabled: ").Append(endpoint.IsEnabled)
                            .Append("\n\t\t\tRouting priority: ").Append(endpoint.RoutingPriority)
                            .Append("\n\t\t\tRouting weight: ").Append(endpoint.RoutingWeight);
                }
            }

            var nestedProfileEndpoints = profile.NestedProfileEndpoints;
            if (!nestedProfileEndpoints.Any())
            {
                builder.Append("\n\tNested profile endpoints:");
                var idx = 1;
                foreach (var endpoint in nestedProfileEndpoints.Values)
                {
                    builder.Append("\n\t\tNested profile endpoint: #").Append(idx++)
                            .Append("\n\t\t\tId: ").Append(endpoint.Id)
                            .Append("\n\t\t\tType: ").Append(endpoint.EndpointType)
                            .Append("\n\t\t\tNested profileId: ").Append(endpoint.NestedProfileId)
                            .Append("\n\t\t\tMinimum child threshold: ").Append(endpoint.MinimumChildEndpointCount)
                            .Append("\n\t\t\tSource Traffic Location: ").Append(endpoint.SourceTrafficLocation)
                            .Append("\n\t\t\tMonitor status: ").Append(endpoint.MonitorStatus)
                            .Append("\n\t\t\tEnabled: ").Append(endpoint.IsEnabled)
                            .Append("\n\t\t\tRouting priority: ").Append(endpoint.RoutingPriority)
                            .Append("\n\t\t\tRouting weight: ").Append(endpoint.RoutingWeight);
                }
            }
            Utilities.Log(builder.ToString());
        }

        public static void Print(IDnsZone dnsZone)
        {
            var builder = new StringBuilder();
            builder.Append("Dns Zone: ").Append(dnsZone.Id)
                    .Append("\n\tName (Top level domain): ").Append(dnsZone.Name)
                    .Append("\n\tResource group: ").Append(dnsZone.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(dnsZone.RegionName)
                    .Append("\n\tTags: ").Append(dnsZone.Tags)
                    .Append("\n\tName servers:");
            foreach (var nameServer in dnsZone.NameServers)
            {
                builder.Append("\n\t\t").Append(nameServer);
            }
            var soaRecordSet = dnsZone.GetSoaRecordSet();
            var soaRecord = soaRecordSet.Record;
            builder.Append("\n\tSOA Record:")
                    .Append("\n\t\tHost:").Append(soaRecord.Host)
                    .Append("\n\t\tEmail:").Append(soaRecord.Email)
                    .Append("\n\t\tExpire time (seconds):").Append(soaRecord.ExpireTime)
                    .Append("\n\t\tRefresh time (seconds):").Append(soaRecord.RefreshTime)
                    .Append("\n\t\tRetry time (seconds):").Append(soaRecord.RetryTime)
                    .Append("\n\t\tNegative response cache ttl (seconds):").Append(soaRecord.MinimumTtl)
                    .Append("\n\t\tTtl (seconds):").Append(soaRecordSet.TimeToLive);

            var aRecordSets = dnsZone.ARecordSets.List();
            builder.Append("\n\tA Record sets:");
            foreach (var aRecordSet in aRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(aRecordSet.Id)
                        .Append("\n\t\tName: ").Append(aRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(aRecordSet.TimeToLive)
                        .Append("\n\t\tIp v4 addresses: ");
                foreach (var ipAddress in aRecordSet.Ipv4Addresses)
                {
                    builder.Append("\n\t\t\t").Append(ipAddress);
                }
            }

            var aaaaRecordSets = dnsZone.AaaaRecordSets.List();
            builder.Append("\n\tAAAA Record sets:");
            foreach (var aaaaRecordSet in aaaaRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(aaaaRecordSet.Id)
                        .Append("\n\t\tName: ").Append(aaaaRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(aaaaRecordSet.TimeToLive)
                        .Append("\n\t\tIp v6 addresses: ");
                foreach (var ipAddress in aaaaRecordSet.Ipv6Addresses)
                {
                    builder.Append("\n\t\t\t").Append(ipAddress);
                }
            }

            var cnameRecordSets = dnsZone.CnameRecordSets.List();
            builder.Append("\n\tCNAME Record sets:");
            foreach (var cnameRecordSet in cnameRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(cnameRecordSet.Id)
                        .Append("\n\t\tName: ").Append(cnameRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(cnameRecordSet.TimeToLive)
                        .Append("\n\t\tCanonical name: ").Append(cnameRecordSet.CanonicalName);
            }

            var mxRecordSets = dnsZone.MxRecordSets.List();
            builder.Append("\n\tMX Record sets:");
            foreach (var mxRecordSet in mxRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(mxRecordSet.Id)
                        .Append("\n\t\tName: ").Append(mxRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(mxRecordSet.TimeToLive)
                        .Append("\n\t\tRecords: ");
                foreach (var mxRecord in mxRecordSet.Records)
                {
                    builder.Append("\n\t\t\tExchange server, Preference: ")
                            .Append(mxRecord.Exchange)
                            .Append(" ")
                            .Append(mxRecord.Preference);
                }
            }

            var nsRecordSets = dnsZone.NsRecordSets.List();
            builder.Append("\n\tNS Record sets:");
            foreach (var nsRecordSet in nsRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(nsRecordSet.Id)
                        .Append("\n\t\tName: ").Append(nsRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(nsRecordSet.TimeToLive)
                        .Append("\n\t\tName servers: ");
                foreach (var nameServer in nsRecordSet.NameServers)
                {
                    builder.Append("\n\t\t\t").Append(nameServer);
                }
            }

            var ptrRecordSets = dnsZone.PtrRecordSets.List();
            builder.Append("\n\tPTR Record sets:");
            foreach (var ptrRecordSet in ptrRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(ptrRecordSet.Id)
                        .Append("\n\t\tName: ").Append(ptrRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(ptrRecordSet.TimeToLive)
                        .Append("\n\t\tTarget domain names: ");
                foreach (var domainNames in ptrRecordSet.TargetDomainNames)
                {
                    builder.Append("\n\t\t\t").Append(domainNames);
                }
            }

            var srvRecordSets = dnsZone.SrvRecordSets.List();
            builder.Append("\n\tSRV Record sets:");
            foreach (var srvRecordSet in srvRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(srvRecordSet.Id)
                        .Append("\n\t\tName: ").Append(srvRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(srvRecordSet.TimeToLive)
                        .Append("\n\t\tRecords: ");
                foreach (var srvRecord in srvRecordSet.Records)
                {
                    builder.Append("\n\t\t\tTarget, Port, Priority, Weight: ")
                            .Append(srvRecord.Target)
                            .Append(", ")
                            .Append(srvRecord.Port)
                            .Append(", ")
                            .Append(srvRecord.Priority)
                            .Append(", ")
                            .Append(srvRecord.Weight);
                }
            }

            var txtRecordSets = dnsZone.TxtRecordSets.List();
            builder.Append("\n\tTXT Record sets:");
            foreach (var txtRecordSet in txtRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(txtRecordSet.Id)
                        .Append("\n\t\tName: ").Append(txtRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(txtRecordSet.TimeToLive)
                        .Append("\n\t\tRecords: ");
                foreach (var txtRecord in txtRecordSet.Records)
                {
                    if (txtRecord.Value.Count() > 0)
                    {
                        builder.Append("\n\t\t\tValue: ").Append(txtRecord.Value.FirstOrDefault());
                    }
                }
            }
            Utilities.Log(builder.ToString());
        }
    }
}
