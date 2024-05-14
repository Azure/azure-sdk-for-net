function BuildServiceDirectoryPrefix([string]$serviceName) {
    $serviceName = $serviceName -replace '[\./\\]', '_'
    return $serviceName.ToUpperInvariant() + "_"
}

# If the ServiceDirectory has multiple segments use the last directory name
# e.g. D:\foo\bar -> bar or foo/bar -> bar
function GetServiceLeafDirectoryName([string]$serviceDirectory) {
    return $serviceDirectory ? (Split-Path -Leaf $serviceDirectory) : ""
}

function GetUserName() {
    $UserName = $env:USER ?? $env:USERNAME
    # Remove spaces, etc. that may be in $UserName
    $UserName = $UserName -replace '\W'
    return $UserName
}

function GetBaseAndResourceGroupNames(
    [string]$baseNameDefault,
    [string]$resourceGroupNameDefault,
    [string]$user,
    [string]$serviceDirectoryName,
    [bool]$CI
) {
    if ($baseNameDefault) {
        $base = $baseNameDefault.ToLowerInvariant()
        $group = $resourceGroupNameDefault ? $resourceGroupNameDefault : ("rg-$baseNameDefault".ToLowerInvariant())
        return $base, $group
    }

    if ($CI) {
        $base = 't' + (New-Guid).ToString('n').Substring(0, 16)
        # Format the resource group name based on resource group naming recommendations and limitations.
        $generatedGroup = "rg-{0}-$base" -f ($serviceName -replace '[\.\\\/:]', '-').
                            Substring(0, [Math]::Min($serviceDirectoryName.Length, 90 - $base.Length - 4)).
                            Trim('-').
                            ToLowerInvariant()
        $group = $resourceGroupNameDefault ? $resourceGroupNameDefault : $generatedGroup

        Log "Generated resource base name '$base' and resource group name '$group' for CI build"

        return $base, $group
    }

    # Handle service directories in nested directories, e.g. `data/aztables`
    $serviceDirectorySafeName = $serviceDirectoryName -replace '[\./\\]', ''
    # Seed off resource group name if set to avoid name conflicts with deployments where it is not set
    $seed = $resourceGroupNameDefault ? $resourceGroupNameDefault : "${user}${serviceDirectorySafeName}"
    $baseNameStream = [IO.MemoryStream]::new([Text.Encoding]::UTF8.GetBytes("$seed"))
    # Hash to keep resource names short enough to not break naming restrictions (e.g. keyvault name length)
    $base = 't' + (Get-FileHash -InputStream $baseNameStream -Algorithm SHA256).Hash.Substring(0, 16).ToLowerInvariant()
    $group = $resourceGroupNameDefault ? $resourceGroupNameDefault : "rg-${user}${serviceDirectorySafeName}".ToLowerInvariant();

    Log "BaseName was not set. Generating resource group name '$group' and resource base name '$base'"

    return $base, $group
}

function ShouldMarkValueAsSecret([string]$serviceName, [string]$key, [string]$value, [array]$allowedValues = @())
{
    $logOutputNonSecret = @(
        # Environment Variables
        "RESOURCEGROUP_NAME",
        # Deployment Outputs
        "CLIENT_ID",
        "TENANT_ID",
        "SUBSCRIPTION_ID",
        "RESOURCE_GROUP",
        "LOCATION",
        "ENVIRONMENT",
        "AUTHORITY_HOST",
        "RESOURCE_MANAGER_URL",
        "SERVICE_MANAGEMENT_URL",
        "ENDPOINT_SUFFIX",
        "SERVICE_DIRECTORY",
        # This is used in many places and is harder to extract from the base subscription config, so hardcode it for now.
        "STORAGE_ENDPOINT_SUFFIX",
        # Parameters
        "Environment",
        "SubscriptionId",
        "TenantId",
        "TestApplicationId",
        "TestApplicationOid",
        "ProvisionerApplicationId"
    )

    $serviceDirectoryPrefix = BuildServiceDirectoryPrefix $serviceName

    $suffix1 = $key -replace $serviceDirectoryPrefix, ""
    $suffix2 = $key -replace "AZURE_", ""
    $variants = @($key, $suffix1, $suffix2)
    if ($variants | Where-Object { $logOutputNonSecret -contains $_ }) {
        return $false
    }

    if ($allowedValues -contains $value) {
        return $false
    }

    return $true
}

function SetSubscriptionConfiguration([object]$subscriptionConfiguration)
{
    foreach($pair in $subscriptionConfiguration.GetEnumerator()) {
        if ($pair.Value -is [Hashtable]) {
            foreach($nestedPair in $pair.Value.GetEnumerator()) {
                # Mark values as secret so we don't print json blobs containing secrets in the logs.
                # Prepend underscore to the variable name, so we can still access the variable names via environment
                # variables if they get set subsequently.
                if ([Environment]::GetEnvironmentVariable($nestedPair.Name)) {
                    throw "Environment variable '$($nestedPair.Name)' is already set. Check the tests.yml/ci.yml EnvVars parameter does not conflict with the subscription config json"
                }
                if (ShouldMarkValueAsSecret "AZURE_" $nestedPair.Name $nestedPair.Value) {
                    Write-Host "##vso[task.setvariable variable=_$($nestedPair.Name);issecret=true;]$($nestedPair.Value)"
                }
            }
        } else {
            if ([Environment]::GetEnvironmentVariable($pair.Name)) {
                throw "Environment variable '$($pair.Name)' is already set. Check the tests.yml/ci.yml EnvVars parameter does not conflict with the subscription config json"
            }
            if (ShouldMarkValueAsSecret "AZURE_" $pair.Name $pair.Value) {
                Write-Host "##vso[task.setvariable variable=_$($pair.Name);issecret=true;]$($pair.Value)"
            }
        }
    }

    Write-Host ($subscriptionConfiguration | ConvertTo-Json)
    $serialized = $subscriptionConfiguration | ConvertTo-Json -Compress
    Write-Host "##vso[task.setvariable variable=SubscriptionConfiguration;]$serialized"
}

function UpdateSubscriptionConfiguration([object]$subscriptionConfigurationBase, [object]$subscriptionConfiguration)
{
        foreach ($pair in $subscriptionConfiguration.GetEnumerator()) {
            if ($pair.Value -is [Hashtable]) {
                if (!$subscriptionConfigurationBase.ContainsKey($pair.Name)) {
                    $subscriptionConfigurationBase[$pair.Name] = @{}
                }
                foreach($nestedPair in $pair.Value.GetEnumerator()) {
                    # Mark values as secret so we don't print json blobs containing secrets in the logs.
                    # Prepend underscore to the variable name, so we can still access the variable names via environment
                    # variables if they get set subsequently.
                    if (ShouldMarkValueAsSecret "AZURE_" $nestedPair.Name $nestedPair.Value) {
                        Write-Host "##vso[task.setvariable variable=_$($nestedPair.Name);issecret=true;]$($nestedPair.Value)"
                    }
                    $subscriptionConfigurationBase[$pair.Name][$nestedPair.Name] = $nestedPair.Value
                }
            } else {
                if (ShouldMarkValueAsSecret "AZURE_" $pair.Name $pair.Value) {
                    Write-Host "##vso[task.setvariable variable=_$($pair.Name);issecret=true;]$($pair.Value)"
                }
                $subscriptionConfigurationBase[$pair.Name] = $pair.Value
            }
        }

        $serialized = $subscriptionConfigurationBase | ConvertTo-Json -Compress
        Write-Host ($subscriptionConfigurationBase | ConvertTo-Json)
        Write-Host "##vso[task.setvariable variable=SubscriptionConfiguration;]$serialized"
}
