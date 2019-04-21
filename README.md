# IISLogFind.exe Excute Program 
Windows IIS Log File Text Serch

## 1. 프로젝트 정보 및 버젼

### *[ IISLogFind Solution ]	
### *[ IISLogFind.csproj ]	

| 프로젝트 | 설명 | .NET버젼 | AdoToFormats버젼 |
| -------- | -------- | -------- | -------- |
| IISLogFind | IIS Log File 검색	| .NET 3.5	| IISLogFind.exe 1.0.0.1 |

## 2. IISLogFind 정보 및 참조
- IISLogFind.exe v2.0
- using System.IO;
- using System.Threading;
- using System.Collections;

## 3. IISLogFind 사용 정보
* IIS Log : C:\inetpub\logs\LogFiles\W3SVC2
* IISLogFind.exe 실행 > IIS Log 파일 지정 > 검색 데이터 지정 후 검색 실행 > LogView 확인
![IISLogFind](https://user-images.githubusercontent.com/49525161/56466030-bbee7a00-6445-11e9-870c-f133b6a4ad6c.jpg)

## 4. IISLogFind Sample
- /Sample/find_20190304.txt
- /Sample/IISLogFind.jpg

## 5. IISLogFind Class :
```
class IISLogFind
		Event Halller
		GetFind
		GetFindMulti
		GetFileInfo
		CheckLogFileExist
		SetProgressbar
		SetTimer

class LibCommon
	 ChooseFolder()
	 ChooseFilePath()
	 ChooseFileMultiPath()

class LibShell
	ExecuteShellCommand(string strCmdText) 
	ExecuteShellCommand(string _FileToExecute, string _CommandLine, ref string _outputMessage, ref string _errorMessage)
```
