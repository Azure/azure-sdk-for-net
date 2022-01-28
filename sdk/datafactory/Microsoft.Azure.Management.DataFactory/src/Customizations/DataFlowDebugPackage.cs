using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class DataFlowDebugPackage
    {
        /// <summary>
        /// Initializes a new instance of the DataFlowDebugPackage class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="sessionId">The ID of data flow debug session.</param>
        /// <param name="dataFlow">Data flow instance.</param>
        /// <param name="datasets">List of datasets.</param>
        /// <param name="linkedServices">List of linked services.</param>
        /// <param name="staging">Staging info for debug session.</param>
        /// <param name="debugSettings">Data flow debug settings.</param>
        public DataFlowDebugPackage(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), string sessionId = default(string), DataFlowDebugResource dataFlow = default(DataFlowDebugResource), IList<DatasetDebugResource> datasets = default(IList<DatasetDebugResource>), IList<LinkedServiceDebugResource> linkedServices = default(IList<LinkedServiceDebugResource>), DataFlowStagingInfo staging = default(DataFlowStagingInfo), DataFlowDebugPackageDebugSettings debugSettings = default(DataFlowDebugPackageDebugSettings))
        {
            AdditionalProperties = additionalProperties;
            SessionId = sessionId;
            DataFlow = dataFlow;
            Datasets = datasets;
            LinkedServices = linkedServices;
            Staging = staging;
            DebugSettings = debugSettings;
            CustomInit();
        }
    }
}
