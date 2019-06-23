# Xamarin Forms ADAL with multiple resources request
 
## 1. Setup Azure AD Auth on WebAPI (Azure App Services)
 Select web api App service in Azure. Under Settings Authentication/ Authorization
![Appservicesettting1](appservicesettting1.png)
Select Express and press OK
![2](2.png)

Selecting Express will automaticly add the web api app into Azure Active Directory.
Which can be found under Azure Active Directory / App registration
![3](3.png)

Select `BackEndTestAPI`, then select Redirect URIs:
 ![4](4.png)
![5](5.png)

The redirect URI: `https://backendtestapi.azurewebsites.net/.auth/login/aad/callback` was autoset for
us using express mode.

Going to `https://backendtestapi.azurewebsites.net/` now will prompt you to login.

### Important:     Add Allowed Token Audiences
There is a bug in the `Express` options. It doesn't add the website URL in the allowed token audiences. 
(Hence, the granted accessToken for `https://backendtestapi.azurewebsites.net/` will still give unauthorized 401 error
when send request to it.)
Follow these steps to fix this bug:

* Go to the first website in Azure portal
* Click on the Authentication / Authorization blade
* Click on the Azure AD
* Change it from Express to Advanced
* In the Allowed Token Audiences add your website URL as shown below (eg: `https://backendtestapi.azurewebsites.net/`)
* Click OK
* Click Save

![9](9.png)


## 2.Register Azure Active Directory for Mobile App 

This is because Azure AD won’t issue access tokens to unknown clients. And We can authenticate ourselves directly in the browser, but the mobile can't yet.

Under Azure Active Directory / App registrations , Click `New Registration`
![6](6.png)

The App can now be found under Owned applications, since you created manually
![7](7.png)

Click on the app, and under `Overview` set the Redirects URI that matched the redirect URI in step 1.

![8](8.png)

(Note: if this won't match the login screen will throw error doesn't set or not match URI).



Select the App/ API permissions
Click Add a permission
Select APIs my organization uses
Search for the name of the api(eg: `BackEndTestAPI`)

![10](10.png)
![11](11.png)

Select the app, tick `user_impersonation`
Click Add permissions_

![12](12.png)

API permissions will now look like this:
![13](13.png)



Another slightly different of using IPlatformParameters only instead of ILoginProvider : 
https://github.com/TimLariviere/WoodenMoose.Samples.Xamarin_Authentication







