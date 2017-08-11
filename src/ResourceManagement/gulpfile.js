var path = require('path');
var gulp = require('gulp');
var args = require('yargs').argv;
var colors = require('colors');
var exec = require('child_process').exec;
var fs = require('fs');

var mappings = {
    'compute': {
        'dir': 'Compute',
        'source': 'arm-compute/compositeComputeClient.json',
        'package': 'Microsoft.Azure.Management.Compute.Fluent',
        'composite': true,
        'args': '-FT 1'
    },
    'eventhub': {
        'dir': 'EventHub',
        'source': 'arm-eventhub/2015-08-01/swagger/EventHub.json',
        'package': 'Microsoft.Azure.Management.EventHub.Fluent',
        'args': '-FT 1'
    },
    'servicefabric': {
        'dir': 'ServiceFabric',
        'source': 'arm-servicefabric/2016-09-01/swagger/servicefabric.json',
        'package': 'Microsoft.Azure.Management.ServiceFabric.Fluent',
        'args': '-FT 1'
    },
    'notificationhubs': {
        'dir': 'NotificationHubs',
        'source': 'arm-notificationhubs/2017-04-01/swagger/notificationhubs.json',
        'package': 'Microsoft.Azure.Management.NotificationHubs.Fluent',
        'args': '-FT 1'
    },
    'analysisservices': {
        'dir': 'AnalysisServices',
        'source': 'arm-analysisservices/2016-05-16/swagger/analysisservices.json',
        'package': 'Microsoft.Azure.Management.AnalysisServices.Fluent',
        'args': '-FT 1'
    },
    'automation': {
        'dir': 'Automation',
        'source': 'arm-automation/compositeAutomation.json',
        'package': 'Microsoft.Azure.Management.Automation.Fluent',
        'args': '-FT 1',
        'modeler': 'CompositeSwagger'
    },
    'billing': {
        'dir': 'Billing',
        'source': 'arm-billing/2017-04-24-preview/swagger/billing.json',
        'package': 'Microsoft.Azure.Management.Billing.Fluent',
        'args': '-FT 1'
    },
    'cognitiveservices': {
        'dir': 'CognitiveServices',
        'source': 'arm-cognitiveservices/2017-04-18/swagger/cognitiveservices.json',
        'package': 'Microsoft.Azure.Management.CognitiveServices.Fluent',
        'args': '-FT 1'
    },
    'consumption': {
        'dir': 'Consumption',
        'source': 'arm-consumption/2017-04-24-preview/swagger/consumption.json',
        'package': 'Microsoft.Azure.Management.Consumption.Fluent',
        'args': '-FT 1'
    },
    'customerinsights': {
        'dir': 'CustomerInsights',
        'source': 'arm-customer-insights/2017-04-26/swagger/customer-insights.json',
        'package': 'Microsoft.Azure.Management.CustomerInsights.Fluent',
        'args': '-FT 1'
    },
    'devtestlab': {
        'dir': 'DevTestLab',
        'source': 'arm-devtestlabs/2016-05-15/swagger/DTL.json',
        'package': 'Microsoft.Azure.Management.DevTestLab.Fluent',
        'args': '-FT 1'
    },
    'insights': {
        'dir': 'Insights',
        'source': 'arm-insights/compositeInsightsManagementClient.json',
        'package': 'Microsoft.Azure.Management.Insights.Fluent',
        'args': '-FT 1',
        'modeler': 'CompositeSwagger'
    },
    'intune': {
        'dir': 'Intune',
        'source': 'arm-intune/2015-01-14-preview/swagger/intune.json',
        'package': 'Microsoft.Azure.Management.Intune.Fluent',
        'args': '-FT 1'
    },
    'iothub': {
        'dir': 'Devices',
        'source': 'arm-iothub/2017-01-19/swagger/iothub.json',
        'package': 'Microsoft.Azure.Management.Devices.Fluent',
        'args': '-FT 1'
    },
    'logic': {
        'dir': 'Logic',
        'source': 'arm-logic/2016-06-01/swagger/logic.json',
        'package': 'Microsoft.Azure.Management.Logic.Fluent',
        'args': '-FT 1'
    },
    'machinelearning': {
        'dir': 'MachineLearning',
        'source': 'arm-machinelearning/2017-01-01/swagger/webservices.json',
        'package': 'Microsoft.Azure.Management.MachineLearning.Fluent',
        'args': '-FT 1'
    },
    'operationalinsights': {
        'dir': 'OperationalInsights',
        'source': 'arm-operationalinsights/compositeOperationalInsights.json',
        'package': 'Microsoft.Azure.Management.OperationalInsights.Fluent',
        'args': '-FT 1',
        'modeler': 'CompositeSwagger'
    },
    'powerbi': {
        'dir': 'PowerBI',
        'source': 'arm-powerbiembedded/2016-01-29/swagger/powerbiembedded.json',
        'package': 'Microsoft.Azure.Management.PowerBI.Fluent',
        'args': '-FT 1'
    },
    'recoveryservices': {
        'dir': 'RecoveryServices',
        'source': 'arm-recoveryservices/compositeRecoveryServicesClient.json',
        'package': 'Microsoft.Azure.Management.RecoveryServices.Fluent',
        'args': '-FT 1',
        'modeler': 'CompositeSwagger'
    },
    'recoveryservicesbackup': {
        'dir': 'RecoveryServices.Backup',
        'source': 'arm-recoveryservicesbackup/2016-12-01/swagger/backupManagement.json',
        'package': 'Microsoft.Azure.Management.RecoveryServices.Backup.Fluent',
        'args': '-FT 1'
    },
    'recoveryservicessiterecovery': {
        'dir': 'RecoveryServices.SiteRecovery',
        'source': 'arm-recoveryservicessiterecovery/2016-08-10/swagger/service.json',
        'package': 'Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Fluent',
        'args': '-FT 1'
    },
    'relay': {
        'dir': 'Relay',
        'source': 'arm-relay/2017-04-01/swagger/relay.json',
        'package': 'Microsoft.Azure.Management.Relay.Fluent',
        'args': '-FT 1'
    },
    'storsimple8000series': {
        'dir': 'StorSimple',
        'source': 'arm-storsimple8000series/2017-06-01/swagger/storsimple.json',
        'package': 'Microsoft.Azure.Management.StorSimple.Fluent',
        'args': '-FT 1'
    },
    'streamanalytics': {
        'dir': 'StreamAnalytics',
        'source': 'arm-streamanalytics/compositeStreamAnalytics.json',
        'package': 'Microsoft.Azure.Management.StreamAnalytics.Fluent',
        'args': '-FT 1',
        'modeler': 'CompositeSwagger'
    },
    'storage': {
        'dir': 'Storage',
        'source': 'arm-storage/2016-01-01/swagger/storage.json',
        'package': 'Microsoft.Azure.Management.Storage.Fluent',
        'args': '-FT 2'
    },
    'resources': {
        'dir': 'ResourceManager',
        'source': 'arm-resources/resources/2016-02-01/swagger/resources.json',
        'package': 'Microsoft.Azure.Management.ResourceManager.Fluent'
    },
    'subscriptions': {
        'dir': 'ResourceManager',
        'source': 'arm-resources/subscriptions/2015-11-01/swagger/subscriptions.json',
        'package': 'Microsoft.Azure.Management.ResourceManager.Fluent'
    },
    'features': {
        'dir': 'ResourceManager',
        'source': 'arm-resources/features/2015-12-01/swagger/features.json',
        'package': 'Microsoft.Azure.Management.ResourceManager.Fluent'
    },
    'network': {
        'dir': 'Network',
        'source': 'arm-network/compositeNetworkClient.json',
        'package': 'Microsoft.Azure.Management.Network.Fluent',
        'args': '-FT 1',
        'composite': true,
    },
    'batch': {
        'dir': 'Batch',
        'source': 'arm-batch/2017-05-01/swagger/BatchManagement.json',
        'package': 'Microsoft.Azure.Management.Batch.Fluent',
        'args': '-FT 1'
    },
    'redis': {
        'dir': 'RedisCache',
        'source': 'arm-redis/2016-04-01/swagger/redis.json',
        'package': 'Microsoft.Azure.Management.Redis.Fluent',
        'args': '-FT 1'
    },
    'graphrbac': {
        'dir': 'Graph.RBAC',
        'source': 'arm-graphrbac/1.6/swagger/graphrbac.json',
        'package': 'Microsoft.Azure.Management.Graph.RBAC.Fluent',
    },
    'authorization': {
        'dir': 'Graph.RBAC',
        'source': 'arm-authorization/2015-07-01/swagger/authorization.json',
        'package': 'Microsoft.Azure.Management.Graph.RBAC.Fluent',
        'args': '-FT 1'
    },
    'keyvault': {
        'dir': 'KeyVault',
        'source': 'arm-keyvault/2015-06-01/swagger/keyvault.json',
        'package': 'Microsoft.Azure.Management.KeyVault.Fluent',
    },
    'sql': {
        'dir': 'Sql',
        'source': 'arm-sql/compositeSql.json',
        'package': 'Microsoft.Azure.Management.Sql.Fluent',
        'composite': true,
        'args': '-FT 1'
    },
    'cdn': {
        'dir': 'Cdn',
        'source': 'arm-cdn/2016-10-02/swagger/cdn.json',
        'package': 'Microsoft.Azure.Management.Cdn.Fluent',
        'args': '-FT 2'
    },
    'dns': {
        'dir': 'Dns',
        'source': 'arm-dns/2016-04-01/swagger/dns.json',
        'package': 'Microsoft.Azure.Management.Dns.Fluent',
        'args': '-FT 2'
    },
    'trafficmanager': {
        'dir': 'TrafficManager',
        'source': 'arm-trafficmanager/2017-05-01/swagger/trafficmanager.json',
        'package': 'Microsoft.Azure.Management.TrafficManager.Fluent',
        'args': '-FT 2'
    },
    'appservice': {
        'dir': 'AppService',
        'source': 'arm-web/compositeWebAppClient.json',
        'package': 'Microsoft.Azure.Management.AppService.Fluent',
        'composite': true,
        'args': '-FT 1'
    },
    'servicebus': {
        'dir': 'ServiceBus',
        'source': 'arm-servicebus\2015-08-01\swagger\servicebus.json',
        'package': 'Microsoft.Azure.Management.Fluent.ServiceBus',
        'args': '-FT 1'
    },
    'monitor': {
        'dir': 'Monitor',
        'source': 'arm-monitor/compositeMonitorManagementClient.json',
        'package': 'Microsoft.Azure.Management.Fluent.ServiceBus',
        'args': '-FT 1 -ServiceName Monitor',
        'composite': true
    },
    'monitor-dataplane': {
        'dir': 'Monitor',
        'source': 'monitor/compositeMonitorClient.json',
        'package': 'Microsoft.Azure.Management.Fluent.ServiceBus',
        'args': '-FT 1 -ServiceName Monitor',
        'composite': true
    },
    'containerregistry': {
        'dir': 'ContainerRegistry',
        'source': 'arm-containerregistry/2017-03-01/swagger/containerregistry.json',
        'package': 'Microsoft.Azure.Management.ContainerRegistry.Fluent',
        'args': '-FT 1',
    },
    'search': {
        'dir': 'Search',
        'source': 'arm-search/2015-08-19/swagger/search.json',
        'package': 'Microsoft.Azure.Management.Search.Fluent',
        'args': '-FT 1'
    },
    'scheduler': {
        'dir': 'Scheduler',
        'source': 'arm-scheduler/2016-03-01/swagger/scheduler.json',
        'package': 'Microsoft.Azure.Management.Scheduler.Fluent',
        'args': '-FT 1'
    },
    'documentdb': {
        'dir': 'DocumentDB',
        'source': 'arm-documentdb/2015-04-08/swagger/documentdb.json',
        'package': 'Microsoft.Azure.Management.DocumentDB.Fluent',
        'args': '-FT 1',
    }
};

gulp.task('default', function () {
    console.log("Usage: gulp codegen [--spec-root <swagger specs root>] [--projects <project names>] [--autorest <autorest info>]\n");
    console.log("--spec-root");
    console.log("\tRoot location of Swagger API specs, default value is \"https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master\"");
    console.log("--projects\n\tComma separated projects to regenerate, default is all. List of available project names:");
    Object.keys(mappings).forEach(function (i) {
        console.log('\t' + i.magenta);
    });
    console.log("--autorest\n\tThe version of AutoRest. E.g. 1.0.1-20170222-2300-nightly, or the location of AutoRest repo, E.g. E:\\repo\\autorest");
    console.log("--autorest-args\n\tPasses additional argument to AutoRest generator");
});

var specRoot = args['spec-root'] || "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master";
var projects = args['projects'];
var autoRestVersion = 'latest'; // default
if (args['autorest'] !== undefined) {
    autoRestVersion = args['autorest'];
}
var autoRestExe;

gulp.task('codegen', function (cb) {
    if (autoRestVersion.match(/[0-9]+\.[0-9]+\.[0-9]+.*/) ||
        autoRestVersion == 'latest') {
        autoRestExe = 'autorest ---version=' + autoRestVersion;
        handleInput(projects, cb);
    } else {
        autoRestExe = path.join(autoRestVersion, "src/core/AutoRest/bin/Debug/netcoreapp1.0/AutoRest.dll");
        if (process.platform !== 'win32') {
            autoRestExe = "dotnet " + autoRestExe;
        }
        handleInput(projects, cb);
    }

});

var handleInput = function (projects, cb) {
    if (projects === undefined) {
        Object.keys(mappings).forEach(function (proj) {
            codegen(proj, cb);
        });
    } else {
        projects.split(",").forEach(function (proj) {
            proj = proj.replace(/\ /g, '');
            if (mappings[proj] === undefined) {
                console.error('Invalid project name "' + proj + '"!');
                process.exit(1);
            }
            codegen(proj, cb);
        });
    }
}

var codegen = function (project, cb) {
    var outputDir = mappings[project].dir + '/Generated';
    if (!args['preserve']) {
        deleteFolderRecursive(outputDir);
    }
    console.log('Generating "' + project + '" from spec file ' + specRoot + '/' + mappings[project].source);
    var generator = 'Azure.CSharp.Fluent';
    if (mappings[project].fluent !== null && mappings[project].fluent === false) {
        generator = 'Azure.CSharp';
    }
    var modeler = 'Swagger';
    if (mappings[project].composite !== null && mappings[project].composite === true) {
        modeler = 'CompositeSwagger';
    }
    cmd = autoRestExe + ' -Modeler ' + modeler +
        ' -CodeGenerator ' + generator +
        ' -Namespace ' + mappings[project].package +
        ' -Input ' + specRoot + '/' + mappings[project].source +
        ' -outputDirectory ' + outputDir +
        ' -Header MICROSOFT_MIT' +
        ' -RegenerateManager true' +
        ' -skipValidation true';
    if (mappings[project].args !== undefined) {
        cmd = cmd + ' ' + mappings[project].args;
    }
    console.log('Command: ' + cmd);
    exec(cmd, function (err, stdout, stderr) {
        console.log(stdout);
        console.error(stderr);
    });
};

var deleteFolderRecursive = function (path) {
    if (fs.existsSync(path)) {
        fs.readdirSync(path).forEach(function (file, index) {
            var curPath = path + "/" + file;
            if (fs.lstatSync(curPath).isDirectory()) { // recurse
                deleteFolderRecursive(curPath);
            } else { // delete file
                fs.unlinkSync(curPath);
            }
        });
        fs.rmdirSync(path);
    }
};
