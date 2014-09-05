
CREATE TABLE Team 
(
    id nvarchar(3) not null,
    city nvarchar(255) not null DEFAULT '',
    name nvarchar(255) not null DEFAULT '',
    logoUrl nvarchar(255) not null DEFAULT '',
     
    CONSTRAINT team_pk PRIMARY KEY (id)
)

CREATE TABLE Game 
(
    id int not null IDENTITY(1,1),
    
    week int not null,
    kickoff datetime not null,
    
    homeTeamId nvarchar(3) not null FOREIGN KEY REFERENCES Team(id),
    awayTeamId nvarchar(3) not null FOREIGN KEY REFERENCES Team(id),
    
    favoriteTeamId nvarchar(3) FOREIGN KEY REFERENCES Team(id),
    spread decimal not null DEFAULT 0,
    
    homeScore int,
    awayScore int,
    
    winningTeamId nvarchar(3) FOREIGN KEY REFERENCES Team(id),
    
    dateModified datetime not null DEFAULT getdate(),
    
    CONSTRAINT game_pk PRIMARY KEY (id),
)

CREATE TABLE [User]
( 
    --lowered version of email
    id nvarchar(255) not null,
    
    email nvarchar(255) not null,
    name nvarchar(255) not null DEFAULT '',
    nickname nvarchar(255) not null DEFAULT '',
    pictureUrl nvarchar(255) not null DEFAULT '',
    
    location nvarchar(255) not null DEFAULT '',
    status nvarchar(MAX) not null DEFAULT '',
    pastChampion nvarchar(255) not null DEFAULT '',
    
    role nvarchar(255) not null DEFAULT '',
    password nvarchar(255) not null DEFAULT '',
    
    sendReminder bit not null Default 1,
    paid bit not null default 0,
    
    active bit not null Default 1,
    lastActive date not null Default getdate(),
    
    
    CONSTRAINT user_pk PRIMARY KEY (id)
)
    

CREATE TABLE Pick
(
    id int not null IDENTITY(1,1),
    
    week int not null,
    userId nvarchar(255) not null FOREIGN KEY REFERENCES [User](id),
    
    pick5TeamId nvarchar(3) not null FOREIGN KEY REFERENCES Team(id),
    pick3TeamId nvarchar(3) not null FOREIGN KEY REFERENCES Team(id),
    pick2TeamId nvarchar(3) not null FOREIGN KEY REFERENCES Team(id),
    
    dateCreated datetime not null DEFAULT getDate(),
    userCreatedId nvarchar(255) not null FOREIGN KEY REFERENCES [User](id),
    
    deleted bit not null DEFAULT 0,
    
    CONSTRAINT pick_pk PRIMARY KEY (id)
)

CREATE TABLE MondayGuess
(
    id int not null Identity(1,1),
    
    userId nvarchar(255) not null FOREIGN KEY REFERENCES [User](id),
    gameId int not null FOREIGN KEY REFERENCES Game(id),
    
    guess int not null DEFAULT 0,
    
    dateCreated datetime not null DEFAULT getDate(),
    userCreatedId nvarchar(255) not null FOREIGN KEY REFERENCES [User](id),
    
    deleted bit not null DEFAULT 0,
    
    CONSTRAINT mondayGuess_pk PRIMARY KEY (id)
)

CREATE TABLE CommishAddress
(
    id int not null Identity(1,1),
    
    dateCreated datetime not null DEFAULT getdate(),
    message nvarchar(MAX) not null DEFAULT '',
)
 