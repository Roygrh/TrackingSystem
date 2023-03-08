CREATE DATABASE TrackingSystem;


USE TrackingSystem;
CREATE LOGIN trackinguser WITH PASSWORD = '123456';
CREATE USER trackinguser FOR LOGIN trackinguser;
ALTER ROLE db_owner ADD MEMBER trackinguser;


USE TrackingSystem;

CREATE TABLE Candidate
(
	CandidateId numeric(6,0) primary key identity(1,1),
	FirstName varchar(200) NOT NULL,
	LastName varchar(200) NOT NULL,
	EmailAdress varchar(200) NOT NULL unique,
	PhoneNumber varchar(15) NULL unique,
	ResidentialZipCode varchar(20) NULL
);

INSERT INTO Candidate VALUES('Maria','Espinoza','mespinoza@gmail.com','+51992457128','07046');
INSERT INTO Candidate VALUES('Angelo','Rodas','arodas@gmail.com','+51982317121','07035');
INSERT INTO Candidate VALUES('Arthur','Mauricio','amauricio@gmail.com','+51972737123','15003');
INSERT INTO Candidate VALUES('Boris','Quizpe','bquizpe@gmail.com','+51942457122','15026');
INSERT INTO Candidate VALUES('Fred','Becerra','fbecerra@gmail.com','+51942253232','15026');
INSERT INTO Candidate VALUES('Enrique','Quiroz','quirozato@gmail.com','+51968441644','15434');