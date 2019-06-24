# This Script Generates Yaml files from ECMAXML
$XMLOutputDir = "D:\a\1\b\dll-xml-output"
$XMLOutputDir2 = "D:\a\1\b\dll-xml-output-2"
$ECMA2YamlDir = "D:\a\1\b\Microsoft.DocAsCode.ECMA2Yaml\tools"
$YAMLOutputDir = "D:\a\1\b\dll-yaml-output"

$Services = "ApplicationModel.Configuration", "Core", "Identity", "KeyVault", `
    "Storage", "ApplicationInsights", "Batch", "CognitiveServices", `
    "ContainerRegistry", "OperationalInsights", "Search", "ServiceBus", `
    "EventHubs", "Graph.RBAC", "EventGrid", "HDInsight"


# Arrange XML into folders
$XMLOutputDir
$XMLOutputDir2
$ECMA2YamlDir
cd $XMLOutputDir2
ForEach ($Item in $Services) {
    New-Item -Type dir $Item
}

cd $XMLOutputDir
$XMLOutputItems = ls
ForEach ($Dir in $Services) {
    $XMLFiltered = $XMLOutputItems | ? { $_.Name.Contains($Dir) }
    ForEach ($Item in $XMLFiltered) {
        If ($Item.Name.Contains('Core') -And ($Item.Name.Contains('EventHubs') `
                    -Or $Item.Name.Contains('KeyVault') -Or $Item.Name.Contains('ServiceBus'))) {
            continue
        }
        If ($Item.Name.Contains('Search') -And $Item.Name.Contains('CognitiveServices')) {
            continue
        }
        Copy-Item $Item -Destination "$XMLOutputDir2\$Dir" -Recurse
    }
}

#Generate Yaml from XML
cd $YAMLOutputDir
ForEach ($Item in $Services) {
    New-Item -Type dir $Item
}

cd $ECMA2YamlDir
ForEach ($Dir in $Services) {
    .\ECMA2Yaml.exe -s "$XMLOutputDir2\$Dir" -o "$YAMLOutputDir\$Dir"
}
