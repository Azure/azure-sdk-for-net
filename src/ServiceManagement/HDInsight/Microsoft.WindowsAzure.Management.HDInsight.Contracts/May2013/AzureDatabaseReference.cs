using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract( Namespace = Constants.XsdNamespace )]
    public class AzureDatabaseReference
    {
        [DataMember]
        public string Server { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string DatabaseName { get; set; }
    }
}
