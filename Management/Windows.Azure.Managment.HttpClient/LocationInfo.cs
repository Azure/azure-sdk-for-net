using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Windows.Azure.Management.v1_7
{
    [CollectionDataContract(Name = "Locations", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class LocationCollection : List<Location>
    {
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    [DataContract(Name = "Location", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class Location
    {
        [DataMember(Order=0)]
        public String Name { get; private set; }

        [DataMember(Order=1)]
        public String DisplayName { get; private set; }
    }
}
