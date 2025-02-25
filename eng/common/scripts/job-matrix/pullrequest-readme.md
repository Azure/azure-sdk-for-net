# Pull Request FAQ

The `pullrequest` pipeline is a single public definition that handles all `pull request` changes to an `azure-sdk-for-X` repository. This pull request definition expands and contracts the targeted packages for build according to a **git diff** of the actual changes made. It is currently deployed in the following `azure-sdk` repositories:

| Pipeline Def |
|---|
| [Java](https://dev.azure.com/azure-sdk/public/_build?definitionId=7413) |
| [JS](https://dev.azure.com/azure-sdk/public/_build?definitionId=7140) |
| [.NET](https://dev.azure.com/azure-sdk/public/_build?definitionId=7327) |
| [Python](https://dev.azure.com/azure-sdk/public/_build?definitionId=7050) |
| [Rust](https://dev.azure.com/azure-sdk/public/_build?definitionId=7126) |

Only repos that appear in the above list are enabled with a single unified `pullrequest` pipeline. All other `azure-sdk` shipping repositories ship using a build definition per service directory.

## Pullrequest Pipeline Order of operations

- Generate a PR diff
- Save Package Properties using the `diff`
- Run `build` and `analyze` steps only against artifacts that come out of the package-properties folder
  - The primary change between service build and the pullrequest build is the scoping mechanism. For a service build, a specific service directory is examined for packages. For a pullrequest build, the entire repository is considered before being scoped down to only packages that were actually changed.
- Tests are run against `indirect`ly and `direct`ly changed packages separately in batches.

## What is a `direct` vs `indirect` change?

- A `direct`ly changed package is one whos actual package code has changed.
- An `indirect` changed package is a package that has been added for verification of code that is not directly within the package itself.
  - For example, in `java`, when the `eng/` package is changed, we trigger `azure-core` indirectly.

## Why do I see jobs with `bX` or `ibY` suffixes?

As mentioned above, direct and indirect packages are batched separately. Batching is best explained by the following pseudocode

```
batchSize = configurable # of packages in each test batch, defaults to 10
directPackages = the list of packages with directly changed code in the PR

group the direct packages by matrix configuration
  - each matrix contribution
    - group by batch size
      - assign the matrix to the full batch
      - if multiple batches exist, add suffix
```

Notice that packages are grouped initially by _the matrix associated with their ci.yml_. In the `pullrequest` pipeline, the service directory of a package no longer matters, only what matrix it belongs to.

`indirect` batching works the same way, but doesn't the _full_ test matrix by default. It instead deterministically selects a single item from the resolved test matrix and assigns the batch of packages to it.

The suffixes `b1` or `ib1` or are added automatically as needed by the job pull request [matrix creation.](../../../common/scripts/job-matrix/Create-JobMatrix.ps1).