Changing Package Name
======================
Project directory name becomes package name by default.
If you would like change the package name of the project do the following
1) Rename the project directory to the desired name. project directory = name of the directory where project.json is located
2) Make the appropriate changes for the AssemblyProduct attribute defined in AssemblyInfo.cs

Adding code generated from AutoRest
===================================
1) Add the generated code to the existing Generated directory that you see in the project template

Adding test project to test your newly added SDK project
========================================================
1) Click Add new project to the existing solution
2) Search for "AzureDotNetSDK-TestProject"
3) Give appropriate name of your new Test Project, choose the right location

References:
===========
If you are adding a new reference, all three targets (.NET45, .NET standard 1.1, .NET standard 1.5) will need to be supported
So add the appropriate reference in project.json for the all the 3 frameworks that are listed in project.json

For more information please visit
https://github.com/Azure/adx-documentation-pr/blob/master/README.md

If you do not have access to the above repository, please visit
http://aka.ms/azuregithub

And join Azure Organization
https://repos.opensource.microsoft.com/Azure/
