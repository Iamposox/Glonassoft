using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlonasSoft.Application.Models;

public class ResultResponseModel
{
    public Guid UserId { get; set; }

    public int CountSignIn { get; set; }
}
