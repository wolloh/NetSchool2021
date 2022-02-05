#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM nginx:alpine AS base
WORKDIR /usr/share/nginx/html
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/Web/DSRNetSchool.WEB/DSRNetSchool.WEB.csproj", "Systems/Web/DSRNetSchool.WEB/DSRNetSchool.WEB.csproj"]
RUN dotnet restore "Systems/Web/DSRNetSchool.WEB/DSRNetSchool.WEB.csproj"
COPY . .
WORKDIR "/src/Systems/Web/DSRNetSchool.WEB"
RUN dotnet build "DSRNetSchool.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRNetSchool.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html
COPY Systems/Web/DSRNetSchool.WEB/nginx.conf /etc/nginx/nginx.conf
