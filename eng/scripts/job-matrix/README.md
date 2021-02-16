# Azure Pipelines Matrix Generator

* [Usage in a pipeline](#usage-in-a-pipeline)
* [Matrix config file syntax](#matrix-config-file-syntax)
 * [Fields](#fields)
    * [matrix](#matrix)
    * [include](#include)
    * [exclude](#exclude)
    * [displayNames](#displaynames)
    * [$IMPORT](#import)
* [Matrix Generation behavior](#matrix-generation-behavior)
    * [all](#all)
    * [sparse](#sparse)
    * [include/exclude](#includeexclude)
    * [displayNames](#displaynames-1)
    * [Filters](#filters)
    * [NonSparseParameters](#nonsparseparameters)
    * [Under the hood](#under-the-hood)
* [Testing](#testing)


This directory contains scripts supporting dynamic, cross-product matrix generation for azure pipeline jobs.
It aims to replicate the [cross-product matrix functionality in github actions](https://docs.github.com/free-pro-team@latest/actions/reference/workflow-syntax-for-github-actions#example-running-with-more-than-one-version-of-nodejs),
but also adds some additional features like sparse matrix generation, cross-product includes and excludes, and programmable matrix filters.

This functionality is made possible by the ability for the azure pipelines yaml to take a [dynamic variable as an input
for a job matrix definition](https://docs.microsoft.com/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#multi-job-configuration) (see the code sample at the bottom of the linked section).

## Usage in a pipeline

In order to use these scripts in a pipeline, you must provide a config file and call the matrix creation script within a powershell job.

For a single matrix, you can include the `eng/pipelines/templates/jobs/job-matrix.yml` template in a pipeline:

```
jobs:
- template: /eng/pipelines/templates/jobs/job-matrix.yml
  parameters:
    MatrixConfigs:
      - Name: base_product_matrix
        Path: /eng/pipelines/matrix.json
        Selection: sparse
        NonSparseParameters: <csv of parameter names for which all combinations should be included>
        GenerateVMJobs: true
      - Name: sdk_specific_matrix
        Path: /sdk/foobar/matrix.json
        Selection: all
        GenerateContainerJobs: true
    steps:
      - pwsh:
          ...
```

## Matrix config file syntax

Matrix parameters can either be a list of strings, or a set of grouped strings (represented as a hash). The latter parameter
type is useful for when 2 or more parameters need to be grouped together, but without generating more than one matrix permutation.

```
"matrix": {
  "<parameter1 name>": [ <values...> ],
  "<parameter2 name>": [ <values...> ],
  "<parameter set>": {
    "<parameter set 1 name>": {
        "<parameter set 1 value 1": "value",
        "<parameter set 1 value 2": "<value>",
    },
    "<parameter set 2 name>": {
        "<parameter set 2 value 1": "value",
        "<parameter set 2 value 2": "<value>",
    }
  }
}
"include": [ <matrix>, <matrix>, ... ],
"exclude": [ <matrix>, <matrix>, ... ],
"displayNames": { <parameter value>: <human readable override> }
```

See `samples/matrix.json` for a full sample.

### Fields

#### matrix

The `matrix` field defines the base cross-product matrix. The generated matrix can be full or sparse.

Example:
```
"matrix": {
  "operatingSystem": [
    "windows-2019",
    "ubuntu-18.04",
    "macOS-10.15"
  ],
  "framework": [
    "net461",
    "netcoreapp2.1",
    "net50"
  ],
  "additionalTestArguments": [
    "",
    "/p:UseProjectReferenceToAzureClients=true",
  ]
}
```

#### include

The `include` field defines any number of matrices to be appended to the base matrix after processing exclusions.

#### exclude

The `include` field defines any number of matrices to be removed from the base matrix. Exclude parameters can be a partial
set, meaning as long as all exclude parameters match against a matrix entry (even if the matrix entry has additional parameters),
then it will be excluded from the matrix. For example, the below entry will match the exclusion and be removed:

```
matrix entry:
{
    "a": 1,
    "b": 2,
    "c": 3,
}

"exclude": [
    {
        "a": 1,
        "b": 2
    }
]
```

#### displayNames

Specify any overrides for the azure pipelines definition and UI that determines the matrix job name. If some parameter
values are too long or unreadable for this purpose (e.g. a command line argument), then you can replace them with a more
readable value here. For example:

```
"displayNames": {
  "/p:UseProjectReferenceToAzureClients=true": "UseProjectRef"
},
"matrix": {
  "additionalTestArguments": [
    "/p:UseProjectReferenceToAzureClients=true"
  ]
}
```

#### $IMPORT

Matrix configs can also import another matrix config. The effect of this is the imported matrix will be generated,
and then the importing config will be combined with that matrix (as if each entry of the imported matrix was a parameter).
To import a matrix, add a parameter with the key `$IMPORT`:

```
"matrix": {
  "$IMPORT": "path/to/matrix.json",
  "JavaVersion": [ "1.8", "1.11" ]
}
```

Importing can be useful, for example, in cases where there is a shared base matrix, but there is a need to run it
once for each instance of a language version.

The processing order is as follows:

Given a matrix and import matrix like below:
```
{
    "matrix": {
        "$IMPORT": "example-matrix.json",
        "endpointType": [ "storage", "cosmos" ],
        "JavaVersion": [ "1.8", "1.11" ]
    },
    "include": [
        {
            "operatingSystem": "windows",
            "mode": "TestFromSource",
            "JavaVersion": "1.8"
        }
    ]
}

### example-matrix.json to import
{
    "matrix": {
      "operatingSystem": [ "windows", "linux" ],
      "client": [ "netty", "okhttp" ]
    },
    "include": [
        {
          "operatingSystem": "mac",
          "client": "netty"
        }
    ]
}
```

1. The base matrix is generated (sparse in this example):
    ```
    {
      "storage_18": {
        "endpointType": "storage",
        "JavaVersion": "1.8"
      },
      "cosmos_111": {
        "endpointType": "cosmos",
        "JavaVersion": "1.11"
      }
    }
    ```
1. The imported base matrix is generated (sparse in this example):
    ```
    {
      "windows_netty": {
        "operatingSystem": "windows",
        "client": "netty"
      },
      "linux_okhttp": {
        "operatingSystem": "linux",
        "client": "okhttp"
      }
    }
    ```
1. Includes/excludes from the imported matrix get applied to the imported matrix
    ```
    {
      "windows_netty": {
        "operatingSystem": "windows",
        "client": "netty"
      },
      "linux_okhttp": {
        "operatingSystem": "linux",
        "client": "okhttp"
      },
      "mac_netty": {
        "operatingSystem": "mac",
        "client": "netty"
      }
    }
    ```
1. The base matrix is multipled by the imported matrix (in this case, the base matrix has 2 elements, and the imported
   matrix has 3 elements, so the product is a matrix with 6 elements:
    ```
      "storage_18_windows_netty": {
        "endpointType": "storage",
        "JavaVersion": "1.8",
        "operatingSystem": "windows",
        "client": "netty"
      },
      "storage_18_linux_okhttp": {
        "endpointType": "storage",
        "JavaVersion": "1.8",
        "operatingSystem": "linux",
        "client": "okhttp"
      },
      "storage_18_mac_netty": {
        "endpointType": "storage",
        "JavaVersion": "1.8",
        "operatingSystem": "mac",
        "client": "netty"
      },
      "cosmos_111_windows_netty": {
        "endpointType": "cosmos",
        "JavaVersion": "1.11",
        "operatingSystem": "windows",
        "client": "netty"
      },
      "cosmos_111_linux_okhttp": {
        "endpointType": "cosmos",
        "JavaVersion": "1.11",
        "operatingSystem": "linux",
        "client": "okhttp"
      },
      "cosmos_111_mac_netty": {
        "endpointType": "cosmos",
        "JavaVersion": "1.11",
        "operatingSystem": "mac",
        "client": "netty"
      }
    }
    ```
1. Includes/excludes from the top-level matrix get applied to the multiplied matrix, so the below element will be added
   to the above matrix, for an output matrix with 7 elements:
    ```
    "windows_TestFromSource_18": {
      "operatingSystem": "windows",
      "mode": "TestFromSource",
      "JavaVersion": "1.8"
    }
    ```

## Matrix Generation behavior

#### all

`all` will output the full matrix, i.e. every possible permutation of all parameters given (p1.Length * p2.Length * ...).

#### sparse

`sparse` outputs the minimum number of parameter combinations while ensuring that all parameter values are present in at least one matrix job.
Effectively this means the total length of a sparse matrix will be equal to the largest matrix dimension, i.e. `max(p1.Length, p2.Length, ...)`.

To build a sparse matrix, a full matrix is generated, and then walked diagonally N times where N is the largest matrix dimension.
This pattern works for any N-dimensional matrix, via an incrementing index (n, n, n, ...), (n+1, n+1, n+1, ...), etc.
Index lookups against matrix dimensions are calculated modulus the dimension size, so a two-dimensional matrix of 4x2 might be walked like this:

```
index: 0, 0:
o . . .
. . . .

index: 1, 1:
. . . .
. o . .

index: 2, 2 (modded to 2, 0):
. . o .
. . . .

index: 3, 3 (modded to 3, 1):
. . . .
. . . o
```

#### include/exclude

Include and exclude support additions and subtractions off the base matrix. Both include and exclude take an array of matrix values.
Typically these values will be a single entry, but they also support the cross-product matrix definition syntax of the base matrix.

Include and exclude are parsed fully. So if a sparse matrix is called for, a sparse version of the base matrix will be generated, but
the full matrix of both include and exclude will be processed.

Excludes are processed first, so includes can be used to add back any specific jobs to the matrix.

#### displayNames

In the matrix job output that azure pipelines consumes, the format is a dictionary of dictionaries. For example:

```
{
  "net461_macOS1015": {
    "framework": "net461",
    "operatingSystem": "macOS-10.15"
  },
  "net50_ubuntu1804": {
    "framework": "net50",
    "operatingSystem": "ubuntu-18.04"
  },
  "netcoreapp21_windows2019": {
    "framework": "netcoreapp2.1",
    "operatingSystem": "windows-2019"
  },
  "UseProjectRef_net461_windows2019": {
    "additionalTestArguments": "/p:UseProjectReferenceToAzureClients=true",
    "framework": "net461",
    "operatingSystem": "windows-2019"
  }
}
```

The top level keys are used as job names, meaning they get displayed in the azure pipelines UI when running the pipeline.

The logic for generating display names works like this:

- Join parameter values by "_"
    a. If the parameter value exists as a key in `displayNames` in the matrix config, replace it with that value.
    b. For each name value, strip all non-alphanumeric characters (excluding "_").
    c. If the name is greater than 100 characters, truncate it.

#### Filters

Filters can be passed to the matrix as an array of strings, each matching the format of <key>=<regex>. When a matrix entry
does not contain the specified key, it will default to a value of empty string for regex parsing. This can be used to specify
filters for keys that don't exist or keys that optionally exist and match a regex, as seen in the below example.

Display name filters can also be passed as a single regex string that runs against the [generated display name](#displaynames) of the matrix job.
The intent of display name filters is to be defined primarily as a top level variable at template queue time in the azure pipelines UI.

For example, the below command will filter for matrix entries with "windows" in the job display name, no matrix variable
named "ExcludedKey", a framework variable containing either "461" or "5.0", and an optional key "SupportedClouds" that, if exists, must contain "Public":

```
./Create-JobMatrix.ps1 `
  -ConfigPath samples/matrix.json `
  -Selection all `
  -DisplayNameFilter ".*windows.*" `
  -Filters @("ExcludedKey=^$", "framework=(461|5\.0)", "SupportedClouds=^$|.*Public.*")
```

#### NonSparseParameters

Sometimes it may be necessary to generate a sparse matrix, but keep the full combination of a few parameters. The
NonSparseParameters argument allows for more fine-grained control of matrix generation. For example:

```
./Create-JobMatrix.ps1 `
  -ConfigPath /path/to/matrix.json `
  -Selection sparse `
  -NonSparseParameters @("JavaTestVersion")
```

Given a matrix like below with `JavaTestVersion` marked as a non-sparse parameter:

```
{
  "matrix": {
    "Agent": {
      "windows-2019": { "OSVmImage": "MMS2019", "Pool": "azsdk-pool-mms-win-2019-general" },
      "ubuntu-1804": { "OSVmImage": "MMSUbuntu18.04", "Pool": "azsdk-pool-mms-ubuntu-1804-general" },
      "macOS-10.15": { "OSVmImage": "macOS-10.15", "Pool": "Azure Pipelines" }
    },
    "JavaTestVersion": [ "1.8", "1.11" ],
    "AZURE_TEST_HTTP_CLIENTS": "netty",
    "ArmTemplateParameters": [ "@{endpointType='storage'}", "@{endpointType='cosmos'}" ]
  }
}
```

A matrix with 6 entries will be generated: A sparse matrix of Agent, AZURE_TEST_HTTP_CLIENTS and ArmTemplateParameters
(3 total entries) will be multipled by the two `JavaTestVersion` parameters `1.8` and `1.11`.

#### Under the hood

The script generates an N-dimensional matrix with dimensions equal to the parameter array lengths. For example,
the below config would generate a 2x2x1x1x1 matrix (five-dimensional):

```
"matrix": {
  "framework": [ "net461", "netcoreapp2.1" ],
  "additionalTestArguments": [ "", "/p:SuperTest=true" ]
  "pool": [ "ubuntu-18.04" ],
  "container": [ "ubuntu-18.04" ],
  "testMode": [ "Record" ]
}
```

The matrix is stored as a one-dimensional array, with a row-major indexing scheme (e.g. `(2, 1, 0, 1, 0)`).

## Testing

The matrix functions can be tested using [pester](https://pester.dev/):

```
$ Invoke-Pester

Starting discovery in 1 files.
Discovery finished in 384ms.
[+] /home/ben/sdk/azure-sdk-for-net/eng/scripts/job-matrix/job-matrix-functions.tests.ps1 4.09s (1.52s|2.22s)
Tests completed in 4.12s
Tests Passed: 120, Failed: 0, Skipped: 4 NotRun: 0
```
