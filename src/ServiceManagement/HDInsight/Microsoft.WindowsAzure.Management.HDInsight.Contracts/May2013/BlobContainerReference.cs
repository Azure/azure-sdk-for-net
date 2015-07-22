//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class BlobContainerReference
    {   
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string AccountName { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string BlobContainerName { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Key { get; set; }
    }
}
