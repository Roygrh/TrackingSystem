# Base image
FROM mcr.microsoft.com/mssql/server:2019-latest

# Environment variables for SQL Server and database setup
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=<YourStrong@Passw0rd>
ENV MSSQL_PID=Developer
ENV MSSQL_TCP_PORT=1433

# Create a directory for the app
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Copy the SQL script to the app directory
COPY docker-query.sql /usr/src/app/

# Run SQL script to create the database, table, and user with owner permissions
RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '<YourStrong@Passw0rd>' -i /usr/src/app/docker-query.sql

# Expose port 1433 for SQL Server
EXPOSE 1433

# Start SQL Server when the container starts
CMD ["/opt/mssql/bin/sqlservr"]
