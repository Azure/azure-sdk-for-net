# Microsoft Azure SDK for .NET

The Microsoft Azure SDK for .NET allows you to build applications
that take advantage of scalable cloud computing resources.

### Target Frameworks:

    * .NET Framework 4.5
    * dnxcore50, based on the .NET Core framework 
    * .NET Portable Framework, using profile 111

### Prerequisites:
  Visual Studio 2015 RTM with ASP.NET. For details, check out the [installation doc](http://docs.asp.net/en/latest/getting-started/installing-on-windows.html). 
  
  Note, after done, run "_dnvm list_" command to check the 'coreclr' runtime is installed with right version of '_1.0.0-rc1-final_'. If not, run “_dnvm install 1.0.0-rc1-final -r coreclr -a x64 -Persistent_”. Remember always use "_-Persistent_" flag, so the selection can persist. 

### Known issue and workaround:
   Due to this [build issue on portable framework](aspnet/dnx#2967), when install VS 2015, use the default option. If you didn't, go to “_C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETPortable\v4.5\Profile\Profile111\SupportedFrameworks_”, remove several profile xmls and only keep core targets of “_.NET Framework 4.5.xml_”, “_Windows 8.xml_”, and “_Windows Phone 8.1.xml_”.
   
### To build:

Using Visual Studio:

  - Open any solution, say, "src\ResourceManagement\Compute\Compute.sln".
  - Invoke "build" command.

Using the command line:

  - Ensure "msbuild.exe" is under environment pathes, which you can run the command file pre-installed by Visual Studio.
        *C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\VsDevCmd.bat*
  - Under repository root, there is a "build.proj", which you can build with. For example, to build a nuget package for compute management, run:
        *msbuild build.proj /t:build;package /p:scope=ResourceManagement\Compute*
  - For other supported flags, check out the top comment section inside "build.proj".
   

### To run the tests:

Using Visual Studio:

  - Build.
  - "Test Explorer" window will get populated with tests. Go select and invoke.

Using the command line:

  - Refer to the "To build" section to get the command window set up.
  - Invoke "Test" target from "Build.proj". Likely, you need to build test project first, so put in "build" target as well. 
        *msbuild build.proj /t:build;test /p:scope=ResourceManagement\Compute*

### Issues with Generated Code
Much of the SDK code is generated from metadata specs about the REST APIs. Do not submit PRs that modify generated code. Instead, file an issue describing the problem, OR refer to the the [AutoRest project](AutoRest) to view and modify the generator. 

[AutoRest]:https://github.com/azure/autorest

