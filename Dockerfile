# Base image
FROM mcr.microsoft.com/mssql/server:2022-latest

# Environment variables for SQL Server and database setup
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=YourStrong@Passw0rd_123456
ENV MSSQL_PID=Express
ENV MSSQL_TCP_PORT=1433

USER root

#RUN apt-get update && apt-get install -y mssql-tools

# Create a new user
RUN useradd -ms /bin/bash newuser

# Create a directory for the app and change owner to newuser
RUN mkdir -p /app && chown -R newuser:newuser /app

# Switch to newuser
USER newuser

# Copy the SQL script to the app directory
COPY docker-query.sql /app

# Run SQL script to create the database, table, and user with owner permissions
RUN /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U SA -P 'YourStrong@Passw0rd_123456' -i /app/docker-query.sql

# Expose port 1433 for SQL Server
EXPOSE 1433:1433

# Start SQL Server when the container starts
CMD ["/opt/mssql/bin/sqlservr"]
