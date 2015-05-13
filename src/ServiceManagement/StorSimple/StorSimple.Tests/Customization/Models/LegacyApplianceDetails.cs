// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Management.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    /// <summary>
    /// Represents the parsed config metadata to be send as input for migration
    /// </summary>
    public class LegacyApplianceDetails : LegacyApplianceConfig
    {
        /// <summary>
        /// List of container names of volume containers to be migrated together
        /// </summary>
        public List<string[]> RelatedCloudConfigurationNames { get; set; }

        /// <summary>
        /// Converts the configs in the desired formated string
        /// </summary>
        /// <returns>format content to be displayed</returns>
        public override string ToString()
        {
            try
            {
                StringBuilder consoleOutput = new StringBuilder();
                MigrationCommonModelFormatter modelBase = new MigrationCommonModelFormatter();
                int maxLength = this.GetType().GetProperties().ToList().Max(t => t.Name.Length);
                if (null != this.VolumeGroups)
                {
                    consoleOutput.Append(Resources.MigrationVolumeContainerRelatedGroupHeader).AppendLine();
                    int groupCount = 0;
                    List<List<MigrationDataContainer>> dataContainerGroupList = ComputedRelatedVolumeContainers();
                    if (null != dataContainerGroupList)
                    {
                        foreach (var dataContainerGroup in dataContainerGroupList)
                        {
                            if (null != dataContainerGroup && 0 < dataContainerGroup.Count)
                            {
                                consoleOutput.Append("\t");
                                string relatedDCNames =
                                    modelBase.ConcatStringList(dataContainerGroup.Select(dc => dc.Name).ToList());
                                string relatedDCVar =
                                    string.Format(Resources.MigrationVolumeContainerRelatedGroupSubHeader, ++groupCount);
                                consoleOutput.Append(modelBase.IntendAndConCat(relatedDCVar, relatedDCNames,
                                    Resources.MigrationVolumeContainerRelatedGroupSubHeader.Length + 1));
                                consoleOutput.AppendLine();
                            }
                        }
                    }
                    else
                    {
                        consoleOutput.AppendLine(Resources.MigrationVolumeContainerRelatedGroupingNotFound);
                    }
                }

                return consoleOutput.ToString();
            }
            catch (Exception except)
            {
                // powershell will consume the exception, and no details will be displayed if the exception is thrown, hence handling and returning error string.
                return string.Format(Resources.MigrationErrorInDisplayingDetails, except.ToString());
            }
        }

        /// <summary>
        /// Computed and updates the related volume containers which has to be migrated together
        /// </summary>
        /// <returns>list of related volume containers' name</returns>
        internal List<string[]> UpdateRelatedVolumeContainerNames()
        {
            List<List<MigrationDataContainer>> relatedDataContainerGroupList = this.ComputedRelatedVolumeContainers();
            List<string[]> relatedDataContainerNameList = new List<string[]>();
            foreach (var relatedDCList in relatedDataContainerGroupList)
            {
                if (null != relatedDCList && 0 < relatedDCList.Count)
                {
                    IEnumerable<string> relatedDCNameList = relatedDCList.Select(dc => dc.Name);
                    relatedDataContainerNameList.Add(relatedDCNameList.ToArray());
                }
            }

            return relatedDataContainerNameList;
        }

        /// <summary>
        /// Computes the list of volume containers to be migrated together
        /// </summary>
        /// <returns>list of related volume container(s) which needs to be migrated together</returns>
        private List<List<MigrationDataContainer>> ComputedRelatedVolumeContainers()
        {
            var dcDict = new Dictionary<string, DataContainerInfo>();
            foreach (var virtualDiskGroup in this.VolumeGroups)
            {
                List<string> diskIDList = virtualDiskGroup.VirtualDiskList.ToList();
                string vDGIdentity = Guid.NewGuid().ToString();
                foreach (string virtualDiskId in diskIDList)
                {
                    VirtualDisk virtualDisk = this.Volumes.FirstOrDefault(volume => (volume.InstanceId == virtualDiskId));
                    MigrationDataContainer dataContainer =
                        this.CloudConfigurations.FirstOrDefault(
                            volumeContainer => (volumeContainer.InstanceId == virtualDisk.DataContainerId));
                    if (null != dataContainer)
                    {
                        if (!dcDict.ContainsKey(dataContainer.InstanceId))
                        {
                            DataContainerInfo newDc = new DataContainerInfo()
                            {
                                DcInfo = dataContainer,
                                VirtualDiskGroups = new List<string>() {vDGIdentity},
                                Visited = false
                            };

                            dcDict.Add(dataContainer.InstanceId, newDc);
                        }
                        else if (!dcDict[dataContainer.InstanceId].VirtualDiskGroups.Contains(vDGIdentity))
                        {
                            dcDict[dataContainer.InstanceId].VirtualDiskGroups.Add(vDGIdentity);
                        }
                    }
                    else
                    {
                        throw new MissingMemberException(
                            string.Format(Resources.MigrationVolumeToVolumeContainerMapNotFound,
                                virtualDisk.DataContainerId, virtualDisk.InstanceId));
                    }
                }
            }

            foreach (var dataContainer in this.CloudConfigurations)
            {
                if (!dcDict.Keys.Contains(dataContainer.InstanceId))
                {
                    dcDict.Add(dataContainer.InstanceId,
                        new DataContainerInfo()
                        {
                            DcInfo = dataContainer,
                            VirtualDiskGroups = new List<string>(),
                            Visited = false
                        });
                }
            }

            DataContainerInfo[] dcArray = dcDict.Values.ToArray();

            // create an adjacency matrix of DCs
            bool[,] dcGraph = new bool[dcDict.Count, dcDict.Count];
            for (int row = 0; row < dcDict.Count; row++)
            {
                for (int col = 0; col < dcDict.Count; col++)
                {
                    dcGraph[row, col] = false;
                }
            }

            for (int row = 0; row < dcArray.Count(); row++)
            {
                DataContainerInfo currDc = dcArray[row];
                foreach (string groupInstanceID in currDc.VirtualDiskGroups)
                {
                    for (int col = 0; col < dcArray.Count(); col++)
                    {
                        DataContainerInfo otherDc = dcArray[col];
                        if (!currDc.DcInfo.InstanceId.Equals(otherDc.DcInfo.InstanceId) &&
                            // we're looking at the same vertex
                            !(dcGraph[row, col] && dcGraph[col, row])) // or the vertices are already known neighbours
                        {
                            if (otherDc.VirtualDiskGroups.Contains(groupInstanceID))
                            {
                                dcGraph[row, col] = true;
                                dcGraph[col, row] = true;
                            }
                        }
                    }
                }
            }

            // evaluate DCs connected by policies
            List<List<MigrationDataContainer>> connectedDCs = new List<List<MigrationDataContainer>>();
            for (int index = 0; index < dcArray.Count(); index++)
            {
                if (dcArray[index].Visited == false)
                {
                    connectedDCs.Add(RunDFS(dcGraph, dcArray, index, new List<MigrationDataContainer>()));
                }
            }

            return connectedDCs;
        }

        /// <summary>
        /// Volume container node
        /// </summary>
        private class DataContainerInfo
        {
            public MigrationDataContainer DcInfo;
            public List<string> VirtualDiskGroups;
            public bool Visited;
        }

        /// <summary>
        /// DFS algorithm to traverse through the volume container graph and returns dependent container list
        /// </summary>
        /// <param name="dcGraph">data container graph</param>
        /// <param name="dcArray">list of data containers</param>
        /// <param name="startingNode">starting node for traversal</param>
        /// <param name="traversedNodes">list of nodes already discovered from previous iteration (to start with this pass as empty)</param>
        /// <returns>dependent data container list</returns>
        private List<MigrationDataContainer> RunDFS(bool[,] dcGraph,
            DataContainerInfo[] dcArray,
            int startingNode,
            List<MigrationDataContainer> traversedNodes)
        {
            traversedNodes.Add(dcArray[startingNode].DcInfo);
            dcArray[startingNode].Visited = true;

            for (int index = 0; index < dcArray.Count(); index++)
            {
                if ((dcGraph[startingNode, index] == true) && (dcArray[index].Visited == false))
                {
                    RunDFS(dcGraph, dcArray, index, traversedNodes);
                }
            }

            return traversedNodes;
        }

    }

}