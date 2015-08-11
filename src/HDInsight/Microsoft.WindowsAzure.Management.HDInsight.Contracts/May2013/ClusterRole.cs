//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class ClusterRole
    {
        [DataMember( EmitDefaultValue = false )]
        public int Count { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public ClusterRoleType RoleType { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public NodeVMSize VMSize { get; set; }
    }
}
