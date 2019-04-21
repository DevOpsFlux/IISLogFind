# IISLogFind.exe Excute Program 
Windows IIS Log File Text Serch

## 1. 프로젝트 정보 및 버젼

### *[ IISLogFind Solution ]	
### *[ IISLogFind.csproj ]	

| 프로젝트 | 설명 | .NET버젼 | AdoToFormats버젼 |
| -------- | -------- | -------- | -------- |
| IISLogFind | IIS Log File 검색	| .NET 3.5	| IISLogFind.exe 2.0.0.0 |

## 2. IISLogFind 정보 및 참조
- SEED 암/복호화 모듈 ECB/CBC MODE
- CryptoNetCom.dll 1.0.0.0
- System.EnterpriseServices

## 3. IISLogFind 사용 정보
* IIS Log : C:\inetpub\logs\LogFiles\W3SVC2
* IISLogFind.exe 실행 > IIS Log 파일 지정 > 검색 데이터 지정 후 검색 실행 > LogView 확인

## 4. CryptoNetCom Class Description
- /Doc/CryptoNetCom모듈.xls

* 5. CryptoNetCom CryptLib Class :
```
public bool SeedEncrypt(string strKey, string strText, out string outVal, out string outErrMsg)
public bool SeedDecrypt(string strKey, string strEnc, out string outVal, out string outErrMsg)
public bool SeedECBEncrypt(string strKey, string strIV, string strText, out string outVal, out string outErrMsg)
public bool SeedECBDecrypt(string strKey, string strIV, string strEnc, out string outVal, out string outErrMsg)
public bool SeedECBPADEncrypt(string strKey, string strIV, string strText, out string outVal, out string outErrMsg)
public bool SeedECBPADDecrypt(string strKey, string strIV, string strEnc, out string outVal, out string outErrMsg)
public bool SeedCBCEncrypt(string strKey, string strIV, string strText, out string outVal, out string outErrMsg)
public bool SeedCBCDecrypt(string strKey, string strIV, string strEnc, out string outVal, out string outErrMsg)
public bool SeedCBCPADEncrypt(string strKey, string strIV, string strText, out string outVal, out string outErrMsg)
public bool SeedCBCPADDecrypt(string strKey, string strIV, string strEnc, out string outVal, out string outErrMsg)
```

## 5. Unit Test Sample
```
Option Explicit 

Call SeedCBCTest()

Sub SeedCBCTest()

	Dim objCom, retVal
	Dim SEEDKEY, SEEDIV, strText, strEnc, strDec
	Dim outVal, ErrMsg
	Dim strMsgBox
	

	SEEDKEY = "DevOpsFlux1580!@"
	SEEDIV = "2019GoodLuck1234"
	strText = "Test0987SeedCBCTest"

	strMsgBox = "strText : " & strText & vbCrLf

	Set objCom = CreateObject("CryptoNetCom.CryptLib")
	retVal = objCom.SeedCBCPADEncrypt(SEEDKEY, SEEDIV, strText, outVal, ErrMsg)
	strEnc = outVal
	'strMsgBox = strMsgBox & "seedEncrypt : " & strEnc & " ____ " & ErrMsg  & vbCrLf
	strMsgBox = strMsgBox & "seedEncrypt : " & strEnc & vbCrLf

	retVal = objCom.SeedCBCPADDecrypt(SEEDKEY, SEEDIV, strEnc, outVal, ErrMsg)
	strDec = outVal
	strMsgBox = strMsgBox & "SeedDecrypt : " & strDec & vbCrLf
	msgBox strMsgBox
	
	Set objCom = Nothing 
	
End Sub

```

![CryptoEncDec IMG](https://user-images.githubusercontent.com/49525161/56465899-3ff33280-6443-11e9-9f24-2bd25840c2c3.JPG)