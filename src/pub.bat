@ECHO OFF
REM @if exist "%ProgramFiles%\MSBuild\12.0\bin" set PATH=%ProgramFiles%\MSBuild\12.0\bin;%PATH%
@if exist "%ProgramFiles(x86)%\MSBuild\14.0\bin" set PATH=%ProgramFiles(x86)%\MSBuild\14.0\bin;%PATH%

SET SrcProjectFile=%~1
SET OutDir=%~2

ECHO %ProjectDir%
ECHO %OutDir%

MSBuild %SrcProjectFile% /t:Rebuild /p:Configuration=Release /p:OutDir=%OutDir%\bin\ /p:WebProjectOutputDir=%OutDir%\

EXIT