# Samples, Snippets, and How-To Guides

Developers like to learn by looking at code, and so the Azure SDK comes with a myriad of code samples in the form of short code snippets, sample applications, and how-to guides. This document describes where to find all these resources.

# Structure of the Repository
The Azure SDK repository is organized in the following folder structure, with the main sample locations highlighted using **bold** font.

`/samples` - this folder<br>
&nbsp;&nbsp;&nbsp;&nbsp;`README.md` ```// (this file)```<br>
`/sdk` ```// folder containing sources for all SDK packages```<br>
&nbsp;&nbsp;&nbsp;&nbsp;`/<service>` ```// e.g. storage```<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`/<package>` ```// e.g. Azure.Storage.Blobs```<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`README.md` ```// package READMEs contain hello world samples```**<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`/samples` ```// package-specific samples```**<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`/src`<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`/tests`<br>

##  `Hello World` Samples
Each package folder contains a package-specific `README.md` file. Most of these `README` files contain `Hello World` code samples illustrating basic usage of the the APIs contained in the package. For example, you can find `Hello World` samples for the `Azure.Storage.Blobs` package [here](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs/README.md#examples).

## Package Samples and Hot-To Guides
Each package folder contains a subfolder called `samples` with additional code samples. These samples can be either short programs contained in *.cs files, or more complete how-to guides (code samples and some commentary) contained *.md files. You can find a shortcuts to main how-to guides in the [**How-To Guides List**](#how-to-guide-list) section below.

## Sample Applications
Sometimes we want to illustrate how several APIs or even packages work together in a context of a more complete program. For these cases, we created sample applications that you can look at, download, compile, and execute. These application samples are located on 
[https://code.msdn.microsoft.com/](https://code.msdn.microsoft.com/).

# How-To Guide List
This section lists **main** how-to guides for the most commonly used APIs and most common scenarios, i.e. this section does not attempt to be a complete directory of guides contained in this repository. 

#### General How-To Guides
- How to **authenticate** with Azure services (TODO)
- How to configure, access, and analyze **logging** information (TODO)
- How to configure **retries** (TODO)
- How to access **HTTP response details** (TODO)

#### Azure.Security.KeyVault
- How to **store and retrieve** secrets and keys (TODO)
- How to **backup and restore** secrets and keys (TODO) 
- How to **encrypt and decrypt** secrets and keys (TODO)

#### Azure.Storage.Blobs
- How to **upload** to a blob (TODO)
- How to **download** a blob to a file (TODO)
