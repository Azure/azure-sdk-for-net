using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract( Namespace=Constants.XsdNamespace )]
    public class ContainerError
    {
        [DataMember( Order = 1 )]
        public int ErrorCode { get; set; }

        [DataMember( Order = 2 )]
        public string ErrorDescription { get; set; }
    }
}
