// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014
{
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Validation;

    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class ClusterRole : RestDataContract
    {
        private string vmSizeAsString;

        [DataMember]
        public string FriendlyName { get; set; }

        [DataMember]
        public VmSize VMSize { get; set; }

        [DataMember]
        public string VMSizeAsString 
        { get { return vmSizeAsString; }
            set
            {
                vmSizeAsString = value;

                VmSize legacy;
                if (VmSize.TryParse(vmSizeAsString, out legacy) && legacy <= VmSize.ExtraLarge)
                {
                    VMSize = legacy;
                }
                else
                {
                    VMSize = VmSize.ExtraLarge;
                }
            } 
        }
        
        [DataMember]
        public int InstanceCount { get; set; }

        [DataMember(EmitDefaultValue = false), ValidateObject]
        public RemoteDesktopSettings RemoteDesktopSettings { get; set; }

        public ClusterRole()
        {
            RemoteDesktopSettings = new RemoteDesktopSettings();
        }
    }

}