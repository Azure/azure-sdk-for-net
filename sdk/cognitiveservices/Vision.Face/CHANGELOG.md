# 2.5.0
1) The API client name was changed from FaceAPI to FaceClient, in keeping with other Azure SDKs.
2) Supported customizing service endpoints by assigning the endpoint string to FaceClient.Endpoint. The endpoint string can be found on Azure Portal, it should contain only protocol and hostname, for example: https://westus.api.cognitive.microsoft.com. This change ensures better global coverage.
3) Aligned with latest Face API, Million-Scale features (LargePersonGroup and LargeFaceList) were added.
4) Some inconsistencies in naming, parameter order were corrected.
5) Aligned with latest Face API, Snapshot features for data migration were added.
6) Aligned with latest Face API, multiple recognition model feature was added.