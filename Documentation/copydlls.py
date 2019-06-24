import os
import shutil
import sys

sourcePath = sys.argv[1]
binPath = sys.argv[2]

print(sourcePath)
print(binPath)

for root, dirs, files in os.walk('{0}/artifacts/bin'.format(sourcePath)):
    for pckgName in dirs:
        dllDirPath = os.path.join(root,pckgName,'Debug','net461')
        for fileName in os.listdir(dllDirPath):
            if fileName.endswith('.dll') or fileName.endswith('.xml') or fileName.endswith('.pdb'):
                if fileName.startswith(pckgName) and 'Tests' not in fileName and 'Management' not in fileName and 'Samples' not in fileName and 'Test' not in fileName:
                    dllPath = os.path.join(dllDirPath, fileName)
                    print ('Copy main {0} - '.format(dllPath))
                    shutil.copy(dllPath, '{0}/dll-docs/my-api'.format(binPath))
                else:
                    dllPath = os.path.join(dllDirPath, fileName)
                    print ('Copy Dependency {0} - '.format(dllPath))
                    shutil.copy(dllPath, '{0}/dll-docs/dependencies/my-api'.format(binPath))
    break