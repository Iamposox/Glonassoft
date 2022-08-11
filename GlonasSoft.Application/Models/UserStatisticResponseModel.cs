using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlonasSoft.Application.Models;

public class UserStatisticResponseModel
{
    public Guid StatisticId { get; set; }

    public int Percent { get; set; }

    public ResultResponseModel? Result { get; set; }
}
