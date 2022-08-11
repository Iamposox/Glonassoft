using GlonasSoft.BL.Models.Common;

namespace GlonasSoft.BL.Models;

public class UserStatistic : BaseEntity
{
    public Guid UserId { get; set; }

    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }

    public int CountSignIn { get; set; }
}
