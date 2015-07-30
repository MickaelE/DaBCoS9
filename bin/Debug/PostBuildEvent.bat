@echo off
COPY "D:\Work\Mine\DaBCoS3\DaBCoS.Engine\\XML\*.xml" "D:\Work\Mine\DaBCoS3\bin\Debug\"
if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd