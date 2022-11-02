--initialization

CREATE TABLE Product (
  id INT PRIMARY KEY IDENTITY,
  name VARCHAR(100)
);

CREATE TABLE Category (
  id INT PRIMARY KEY IDENTITY,
  name VARCHAR(100)
);

INSERT Product (name)
VALUES ('apple'),
('pear'),
('phone'),
('car'),
('glasses');

INSERT Category (name)
VALUES ('edible'),
('cheap'),
('expensive'),
('inedible'),
('something');

CREATE TABLE ProductCategory (
  id INT PRIMARY KEY IDENTITY,
  productId INT REFERENCES Product (id),
  categoryId INT REFERENCES Category (id)
);

INSERT ProductCategory (productId, categoryId)
VALUES (1, 1),
(1, 2),
(2, 1),
(2, 2),
(3, 3),
(3, 4),
(4, 3),
(4, 4);

--query

SELECT Product.name AS ProductName, Category.name AS CategoryName
FROM ProductCategory
RIGHT JOIN Product ON Product.id = productId
LEFT JOIN Category ON Category.id = categoryId;