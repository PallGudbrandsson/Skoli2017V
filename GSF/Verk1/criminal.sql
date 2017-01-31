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
	longitude float(35)
);