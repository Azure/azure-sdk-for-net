import * as fs from 'fs';
const { spawnSync } = require( 'child_process' );

const input: GenerateInput = readInput();
Log('There is a property in input: ' + input.repoHttpsUrl);
let flag: boolean = false;

input.relatedReadmeMdFiles.map(
    item => {
        if(item.indexOf('resource-manager') !== -1) {
            flag = true;
            return;
        }
    }
)
if(flag) {
    input.changedFiles.filter(item => item.includes('resource-manager'));
    let output: GenerateOutput = managementGeneration(input);
}

function managementGeneration(input: GenerateInput): GenerateOutput {
    let output: GenerateOutput = {
        packages: []
    };

    let rpIndex: string[] = getRPs(input.changedFiles); 
    rpIndex.map( rpName =>{
        Log('RP name: ' + rpName);
        let path: string = '../sdk/' + rpName + '/Azure.ResourceManager.' + rpName;
        Log('Project path: ' + path);
        if( !fs.existsSync(path) ){
            Log('Path do NOT exsits, new project!')
            buildProject(path, rpName);
        }
        generateCodeWithBuild(path, input.headSha);
        Log('Generate cuccess!!');
        output.packages.push(generateOutput(rpName));
        }
    )

    output.packages.map(
        item => Log("There is a output package with name: " + item.packageName)
    );
    return output;
}

// Log string
function Log(input: string) {
    console.log(input);
}

// Get generateInput.json file content
function readInput(): GenerateInput {
    let input: GenerateInput = JSON.parse(fs.readFileSync('generateInput.json','utf8'));
    return input;
}

// Sort RPs
function getRPs(changedFiles: string[]): string[] {
    let rpMapping = JSON.parse(fs.readFileSync('RPMapping.json','utf8'));
    let output: string[] = []; 
    changedFiles.map(element => {
        let rpName = element.substring(14);
        rpName = rpName.substring(0, rpName.indexOf('/'));
        rpName = rpMapping[rpName]
        if( output.findIndex(rp => rp === rpName) === -1 ){
            output.push(rpName);
        }
    });
    return output;
}

// Create project
function buildProject(path: string, rpName: string) {
    Log('RUN: dotnet new -i ../eng/templates/Azure.ResourceManager.Template');
    const newTemplate = spawnSync( 'dotnet', [ 'new', '-i', '../eng/templates/Azure.ResourceManager.Template' ] );
    Log('stdout here: \n' + newTemplate.stdout);
    fs.mkdir(path, { recursive: true }, (err) => {
        if (err) throw err;
      });
    Log('Maked floder: ' + path);
    Log('RUN: dotnet new azuremgmt --provider ' + rpName + '  Under: ' + path);
    const createProject = spawnSync( 'dotnet',[ 'new', 'azuremgmt', '--provider', rpName], { cwd: path } );
    Log('stdout here: \n' + createProject.stdout);
}

// Generate Code and build the project
function generateCodeWithBuild(path: string, commit: string) {
    Log('Start Generate Code!');
    const autorestFile: string = path + '/src/autorest.md';
    let content = fs.readFileSync(autorestFile, 'utf8');
    let pattern = new RegExp('azure-rest-api-specs\\/[\\S]*\\/specification','g');
    content = content.replace(pattern, 'azure-rest-api-specs/' + commit + '/specification');
    fs.writeFileSync(autorestFile, content, 'utf8');
    Log('autorest.md havs been updated with commit id: ' + commit);

    // Generate code
    Log('RUN: dotnet build /t:GenerateCode  Under: ' + path);
    const generate = spawnSync( 'dotnet', [ 'build', '/t:GenerateCode' ] , { cwd: path } );
    Log('stdout here: \n' + generate.stdout);
    Log('RUN: dotnet build  Under: ' + path);
    const build = spawnSync( 'dotnet', [ 'build' ] , { cwd: path } );
    Log('stdout here: \n' + build.stdout);
}

// Build Output Packages
function generateOutput(rpName: string): Package {
    let output: Package = {
        packageName: 'Azure.ResourceManager.' + rpName,
        path: [
            'sdk/' + rpName
        ],
        readmeMd: [
            'specification/' + rpName + '/resource-manager/readme.md'
          ],
        changelog: {
            content: "Feature: something \n Breaking Changes: something\n",
            hasBreakingChange: true
        },
        artifacts: [
            "sdk/cdn/cdn.nuget",
            "sdk/cdn/cdn.snuget"
        ],
        installInstructions: {
            "full": "To install something...",
            "lite": "dotnet something"
        },
        result: "success"
    };
    return output;
}

interface GenerateInput {
    dryRun: boolean;
    specFolder: string;
    headSha: string;
    headRef: string;
    repoHttpsUrl: string;
    trigger: string;
    changedFiles: string[];
    relatedReadmeMdFiles: string[];
}

interface GenerateOutput {
    packages: Package[];
}

type Package = {
    packageName: string;
    path: string[];
    readmeMd: string[];
    changelog: {
        content: string;
        hasBreakingChange: boolean;
    };
    artifacts: string[];
    installInstructions: {
        full: string;
        lite: string;
    };
    result: string;
}