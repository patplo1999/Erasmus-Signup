FROM postgres
ENV POSTGRES_DB university_db
ENV POSTGRES_USER test
ENV POSTGRES_PASSWORD 123
COPY university.sql /docker-entrypoint-initdb.d/
