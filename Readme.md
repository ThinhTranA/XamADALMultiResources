# Xamarin Forms ADAL with multiple resources request
 
## 1. Setup Azure AD Auth on WebAPI (Azure App Services)
 Select web api App service in Azure. Under Settings Authentication/ Authorization
![Appservicesettting1](appservicesettting1.png)
Select express and press OK
![2](2.png)

Selecting express will automaticly add the web api app into Azure Active Directory.
Which can be found under Azure Active Directory / App registration
![3](3.png)

Select `BackEndTestAPI`, then select Redirect URIs:
 ![4](4.png)
![5](5.png)

The redirect URI: `https://backendtestapi.azurewebsites.net/.auth/login/aad/callback` was autoset for
us using express mode.

Going to `https://backendtestapi.azurewebsites.net/` now will prompt you to login.

## 2.Register Azure Active Directory for Mobile App 

This is because Azure AD won’t issue access tokens to unknown clients. And We can authenticate ourselves directly in the browser, but the mobile can't yet.

Under Azure Active Directory / App registrations , Click `New Registration`
![6](6.png)

The App can now be found under Owned applications, since you created manually
![7](7.png)
Click on the app, and set the Redirects URI that matched the redirect URI in step 1.
![8](8.png)

(note: if this won't match the login screen will throw error doesn't set or not match URI).








