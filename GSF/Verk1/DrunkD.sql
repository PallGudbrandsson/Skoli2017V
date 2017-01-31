DROP TABLE IF EXISTS data;
CREATE TABLE data(
	ID int(11) AUTO_INCREMENT,
	state varchar(255),
	cat varchar(255),
	num float(11),
	CONSTRAINT pk_data PRIMARY KEY(ID)
);
