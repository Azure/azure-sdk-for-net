# Versioning Rules followed for management plane

For the sake of discussing this, let's assume we have a new RP (ContosoService) and is about to release it's first API version 2017-12-01-preview  
ResourceProvider Name: ContosoService  
API Version: 2017-12-01-preview  

When you publish your REST spec for Constoso, you will create your first .NET SDK with following versions

Nuget publish date ==> Jan 01 2018
1. Nuget Package version    ==> 0.9.0-preview
2. AssemblyVersion          ==> 0.9.0.0
3. AssemblyFileVersion      ==> 0.9.0.0

Soon after you got feed back from your customers on your preview SDK and now you have few bugs to fix.  
So you iterated and published 2 additional SDK versions, for e.g.

Preview 1  

1. Nuget package version    ==> 0.10.0-preview
2. Assembly version         ==> 0.10.0.0
3. Assembly Fileversion     ==> 0.10.0.0
4. Publish date             ==> Feb 01 2018  

Preview 2
1. Nuget package version    ==> 0.11.0-preview
2. Assembly version         ==> 0.11.0.0
3. Assembly Fileversion     ==> 0.11.0.0
4. Publish date             ==> Mar 01 2018


Stable  
Now you are ready to go stable and do the following:

1. Publish your REST spec as stable (non-preview) as 2017-12-01
2. Nuget package version    ==> 1.0.0
3. Assembly version         ==> 1.0.0
4. Assembly Fileversion     ==> 1.0.0
5. Publish date             ==> Apr 01 2018

Now you are ready to add new feature to your stable version.

1. Nuget package version    ==> 1.1.0
2. Assembly version         ==> 1.0.0
3. Assembly Fileversion     ==> 1.1.0
4. Publish date             ==> May 01 2018





Now you are ready to work on your new API version 2018-06-01-preview

Preview 1
1. Nuget package version    ==> 1.9.0-preview
2. Assembly version         ==> 1.9.0.0
3. Assembly Fileversion     ==> 1.9.0.0
4. Publish date             ==> Jul 01 2018

Preview 2
1. Nuget package version    ==> 1.10.0-preview
2. Assembly version         ==> 1.10.0.0
3. Assembly Fileversion     ==> 1.10.0.0
4. Publish date             ==> Jul 01 2018

Now are your ready to go stable for 2018-06-01
1. Nuget package version    ==> 2.0.0
2. Assembly version         ==> 2.0.0.0
3. Assembly Fileversion     ==> 2.0.0.0
4. Publish date             ==> Aug 01 2018


If you ever have to add a new feature or fix a bug for your 1.0.0 stable SDK  
You can use the version range between 1.1.xx - 1.8.xx