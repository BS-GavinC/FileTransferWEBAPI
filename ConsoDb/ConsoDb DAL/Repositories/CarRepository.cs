using System.Data;
using ConsoDb;
using ConsoDb_DAL.Interfaces;
using ConsoDb_DAL.Services;

namespace ConsoDb_DAL.Repositories;

public class CarRepository : ICarRepository
{

    private readonly IDbConnection _dbConnection;

    public CarRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public int Add(Car car)
    {
        IDbCommand cmd = _dbConnection.CreateCommand();

        cmd.CommandText = "INSERT INTO cars(id, brand, model) VALUES(@id, @brand, @model)";

        cmd.AddParametersWithValues("id", car.Id);
        cmd.AddParametersWithValues("brand", car.Brand);
        cmd.AddParametersWithValues("model", car.Model);
        
        _dbConnection.Open();

        int result = cmd.ExecuteNonQuery();
        
        _dbConnection.Close();

        return result;

    }
}