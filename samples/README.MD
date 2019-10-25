# Samples, Snippets, and How-To Guides

Developers like to learn by looking at code, and so the Azure SDK comes with a myriad of code samples in the form of short code snippets, sample applications, and how-to guides. This document describes where to find all these resources.

# Structure of the Repository
The Azure SDK repository is organized in the following folder structure, with the main locations containing sample code highlighted

`/samples` ```// (this folder)```<br>
`/sdk` ```// folder containing sources for all SDK packages```<br>
&nbsp;&nbsp;&nbsp;&nbsp;`/<service>` ```// e.g. storage```<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`/<package>` ```// e.g. Azure.Storage.Blobs```<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`README.md` ```// package READMEs contain hello world samples```**<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`/samples` ```// package-specific samples```**<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`/src`<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`/tests`<br>

## Package `Hello World` Samples
Each package folder contains a README.md file. Many of these README files contain some basic `Hello World` code samples.

## Package Samples and Hot-To Guides
As illustrated by the diagram above, package-specific samples are located in each package folder. These samples can be either short C# programs contained in *.cs files, or more complete how-to guides (code samples and some commentary) contained *.md files. You can find a shortcuts to how-to guides for most common scenarios in the `Main How-To Guides` section below.

## Code Snippets

## Sample Applications

# Main How-To Guides

### General How-To Guides
- How-To configure, access, and analyze **logging** information 
- How-To configure **retries**
- How-To access **HTTP response details**

### Azure.Storage.Blobs
- How to **upload** to a blob
- How to **download** a blob to a file
