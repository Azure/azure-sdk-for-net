## Microsoft.Azure.Management.Monitor release notes

### Changes in 0.20.1-preview

**Notes**

- Fixing issue #3585 [Monitor] Breaking change found in AutoScale spec (Swagger spec)
- Fixing issue #3293 [Monitor] Add serviceBusRuleId to the DiagnosticSettings resource (Swagger spec)
- Adding ListBySubscription operations to Autoscale and Alerts APIs
- New api-version for ActionGroups: 2018-03-01
- New api for ScheduledQueryRules: 2018-04-16
- Adding the most recent changes to the Swagger spec: several model classes added due to the new api and the update in ActionGroups

### Changes in 0.20.0-preview

**Notes**

- Approx. date of publication (2018-06)
- Adding MetricAlerts APIs and their unit tests
- Adding scenario tests for MetricAlerts and recorded them

### Changes in 0.19.1-preview

**Notes**

- Fixing bug #2655: specify the top argument of the metrics API as integer instead of double

### Changes in 0.19.0-preview

**Notes**

- Approx. date of publication (2018-03)
- New receivers added to Actiongroup.
- Added a patch action for Actiongroup.
- The attributes of the EventData class are all explicitly marked as read-only. These objects were and still are only returned by the Activity Logs requests, i.e. they have always behaved as read-only attributes.
- The new Api version for the metrics Api and metricDefinitions Api is 2018-01-01. The previous Api version was 2017-05-01-preview.
- A new optional query parameter called 'metricnamespace' is added to metricDefinitions Api.
- Optional query parameters 'top', 'orderby' and 'metricnamespace' are added to metrics Api.
- MetricsTests were updated and sessions re-recorded.


**Breaking change**

- The operations that used to be grouped under **data-plane** were really **resource-management** operations. All those operations were moved to the **resource-management** group and the **data-plane** groups has been removed.
- As a consequence of the previous item the class namespace **Microsoft.Azure.Management.Monitor.Management** has been removed. All the artifacts (e.g. classes, interfaces) are in the namespace: **Microsoft.Azure.Management.Monitor**.
- Another consequence of the first item is that the client **MonitorClient** does not exist anymore. Only the client **MonitorManagementClient** remains and it exposes all the operations of the SDK.
- A query parameter was renamed from 'metric' to 'metricnames' for metrics Api.

### Changes in 0.18.1-preview

**Notes**

- Approx. date of publication (2017-10-20)
- Fixing doc issues
- Adding two values to the metric unit enumeration, generating metadata files
- Adding multi-dimensional metrics tests

### Changes in 0.18.0-preview

**Notes**

- Approx. date of publication (2017-09-20)
- Release 0.17.0-preview was not published.

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

### Changes in 0.16.1-preview

**Notes**

- Approx. date of publication (2017-08-23)
- Adding ActivityLogAlerts and ActionGroups APIs and their unit tests
- Adding PATCH operations and the corresponding unit tests
- Adding scenario tests, improving and re-recording them
- Making sure the scenario tests point to the more recent version of the Resource Manager.dll

### Changes in 0.16.0-preview

**Notes**

- Approx. date of publication (2017-04-27)
- Fixing version of Newtonsoft.Json
- Adding some unit tests and making sure the Tests project works.
- Commenting imports in the project file
- Changing class namespace of the generated code
- Changing namespace and assembly name for compliance
- Leaving the Swagger spec for DiagnosticSettings out of the generation and using the previous API again
- Updating the generate.cmd command to the latest commit for the arm-monitor composite file
- Making the default class namespace consistent with the dll and nuget package names
- Removing unused test files (DiagnosticSettings) and changing the project file accordingly.
