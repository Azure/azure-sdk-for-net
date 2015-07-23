namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [CollectionDataContract(Name = "OutputItems", ItemName = "OutputItem",
        Namespace = "http://schemas.microsoft.com/windowsazure")]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Done to maintain consistency with the contract. [tgs]")]
    internal class OutputItemList : List<OutputItem>
    {
        // Methods
        public OutputItemList()
        {
        }

        public OutputItemList(IEnumerable<OutputItem> outputs)
            : base(outputs)
        {
        }
    }
}