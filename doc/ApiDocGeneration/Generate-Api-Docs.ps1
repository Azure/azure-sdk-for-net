# Generates API Docs from the Azure-SDK-for-NET repo
# Generates an index page for cataloging different versions od the Docs

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

Function Get-DocFx
{
    [CmdletBinding()]
    Param ($DownloadDirectory)

    try 
    {
        Write-Verbose "Downloading DocFx..."
        Invoke-WebRequest -Uri "https://github.com/dotnet/docfx/releases/download/v2.43.2/docfx.zip" `
        -OutFile "docfx.zip" | Wait-Process; Expand-Archive -Path "docfx.zip" -DestinationPath "$($DownloadDirectory)/docfx/"
    }
    catch 
    {
        Write-Verbose "Failed to Download DocFx"
        Write-Error "$_"
        Exit 1
    }
}

Function Get-DocTools
{
    [CmdletBinding()]
    Param (
        $DownloadDirectory,
        $RepoRoot
    )

    try 
    {
        Write-Verbose "Download and Extract mdoc to Build.BinariesDirectory/mdoc"
        Invoke-WebRequest -Uri "https://github.com/mono/api-doc-tools/releases/download/mdoc-5.7.4.9/mdoc-5.7.4.9.zip" `
        -OutFile "mdoc.zip" | Wait-Process; Expand-Archive -Path "mdoc.zip" -DestinationPath "$($DownloadDirectory)/mdoc/"

        Write-Verbose "Restore doc/ApiDocGeneration/assets/docgen.csproj, to get ECMA2Yml and popimport"
        dotnet restore "$($RepoRoot)/doc/ApiDocGeneration/assets/docgen.csproj" /p:BuildBinariesDirectory=$DownloadDirectory
    }
    catch 
    {
        Write-Verbose "Failed to Download Mdoc"
        Write-Error "$_"
        Exit 1
    }

    Get-DocFx -DownloadDirectory $DownloadDirectory
}



Function Build-Docs
{
    [CmdletBinding()]
    Param (
        $ArtifactName,
        $ServiceDirectory,
        $ArtifactsSafeName,
        $ArtifactsDirectoryName,
        $LibType,
        $RepoRoot,
        $BinDirectory
    )

    # Include if runing Build-Docs locally
    # Get-DocTools -DownloadDirectory $BinDirectory -RepoRoot $RepoRoot

    Write-Verbose "Create variables for identifying package location and package safe names"
    $PackageLocation = "$($ServiceDirectory)/$($ArtifactName)"
    Write-Verbose "Package Location $($PackageLocation)"
    $SafeName = $ArtifactsSafeName

    if ($ServiceDirectory -eq '*') {
        $PackageLocation = "core/$($ArtifactName)"
    }

    if ($ServiceDirectory -eq 'cognitiveservices') {
        $PackageLocation = "cognitiveservices/$($ArtifactsDirectoryName)"
        $SafeName = $ArtifactsDirectoryName
    }

    if ($LibType -eq 'Management') {
        $PackageLocation = "$($ServiceDirectory)/$($ArtifactName)"
        $SafeName = $ArtifactsSafeName
        $SafeName = $ArtifactsSafeName.Substring($ArtifactsSafeName.LastIndexOf('.Management') + 1)
    }

    Write-Verbose "Set variable for publish pipeline step"
    echo "##vso[task.setvariable variable=artifactsafename]$($SafeName)"

    Write-Verbose "Create Directories Required for Doc Generation"
    mkdir "$($BinDirectory)/$($SafeName)/dll-docs/my-api"
    mkdir "$($BinDirectory)/$($SafeName)/dll-docs/dependencies/my-api"
    mkdir "$($BinDirectory)/$($SafeName)/dll-xml-output"
    mkdir "$($BinDirectory)/$($SafeName)/dll-yaml-output"
    mkdir "$($BinDirectory)/$($SafeName)/docfx-output"

    if ($LibType -eq '') { 
        Write-Verbose "Build Packages for Doc Generation - Client"
        dotnet build "$($RepoRoot)/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:OutputPath="$($BinDirectory)/$($SafeName)/dll-docs/my-api" /p:TargetFramework=netstandard2.0

        Write-Verbose "Include client Dependencies"
        dotnet build "$($RepoRoot)/eng/service.proj" /p:ServiceDirectory=$PackageLocation /p:IncludeTests=false /p:IncludeSamples=false /p:OutputPath="$($BinDirectory)/$($SafeName)/dll-docs/dependencies/my-api" /p:TargetFramework=netstandard2.0 /p:CopyLocalLockFileAssemblies=true
    }

    if ($LibType -eq 'Management') { # Management Package
        Write-Verbose "Build Packages for Doc Generation - Management"
        dotnet msbuild "eng/mgmt.proj" /p:scope=$PackageLocation /p:OutputPath="$($BinDirectory)/$($SafeName)/dll-docs/my-api" -maxcpucount:1 -nodeReuse:false

        Write-Verbose "Include Management Dependencies"
        dotnet msbuild "eng/mgmt.proj" /p:scope=$PackageLocation /p:OutputPath="$($BinDirectory)/$($SafeName)/dll-docs/dependencies/my-api" /p:CopyLocalLockFileAssemblies=true -maxcpucount:1 -nodeReuse:false
    }

    Write-Verbose "Remove all unneeded artifacts from build output directory"
    Remove-Item –Path "$($BinDirectory)/$($SafeName)/dll-docs/my-api/*" -Include * -Exclude "$($ArtifactName).dll", "$($ArtifactName).xml"

    Write-Verbose "Initialize Frameworks File"
    & "$($BinDirectory)/mdoc/mdoc.exe" fx-bootstrap "$($BinDirectory)/$($SafeName)/dll-docs"

    Write-Verbose "Include XML Files"
    & "$($BinDirectory)/PopImport/popimport.exe" -f "$($BinDirectory)/$($SafeName)/dll-docs"

    Write-Verbose "Produce ECMAXML"
    & "$($BinDirectory)/mdoc/mdoc.exe" update -fx "$($BinDirectory)/$($SafeName)/dll-docs" -o "$($BinDirectory)/$($SafeName)/dll-xml-output" --debug -lang docid -lang vb.net -lang fsharp --delete

    Write-Verbose "Generate YAML"
    & "$($BinDirectory)/ECMA2Yml/ECMA2Yaml.exe" -s "$($BinDirectory)/$($SafeName)/dll-xml-output" -o "$($BinDirectory)/$($SafeName)/dll-yaml-output"

    Write-Verbose "Provision DocFX Directory"
    & "$($BinDirectory)/docfx/docfx.exe" init -q -o "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project"

    Write-Verbose "Copy over Package ReadMe"
    $PkgReadMePath = "$($RepoRoot)/sdk/$($PackageLocation)/README.md"
    if ([System.IO.File]::Exists($PkgReadMePath))
    {
        Copy-Item $PkgReadMePath -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api/index.md" -Force
        Copy-Item $PkgReadMePath -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/index.md" -Force
    }
    else
    {
        New-Item "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api/index.md" -Force
        Add-Content -Path "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api/index.md" -Value "This Package Contains no Readme."
        Copy-Item "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api/index.md" -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/index.md"-Force
        Write-Verbose "Package ReadMe was not found"
    }

    Write-Verbose "Copy over generated yml and other assets"
    Copy-Item "$($BinDirectory)/$($SafeName)/dll-yaml-output/*"-Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/api" -Recurse
    Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/assets/docfx.json" -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project" -Recurse -Force
    New-Item -Path "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project" -Name templates -ItemType directory
    Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/templates/**" -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/templates" -Recurse -Force

    Write-Verbose "Create Toc for Site Navigation"
    New-Item "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/toc.yml" -Force
    Add-Content -Path "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/toc.yml" -Value "- name: $ArtifactName`r`n  href: api/`r`n  homepage: api/index.md"

    Write-Verbose "Build Doc Content"
    & "$($BinDirectory)/docfx/docfx.exe" build "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/docfx.json"

    Write-Verbose "Copy over site Logo"
    Copy-Item "$($RepoRoot)/doc/ApiDocGeneration/assets/logo.svg" -Destination "$($BinDirectory)/$($SafeName)/docfx-output/docfx_project/_site" -Recurse -Force
}

Function Build-DocIndex
{
    [CmdletBinding()]
    Param (
        $RepoRoot
    )
    
    Get-DocFx -DownloadDirectory $RepoRoot

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
}