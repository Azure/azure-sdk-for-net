using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class ExcelDataset : Dataset
    {
        /// <summary>
        /// Initializes a new instance of the ExcelDataset class.
        /// </summary>
        /// <param name="linkedServiceName">Linked service reference.</param>
        /// <param name="location">The location of the excel storage.</param>
        /// <param name="sheetName">The sheet of excel file. Type: string (or
        /// Expression with resultType string).</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="description">Dataset description.</param>
        /// <param name="structure">Columns that define the structure of the
        /// dataset. Type: array (or Expression with resultType array),
        /// itemType: DatasetDataElement.</param>
        /// <param name="schema">Columns that define the physical type schema
        /// of the dataset. Type: array (or Expression with resultType array),
        /// itemType: DatasetSchemaDataElement.</param>
        /// <param name="parameters">Parameters for dataset.</param>
        /// <param name="annotations">List of tags that can be used for
        /// describing the Dataset.</param>
        /// <param name="folder">The folder that this Dataset is in. If not
        /// specified, Dataset will appear at the root level.</param>
        /// <param name="range">The partial data of one sheet. Type: string (or
        /// Expression with resultType string).</param>
        /// <param name="firstRowAsHeader">When used as input, treat the first
        /// row of data as headers. When used as output,write the headers into
        /// the output as the first row of data. The default value is false.
        /// Type: boolean (or Expression with resultType boolean).</param>
        /// <param name="compression">The data compression method used for the
        /// json dataset.</param>
        /// <param name="nullValue">The null value string. Type: string (or
        /// Expression with resultType string).</param>
        public ExcelDataset(LinkedServiceReference linkedServiceName, DatasetLocation location, object sheetName, IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), string description = default(string), object structure = default(object), object schema = default(object), IDictionary<string, ParameterSpecification> parameters = default(IDictionary<string, ParameterSpecification>), IList<object> annotations = default(IList<object>), DatasetFolder folder = default(DatasetFolder), object range = default(object), object firstRowAsHeader = default(object), DatasetCompression compression = default(DatasetCompression), object nullValue = default(object))
            : base(linkedServiceName, additionalProperties, description, structure, schema, parameters, annotations, folder)
        {
            Location = location;
            SheetName = sheetName;
            Range = range;
            FirstRowAsHeader = firstRowAsHeader;
            Compression = compression;
            NullValue = nullValue;
            CustomInit();
        }
    }
}
