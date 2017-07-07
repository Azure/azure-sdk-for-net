@echo off

set OUTPUT=Generated
set CONF=storage.md

IF EXIST %OUTPUT% (
    rd %OUTPUT% /Q /S
 ) 

autorest %CONF% --verbose --debug