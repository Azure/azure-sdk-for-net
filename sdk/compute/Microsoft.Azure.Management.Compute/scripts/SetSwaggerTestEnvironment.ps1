param
(
    [Parameter(Mandatory=$true, ParameterSetName = "Record", Position = 0)]
    [Parameter(Mandatory=$false, ParameterSetName = "Mode", Position = 0)]
    [ValidateSet("Record", "Playback")]
    [string]$Mode,

    [Parameter(Mandatory=$true, ParameterSetName = "Admin", Position = 0)]
    [Switch]$Admin,

    [Parameter(Mandatory=$true, ParameterSetName = "Record", Position = 1)]
    [Parameter(Mandatory=$true, ParameterSetName = "Admin", Position = 1)]
    [Parameter(Mandatory=$false, ParameterSetName = "Mode", Position = 1)]
    [string]$SubscriptionId,
    
    [Parameter(Mandatory=$true, ParameterSetName = "Record", Position = 2)]
    [string]$AADClientId,

    [Parameter(Mandatory=$true, ParameterSetName = "Record", Position = 3)]
    [string]$ApplicationSecret,

    [Parameter(Mandatory=$true, ParameterSetName = "Record", Position = 4)]
    [string]$AADTenant,

    [Parameter(Mandatory=$false, ParameterSetName = "Record", Position = 5)]
    [string]$Environment = "",

    [Parameter(Mandatory=$false, ParameterSetName = "Record", Position = 6)]
    [string]$BaseUri = "",

    [Parameter(Mandatory=$false, ParameterSetName = "Mode", Position = 2)]
    [string]$UserId = "",

    [Parameter(Mandatory=$false, ParameterSetName = "Record", Position = 7)]
    [Parameter(Mandatory=$false, ParameterSetName = "Mode", Position = 3)]
    [string]$Location = "",

    [Parameter(Mandatory=$false)]
    [string]$SolutionFile = "..\..\Microsoft.Azure.Management.Compute\Microsoft.Azure.Management.Compute.sln"
)

Write-Host "=========================================";
Write-Host "Sample Commands :";
Write-Host "-----------------------------------------";
Write-Host "powershell -file .\New-TestEnvironment.ps1 -Mode Record -SubscriptionId xxx -AADClientId xxx -ApplicationSecret xxx -AADTenant xxx -Environment Prod";
Write-Host "powershell -file .\New-TestEnvironment.ps1 -Admin -SubscriptionId xxx";
Write-Host "powershell -file .\New-TestEnvironment.ps1";
Write-Host
Write-Host "=========================================";
Write-Host "Input Variables :";
Write-Host "-----------------------------------------";
Write-Host "`$Mode=$Mode";
Write-Host "`$SubscriptionId=$SubscriptionId";
Write-Host "`$AADClientId=$AADClientId";
Write-Host "`$ApplicationSecret=$ApplicationSecret";
Write-Host "`$AADTenant=$AADTenant";
Write-Host "`$Environment=$Environment";
Write-Host "=========================================";

$table = @{
    "AZURE_TEST_MODE" = "Playback";
    "TEST_CSM_SPN_AUTHENTICATION" = "";
    "TEST_CSM_ORGID_AUTHENTICATION" = "";
    "TEST_ORGID_AUTHENTICATION" = "";
    "TEST_CONNECTION_STRING" = "";
    "TEST_PUBLISHSETTINGS_FILE" = "";
    "AZURE_VM_TEST_LOCATION" = "";
};

if ($Mode.ToLower() -eq 'record')
{
    $table["AZURE_TEST_MODE"] = "Record";

    if ([System.String]::IsNullOrEmpty($AADClientId))
    {
        if ([System.String]::IsNullOrEmpty($UserId))
        {
            $table["TEST_CSM_ORGID_AUTHENTICATION"] = "SubscriptionId=${SubscriptionId};";
            $table["TEST_ORGID_AUTHENTICATION"] = "SubscriptionId=${SubscriptionId};";
        }
        else
        {
            $table["TEST_CSM_ORGID_AUTHENTICATION"] = "SubscriptionId=${SubscriptionId};UserId=${UserId}";
            $table["TEST_ORGID_AUTHENTICATION"] = "SubscriptionId=${SubscriptionId};UserId=${UserId}";
        }
    }
    else
    {
        $table["TEST_CSM_ORGID_AUTHENTICATION"] = "SubscriptionId=${SubscriptionId};ServicePrincipal=${AADClientId};Password=${ApplicationSecret};AADTenant=${AADTenant}";
    }

    if (-not [System.String]::IsNullOrEmpty($BaseUri))
    {
        $table["TEST_ORGID_AUTHENTICATION"] = $table["TEST_ORGID_AUTHENTICATION"] += ';BaseUri=' + $BaseUri;
        $table["TEST_CSM_ORGID_AUTHENTICATION"] = $table["TEST_CSM_ORGID_AUTHENTICATION"] += ';BaseUri=' + $BaseUri;
    }

    if (-not [System.String]::IsNullOrEmpty($Environment))
    {
        $table["TEST_ORGID_AUTHENTICATION"] = $table["TEST_ORGID_AUTHENTICATION"] += ';Environment=' + $Environment;
        $table["TEST_CSM_ORGID_AUTHENTICATION"] = $table["TEST_CSM_ORGID_AUTHENTICATION"] += ';Environment=' + $Environment;
    }
}
else
{
    $table["AZURE_TEST_MODE"] = "Playback";
}

if (-not [System.String]::IsNullOrEmpty($Location))
{
    $table["AZURE_VM_TEST_LOCATION"] = $Location;
}

Write-Host "Environment Variables :";
Write-Host "-----------------------------------------";
foreach ($key in $table.Keys) {
    $value = $table[$key];
    [Environment]::SetEnvironmentVariable($key, $value, "Process");
}

foreach ($key in $table.Keys) {
    Write-Host ("$key = " + [Environment]::GetEnvironmentVariable($key));
}

Write-Host "=========================================";
Write-Host "Setup Finished; Opening File ${SolutionFile}...";
Invoke-Item $SolutionFile;
