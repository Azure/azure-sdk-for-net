# Generates an index page for cataloging different versions of the Docs

[CmdletBinding()]
Param (
    $RepoRoot
)

$ServiceMapping = @{
    "advisor"="Advisor";
    "alertsmanagement"="Alerts Management"; "analysisservices"="Analysis Services";
    "apimanagement"="API Management"; "appconfiguration"="App Configuration";
    "applicationinsights"="Application Insights"; "appplatform"="App Service";
    "attestation"="Attestation"; "authorization"="Authorization";
    "automation"="Automation"; "azurestack"="Azure Stack";
    "batch"="Batch"; "batchai"="Batch AI";
    "billing"="Billing"; "blueprint"="Blueprint";
    "botservice"="Bot Service"; "cdn"="CDN";
    "cognitiveservices"="Cognitive Services"; "compute"="Compute";
    "consumption"="Consumption"; "containerinstance"="Container Instance";
    "containerregistry"="Container Registry"; "containerservice"="Container Service";
    "core"="Core"; "cost-management"="Cost Management";
    "customer-insights"="Customer Insights"; "customproviders"="Custom Providers";
    "databox"="Data Box"; "databoxedge"="Data Box Edge";
    "datafactory"="Data Factory"; "datalake-analytics"="Data Lake Analytics";
    "datalake-store"="Data Lake Store"; "datamigration"="Data Migration";
    "datashare"="Data Share"; "deploymentmanager"="Deployment Manager";
    "deviceprovisioningservices"="Device Provisioning Services"; "devspaces"="Dev Spaces";
    "Dev Test Labs"=""; "dns"="DNS";
    "edgegateway"="Edge Gateway";
    "eventgrid"="Event Grid"; "eventhub"="Event Hub";
    "frontdoor"="Front Door"; "graphrbac"="Active Directory";
    "guestconfiguration"="Guest Configuration"; "hdinsight"="HDInsight";
    "healthcareapis"="Healthcare APIs"; "hybridcompute"="Hybrid Cloud";
    "hybriddatamanager"="Hybrid Datamanager"; "identity"="Identity";
    "insights"="Insights"; "iotcentral"="IoT Central";
    "iothub"="IoT"; "keyvault"="Keyvault";
    "kusto"="Kusto"; "labservices"="LabServices";
    "locationbasedservices"="Location Based Services"; "logic"="Logic Apps";
    "machinelearning"="Machine Learning"; "machinelearningcompute"="Machine Learning Compute";
    "maintenance"="Maintenance"; "managednetwork"="Managed Network";
    "managedserviceidentity"="Managed Service Identity"; "managedservices"="Managed Services";
    "managementgroups"="Management Groups"; "managementpartner"="Management Partner";
    "maps"="Maps"; "marketplaceordering"="Market Place Ordering";
    "mediaservices"="Media Services";
    "mixedreality"="Mixed Reality"; "monitor"="Monitor";
    "netapp"="NetApp"; "network"="Network";
    "notificationhubs"="Notification Hubs"; "operationalinsights"="Operational Insights";
    "peering"="Peering"; "policyinsights"="Policy Insights";
    "postgresql"="PostgreSQL"; "powerbidedicated"="PowerBI Dedicated";
    "privatedns"="Private DNS"; "recoveryservices"="Recovery Services";
    "recoveryservices-backup"="Recovery Services Backup"; "recoveryservices-siterecovery"="Recovery Services Site Recovery";
    "redis"="Redis"; "relay"="Relay";
    "reservations"="Reservations"; "resourcegraph"="Resource Graph";
    "resources"="Resources"; "scheduler"="Scheduler";
    "search"="Search"; "securitycenter"="Security Center";
    "servermanagement"="Server Management"; "servicebus"="Service Bus";
    "servicefabric"="Service Fabric"; "signalr"="signalR";
    "sqlmanagement"="SQL Management"; "sqlvirtualmachine"="SQL Virtual Machine";
    "storage"="Storage"; "storagecache"="Storage Cache";
    "storagesync"="Storage Sync"; "storsimple"="Stor Simple";
    "storsimple8000series"="Stor Simple 8000 series"; "streamanalytics"="Stream Analytics";
    "subscription"="Subscription";
    "trafficmanager"="Traffic Manager"; "websites"="Websites";
}


Write-Verbose "Initializing Default DocFx Site..."
& "$($RepoRoot)/docfx/docfx.exe" init -q -o "$($RepoRoot)/docfx_project"

Write-Verbose "Copying template and configuration..."
New-Item -Path "$($RepoRoot)/docfx_project" -Name "templates" -ItemType "directory"
Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/templates/*" -Destination "$($RepoRoot)/docfx_project/templates" -Force -Recurse
Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/docfx.json" -Destination "$($RepoRoot)/docfx_project/" -Force

Write-Verbose "Creating Index using service directory and package names from repo..."
$ServiceList = Get-ChildItem "$($RepoRoot)/sdk" -Directory -Exclude eng, mgmtcommon, template | Sort-Object
$YmlPath = "$($RepoRoot)/docfx_project/api"
New-Item -Path $YmlPath -Name "toc.yml" -Force

Write-Verbose "Creating Index for client packages..."
foreach ($Dir in $ServiceList)
{
    New-Item -Path $YmlPath -Name "$($Dir.Name).md" -Force
    $ServiceName = If ($ServiceMapping.Contains($Dir.Name)) { $ServiceMapping[$Dir.Name] } Else { $Dir.Name }
    Add-Content -Path "$($YmlPath)/toc.yml" -Value "- name: $($ServiceName)`r`n  href: $($Dir.Name).md"
    $PkgList = Get-ChildItem $Dir.FullName -Directory -Exclude .vs, .vscode, Azure.Security.KeyVault.Shared | Where-Object -FilterScript {$_.Name -notmatch ".Management."}

    if (($PkgList | Measure-Object).count -eq 0)
    {
        continue
    }
    Add-Content -Path "$($YmlPath)/$($Dir.Name).md" -Value "# Client"
    Add-Content -Path "$($YmlPath)/$($Dir.Name).md" -Value "---"
    Write-Verbose "Operating on Client Packages for $($Dir.Name)"

    foreach ($Pkg in $PkgList)
    {
        if (Test-Path "$($pkg.FullName)\src")
        {
            $ProjectName = Get-ChildItem "$($pkg.FullName)\src\*" -Include *.csproj
            Add-Content -Path "$($YmlPath)/$($Dir.Name).md" -Value "#### $($ProjectName.BaseName)"
        }  
    }
}

Write-Verbose "Creating Index for management packages..."
foreach ($Dir in $ServiceList)
{
    $PkgList = Get-ChildItem $Dir.FullName -Directory | Where-Object -FilterScript {$_.Name -match ".Management."}
    if (($PkgList | Measure-Object).count -eq 0)
    {
        continue
    }
    Add-Content -Path "$($YmlPath)/$($Dir.Name).md" -Value "# Management"
    Add-Content -Path "$($YmlPath)/$($Dir.Name).md" -Value "---"
    Write-Verbose "Operating on Management Packages for $($Dir.Name)"

    foreach ($Pkg in $PkgList)
    {
        if (Test-Path "$($pkg.FullName)\src")
        {
            $ProjectName = Get-ChildItem "$($pkg.FullName)\src\*" -Include *.csproj
            Add-Content -Path "$($YmlPath)/$($Dir.Name).md" -Value "#### $($ProjectName.BaseName)"
        }
    }
}

Write-Verbose "Creating Site Title and Navigation..."
New-Item -Path "$($RepoRoot)/docfx_project" -Name "toc.yml" -Force
Add-Content -Path "$($RepoRoot)/docfx_project/toc.yml" -Value "- name: Azure SDK for NET APIs`r`n  href: api/`r`n  homepage: api/index.md"

Write-Verbose "Copying root markdowns"
Copy-Item "$($RepoRoot)/README.md" -Destination "$($RepoRoot)/docfx_project/api/index.md" -Force
Copy-Item "$($RepoRoot)/CONTRIBUTING.md" -Destination "$($RepoRoot)/docfx_project/api/CONTRIBUTING.md" -Force

Write-Verbose "Building site..."
& "$($RepoRoot)/docfx/docfx.exe" build "$($RepoRoot)/docfx_project/docfx.json"

Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/assets/logo.svg" -Destination "$($RepoRoot)/docfx_project/_site/" -Force
Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/assets/toc.yml" -Destination "$($RepoRoot)/docfx_project/_site/" -Force