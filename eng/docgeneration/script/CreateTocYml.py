# This Script Creates the Toc.yml file that groups the User Documentation page
import os
import re
import sys

sourceDir = sys.argv[1]
apiDirPath = "{0}/docfx_project/api".format(sourceDir)
apiTocPath = os.path.join(apiDirPath, 'toc.yml')

# Map Api to Service Folders
FileToFolderMap = {
    "- uid: Azure.ApplicationModel" : "ApplicationModel.Configuration",
    "- uid: Azure.Identity" : "Identity",
    "- uid: Azure.Messaging.EventHubs" : "EventHubs",
    "- uid: Azure.Security.KeyVault" : "KeyVault",
    "- uid: Azure.Storage": "Storage",
    "- uid: Microsoft.Azure.ApplicationInsights": "ApplicationInsights",
    "- uid: Microsoft.Azure.Batch": "Batch",
    "- uid: Microsoft.Azure.CognitiveServices": "CognitiveServices",
    "- uid: Microsoft.Azure.ContainerRegistry": "ContainerRegistry",
    "- uid: Microsoft.Azure.EventGrid": "EventGrid",
    "- uid: Microsoft.Azure.EventHubs" : "EventHubs",
    "- uid: Microsoft.Azure.Graph": "Graph.RBAC",
    "- uid: Microsoft.Azure.HDInsight": "HDInsight",
    "- uid: Microsoft.Azure.KeyVault" : "KeyVault",
    "- uid: Microsoft.Azure.OperationalInsights": "OperationalInsights",
    "- uid: Microsoft.Azure.Search": "Search",
    "- uid: Microsoft.Azure.ServiceBus": "ServiceBus",
    "- uid: Azure.Core" : "Core",
}

currentTocFile = open(os.path.join(apiDirPath, 'index.md')) # Start with a dummy open Just to set the variable
# Open Base
try:
    with open(apiTocPath, "r") as baseToc:
        for line in baseToc:
            if line.startswith('#'): continue
            if line.startswith('-'):
                matchedThree = re.match(r'(^- uid: .*?\..*?\..*?)($|\..*)', line, re.S)
                matchedTwo = re.match(r'(^- uid: .*?\..*?)($|\..*)', line, re.S)
                if matchedThree is not None and matchedThree.group(1) in FileToFolderMap.keys():
                    tocDir = FileToFolderMap[matchedThree.group(1)]
                    currentToc = os.path.join(apiDirPath, tocDir, 'toc.yml')
                    currentTocFile.close()
                    currentTocFile = open(currentToc, "a")
                    currentTocFile.write(line)
                    print('Write ', line, ': ', tocDir)
                    continue
                if matchedTwo is not None and matchedTwo.group(1) in FileToFolderMap.keys():
                    tocDir = FileToFolderMap[matchedTwo.group(1)]
                    currentToc = os.path.join(apiDirPath, tocDir, 'toc.yml')
                    currentTocFile.close()
                    currentTocFile = open(currentToc, "a")
                    currentTocFile.write(line)
                    print('Write ', line, ': ', tocDir)
                    continue
                else:
                    tocDir = 'OtherApis'
                    currentToc = os.path.join(apiDirPath, tocDir, 'toc.yml')
                    currentTocFile.close()
                    currentTocFile = open(currentToc, "a")
                    currentTocFile.write(line)
                    print('Write ', line, ': ', tocDir)
            else:
                currentTocFile.write(line)
except IOError:
    print("Error: File does not appear to exist")

currentTocFile.close()