MotionMail .Net
==============

[MotionMail](http://motionmailapp.com) API Lib for ASP.NET

#Configuring your application

You have 3 ways you can configure your application to use the API

**Option 1** - `AppSetting`
In your config file add the following entries
```xml
	<appSettings>
	    <add key="MotionMailApiKey" value="YOUR_API_KEY" />
	    <add key="MotionMailSecretKey" value="YOUR_SECRET_KEY" />
	</appSettings>
```

**Option 2** - `MotionMailConfiguration`
In the `Application_Start` method of your web application or the `Run` method of your console application

```c#	
	MotionMailConfiguration.SetApiKey("YOUR_API_KEY");
	MotionMailConfiguration.SetSecretKey("YOUR_SECRET_KEY");
```

**Option 3** - Constructor Argument
You can also supply your API and Secret key to the constructor of the service you are using

```c#
	IDateTimeTokenService service = new DateTimeTokenTokenService("YOUR_API_KEY", "YOUR_SECRET_KEY");
```

#Generating a DateTime token
After you have configured your API and Secret keys, you will use the IDateTimeTokenService to create a new token

```c#
    try {
		IDateTimeTokenService service = new DateTimeTokenTokenService();
		DateTimeTokenCreateCommand command = DateTimeTokenCreateCommand.FromDateTime(DateTime.Now);
		TokenResponse tokenResponse = service.Create(command);
		string urlToken = tokenResponse.Value;
	} catch(MotionMailApiException ex) {
		//handle exception
		string type = ex.MotionMailError.Type;
		string message = ex.MotionMailError.Message;
		string param = ex.MotionMailError.Param;
		HttpStatusCode statusCode = ex.MotionMailError.StatusCode;
	}
```

#Using a DateTime token
Once you have generated a new url token, you simply need to add the following to any timer embed code url

```html
    <img src="...?endDateTimeToken=URL_TOKEN" />
```