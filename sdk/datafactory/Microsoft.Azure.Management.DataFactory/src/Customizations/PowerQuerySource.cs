namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class PowerQuerySource : DataFlowSource
    {
        /// <summary>
        /// Initializes a new instance of the PowerQuerySource class.
        /// </summary>
        /// <param name="name">Transformation name.</param>
        /// <param name="description">Transformation description.</param>
        /// <param name="dataset">Dataset reference.</param>
        /// <param name="linkedService">Linked service reference.</param>
        /// <param name="schemaLinkedService">Schema linked service
        /// reference.</param>
        /// <param name="script">source script.</param>
        public PowerQuerySource(string name, string description = default(string), DatasetReference dataset = default(DatasetReference), LinkedServiceReference linkedService = default(LinkedServiceReference), LinkedServiceReference schemaLinkedService = default(LinkedServiceReference), string script = default(string))
            : base(name, description, dataset, linkedService, schemaLinkedService)
        {
            Script = script;
            CustomInit();
        }
    }
}
