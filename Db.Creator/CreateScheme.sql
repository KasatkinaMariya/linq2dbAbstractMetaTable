CREATE TABLE entity_a (
	  id UUID PRIMARY KEY NOT NULL

	/* entity_a specific data */
	, prop_a1 VARCHAR NOT NULL
	, prop_a2 BOOLEAN NOT NULL
);
CREATE TABLE entity_b (
	  id UUID PRIMARY KEY NOT NULL

	/* entity_b specific data */
	, prop_b1 NUMERIC(4,2) NOT NULL
	, prop_b2 NUMERIC(4,2) NOT NULL
);

CREATE TABLE some_object (
	  id UUID PRIMARY KEY NOT NULL
	/* object properties */
);

/* same data structures for A and B */
CREATE TABLE some_data_entity_a (
	  id SERIAL PRIMARY KEY
	, entity_id UUID NOT NULL REFERENCES entity_a
	, linked_object_id UUID NOT NULL REFERENCES some_object
	, last_access_timestamp TIMESTAMP WITH TIME ZONE NOT NULL
	, entity_type SMALLINT NOT NULL DEFAULT = 1
);
CREATE TABLE some_data_entity_b (
	  id SERIAL PRIMARY KEY
	, entity_id UUID NOT NULL REFERENCES entity_b
	, linked_object_id UUID NOT NULL REFERENCES some_object
	, last_access_timestamp TIMESTAMP WITH TIME ZONE NOT NULL
	, entity_type SMALLINT NOT NULL DEFAULT = 2
);