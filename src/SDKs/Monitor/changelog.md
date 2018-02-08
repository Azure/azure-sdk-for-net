## Microsoft.Azure.Management.Monitor release notes

### Changes in 0.17.0-preview

**Breaking change**

- All classes prefixed with ServiceDiagnosticSettings were renamed and are now prefixed with DiagnosticSettings.

**Notes**

- Api version in DiagnosticSettings calls was updated from 2016-09-01 to 2017-05-01-preview.
- DiagnosticSettings operations now support named settings. It is possible to add and remove different settings for the same resource.
- Diagnostic settings accepts optional EventHubName, which allows to select the name of the EventHub, when specified.
- Added DiagnosticSettingsCategories operations which allow querying the available categories for a particular resource 

**Breaking change**

- The metrics API has been replaced with the multi-dimensional metrics API. The names/paths of the calls remain unchanged, but the parameters of those calls have changed significantly.
- The new metric definition call does not accept a $filter parameter. The return type for this call remains similar to the previous API, but not completely equal: the changes are additive in this case.
- The new metrics call accepts a greater set of parameters. Some of them were in the $filter in the previous API. Some are new, e.g.: the parameter that determines the type of data to return: metrics data or metadata. Some other parameters have changed, e.g.: the new call keeps the $filter parameter, but it is intended mostly to handle metadata conditions. The return type of this call changed significantly since the new API can return metadata as well as metric data. 

**Notes**

- The new Api version for the whole metrics API is 2017-05-01-preview. Before it was 2016-09-01 for metrics and 2016-03-01 for metric definitions.
- The calls can retrieve single-dimension metrics with the proper set of parameters. So the change is not completely a breaking change, but it would certainly require some adjustments in the calls.
