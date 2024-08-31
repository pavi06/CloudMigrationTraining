# Use the official SQL Server image as a base
FROM mcr.microsoft.com/mssql/server:2019-latest

# Copy the initialization script into the container
COPY . /docker-entrypoint-initdb.d/init.sql

# Create a custom entrypoint script
ENTRYPOINT ["/bin/bash", "-c", "/opt/mssql/bin/sqlservr & sleep 30s && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -i /docker-entrypoint-initdb.d/init.sql && wait"]