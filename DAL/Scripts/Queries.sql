SELECT * FROM Folder;

DELETE FROM Folder
WHERE ID = 'Black';

DELETE FROM Folder
WHERE ID IN ('Black', 'Grey', 'Light Blue', 'Magenta', 'Yellow');

SELECT * FROM Owner;
DELETE Owner;

DELETE FROM Bill;

SELECT * FROM Owner;
SELECT * FROM Folder;
SELECT * FROM Bill;

SELECT Folder
FROM Bill
ORDER BY Folder ASC;

SELECT * FROM Owner
WHERE Name = 'John Doe';
SELECT * FROM Folder
WHERE Name = 'Cable';
SELECT * FROM Bill
WHERE Folder = 'CB1';

INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (123, '10-10-2021', '08-10-2021', 10000, 1, 0xCE, 'CBE1');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (456, '10-10-2021', '08-10-2021', 2000, 1, 0xCE, 'CBE1');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (789, '10-10-2021', '08-10-2021', 30000, 1, 0xCE, 'CBE1');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (101, '10-10-2021', '08-10-2021', 10000, 1, 0xCE, 'CBE2');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (121, '10-10-2021', '08-10-2021', 2000, 1, 0xCE, 'CBE2');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (141, '10-10-2021', '08-10-2021', 30000, 1, 0xCE, 'CBE2');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (116, '10-10-2021', '08-10-2021', 10000, 1, 0xCE, 'CBE3');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (171, '10-10-2021', '08-10-2021', 2000, 1, 0xCE, 'CBE3');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (191, '10-10-2021', '08-10-2021', 30000, 1, 0xCE, 'CBE3');
