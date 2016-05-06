using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvenienceLayerCodeGenerationTest
{
    using RoslynParser;

    public partial class NamedBatchRequests
    {
        public NamedBatchRequests(Dictionary<string, IEnumerable<BatchRequestTemplate>> batchRequests)
        {
            this._batchRequestsField = batchRequests;
        }
    }
}
