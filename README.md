Часть 2
Задание 1:

SELECT c.clientname ,  COUNT(DISTINCT cc.id) as "contactsCount"
from clients c
left JOIN clientcontacts cc ON cc.clientid = c.id
group  by c.id


Задание 2:

SELECT c.clientname ,  COUNT(DISTINCT cc.id) as "contactsCount"
from clients c
left JOIN clientcontacts cc ON cc.clientid = c.id
group  by c.id
HAVING COUNT(*) > 2
