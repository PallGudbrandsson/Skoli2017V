DROP TABLE IF EXISTS data3;
CREATE TABLE data3(
	fall varchar(255),
	year datetime,
	nametype varchar(255)
	mass int(11),
	name varchar(255),
	type varchar(255),
	recclass float(25),
	reclat float(25),
	reclong float(25),
	id int(11),
	latitude float(25),
	needs_recording boolean,
	longitude float(25),
	ADD CONSTRAINT fall_def DEFAULT "UNKNOWN" FOR fall,
	ADD CONSTRAINT year_def DEFAULT NOW() for year,
	ADD CONSTRAINT nametype_def DEFAULT "UNKNOWN" for nametype,
	ADD CONSTRAINT mass_def DEFAULT 0 for mass,
	ADD CONSTRAINT name_def DEFAULT "UNKNOWN" for name,
	ADD CONSTRAINT type_def DEFAULT "UNKNOWN" for type,
	ADD CONSTRAINT recclass_def DEFAULT 0 for recclass,
	ADD CONSTRAINT reclat_def DEFAULT 0 for reclat,
	ADD CONSTRAINT reclong_def DEFAULT 0 for reclong,
	ADD CONSTRAINT id_def DEFAULT 0 for id,
	ADD CONSTRAINT latitude_def DEFAULT 0 for latitude,
	ADD CONSTRAINT needs_recording_def DEFAULT 1 for needs_recording,
	ADD CONSTRAINT longitude_def DEFAULT 0 for longitude
)