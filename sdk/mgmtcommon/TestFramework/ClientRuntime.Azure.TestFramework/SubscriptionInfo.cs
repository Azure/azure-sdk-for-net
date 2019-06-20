// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
  public class SubscriptionInfo
  {
    public SubscriptionInfo(JObject resultObject)
    {
        Id = (string)(resultObject["id"]);
        SubscriptionId = (string)(resultObject["subscriptionId"]);
        DisplayName = (string)(resultObject["displayName"]);
        State = (string)(resultObject["state"]);
    }

    public string Id { get; set; }

    public string SubscriptionId { get; set; }

    public string DisplayName { get; set; }

    public string State { get; set; }
  }
}
