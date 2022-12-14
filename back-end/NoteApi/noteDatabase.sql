CREATE TABLE note (
    id                      serial PRIMARY KEY,
    user_id                 bigint NOT NULL,
    created_at              timestamp NOT NULL
);

CREATE TABLE common_note (
    note_id                 integer REFERENCES note(id) ON DELETE CASCADE,
    title                   text NOT NULL,
    content                 text NOT NULL,
    PRIMARY KEY (note_id)
);

CREATE TABLE plan_note (
    note_id                 integer REFERENCES note(id) ON DELETE CASCADE,
    plan_id                 integer NOT NULL,
    title                   text NOT NULL,
    content                 text NOT NULL,
    PRIMARY KEY (note_id)
);

CREATE TABLE speciality_note (
    note_id                 integer REFERENCES note(id) ON DELETE CASCADE,
    speciality_id           integer NOT NULL,
    title                   text NOT NULL,
    content                 text NOT NULL,
    PRIMARY KEY (note_id)
);

CREATE TABLE speciality_highlight_note (
    note_id                 integer REFERENCES note(id) ON DELETE CASCADE,
    speciality_id           integer NOT NULL,
    positive                boolean NOT NULL, -- true -> like, false -> dislike/blacklist
    PRIMARY KEY (note_id)
);

CREATE TABLE speciality_priority_note (
    note_id                 integer REFERENCES note(id) ON DELETE CASCADE,
    speciality_id           integer NOT NULL,
    priority                smallint NOT NULL,
    CONSTRAINT valid_priority CHECK ((1 <= priority) AND (priority <= 10)),
    PRIMARY KEY (note_id)
);
