# Repo-Tasks Module #

###### Usage:

1. Start ./tools/PS-VSPrompt.lnk (shortcut), this will start VS Dev Prompt in powershell
2. Import-Module ./tools/Repo-Tasks.psm1
	1. During import, we allow to load additional functions that users might want to use it in their session.
	2. If you have any userPreference.ps1 file under %userprofile%/psFiles directory, the module will try to load it by dot sourcing it.
	2. It will also honor environment variable $env:psuserpreferences and load .ps1 files from the location that is pointed by $env:psuserpreferences
	3. As long as you have exported all the functions that you need from your ps1 file using export-modulemember -function <name of function>. We deliberately do this to avoid polluting list of commands available (when you use Get-Command)
3. Currently Repo-Tasks module supports following tasks:
	1. Set-TestEnvironment
		1. Will allow you create a test connection string required to setup test environment in order to run tests. More information about Test environment can be found [here](https://github.com/Azure/azure-powershell/blob/dev/documentation/Using-Azure-TestFramework.md "here")
	2. Start-Build
		1. Will allow you to kick off full build
		2. Or will allow you build for a particular scope (e.g. Start-Build -BuildScope ResourceManagment\Compute)
	3. Get-BuildScopes
		1. Will allow you to query and find existing build scopes that can be used to build.
	4. Invoke-CheckinTests
		1. Will build and run existing tests.
	5. Install-VSProjectTemplates
		1. Installs projects templates for creating an empty project for
			1. AutoRest-SDK Project
			2. SDK for NET test project

###Note:
If you do not start your powershell session using PS-VSPrompt shortcut, you will not have access to all the environment variables that are set as part of VS Dev Command prompt.