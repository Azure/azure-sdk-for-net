#!/bin/sh
dnu restore
set -e
armdir=`pwd`/src/ResourceManagement
for item in Compute Authorization Graph.RBAC Network Resource Storage WebSite
do
  if [ -d $armdir/$item ]
  then
    if [ -d $armdir/$item/$item.Tests ] && [ -f $armdir/$item/$item.Tests/project.json ]
    then
      cd $armdir/$item/$item.Tests
      dnu build --framework dnxcore50
      dnx test
      cd $armdir 
    fi
  fi
done
