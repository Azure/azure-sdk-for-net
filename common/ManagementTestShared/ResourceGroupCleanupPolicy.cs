// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.RegularExpressions;

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.TestFramework
{
    public class ResourceGroupCleanupPolicy : HttpPipelineSynchronousPolicy
    {
        private Regex _resourceGroupPattern = new Regex(@"/subscriptions/[^/]+/resourcegroups/([^?/]+)\?api-version");
        private readonly IList<string> _resourceGroupCreated = new List<string>();

        public IList<string> ResourceGroupsCreated
        {
            get { return _resourceGroupCreated; }
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.Request.Method == RequestMethod.Put)
            {
                var match = _resourceGroupPattern.Match(message.Request.Uri.ToString());
                if (match.Success)
                {
                    _resourceGroupCreated.Add(match.Groups[1].Value);
                }
            }
        }
    }
}
