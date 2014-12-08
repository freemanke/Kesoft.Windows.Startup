nuget update -self
nuget SetApiKey 11b952d1-5fa1-457c-adad-ec28a8c50bb4
nuget pack ..\sources\kesoft.windowsstartup\kesoft.windowsstartup.csproj
nuget push kesoft.windowsstartup.*.nupkg