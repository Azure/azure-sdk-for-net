# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: PurviewScanningService
input-file: https://github.com/Azure/azure-rest-api-specs/blob/8478d2280c54d0065ac6271e39321849c090c659/specification/purview/data-plane/Azure.Data.Purview.Scanning/preview/2018-12-01-preview/scanningService.json
namespace: Azure.Analytics.Purview.Scanning
low-level-client: true
security: AADToken
security-scopes:  https://purview.azure.net/.default
modelerfour:
  lenient-model-deduplication: true
```

# Model endpoint parameter as a url, not a string.

```yaml
directive:
  - from: swagger-document
    where: $.parameters.Endpoint
    transform: >
      $.format = "url";
```

# Promote Parameters to clients

```yaml
directive:
  - from: swagger-document
    where: $.parameters
    transform: >
      $["dataSourceName"] = {
        "in": "path",
        "name": "dataSourceName",
        "required": true,
        "type": "string",
        "x-ms-parameter-location": "client"
      };
      $["scanName"] = {
        "in": "path",
        "name": "scanName",
        "required": true,
        "type": "string",
        "x-ms-parameter-location": "client" 
      };
      $["classificationRuleName"] = {
        "in": "path",
        "name": "classificationRuleName",
        "required": true,
        "type": "string",
        "x-ms-parameter-location": "client" 
      };      

  - from: swagger-document
    where: $.paths..parameters[?(@.name=='dataSourceName')]
    transform: >
      $ = { "$ref": "#/parameters/dataSourceName" };

  - from: swagger-document
    where: $.paths..parameters[?(@.name=='scanName')]
    transform: >
      $ = { "$ref": "#/parameters/scanName" };

  - from: swagger-document
    where: $.paths..parameters[?(@.name=='classificationRuleName')]
    transform: >
      $ = { "$ref": "#/parameters/classificationRuleName" };

```

# Adopt Client Factoring

```yaml
directive:
  - from: swagger-document
    where: $..[?(@.operationId !== undefined)]
    transform: >
      const mappingTable = {
        "AzureKeyVaults_GetAzureKeyVault": "GetKeyVaultReference",
        "AzureKeyVaults_CreateAzureKeyVault": "CreateOrUpdateKeyVaultReference",
        "AzureKeyVaults_DeleteAzureKeyVault": "DeleteKeyVaultReference",
        "AzureKeyVaults_ListByAccount": "GetKeyVaultReferences",
        "ClassificationRules_Get": "PurviewClassificationRule_GetProperties",
        "ClassificationRules_CreateOrUpdate": "PurviewClassificationRule_CreateOrUpdate",
        "ClassificationRules_Delete": "PurviewClassificationRule_Delete",
        "ClassificationRules_ListAll": "GetClassificationRules",
        "ClassificationRules_ListVersionsByClassificationRuleName": "PurviewClassificationRule_GetVersions",
        "ClassificationRules_TagClassificationVersion": "PurviewClassificationRule_TagVersion",
        "DataSources_CreateOrUpdate": "PurviewDataSource_CreateOrUpdate",
        "DataSources_Get": "PurviewDataSource_GetProperties",
        "DataSources_Delete": "PurviewDataSource_Delete",
        "DataSources_ListByAccount": "GetDataSources",
        "DataSources_ListChildrenByCollection": "PurviewDataSource_GetChildren",
        "DataSource_ListUnparentedDataSourcesByAccount": "GetUnparentedDataSources",
        "Filters_Get": "PurviewScan_GetFilter",
        "Filters_CreateOrUpdate": "PurviewScan_CreateOrUpdateFilter",
        "Scans_CreateOrUpdate": "PurviewScan_CreateOrUpdate",
        "Scans_Get": "PurviewScan_GetProperties",
        "Scans_Delete": "PurviewScan_Delete",
        "Scans_ListByDataSource": "PurviewDataSource_GetScans",
        "Scans_RunScan": "PurviewScan_RunScan",
        "Scans_CancelScan": "PurviewScan_CancelScan",
        "Scans_ListScanHistory": "PurviewScan_GetRuns",
        "ScanRulesets_Get": "GetScanRuleset",
        "ScanRulesets_CreateOrUpdate": "CreateOrUpdateScanRuelset",
        "ScanRulesets_Delete": "DeleteScanRuleset",
        "ScanRulesets_ListAll": "GetScanRulesets",
        "SystemScanRulesets_ListAll": "GetSystemRulesets",
        "SystemScanRulesets_Get": "GetSystemRulesetsForDataSource",
        "SystemScanRulesets_GetByVersion": "GetSystemRulesetsForVersion",
        "SystemScanRulesets_GetLatest": "GetLatestSystemRulestes",
        "SystemScanRulesets_ListVersionsByDataSource": "GetSystemRulesetsVersions",
        "Triggers_GetTrigger": "PurviewScan_GetTrigger",
        "Triggers_CreateTrigger": "PurviewScan_CreateOrUpdateTrigger",
        "Triggers_DeleteTrigger": "PurviewScan_DeleteTrigger",
      };

      $.operationId = (mappingTable[$.operationId] ?? $.operationId);
```