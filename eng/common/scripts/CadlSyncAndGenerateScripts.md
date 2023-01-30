# Integrating with cadl sync and generate scripts

There are 2 common scripts provided for each language to be able to generate from within the language
repo and use the remote cadl definition in the spec repo.

## Prerequisites

There are 4 things that these two scripts expect are set up in your language repo before they will run correctly.

### cadl-location.yaml

This file should live under the project directory for each service and has the following properties

| Property | Description | IsRequired |
| --- | --- | --- |
| directory | The top level directory where the main.cadl for the serivce lives.  This should be relative to the spec repo root such as `specification/cognitiveservices/OpenAI.Inference` | true |
| additionalDirectories | Sometimes a cadl file will use a relative import that might not be under the main directory.  In this case you can specify additional directories as a list to sync so that all needed files are synced. | false: default = null |
| commit | The commit sha for the version of the cadl files you want to generate off of.  This allows us to have idempotence on generation until we opt into pointing at a later version. | true |
| repo | The repo this spec lives in.  This should be either `Azure/azure-rest-api-specs` or `Azure/azure-rest-api-specs-pr`.  Note that pr will work locally but not in CI until we add another change to handle token based auth. | true |
| cleanup | This will remove the TempCadlFiles directory after generation is complete if true otherwise this directory will be left to support local changes to the files to see how different changes would affect the generation. | false: default = true |

Example

```yml
directory: specification/cognitiveservices/OpenAI.Inference
additionalDirectories:
  - specification/cognitiveservices/OpenAI.Authoring
commit: 14f11cab735354c3e253045f7fbd2f1b9f90f7ca
repo: Azure/azure-rest-api-specs
cleanup: false
```

### TempCadlFiles

You should add a new entry in your .gitignore for your repo so that none of these files are accidentally checked in if cleanup is turned off.
`TempCadlFiles/`

### emitter-package.json

This will be the package.json that gets used when `npm install` is called.  This replaces the package.json checked into the spec repo and allows each language to fix the version of their emitter to be the same for all packages in their repo.
The file should be checked into this location `./eng/emitter-package.json`

Example

```json
{
    "main": "dist/src/index.js",
    "dependencies": {
      "@azure-tools/cadl-csharp": "0.1.11-beta.20230123.1"
    }
}
```

Note that cadl compile currently requires the "main" line to be there.

### Language-Settings.ps1

There are three methods you can write in your language repo to adjust the behavior of the scripts one of which is required.
For each of these replace `${Language}` with the language identifier in your repo.  If you don't know what this is you can look at `./eng/scripts/Language-Settings.ps1` in your language repo and you will find other functions that match this pattern that already exist.

#### Get-${Language}-EmitterName *(Required)*

This function simply returns the emitter name string.

Example

```powershell
function Get-dotnet-EmitterName() {
  return "@azure-tools/cadl-csharp"
}
```

#### Get-${Language}-EmitterPackageJsonPath (Optional)

This function allows you to specify the location and name of the emitter package.json to use.  If this is omitted the script will assume the default location listed above `./eng/emitter-package.json`.  The path must be absolute.

Example

```powershell
function Get-dotnet-EmitterPackageJsonPath() {
  return "D:\SomeOtherLocation\some-other-emitter-package.json"
}
```

#### Get-${Language}-EmitterAdditionalOptions (Optional)

This function allows you to append additional `--option` arguments that will be passed into cadl compile.  One example of this is the `emitter-output-dir`.  For dotnet we want the location of the generated files to be `{projectDir}/src` however in other languages they will have other conventions.  This method will take in a fully qualified path to the project directory so you can construct your relative path to that as the output.

Example

```powershell
function Get-dotnet-EmitterAdditionalOptions([string]$projectDirectory) {
  return "--option @azure-tools/cadl-csharp.emitter-output-dir=$projectDirectory/src"
}
```

## Cadl-Project-Sync.ps1

This is the first script that should be called and can be found at `./eng/common/scripts/Cadl-Project-Sync.ps1`.  It takes in one parameter which is the root directory of the project which is typically one layer lower than the service directory.  As an example for dotnet this is `./sdk/openai/Azure.AI.OpenAI` where `openai` is the service directory and `Azure.AI.OpenAI` is the project directory.

This script will create a sparse check out at the root of your current repository named after the project directory, automatically filter to only the files in the directory defined in cadl-location.yaml, and sync to the sha defined in cadl-location.yaml.

If you have your language repo at `D:\git\azure-sdk-for-net` there will be a new directory `D:\git\sparse-checkout\Azure.AI.OpenAI` where the sparse checkout will live.

This is then copied over to your project directory so that you can make temporary changes if needed.  The location will be `./{projectDir}/TempCadlFiles`.  This temporary directory will be cleaned up at the end of the generate script if set in the cadl-location.yaml.

## Cadl-Project-Generate.ps1

This is the second script that should be called and can be found at `./eng/common/scripts/Cadl-Project-Generate.ps1`.  It takes the exact same parameter as the sync script.

The first thing this does is clean up the npm install that might exist in `./{projectDir}/TempCadlFiles`, followed by replacing the package.json with the language static one.

Once this is done it will run `npm install` followed by `cadl compile` which is the standard way to generate a cadl project.

The exact command that gets run is output stdout to enable debugging if needed.

We currently don't do anything to the cadl-project.yaml that gets pulled in from the spec repo to limit to just your language emitter instead we use the filter option on the command line `--emit $emitterName`.  This allows you to isolate the generation to only things owned by your language so you can safely add generation dependencies in CI without needing to worry about noisy neighbors.

## Build tool integration

One use case that some languages have is to have their CI regenerate the project and then do a `git diff` to validate that there are no differences.  This helps detect if people modify the generated files manually.  To support this its valuable to have the exact same command to generate a project regardless of whether the individual library is autorest or cadl.

To achieve this each language will have their own idiomatic tool set but whatever that toolset is can check to see if a cadl-location.yaml file exists, and if it does they can call the Cadl-Project-Sync.ps1 and Cadl-Project-Generate.ps1 scripts, otherwise they can call the autorest command they call today for all other libraries.

In dotnet this is achieved by running `dotnet build /t:GenerateCode` regardless of which type of project it is the correct commands get called and it remains consistent and idiomatic to the language.  In other languages this could be `npm generate` or `python generate.py` to do the same.

Since the generate script simply is a wrapper for `npm install` and `cadl compile` you can still run those commands directly manually after the sync if you want to instead.
