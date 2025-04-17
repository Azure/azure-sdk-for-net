// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.IoT.DeviceOnboarding.Models;
using Azure.IoT.DeviceOnboarding.Models.Providers;
using NUnit.Framework;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    public class Sample_DeviceOnboarding
    {
        [Test]
        public async Task Sample_InitializeDevice_RV_IPAddress()
        {
            CBORConverterProvider cborProvider = new Sample_CBORConverter();
            DeviceCredentialProvider credentialProvider = new Sample_DeviceCredentialProvider();
            DeviceOnboardingClient client = new DeviceOnboardingClient(cborProvider, credentialProvider);
            DeviceInitializer deviceInitializer = client.GetDeviceInitializer();
#if NET9_0_OR_GREATER
        var mfgCert = X509CertificateLoader.LoadCertificateFromFile("path to manufacturer's cert");
#else
            var mfgCert = new X509Certificate2("path to manufacturer's cert");
#endif
            var rvDir = new RendezvousDirective();
            rvDir.Add(new RendezvousInstruction()
            {
                Variable = RendezvousVariable.IP_ADDRESS,
                Value = cborProvider.Serialize(IPAddress.Parse("<ip address of rv server>").GetAddressBytes())
            });
            rvDir.Add(new RendezvousInstruction()
            {
                Variable = RendezvousVariable.PROTOCOL,
                Value = cborProvider.Serialize(RendezvousProtocolValue.RVProtHttp)
            });
            rvDir.Add(new RendezvousInstruction()
            {
                Variable = RendezvousVariable.DEV_PORT,
                Value = cborProvider.Serialize(80)
            });
            var rvInfo = new RendezvousInfo();
            rvInfo.Add(rvDir);
            await deviceInitializer.CreateOwnershipVoucherAsync(new X509Certificate2Collection(mfgCert), PublicKeyEncoding.COSEX5CHAIN, rvInfo);

            //user should save ownership voucher at deviceInitializer._ownershipVoucher for extension and upload to storage account
            var creds = credentialProvider.GetDeviceCredentials();
            var filePath = $"<folder to store ownershipvoucher>\\{creds.DeviceGuid}";
            File.WriteAllText(filePath, Convert.ToBase64String(cborProvider.Serialize(deviceInitializer._ownershipVoucher)));
        }

        [Test]
        public async Task Sample_InitializeDevice_RV_DNS()
        {
            CBORConverterProvider cborProvider = new Sample_CBORConverter();
            DeviceCredentialProvider credentialProvider = new Sample_DeviceCredentialProvider();
            DeviceOnboardingClient client = new DeviceOnboardingClient(cborProvider, credentialProvider);
            DeviceInitializer deviceInitializer = client.GetDeviceInitializer();
#if NET9_0_OR_GREATER
            var mfgCert = X509CertificateLoader.LoadCertificateFromFile("path to manufacturer's cert");
#else
            var mfgCert = new X509Certificate2("<path to manufacturer's cert>");
#endif
            var rvDir = new RendezvousDirective();
            rvDir.Add(new RendezvousInstruction()
            {
                Variable = RendezvousVariable.DNS,
                Value = cborProvider.Serialize("<dns of rendezvous server>")
            });
            var rvInfo = new RendezvousInfo();
            rvInfo.Add(rvDir);
            await deviceInitializer.CreateOwnershipVoucherAsync(new X509Certificate2Collection(mfgCert), PublicKeyEncoding.COSEX5CHAIN, rvInfo);

            //user should save ownership voucher at deviceInitializer._ownershipVoucher for extension and upload to storage account
            var creds = credentialProvider.GetDeviceCredentials();
            var filePath = $"<folder to store ownershipvoucher>\\{creds.DeviceGuid}";
            File.WriteAllText(filePath, Convert.ToBase64String(cborProvider.Serialize(deviceInitializer._ownershipVoucher)));
        }

        [Test]
        public async Task Sample_OnboardDevice()
        {
            CBORConverterProvider cborProvider = new Sample_CBORConverter();
            DeviceCredentialProvider credentialProvider = new Sample_DeviceCredentialProvider();
            DeviceOnboardingClient client = new DeviceOnboardingClient(cborProvider, credentialProvider);

            var creds = credentialProvider.GetDeviceCredentials();
            var serverUrls = GetServerInstructions(creds.DeviceRVInfo, true, cborProvider);
            TO2OwnerInfo ownerInfo = null;
            for (int i = 0;i < serverUrls.Count; i++)
            {
                try
                {
                    var deviceDiscoverer = client.GetDeviceDiscoverer(serverUrls[i]);
                    ownerInfo = await deviceDiscoverer.GetOwnerInfoAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message},{ex.StackTrace}");
                    Console.WriteLine("Moving to next rv entry");
                }
            }
            if (ownerInfo != null)
            {
                throw new Exception("None of the rv entries were able to provide owner information");
            }
            var ownerUrls = GetOwnerUrls(ownerInfo);
            for (int i = 0; i < ownerUrls.Count; i++)
            {
                try
                {
                    var deviceProvisioner = client.GetDeviceProvisioner(ownerUrls[i], ownerInfo, new Dictionary<string, BaseServiceInfoModuleDevice> { });
                    deviceProvisioner.UpdateDeviceOwner();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message},{ex.StackTrace}");
                    Console.WriteLine("Moving to next owner url");
                }
            }
        }

        public static List<string> GetServerInstructions(RendezvousInfo rendezvousInstructions, bool isDevice, CBORConverterProvider cborConverter)
        {
            var instructions = new List<string>();

            foreach (var directive in rendezvousInstructions)
            {
                bool skipDirective = false;
                string dnsAddress = string.Empty;
                byte[] ipAddressBytes = null;
                IPAddress ipAddress = null;
                int? port = null;
                int delaySeconds = 0;
                RendezvousProtocolValue? protocolValue = null;

                foreach (var instruction in directive)
                {
                    switch (instruction.Variable)
                    {
                        case RendezvousVariable.DEV_ONLY:
                            if (!isDevice)
                            {
                                skipDirective = true;
                            }
                            break;
                        case RendezvousVariable.OWNER_ONLY:
                            if (isDevice)
                            {
                                skipDirective = true;
                            }
                            break;
                        case RendezvousVariable.DNS:
                            dnsAddress = cborConverter.Deserialize<string>(instruction.Value);
                            break;
                        case RendezvousVariable.DEV_PORT:
                            if (isDevice)
                            {
                                port = cborConverter.Deserialize<int>(instruction.Value);
                            }
                            break;
                        case RendezvousVariable.OWNER_PORT:
                            if (!isDevice)
                            {
                                port = cborConverter.Deserialize<int>(instruction.Value);
                            }
                            break;
                        case RendezvousVariable.WIFI_SSID:
                            skipDirective = true;
                            break;
                        case RendezvousVariable.WIFI_PW:
                            skipDirective = true;
                            break;
                        case RendezvousVariable.BYPASS:
                            skipDirective = true;
                            break;
                        case RendezvousVariable.IP_ADDRESS:
                            ipAddressBytes = cborConverter.Deserialize<byte[]>(instruction.Value);
                            break;
                        case RendezvousVariable.CL_CERT_HASH:
                            skipDirective = true;
                            break;
                        case RendezvousVariable.SV_CERT_HASH:
                            skipDirective = true;
                            break;
                        case RendezvousVariable.USER_INPUT:
                            skipDirective = true;
                            break;
                        case RendezvousVariable.MEDIUM:
                            skipDirective = true;
                            break;
                        case RendezvousVariable.PROTOCOL:
                            if (isDevice)
                                protocolValue = cborConverter.Deserialize<RendezvousProtocolValue>(instruction.Value);
                            break;
                        case RendezvousVariable.DELAYSEC:
                            delaySeconds = cborConverter.Deserialize<int>(instruction.Value);
                            break;
                        case RendezvousVariable.EXT_RV:
                            skipDirective = true;
                            break;
                        default:
                            throw new ArgumentException("No valid Rendezvous Variable found.");
                    }
                    if (skipDirective)
                    {
                        continue;
                    }
                }

                // Now construct a server instruction from the Directive

                // Don't Process the Directive if no valid DNS or IPAddress is found
                if (string.IsNullOrEmpty(dnsAddress) && (ipAddressBytes == null || ipAddressBytes.Length == 0))
                {
                    continue;
                }

                // At this point we only support Http and Https
                if (protocolValue != null)
                {
                    if (!(protocolValue.Equals(RendezvousProtocolValue.RVProtHttp) ||
                        protocolValue.Equals(RendezvousProtocolValue.RVProtHttps)))
                    {
                        continue;
                    }
                }
                else
                {
                    // Default is Https
                    protocolValue = RendezvousProtocolValue.RVProtHttps;
                    if (port != null && port == 80)
                    {
                        protocolValue = RendezvousProtocolValue.RVProtHttp;
                    }
                }

                // If port is null, add ports for Https and Http
                if (port == null)
                {
                    if (protocolValue.Equals(RendezvousProtocolValue.RVProtHttp))
                    {
                        port = 80;
                    }
                    else if (protocolValue.Equals(RendezvousProtocolValue.RVProtHttps))
                    {
                        port = 443;
                    }
                }

                // Parse IP Address
                if (ipAddressBytes != null && ipAddressBytes.Length > 0)
                {
                    ipAddress = new IPAddress(ipAddressBytes);
                }

                var httpSuffix = protocolValue.Equals(RendezvousProtocolValue.RVProtHttps) ? "https" : "http";

                // Add Dns Entry First
                if (!string.IsNullOrEmpty(dnsAddress))
                {
                    var url = string.Concat(httpSuffix, "://", dnsAddress, ":", port);
                    instructions.Add(url);
                }

                // Add IPAddress after DNS
                if (ipAddress != null)
                {
                    var url = string.Concat(httpSuffix, "://", ipAddress.ToString(), ":", port);
                    instructions.Add(url);
                }
            }
            return instructions;
        }

        public static List<string> GetOwnerUrls(TO2OwnerInfo ownerInfo)
        {
            var list = new List<string>();
            foreach (TO2AddressEntry address in ownerInfo.To1dPayload.AddressEntries)
            {
                // Check the protocol
                string protocolValue = "http";
                var protocol = address.Protocol;
                if (protocol.Equals(TransportProtocol.PROT_HTTPS))
                {
                    protocolValue = "http";
                }
                else if (protocol.Equals(TransportProtocol.PROT_HTTP))
                {
                    protocolValue = "http";
                }
                else
                {
                    var msg = $"Protocol {protocol} not supported";
                    throw new ArgumentException(msg);
                }

                // If port is null, add ports for Https and Http
                var port = address.Port;
                if (port == 0)
                {
                    if (protocolValue.Equals("http"))
                    {
                        port = 80;
                    }
                    else if (protocolValue.Equals("https"))
                    {
                        port = 443;
                    }
                }

                if (address.DnsAddress != null)
                {
                    var url = protocolValue + "://" + address.DnsAddress.ToString() + ":" + port;
                    list.Add(url);
                }

                if (address.IpAddress != null)
                {
                    var ipAddress = new IPAddress(address.IpAddress);
                    var url = protocolValue + "://" + ipAddress.ToString() + ":" + port;
                    list.Add(url);
                }
            }
            return list;
        }
    }
}
