call %~dp0\SetupEnv.cmd

msbuild %SDKNetRoot%\libraries.msbuild /t:runtests /p:configuration=debug
