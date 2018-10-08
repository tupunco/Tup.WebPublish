@ECHO OFF
REM @if exist "%ProgramFiles%\MSBuild\12.0\bin" set PATH=%ProgramFiles%\MSBuild\12.0\bin;%PATH%
REM @if exist "%ProgramFiles(x86)%\MSBuild\14.0\bin" set PATH=%ProgramFiles(x86)%\MSBuild\14.0\bin;%PATH%
@if exist "D:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin" set PATH=D:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin;%PATH%

SET SrcProjectFile=%~1
SET OutDir=%~2

ECHO %ProjectDir%
ECHO %OutDir%

MSBuild %SrcProjectFile% /t:Rebuild /p:Configuration=Release /p:OutDir=%OutDir%\bin\ /p:WebProjectOutputDir=%OutDir%\

EXIT