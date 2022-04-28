function BuildServiceDirectoryPrefix([string]$serviceName) {
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

function GetBaseName([string]$user, [string]$serviceDirectoryName) {
    # Handle service directories in nested directories, e.g. `data/aztables`
    $serviceDirectorySafeName = $serviceDirectoryName -replace '[/\\]', ''
    return "$user$serviceDirectorySafeName"
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
                if (ShouldMarkValueAsSecret "AZURE_" $nestedPair.Name $nestedPair.Value) {
                    Write-Host "##vso[task.setvariable variable=_$($nestedPair.Name);issecret=true;]$($nestedPair.Value)"
                }
            }
        } else {
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
