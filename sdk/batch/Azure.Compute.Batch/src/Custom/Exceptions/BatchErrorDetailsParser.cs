// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using System.ClientModel.Primitives;

namespace Azure.Compute.Batch
{
    internal class BatchErrorDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
        {
            data = new Dictionary<string, string>();
            try
            {
                BatchError batchError = ModelReaderWriter.Read<BatchError>(response.Content, new ModelReaderWriterOptions("J"), AzureComputeBatchContext.Default);

                if (batchError.Values != null && batchError.Values.Count > 0)
                {
                    foreach (BatchErrorDetail details in batchError.Values)
                    {
                        data.Add(details.Key, details.Value);
                    }
                }

                error = new ResponseError(batchError.Code, batchError.Message.Value);
                return true;
            }
            catch
            {
                error = new ResponseError(null, response.Content.ToString());
                return true;
            }
        }
    }
}
