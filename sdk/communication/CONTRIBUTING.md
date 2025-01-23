# Contributing Guide

This a contributing guide made specifically for the Azure Communication Services SDK. The Azure SDK repo also has a contributing guide that might help you in some other general processes this guide assumes you have done. If you haven't checked that one out yet, you can find it [here](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md)

The Azure Communication Services SDK for .Net currently consists of six different packages. While each package has its own set of environment variables to make their tests run successfully, all of them follow a similar structure that allows a smooth onboarding process.

Let's get started with how to set up the repo itself.

## Building 

To get started, open the file "sdk\communication\Azure.Communication.sln". Then, at the root directory, invoke `msbuild eng\mgmt.proj /p:scope=Communication`. 

Once the package has been built, let's jump on how to run the tests to see that everything is in order.

## Testing

Make sure to check out the general contributing guide the Azure SDK repo has for a more in-depth look at testing and setting up your dev environment. You can check out the contributing file [here](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md)

When you go inside the tests folder of the package you are working with, you will see a folder called `SessionRecords\<TestFileName>`. This folder contains, as its name suggests, recordings of successful calls to the API that allow us to run the tests in PLAYBACK mode and remove the necessity of hitting the actual resources every time we may want to test.

### Playback mode

By default tests are run in playback mode. You can also set an environment variable called `AZURE_TEST_MODE` and set its value to `PLAYBACK`. You may need to reopen Visual Studio for the environment variable change to reflect. The `Test Explorer` window will get populated with tests and you can then select the tests and `Run` or `Debug`.

If the tests are successful, we can proceed to run the tests in LIVE mode.

### Live mode

Since in LIVE mode we are hitting an actual resource, we must set the appropriate environment variables to make sure the code tests against the resource we want. Set up an env variable called `COMMUNICATION_LIVETEST_STATIC_CONNECTION_STRING` for Phone Number and SMS packages and set it to the connection string of the resource you want to test against. For all other communication packages, set up an environment variable called `COMMUNICATION_CONNECTION_STRING` and set it to the connection string of the resource you want to test against.

Depending on which package you are testing, it may need special environment variables to test succesfully. The names of these variables can be found inside `*ClientTestEnvironment.cs` inside the test packages. Make sure to set these variables before running the tests themselves. You may need to restart your development environment after creating or updating these environment variables.

After setting up the environment variables and setting `AZURE_TEST_MODE` to `LIVE`, you can run the tests in the Test Explorer.

### Record mode

RECORD mode is similar to LIVE mode because it also hits an actual resource. In addition to hitting the resource, RECORD mode will also record the successful calls to the service in json format. As mentioned, the recordings are stored in the test package under `SessionRecords\<TestFileName>`.

If you would like to generate new recordings for a test, setting `AZURE_TEST_MODE` to `RECORD`, reopen Visual Studio, and run the tests in the Test Explorer.

### Managed Identity Tests

If you ran the tests in RECORD mode, you may have noticed that the files inside the `SessionRecords` folder were updated. If any of the tests failed, you will see the error message in your terminal logs.

The most probable thing is that the managed identity tests will fail at first. This is because we haven't set up any managed identity credentials for the DefaultAzureCredential object inside the tests to reference to. There are multiple ways of creating a managed identity credential.

One of the easiest ways is to install the [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli) and run the `az login` command. If you are listed as a contributor of the resource you are testing against, this should be enough for the DefaultAzureCredential object to get the corresponding Azure Active Directory credentials you need.

Another way to authenticate is to set up 3 environment variables called `AZURE_CLIENT_ID`, `AZURE_TENANT_ID` and `AZURE_CLIENT_SECRET` and set their values to the ones from a registered Azure Active Directory application that is linked to the resource you are testing against.

If you are testing against a personal resource, you can check the [Managed Identity Quickstart Guide for ACS](https://learn.microsoft.com/azure/communication-services/quickstarts/managed-identity-from-cli) for an easy ramp-up process.

For a more in-depth look on how to authenticate using managed identity, refer to the [Azure Identity client library for .Net](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet) documentation. This document also has more ways for you to authenticate using the DefaultAzureCredential object besides the ones we discussed in this contributing file.

## Submitting a Pull Request

The easiest way for you to test without worrying about breaking changes you may cause is to create a fork from the [.Net Azure SDK repo](https://github.com/Azure/azure-sdk-for-net). After downloading your repo, make sure to add the original repo as an upstream. To do this, use the `git remote add upstream https://github.com/Azure/azure-sdk-for-net.git`

Create a branch for any new feature you may want to add and when your changes are ready, push your branch to the origin. Because the upstream was already set, if you go to the .Net Azure SDK repo you will see a message saying that you pushed changes to your fork and give you the option to create a PR from your fork to the original repo.

Make sure to name your PR with the following format when you are ready to submit it: [Communication] - `package-you-are-updating` - `pr-description`.

Additionally, write a good description about what your PR does in the description section. This will help your reviewers have a better understanding of what you are trying to accomplish.

## Samples 

Each SDK has a `samples` folder in the test package where you can run example code for every function the of the SDK. These samples may have special requirements such as specific environment variables you may have to setup before running them. Make sure to take a look at these files and setup the environment as it is expected. 

You can run these samples like running any tests in .Net by opening the Test Explorer and selecting either `Run` or `Debug`. Running these samples against a real resource may cost money depending on which SDK you are testing.
