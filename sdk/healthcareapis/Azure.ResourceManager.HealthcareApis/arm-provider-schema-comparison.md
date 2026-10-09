# ARM provider schema comparison: Azure.ResourceManager.HealthcareApis

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 10 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 3 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/dicomservices/{}`
  - legacy-only: `Microsoft.HealthcareApis.DicomServiceOperationGroup.delete (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/dicomservices/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/dicomservices/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HealthcareApis.DicomServiceOperationGroup.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/dicomservices/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/dicomservices/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/fhirservices/{}`
  - legacy-only: `Microsoft.HealthcareApis.FhirServiceOperationGroup.delete (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/fhirservices/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/fhirservices/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HealthcareApis.FhirServiceOperationGroup.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/fhirservices/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/fhirservices/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/iotconnectors/{}`
  - legacy-only: `Microsoft.HealthcareApis.IotConnectorOperationGroup.delete (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/iotconnectors/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/iotconnectors/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HealthcareApis.IotConnectorOperationGroup.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/iotconnectors/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/iotconnectors/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}`
  - resolveArmResources-only: `Microsoft.HealthcareApis.DicomServiceOperationGroup.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/dicomservices/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HealthcareApis.DicomServiceOperationGroup.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/dicomservices/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HealthcareApis.FhirServiceOperationGroup.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/fhirservices/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HealthcareApis.FhirServiceOperationGroup.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/fhirservices/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HealthcareApis.IotConnectorOperationGroup.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/iotconnectors/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HealthcareApis.IotConnectorOperationGroup.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}/iotconnectors/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HealthcareApis/workspaces/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
