# Pull Request FAQ

The `pullrequest` pipeline is a single public definition that handles all `pull request` changes to an `azure-sdk-for-X` repository. This document is intended to answer some common questions that users may have about the `pullrequest` definition.

## Can I get a bit more context first?

Let's get some basic repo structure discussion out of the way. The `azure-sdk` team maintains a consistent repo structure for all shipping packages to package managers (Read NPM, Nuget, pypi, Maven, etc)

```jsonc
sdk/
  storage
    Azure.Storage.Blobs
    Azure.Storage.Queues
    ...
  <service>
    <service-package-1>
    ..
    <service-package-N>
    // the ci.yml is what AZDO build defs are based upon
    ci.yml
```

This necessitates that release definitions on the [internal](https://dev.azure.com/azure-sdk/internal/) azure devops exist for each service in a repository. However, each build definition can only build and ship packages **within the service it was created for**.

This service-directory also applied to `public` build definitions that triggered on [pull requests](https://github.com/Azure/azure-sdk-for-python/pulls) in our repos. Due to this, large changesets that touched multiple service directories would incur a build for _every service directory that was touched_. The `azure-sdk` EngSys calls this situation a `build storm`.

The `<language> - pullrequest` definitions entirely replace service-specific build definitions. It has the ability to expand and contract the targeted packages for build according to a **git diff** of the actual changes made. Because of this, any repo that has cut over to `pullrequest` will enjoy no longer incurring build storms on large cross-cutting changes. While the individual build run will be very long running and batch up tests across a bunch of agents, it _will_ eventually complete. It will be _impossible_ to exhaust GitHub or Azure DevOps token utilization as well, given that it is a single definition triggering checks.

The `pullrequest` pipeline is currently deployed in the following `azure-sdk` repositories:

| Pipeline Def | Completed? |
|---|---|
| [Java](https://dev.azure.com/azure-sdk/public/_build?definitionId=7413) |❌|
| [JS](https://dev.azure.com/azure-sdk/public/_build?definitionId=7140) |✅|
| [.NET](https://dev.azure.com/azure-sdk/public/_build?definitionId=7327) |❌|
| [Python](https://dev.azure.com/azure-sdk/public/_build?definitionId=7050) |✅|
| [Rust](https://dev.azure.com/azure-sdk/public/_build?definitionId=7126) |✅|

Only repos that appear in the above list are enabled with a single unified `pullrequest` pipeline. All other `azure-sdk` shipping repositories ship and PR using a build definition per service directory.

## Pullrequest pipeline order of operations

- Generate a PR diff
- Save Package Properties using the `diff`
- Run `build` and `analyze` steps only against artifacts that come out of the package-properties folder
  - The primary change between service build and the pullrequest build is the scoping mechanism. For a service build, a specific service directory is examined for packages. For a pullrequest build, the entire repository is considered before being scoped down to only packages that were actually changed.
- Tests are run against `indirect`ly and `direct`ly changed packages separately in batches.

## What is a `direct` vs `indirect` change?

- A `direct`ly changed package is one whose actual package code has changed.
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

`indirect` batching works the same way, but doesn't use the _full_ test matrix by default. It instead deterministically selects a single item from the resolved test matrix and assigns the batch of packages to it.

The suffixes `b1` or `ib1` or are added automatically as needed by the job pull request [matrix creation.](https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/scripts/job-matrix/Create-PrJobMatrix.ps1).

## Can I disable this matrix batching?

Yes! Users can entirely disable the batching for a specific matrix by setting `PRBatching` to false in the matrix configuration.

Example:

```yml
MatrixConfigs:
  - Name: version_overrides_tests
    Path: sdk/core/version-overrides-matrix.json
    Selection: all
    PRBatching: false # the new key
    GenerateVMJobs: true
```
