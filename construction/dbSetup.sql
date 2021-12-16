-- CREATE TABLE IF NOT EXISTS accounts(
--   id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
--   createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
--   updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
--   name varchar(255) COMMENT 'User Name',
--   email varchar(255) COMMENT 'User Email',
--   picture varchar(255) COMMENT 'User Picture'
-- ) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS contractors (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name TEXT NOT NULL,
  creatorId TEXT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
CREATE TABLE accountcontractors(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
  accountId VARCHAR(255) NOT NULL,
  contractorId INT NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (contractorId) REFERENCES contractors(id) ON DELETE CASCADE
) DEFAULT CHARSET UTF8 COMMENT '';
SELECT
  *
FROM
  contractors;
SELECT
  c.*,
  acctContractors.id AS accountContractorId,
  a.*
FROM
  accountcontractors acctContractors
  JOIN contractors c ON c.id = acctContractors.contractorId
  JOIN accounts a ON a.id = c.creatorId
WHERE
  acctContractors.accountId = "61bbb1ae39975b2f8f7a1e23";
INSERT INTO
  accountcontractors (accountId, contractorId)
VALUES
  ("61bbb1ae39975b2f8f7a1e23", 15);
select
  *
FROM
  accountcontractors;