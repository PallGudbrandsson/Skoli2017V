r.db('the world').tableCreate('continents');
r.table('continents').insert([
	{Name: 'Africa'},
	{Name: 'Antarctic'},
	{Name: 'Asia'},
	{Name: 'Europe'},
	{Name: 'North America'},
	{Name: 'Australia'},
	{Name: 'South America'}])

r.db('the world').tableCreate('countries');
r.table('countries').insert([
	{Name: 'Iceland', Code: 'ISL', Size: 'Small', Population: '300 000 ish', Goverment: 'Represenetive Democracy', Cities: 'Reykjavik'},
	{Name: 'United States of America', Code: 'USA', Size: 'Large', Population: '300 000 000', Goverment: 'Republic', Cities: 'New york'},
	{Name: 'Russia', Code: 'RUS', Size: 'Huge', Population: 'Who knows', Goverment: '"Democracy"', Cities: 'Omsk'},
	{Name: 'China', Code: 'CHN', Size: 'Quite large', Population: 'So many', Goverment: 'Commutist', Cities: 'Bejing'},
	{Name: 'Best Korea', Code: 'PRK', Size: 'Below Average', Population: 'All the best people', Goverment: 'Neocracy', Cities: 'Pjongjangotashesmqan'},
	{Name: 'Bad Korea', Code: 'KOR', Size: 'Larger than best korea', Population: 'Best korea rejects', Goverment: 'bad', Cities: 'not good'},
	{Name: 'Spain', Code: 'ESP', Size: 'Average', Population: 'Mostly tourists', Goverment: 'Who knows', Cities: 'The best'},
	{Name: 'Kroatia', Code: '???', Size: 'the fuck knows?', Population: 'some', Goverment: 'Democracy, I think?', Cities: 'none, just huts',
	{Name: 'Germany', Code: 'GER', Size: 'small enough', Population: 'Arian', Goverment: 'different', Cities: 'Only the finest'},
	{Name: 'Dumb fuckistan', Code: 'DUMBAF', Size: 'The States that voted for trump', Population: '62,985,106', Goverment: 'Trump', Cities: 'Full of regret'}])