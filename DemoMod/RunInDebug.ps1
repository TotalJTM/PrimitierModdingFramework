$PRIMITIER_PATH = 'D:\Program Files (x86)\Steam\steamapps\common\Primitier';
$DEBUG_BIN_PATH = 'bin\Debug';

$ModsFolder =  $PRIMITIER_PATH+"\Mods"

Write-Output 'Clearing mods folder';
Remove-Item ($ModsFolder+"\*") -Recurse -Force;

Write-Output 'Copying debug folder';
Copy-Item -Path ($DEBUG_BIN_PATH+"\*") -Destination $ModsFolder -Recurse;

Write-Output 'Starting Primitier';
Start-Process ($PRIMITIER_PATH+"\Primitier.exe") -ArgumentList '--melonloader.debug';