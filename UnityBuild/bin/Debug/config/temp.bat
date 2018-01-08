set path=E:\MaJiang\JDZMJClient\trunk\Client(Mac)\
rem 取得好压程序位置
set haozip=C:\Program Files\2345Soft\HaoZip\HaoZipC.exe
rem 取得PC压缩包路径
set zipPath=E:\JXZC_Publish_Game
rem 取得Mac压缩包路径
set zipMacPath=\\JXZCS-IMAC\jxzc\JXZC\MaJiang\JDZSparrow
rem 取得项目名称
set projectName=XcodeProject
set zipFile=%zipPath%\%projectName%.zip
if exist %zipFile% del %zipFile%
rem 开始压缩
"%haozip%" a -tzip %zipFile% "%path%XcodeProject\*"
rem 复制到Mac电脑
set zipMacFile=%zipMacPath%\%projectName%.zip
if exist %zipMacFile% del %zipMacFile%
copy %zipFile% %zipMacPath%
"C:\Windows\explorer.exe" %zipPath%
"C:\Windows\explorer.exe" %zipMacPath%
