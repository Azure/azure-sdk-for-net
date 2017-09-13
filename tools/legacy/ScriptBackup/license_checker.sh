#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"

echo Scanning *.cs files for missing License header EXCEPT batch folder in $rootdir

badFiles=()
# Once Batch folder will be converter to MIT license uncomment the following line and remove the next read
#read -ra badFiles <<< $(find $rootdir -name '*.cs' -print | xargs grep -iL "// Licensed under the MIT License. See License.txt in the project root")
read -ra badFiles <<< $(find $rootdir -path "$rootdir/src/Batch" -prune -o -name '*.cs' -print | xargs grep -iL "// Licensed under the MIT License. See License.txt in the project root")

if [ -n "$badFiles" ]; then
	echo Setting build as FAILED...
	for s in "${badFiles[@]}"; do
    	echo "License header missing in: $s"
	done		
	exit -1
fi
exit 0