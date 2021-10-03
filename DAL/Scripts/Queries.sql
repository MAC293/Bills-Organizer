SELECT * FROM Folder;

DELETE FROM Folder
WHERE ID = 'Black';

DELETE FROM Folder
WHERE ID IN ('Black', 'Grey', 'Light Blue', 'Magenta', 'Yellow');

SELECT * FROM Owner;
DELETE Owner;