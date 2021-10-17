SELECT * FROM Folder;

DELETE FROM Folder
WHERE ID = 'Black';

DELETE FROM Folder
WHERE ID IN ('Black', 'Grey', 'Light Blue', 'Magenta', 'Yellow');

SELECT * FROM Owner;
DELETE Owner;

SELECT * FROM Bill;

INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (123, '10-10-2021', '08-10-2021', 10000, 1, 0xCE, 'CBE1');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (456, '10-10-2021', '08-10-2021', 2000, 1, 0xCE, 'CBE1');
INSERT INTO Bill (Number, DateIssue, ExpiringDate, TotalPay, Status, Image, Folder)
VALUES (789, '10-10-2021', '08-10-2021', 30000, 1, 0xCE, 'CBE1');
