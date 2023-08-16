
select emp2.name as Employee  from Employee as emp1 inner join Employee as emp2 
on emp1.id = emp2.managerId
where emp2.salary>emp1.salary;