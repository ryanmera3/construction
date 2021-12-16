using System.Collections.Generic;
using System.Data;
using System.Linq;
using construction.Models;
using Dapper;

namespace construction.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Contractor> Get()
    {
      string sql = "SELECT * FROM contractors;";
      return _db.Query<Contractor>(sql).ToList();
    }

    internal Contractor Get(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id;";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }
    internal Contractor Create(Contractor newContractor)
    {
      string sql = @"
      INSERT INTO contractors
      (name, creatorId)
      VALUES
      (@Name, @CreatorId);
      SELECT LAST_INSERT_ID()
      ;";
      int id = _db.ExecuteScalar<int>(sql, newContractor);
      newContractor.Id = id;
      return newContractor;
    }
  }
}