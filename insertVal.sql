INSERT INTO VotreTable (ExternalId, NumeroId, Val)
SELECT ExternalId, ISNULL(MAX(NumeroId), 0) + 1, '*'
FROM VotreTable
WHERE ExternalId IN (SELECT DISTINCT ExternalId FROM VotreTable WHERE <condition>)
GROUP BY ExternalId;