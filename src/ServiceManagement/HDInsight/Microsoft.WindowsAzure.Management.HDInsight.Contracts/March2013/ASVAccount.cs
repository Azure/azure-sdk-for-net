//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.March2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class ASVAccount
    {       
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string AccountName { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string BlobContainerName { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string SecretKey { get; set; }
    }
}

