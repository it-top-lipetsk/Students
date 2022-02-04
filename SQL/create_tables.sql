CREATE TABLE tab_accounts
(
    id        INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    login     VARCHAR(25) NOT NULL UNIQUE,
    password  TEXT NOT NULL,
    is_active BOOL NOT NULL DEFAULT TRUE
);

CREATE TABLE tab_roles
(
    id   INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name TEXT NOT NULL
);

CREATE TABLE tab_account_roles
(
    id         INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    account_id INT NOT NULL,
    role_id    INT NOT NULL,
    FOREIGN KEY (account_id) REFERENCES tab_accounts (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    FOREIGN KEY (role_id) REFERENCES tab_roles (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_persons
(
    id            INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    first_name    TEXT NOT NULL,
    last_name     TEXT NOT NULL,
    date_of_birth DATE NOT NULL,
    sex           CHAR NOT NULL,
    FOREIGN KEY (id) REFERENCES tab_accounts (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_groups
(
    id   INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name TEXT NOT NULL
);

CREATE TABLE tab_teachers
(
    id        INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    person_id INT NOT NULL,
    group_id  INT NOT NULL,
    FOREIGN KEY (person_id) REFERENCES tab_persons (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    FOREIGN KEY (group_id) REFERENCES tab_groups (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_students
(
    id        INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    person_id INT  NOT NULL,
    group_id  INT  NOT NULL,
    is_study  BOOL NOT NULL DEFAULT TRUE,
    FOREIGN KEY (person_id) REFERENCES tab_persons (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    FOREIGN KEY (group_id) REFERENCES tab_groups (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);