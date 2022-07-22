# scenarios

## First Onboard
For DPG, autorestConfig will be provided in input.json as following:

input.json

```json
{
    "dryRun": false,
    "specFolder": "../azure-rest-api-specs",
    "headSha": "98dc0989df3a17a1c0ec6dec034e6938e7d65127",
    "headRef": "refs/pull/3146/merge",
    "repoHttpsUrl": "https://github.com/openapi-env-test/azure-rest-api-specs",
    "trigger": "pullRequest",
    "changedFiles": [
        "specification/deviceupdate/data-plane/readme.md",
        "specification/deviceupdate/data-plane/readme.python.md",
        "specification/deviceupdate/data-plane/readme.typescript.md"
    ],
    "relatedReadmeMdFiles": [
        "specification/deviceupdate/data-plane/readme.md"
    ],
    "installInstructionInput": {
        "isPublic": false,
        "downloadUrlPrefix": "https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2/",
        "downloadCommandTemplate": "curl -L \"{URL}\" -o {FILENAME}",
        "trigger": "pullRequest"
    },
    "autorestConfig": "# azure-sdk-for-net-track2\r\n``` yaml\r\noutput-folder: sdk/deviceupdate/Azure.IoT.DeviceUpdate.Demo\r\nrequire:\r\n - specification/deviceupdate/data-plane/readme.md\r\n```"
}
```

output.json

```json
{
  "packages": [
    {
      "apiViewArtifact": ".\\artifacts\\packages\\Debug\\Azure.IoT.DeviceUpdate.Demo\\Azure.IoT.DeviceUpdate.Demo.1.0.0-alpha.20220722.1.nupkg",
      "language": ".Net",
      "artifacts": [
        ".\\artifacts\\packages\\Debug\\Azure.IoT.DeviceUpdate.Demo\\Azure.IoT.DeviceUpdate.Demo.1.0.0-alpha.20220722.1.nupkg"
      ],
      "result": "succeeded",
      "packageName": "Azure.IoT.DeviceUpdate.Demo",
      "path": [
        ".\\sdk\\deviceupdate\\Azure.IoT.DeviceUpdate.Demo"
      ],
      "installInstructions": {
        "full": "Download the Azure.IoT.DeviceUpdate.Demo package from [here](https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2//Azure.IoT.DeviceUpdate.Demo.1.0.0-alpha.20220722.1.nupkg)",
        "lite": "Download the Azure.IoT.DeviceUpdate.Demo package from [here](https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2//Azure.IoT.DeviceUpdate.Demo.1.0.0-alpha.20220722.1.nupkg)"
      },
      "changelog": {
        "content": null,
        "hasBreakingChange": false
      },
      "packageFolder": "C:/project/azure-sdk-for-net/sdk/deviceupdate/Azure.IoT.DeviceUpdate.Demo"
    }
  ]
}
```

## update existing SDK
- without autorestConfig
input.json

```json

{
    "dryRun": false,
    "specFolder": "",
    "headSha": "98dc0989df3a17a1c0ec6dec034e6938e7d65127",
    "headRef": "refs/pull/3146/merge",
    "repoHttpsUrl": "https://github.com/openapi-env-test/azure-rest-api-specs",
    "trigger": "pullRequest",
    "changedFiles": [
        "specification/deviceupdate/data-plane/readme.md",
        "specification/deviceupdate/data-plane/readme.python.md",
        "specification/deviceupdate/data-plane/readme.typescript.md"
    ],
    "relatedReadmeMdFiles": [
        "specification/deviceupdate/data-plane/readme.md"
    ],
    "installInstructionInput": {
        "isPublic": false,
        "downloadUrlPrefix": "https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2/",
        "downloadCommandTemplate": "curl -L \"{URL}\" -o {FILENAME}",
        "trigger": "pullRequest"
    }
}
```

output.json

```json
{
  "packages": [
    {
      "apiViewArtifact": ".\\artifacts\\packages\\Debug\\Azure.IoT.DeviceUpdate\\Azure.IoT.DeviceUpdate.1.0.0-alpha.20220722.1.nupkg",
      "language": ".Net",
      "artifacts": [
        ".\\artifacts\\packages\\Debug\\Azure.IoT.DeviceUpdate\\Azure.IoT.DeviceUpdate.1.0.0-alpha.20220722.1.nupkg"
      ],
      "result": "failed",
      "packageName": "Azure.IoT.DeviceUpdate",
      "path": [
        ".\\sdk\\deviceupdate\\Azure.IoT.DeviceUpdate"
      ],
      "installInstructions": {
        "full": "Download the Azure.IoT.DeviceUpdate package from [here](https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2//Azure.IoT.DeviceUpdate.1.0.0-alpha.20220722.1.nupkg)",
        "lite": "Download the Azure.IoT.DeviceUpdate package from [here](https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2//Azure.IoT.DeviceUpdate.1.0.0-alpha.20220722.1.nupkg)"
      },
      "changelog": {
        "content": null,
        "hasBreakingChange": false
      },
      "packageFolder": "C:/project/azure-sdk-for-net/sdk/deviceupdate/Azure.IoT.DeviceUpdate"
    }
  ]
}

```
- provide autorestConfig
  The autorest config provided will be merged into exist autorest.md.

input.json: 

**Tip**: in the autorest config,the title is set to 'AzureDeviceUpdate'. AS a result, the title in autorest.md is updated, and the generated code will use the new title.

```json
{
    "dryRun": false,
    "specFolder": "../azure-rest-api-specs",
    "headSha": "98dc0989df3a17a1c0ec6dec034e6938e7d65127",
    "headRef": "refs/pull/3146/merge",
    "repoHttpsUrl": "https://github.com/openapi-env-test/azure-rest-api-specs",
    "trigger": "pullRequest",
    "changedFiles": [
        "specification/deviceupdate/data-plane/readme.md",
        "specification/deviceupdate/data-plane/readme.python.md",
        "specification/deviceupdate/data-plane/readme.typescript.md"
    ],
    "relatedReadmeMdFiles": [
        "specification/deviceupdate/data-plane/readme.md"
    ],
    "installInstructionInput": {
        "isPublic": false,
        "downloadUrlPrefix": "https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2/",
        "downloadCommandTemplate": "curl -L \"{URL}\" -o {FILENAME}",
        "trigger": "pullRequest"
    },
    "autorestConfig": "# azure-sdk-for-net-track2\r\n``` yaml\r\noutput-folder: sdk/deviceupdate/Azure.IoT.DeviceUpdate\r\nrequire:\r\n - specification/deviceupdate/data-plane/readme.md\r\ntitle: AzureDeviceUpdate\r\n```"
}
```

output.json

```json
{
  "packages": [
    {
      "apiViewArtifact": ".\\artifacts\\packages\\Debug\\Azure.IoT.DeviceUpdate\\Azure.IoT.DeviceUpdate.1.0.0-alpha.20220722.1.nupkg",
      "language": ".Net",
      "artifacts": [
        ".\\artifacts\\packages\\Debug\\Azure.IoT.DeviceUpdate\\Azure.IoT.DeviceUpdate.1.0.0-alpha.20220722.1.nupkg"
      ],
      "result": "failed",
      "packageName": "Azure.IoT.DeviceUpdate",
      "path": [
        ".\\sdk\\deviceupdate\\Azure.IoT.DeviceUpdate"
      ],
      "installInstructions": {
        "full": "Download the Azure.IoT.DeviceUpdate package from [here](https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2//Azure.IoT.DeviceUpdate.1.0.0-alpha.20220722.1.nupkg)",
        "lite": "Download the Azure.IoT.DeviceUpdate package from [here](https://openapihub.test.azure-devex-tools.com/api/sdk-dl-pub?p=openapi-env-test/3146/azure-sdk-for-net-track2//Azure.IoT.DeviceUpdate.1.0.0-alpha.20220722.1.nupkg)"
      },
      "changelog": {
        "content": null,
        "hasBreakingChange": false
      },
      "packageFolder": "C:/project/azure-sdk-for-net/sdk/deviceupdate/Azure.IoT.DeviceUpdate"
    }
  ]
}

```
