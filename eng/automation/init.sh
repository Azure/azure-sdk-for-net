#!/bin/bash

if [ -z $1 ]; then
    echo "Please input outputfile"
    exit 1
fi
echo $1