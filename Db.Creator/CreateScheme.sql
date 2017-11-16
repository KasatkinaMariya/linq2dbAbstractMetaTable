CREATE TABLE "EntityA" (
	  "Id" UUID PRIMARY KEY NOT NULL

	/* EntityA specific data */
	, "PropA1" VARCHAR NOT NULL
	, "PropA2" BOOLEAN NOT NULL
);
CREATE TABLE "EntityB" (
	  "Id" UUID PRIMARY KEY NOT NULL

	/* EntityB specific data */
	, "PropB1" NUMERIC(4,2) NOT NULL
	, "PropB2" NUMERIC(4,2) NOT NULL
);

CREATE TABLE "DataSource" (
	  "Id" UUID PRIMARY KEY NOT NULL
	/* source properties */
);
CREATE TABLE "SomeObject" (
	  "Id" UUID PRIMARY KEY NOT NULL
	/* object properties */
);

/* same data structures for A and B */
CREATE TABLE "DataEntityA" (
	  "Id" SERIAL PRIMARY KEY
	, "EntityId" UUID NOT NULL REFERENCES "EntityA"
	, "SourceId" UUID NOT NULL REFERENCES "DataSource"
	, "Value" NUMERIC(4,2) NOT NULL
	, "Timestamp" TIMESTAMP WITH TIME ZONE NOT NULL
);
CREATE TABLE "DataEntityB" (
	  "Id" SERIAL PRIMARY KEY
	, "EntityId" UUID NOT NULL REFERENCES "EntityB"
	, "SourceId" UUID NOT NULL REFERENCES "DataSource"
	, "Value" NUMERIC(4,2) NOT NULL
	, "Timestamp" TIMESTAMP WITH TIME ZONE NOT NULL
);
CREATE TABLE "LinkEntityA" (
	  "Id" SERIAL PRIMARY KEY
	, "EntityId" UUID NOT NULL REFERENCES "EntityA"
	, "LinkedObjectId" UUID NOT NULL REFERENCES "SomeObject"
	, "LastAccessTimestamp" TIMESTAMP WITH TIME ZONE NOT NULL
);
CREATE TABLE "LinkEntityB" (
	  "Id" SERIAL PRIMARY KEY
	, "EntityId" UUID NOT NULL REFERENCES "EntityB"
	, "LinkedObjectId" UUID NOT NULL REFERENCES "SomeObject"
	, "LastAccessTimestamp" TIMESTAMP WITH TIME ZONE NOT NULL
);