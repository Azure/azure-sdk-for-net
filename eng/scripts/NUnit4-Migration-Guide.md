# NUnit 4 Migration Guide

This guide provides step-by-step instructions for migrating the entire azure-sdk-for-net repository to NUnit 4.

## Prerequisites

- PowerShell 7+ installed (for parallel processing)
- Git repository is clean (no uncommitted changes)
- Working branch created for the migration

## Automated Migration with Worktrees (Recommended)

For the fastest workflow, use the `Run-NUnit4Migration-Full.ps1` script with git worktrees:

### Setup

1. **Create a branch with migration scripts** (if not already done):
   ```powershell
   git checkout -b nunit4-scripts
   # Commit all migration scripts
   ```

2. **Create a worktree for each migration batch**:
   ```powershell
   git worktree add ..\azure-sdk-nunit4-batch1 -b nunit4-migration-batch1 nunit4-scripts
   cd ..\azure-sdk-nunit4-batch1
   ```

3. **Edit the service list** in `eng/scripts/Run-NUnit4Migration-Full.ps1`:
   ```powershell
   $serviceDirectories = @(
       "core",
       "template",
       "storage"
   )
   ```

4. **Run the full migration** (in a separate terminal):
   ```powershell
   .\eng\scripts\Run-NUnit4Migration-Full.ps1
   ```

5. **Continue working** in your main workspace while migration runs

6. **Review and finalize** when complete:
   ```powershell
   # Review the output and test results
   git log
   
   # Remove migration scripts before PR
   git rm eng/scripts/Migrate-NUnit4.ps1
   git rm eng/scripts/Test-NUnit4Migration.ps1
   git rm eng/scripts/Run-NUnit4Migration-Full.ps1
   git rm eng/scripts/NUnit4-Migration-Guide.md
   git commit -m "Remove migration scripts"
   
   # Push and create PR
   git push origin nunit4-migration-batch1
   ```

7. **Cleanup worktree** after PR is merged:
   ```powershell
   git worktree remove ..\azure-sdk-nunit4-batch1
   ```

### Benefits
- Run multiple migrations in parallel using different worktrees
- Continue working on other tasks while migration runs
- Each migration is isolated in its own directory
- Easy to create multiple PRs simultaneously

## Manual Migration Process (Per PR)

Each PR should migrate a specific set of packages/services. Follow these steps for each PR:

### Step 1: Update Central Package Versions - Phase 1

Add NUnit.Analyzers to enable the migration tooling.

**File: `eng/Packages.Data.props`**

Add the version property (around line 24, near NUnitVersion):
```xml
<NUnitAnalyzersVersion>4.11.2</NUnitAnalyzersVersion>
```

Add the package reference for test projects (around line 387, near NUnit references):
```xml
<PackageReference Update="NUnit.Analyzers" Version="$(NUnitAnalyzersVersion)" />
```

**File: `eng/Directory.Build.Common.targets`**

Add NUnit.Analyzers to management plane test projects (around line 299, in the management test ItemGroup):
```xml
<!-- Management Client TEST Project Specific Overrides -->
<ItemGroup Condition="('$(IsMgmtLibrary)' == 'true' and '$(IsTestProject)' == 'true') or '$(IsStorageTest)' == 'true'">
  <ProjectReference Condition="'$(IsMgmtLibrary)' == 'true' and '$(IsTestProject)' == 'true'" Include="$(AzureCoreTestFramework)" />
  <PackageReference Include="NUnit" />
  <PackageReference Include="NUnit.Analyzers" />
  <PackageReference Include="NUnit3TestAdapter" />
  <PackageReference Include="Microsoft.NET.Test.Sdk" />
  <PackageReference Include="Moq" />
</ItemGroup>
```

Commit these changes:
```powershell
git add eng/Packages.Data.props eng/Directory.Build.Common.targets
git commit -m "Add NUnit.Analyzers for migration"
```

### Step 2: Run Migration Script

Run the migration script for your target service(s):

```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory <service-name>
```

Example:
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory core
```

Review the changes:
```powershell
git diff
```

Commit the migration changes:
```powershell
git add sdk/<service-name>/**/*.cs
git commit -m "Migrate <service-name> tests to NUnit 4 constraint model"
```

### Step 3: Update Central Package Versions - Phase 2

Remove the temporary NUnit.Analyzers references and add the NUnit 4 version override for the migrated service.

**File: `eng/Packages.Data.props`**

Remove the NUnitAnalyzersVersion property and package reference added in Step 1.

Add a conditional ItemGroup for the migrated service(s) at the end of the file (before the closing `</Project>` tag, around line 580):
```xml
<!-- NUnit 4 migration: <service-name> -->
<ItemGroup Condition="$(MSBuildProjectDirectory.Contains('\sdk\<service-name>\'))">
  <PackageReference Update="NUnit" Version="4.4.0" />
  <PackageReference Update="NUnit3TestAdapter" Version="4.6.0" />
  <PackageReference Update="NUnit.Analyzers" Version="4.5.0" />
</ItemGroup>
```

For multiple services in the same PR, you can combine them:
```xml
<!-- NUnit 4 migration: core, template -->
<ItemGroup Condition="$(MSBuildProjectDirectory.Contains('\sdk\core\')) or $(MSBuildProjectDirectory.Contains('\sdk\template\'))">
  <PackageReference Update="NUnit" Version="4.4.0" />
  <PackageReference Update="NUnit3TestAdapter" Version="4.6.0" />
  <PackageReference Update="NUnit.Analyzers" Version="4.5.0" />
</ItemGroup>
```

**File: `eng/Directory.Build.Common.targets`**

Remove the NUnit.Analyzers reference from the management plane ItemGroup.

Commit these changes:
```powershell
git add eng/Packages.Data.props eng/Directory.Build.Common.targets
git commit -m "Add NUnit 4.4.0 override for <service-name>"
```

### Step 4: Build and Test

Build and test the migrated service:

```powershell
.\eng\scripts\Test-NUnit4Migration.ps1 -ServiceDirectory <service-name>
```

Fix any build errors or test failures, then commit:
```powershell
git add .
git commit -m "Fix build/test issues for <service-name>"
```

### Step 5: Submit PR

Push your branch and create a PR:
```powershell
git push origin <your-branch-name>
```

---

## Repository Upgrade Plan

The following plan breaks down the migration into manageable PRs. Each PR should target related services to keep changes cohesive.

### Phase 1: Core Infrastructure (3 PRs)

**PR 1.1 - Core Libraries**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory core
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory template
```

**PR 1.2 - Storage**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory storage
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory storagecache
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory storageactions
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory storagemover
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory storagepool
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory storagesync
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory storagediscovery
```

**PR 1.3 - Identity & Key Vault**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory identity
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory keyvault
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory entra
```

### Phase 2: Messaging & Events (2 PRs)

**PR 2.1 - Event & Service Bus**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory eventhub
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory servicebus
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory eventgrid
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory relay
```

**PR 2.2 - Messaging Extensions**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory schemaregistry
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory signalr
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory webpubsub
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory notificationhubs
```

### Phase 3: AI & Cognitive Services (3 PRs)

**PR 3.1 - AI Core**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory ai
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory openai
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory cognitiveservices
```

**PR 3.2 - AI Language & Vision**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory cognitivelanguage
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory textanalytics
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory vision
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory face
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory formrecognizer
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory documentintelligence
```

**PR 3.3 - AI Specialized**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory anomalydetector
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory personalizer
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory metricsadvisor
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory healthinsights
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory contentsafety
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory contentunderstanding
```

### Phase 4: Data & Analytics (3 PRs)

**PR 4.1 - Cosmos DB & Search**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory cosmosdb
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory cosmosdbforpostgresql
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory search
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory tables
```

**PR 4.2 - SQL & Database Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory sqlmanagement
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory sqlvirtualmachine
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory mysql
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory postgresql
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory databasewatcher
```

**PR 4.3 - Analytics & Monitoring**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory monitor
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory operationalinsights
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory applicationinsights
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory streamanalytics
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory synapse
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory kusto
```

### Phase 5: Compute & Containers (3 PRs)

**PR 5.1 - Compute**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory compute
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory computefleet
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory computelimit
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory computerecommender
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory computeschedule
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory batch
```

**PR 5.2 - Container Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory containerregistry
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory containerservice
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory containerapps
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory containerinstance
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory containerorchestratorruntime
```

**PR 5.3 - Kubernetes & Orchestration**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory kubernetesconfiguration
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory hybridkubernetes
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory hybridaks
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory fleet
```

### Phase 6: Networking (2 PRs)

**PR 6.1 - Core Networking**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory network
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory frontdoor
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory cdn
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory trafficmanager
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory dns
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory privatedns
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory dnsresolver
```

**PR 6.2 - Advanced Networking**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory networkanalytics
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory networkcloud
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory networkfunction
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory servicenetworking
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory managednetwork
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory managednetworkfabric
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory peering
```

### Phase 7: IoT & Edge (2 PRs)

**PR 7.1 - IoT Core**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory iot
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory iothub
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory iotcentral
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory iotoperations
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory deviceprovisioningservices
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory deviceupdate
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory deviceregistry
```

**PR 7.2 - Edge Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory edgeactions
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory edgeorder
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory edgezones
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory databox
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory databoxedge
```

### Phase 8: Security & Governance (2 PRs)

**PR 8.1 - Security Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory securitycenter
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory securityinsights
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory securitydevops
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory attestation
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory confidentialledger
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory hardwaresecuritymodules
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory trustedsigning
```

**PR 8.2 - Governance & Compliance**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory policyinsights
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory authorization
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory blueprint
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory appcomplianceautomation
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory guestconfiguration
```

### Phase 9: Management & Operations (3 PRs)

**PR 9.1 - Resource Management**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory resourcemanager
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory resources
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory resourcegraph
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory resourcehealth
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory resourcemover
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory resourceconnector
```

**PR 9.2 - Recovery & Backup**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory recoveryservices
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory recoveryservices-backup
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory recoveryservices-datareplication
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory recoveryservices-siterecovery
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory dataprotection
```

**PR 9.3 - Management Tools**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory automation
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory automanage
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory maintenance
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory changeanalysis
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory chaos
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory selfhelp
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory support
```

### Phase 10: Application Services (3 PRs)

**PR 10.1 - App Platform & Functions**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory appplatform
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory appconfiguration
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory websites
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory extension-wcf
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory extensions
```

**PR 10.2 - Integration & Messaging**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory logic
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory apimanagement
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory servicelinker
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory servicefabric
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory servicefabricmanagedclusters
```

**PR 10.3 - Dev Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory devcenter
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory devopsinfrastructure
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory devspaces
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory devtestlabs
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory labservices
```

### Phase 11: Communication & Media (2 PRs)

**PR 11.1 - Communication Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory communication
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory voiceservices
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory botservice
```

**PR 11.2 - Media & Mixed Reality**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory mediaservices
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory videoanalyzer
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory mixedreality
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory objectanchors
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory remoterendering
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory digitaltwins
```

### Phase 12: Data Services (2 PRs)

**PR 12.1 - Data Lake & Migration**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory datalake-analytics
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory datalake-store
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory datamigration
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory datashare
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory datafactory
```

**PR 12.2 - Data Platform Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory purview
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory openenergyplatform
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory modelsrepository
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory healthdataaiservices
```

### Phase 13: Hybrid & Arc (2 PRs)

**PR 13.1 - Hybrid Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory hybridcompute
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory hybridconnectivity
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory hybridnetwork
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory extendedlocation
```

**PR 13.2 - Arc Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory arc-scvmm
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory connectedvmwarevsphere
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory azurestackhci
```

### Phase 14: Specialized Services A (3 PRs)

**PR 14.1 - Healthcare & Life Sciences**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory healthcareapis
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory healthbot
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory agrifood
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory agricultureplatform
```

**PR 14.2 - Desktop & Gaming**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory desktopvirtualization
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory playwright
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory loadtestservice
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory onlineexperimentation
```

**PR 14.3 - Machine Learning**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory machinelearningservices
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory machinelearningcompute
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory quantum
```

### Phase 15: Specialized Services B (3 PRs)

**PR 15.1 - Observability**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory grafana
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory dynatrace
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory elastic
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory datadog
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory newrelicobservability
```

**PR 15.2 - Marketplace & Billing**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory marketplace
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory marketplaceordering
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory billing
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory billingbenefits
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory costmanagement
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory consumption
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory reservations
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory quota
```

**PR 15.3 - Partner Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory confluent
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory oracle
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory informaticadatamanagement
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory qumulo
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory dellstorage
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory purestorageblock
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory paloaltonetworks.ngfw
```

### Phase 16: Specialized Services C (3 PRs)

**PR 16.1 - Maps & Spatial**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory maps
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory orbital
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory planetarycomputer
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory sphere
```

**PR 16.2 - Specialized Databases**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory redis
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory redisenterprise
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory mongocluster
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory mongodbatlas
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory neonpostgres
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory pineconevectordb
```

**PR 16.3 - Infrastructure Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory netapp
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory elasticsan
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory fileshares
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory fluidrelay
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory standbypool
```

### Phase 17: Remaining SDK Services (3 PRs)

**PR 17.1 - Migration & Discovery**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory migrationassessment
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory migrationdiscoverysap
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory springappdiscovery
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory dependencymap
```

**PR 17.2 - Workload Services**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory workloadmonitor
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory workloadorchestration
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory workloads
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory workloadssapvirtualinstance
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory sitemanager
```

**PR 17.3 - Miscellaneous A**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory advisor
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory alertsmanagement
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory analysisservices
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory apicenter
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory astronomer
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory avs
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory azurelargeinstance
```

### Phase 18: Final SDK Services (3 PRs)

**PR 18.1 - Miscellaneous B**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory carbon
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory cloudhealth
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory cloudmachine
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory connectedcache
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory customer-insights
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory defendereasm
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory disconnectedoperations
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory durabletask
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory easm
```

**PR 18.2 - Miscellaneous C**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory fabric
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory graphrbac
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory graphservices
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory impactreporting
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory lambdatesthyperexecute
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory managementpartner
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory managedserviceidentity
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory managedservices
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory mobilenetwork
```

**PR 18.3 - Miscellaneous D**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory nginx
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory portalservices
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory powerbidedicated
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory providerhub
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory provisioning
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory secretsstoreextension
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory subscription
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory terraform
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory timeseriesinsights
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory translation
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory virtualenclaves
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory weightsandbiases
```

### Phase 19: Agent Server (1 PR)

**PR 19.1 - Agent Server**
```powershell
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory agentserver
.\eng\scripts\Migrate-NUnit4.ps1 -ServiceDirectory arizeaiobservabilityeval
```

### Phase 20: Generator Projects (1 PR)

**PR 20.1 - Azure Generator**

The generator projects are outside the sdk/ directory. Build the solution and run tests manually:

```powershell
cd eng\packages\http-client-csharp
dotnet build Azure.Generator.sln
dotnet test Azure.Generator.sln
```

If there are test projects, you'll need to manually:
1. Add NUnit.Analyzers package references to test projects
2. Run dotnet format with NUnit diagnostics (follow the same pattern as Migrate-NUnit4.ps1)
3. Add NUnit 4.4.0 override to `eng/Packages.Data.props` using a condition like:
   ```xml
   <!-- NUnit 4 migration: Azure Generator -->
   <ItemGroup Condition="$(MSBuildProjectDirectory.Contains('\eng\packages\http-client-csharp\'))">
     <PackageReference Update="NUnit" Version="4.4.0" />
     <PackageReference Update="NUnit3TestAdapter" Version="4.6.0" />
     <PackageReference Update="NUnit.Analyzers" Version="4.5.0" />
   </ItemGroup>
   ```

### Phase 21: Other Common Test Projects (1 PR)

**PR 21.1 - Common Test Infrastructure**

Review and migrate any test projects outside sdk/ and eng/packages:
- `common/ManagementTestShared`
- `common/Perf`
- `common/SmokeTests`

For each directory with test projects, follow the same migration process.

---

## Final Steps

After all PRs are merged:

1. Update `eng/Packages.Data.props` to change the central `NUnitVersion` from `3.14.0` to `4.4.0`
2. Remove all the conditional NUnit 4 override ItemGroups from `eng/Packages.Data.props` (they'll no longer be needed)
3. Submit final cleanup PR

---

## Troubleshooting

### Build Errors

If you encounter build errors after migration:
- Check that the conditional ItemGroup was added correctly to `eng/Packages.Data.props`
- Verify the path condition matches your service directory structure
- Ensure NUnit.Analyzers was properly removed from central packages after Step 3
- Review the diff for any unintended changes

### Test Failures

Common test failures after migration:
- **Message format changes**: NUnit 4 may format assertion messages differently
- **Constraint model differences**: Some complex assertions may need manual adjustment
- **TestContext API changes**: Update any code using `TestContext.CurrentContext.Result`

### Partial Migrations

If you need to stop mid-PR:
- Complete Step 3 to ensure the migrated services have proper version overrides in `eng/Packages.Data.props`
- Commit all changes before stopping
- Document which services were completed in the PR description

---

## Notes

- Each PR should be focused on related services to make reviews easier
- Build and test each PR before submitting to catch issues early
- The migration script handles most code changes automatically via NUnit.Analyzers
- Manual fixes may be needed for edge cases or complex test scenarios
- Keep PRs manageable in size (recommended: 5-10 services per PR for medium-sized services)
