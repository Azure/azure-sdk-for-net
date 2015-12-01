#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"

dnu restore
cd $rootdir/src/TestFramework/HttpRecorder.Tests
dnu build --framework dnxcore50
dnx test
cd  ../TestFramework.Tests
dnu build --framework dnxcore50
dnx test

armdir=$rootdir/src/ResourceManagement
for folder in $armdir/*
do
  item=`basename $folder`
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
