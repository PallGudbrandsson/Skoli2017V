r.dbCreate('theWorld');

r.db('theWorld').tableCreate('continents');

r.db('theWorld').table('continents').insert([
	{'Name': 'Europe'},
		{
			'Name': 'Iceland', 
			'Code': 'ISL', 
			'Size': 'Small', 
			'Population': '300 000 ish', 
			'Goverment': 'Represenetive Democracy', 
			'Cities': 'Reykjavik'},
	{'Name': 'North America'},
		{'Name': 'Dumb fuckistan', 
		'Code': 'DUMBAF', 
		'Size': 'The States that voted for trump', 
		'Population': '62,985,106', 
		'Goverment': 'Trump', 
		'Cities': 'Full of regret'},
]);