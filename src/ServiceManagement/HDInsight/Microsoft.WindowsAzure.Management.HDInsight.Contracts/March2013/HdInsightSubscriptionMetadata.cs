//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.March2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class HdInsightSubscriptionMetadata
    {
 
        [DataMember( EmitDefaultValue = false )]
        public string SubscriptionId;

        [DataMember( EmitDefaultValue = false )]
        public IEnumerable<string> Versions;

        [DataMember( EmitDefaultValue = false )]
        public IEnumerable<string> Locations;

        [DataMember( EmitDefaultValue = false )]
        public int ContainersCount; 

        [DataMember( EmitDefaultValue = false )]
        public int CoresUsed; 

        [DataMember( EmitDefaultValue = false )]
        public int MaxCoresAllowed;
    }
}
