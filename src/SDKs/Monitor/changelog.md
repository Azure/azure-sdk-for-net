## Microsoft.Azure.Management.Monitor release notes

### Changes in 0.17.0-preview

**Breaking change**

- All classes prefixed with ServiceDiagnosticSettings were renamed and are now prefixed with DiagnosticSettings.

**Notes**

- Api version in DiagnosticSettings calls was updated from 2016-09-01 to 2017-05-01-preview.
- DiagnosticSettings operations now support named settings. It is possible to add and remove different settings for the same resource.
- Diagnostic settings accepts optional EventHubName, which allows to select the name of the EventHub, when specified.
- Added DiagnosticSettingsCategories operations which allow querying the available categories for a particular resource 
