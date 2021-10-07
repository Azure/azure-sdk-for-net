// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.TestFramework
{
    public class ManagementGroupCleanupPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly object _listLock = new object();
        private Regex _mgmtGroupPattern = new Regex(@"(/providers/Microsoft\.Management/managementGroups/[^?/]+)\?api-version");
        private readonly IList<string> _mgmtGroupCreated = new List<string>();

        public IList<string> ManagementGroupsCreated
        {
            get { return _mgmtGroupCreated; }
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.Request.Method == RequestMethod.Put)
            {
                var match = _mgmtGroupPattern.Match(message.Request.Uri.ToString());
                if (match.Success)
                {
                    lock (_listLock)
                    {
                        _mgmtGroupCreated.Add(match.Groups[1].Value);
                    }
                }
            }
        }
    }
}
