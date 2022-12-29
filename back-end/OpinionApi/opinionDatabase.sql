CREATE TABLE opinion (
    id                      bigserial PRIMARY KEY,
    student_id              bigint NOT NULL,
    speciality_id           bigint NOT NULL,
    content                 text NOT NULL,
    rating                  float NOT NULL
);
