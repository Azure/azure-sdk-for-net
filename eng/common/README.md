# Common Engineering System

The `eng/common` directory contains engineering files that are common across the various azure-sdk language repos.
It should remain relatively small and only contain textual based files like scripts, configs, or templates. It
should not contain binary files as they don't play well with git.

## Updating

Any updates to files in the `eng/common` directory should be made in the [azure-sdk-tools](https://github.com/azure/azure-sdk-tools) repo.
All changes made will cause a PR to created in all subscribed azure-sdk language repos which will blindly replace all contents of
the `eng/common` directory in that repo. For that reason do **NOT** make changes to files in this directory in the individual azure-sdk
languages repos as they will be overwritten the next time an update is taken from the common azure-sdk-tools repo.

### Workflow

The 'Sync eng/common directory' PRs will be created in the language repositories once a pull request that touches the eng/common directory is submitted against the master branch. This will make it easier for changes to be tested in each individual language repo before merging the changes in the azure-sdk-tools repo. The workflow is explained below:

1. Create a PR against Azure/azure-sdk-tools:master. This is the **Tools PR**.
2. `azure-sdk-tools - sync - eng-common` is run automatically. It creates **Sync PRs** in each of the connected language repositories using the format `Sync eng/common directory with azure-sdk-tools for PR {Tools PR Number}`. Each **Sync PR** will contain a link back to the **Tools PR** that triggered it.
3. More changes pushed to the **Tools PR**, will automatically triggered new pipeline runs in the respective **Sync PRs**. The **Sync PRs** are used to make sure the changes would not break any of the connected pipelines.
4. Once satisfied with the changes;
    - First merge all the **Sync PRs**. The **Tools PR** contains links to all the **Sync PRs**
    - Finally merge the **Tools PR**. Each **Sync PR** contains the link to the corresponding **Tools PR**. 