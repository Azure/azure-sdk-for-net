function Log($Message) {
    Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

# vso commands are specially formatted log lines that are parsed by Azure Pipelines
# to perform additional actions, most commonly marking values as secrets.
# https://docs.microsoft.com/en-us/azure/devops/pipelines/scripts/logging-commands
function LogVsoCommand([string]$message) {
    if (!$CI -or $SuppressVsoCommands) {
        return
    }
    Write-Host $message
}

function Retry([scriptblock] $Action, [int] $Attempts = 5) {
    $attempt = 0
    $sleep = 5

    while ($attempt -lt $Attempts) {
        try {
            $attempt++
            return $Action.Invoke()
        }
        catch {
            if ($attempt -lt $Attempts) {
                $sleep *= 2

                Write-Warning "Attempt $attempt failed: $_. Trying again in $sleep seconds..."
                Start-Sleep -Seconds $sleep
            }
            else {
                throw
            }
        }
    }
}

# NewServicePrincipalWrapper creates an object from an AAD graph or Microsoft Graph service principal object type.
# This is necessary to work around breaking changes introduced in Az version 7.0.0:
# https://azure.microsoft.com/en-us/updates/update-your-apps-to-use-microsoft-graph-before-30-june-2022/
function NewServicePrincipalWrapper([string]$subscription, [string]$resourceGroup, [string]$displayName) {
    if ((Get-Module Az.Resources).Version -eq "5.3.0") {
        # https://github.com/Azure/azure-powershell/issues/17040
        # New-AzAdServicePrincipal calls will fail with:
        # "You cannot call a method on a null-valued expression."
        Write-Warning "Az.Resources version 5.3.0 is not supported. Please update to >= 5.3.1"
        Write-Warning "Update-Module Az.Resources -RequiredVersion 5.3.1"
        exit 1
    }

    try {
        $servicePrincipal = Retry {
            New-AzADServicePrincipal -Role "Owner" -Scope "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName" -DisplayName $displayName
        }
    }
    catch {
        # The underlying error "The directory object quota limit for the Principal has been exceeded" gets overwritten by the module trying
        # to call New-AzADApplication with a null object instead of stopping execution, which makes this case hard to diagnose because it prints the following:
        #      "Cannot bind argument to parameter 'ObjectId' because it is an empty string."
        # Provide a more helpful diagnostic prompt to the user if appropriate:
        $totalApps = (Get-AzADApplication -OwnedApplication).Length
        $msg = "App Registrations owned by you total $totalApps and may exceed the max quota (likely around 135)." + `
            "`nTry removing some at https://ms.portal.azure.com/#view/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/~/RegisteredApps" + `
            " or by running the following command to remove apps created by this script:" + `
            "`n    Get-AzADApplication -DisplayNameStartsWith '$baseName' | Remove-AzADApplication" + `
            "`nNOTE: You may need to wait for the quota number to be updated after removing unused applications."
        Write-Warning $msg
        throw
    }

    $spPassword = ""
    $appId = ""
    if (Get-Member -Name "Secret" -InputObject $servicePrincipal -MemberType property) {
        Write-Verbose "Using legacy PSADServicePrincipal object type from AAD graph API"
        # Secret property exists on PSADServicePrincipal type from AAD graph in Az # module versions < 7.0.0
        $spPassword = $servicePrincipal.Secret
        $appId = $servicePrincipal.ApplicationId
    }
    else {
        if ((Get-Module Az.Resources).Version -eq "5.1.0") {
            Write-Verbose "Creating password and credential for service principal via MS Graph API"
            Write-Warning "Please update Az.Resources to >= 5.2.0 by running 'Update-Module Az'"
            # Microsoft graph objects (Az.Resources version == 5.1.0) do not provision a secret on creation so it must be added separately.
            # Submitting a password credential object without specifying a password will result in one being generated on the server side.
            $password = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential"
            $password.DisplayName = "Password for $displayName"
            $credential = Retry { New-AzADSpCredential -PasswordCredentials $password -ServicePrincipalObject $servicePrincipal -ErrorAction 'Stop' }
            $spPassword = ConvertTo-SecureString $credential.SecretText -AsPlainText -Force
            $appId = $servicePrincipal.AppId
        }
        else {
            Write-Verbose "Creating service principal credential via MS Graph API"
            # In 5.2.0 the password credential issue was fixed (see https://github.com/Azure/azure-powershell/pull/16690) but the
            # parameter set was changed making the above call fail due to a missing ServicePrincipalId parameter.
            $credential = Retry { $servicePrincipal | New-AzADSpCredential -ErrorAction 'Stop' }
            $spPassword = ConvertTo-SecureString $credential.SecretText -AsPlainText -Force
            $appId = $servicePrincipal.AppId
        }
    }

    return @{
        AppId         = $appId
        ApplicationId = $appId
        # This is the ObjectId/OID but most return objects use .Id so keep it consistent to prevent confusion
        Id            = $servicePrincipal.Id
        DisplayName   = $servicePrincipal.DisplayName
        Secret        = $spPassword
    }
}

function LoadCloudConfig([string] $env) {
    $configPath = "$PSScriptRoot/clouds/$env.json"
    if (!(Test-Path $configPath)) {
        Write-Warning "Could not find cloud configuration for environment '$env'"
        return @{}
    }

    $config = Get-Content $configPath | ConvertFrom-Json -AsHashtable
    return $config
}

function MergeHashes([hashtable] $source, [psvariable] $dest) {
    foreach ($key in $source.Keys) {
        if ($dest.Value.Contains($key) -and $dest.Value[$key] -ne $source[$key]) {
            Write-Warning ("Overwriting '$($dest.Name).$($key)' with value '$($dest.Value[$key])' " +
                "to new value '$($source[$key])'")
        }
        $dest.Value[$key] = $source[$key]
    }
}

function BuildBicepFile([System.IO.FileSystemInfo] $file) {
    if (!(Get-Command bicep -ErrorAction Ignore)) {
        Write-Error "A bicep file was found at '$($file.FullName)' but the Azure Bicep CLI is not installed. See aka.ms/bicep-install"
        throw
    }

    $tmp = $env:TEMP ? $env:TEMP : [System.IO.Path]::GetTempPath()
    $templateFilePath = Join-Path $tmp "$ResourceType-resources.$(New-Guid).compiled.json"

    # Az can deploy bicep files natively, but by compiling here it becomes easier to parse the
    # outputted json for mismatched parameter declarations.
    bicep build $file.FullName --outfile $templateFilePath
    if ($LASTEXITCODE) {
        Write-Error "Failure building bicep file '$($file.FullName)'"
        throw
    }

    return $templateFilePath
}

function BuildDeploymentOutputs([string]$serviceName, [object]$azContext, [object]$deployment, [hashtable]$environmentVariables) {
    $serviceDirectoryPrefix = BuildServiceDirectoryPrefix $serviceName
    # Add default values
    $deploymentOutputs = [Ordered]@{
        "${serviceDirectoryPrefix}SUBSCRIPTION_ID"        = $azContext.Subscription.Id;
        "${serviceDirectoryPrefix}RESOURCE_GROUP"         = $resourceGroup.ResourceGroupName;
        "${serviceDirectoryPrefix}LOCATION"               = $resourceGroup.Location;
        "${serviceDirectoryPrefix}ENVIRONMENT"            = $azContext.Environment.Name;
        "${serviceDirectoryPrefix}AZURE_AUTHORITY_HOST"   = $azContext.Environment.ActiveDirectoryAuthority;
        "${serviceDirectoryPrefix}RESOURCE_MANAGER_URL"   = $azContext.Environment.ResourceManagerUrl;
        "${serviceDirectoryPrefix}SERVICE_MANAGEMENT_URL" = $azContext.Environment.ServiceManagementUrl;
        "AZURE_SERVICE_DIRECTORY"                         = $serviceName.ToUpperInvariant();
    }

    if ($ServicePrincipalAuth) {
        $deploymentOutputs["${serviceDirectoryPrefix}CLIENT_ID"] = $TestApplicationId;
        $deploymentOutputs["${serviceDirectoryPrefix}CLIENT_SECRET"] = $TestApplicationSecret;
        $deploymentOutputs["${serviceDirectoryPrefix}TENANT_ID"] = $azContext.Tenant.Id;
    }

    MergeHashes $environmentVariables $(Get-Variable deploymentOutputs)

    foreach ($key in $deployment.Outputs.Keys) {
        $variable = $deployment.Outputs[$key]

        # Work around bug that makes the first few characters of environment variables be lowercase.
        $key = $key.ToUpperInvariant()

        if ($variable.Type -eq 'String' -or $variable.Type -eq 'SecureString') {
            $deploymentOutputs[$key] = $variable.Value
        }
    }

    # Force capitalization of all keys to avoid Azure Pipelines confusion with
    # variable auto-capitalization and OS env var capitalization differences
    $capitalized = @{}
    foreach ($item in $deploymentOutputs.GetEnumerator()) {
        $capitalized[$item.Name.ToUpperInvariant()] = $item.Value
    }

    return $capitalized
}

function SetDeploymentOutputs(
    [string]$serviceName,
    [object]$azContext,
    [object]$deployment,
    [object]$templateFile,
    [hashtable]$environmentVariables = @{}
) {
    $deploymentEnvironmentVariables = $environmentVariables.Clone()
    $deploymentOutputs = BuildDeploymentOutputs $serviceName $azContext $deployment $deploymentEnvironmentVariables

    if ($OutFile) {
        if (!$IsWindows) {
            Write-Host 'File option is supported only on Windows'
        }

        $outputFile = "$($templateFile.originalFilePath).env"

        $environmentText = $deploymentOutputs | ConvertTo-Json;
        $bytes = [System.Text.Encoding]::UTF8.GetBytes($environmentText)
        $protectedBytes = [Security.Cryptography.ProtectedData]::Protect($bytes, $null, [Security.Cryptography.DataProtectionScope]::CurrentUser)

        Set-Content $outputFile -Value $protectedBytes -AsByteStream -Force

        Write-Host "Test environment settings`n $environmentText`nstored into encrypted $outputFile"
    }
    else {
        if (!$CI) {
            # Write an extra new line to isolate the environment variables for easy reading.
            Log "Persist the following environment variables based on your detected shell ($shell):`n"
        }

        # Write overwrite warnings first, since local execution prints a runnable command to export variables
        foreach ($key in $deploymentOutputs.Keys) {
            if ([Environment]::GetEnvironmentVariable($key)) {
                Write-Warning "Deployment outputs will overwrite pre-existing environment variable '$key'"
            }
        }

        # Marking values as secret by allowed keys below is not sufficient, as there may be outputs set in the ARM/bicep
        # file that re-mark those values as secret (since all user-provided deployment outputs are treated as secret by default).
        # This variable supports a second check on not marking previously allowed keys/values as secret.
        $notSecretValues = @()
        foreach ($key in $deploymentOutputs.Keys) {
            $value = $deploymentOutputs[$key]
            $deploymentEnvironmentVariables[$key] = $value

            if ($CI) {
                if (ShouldMarkValueAsSecret $serviceName $key $value $notSecretValues) {
                    # Treat all ARM template output variables as secrets since "SecureString" variables do not set values.
                    # In order to mask secrets but set environment variables for any given ARM template, we set variables twice as shown below.
                    LogVsoCommand "##vso[task.setvariable variable=_$key;issecret=true;]$value"
                    Write-Host "Setting variable as secret '$key'"
                }
                else {
                    Write-Host "Setting variable '$key': $value"
                    $notSecretValues += $value
                }
                LogVsoCommand "##vso[task.setvariable variable=$key;]$value"
            }
            else {
                Write-Host ($shellExportFormat -f $key, $value)
            }
        }

        if ($key) {
            # Isolate the environment variables for easy reading.
            Write-Host "`n"
            $key = $null
        }
    }

    return $deploymentEnvironmentVariables, $deploymentOutputs
}
