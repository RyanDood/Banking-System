--CREATING DATABASE:
create database HMBank

--CREATING TABLES:
create table Customers(
customer_id int identity(1,1) primary key,
first_name varchar(50),
last_name varchar(50),
DOB date,
email varchar(50),
phone_number varchar(15),
address varchar(max)
)

create table Accounts(
account_id bigint identity(1001,1) primary key,
customer_id int,
account_type varchar(50),
balance decimal(18,2) check (balance >= 0),
constraint Accounts_Customers foreign key(customer_id) references Customers(customer_id) on delete cascade
)

create table Transactions(
transaction_id int identity(101,1) primary key,
account_id bigint,
transaction_type varchar(50),
amount decimal(18,2) check (amount > 0),
transaction_date date
constraint Transactions_Accounts foreign key(account_id) references Accounts(account_id) on delete cascade
)

--INSERTING VALUES:
insert into Customers
values
('Ryan','Paul','2002-03-13','ryan@email.com','9876543210','Trichy,TamilNadu'),
('Arun','Vijay','1992-07-15','arun@email.com','9638527410','Chennai,TamilNadu'),
('Jabez','John','2001-02-02','jabez@email.com','8695742310','Bangalore,Karnataka')

insert into Accounts
values
(1,'Savings',25000),
(2,'Current',75000),
(3,'ZeroBalance',125000)

insert into Transactions
values
(1001,'Deposit',5000,'2022-12-17'),
(1002,'Withdrawal',10000,'2023-01-11'),
(1003,'Transfer',20000,'2023-01-16'),
(1001,'Withdrawal',2000,'2023-02-01')


--TRANSACTIONS OF AN ACCOUNT WITHIN A PARTICULAR PERIOD
select * from Transactions where transaction_date between '2023-01-16' and '2023-02-01' and account_id = 1003

--VIEW BALANCE
select balance from Accounts where account_id  = 1001

--DEPOSIT
update Accounts set balance = balance + 100 where account_id = 1001

--WITHDRAW
update Accounts set balance = balance - 100 where account_id = 1001

--ACCOUNT AND CUTOMER DETAILS
select account_id,account_type,balance,first_name,email,phone_number,address from Accounts inner join Customers on Accounts.customer_id = Customers.customer_id where account_id = 1001

--CREATE ACCCOUNT
insert into Accounts values (1,'Savings',25000)
