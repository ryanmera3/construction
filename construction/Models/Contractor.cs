using System.ComponentModel.DataAnnotations;

namespace construction.Models
{
  public class Contractor
  {

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public string CreatorId { get; set; }

  }
  public class ContractorAccountViewModel : Contractor
  {
    public int AccountContractorId { get; set; }
  }
}