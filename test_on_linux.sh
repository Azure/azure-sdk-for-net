#!bin/sh

for item in src/ResourceManagement/*
do
  if [ -d $item ]
  then
    if [ -d $item/$item.Tests ] && [ -f $item\$item.Tests\project.json ]
    then
      dnu $item/$item.Tests/project.json build --framework dnxcore50
      dnx $item/$item.Tests/project.json test
    fi
  fi
done
