--Create the chocolate bar table
CREATE TABLE ChocolateBars
(
	[ChocolateBarID] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(128) NULL, 
    [Price] MONEY NULL
);

-- Create the review link table
CREATE TABLE Reviews
(
	[ReviewID] INT NOT NULL PRIMARY KEY, 
    [ChocolateBarID] INT NOT NULL, 
    [UserID] INT NOT NULL, 
    [Score] INT NOT NULL DEFAULT 0, 
    [Comment] TEXT NULL DEFAULT 'No text added'
);

-- Create the user table
CREATE TABLE Users
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    [FirstName] NCHAR(128) NOT NULL DEFAULT '', 
    [LastName] NCHAR(128) NOT NULL DEFAULT ''
)