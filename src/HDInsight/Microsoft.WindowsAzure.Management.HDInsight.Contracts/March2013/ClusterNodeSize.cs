//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.March2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class ClusterNodeSize
    {
        [DataMember( EmitDefaultValue = false )]
        public int Count { get; set; } 

        [DataMember( EmitDefaultValue = false )]
        public ClusterNodeType RoleType { get; set; } 

        [DataMember( EmitDefaultValue = false )]
        public NodeVMSize VMSize { get; set; }
    }
}
