using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.March2013
{
    [DataContract(Namespace = Constants.XsdMetastoreNamespace)]
    public class SqlAzureMetaStore
    {
        [DataMember(EmitDefaultValue = false)]
        public string AzureServerName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Username { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Password { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string DatabaseName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SqlMetastoreType Type { get; set; }
    }
}
