set path=E:\MaJiang\JDZMJClient\trunk\Client(Mac)\
rem ȡ�ú�ѹ����λ��
set haozip=C:\Program Files\2345Soft\HaoZip\HaoZipC.exe
rem ȡ��PCѹ����·��
set zipPath=E:\JXZC_Publish_Game
rem ȡ��Macѹ����·��
set zipMacPath=\\JXZCS-IMAC\jxzc\JXZC\MaJiang\JDZSparrow
rem ȡ����Ŀ����
set projectName=XcodeProject
set zipFile=%zipPath%\%projectName%.zip
if exist %zipFile% del %zipFile%
rem ��ʼѹ��
"%haozip%" a -tzip %zipFile% "%path%XcodeProject\*"
rem ���Ƶ�Mac����
set zipMacFile=%zipMacPath%\%projectName%.zip
if exist %zipMacFile% del %zipMacFile%
copy %zipFile% %zipMacPath%
"C:\Windows\explorer.exe" %zipPath%
"C:\Windows\explorer.exe" %zipMacPath%
