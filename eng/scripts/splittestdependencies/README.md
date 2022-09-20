# Test dependency Splitting Strategy
## Problems
Today, most of the Azure SDKs implemented in our repo have a dependency on the core library. In order to guarantee the changes on core do not break the SDKs depend on it, our core PR validation pipeline currently runs all tests under `sdk` folder. As the onboarding packages keep growing, the test steps of pipeline usually take nearly an hour to finish. To achieve the purpose of speeding up the PR validation, we decided to move on to the test splitting task.

## Existing workflow
Before we run the tests, we have a step to determine the testing matrix (OS image, pool, .NET framework etc.). For each of the testing environment, we check which is the service triggers the pipeline. If it is service other that core, then we run the tests under the service only. If it is core library, then we will run all tests under `sdk` folder. There are more than 400 packages in total as of today, so even we execute them in parallel, it still takes long while to get them done. 

## New workflow
In order to speed up the pipeline, we have to answer two questions here:

1. Is it necessary to run all tests under `sdk`? Can we fetch the tests which have a dependency on core?
1. Can we split the tests depend on core into different test jobs?

To optimize the existing process, we first use the `MSBuild` to find all test `.csproj` files depend on target service. Then, we split these test projects (exclude the target service) into certain number of chunks (according to the input of how many tests we expect to run on each test job) and write them into separate project files. We will dynamically write the project files back as a new property to the matrix json which will use to determine the test job settings later on. By having the mutate matrix json, the test steps can execute their tests on small number of tests defined in project files respectively. We also have another set of test jobs which run the target service tests only. Though we double the size of test matrix, it saves nearly 80% of the time we spend on test jobs.

Here is the workflow for better understanding:
![Workflow](assets/test-split-workflow.png)

## Enable/Disable the split work
We currently have this support in public PR validation pipeline and internal release pipeline.
We have enabled the core pipeline.

To enable the split on your service, you can add the line below in `ci.yml` under service folder. E.g. [ci.yml](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/ci.yml)
```
TestDependsOnDependency: ${service-name}
```
To disable, just remove the above line, and the corresponding pipeline will run the tests on target service only.

## Performance
Here is the comparison:
|     | Old | New |
| --- | --- | --- |
| Num of tests on each job | ~400 | ~20 |
| Time spent on core | ~ 1 hour as maximum | ~ 13 min as maximum | 

## Downside of the feature

1. The job matrix is determined once generate-job-matrix is done. Rerun any failed step will still run on the same testing environment (OSImage, Pool, Test framework, Test dependency project etc). 
This is by design. So if a new project is added/deleted, we are not able to pick up the latest test projects in the same build. The case is rare, so it should not be a concern for our current usage.

## Future work
1. Onboard to live test pipeline
1. Leverage the work on other time consuming job.