using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class Transformation
    {
        /// <summary>
        /// Initializes a new instance of the Transformation class.
        /// </summary>
        /// <param name="name">Transformation name.</param>
        /// <param name="description">Transformation description.</param>
        /// <param name="flowlet">Flowlet Reference</param>
        public Transformation(string name, string description = default(string), DataFlowReference flowlet = default(DataFlowReference))
        {
            Name = name;
            Description = description;
            Flowlet = flowlet;
            CustomInit();
        }
    }
}
