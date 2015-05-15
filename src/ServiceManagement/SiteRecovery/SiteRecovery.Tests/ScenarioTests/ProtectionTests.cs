//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
using System.Net;
using Xunit;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Azure.Test;
using System.IO;

namespace SiteRecovery.Tests
{
    /// <summary>
    /// Helper around serialization/deserialization of objects. This one is a thin wrapper around
    /// DataContractUtils<T> which is the one doing the heavy lifting.
    /// </summary>
    public static class DataContractUtils
    {
        /// <summary>
        /// Serializes the supplied object to the string.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>Serialized string.</returns>
        public static string Serialize<T>(T obj)
        {
            return DataContractUtils<T>.Serialize(obj);
        }

        /// <summary>
        /// Deserialize the string to the expected object type.
        /// </summary>
        /// <param name="xmlString">Serialized string.</param>
        /// <param name="result">Deserialized object.</param>
        public static void Deserialize<T>(string xmlString, out T result)
        {
            result = DataContractUtils<T>.Deserialize(xmlString);
        }
    }

    public static class DataContractUtils<T>
    {
        /// <summary>
        /// Serializes the propertyBagContainer to the string. 
        /// </summary>
        /// <param name="propertyBagContainer"></param>
        /// <returns></returns>
        public static string Serialize(T propertyBagContainer)
        {
            var serializer = new DataContractSerializer(typeof(T));
            string xmlString;
            StringWriter sw = null;
            try
            {
                sw = new StringWriter();
                using (var writer = new XmlTextWriter(sw))
                {
                    // Indent the XML so it's human readable.
                    writer.Formatting = Formatting.Indented;
                    serializer.WriteObject(writer, propertyBagContainer);
                    writer.Flush();
                    xmlString = sw.ToString();
                }
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return xmlString;
        }

        /// <summary>
        /// Deserialize the string to the propertyBagContainer.
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static T Deserialize(string xmlString)
        {
            T propertyBagContainer;
            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xmlString);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                propertyBagContainer = (T)deserializer.ReadObject(stream);
            }

            return propertyBagContainer;
        }
    }

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class AzureEnableProtectionInput
    {
        [DataMember(Order = 1)]
        public string HvHostVmId { get; set; }
        [DataMember(Order = 2)]
        public string VmName { get; set; }
        [DataMember(Order = 3)]
        public string OSType { get; set; }
        [DataMember(Order = 4)]
        public string VHDId { get; set; }
    }

    /// <summary>
    /// San specific enable replication group protection input as part of
    /// EnableReplicationGroupProtection REST API.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class SanEnableProtectionInput
    {
        /// <summary>
        /// Gets or sets the fabric that contains the replication group.
        /// </summary>
        [DataMember(Order = 1)]
        public string FabricId { get; set; }

        /// <summary>
        /// Gets or sets the cloud that contains the replication group.
        /// </summary>
        [DataMember(Order = 2)]
        public string CloudId { get; set; }

        /// <summary>
        /// Gets or sets the fabric's replication group Id.
        /// </summary>
        [DataMember(Order = 3)]
        public string FabricReplicationGroupId { get; set; }

        /// <summary>
        /// Gets or sets the replication type (sync or async).
        /// </summary>
        [DataMember(Order = 4)]
        public string ReplicationType { get; set; }

        /// <summary>
        /// Gets or sets the RPO to use in conjunction with the replication type. Valid inputs are:
        /// ReplicationType = Sync -> RPO value should be set to 0.
        /// ReplicationType = Async
        ///    - RPO value left at 0 -> Array's default RPO will get used.
        ///    - RPO value non-zero -> Should be one of the array's supported RPO values.
        /// </summary>
        [DataMember(Order = 5)]
        public int Rpo { get; set; }

        /// <summary>
        /// Gets or sets the remote array to be used for protection.
        /// </summary>
        [DataMember(Order = 6)]
        public string RemoteArrayId { get; set; }
    }

    /// <summary>
    /// San specific disable replication group protection input as part of
    /// DisableReplicationGroupProtection REST API.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class SanDisableProtectionInput
    {
        /// <summary>
        /// Gets or sets a value indicating whether luns needs to be deleted.
        /// </summary>
        [DataMember(Order = 1)]
        public bool DeleteReplicaLuns { get; set; }

        /// <summary>
        /// Gets or sets the cloud Id from which luns should be deleted.
        /// </summary>
        [DataMember(Order = 2)]
        public string TargetCloudIdForLunDeletion { get; set; }
    }

    /// <summary>
    /// Disk details.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class VirtualHardDisk
    {
        /// <summary>
        /// Gets or sets the VHD id.
        /// </summary>
        [DataMember(Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Order = 2)]
        public string Name { get; set; }
    }

    /// <summary>
    /// Disk details for E2A provider.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class AzureVmDiskDetails
    {
        /// <summary>
        /// Gets or sets the List of all Disk in VM.
        /// </summary>
        [DataMember]
        public string OsType { get; set; }

        /// <summary>
        /// Gets or sets the disks details.
        /// </summary>
        [DataMember]
        public List<VirtualHardDisk> Disks { get; set; }

        /// <summary>
        /// Gets or sets the Name of OS Disk as set.
        /// </summary>
        [DataMember]
        public string OsDisk { get; set; }

        /// <summary>
        /// Gets or sets the VHD id.
        /// </summary>
        [DataMember]
        public string VHDId { get; set; }

        /// <summary>
        /// Gets or sets MaxSizeMB.
        /// </summary>
        [DataMember]
        public ulong MaxSizeMB { get; set; }
    }

    public class ProtectionTests : SiteRecoveryTestsBase
    {
        public void EnableProtectionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);
                
                var responsePC = client.ProtectionContainer.List(RequestHeaders);
                JobResponse response = new JobResponse();
                bool desiredPEFound = false;
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    if (pc.Role == "Primary")
                    {
                        var responsePEs = client.ProtectionEntity.List(pc.ID, RequestHeaders);
                        response = null;
                        foreach (var pe in responsePEs.ProtectionEntities)
                        {
                            if (pe.Protected == false)
                            {
                                AzureVmDiskDetails diskDetails;
                                DataContractUtils.Deserialize<AzureVmDiskDetails>(
                                    pe.ReplicationProviderSettings, out diskDetails);
                                EnableProtectionInput input = new EnableProtectionInput();
                                int index = 0;
                                input.ProtectionProfileId = pc.AvailableProtectionProfiles[index].ID;
                                AzureEnableProtectionInput azureInput = new AzureEnableProtectionInput();
                                azureInput.HvHostVmId = pe.FabricObjectId;
                                azureInput.VmName = pe.Name;
                                azureInput.VHDId = diskDetails.VHDId;
                                azureInput.OSType = diskDetails.OsType;

                                if (string.IsNullOrWhiteSpace(azureInput.OSType))
                                {
                                    azureInput.OSType = "Windows";
                                }

                                input.ReplicationProviderInput = DataContractUtils.Serialize<AzureEnableProtectionInput>(azureInput);

                                response = client.ProtectionEntity.EnableProtection(
                                    pe.ProtectionContainerId,
                                    pe.ID,
                                    input,
                                    requestHeaders);

                                desiredPEFound = true;
                                break;
                            }
                        }

                        if (desiredPEFound)
                        {
                            break;
                        }
                    }
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing Enable protection operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void DisableProtectionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);
                JobResponse response = new JobResponse();

                var responsePC = client.ProtectionContainer.List(RequestHeaders);
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    var responsePEs = client.ProtectionEntity.List(pc.ID, RequestHeaders);
                    response = null;
                    foreach (var pe in responsePEs.ProtectionEntities)
                    {
                        if (pe.Protected == true)
                        {
                            response = client.ProtectionEntity.DisableProtection(pe.ProtectionContainerId, pe.ID, null, requestHeaders);
                            break;
                        }
                    }
                }


                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing disable protection operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
