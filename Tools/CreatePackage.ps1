# $msbuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
$msbuild = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"

.\IncrementVersion-cs.ps1 ..\KLibrary3\Linq

$slnFilePath = "..\KLibrary3\KLibrary3.sln"
& $msbuild $slnFilePath /p:Configuration=Release /t:Clean
& $msbuild $slnFilePath /p:Configuration=Release /t:Rebuild

cd ..\KLibrary3\Linq
.\NuGetPackup.exe

ni ..\..\Published -type directory -Force
move *.nupkg ..\..\Published -Force
explorer ..\..\Published
