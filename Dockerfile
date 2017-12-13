FROM microsoft/aspnetcore:2.0
COPY deploy /app
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "Server.dll"]