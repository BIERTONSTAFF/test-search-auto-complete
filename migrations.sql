CREATE DATABASE testsearchautocomplete;

CREATE TABLE notes (
    id INT,
    name VARCHAR NOT NULL,
    content VARCHAR NOT NULL,
    search_vector tsvector
);

CREATE OR REPLACE FUNCTION notes_search_vector_setweight()
RETURNS trigger AS $$
BEGIN
    NEW.search_vector :=
        setweight(to_tsvector('russian', coalesce(NEW.name, '')), 'A') ||
        setweight(to_tsvector('russian', coalesce(NEW.content, '')), 'B');
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER notes_search_vector_setweight
    BEFORE INSERT OR UPDATE OF name, content
    ON notes
    FOR EACH ROW
    EXECUTE FUNCTION notes_search_vector_setweight();
