using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using construction.Models;
using construction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace construction.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ContractorController : ControllerBase
  {
    private readonly ContractorService _cs;
    private readonly AccountService _acctService;

    public ContractorController(ContractorService cs, AccountService acctService)
    {
      _cs = cs;
      _acctService = acctService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Contractor>> Get()
    {
      try
      {
        var contractors = _cs.Get();
        return Ok(contractors);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        var contractor = _cs.Get(id);
        return Ok(contractor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/accounts")]
    public ActionResult<IEnumerable<AccountContractorViewModel>> GetAccounts(int id)
    {
      try
      {
        List<AccountContractorViewModel> accounts = _acctService.GetByContractorId(id);
        return Ok(accounts);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Contractor>> Create([FromBody] Contractor newContractor)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newContractor.CreatorId = userInfo?.Id;
        Contractor contractor = _cs.Create(newContractor);
        return Ok(contractor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Contractor>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _cs.Remove(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}