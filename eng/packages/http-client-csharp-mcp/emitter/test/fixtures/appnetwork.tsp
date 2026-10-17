import "./client.tsp";

using Azure.Mcp;

@@tool(
  Microsoft.AppLink.AppLinks.get,
  "95293755-5b44-4e67-b2b0-75a838032e18",
  "appnetwork applink get",
  "Get Application Network"
);
@@openWorld(Microsoft.AppLink.AppLinks.get, false);
@@tool(
  Microsoft.AppLink.AppLinks.listByResourceGroup,
  "723605b4-2f2a-4e75-949a-e3c451dba808",
  "appnetwork applink list",
  "List Application Networks in Resource Group"
);
@@openWorld(Microsoft.AppLink.AppLinks.listByResourceGroup, false);
@@tool(
  Microsoft.AppLink.AppLinks.listBySubscription,
  "d8aa8ac7-86c4-49f0-8c9d-3b9e15297f45",
  "appnetwork applink subscription list",
  "List Application Networks in Subscription"
);
@@openWorld(Microsoft.AppLink.AppLinks.listBySubscription, false);
