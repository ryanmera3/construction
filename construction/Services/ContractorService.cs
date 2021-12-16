using System;
using System.Collections.Generic;
using construction.Models;
using construction.Repositories;

namespace construction.Services
{
  public class ContractorService
  {
    private readonly ContractorsRepository _repo;

    public ContractorService(ContractorsRepository repo)
    {
      _repo = repo;
    }

    internal List<Contractor> Get()
    {
      return _repo.Get();
    }

    internal Contractor Create(Contractor newContractor)
    {
      return _repo.Create(newContractor);

    }

    internal Contractor Get(int id)
    {
      Contractor found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal void Remove(int id, string userId)
    {
      Contractor contractor = Get(id);
      if (contractor.CreatorId != userId)
      {
        throw new Exception("You are not allowed to remove this");
      }
      _repo.Remove(id);
    }
  }
}