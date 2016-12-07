var gulp = require('gulp');
var args = require('yargs').argv;
var exec = require('child_process').exec;
var fs = require('fs');

var mappings = {
    'compute': {
        'dir': 'Compute/Microsoft.Azure.Management.Fluent.Compute',
        'source': 'arm-compute/2016-03-30/swagger/compute.json',
        'package': 'Microsoft.Azure.Management.Fluent.Compute',
        'args': '-FT 1'
    },
    'storage': {
        'dir': 'Storage/Microsoft.Azure.Management.Fluent.Storage',
        'source': 'arm-storage/2016-01-01/swagger/storage.json',
        'package': 'Microsoft.Azure.Management.Fluent.Storage',
        'args': '-FT 2'
    },
    'resources': {
        'dir': 'ResourceManager/Microsoft.Azure.Management.Fluent.ResourceManager',
        'source': 'arm-resources/resources/2016-02-01/swagger/resources.json',
        'package': 'Microsoft.Azure.Management.Fluent.ResourceManager'
    },
    'subscriptions': {
        'dir': 'ResourceManager/Microsoft.Azure.Management.Fluent.ResourceManager',
        'source': 'arm-resources/subscriptions/2015-11-01/swagger/subscriptions.json',
        'package': 'Microsoft.Azure.Management.Fluent.ResourceManager'
    },
    'features': {
        'dir': 'ResourceManager/Microsoft.Azure.Management.Fluent.ResourceManager',
        'source': 'arm-resources/features/2015-12-01/swagger/features.json',
        'package': 'Microsoft.Azure.Management.Fluent.ResourceManager'
    },
    'network': {
        'dir': 'Network/Microsoft.Azure.Management.Fluent.Network',
        'source': 'arm-network/2016-06-01/swagger/network.json',
        'package': 'Microsoft.Azure.Management.Fluent.Network',
        'args': '-FT 1'
    },
    'batch': {
        'dir': 'Batch/Microsoft.Azure.Management.Fluent.Batch',
        'source': 'arm-batch/2015-12-01/swagger/BatchManagement.json',
        'package': 'Microsoft.Azure.Management.Fluent.Batch',
        'args': '-FT 1'
    },
    'redis': {
        'dir': 'RedisCache/Microsoft.Azure.Management.Redis.Fluent',
        'source': 'arm-redis/2016-04-01/swagger/redis.json',
        'package': 'Microsoft.Azure.Management.Redis.Fluent',
        'args': '-FT 1'
    },
    'graphrbac': {
        'dir': 'Graph.RBAC/Microsoft.Azure.Management.Fluent.Graph.RBAC',
        'source': 'arm-graphrbac/1.6/swagger/graphrbac.json',
        'package': 'Microsoft.Azure.Management.Fluent.Graph.RBAC',
    },
    'keyvault': {
        'dir': 'KeyVault/Microsoft.Azure.Management.Fluent.KeyVault',
        'source': 'arm-keyvault/2015-06-01/swagger/keyvault.json',
        'package': 'Microsoft.Azure.Management.Fluent.KeyVault',
    },
    'sql': {
        'dir': 'Sql/Microsoft.Azure.Management.Sql.Fluent',
        'source': 'arm-sql/compositeSql.json',
        'package': 'Microsoft.Azure.Management.Sql.Fluent',
        'composite': true,
        'args': '-FT 1'
    },
    'cdn': {
        'dir': 'Cdn/Microsoft.Azure.Management.Cdn.Fluent',
        'source': 'arm-cdn/2016-10-02/swagger/cdn.json',
        'package': 'Microsoft.Azure.Management.Cdn.Fluent',
        'args': '-FT 2'
    },
    'dns': {
        'dir': 'Dns/Microsoft.Azure.Management.Dns.Fluent',
        'source': 'arm-dns/2016-04-01/swagger/dns.json',
        'package': 'Microsoft.Azure.Management.Dns.Fluent',
        'args': '-FT 2'
    },
    'trafficmanager': {
        'dir': 'TrafficManager/Microsoft.Azure.Management.TrafficManager.Fluent',
        'source': 'arm-trafficmanager/2015-11-01/swagger/trafficmanager.json',
        'package': 'Microsoft.Azure.Management.TrafficManager.Fluent',
        'args': '-FT 2'
    }

};

gulp.task('default', function() {
    console.log("Usage: gulp codegen [--spec-root <swagger specs root>] [--projects <project names>] [--autorest <autorest info>]\n");
    console.log("--spec-root");
    console.log("\tRoot location of Swagger API specs, default value is \"https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master\"");
    console.log("--projects\n\tComma separated projects to regenerate, default is all. List of available project names:");
    Object.keys(mappings).forEach(function(i) {
        console.log('\t' + i.magenta);
    });
    console.log("--autorest\n\tThe version of AutoRest. E.g. 0.15.0, or the location of AutoRest repo, E.g. E:\\repo\\autorest");
});

var specRoot = args['spec-root'] || "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master";
var projects = args['projects'];
var autoRestVersion = '0.17.0-Nightly20160706'; // default
if (args['autorest'] !== undefined) {
    autoRestVersion = args['autorest'];
}
var autoRestExe;

gulp.task('codegen', function(cb) {
    var nugetSource = 'https://www.myget.org/F/autorest/api/v2';
    if (autoRestVersion.match(/[0-9]+\.[0-9]+\.[0-9]+.*/)) {
        autoRestExe = 'packages\\autorest.' + autoRestVersion + '\\tools\\AutoRest.exe';
        exec('tools\\nuget.exe install autorest -Source ' + nugetSource + ' -Version ' + autoRestVersion + ' -o packages', function(err, stdout, stderr) {
            console.log(stdout);
            console.error(stderr);
            handleInput(projects, cb);
        });
    } else {
        autoRestExe = autoRestVersion + "/" + GetAutoRestFolder() + "AutoRest.exe";
        if (process.platform !== 'win32') {
            autoRestExe = "mono " + autoRestExe;
        }
        handleInput(projects, cb);
    }

});

var handleInput = function(projects, cb) {
    if (projects === undefined) {
        Object.keys(mappings).forEach(function(proj) {
            codegen(proj, cb);
        });
    } else {
        projects.split(",").forEach(function(proj) {
            proj = proj.replace(/\ /g, '');
            if (mappings[proj] === undefined) {
                console.error('Invalid project name "' + proj + '"!');
                process.exit(1);
            }
            codegen(proj, cb);
        });
    }
}

var codegen = function(project, cb) {
    deleteFolderRecursive(mappings[project].dir + '/Generated');
    console.log('Generating "' + project + '" from spec file ' + specRoot + '/' + mappings[project].source);
    var generator = 'Azure.CSharp.Fluent';
    if (mappings[project].fluent !== null && mappings[project].fluent === false) {
        generator = 'Azure.CSharp';
    }
    var modeler = 'Swagger';
    if (mappings[project].composite !== null && mappings[project].composite === true) {
        modeler = 'CompositeSwagger';
    }
    cmd = autoRestExe + ' -Modeler ' + modeler + ' -CodeGenerator ' + generator + ' -Namespace ' + mappings[project].package + ' -Input ' + specRoot + '/' + mappings[project].source + 
            ' -outputDirectory ' + mappings[project].dir + '/Generated' + ' -Header MICROSOFT_MIT';
    if (mappings[project].args !== undefined) {
        cmd = cmd + ' ' + mappings[project].args;
    }
    console.log('Command: ' + cmd);
    exec(cmd, function(err, stdout, stderr) {
        console.log(stdout);
        console.error(stderr);
    });
};

var deleteFolderRecursive = function(path) {
    if(fs.existsSync(path)) {
        fs.readdirSync(path).forEach(function(file, index) {
            var curPath = path + "/" + file;
            if(fs.lstatSync(curPath).isDirectory()) { // recurse
                deleteFolderRecursive(curPath);
            } else { // delete file
                fs.unlinkSync(curPath);
            }
        });
        fs.rmdirSync(path);
    }
};


var isWindows = (process.platform.lastIndexOf('win') === 0);
var isLinux= (process.platform.lastIndexOf('linux') === 0);
var isMac = (process.platform.lastIndexOf('darwin') === 0);

function GetAutoRestFolder() {
  if (isWindows) {
    return "src/core/AutoRest/bin/Debug/net451/win7-x64/";
  }
  if( isMac ) {
    return "src/core/AutoRest/bin/Debug/net451/osx.10.11-x64/";
  } 
  if( isLinux ) { 
    return "src/core/AutoRest/bin/Debug/net451/ubuntu.14.04-x64/"
  }
   throw new Error("Unknown platform?");
}
