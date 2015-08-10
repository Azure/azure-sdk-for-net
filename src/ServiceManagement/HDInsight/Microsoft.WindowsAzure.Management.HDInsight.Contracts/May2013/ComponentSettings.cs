using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract( Namespace = Constants.XsdNamespace )]
    public class ComponentSettings
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public Core Core { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public Hdfs Hdfs { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public MapReduce MapReduce { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public Hive Hive { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public Oozie Oozie { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public Yarn Yarn { get; set; }

        public ComponentSettings()
        {
            Core = new Core();
            Hdfs = new Hdfs();
            MapReduce = new MapReduce();
            Hive = new Hive();
            Oozie = new Oozie();
            Yarn = null; //Yarn is an optional field
        }
    }
}
