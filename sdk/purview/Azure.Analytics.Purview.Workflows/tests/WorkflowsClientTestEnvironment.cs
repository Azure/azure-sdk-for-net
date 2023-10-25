// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Analytics.Purview.Workflows.Tests
{
    public class WorkflowsClientTestEnvironment : TestEnvironment
    {
        private TokenCredential _usernamePasswordcredential;

        public WorkflowsClientTestEnvironment()
        {
        }
        public Uri Endpoint => new(GetRecordedVariable("WORKFLOW_ENDPOINT"));

        public TokenCredential UsernamePasswordCredential
        {
            get
            {
                if (_usernamePasswordcredential != null)
                {
                    return _usernamePasswordcredential;
                }

                if (Mode == RecordedTestMode.Playback)
                {
                    _usernamePasswordcredential = new MockCredential();
                }
                else
                {
                    _usernamePasswordcredential = new UsernamePasswordCredential(
                        GetVariable("Username"),
                        GetVariable("Password"),
                        GetVariable("TenantId"),
                        GetVariable("ClientId")
                    );
                }

                return _usernamePasswordcredential;
            }
        }
    }
}
