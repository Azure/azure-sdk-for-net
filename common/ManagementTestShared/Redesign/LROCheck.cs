// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System.Collections.Generic;

#nullable disable

namespace Azure.ResourceManager.TestFramework
{
    public class LROCheck : HttpPipelineSynchronousPolicy
    {
        public override void OnReceivedResponse(HttpMessage message)
        {
            if (message.Request.Uri.ToString().Contains("Microsoft.OperationalInsights"))
            {
                string locationUri;
                var oldHeader = message.Response.Headers;
                var headerList = new List<HttpHeader>();
                if (oldHeader.TryGetValue("Location", out locationUri))
                {
                    if (locationUri.Contains("/operationresults/"))
                    {
                        foreach (var item in oldHeader)
                        {
                            if (!item.Name.Equals("Location"))
                            {
                                headerList.Add(item);
                            }
                        }
                    }
                }
                message.Response.Headers = ;
                message.Response
            }
        }
    }
}
