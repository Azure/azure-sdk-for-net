# Azure Pipelines Matrix Generator

* [Usage in a pipeline](#usage-in-a-pipeline)
* [Matrix config file syntax](#matrix-config-file-syntax)
   * [Fields](#fields)
	  * [matrix](#matrix)
	  * [include](#include)
	  * [exclude](#exclude)
	  * [displayNames](#displaynames)
* [Matrix Generation behavior](#matrix-generation-behavior)
  * [all](#all)
  * [sparse](#sparse)
  * [include/exclude](#includeexclude)
  * [displayNames](#displaynames-1)
  * [Filters](#filters)
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
      - Name: sdk_specific_matrix
        Path: /sdk/foobar/matrix.json
        Selection: all
	steps:
	  - pwsh:
          ...
```

## Matrix config file syntax

```
"matrix": {
  "<parameter1 name>": [ <values...> ],
  "<parameter2 name>": [ <values...> ]
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

1. Sort the matrix by: parameter length, parameter name, and sort the parameter values arrays.
2. In sorted order, join parameter values by "_"
    a. If the parameter value exists as a key in `displayNames` in the matrix config, replace it with that value.
    b. For each name value, strip all `.-_` characters from the string.

The matrix is then sorted by display name, before being sent to azure pipelines. The underlying matrix may have a different
sorted order than the display name output. The sorting needs to be separate so that sparse matrix generation can be deterministic.

#### Filters

To be implemented. A basic example of a filter is "all" vs. "sparse" generation, but eventually will be a more programmable
way of processing excludes, such as an expression that only includes entries with a container image specified. The intent
is that these filters can be entered at runtime, as opposed to statically in yaml.

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
