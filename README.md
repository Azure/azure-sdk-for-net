# Microsoft Azure SDK for .NET

The Microsoft Azure SDK for .NET allows you to build applications
that take advantage of scalable cloud computing resources.

### Target frameworks

-  .NET Framework 4.0 and newer.
-  .NET Portable Framework, using profile 102

### Prerequisites

- Visual Studio 2013 RTM Update 2 (at minimum)

## Building

#### Using Visual Studio

  - Open any solution, say, [`src\ResourceManagement\Compute\Compute.sln`](src/ResourceManagement/Compute/Compute.sln).
  - Invoke the "build" command.
  - Most solutions support 3 solution configurations, "Net40", "Net45", and "Portable". You can use "Configuration Manager" to switch and build.

#### Using the command line

  - Use `VsDevCmd` to Ensure "msbuild.exe" is in your path (replace "12.0" with your version): 
      `C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat`
  - You can build with [`build.proj`](build.proj). For example, to build a nuget package for compute management, run: 
      `msbuild build.proj /t:build;package /p:scope=ResourceManagement\Compute`
  - For other supported flags, check out the top comment section inside [`build.proj`](build.proj).

## Tests

#### Using Visual Studio

  - Most test projects only build for "net45". To run them, switch solution configuration to "net45".
  - Build.
  - "Test Explorer" window will be populated with tests. Go select and invoke.

#### Using the command line

  - Refer to the [building](#building) section to get the command window set up.
  - Invoke the "Test" target from [`build.proj`](build.proj). It's likely you'll need to build the test project first, so add the "build" target as well:
   `msbuild build.proj /t:build;test /p:scope=ResourceManagement\Compute`

## Issues with generated code

Much of the SDK code is generated from metadata specs about the REST APIs. Don't submit PRs that modify generated code. Instead, file an issue describing the problem, *or* refer to the the [AutoRest project][AutoRest] to view and modify the generator.

>Note: the generated code in the master branch is from a private project. The SDK is migrating to use AutoRest with generated code described by Swagger. Not all of the generator code is public yet, but it will be over the next few weeks. (July 2015).

[AutoRest]: https://github.com/azure/autorest
