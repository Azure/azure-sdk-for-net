namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class DataFlowSource : Transformation
    {
        /// <summary>
        /// Initializes a new instance of the DataFlowSource class.
        /// </summary>
        /// <param name="name">Transformation name.</param>
        /// <param name="description">Transformation description.</param>
        /// <param name="dataset">Dataset reference.</param>
        /// <param name="linkedService">Linked service reference.</param>
        /// <param name="schemaLinkedService">Schema linked service
        /// reference.</param>
        public DataFlowSource(string name, string description = default(string), DatasetReference dataset = default(DatasetReference), LinkedServiceReference linkedService = default(LinkedServiceReference), LinkedServiceReference schemaLinkedService = default(LinkedServiceReference))
            : base(name, description, default(DataFlowReference))
        {
            Dataset = dataset;
            LinkedService = linkedService;
            SchemaLinkedService = schemaLinkedService;
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DataFlowSource class.
        /// </summary>
        /// <param name="name">Transformation name.</param>
        /// <param name="description">Transformation description.</param>
        /// <param name="flowlet">Flowlet Reference</param>
        /// <param name="dataset">Dataset reference.</param>
        /// <param name="linkedService">Linked service reference.</param>
        /// <param name="schemaLinkedService">Schema linked service
        /// reference.</param>
        public DataFlowSource(string name, string description = default(string), DataFlowReference flowlet = default(DataFlowReference), DatasetReference dataset = default(DatasetReference), LinkedServiceReference linkedService = default(LinkedServiceReference), LinkedServiceReference schemaLinkedService = default(LinkedServiceReference))
            : base(name, description, flowlet)
        {
            Dataset = dataset;
            LinkedService = linkedService;
            SchemaLinkedService = schemaLinkedService;
            CustomInit();
        }
    }
}
