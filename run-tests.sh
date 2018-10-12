#!/bin/bash
dotnet test ./EmployeeService.UnitTests /p:CollectCoverage=true   /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info 

