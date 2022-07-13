Create database ParallelTest;

use ParallelTest;

create table Folders(
	Folderid INT NOT NULL identity(1,1),
	Name nvarchar not null,
	Location nvarchar not null,
	PRIMARY KEY(Folderid)
);

create table TextFile(
	TextFileid INT NOT NULL identity(1,1),
	Name nvarchar not null,
	Location nvarchar not null,
	PRIMARY KEY(TextFileid)
);