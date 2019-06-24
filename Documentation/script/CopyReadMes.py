# Copy All ReadMes in the Repo
import os
import shutil
import sys

sourceDir = sys.argv[1]
sdkDirPath = '{0}/sdk'.format(sourceDir)
articlesDir = '{0}/docfx_project/articles'.format(sourceDir)

services = ['core', 'appconfiguration', 'applicationinsights', 'batch', 'cognitiveservices', 'containerregistry',
            'eventgrid', 'eventhub', 'graphrbac', 'hdinsight', 'identity', 'keyvault', 'operationalinsights',
            'search', 'servicebus', 'storage']

for root, dirs, files in os.walk(sdkDirPath):
    for servieDir in dirs:
        if servieDir in services:
            serviceDirPath = os.path.join(sdkDirPath, servieDir)
            for serviceRoot, serviceDirs, serviceFiles in os.walk(serviceDirPath):
                for file in serviceFiles:
                    if file.endswith('.md'):
                        sourceFileName = os.path.join(serviceRoot, file)
                        fileName = serviceRoot.replace(sdkDirPath, '')
                        fileName = os.path.join(fileName, file)
                        fileName = fileName.replace('/', '-')
                        fileName = fileName.replace('\\', '-')
                        print('Copy: ', sourceFileName)
                        shutil.copyfile(sourceFileName, os.path.join(articlesDir, fileName))
                        print(fileName)
    break