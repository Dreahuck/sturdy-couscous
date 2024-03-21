CREATE PROCEDURE MaProcedure
    @ID1 INT,
    @ID2 INT,
    -- Ajoutez d'autres paramètres d'ID si nécessaire
AS
BEGIN
    DECLARE @WhereClause NVARCHAR(MAX);
    SET @WhereClause = N'';

    -- Construisez la clause WHERE dynamiquement
    IF @ID1 IS NOT NULL
        SET @WhereClause = @WhereClause + N' OR ID = @ID1';
    IF @ID2 IS NOT NULL
        SET @WhereClause = @WhereClause + N' OR ID = @ID2';
    -- Ajoutez d'autres conditions ici

    -- Exécutez votre requête finale
    EXEC sp_executesql N'
        SELECT *
        FROM VotreTable
        WHERE 1 = 1 ' + @WhereClause;
END;
