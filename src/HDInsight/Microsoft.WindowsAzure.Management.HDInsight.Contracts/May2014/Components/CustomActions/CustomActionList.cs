using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.CustomActions
{
    /// <summary>
    /// A collection of <see cref="CustomAction"/> objects
    /// </summary>
    [CollectionDataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class CustomActionList : RestCollectionDataContract<CustomAction>
    {
        public CustomActionList()
        {

        }

        public CustomActionList(IEnumerable<CustomAction> customActions)
            : base(customActions)
        {

        }
    }
}