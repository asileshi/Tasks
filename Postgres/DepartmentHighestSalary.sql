SELECT dep.name AS Department,
       emp.name AS Employee,
       emp.salary AS Salary
FROM Employee AS emp
INNER JOIN Department AS dep ON emp.departmentId = dep.id
WHERE (emp.departmentId, emp.salary) IN (
    SELECT departmentId, MAX(salary)
    FROM Employee
    GROUP BY departmentId
);
