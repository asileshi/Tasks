
select distinct l1.num as ConsecutiveNums 
from Logs as l1 inner join Logs as l2 on l1.num = l2.num and l1.id = l2.id-1 
inner join Logs as l3 on l3.num = l2.num and l2.id = l3.id-1 
