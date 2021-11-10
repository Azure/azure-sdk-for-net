$testResourceProviders = "Microsoft.Advisor", "Microsoft.AlertsManagement", "Microsoft.AnalysisServices", "Microsoft.ApiManagement", "Microsoft.AppConfiguration",
    "Microsoft.ApplicationInsights", "Microsoft.AppPlatform", "Microsoft.Attestation", "Microsoft.Authorization", "Microsoft.Automanage",
    "Microsoft.Automation", "Microsoft.Avs", "Microsoft.AzureStackHCI", "Microsoft.Batch", "Microsoft.Billing",
    "Microsoft.Blueprint", "Microsoft.BotService", "Microsoft.Cdn", "Microsoft.ChangeAnalysis", "Microsoft.CognitiveServices",
    "Microsoft.Communication", "Microsoft.Compute", "Microsoft.Confluent", "Microsoft.Consumption", "Microsoft.ContainerInstance",
    "Microsoft.ContainerRegistry", "Microsoft.ContainerService", "Microsoft.CosmosDB", "Microsoft.CustomProviders", "Microsoft.DataBox",
    "Microsoft.DataBoxEdge", "Microsoft.Datadog", "Microsoft.DataFactory", "Microsoft.DataMigration", "Microsoft.DataProtection",
    "Microsoft.DataShare", "Microsoft.DeploymentManager", "Microsoft.DeviceProvisioningServices", "Microsoft.DeviceUpdate", "Microsoft.DevSpaces",
    "Microsoft.DevTestLabs", "Microsoft.DigitalTwins", "Microsoft.Dns", "Microsoft.Elastic", "Microsoft.EventGrid",
    "Microsoft.ExtendedLocation", "Microsoft.FrontDoor", "Microsoft.GuestConfiguration", "Microsoft.HDInsight", "Microsoft.Healthbot", 
    "Microsoft.HealthcareApis", "Microsoft.HybridCompute", "Microsoft.HybridDataManager", "Microsoft.Insights", "Microsoft.IotCentral",
    "Microsoft.IotHub", "Microsoft.KeyVault", "Microsoft.KubernetesConfiguration", "Microsoft.Kusto", "Microsoft.LabServices",
    "Microsoft.Logic", "Microsoft.Logz", "Microsoft.MachineLearning", "Microsoft.MachineLearningCompute", "Microsoft.MachineLearningServices",
    "Microsoft.Maintenance", "Microsoft.ManagedNetwork", "Microsoft.ManagedServiceIdentity", "Microsoft.ManagedServices", "Microsoft.ManagementGroups",
    "Microsoft.ManagementPartner", "Microsoft.Maps", "Microsoft.Marketplace", "Microsoft.MarketplaceOrdering", "Microsoft.MixedReality",
    "Microsoft.MySQL", "Microsoft.NetApp", "Microsoft.Network", "Microsoft.NotificationHubs", "Microsoft.OperationalInsights",
    "Microsoft.Peering", "Microsoft.PolicyInsights", "Microsoft.PostgreSQL", "Microsoft.PowerBIDedicated", "Microsoft.PrivateDns",
    "Microsoft.ProviderHub", "Microsoft.Purview", "Microsoft.Quantum", "Microsoft.RecoveryServices", "Microsoft.Redis",
    "Microsoft.Relay", "Microsoft.Reservations", "Microsoft.ResourceGraph", "Microsoft.Resources", "Microsoft.Scheduler",
    "Microsoft.Search", "Microsoft.SecurityCenter", "Microsoft.SecurityInsights", "Microsoft.ServiceBus", "Microsoft.ServiceFabric",
    "Microsoft.ServiceFabricManagedClusters", "Microsoft.SignalR", "Microsoft.SqlVirtualMachine", "Microsoft.Storage", "Microsoft.StorageCache",
    "Microsoft.StoragePool", "Microsoft.StorageSync", "Microsoft.StorSimple", "Microsoft.StorSimple8000Series", "Microsoft.StreamAnalytics",
    "Microsoft.Subscription", "Microsoft.Support", "Microsoft.Synapse", "Microsoft.TrafficManager", "Microsoft.VideoAnalyzer",
    "Microsoft.WebPubSub", "Microsoft.AppService", "Microsoft.WorkLoadMonitor"
$successResourceProviders = @()
$genFailResourceProviders = @()
$buildFailResourceProviders = @()

dotnet new -i "$PSScriptRoot\..\templates\Azure.ResourceManager.Template"

foreach ($testResourceProvider in $testResourceProviders) {
    $shortenName = $testResourceProvider.substring(10)
    $captizeName = $shortenName.tolower()
    $projectFolder = "$PSScriptRoot\..\..\sdk\$captizeName\Azure.ResourceManager.$shortenName"
    $configurationFolder = "$projectFolder\src"
    $needRemoveFolder = $false
    if (Test-Path -Path $projectFolder) {
        Write-Host "The project folder of $testResourceProvider exists"
        Set-Location $configurationFolder
        dotnet build /t:GenerateCode
    }
    else {
        $needRemoveFolder = $true
        mkdir -Path $projectFolder
        Set-Location $projectFolder
        dotnet new azuremgmt --provider $testResourceProvider --force
        Set-Location $configurationFolder
        autorest autorest.md
    }
    if (!$?){
        $genFailResourceProviders += $testResourceProvider
    }
    else {
        dotnet build
        if (!$?){
            $buildFailResourceProviders += $testResourceProvider
        }
        else {
            $successResourceProviders += $testResourceProvider
            Write-Host "Code Generation and Compile of $testResourceProvider succeeded!"
        }
    }
    if ($needRemoveFolder){
        Set-Location $PSScriptRoot
        Remove-Item $projectFolder -Recurse
    }
}

$successCount = $successResourceProviders.Count
$genFailCount = $genFailResourceProviders.Count
$buildFailCount = $buildFailResourceProviders.Count
Write-Output "$successCount successfully generated RPs:" | Out-File "$PSScriptRoot\result.txt"
Write-Output "$successResourceProviders" | Out-File -Append "$PSScriptRoot\result.txt"
Write-Output "$genFailCount codeGen failed RPs:" | Out-File -Append "$PSScriptRoot\result.txt"
Write-Output "$genFailResourceProviders" | Out-File -Append "$PSScriptRoot\result.txt"
Write-Output "$buildFailCount built failed generated RPs:" | Out-File -Append "$PSScriptRoot\result.txt"
Write-Output "$buildFailResourceProviders" | Out-File -Append "$PSScriptRoot\result.txt"