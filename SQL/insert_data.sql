INSERT INTO host1323541_lipetsk.tab_roles (name) VALUES ('student');
INSERT INTO host1323541_lipetsk.tab_roles (name) VALUES ('teacher');
INSERT INTO host1323541_lipetsk.tab_roles (name) VALUES ('admin');

INSERT INTO host1323541_lipetsk.tab_accounts (login, password, is_active)
VALUES ('student', '123', DEFAULT);
INSERT INTO host1323541_lipetsk.tab_accounts (login, password, is_active)
VALUES ('teacher', '123', DEFAULT);
INSERT INTO host1323541_lipetsk.tab_accounts (login, password, is_active)
VALUES ('admin', '123', DEFAULT);

INSERT INTO host1323541_lipetsk.tab_account_roles (account_id, role_id)
VALUES (1, 1);
INSERT INTO host1323541_lipetsk.tab_account_roles (account_id, role_id)
VALUES (2, 2);
INSERT INTO host1323541_lipetsk.tab_account_roles (account_id, role_id)
VALUES (3, 3);

INSERT INTO host1323541_lipetsk.tab_persons (first_name, last_name, date_of_birth, sex)
VALUES ('Stud', 'Student', '2022-02-04', 'F');
INSERT INTO host1323541_lipetsk.tab_persons (first_name, last_name, date_of_birth, sex)
VALUES ('Teach', 'Teacher', '2022-02-01', 'M');
INSERT INTO host1323541_lipetsk.tab_persons (first_name, last_name, date_of_birth, sex)
VALUES ('Admin', 'Administrator', '2022-01-31', 'F');

INSERT INTO host1323541_lipetsk.tab_groups (name)
VALUES ('F-55');

INSERT INTO host1323541_lipetsk.tab_students (person_id, group_id, is_study)
VALUES (1, 1, DEFAULT);

INSERT INTO host1323541_lipetsk.tab_teachers (person_id, group_id)
VALUES (2, 1);
