-- SQLite
create table User
(
    user_id             INTEGER PRIMARY KEY AUTOINCREMENT,
    email_address       TEXT    NOT NULL,
    password            TEXT    NOT NULL,
    source              TEXT    NOT NULL,
    first_name          TEXT,
    last_name           TEXT,
    profile_picture_url TEXT,
    date_of_birth       DATETIME,
    about_me            TEXT,
    notifications       INTEGER,
    dark_theme          INTEGER,
    created_date        DATE

);

create table ChatHistory
(
    chat_history_id     INTEGER PRIMARY KEY AUTOINCREMENT,
    from_user_id        INT NOT NULL,
    to_user_id          INT NOT NULL,
    message             TEXT NOT NULL,
    created_date        DATE NOT NULL,
    
    FOREIGN KEY(from_user_id) REFERENCES User(user_id),
    FOREIGN KEY(to_user_id) REFERENCES User(user_id) 
);

INSERT INTO User(user_id, email_address, password, source, first_name, last_name, profile_picture_url, date_of_birth, about_me, notifications, dark_theme, created_date)
VALUES
(44,'lewis@f1.com','qwerty','APPL','Lewis','Hamilton',NULL,NULL,NULL,1,1,NULL),
(77,'valteri@f1.com','qwerty','APPL','Valteri','Bottas',NULL,NULL,NULL,0,0,NULL),
(6,'charles@f1.com','qwerty','APPL','Charles','Leclerk',NULL,NULL,NULL,0,0,NULL),
(55,'carlos@f1.com','qwerty','APPL','Carlos','Sainz',NULL,NULL,NULL,0,0,NULL),
(3,'max@f1.com','qwerty','APPL','Max','Verstappen',NULL,NULL,NULL,0,0,NULL);

