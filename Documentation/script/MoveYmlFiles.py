# This Script Arranges the Yaml files into directories
# This causes the API generated to be grouped by their service names
import os
import re
import shutil
import sys


sourceDir = sys.argv[1]
apiDirPath = "{0}/docfx_project//api".format(sourceDir)

# Map Api to Service Folders
FileToFolderMap = {
    "Azure.ApplicationModel.Configuration" : "ApplicationModel.Configuration",
    "Azure.Identity" : "Identity",
    "Azure.Messaging.EventHubs" : "EventHubs",
    "Microsoft.Azure.EventHubs" : "EventHubs",
    "Azure.Security.KeyVault" : "KeyVault",
    "Microsoft.Azure.KeyVault" : "KeyVault",
    "Azure.Storage" : "Storage",
    "Microsoft.Azure.ApplicationInsights" : "ApplicationInsights",
    "Microsoft.Azure.Batch" : "Batch",
    "Microsoft.Azure.CognitiveServices" : "CognitiveServices",
    "Microsoft.Azure.ContainerRegistry" : "ContainerRegistry",
    "Microsoft.Azure.EventGrid" : "EventGrid",
    "Microsoft.Azure.Graph": "Graph.RBAC",
    "Microsoft.Azure.HDInsight": "HDInsight",
    "Microsoft.Azure.OperationalInsights": "OperationalInsights",
    "Microsoft.Azure.Search": "Search",
    "Microsoft.Azure.ServiceBus": "ServiceBus",
    "Azure.Core" : "Core",
}

# Create Folders
folders = FileToFolderMap.values()
for item in folders:
    path = os.path.join(apiDirPath, item)
    if not os.path.exists(path):
        os.makedirs(path)

os.makedirs(os.path.join(apiDirPath, 'OtherApis')) # For Apis that dont fit under a Dir

for item in os.listdir(apiDirPath):
    if item == '.gitignore' or item == '.manifest' or item == 'index.md' or item == 'toc.yml':
        print('Skip:', item)
        continue
    itemPath = os.path.join(apiDirPath, item)
    if os.path.isfile(itemPath):
        # Get first 3 words seperated by dots
        matchedThree = re.match(r'(^.*?\..*?\..*?)\..*', item, re.S)
        if matchedThree is not None:
            if matchedThree.group(1) in FileToFolderMap.keys():
                itemDest = FileToFolderMap[matchedThree.group(1)]
                print('Moved ', item , 'to', itemDest)
                shutil.move(itemPath, os.path.join(apiDirPath, itemDest))
                continue
        # Get first two word Seperated by dots
        matchedTwo = re.match(r'(^.*?\..*?)\..*', item, re.S)
        if matchedTwo is not None:
            if matchedTwo.group(1) in FileToFolderMap.keys():
                itemDest = FileToFolderMap[matchedTwo.group(1)]
                print('Moved ', item , 'to', FileToFolderMap[matchedTwo.group(1)])
                shutil.move(itemPath, os.path.join(apiDirPath, itemDest))
                continue
        print('Moved ', item , 'to OtherApis')
        shutil.move(itemPath, os.path.join(apiDirPath, 'OtherApis'))
