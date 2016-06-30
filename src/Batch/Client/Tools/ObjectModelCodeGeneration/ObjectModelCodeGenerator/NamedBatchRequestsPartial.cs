namespace ObjectModelCodeGenerator
{
    using System.Collections.Generic;
    using ProxyLayerParser;

    public partial class NamedBatchRequests
    {
        public NamedBatchRequests(IEnumerable<BatchRequestGroup> batchRequests)
        {
            this._batchRequestsField = batchRequests;
        }
    }
}
