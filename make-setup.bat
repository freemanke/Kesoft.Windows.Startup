;����Release�汾
set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %MSBuildDir%\msbuild sources\Kesoft.WindowsStartup.sln /t:build /p:Configuration="Release"
@IF %ERRORLEVEL% NEQ 0 PAUSE

;���ɰ�װ�ļ�
"C:\Program Files (x86)\Inno Setup 5\ISCC.exe" setup.iss