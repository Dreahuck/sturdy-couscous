CREATE PROCEDURE spGetCitiesByCountry @CountryID INT
AS
BEGIN
    SELECT 
        c.Name AS CountryName,
        (SELECT v.Name AS CityName 
         FROM Cities AS v
         WHERE v.CountryID = c.ID
         FOR JSON PATH) AS Cities
    FROM Countries AS c
    WHERE c.ID = @CountryID
    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER;
END
GO
