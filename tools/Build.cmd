call %~dp0\SetupEnv.cmd

msbuild %SDKNetRoot%\libraries.msbuild /t:DeveloperBuild;BuildPackages