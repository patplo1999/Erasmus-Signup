CREATE TABLE user_profile (
    id                              smallserial PRIMARY KEY,
    user_id                         bigint NOT NULL,
    average_grade                   float NOT NULL,
    preferenced_study_domain_id     smallint
);

