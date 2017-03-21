DROP TABLE IF EXISTS data2;
CREATE TABLE data2(
	ID int(11) AUTO_INCREMENT,
	cdatetime datetime,
	address varchar(255),
	district int(11),
	beat varchar(255),
	grid int(11),
	crimedescr varchar(255),
	ucr_ncic_code int(11),
	latitude float(35),
	longitude float(35),
	CONSTRAINT pk_data1 PRIMARY KEY(ID)
	ADD CONSTRAINT ID_def DEFAULT "UNKNOWN" for ID, 
	ADD CONSTRAINT cdatetime_def DEFAULT NOW() for cdatetime, 
	ADD CONSTRAINT address_def DEFAULT "UNKNOWN" for address, 
	ADD CONSTRAINT district_def DEFAULT 0 for district, 
	ADD CONSTRAINT beat_def DEFAULT "UNKNOWN" for beat, 
	ADD CONSTRAINT grid_def DEFAULT 0 for grid, 
	ADD CONSTRAINT crimedescr_def DEFAULT "UNKNOWN" for crimedescr, 
	ADD CONSTRAINT ucr_ncic_code_def DEFAULT 0 for ucr_ncic_code, 
	ADD CONSTRAINT latitude_def DEFAULT 0 for latitude, 
	ADD CONSTRAINT longitude_def DEFAULT 0 for longitude
);