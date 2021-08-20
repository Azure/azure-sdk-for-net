// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Account.Tests
{
    public class PurviewCollectionTestEnvironment: TestEnvironment
    {
        public PurviewCollectionTestEnvironment()
        {
        }
        public PurviewCollectionTestEnvironment(string endpint)
        {
            this._endpoint = endpint;
        }
        private string _endpoint;

        public string Endpoint { get => _endpoint; set => _endpoint = value; }
    }
}
