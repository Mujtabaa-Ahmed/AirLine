create database Airline;
use Airline;
create table Role
(
r_id int not null primary key identity(1,1),
r_name varchar (255)
);
create table Users
(
u_id int not null primary key identity(1,1),
u_name varchar (255),
u_mail varchar (255),
u_pass varchar (255),
r_id int,
foreign key (r_id) references role(r_id),
);
select * from schedule;
select * from rout;
select * from Users;

create table flight
(
f_id int not null primary key identity(1,1),
f_name varchar (255)
);
create table rout
(
Rout_id int not null primary key identity (1,1),
rout_name varchar (255),
);

create table schedule
(
s_id int not null primary key identity(1,1),
f_id int,
rout_id int,
s_departure datetime,
s_arival datetime,
foreign key (f_id) references flight(f_id),
foreign key (rout_id) references rout(rout_id),
);
create table class
(
c_id int not null primary key identity (1,1),
c_name varchar (255),
c_price int,
);	
create table booking
(
 b_id int not null primary key identity (1,1),
 b_quan int,
 b_amount int,
 c_id int,
 s_id int,
 foreign key (c_id) references class(c_id),
 foreign key (s_id) references schedule(s_id)
);

Delete from schedule where s_id = 1;