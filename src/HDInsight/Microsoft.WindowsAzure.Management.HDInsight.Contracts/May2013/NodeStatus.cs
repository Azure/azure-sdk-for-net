//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class NodeStatus
    {
        [DataMember( EmitDefaultValue = false )]
        public ClusterRoleType Role { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string AzureInstanceName { get; set; }
    }
}
