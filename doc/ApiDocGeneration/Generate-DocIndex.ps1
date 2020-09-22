# Generates an index page for cataloging different versions of the Docs

[CmdletBinding()]
Param (
    $RepoRoot,
    $DocGenDir
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
    "communication" = "Communication"; "cosmosdb" = "Cosmos";
    "consumption"="Consumption"; "containerinstance"="Container Instance";
    "containerregistry"="Container Registry"; "containerservice"="Container Service";
    "core"="Core"; "cost-management"="Cost Management";
    "customer-insights"="Customer Insights"; "customproviders"="Custom Providers";
    "databox"="Data Box"; "databoxedge"="Data Box Edge";
    "datafactory"="Data Factory"; "datalake-analytics"="Data Lake Analytics";
    "datalake-store"="Data Lake Store"; "datamigration"="Data Migration";
    "datashare"="Data Share"; "deploymentmanager"="Deployment Manager";
    "deviceprovisioningservices"="Device Provisioning Services"; "devspaces"="Dev Spaces";
    "devtestlabs" = "Dev Test Labs"; "dns"="DNS"; "digitaltwins" = "Digital Twins";
    "edgegateway"="Edge Gateway";
    "eventgrid"="Event Grid"; "eventhub"="Event Hub"; "extensions" = "Extensions"
    "frontdoor"="Front Door"; "graphrbac"="Active Directory";
    "formrecognizer" = "Form Recognizer";
    "guestconfiguration"="Guest Configuration"; "hdinsight"="HDInsight";
    "healthcareapis"="Healthcare APIs"; "hybridcompute"="Hybrid Cloud";
    "hybriddatamanager"="Hybrid Datamanager"; "identity"="Identity";
    "insights"="Insights"; "iot" = "IoT"; "iotcentral"="IoT Central";
    "iothub"="IoTHub"; "keyvault"="Keyvault";
    "kusto"="Kusto"; "labservices"="LabServices";
    "locationbasedservices"="Location Based Services"; "logic"="Logic Apps";
    "machinelearning"="Machine Learning"; "machinelearningcompute"="Machine Learning Compute";
    "marketplace" = "Marketplace"; "maintenance"="Maintenance"; "managednetwork"="Managed Network";
    "managedserviceidentity"="Managed Service Identity"; "managedservices"="Managed Services";
    "managementgroups"="Management Groups"; "managementpartner"="Management Partner";
    "maps"="Maps"; "marketplaceordering"="Market Place Ordering";
    "mediaservices"="Media Services";
    "mixedreality"="Mixed Reality"; "monitor"="Monitor";
    "mysql" = "MySql";
    "netapp"="NetApp"; "network"="Network";
    "notificationhubs"="Notification Hubs"; "operationalinsights"="Operational Insights";
    "peering"="Peering"; "policyinsights"="Policy Insights";
    "postgresql"="PostgreSQL"; "powerbidedicated"="PowerBI Dedicated";
    "privatedns"="Private DNS"; "recoveryservices"="Recovery Services";
    "recoveryservices-backup"="Recovery Services Backup"; "recoveryservices-siterecovery"="Recovery Services Site Recovery";
    "redis"="Redis"; "relay"="Relay";
    "reservations"="Reservations"; "resourcegraph"="Resource Graph";
    "resourcemover" = "Resource Mover";
    "resources"="Resources"; "scheduler"="Scheduler";
    "search"="Search"; "securitycenter"="Security Center";
    "servermanagement"="Server Management"; "servicebus"="Service Bus";
    "servicefabric"="Service Fabric"; "signalr"="signalR";
    "schemaregistry" = "Schema Registry"
    "sqlmanagement"="SQL Management"; "sqlvirtualmachine"="SQL Virtual Machine";
    "synapse" = "Synapse";
    "storage"="Storage"; "storagecache"="Storage Cache";
    "storagesync"="Storage Sync"; "storsimple"="Stor Simple";
    "storsimple8000series"="Stor Simple 8000 series"; "streamanalytics"="Stream Analytics";
    "subscription"="Subscription"; 
    "tables" = "Tables"
    "textanalytics"="Text Analytics";
    "trafficmanager"="Traffic Manager"; "websites"="Websites";
}

Write-Verbose "Name Reccuring paths with variable names"
$DocFxTool = "${RepoRoot}/docfx/docfx.exe"
$DocOutDir = "${RepoRoot}/docfx_project"

Write-Verbose "Initializing Default DocFx Site..."
& "${DocFxTool}" init -q -o "${DocOutDir}"

Write-Verbose "Copying template and configuration..."
New-Item -Path "${DocOutDir}" -Name "templates" -ItemType "directory"
Copy-Item "${DocGenDir}/templates/*" -Destination "${DocOutDir}/templates" -Force -Recurse
Copy-Item "${DocGenDir}/docfx.json" -Destination "${DocOutDir}/" -Force

Write-Verbose "Creating Index using service directory and package names from repo..."
$ServiceList = Get-ChildItem "$($RepoRoot)/sdk" -Directory -Exclude eng, mgmtcommon, testcommon, template | Sort-Object
$YmlPath = "${DocOutDir}/api"
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
New-Item -Path "${DocOutDir}" -Name "toc.yml" -Force
Add-Content -Path "${DocOutDir}/toc.yml" -Value "- name: Azure SDK for NET APIs`r`n  href: api/`r`n  homepage: api/index.md"

Write-Verbose "Copying root markdowns"
Copy-Item "$($RepoRoot)/README.md" -Destination "${DocOutDir}/api/index.md" -Force
Copy-Item "$($RepoRoot)/CONTRIBUTING.md" -Destination "${DocOutDir}/api/CONTRIBUTING.md" -Force

Write-Verbose "Building site..."
& "${DocFxTool}" build "${DocOutDir}/docfx.json"

Copy-Item "${DocGenDir}/assets/logo.svg" -Destination "${DocOutDir}/_site/" -Force
Copy-Item "${DocGenDir}/assets/toc.yml" -Destination "${DocOutDir}/_site/" -Force
