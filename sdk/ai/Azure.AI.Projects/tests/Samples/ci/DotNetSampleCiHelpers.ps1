# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

function Get-DotNetSampleEnvironment {
    param([Parameter(Mandatory)] [System.Collections.IDictionary] $Environment)

    Assert-SampleEnvironment -Environment $Environment -Names @(Get-SampleEnvironmentNames)
    $bindings = @{}
    foreach ($name in $Environment.Keys) { $bindings[$name] = $Environment[$name] }
    # These .NET properties say "NAME", but are passed to ProjectConnectionId.
    $bindings.MCP_PROJECT_CONNECTION_NAME = $Environment.MCP_PROJECT_CONNECTION_ID
    $bindings.AI_SEARCH_CONNECTION_NAME = $Environment.AI_SEARCH_PROJECT_CONNECTION_ID
    $bindings.BING_CONNECTION_ID = $Environment.BING_PROJECT_CONNECTION_ID
    $bindings.BING_CONNECTION_NAME = $Environment.BING_PROJECT_CONNECTION_NAME
    $bindings.CUSTOM_BING_CONNECTION_ID = $Environment.BING_CUSTOM_SEARCH_PROJECT_CONNECTION_ID
    $bindings.CUSTOM_BING_CONNECTION_NAME = $Environment.BING_CUSTOM_SEARCH_PROJECT_CONNECTION_NAME
    $bindings.PLAYWRIGHT_CONNECTION_ID = $Environment.BROWSER_AUTOMATION_PROJECT_CONNECTION_ID
    $bindings.PLAYWRIGHT_CONNECTION_NAME = $Environment.BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME
    $bindings.BROWSER_AUTOMATION_NAME = $Environment.BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME
    $bindings.STORAGE_QUEUE_URI = $Environment.STORAGE_QUEUE_SERVICE_ENDPOINT.TrimEnd('/')
    return $bindings
}
