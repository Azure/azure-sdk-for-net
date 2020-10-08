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

The 'Sync eng/common directory' PRs will be created in the language repositories when a pull request that touches the eng/common directory is submitted against the master branch. This will make it easier for changes to be tested in each individual language repo before merging the changes in the azure-sdk-tools repo. The workflow is explained below:

1. Create a PR (**Tools PR**) in the `azure - sdk - tools` Repo with changes to eng/common directory.
2. `azure-sdk-tools - sync - eng-common` pipeline is triggered for the **Tools PR**
3. The  `azure-sdk-tools - sync - eng-common` pipeline queues test runs using the dotnet, js, java and python template pipelines. This help to test the recent changes in the **Tools PR**
4. If there are changes in the **Tools PR** that will affect the release stage you should approve the release test pipelines by clicking the approval gate. The test (template) pipeline will automatically release the next eligible version without needing manual intervention for the versioning. Please approve your test releases as quickly as possible. A race condition may occur due to someone else queueing the pipeline and going all the way to release using your version while yours is still waiting. If this occurs manually rerun the pipeline that failed.
5. Repeat step 1 - 4 by pushing new changes to your **Tools PR** Do this until you have satisfactory test runs all the way to release of the template package if necessary.
6. Sign off on next stage of the sync pipeline using the approval gate. The CreateSyncPRs stage will create the sync PR in the various language repos. Before doing this you need to be satisfied with the testing from the previous steps. This stage will append the `auto-merge` label to the **Sync PRs** as well as the **Tools PR**.
6. Go review and approve each of your **Sync PRs**. The merging will happen automatically.
