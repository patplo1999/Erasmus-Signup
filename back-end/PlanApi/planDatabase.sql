CREATE TABLE status (
    id                      bigserial PRIMARY KEY,
    content                 varchar(50) NOT NULL
);

CREATE TABLE plan (
    id                      bigserial PRIMARY KEY,
    student_id              bigint NOT NULL,
    speciality_id           bigint NOT NULL,
    status_id               bigint REFERENCES status
);


CREATE TABLE subject (
    id                      bigserial PRIMARY KEY,
    plan_id                 bigint REFERENCES plan,
    name                    text NOT NULL,
    ects                    smallint NOT NULL,
    plan_mapping_row        bigint,
    is_pwr                  boolean NOT NULL
);

CREATE TABLE user_home_subject (
    id                      bigserial PRIMARY KEY,
    student_id              bigint NOT NULL,
    name                    text NOT NULL,
    ects                    smallint NOT NULL
);
